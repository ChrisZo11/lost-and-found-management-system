using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Reporting.WinForms;

namespace LostAndFound
{
    public partial class ReportForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private const int TitleBarHeight = 42;

        private readonly IItem item;

        private Guna2Panel panelWindowChrome;
        private Guna2Panel panelWindowIcon;
        private Guna2Panel panelWindowDivider;
        private Label lblWindowTitle;
        private Guna2Button btnWindowMinimize;
        private Guna2Button btnWindowMaximize;
        private Guna2Button btnWindowClose;

        private Guna2Panel reportHeader;
        private Guna2HtmlLabel reportTitle;
        private Guna2HtmlLabel reportSubtitle;

        private Guna2Panel filterPanel;
        private Guna2Button btnShowAll;
        private Guna2Button btnShowFound;
        private Guna2Button btnShowLost;
        private Guna2DateTimePicker dtpFromDate;
        private Guna2DateTimePicker dtpToDate;
        private Label lblFromDate;
        private Label lblToDate;
        private Guna2Button btnClearDateFilter;

        private Guna2Panel panelLostMetric;
        private Guna2Panel panelFoundMetric;
        private Guna2Panel panelReturnedMetric;
        private Label lblLost;
        private Label lblFound;
        private Label lblReturned;

        private Label lblEmptyState;

        private enum ReportMode { All, Found, Lost }
        private ReportMode mode = ReportMode.All;
        private bool initialReportLoaded;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int message, int wParam, int lParam);

        public ReportForm()
            : this(new Item())
        {
        }

        public ReportForm(IItem item)
        {
            this.item = item ?? throw new ArgumentNullException(nameof(item));
            InitializeComponent();
            ConfigureVisualDesign();
        }

        private void ConfigureVisualDesign()
        {
            UiTheme.StyleForm(this, new Size(980, 640), true);
            Text = "Laporan Item - Lost and Found";

            BuildWindowChrome();
            BuildReportHeader();
            BuildFilterBar();
            BuildStatPills();
            BuildEmptyState();

            reportViewer.Dock = DockStyle.None;
            reportViewer.BackColor = UiTheme.Surface;

            LayoutReportControls();
            Resize += (sender, e) => LayoutReportControls();
        }

        private void BuildReportHeader()
        {
            if (reportHeader == null)
            {
                reportHeader = new Guna2Panel
                {
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
            panelWindowChrome?.BringToFront();
        }

        private void BuildWindowChrome()
        {
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = true;
            MaximizeBox = true;

            if (panelWindowChrome == null)
            {
                panelWindowChrome = new Guna2Panel { Name = "panelWindowChrome" };
            }

            panelWindowChrome.Dock = DockStyle.Top;
            panelWindowChrome.FillColor = Color.FromArgb(246, 250, 252);
            panelWindowChrome.Height = TitleBarHeight;

            if (panelWindowIcon == null)
            {
                panelWindowIcon = new Guna2Panel { Name = "panelWindowIcon" };
            }

            if (lblWindowTitle == null)
            {
                lblWindowTitle = new Label { Name = "lblWindowTitle" };
            }

            lblWindowTitle.BackColor = Color.Transparent;
            lblWindowTitle.Font = UiTheme.Font(9F, FontStyle.Bold);
            lblWindowTitle.ForeColor = UiTheme.Text;
            lblWindowTitle.Text = "Lost & Found";

            if (btnWindowMinimize == null)
            {
                btnWindowMinimize = CreateChromeButton("btnWindowMinimize", "-");
            }

            if (btnWindowMaximize == null)
            {
                btnWindowMaximize = CreateChromeButton("btnWindowMaximize", "\u25A1");
            }

            if (btnWindowClose == null)
            {
                btnWindowClose = CreateChromeButton("btnWindowClose", "x");
            }

            if (panelWindowDivider == null)
            {
                panelWindowDivider = new Guna2Panel { Name = "panelWindowDivider" };
            }

            panelWindowDivider.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelWindowDivider.FillColor = Color.FromArgb(224, 232, 238);
            panelWindowDivider.Location = new Point(0, 41);
            panelWindowDivider.Size = new Size(ClientSize.Width, 1);

            ConfigureChromeButton(btnWindowMinimize, "-");
            ConfigureChromeButton(btnWindowMaximize, "\u25A1");
            ConfigureChromeButton(btnWindowClose, "x");

            UiTheme.StyleTitleBarLogo(panelWindowIcon, lblWindowTitle);
            btnWindowClose.HoverState.FillColor = UiTheme.Danger;
            btnWindowClose.HoverState.ForeColor = Color.White;

            AddIfMissing(panelWindowChrome, panelWindowIcon);
            AddIfMissing(panelWindowChrome, lblWindowTitle);
            AddIfMissing(panelWindowChrome, btnWindowMinimize);
            AddIfMissing(panelWindowChrome, btnWindowMaximize);
            AddIfMissing(panelWindowChrome, btnWindowClose);
            AddIfMissing(panelWindowChrome, panelWindowDivider);
            AddIfMissing(this, panelWindowChrome);

            panelWindowChrome.MouseDown -= WindowChrome_MouseDown;
            lblWindowTitle.MouseDown -= WindowChrome_MouseDown;
            panelWindowIcon.MouseDown -= WindowChrome_MouseDown;
            btnWindowMinimize.Click -= btnWindowMinimize_Click;
            btnWindowMaximize.Click -= btnWindowMaximize_Click;
            btnWindowClose.Click -= btnWindowClose_Click;

            panelWindowChrome.MouseDown += WindowChrome_MouseDown;
            lblWindowTitle.MouseDown += WindowChrome_MouseDown;
            panelWindowIcon.MouseDown += WindowChrome_MouseDown;
            btnWindowMinimize.Click += btnWindowMinimize_Click;
            btnWindowMaximize.Click += btnWindowMaximize_Click;
            btnWindowClose.Click += btnWindowClose_Click;

            LayoutWindowChrome();
            UpdateMaximizeButtonText();
        }

        private Guna2Button CreateChromeButton(string name, string text)
        {
            var button = new Guna2Button
            {
                Name = name
            };
            ConfigureChromeButton(button, text);
            return button;
        }

        private void ConfigureChromeButton(Guna2Button button, string text)
        {
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.BorderRadius = 8;
            button.FillColor = Color.Transparent;
            button.Font = UiTheme.Font(10F, FontStyle.Bold);
            button.ForeColor = UiTheme.Muted;
            button.HoverState.FillColor = Color.FromArgb(230, 238, 243);
            button.Size = new Size(34, 30);
            button.Text = text;
            button.TextAlign = HorizontalAlignment.Center;
            button.TextOffset = new Point(0, -1);
        }

        private void BuildFilterBar()
        {
            if (filterPanel == null)
            {
                filterPanel = new Guna2Panel { Name = "filterPanel" };
            }

            filterPanel.BackColor = Color.Transparent;
            filterPanel.Height = 44;
            AddIfMissing(this, filterPanel);

            if (btnShowAll == null) btnShowAll = CreateModeButton("Semua", "btnShowAll");
            if (btnShowFound == null) btnShowFound = CreateModeButton("Ditemukan", "btnShowFound");
            if (btnShowLost == null) btnShowLost = CreateModeButton("Hilang", "btnShowLost");

            btnShowAll.Click -= btnShowAll_Click;
            btnShowFound.Click -= btnShowFound_Click;
            btnShowLost.Click -= btnShowLost_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnShowFound.Click += btnShowFound_Click;
            btnShowLost.Click += btnShowLost_Click;

            AddIfMissing(filterPanel, btnShowAll);
            AddIfMissing(filterPanel, btnShowFound);
            AddIfMissing(filterPanel, btnShowLost);

            if (lblFromDate == null)
            {
                lblFromDate = new Label();
            }

            lblFromDate.AutoSize = false;
            lblFromDate.BackColor = Color.Transparent;
            lblFromDate.Font = UiTheme.Font(8F, FontStyle.Bold);
            lblFromDate.ForeColor = UiTheme.Muted;
            lblFromDate.Text = "Dari";
            lblFromDate.TextAlign = ContentAlignment.MiddleLeft;
            lblFromDate.Size = new Size(32, 22);

            if (lblToDate == null)
            {
                lblToDate = new Label();
            }

            lblToDate.AutoSize = false;
            lblToDate.BackColor = Color.Transparent;
            lblToDate.Font = UiTheme.Font(8F, FontStyle.Bold);
            lblToDate.ForeColor = UiTheme.Muted;
            lblToDate.Text = "Ke";
            lblToDate.TextAlign = ContentAlignment.MiddleLeft;
            lblToDate.Size = new Size(22, 22);

            if (dtpFromDate == null)
            {
                dtpFromDate = new Guna2DateTimePicker { Name = "dtpFromDate" };
            }

            ConfigureDatePicker(dtpFromDate);

            if (dtpToDate == null)
            {
                dtpToDate = new Guna2DateTimePicker { Name = "dtpToDate" };
            }

            ConfigureDatePicker(dtpToDate);

            if (btnClearDateFilter == null)
            {
                btnClearDateFilter = new Guna2Button { Name = "btnClearDateFilter" };
            }

            btnClearDateFilter.BorderRadius = 8;
            btnClearDateFilter.Size = new Size(64, 30);
            btnClearDateFilter.Text = "Reset";
            UiTheme.StyleSecondaryButton(btnClearDateFilter);

            dtpFromDate.ValueChanged -= DateFilter_ValueChanged;
            dtpToDate.ValueChanged -= DateFilter_ValueChanged;
            btnClearDateFilter.Click -= btnClearDateFilter_Click;
            dtpFromDate.ValueChanged += DateFilter_ValueChanged;
            dtpToDate.ValueChanged += DateFilter_ValueChanged;
            btnClearDateFilter.Click += btnClearDateFilter_Click;

            AddIfMissing(filterPanel, lblFromDate);
            AddIfMissing(filterPanel, dtpFromDate);
            AddIfMissing(filterPanel, lblToDate);
            AddIfMissing(filterPanel, dtpToDate);
            AddIfMissing(filterPanel, btnClearDateFilter);

            StyleModeButtons();
        }

        private static void ConfigureDatePicker(Guna2DateTimePicker picker)
        {
            picker.BorderColor = UiTheme.Border;
            picker.BorderRadius = 8;
            picker.BorderThickness = 1;
            picker.Checked = false;
            picker.CustomFormat = "dd/MM/yyyy";
            picker.Font = UiTheme.Font(8.4F);
            picker.Format = DateTimePickerFormat.Custom;
            picker.FillColor = UiTheme.Surface;
            picker.ForeColor = UiTheme.Text;
            picker.ShowCheckBox = true;
            picker.Size = new Size(122, 30);
        }

        private void DateFilter_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnClearDateFilter_Click(object sender, EventArgs e)
        {
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
            LoadReport();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SetMode(ReportMode.All);
        }

        private void btnShowFound_Click(object sender, EventArgs e)
        {
            SetMode(ReportMode.Found);
        }

        private void btnShowLost_Click(object sender, EventArgs e)
        {
            SetMode(ReportMode.Lost);
        }

        private Guna2Button CreateModeButton(string text, string name)
        {
            return new Guna2Button
            {
                Name = name,
                Size = new Size(100, 34),
                Text = text
            };
        }

        private void BuildStatPills()
        {
            if (panelLostMetric == null) panelLostMetric = CreateStatPill("Hilang", UiTheme.Danger);
            if (panelFoundMetric == null) panelFoundMetric = CreateStatPill("Ditemukan", UiTheme.Info);
            if (panelReturnedMetric == null) panelReturnedMetric = CreateStatPill("Kembali", UiTheme.Success);

            AddIfMissing(this, panelLostMetric);
            AddIfMissing(this, panelFoundMetric);
            AddIfMissing(this, panelReturnedMetric);
        }

        private Guna2Panel CreateStatPill(string caption, Color accent)
        {
            var panel = new Guna2Panel
            {
                BorderColor = Color.FromArgb(212, 224, 234),
                BorderRadius = 8,
                BorderThickness = 1,
                FillColor = UiTheme.SurfaceSoft,
                Size = new Size(140, 54)
            };

            var marker = new Guna2Panel
            {
                BorderRadius = 4,
                FillColor = accent,
                Location = new Point(14, 14),
                Size = new Size(8, 8)
            };

            var valueLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.DisplayFont(14F, FontStyle.Bold),
                ForeColor = UiTheme.Ink,
                Location = new Point(30, 6),
                Name = "lbl" + caption,
                Size = new Size(98, 23),
                Text = "0",
                TextAlign = ContentAlignment.MiddleLeft
            };

            var captionLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(7.8F),
                ForeColor = UiTheme.Muted,
                Location = new Point(14, 31),
                Size = new Size(114, 17),
                Text = caption,
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(marker);
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(captionLabel);

            if (caption == "Hilang") lblLost = valueLabel;
            else if (caption == "Ditemukan") lblFound = valueLabel;
            else if (caption == "Kembali") lblReturned = valueLabel;

            return panel;
        }

        private void BuildEmptyState()
        {
            if (lblEmptyState == null)
            {
                lblEmptyState = new Label { Name = "lblEmptyState" };
            }

            lblEmptyState.AutoEllipsis = true;
            lblEmptyState.BackColor = UiTheme.Surface;
            lblEmptyState.Font = UiTheme.Font(10F, FontStyle.Bold);
            lblEmptyState.ForeColor = UiTheme.Muted;
            lblEmptyState.Text = "Tidak ada data untuk filter yang dipilih.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.Visible = false;
            AddIfMissing(this, lblEmptyState);
            lblEmptyState.BringToFront();
        }

        private static void AddIfMissing(Control parent, Control child)
        {
            if (parent == null || child == null || child.Parent == parent)
            {
                return;
            }

            parent.Controls.Add(child);
        }

        private void LayoutReportControls()
        {
            int width = ClientSize.Width;
            LayoutWindowChrome();

            if (reportHeader != null)
            {
                reportHeader.Location = new Point(0, TitleBarHeight);
                reportHeader.Size = new Size(width, 82);
            }

            int headerBottom = reportHeader?.Bottom ?? 82;

            LayoutFilterBar(width, headerBottom);
            LayoutStatPills(width, filterPanel.Bottom);
            LayoutReportViewer(width);
        }

        private void LayoutFilterBar(int formWidth, int top)
        {
            if (filterPanel == null) return;

            filterPanel.Location = new Point(0, top);
            filterPanel.Size = new Size(formWidth, 48);

            btnShowAll.Location = new Point(28, 7);
            btnShowFound.Location = new Point(btnShowAll.Right + 8, 7);
            btnShowLost.Location = new Point(btnShowFound.Right + 8, 7);

            int dateSectionRight = formWidth - 28;
            btnClearDateFilter.Location = new Point(dateSectionRight - btnClearDateFilter.Width, 9);

            int dtpRight = btnClearDateFilter.Left - 12;
            dtpToDate.Location = new Point(dtpRight - dtpToDate.Width, 9);
            lblToDate.Location = new Point(dtpToDate.Left - lblToDate.Width - 4, 13);

            int dtpFromRight = lblToDate.Left - 16;
            dtpFromDate.Location = new Point(dtpFromRight - dtpFromDate.Width, 9);
            lblFromDate.Location = new Point(dtpFromDate.Left - lblFromDate.Width - 4, 13);
        }

        private void LayoutStatPills(int formWidth, int top)
        {
            if (panelLostMetric == null || panelFoundMetric == null || panelReturnedMetric == null) return;

            int pillWidth = Math.Min(140, (formWidth - 112) / 3);
            int gap = Math.Max(12, (formWidth - 56 - pillWidth * 3) / 2);

            panelLostMetric.Size = new Size(pillWidth, 54);
            panelFoundMetric.Size = new Size(pillWidth, 54);
            panelReturnedMetric.Size = new Size(pillWidth, 54);

            panelLostMetric.Location = new Point(28, top + 10);
            panelFoundMetric.Location = new Point(panelLostMetric.Right + gap, top + 10);
            panelReturnedMetric.Location = new Point(panelFoundMetric.Right + gap, top + 10);
        }

        private void LayoutReportViewer(int formWidth)
        {
            int viewTop = panelReturnedMetric?.Bottom + 8 ?? 196;
            int viewHeight = Math.Max(200, ClientSize.Height - viewTop - 8);

            reportViewer.Location = new Point(24, viewTop);
            reportViewer.Size = new Size(formWidth - 48, viewHeight);
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            if (lblEmptyState != null)
            {
                lblEmptyState.Location = reportViewer.Location;
                lblEmptyState.Size = reportViewer.Size;
                if (lblEmptyState.Visible) lblEmptyState.BringToFront();
            }
        }

        private void SetMode(ReportMode newMode)
        {
            if (mode == newMode) return;
            mode = newMode;
            StyleModeButtons();
            LoadReport();
        }

        private void StyleModeButtons()
        {
            StyleModeButton(btnShowAll, mode == ReportMode.All);
            StyleModeButton(btnShowFound, mode == ReportMode.Found);
            StyleModeButton(btnShowLost, mode == ReportMode.Lost);
        }

        private static void StyleModeButton(Guna2Button button, bool active)
        {
            if (button == null) return;
            if (active)
                UiTheme.StylePrimaryButton(button);
            else
                UiTheme.StyleSecondaryButton(button);
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (UiTheme.IsDesignMode(this)) return;
            if (initialReportLoaded) return;

            initialReportLoaded = true;
            BeginInvoke(new Action(LoadReport));
        }

        private void LoadReport()
        {
            try
            {
                LoadStats();
                if (!TryGetDateRange(out DateTime? fromDate, out DateTime? toDate))
                {
                    return;
                }

                DataTable data = GetReportData(fromDate, toDate);

                if (data.Rows.Count == 0)
                {
                    ShowEmptyState();
                    return;
                }

                HideEmptyState();

                string reportPath = Path.Combine(Application.StartupPath, "Reports", "ItemsReport.rdlc");
                if (!File.Exists(reportPath))
                {
                    throw new FileNotFoundException("File definisi laporan tidak ditemukan.", reportPath);
                }

                reportViewer.LocalReport.ReportPath = reportPath;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemsDataSet", data));
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memuat laporan: " + ex.Message);
            }
        }

        private DataTable GetReportData(DateTime? fromDate, DateTime? toDate)
        {
            switch (mode)
            {
                case ReportMode.Found:
                    return item.GetActiveFoundItems(fromDate, toDate);
                case ReportMode.Lost:
                    return item.GetActiveLostItems(fromDate, toDate);
                default:
                {
                    DataTable found = item.GetActiveFoundItems(fromDate, toDate);
                    DataTable lost = item.GetActiveLostItems(fromDate, toDate);
                    found.Merge(lost);
                    SortReportData(found);
                    return found;
                }
            }
        }

        private static void SortReportData(DataTable table)
        {
            if (table == null || table.Rows.Count == 0 || !table.Columns.Contains("DateReported"))
            {
                return;
            }

            string sort = table.Columns.Contains("ItemID")
                ? "DateReported DESC, ItemID DESC"
                : "DateReported DESC";
            DataView view = table.DefaultView;
            view.Sort = sort;
            DataTable sorted = view.ToTable();
            table.Clear();
            foreach (DataRow row in sorted.Rows)
            {
                table.ImportRow(row);
            }
        }

        private void LoadStats()
        {
            try
            {
                ItemStats stats = item.GetStats();

                if (lblLost != null) lblLost.Text = stats.LostCount.ToString();
                if (lblFound != null) lblFound.Text = stats.FoundCount.ToString();
                if (lblReturned != null) lblReturned.Text = stats.ReturnedCount.ToString();
            }
            catch
            {
                if (lblLost != null) lblLost.Text = "-";
                if (lblFound != null) lblFound.Text = "-";
                if (lblReturned != null) lblReturned.Text = "-";
            }
        }

        private bool TryGetDateRange(out DateTime? fromDate, out DateTime? toDate)
        {
            fromDate = null;
            toDate = null;

            if (dtpFromDate != null && dtpFromDate.Checked)
                fromDate = dtpFromDate.Value.Date;

            if (dtpToDate != null && dtpToDate.Checked)
                toDate = dtpToDate.Value.Date.AddDays(1);

            if (fromDate.HasValue && toDate.HasValue && fromDate.Value >= toDate.Value)
            {
                UiTheme.ShowWarning(this, "Tanggal Dari tidak boleh lewat dari tanggal Ke.");
                fromDate = null;
                toDate = null;
                return false;
            }

            return true;
        }

        private void ShowEmptyState()
        {
            reportViewer.Visible = false;
            if (lblEmptyState != null)
            {
                lblEmptyState.Text = mode == ReportMode.Found
                    ? "Belum ada data barang ditemukan."
                    : mode == ReportMode.Lost
                        ? "Belum ada data laporan hilang."
                        : "Belum ada data item untuk filter ini.";
                lblEmptyState.Visible = true;
                lblEmptyState.BringToFront();
            }
        }

        private void HideEmptyState()
        {
            reportViewer.Visible = true;
            if (lblEmptyState != null)
            {
                lblEmptyState.Visible = false;
            }
        }

        private void LayoutWindowChrome()
        {
            if (btnWindowMinimize == null || btnWindowMaximize == null || btnWindowClose == null)
            {
                return;
            }

            btnWindowMinimize.Location = new Point(ClientSize.Width - 126, 4);
            btnWindowMaximize.Location = new Point(ClientSize.Width - 84, 4);
            btnWindowClose.Location = new Point(ClientSize.Width - 42, 4);
            if (panelWindowDivider != null)
            {
                panelWindowDivider.Size = new Size(ClientSize.Width, 1);
            }
        }

        private void WindowChrome_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void btnWindowMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnWindowMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
            UpdateMaximizeButtonText();
            LayoutReportControls();
        }

        private void btnWindowClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateMaximizeButtonText()
        {
            if (btnWindowMaximize == null)
            {
                return;
            }

            btnWindowMaximize.Text = WindowState == FormWindowState.Maximized ? "\u2750" : "\u25A1";
        }
    }
}
