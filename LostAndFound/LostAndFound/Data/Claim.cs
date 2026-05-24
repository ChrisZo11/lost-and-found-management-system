using System;
using System.Data;
using System.Data.SqlClient;

namespace LostAndFound
{
    public interface IClaim
    {
        DataTable GetAllClaims(DateTime? fromDate = null, DateTime? toDate = null);
        void CreatePendingClaim(ClaimRequest request);
        void CreateApprovedClaim(ClaimRequest request, int processedByUserId);
        void ApprovePendingClaim(int claimId, int processedByUserId);
    }

    public sealed class Claim : DatabaseEntity, IClaim
    {
        public Claim()
        {
        }

        public Claim(string connectionString)
            : base(connectionString)
        {
        }

        public DataTable GetAllClaims(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection conn = CreateConnection())
            {
                const string query = @"
                    SELECT
                        c.ClaimID,
                        c.ItemID,
                        i.ItemName AS ClaimedItem,
                        c.StudentNIM,
                        COALESCE(c.StudentName, c.ClaimantName) AS StudentName,
                        c.ClaimedAt,
                        COALESCE(u.FullName, u.Username) AS ProcessedBy,
                        cs.StatusName AS ClaimStatus,
                        i.Location,
                        c.ClaimPhotoPath
                    FROM Claims c
                    INNER JOIN Items i ON i.ItemID = c.ItemID
                    INNER JOIN ClaimStatuses cs ON cs.ClaimStatusID = c.ClaimStatusID
                    LEFT JOIN Users u ON u.UserID = c.ProcessedBy
                    WHERE (@fromDate IS NULL OR c.ClaimedAt >= @fromDate)
                        AND (@toDate IS NULL OR c.ClaimedAt < @toDate)
                    ORDER BY c.ClaimedAt DESC, c.ClaimID DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value = (object)fromDate ?? DBNull.Value;
                    cmd.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = (object)toDate ?? DBNull.Value;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ConfigureClaimsColumns(table);
                    return table;
                }
            }
        }

        public void CreatePendingClaim(ClaimRequest request)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    EnsureItemCanBeClaimed(conn, trans, request.ItemId);
                    EnsureItemHasNoActiveClaim(conn, trans, request.ItemId);
                    InsertPendingClaim(conn, trans, request);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void CreateApprovedClaim(ClaimRequest request, int processedByUserId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    EnsureItemCanBeClaimed(conn, trans, request.ItemId);
                    EnsureItemHasNoActiveClaim(conn, trans, request.ItemId);
                    int claimId = InsertApprovedClaim(conn, trans, request, processedByUserId);
                    MarkClaimedItemReturned(conn, trans, claimId);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void ApprovePendingClaim(int claimId, int processedByUserId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    ApproveClaim(conn, trans, claimId, processedByUserId);
                    MarkClaimedItemReturned(conn, trans, claimId);
                    RejectOtherPendingClaims(conn, trans, claimId, processedByUserId);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        private static int InsertApprovedClaim(SqlConnection conn, SqlTransaction trans, ClaimRequest request, int processedByUserId)
        {
            const string query = @"
                INSERT INTO Claims
                (
                    ItemID,
                    ClaimantName,
                    StudentNIM,
                    StudentName,
                    ClaimPhotoPath,
                    ClaimStatusID,
                    ClaimDate,
                    ClaimedAt,
                    ProcessedBy,
                    ProcessedAt
                )
                OUTPUT INSERTED.ClaimID
                VALUES
                (
                    @itemId,
                    @studentName,
                    @studentNim,
                    @studentName,
                    @photoPath,
                    (SELECT ClaimStatusID FROM ClaimStatuses WHERE StatusName = @approvedClaimStatus),
                    SYSDATETIME(),
                    SYSDATETIME(),
                    @user,
                    SYSDATETIME()
                )";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@itemId", request.ItemId);
                cmd.Parameters.AddWithValue("@studentName", request.StudentName);
                cmd.Parameters.AddWithValue("@studentNim", request.StudentNim);
                cmd.Parameters.AddWithValue("@photoPath", request.ClaimPhotoPath);
                cmd.Parameters.AddWithValue("@approvedClaimStatus", DomainValues.ClaimStatuses.Approved);
                cmd.Parameters.AddWithValue("@user", processedByUserId);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static void ConfigureClaimsColumns(DataTable table)
        {
            DataTableColumnMetadata.Configure(table, "ClaimID", "ID", 64F);
            DataTableColumnMetadata.Configure(table, "ItemID", visible: false);
            DataTableColumnMetadata.Configure(table, "ClaimedItem", "Item", 160F);
            DataTableColumnMetadata.Configure(table, "StudentNIM", "NIM", 104F);
            DataTableColumnMetadata.Configure(table, "StudentName", "Nama", 150F);
            DataTableColumnMetadata.Configure(table, "ClaimedAt", "Tanggal", 120F, "dd/MM/yyyy HH:mm");
            DataTableColumnMetadata.Configure(table, "ProcessedBy", "Diproses", visible: false);
            DataTableColumnMetadata.Configure(table, "ClaimStatus", "Status Klaim", 126F);
            DataTableColumnMetadata.Configure(table, "Location", "Lokasi", 140F);
            DataTableColumnMetadata.Configure(table, "ClaimPhotoPath", visible: false);
        }

        private static void EnsureItemCanBeClaimed(SqlConnection conn, SqlTransaction trans, int itemId)
        {
            const string query = @"
                SELECT COUNT(1)
                FROM Items i
                INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                WHERE i.ItemID = @itemId
                    AND t.TypeName = @foundType
                    AND s.StatusName != @returnedItemStatus";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.Parameters.AddWithValue("@foundType", DomainValues.ItemTypes.Found);
                cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    throw new InvalidOperationException("Item ini tidak tersedia untuk diklaim.");
                }
            }
        }

        private static void EnsureItemHasNoActiveClaim(SqlConnection conn, SqlTransaction trans, int itemId)
        {
            const string query = @"
                SELECT COUNT(1)
                FROM Claims c
                INNER JOIN ClaimStatuses cs ON cs.ClaimStatusID = c.ClaimStatusID
                WHERE c.ItemID = @itemId AND cs.StatusName IN (@pendingClaimStatus, @approvedClaimStatus)";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.Parameters.AddWithValue("@pendingClaimStatus", DomainValues.ClaimStatuses.Pending);
                cmd.Parameters.AddWithValue("@approvedClaimStatus", DomainValues.ClaimStatuses.Approved);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    throw new InvalidOperationException("Item ini sudah punya klaim aktif.");
                }
            }
        }

        private static void InsertPendingClaim(SqlConnection conn, SqlTransaction trans, ClaimRequest request)
        {
            const string query = @"
                INSERT INTO Claims
                (
                    ItemID,
                    ClaimantName,
                    StudentNIM,
                    StudentName,
                    ClaimPhotoPath,
                    ClaimStatusID,
                    ClaimDate,
                    ClaimedAt
                )
                VALUES
                (
                    @itemId,
                    @studentName,
                    @studentNim,
                    @studentName,
                    @photoPath,
                    (SELECT ClaimStatusID FROM ClaimStatuses WHERE StatusName = @pendingClaimStatus),
                    SYSDATETIME(),
                    SYSDATETIME()
                )";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@itemId", request.ItemId);
                cmd.Parameters.AddWithValue("@studentName", request.StudentName);
                cmd.Parameters.AddWithValue("@studentNim", request.StudentNim);
                cmd.Parameters.AddWithValue("@photoPath", request.ClaimPhotoPath);
                cmd.Parameters.AddWithValue("@pendingClaimStatus", DomainValues.ClaimStatuses.Pending);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ApproveClaim(SqlConnection conn, SqlTransaction trans, int claimId, int processedByUserId)
        {
            const string query = @"
                UPDATE Claims
                SET
                    ClaimStatusID = (SELECT ClaimStatusID FROM ClaimStatuses WHERE StatusName = @approvedClaimStatus),
                    ProcessedBy = @user,
                    ProcessedAt = SYSDATETIME()
                WHERE
                    ClaimID = @claimId
                    AND ClaimStatusID = (SELECT ClaimStatusID FROM ClaimStatuses WHERE StatusName = @pendingClaimStatus)";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@claimId", claimId);
                cmd.Parameters.AddWithValue("@user", processedByUserId);
                cmd.Parameters.AddWithValue("@approvedClaimStatus", DomainValues.ClaimStatuses.Approved);
                cmd.Parameters.AddWithValue("@pendingClaimStatus", DomainValues.ClaimStatuses.Pending);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException("Request klaim ini sudah diproses.");
                }
            }
        }

        private static void MarkClaimedItemReturned(SqlConnection conn, SqlTransaction trans, int claimId)
        {
            const string query = @"
                UPDATE i
                SET ItemStatusID = s.ItemStatusID
                FROM Items i
                INNER JOIN Claims c ON c.ItemID = i.ItemID
                INNER JOIN ItemStatuses s ON s.StatusName = @returnedItemStatus
                WHERE c.ClaimID = @claimId";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@claimId", claimId);
                cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                cmd.ExecuteNonQuery();
            }
        }

        private static void RejectOtherPendingClaims(SqlConnection conn, SqlTransaction trans, int claimId, int processedByUserId)
        {
            const string query = @"
                UPDATE otherClaims
                SET
                    ClaimStatusID = rejectedStatus.ClaimStatusID,
                    ProcessedBy = @user,
                    ProcessedAt = SYSDATETIME()
                FROM Claims otherClaims
                INNER JOIN Claims approvedClaim ON approvedClaim.ItemID = otherClaims.ItemID
                INNER JOIN ClaimStatuses pendingStatus ON pendingStatus.StatusName = @pendingClaimStatus
                INNER JOIN ClaimStatuses rejectedStatus ON rejectedStatus.StatusName = @rejectedClaimStatus
                WHERE
                    approvedClaim.ClaimID = @claimId
                    AND otherClaims.ClaimID != @claimId
                    AND otherClaims.ClaimStatusID = pendingStatus.ClaimStatusID";

            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@claimId", claimId);
                cmd.Parameters.AddWithValue("@user", processedByUserId);
                cmd.Parameters.AddWithValue("@pendingClaimStatus", DomainValues.ClaimStatuses.Pending);
                cmd.Parameters.AddWithValue("@rejectedClaimStatus", DomainValues.ClaimStatuses.Rejected);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
