using System;
using System.Data;
using System.Data.SqlClient;

namespace LostAndFound
{
    public interface IItem
    {
        DataTable GetActiveFoundItems(DateTime? fromDate = null, DateTime? toDate = null);
        DataTable GetActiveLostItems(DateTime? fromDate = null, DateTime? toDate = null);
        ItemStats GetStats();
        void CreateReport(ItemReportRequest request);
        void MarkLostItemReturned(int itemId);
    }

    public sealed class Item : DatabaseEntity, IItem
    {
        public Item()
        {
        }

        public Item(string connectionString)
            : base(connectionString)
        {
        }

        public DataTable GetActiveFoundItems(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection conn = CreateConnection())
            {
                const string query = @"
                    SELECT
                        i.ItemID,
                        i.ItemName,
                        t.TypeName AS Type,
                        s.StatusName AS Status,
                        i.Location,
                        i.DateReported,
                        (
                            SELECT COUNT(1)
                            FROM Claims c
                            INNER JOIN ClaimStatuses cs ON cs.ClaimStatusID = c.ClaimStatusID
                            WHERE c.ItemID = i.ItemID AND cs.StatusName IN (@pendingClaimStatus, @approvedClaimStatus)
                        ) AS ActiveClaims,
                        i.ImagePath
                    FROM Items i
                    INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                    INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                    WHERE t.TypeName = @foundType AND s.StatusName != @returnedItemStatus
                        AND (@fromDate IS NULL OR i.DateReported >= @fromDate)
                        AND (@toDate IS NULL OR i.DateReported < @toDate)
                    ORDER BY i.DateReported DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pendingClaimStatus", DomainValues.ClaimStatuses.Pending);
                    cmd.Parameters.AddWithValue("@approvedClaimStatus", DomainValues.ClaimStatuses.Approved);
                    cmd.Parameters.AddWithValue("@foundType", DomainValues.ItemTypes.Found);
                    cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                    cmd.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value = (object)fromDate ?? DBNull.Value;
                    cmd.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = (object)toDate ?? DBNull.Value;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ConfigureActiveFoundItemsColumns(table);
                    return table;
                }
            }
        }

        public DataTable GetActiveLostItems(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection conn = CreateConnection())
            {
                const string query = @"
                    SELECT
                        i.ItemID,
                        i.ItemName,
                        t.TypeName AS Type,
                        s.StatusName AS Status,
                        i.Location,
                        i.DateReported,
                        i.ImagePath
                    FROM Items i
                    INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                    INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                    WHERE t.TypeName = @lostType AND s.StatusName != @returnedItemStatus
                        AND (@fromDate IS NULL OR i.DateReported >= @fromDate)
                        AND (@toDate IS NULL OR i.DateReported < @toDate)
                    ORDER BY i.DateReported DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lostType", DomainValues.ItemTypes.Lost);
                    cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                    cmd.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value = (object)fromDate ?? DBNull.Value;
                    cmd.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = (object)toDate ?? DBNull.Value;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ConfigureActiveLostItemsColumns(table);
                    return table;
                }
            }
        }

        public ItemStats GetStats()
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                return new ItemStats
                {
                    LostCount = CountActiveItemsByType(conn, DomainValues.ItemTypes.Lost),
                    FoundCount = CountActiveItemsByType(conn, DomainValues.ItemTypes.Found),
                    ReturnedCount = CountReturnedItems(conn)
                };
            }
        }

        public void CreateReport(ItemReportRequest request)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                const string query = @"
                    INSERT INTO Items
                    (
                        ItemName,
                        Description,
                        DateReported,
                        Location,
                        ItemTypeID,
                        ItemStatusID,
                        ReportedBy,
                        ImagePath
                    )
                    VALUES
                    (
                        @name,
                        @desc,
                        SYSDATETIME(),
                        @loc,
                        (SELECT ItemTypeID FROM ItemTypes WHERE TypeName = @type),
                        (SELECT ItemStatusID FROM ItemStatuses WHERE StatusName = @pendingItemStatus),
                        @user,
                        @imagePath
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", request.ItemName);
                    cmd.Parameters.AddWithValue("@desc", request.Description);
                    cmd.Parameters.AddWithValue("@loc", request.Location);
                    cmd.Parameters.AddWithValue("@type", request.Type);
                    cmd.Parameters.AddWithValue("@pendingItemStatus", DomainValues.ItemStatuses.Pending);
                    cmd.Parameters.AddWithValue("@user", request.ReportedBy);
                    cmd.Parameters.AddWithValue("@imagePath", (object)request.ImagePath ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MarkLostItemReturned(int itemId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                const string query = @"
                    UPDATE i
                    SET ItemStatusID = returnedStatus.ItemStatusID
                    FROM Items i
                    INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                    INNER JOIN ItemStatuses currentStatus ON currentStatus.ItemStatusID = i.ItemStatusID
                    INNER JOIN ItemStatuses returnedStatus ON returnedStatus.StatusName = @returnedItemStatus
                    WHERE i.ItemID = @itemId
                        AND t.TypeName = @lostType
                        AND currentStatus.StatusName != @returnedItemStatus";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@lostType", DomainValues.ItemTypes.Lost);
                    cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("Laporan hilang ini sudah selesai atau tidak tersedia.");
                    }
                }
            }
        }

        private static int CountActiveItemsByType(SqlConnection conn, string typeName)
        {
            const string query = @"
                SELECT COUNT(*)
                FROM Items i
                INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                WHERE t.TypeName = @typeName AND s.StatusName != @returnedItemStatus";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@typeName", typeName);
                cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static int CountReturnedItems(SqlConnection conn)
        {
            const string query = @"
                SELECT COUNT(*)
                FROM Items i
                INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                WHERE s.StatusName = @returnedItemStatus";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@returnedItemStatus", DomainValues.ItemStatuses.Returned);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static void ConfigureActiveFoundItemsColumns(DataTable table)
        {
            DataTableColumnMetadata.Configure(table, "ItemID", "ID", 52F);
            DataTableColumnMetadata.Configure(table, "ItemName", "Item", 150F);
            DataTableColumnMetadata.Configure(table, "Type", "Type", 86F);
            DataTableColumnMetadata.Configure(table, "Status", "Status", 96F);
            DataTableColumnMetadata.Configure(table, "Location", "Lokasi", 140F);
            DataTableColumnMetadata.Configure(table, "DateReported", "Tanggal", 122F, "dd/MM/yyyy HH:mm");
            DataTableColumnMetadata.Configure(table, "ActiveClaims", "Klaim Aktif", 96F);
            DataTableColumnMetadata.Configure(table, "ImagePath", visible: false);
        }

        private static void ConfigureActiveLostItemsColumns(DataTable table)
        {
            DataTableColumnMetadata.Configure(table, "ItemID", "ID", 52F);
            DataTableColumnMetadata.Configure(table, "ItemName", "Item", 170F);
            DataTableColumnMetadata.Configure(table, "Type", "Type", 86F);
            DataTableColumnMetadata.Configure(table, "Status", "Status", 96F);
            DataTableColumnMetadata.Configure(table, "Location", "Lokasi", 150F);
            DataTableColumnMetadata.Configure(table, "DateReported", "Tanggal", 122F, "dd/MM/yyyy HH:mm");
            DataTableColumnMetadata.Configure(table, "ImagePath", visible: false);
        }
    }
}
