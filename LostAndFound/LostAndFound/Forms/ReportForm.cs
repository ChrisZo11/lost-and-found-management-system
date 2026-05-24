using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Reporting.WinForms;

namespace LostAndFound
{
    public partial class ReportForm : Form
    {
        private readonly string cs = "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=LostAndFoundDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True";
        private Guna2Panel reportHeader;
        private Guna2HtmlLabel reportTitle;
        private Guna2HtmlLabel reportSubtitle;

        public ReportForm()
        {
            InitializeComponent();
            ConfigureVisualDesign();
        }

        private void ConfigureVisualDesign()
        {
            UiTheme.StyleForm(this, new Size(980, 640), true);
            Text = "Laporan Item - Lost and Found";
            BuildReportHeader();
            reportViewer.Dock = DockStyle.None;
            reportViewer.Location = new Point(0, reportHeader.Bottom);
            reportViewer.Size = new Size(ClientSize.Width, ClientSize.Height - reportHeader.Height);
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer.BackColor = UiTheme.Surface;
        }

        private void BuildReportHeader()
        {
            if (reportHeader == null)
            {
                reportHeader = new Guna2Panel
                {
                    Dock = DockStyle.Top,
                    FillColor = UiTheme.Surface,
                    Height = 82,
                    Name = "reportHeader"
                };

                reportTitle = new Guna2HtmlLabel();
                reportSubtitle = new Guna2HtmlLabel();
                reportHeader.Controls.Add(reportTitle);
                reportHeader.Controls.Add(reportSubtitle);
                Controls.Add(reportHeader);
            }

            reportTitle.Text = "Laporan Item";
            reportSubtitle.Text = "Ringkasan item hilang, ditemukan, dan dikembalikan";
            UiTheme.StyleTitle(reportTitle, 16F);
            UiTheme.StyleSubtitle(reportSubtitle);
            reportTitle.Location = new Point(28, 18);
            reportSubtitle.Location = new Point(30, 48);
            reportHeader.BringToFront();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (UiTheme.IsDesignMode(this))
            {
                return;
            }

            LoadItemsReport();
        }

        private void LoadItemsReport()
        {
            try
            {
                DataTable items = GetReportItems();
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "ItemsReport.rdlc");

                if (!File.Exists(reportPath))
                {
                    throw new FileNotFoundException("Report definition file was not found.", reportPath);
                }

                reportViewer.LocalReport.ReportPath = reportPath;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemsDataSet", items));
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memuat laporan: " + ex.Message);
            }
        }

        private DataTable GetReportItems()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                const string query = @"
                    SELECT
                        ItemID,
                        ItemName,
                        t.TypeName AS Type,
                        s.StatusName AS Status,
                        i.Location,
                        CASE
                            WHEN i.DateReported IS NULL THEN ''
                            ELSE CONVERT(varchar(10), i.DateReported, 103)
                        END AS DateReported
                    FROM Items i
                    INNER JOIN ItemTypes t ON t.ItemTypeID = i.ItemTypeID
                    INNER JOIN ItemStatuses s ON s.ItemStatusID = i.ItemStatusID
                    ORDER BY i.DateReported DESC, i.ItemID DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable("ItemsDataSet");
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
