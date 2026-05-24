using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    public partial class AdminForm : Form
    {
        private enum AdminGridMode
        {
            FoundItems,
            LostItems,
            Claims
        }

        private readonly IItem item;
        private readonly IClaim claim;
        private readonly IPhotoStorageService photoStorage;
        private Guna2PictureBox picItemImage;
        private Label lblImageStatus;
        private Label lblLostMetric;
        private Label lblFoundMetric;
        private Label lblReturnedMetric;
        private Label lblHeaderActiveMetric;
        private Label lblHeaderLostMetric;
        private Label lblHeaderReturnedMetric;
        private string selectedImagePath;
        private string selectedImageTitle;
        private TableLayoutPanel dashboardLayout;
        private Label lblClaimsEmptyState;
        private Guna2Button btnShowLostItems;
        private AdminGridMode gridMode = AdminGridMode.FoundItems;

        public AdminForm()
            : this(new Item(), new Claim(), PhotoStorageService.CreateDefault())
        {
        }

        public AdminForm(IItem item, IClaim claim)
            : this(item, claim, PhotoStorageService.CreateDefault())
        {
        }

        public AdminForm(IItem item, IClaim claim, IPhotoStorageService photoStorage)
        {
            this.item = item ?? throw new ArgumentNullException(nameof(item));
            this.claim = claim ?? throw new ArgumentNullException(nameof(claim));
            this.photoStorage = photoStorage ?? throw new ArgumentNullException(nameof(photoStorage));

            InitializeComponent();

            ConfigureHeader();
            ConfigureReportButton();
            ConfigureDashboard();
            ConfigureImagePreview();

            if (UiTheme.IsDesignMode(this))
            {
                return;
            }

            LoadItems();
            LoadStats();
        }

        private void ConfigureHeader()
        {
            UiTheme.StyleForm(this, new Size(1180, 720), true);
            UiTheme.SetDoubleBuffered(this);
            Text = "Dashboard Admin - Lost and Found";
            Guna2HtmlLabel lblSubtitle = EnsureHeaderSubtitle();

            lblTitle.Text = "Dashboard Admin";
            lblSubtitle.Text = string.Empty;
            UiTheme.StyleTitle(lblTitle, 20F);
            UiTheme.StyleSubtitle(lblSubtitle);
            lblTitle.Location = new Point(32, 24);
            lblSubtitle.Location = new Point(34, 61);
            lblSubtitle.AutoSize = false;
            lblSubtitle.Size = new Size(292, 20);
            lblSubtitle.Visible = false;
            lblTitle.ForeColor = UiTheme.Ink;
            lblSubtitle.ForeColor = UiTheme.Muted;

            btnLogout.Text = "Keluar";
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UiTheme.StyleSecondaryButton(btnLogout);
            btnLogout.Location = new Point(ClientSize.Width - 116, 30);
            AddUserBadge(new Point(ClientSize.Width - 468, 30), new Size(232, 36));

            if (lblHeaderActiveMetric == null)
            {
                lblHeaderActiveMetric = AddHeaderMetric("Aktif", "0", UiTheme.Primary, new Point(382, 26));
            }

            if (lblHeaderLostMetric == null)
            {
                lblHeaderLostMetric = AddHeaderMetric("Hilang", "0", UiTheme.Danger, new Point(510, 26));
            }

            if (lblHeaderReturnedMetric == null)
            {
                lblHeaderReturnedMetric = AddHeaderMetric("Kembali", "0", UiTheme.Success, new Point(638, 26));
            }

            HideHeaderMetricCards();
        }

        private Guna2HtmlLabel EnsureHeaderSubtitle()
        {
            Guna2HtmlLabel subtitle = Controls["lblSubtitle"] as Guna2HtmlLabel;

            if (subtitle != null)
            {
                return subtitle;
            }

            subtitle = new Guna2HtmlLabel
            {
                Name = "lblSubtitle",
                TabIndex = 1
            };

            Controls.Add(subtitle);
            subtitle.BringToFront();
            return subtitle;
        }

        private void ConfigureReportButton()
        {
            Guna2Button btnReport = Controls["btnReport"] as Guna2Button;

            if (btnReport == null)
            {
                btnReport = new Guna2Button
                {
                    Name = "btnReport",
                    TabIndex = 6
                };

                Controls.Add(btnReport);
            }

            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.Cursor = Cursors.Hand;
            btnReport.Location = new Point(ClientSize.Width - 224, 30);
            btnReport.Size = new Size(100, 36);
            btnReport.Text = "Laporan";

            UiTheme.StyleSecondaryButton(btnReport);
            btnReport.Click -= btnReport_Click;
            btnReport.Click += btnReport_Click;
            btnReport.BringToFront();
        }

        private void AddUserBadge(Point location, Size size)
        {
            Control existingBadge = Controls["panelUserBadge"];
            if (existingBadge != null)
            {
                existingBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                existingBadge.Location = location;
                existingBadge.Size = size;

                Control[] labels = existingBadge.Controls.Find("lblUserBadge", true);
                if (labels.Length > 0)
                {
                    labels[0].Text = GetHeaderIdentity();
                }

                existingBadge.BringToFront();
                return;
            }

            Guna2Panel badge = new Guna2Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BorderColor = UiTheme.Border,
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = UiTheme.Surface,
                Location = location,
                Name = "panelUserBadge",
                Size = size
            };

            Guna2Panel marker = new Guna2Panel
            {
                BorderRadius = 5,
                FillColor = UiTheme.Success,
                Location = new Point(13, 13),
                Size = new Size(10, 10)
            };

            Label label = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = UiTheme.Font(8.8F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Padding = new Padding(32, 0, 12, 0),
                Text = GetHeaderIdentity(),
                TextAlign = ContentAlignment.MiddleLeft
            };

            badge.Controls.Add(label);
            badge.Controls.Add(marker);
            Controls.Add(badge);
            badge.BringToFront();
        }

        private Label AddHeaderMetric(string caption, string value, Color accent, Point location)
        {
            var panel = new Guna2Panel
            {
                BackColor = UiTheme.Canvas,
                BorderColor = UiTheme.Border,
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = UiTheme.Surface,
                Location = location,
                Size = new Size(112, 52)
            };

            var marker = new Guna2Panel
            {
                BorderRadius = 4,
                FillColor = accent,
                Location = new Point(12, 12),
                Size = new Size(8, 8)
            };

            var valueLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(12.5F, FontStyle.Bold),
                ForeColor = UiTheme.Ink,
                Location = new Point(27, 6),
                Size = new Size(68, 22),
                Text = value,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var captionLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(7.8F),
                ForeColor = UiTheme.Muted,
                Location = new Point(12, 30),
                Size = new Size(86, 16),
                Text = caption,
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(marker);
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(captionLabel);
            Controls.Add(panel);
            panel.BringToFront();
            return valueLabel;
        }

        private void StyleHeaderMetricCards()
        {
            StyleHeaderMetricCard(panelHeaderActive, lblHeaderActiveMetric, lblHeaderActiveCaption, panelHeaderActiveMarker, 348);
            StyleHeaderMetricCard(panelHeaderLost, lblHeaderLostMetric, lblHeaderLostCaption, panelHeaderLostMarker, 466);
            StyleHeaderMetricCard(panelHeaderReturned, lblHeaderReturnedMetric, lblHeaderReturnedCaption, panelHeaderReturnedMarker, 584);
        }

        private void HideHeaderMetricCards()
        {
            if (panelHeaderActive != null)
            {
                panelHeaderActive.Visible = false;
            }

            if (panelHeaderLost != null)
            {
                panelHeaderLost.Visible = false;
            }

            if (panelHeaderReturned != null)
            {
                panelHeaderReturned.Visible = false;
            }
        }

        private void StyleHeaderMetricCard(Guna2Panel panel, Label metric, Label caption, Guna2Panel marker, int x)
        {
            if (panel == null || metric == null || caption == null || marker == null)
            {
                return;
            }

            panel.BorderColor = UiTheme.Border;
            panel.BorderRadius = 12;
            panel.BorderThickness = 1;
            panel.FillColor = UiTheme.Surface;
            panel.Location = new Point(x, 24);
            panel.Size = new Size(106, 56);
            marker.Location = new Point(13, 14);
            marker.Size = new Size(9, 9);
            metric.Font = UiTheme.DisplayFont(14.5F, FontStyle.Bold);
            metric.ForeColor = UiTheme.Ink;
            metric.Location = new Point(30, 7);
            metric.Size = new Size(68, 25);
            caption.Font = UiTheme.Font(8F);
            caption.ForeColor = UiTheme.Muted;
            caption.Location = new Point(13, 34);
            caption.Size = new Size(82, 17);
            panel.BringToFront();
        }

        private string GetHeaderIdentity()
        {
            string role = string.IsNullOrWhiteSpace(UserSession.Role) ? DomainValues.Roles.Admin : UserSession.Role;
            string username = string.IsNullOrWhiteSpace(UserSession.Username) ? "User" : UserSession.Username;
            return role + " / " + username;
        }

        private void ConfigureDashboard()
        {
            panelItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelClaim.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelItems.Location = new Point(24, 116);
            panelItems.Size = new Size(704, 392);
            panelChart.Location = new Point(752, 116);
            panelChart.Size = new Size(464, 392);
            panelClaim.Location = new Point(24, 532);
            panelClaim.Size = new Size(1192, 158);

            UiTheme.StyleCard(panelItems);
            UiTheme.StyleCard(panelChart);
            UiTheme.StyleCard(panelClaim);
            ConfigureDashboardLayout();

            lblItemsTitle.Text = "Barang Ditemukan";
            lblItemsSubtitle.Text = "Item temuan yang dilaporkan security";
            lblChartTitle.Text = "Status Item";
            lblChartSubtitle.Text = "Distribusi hilang, ditemukan, kembali";
            lblClaimTitle.Text = "Foto Item";
            lblClaimSubtitle.Text = "Pilih barang untuk melihat foto laporan";
            lblClaimant.Text = "Barang";
            btnApproveClaim.Text = "Setujui Request";

            UiTheme.StyleTitle(lblItemsTitle, 14F);
            UiTheme.StyleSubtitle(lblItemsSubtitle);
            UiTheme.StyleTitle(lblChartTitle, 14F);
            UiTheme.StyleSubtitle(lblChartSubtitle);
            UiTheme.StyleTitle(lblClaimTitle, 14F);
            UiTheme.StyleSubtitle(lblClaimSubtitle);
            UiTheme.StyleFieldLabel(lblClaimant);
            UiTheme.StyleTextBox(txtClaimantName);
            UiTheme.StylePrimaryButton(btnApproveClaim);
            HideDashboardPanelHeaders();
            txtClaimantName.PlaceholderText = "Pilih barang ditemukan";
            txtClaimantName.ReadOnly = true;
            txtClaimantName.Cursor = Cursors.Default;
            btnApproveClaim.Visible = false;

            ConfigureViewButtons();
            ConfigureItemGrid();
            ConfigureStatsChart();
            EnsureClaimsEmptyState();
            ApplyGridModeText();
            LayoutDashboardPanels();
            Resize += (sender, e) => LayoutDashboardPanels();
            panelItems.Resize += (sender, e) => LayoutItemsPanel();
            panelChart.Resize += (sender, e) => LayoutChartPanel();
            panelClaim.Resize += (sender, e) => LayoutClaimPhotoPanel();
        }

        private void ConfigureDashboardLayout()
        {
            if (dashboardLayout == null)
            {
                dashboardLayout = new TableLayoutPanel
                {
                    BackColor = Color.Transparent,
                    ColumnCount = 2,
                    RowCount = 2,
                    Name = "adminDashboardLayout",
                    Padding = new Padding(0)
                };
                dashboardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
                dashboardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
                dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                dashboardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
                Controls.Add(dashboardLayout);
            }

            dashboardLayout.Controls.Clear();
            dashboardLayout.Controls.Add(panelItems, 0, 0);
            dashboardLayout.Controls.Add(panelChart, 1, 0);
            dashboardLayout.Controls.Add(panelClaim, 0, 1);
            dashboardLayout.SetColumnSpan(panelClaim, 2);

            panelItems.Dock = DockStyle.Fill;
            panelChart.Dock = DockStyle.Fill;
            panelClaim.Dock = DockStyle.Fill;
            panelItems.Margin = new Padding(0, 0, 10, 10);
            panelChart.Margin = new Padding(10, 0, 0, 10);
            panelClaim.Margin = new Padding(0);
        }

        private void LayoutDashboardPanels()
        {
            if (dashboardLayout == null)
            {
                return;
            }

            dashboardLayout.Location = new Point(24, 104);
            dashboardLayout.Size = new Size(Math.Max(1, ClientSize.Width - 48), Math.Max(1, ClientSize.Height - 128));
            dashboardLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LayoutItemsPanel();
            LayoutChartPanel();
            LayoutClaimPhotoPanel();
            LayoutViewButtons();
        }

        private void HideDashboardPanelHeaders()
        {
            SetControlHidden(lblItemsTitle);
            SetControlHidden(lblItemsSubtitle);
            SetControlHidden(lblChartTitle);
            SetControlHidden(lblChartSubtitle);
            SetControlHidden(lblClaimTitle);
            SetControlHidden(lblClaimSubtitle);
        }

        private void SetControlHidden(Control control)
        {
            if (control != null)
            {
                control.Text = string.Empty;
                control.Size = new Size(1, 1);
                control.Visible = false;
            }
        }

        private void HideChildControl(Control parent, string controlName)
        {
            if (parent == null || string.IsNullOrWhiteSpace(controlName))
            {
                return;
            }

            foreach (Control control in parent.Controls.Find(controlName, true))
            {
                SetControlHidden(control);
            }
        }

        private void ConfigureImagePreview()
        {
            txtClaimantName.Size = new Size(760, 42);
            txtClaimantName.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            if (picItemImage == null)
            {
                picItemImage = new Guna2PictureBox();
            }

            picItemImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picItemImage.BackColor = Color.Transparent;
            picItemImage.BorderRadius = 8;
            picItemImage.Cursor = Cursors.Default;
            picItemImage.FillColor = UiTheme.SurfaceSoft;
            picItemImage.Location = new Point(940, 26);
            picItemImage.Size = new Size(96, 96);
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom;

            if (lblImageStatus == null)
            {
                lblImageStatus = new Label();
            }

            lblImageStatus.AutoEllipsis = true;
            lblImageStatus.BackColor = Color.Transparent;
            lblImageStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblImageStatus.Location = new Point(1050, 38);
            lblImageStatus.Size = new Size(120, 70);
            lblImageStatus.Text = "Pilih barang\r\nuntuk melihat foto";
            UiTheme.StyleMutedLabel(lblImageStatus);

            if (picItemImage.Parent == null)
            {
                panelClaim.Controls.Add(picItemImage);
            }

            if (lblImageStatus.Parent == null)
            {
                panelClaim.Controls.Add(lblImageStatus);
            }

            dgvItems.SelectionChanged -= dgvItems_SelectionChanged;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
            picItemImage.Click -= picItemImage_Click;
            picItemImage.Click += picItemImage_Click;
            LayoutClaimPhotoPanel();
        }

        private void ConfigureItemGrid()
        {
            UiTheme.StyleGrid(dgvItems);
            UiTheme.AttachStatusBadgeRenderer(dgvItems, "Status", "ClaimStatus");
            dgvItems.AutoGenerateColumns = true;
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.RowTemplate.Height = 40;
            LayoutItemsPanel();
        }

        private void ConfigureViewButtons()
        {
            if (btnShowFoundItems == null)
            {
                btnShowFoundItems = new Guna2Button
                {
                    Name = "btnShowFoundItems",
                    Text = "Barang"
                };
                panelItems.Controls.Add(btnShowFoundItems);
            }

            if (btnShowClaims == null)
            {
                btnShowClaims = new Guna2Button
                {
                    Name = "btnShowClaims",
                    Text = "Histori"
                };
                panelItems.Controls.Add(btnShowClaims);
            }

            if (btnShowLostItems == null)
            {
                btnShowLostItems = new Guna2Button
                {
                    Name = "btnShowLostItems",
                    Text = "Hilang"
                };
                panelItems.Controls.Add(btnShowLostItems);
            }

            if (panelDateFilter == null)
            {
                panelDateFilter = new Guna2Panel
                {
                    BackColor = Color.Transparent,
                    BorderColor = UiTheme.Border,
                    BorderRadius = 10,
                    BorderThickness = 1,
                    FillColor = Color.FromArgb(248, 252, 252),
                    Name = "panelDateFilter"
                };
                panelItems.Controls.Add(panelDateFilter);
            }

            if (lblFromDate == null)
            {
                lblFromDate = CreateDateFilterLabel("From");
                panelDateFilter.Controls.Add(lblFromDate);
            }

            if (dtpFromDate == null)
            {
                dtpFromDate = CreateDateFilterPicker();
                dtpFromDate.Name = "dtpFromDate";
                dtpFromDate.ValueChanged += DateFilter_ValueChanged;
                panelDateFilter.Controls.Add(dtpFromDate);
            }

            if (lblToDate == null)
            {
                lblToDate = CreateDateFilterLabel("To");
                panelDateFilter.Controls.Add(lblToDate);
            }

            if (dtpToDate == null)
            {
                dtpToDate = CreateDateFilterPicker();
                dtpToDate.Name = "dtpToDate";
                dtpToDate.ValueChanged += DateFilter_ValueChanged;
                panelDateFilter.Controls.Add(dtpToDate);
            }

            if (btnClearDateFilter == null)
            {
                btnClearDateFilter = new Guna2Button
                {
                    BorderRadius = 8,
                    Name = "btnClearDateFilter",
                    Text = "Reset"
                };
                btnClearDateFilter.Click += btnClearDateFilter_Click;
                panelDateFilter.Controls.Add(btnClearDateFilter);
            }

            btnShowFoundItems.Size = new Size(104, 34);
            btnShowLostItems.Size = new Size(96, 34);
            btnShowClaims.Size = new Size(96, 34);
            btnClearDateFilter.Size = new Size(64, 30);
            UiTheme.StyleSecondaryButton(btnClearDateFilter);
            dtpFromDate.ValueChanged -= DateFilter_ValueChanged;
            dtpFromDate.ValueChanged += DateFilter_ValueChanged;
            dtpToDate.ValueChanged -= DateFilter_ValueChanged;
            dtpToDate.ValueChanged += DateFilter_ValueChanged;
            btnShowFoundItems.Click -= btnShowFoundItems_Click;
            btnShowFoundItems.Click += btnShowFoundItems_Click;
            btnShowLostItems.Click -= btnShowLostItems_Click;
            btnShowLostItems.Click += btnShowLostItems_Click;
            btnShowClaims.Click -= btnShowClaims_Click;
            btnShowClaims.Click += btnShowClaims_Click;
            btnClearDateFilter.Click -= btnClearDateFilter_Click;
            btnClearDateFilter.Click += btnClearDateFilter_Click;
            LayoutViewButtons();
            StyleViewButtons();
        }

        private Label CreateDateFilterLabel(string text)
        {
            return new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(8F, FontStyle.Bold),
                ForeColor = UiTheme.Muted,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private Guna2DateTimePicker CreateDateFilterPicker()
        {
            return new Guna2DateTimePicker
            {
                BorderColor = UiTheme.Border,
                BorderRadius = 8,
                BorderThickness = 1,
                Checked = false,
                CustomFormat = "dd/MM/yyyy",
                Font = UiTheme.Font(8.4F),
                Format = DateTimePickerFormat.Custom,
                FillColor = UiTheme.Surface,
                ForeColor = UiTheme.Text,
                ShowCheckBox = true,
                Size = new Size(132, 30)
            };
        }

        private void LayoutViewButtons()
        {
            if (btnShowFoundItems == null || btnShowLostItems == null || btnShowClaims == null || panelItems == null)
            {
                return;
            }

            int right = Math.Max(560, panelItems.ClientSize.Width - 28);
            btnShowClaims.Location = new Point(right - btnShowClaims.Width, 20);
            btnShowLostItems.Location = new Point(btnShowClaims.Left - btnShowLostItems.Width - 10, 20);
            btnShowFoundItems.Location = new Point(btnShowLostItems.Left - btnShowFoundItems.Width - 10, 20);
            btnShowFoundItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowLostItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            if (panelDateFilter != null && dtpToDate != null && lblToDate != null && dtpFromDate != null && lblFromDate != null && btnClearDateFilter != null)
            {
                int filterWidth = 438;
                int filterX = Math.Max(28, btnShowFoundItems.Left - filterWidth - 14);
                panelDateFilter.Location = new Point(filterX, 14);
                panelDateFilter.Size = new Size(Math.Min(filterWidth, btnShowFoundItems.Left - filterX - 14), 44);
                panelDateFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                lblFromDate.Location = new Point(14, 11);
                lblFromDate.Size = new Size(40, 22);
                dtpFromDate.Location = new Point(56, 7);
                dtpFromDate.Size = new Size(132, 30);
                lblToDate.Location = new Point(200, 11);
                lblToDate.Size = new Size(22, 22);
                dtpToDate.Location = new Point(224, 7);
                dtpToDate.Size = new Size(132, 30);
                btnClearDateFilter.Location = new Point(panelDateFilter.Width - btnClearDateFilter.Width - 8, 7);

                panelDateFilter.BringToFront();
            }

            btnShowFoundItems.BringToFront();
            btnShowLostItems.BringToFront();
            btnShowClaims.BringToFront();
        }

        private void LayoutItemsPanel()
        {
            if (panelItems == null || dgvItems == null)
            {
                return;
            }

            dgvItems.Location = new Point(28, 76);
            dgvItems.Size = new Size(Math.Max(1, panelItems.ClientSize.Width - 56), Math.Max(110, panelItems.ClientSize.Height - 100));

            if (lblClaimsEmptyState != null)
            {
                lblClaimsEmptyState.Location = dgvItems.Location;
                lblClaimsEmptyState.Size = dgvItems.Size;
                if (lblClaimsEmptyState.Visible)
                {
                    lblClaimsEmptyState.BringToFront();
                }
            }
        }

        private void StyleViewButtons()
        {
            StyleViewButton(btnShowFoundItems, gridMode == AdminGridMode.FoundItems);
            StyleViewButton(btnShowLostItems, gridMode == AdminGridMode.LostItems);
            StyleViewButton(btnShowClaims, gridMode == AdminGridMode.Claims);
        }

        private void StyleViewButton(Guna2Button button, bool active)
        {
            if (button == null)
            {
                return;
            }

            if (active)
            {
                UiTheme.StylePrimaryButton(button);
            }
            else
            {
                UiTheme.StyleSecondaryButton(button);
            }
        }

        private void DateFilter_ValueChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btnShowFoundItems_Click(object sender, EventArgs e)
        {
            SetGridMode(AdminGridMode.FoundItems);
        }

        private void btnShowLostItems_Click(object sender, EventArgs e)
        {
            SetGridMode(AdminGridMode.LostItems);
        }

        private void btnShowClaims_Click(object sender, EventArgs e)
        {
            SetGridMode(AdminGridMode.Claims);
        }

        private void btnClearDateFilter_Click(object sender, EventArgs e)
        {
            if (dtpFromDate != null)
            {
                dtpFromDate.Checked = false;
            }

            if (dtpToDate != null)
            {
                dtpToDate.Checked = false;
            }

            LoadItems();
        }

        private void ConfigureStatsChart()
        {
            chartStats.BackColor = UiTheme.Surface;
            chartStats.Legend.Display = true;
            chartStats.Legend.Position = LegendPosition.Bottom;
            chartStats.Legend.LabelFont = new ChartFont(UiTheme.FontFamilyName, 10);
            chartStats.Legend.LabelForeColor = UiTheme.Text;
            chartStats.Legend.BoxWidth = 10;
            chartStats.Title.Display = false;
            chartStats.XAxes.Display = false;
            chartStats.YAxes.Display = false;
            chartStats.XAxes.GridLines.Display = false;
            chartStats.YAxes.GridLines.Display = false;
            chartStats.Location = new Point(36, 82);
            chartStats.Size = new Size(392, 190);

            if (lblLostMetric == null)
            {
                lblLostMetric = AddMetricPill("Hilang", UiTheme.Danger, new Point(28, 300));
            }

            if (lblFoundMetric == null)
            {
                lblFoundMetric = AddMetricPill("Ditemukan", UiTheme.Info, new Point(170, 300));
            }

            if (lblReturnedMetric == null)
            {
                lblReturnedMetric = AddMetricPill("Kembali", UiTheme.Success, new Point(312, 300));
            }

            LayoutChartPanel();
        }

        private void EnsureClaimsEmptyState()
        {
            if (lblClaimsEmptyState == null)
            {
                lblClaimsEmptyState = new Label
                {
                    AutoEllipsis = true,
                    BackColor = UiTheme.Surface,
                    Font = UiTheme.Font(10F, FontStyle.Bold),
                    ForeColor = UiTheme.Muted,
                    Name = "lblClaimsEmptyState",
                    Text = "Belum ada data klaim.",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = false
                };
                panelItems.Controls.Add(lblClaimsEmptyState);
            }
        }

        private void LayoutChartPanel()
        {
            if (panelChart == null || chartStats == null)
            {
                return;
            }

            int panelWidth = Math.Max(1, panelChart.ClientSize.Width);
            int panelHeight = Math.Max(1, panelChart.ClientSize.Height);
            int chartWidth = Math.Max(220, panelWidth - 56);
            int chartHeight = Math.Max(180, panelHeight - 146);

            chartStats.Location = new Point(28, 20);
            chartStats.Size = new Size(chartWidth, chartHeight);

            int metricY = Math.Max(chartStats.Bottom + 12, panelHeight - 68);
            int metricWidth = Math.Max(74, Math.Min(112, (panelWidth - 72) / 3));
            int gap = Math.Max(8, (panelWidth - 56 - metricWidth * 3) / 2);
            LayoutMetricPanel(panelLostMetric, 28, metricY, metricWidth);
            LayoutMetricPanel(panelFoundMetric, 28 + metricWidth + gap, metricY, metricWidth);
            LayoutMetricPanel(panelReturnedMetric, 28 + (metricWidth + gap) * 2, metricY, metricWidth);
        }

        private void LayoutMetricPanel(Guna2Panel panel, int x, int y, int width)
        {
            if (panel == null)
            {
                return;
            }

            panel.Location = new Point(x, y);
            panel.Size = new Size(width, 54);
        }

        private void LayoutClaimPhotoPanel()
        {
            if (panelClaim == null || txtClaimantName == null || picItemImage == null || lblImageStatus == null)
            {
                return;
            }

            int width = Math.Max(1, panelClaim.ClientSize.Width);
            int photoSize = 104;
            int photoX = width - photoSize - 142;
            int buttonWidth = 142;
            int actionX = photoX - buttonWidth - 18;
            int inputRight = btnApproveClaim.Visible ? actionX - 14 : photoX - 28;

            lblClaimant.Location = new Point(28, 48);
            txtClaimantName.Location = new Point(134, 40);
            txtClaimantName.Size = new Size(Math.Max(260, inputRight - 134), 42);
            btnApproveClaim.Location = new Point(actionX, 40);
            btnApproveClaim.Size = new Size(buttonWidth, 42);
            picItemImage.Location = new Point(photoX, 20);
            picItemImage.Size = new Size(photoSize, 100);
            lblImageStatus.Location = new Point(picItemImage.Right + 16, 32);
            lblImageStatus.Size = new Size(Math.Max(96, width - lblImageStatus.Left - 24), 72);
        }

        private Label AddMetricPill(string caption, Color accent, Point location)
        {
            var panel = new Guna2Panel
            {
                BorderColor = Color.FromArgb(212, 224, 234),
                BorderRadius = 8,
                BorderThickness = 1,
                FillColor = UiTheme.SurfaceSoft,
                Location = location,
                Size = new Size(118, 54)
            };

            var marker = new Guna2Panel
            {
                BorderRadius = 4,
                FillColor = accent,
                Location = new Point(13, 13),
                Size = new Size(8, 8)
            };

            var valueLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.DisplayFont(14F, FontStyle.Bold),
                ForeColor = UiTheme.Ink,
                Location = new Point(28, 6),
                Size = new Size(76, 23),
                Text = "0",
                TextAlign = ContentAlignment.MiddleLeft
            };

            var captionLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(7.8F),
                ForeColor = UiTheme.Muted,
                Location = new Point(13, 31),
                Size = new Size(92, 17),
                Text = caption,
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(marker);
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(captionLabel);
            panelChart.Controls.Add(panel);
            panel.BringToFront();

            return valueLabel;
        }

        private void LoadItems()
        {
            try
            {
                if (!TryGetDateRange(out DateTime? fromDate, out DateTime? toDate))
                {
                    return;
                }

                if (gridMode == AdminGridMode.Claims)
                {
                    DataTable claims = claim.GetAllClaims(fromDate, toDate);
                    dgvItems.DataSource = claims;
                    ApplyGridColumnMetadata(claims);
                    UpdateClaimsEmptyState(claims.Rows.Count == 0);
                }
                else if (gridMode == AdminGridMode.LostItems)
                {
                    DataTable lostItems = item.GetActiveLostItems(fromDate, toDate);
                    dgvItems.DataSource = lostItems;
                    ApplyGridColumnMetadata(lostItems);
                    UpdateClaimsEmptyState(lostItems.Rows.Count == 0);
                }
                else
                {
                    DataTable foundItems = item.GetActiveFoundItems(fromDate, toDate);
                    dgvItems.DataSource = foundItems;
                    ApplyGridColumnMetadata(foundItems);
                    UpdateClaimsEmptyState(foundItems.Rows.Count == 0);
                }

                LoadSelectedGridDetails();
                LoadSelectedItemImage();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memuat data admin: " + ex.Message);
            }
        }

        private bool TryGetDateRange(out DateTime? fromDate, out DateTime? toDate)
        {
            fromDate = null;
            toDate = null;

            if (dtpFromDate != null && dtpFromDate.Checked)
            {
                fromDate = dtpFromDate.Value.Date;
            }

            if (dtpToDate != null && dtpToDate.Checked)
            {
                toDate = dtpToDate.Value.Date.AddDays(1);
            }

            if (fromDate.HasValue && toDate.HasValue && fromDate.Value >= toDate.Value)
            {
                UiTheme.ShowWarning(this, "Tanggal From tidak boleh lewat dari tanggal To.");
                return false;
            }

            return true;
        }

        private void ApplyGridColumnMetadata(DataTable table)
        {
            if (table == null || dgvItems.Columns.Count == 0)
            {
                return;
            }

            foreach (DataGridViewColumn gridColumn in dgvItems.Columns)
            {
                DataColumn dataColumn = GetBoundDataColumn(table, gridColumn);

                if (dataColumn == null)
                {
                    continue;
                }

                gridColumn.HeaderText = dataColumn.Caption;

                string format;
                if (DataTableColumnMetadata.TryGetFormat(dataColumn, out format))
                {
                    gridColumn.DefaultCellStyle.Format = format;
                }

                bool visible;
                if (DataTableColumnMetadata.TryGetVisible(dataColumn, out visible))
                {
                    gridColumn.Visible = visible;
                }

                float fillWeight;
                if (DataTableColumnMetadata.TryGetFillWeight(dataColumn, out fillWeight))
                {
                    gridColumn.FillWeight = fillWeight;
                }
            }
        }

        private static DataColumn GetBoundDataColumn(DataTable table, DataGridViewColumn gridColumn)
        {
            string columnName = string.IsNullOrWhiteSpace(gridColumn.DataPropertyName)
                ? gridColumn.Name
                : gridColumn.DataPropertyName;

            if (string.IsNullOrWhiteSpace(columnName) || !table.Columns.Contains(columnName))
            {
                return null;
            }

            return table.Columns[columnName];
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedGridDetails();
            LoadSelectedItemImage();
        }

        private void LoadSelectedGridDetails()
        {
            if (gridMode == AdminGridMode.Claims)
            {
                LoadSelectedClaimDetails();
            }
            else if (gridMode == AdminGridMode.LostItems)
            {
                LoadSelectedLostItemDetails();
            }
            else
            {
                LoadSelectedFoundItemDetails();
            }
        }

        private void LoadSelectedFoundItemDetails()
        {
            if (txtClaimantName == null)
            {
                return;
            }

            if (dgvItems.SelectedRows.Count == 0)
            {
                txtClaimantName.Clear();
                txtClaimantName.PlaceholderText = "Pilih barang ditemukan";
                btnApproveClaim.Visible = false;
                LayoutClaimPhotoPanel();
                return;
            }

            string itemName = GetSelectedCellText("ItemName");
            string location = GetSelectedCellText("Location");
            txtClaimantName.Text = string.IsNullOrWhiteSpace(location)
                ? itemName
                : itemName + " - " + location;
            btnApproveClaim.Visible = false;
            LayoutClaimPhotoPanel();
        }

        private void LoadSelectedLostItemDetails()
        {
            if (txtClaimantName == null)
            {
                return;
            }

            if (dgvItems.SelectedRows.Count == 0)
            {
                txtClaimantName.Clear();
                txtClaimantName.PlaceholderText = "Pilih laporan hilang";
                btnApproveClaim.Visible = false;
                LayoutClaimPhotoPanel();
                return;
            }

            string itemName = GetSelectedCellText("ItemName");
            string location = GetSelectedCellText("Location");
            txtClaimantName.Text = string.IsNullOrWhiteSpace(location)
                ? itemName
                : itemName + " - " + location;
            btnApproveClaim.Text = "Tandai Selesai";
            btnApproveClaim.Visible = true;
            LayoutClaimPhotoPanel();
        }

        private void LoadSelectedClaimDetails()
        {
            if (txtClaimantName == null)
            {
                return;
            }

            if (dgvItems.SelectedRows.Count == 0)
            {
                txtClaimantName.Clear();
                txtClaimantName.PlaceholderText = "Pilih data klaim";
                btnApproveClaim.Visible = false;
                LayoutClaimPhotoPanel();
                return;
            }

            string nim = GetSelectedCellText("StudentNIM");
            string name = GetSelectedCellText("StudentName");
            txtClaimantName.Text = string.IsNullOrWhiteSpace(nim) ? name : nim + " - " + name;
            btnApproveClaim.Visible = false;
            LayoutClaimPhotoPanel();
        }

        private void LoadSelectedItemImage()
        {
            string imageColumn = gridMode == AdminGridMode.Claims ? "ClaimPhotoPath" : "ImagePath";
            string emptySelectionText = GetEmptyImageSelectionText();

            if (picItemImage == null || dgvItems.SelectedRows.Count == 0 || !dgvItems.Columns.Contains(imageColumn))
            {
                ClearSelectedItemImage(emptySelectionText);
                return;
            }

            string storedImagePath = Convert.ToString(dgvItems.SelectedRows[0].Cells[imageColumn].Value);
            selectedImagePath = null;
            selectedImageTitle = GetSelectedImageTitle();

            if (string.IsNullOrWhiteSpace(storedImagePath))
            {
                ClearSelectedItemImage(gridMode == AdminGridMode.Claims ? "Belum ada foto klaim" : "Belum ada foto item");
                return;
            }

            string imagePath = photoStorage.ResolvePath(storedImagePath);
            if (!File.Exists(imagePath))
            {
                ClearSelectedItemImage(gridMode == AdminGridMode.Claims ? "File foto klaim tidak ditemukan" : "File foto item tidak ditemukan");
                return;
            }

            try
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    Image oldImage = picItemImage.Image;
                    picItemImage.Image = new Bitmap(image);
                    oldImage?.Dispose();
                }

                selectedImagePath = imagePath;
                picItemImage.Cursor = Cursors.Hand;
                picItemImage.FillColor = UiTheme.SurfaceSoft;
                lblImageStatus.Text = "Foto tersedia\r\nKlik untuk zoom";
                lblImageStatus.ForeColor = UiTheme.Success;
            }
            catch
            {
                ClearSelectedItemImage("Foto tidak dapat dimuat");
            }
        }

        private string GetEmptyImageSelectionText()
        {
            if (gridMode == AdminGridMode.Claims)
            {
                return "Pilih klaim untuk melihat foto";
            }

            if (gridMode == AdminGridMode.LostItems)
            {
                return "Pilih laporan hilang untuk melihat foto";
            }

            return "Pilih barang untuk melihat foto";
        }

        private string GetSelectedImageTitle()
        {
            if (gridMode == AdminGridMode.Claims)
            {
                return "Klaim " + GetSelectedCellText("ClaimID") + " - " + GetSelectedCellText("StudentName");
            }

            if (gridMode == AdminGridMode.LostItems)
            {
                return "Laporan Hilang " + GetSelectedCellText("ItemID") + " - " + GetSelectedCellText("ItemName");
            }

            return "Item " + GetSelectedCellText("ItemID") + " - " + GetSelectedCellText("ItemName");
        }

        private void picItemImage_Click(object sender, EventArgs e)
        {
            if (picItemImage == null || picItemImage.Image == null)
            {
                UiTheme.ShowWarning(this, "Foto belum tersedia untuk di-zoom.");
                return;
            }

            using (var zoomForm = new ImageZoomForm(picItemImage.Image, selectedImageTitle))
            {
                zoomForm.ShowDialog(this);
            }
        }

        private void ClearSelectedItemImage(string status)
        {
            selectedImagePath = null;
            selectedImageTitle = null;

            if (picItemImage != null)
            {
                Image oldImage = picItemImage.Image;
                picItemImage.Image = null;
                picItemImage.Cursor = Cursors.Default;
                oldImage?.Dispose();
            }

            if (lblImageStatus != null)
            {
                lblImageStatus.Text = status;
                lblImageStatus.ForeColor = UiTheme.Muted;
            }
        }

        private void UpdateClaimsEmptyState(bool isEmpty)
        {
            if (lblClaimsEmptyState == null)
            {
                return;
            }

            lblClaimsEmptyState.Visible = isEmpty;
            if (gridMode == AdminGridMode.Claims)
            {
                lblClaimsEmptyState.Text = "Belum ada data klaim.";
            }
            else if (gridMode == AdminGridMode.LostItems)
            {
                lblClaimsEmptyState.Text = "Belum ada laporan hilang aktif.";
            }
            else
            {
                lblClaimsEmptyState.Text = "Belum ada barang ditemukan.";
            }

            if (isEmpty)
            {
                lblClaimsEmptyState.BringToFront();
            }
        }

        private void SetGridMode(AdminGridMode mode)
        {
            if (gridMode == mode)
            {
                return;
            }

            gridMode = mode;
            ApplyGridModeText();
            StyleViewButtons();
            LoadItems();
        }

        private void ApplyGridModeText()
        {
            if (gridMode == AdminGridMode.Claims)
            {
                lblItemsTitle.Text = "Data Klaim";
                lblItemsSubtitle.Text = "Semua klaim item yang diproses security";
                lblClaimTitle.Text = "Foto Klaim";
                lblClaimSubtitle.Text = "Pilih data klaim untuk melihat foto verifikasi";
                lblClaimant.Text = "Mahasiswa";
                txtClaimantName.PlaceholderText = "Pilih data klaim";
                HideDashboardPanelHeaders();
                LayoutClaimPhotoPanel();
                return;
            }

            if (gridMode == AdminGridMode.LostItems)
            {
                lblItemsTitle.Text = "Laporan Hilang";
                lblItemsSubtitle.Text = "Watchlist barang hilang yang belum selesai";
                lblClaimTitle.Text = "Foto Laporan";
                lblClaimSubtitle.Text = "Pilih laporan hilang untuk melihat foto";
                lblClaimant.Text = "Laporan";
                txtClaimantName.PlaceholderText = "Pilih laporan hilang";
                btnApproveClaim.Text = "Tandai Selesai";
                btnApproveClaim.Visible = false;
                HideDashboardPanelHeaders();
                LayoutClaimPhotoPanel();
                return;
            }

            lblItemsTitle.Text = "Barang Ditemukan";
            lblItemsSubtitle.Text = "Item temuan yang dilaporkan security";
            lblClaimTitle.Text = "Foto Item";
            lblClaimSubtitle.Text = "Pilih barang untuk melihat foto laporan";
            lblClaimant.Text = "Barang";
            txtClaimantName.PlaceholderText = "Pilih barang ditemukan";
            btnApproveClaim.Text = "Setujui Request";
            btnApproveClaim.Visible = false;
            HideDashboardPanelHeaders();
            LayoutClaimPhotoPanel();
        }

        private void btnApproveClaim_Click(object sender, EventArgs e)
        {
            if (gridMode == AdminGridMode.LostItems)
            {
                if (!TryGetSelectedItemId(out int itemId))
                {
                    UiTheme.ShowWarning(this, "Pilih laporan hilang yang akan ditandai selesai.");
                    return;
                }

                try
                {
                    item.MarkLostItemReturned(itemId);
                    UiTheme.ShowInfo(this, "Laporan hilang ditandai selesai. Status item sudah menjadi " + DomainValues.ItemStatuses.Returned + ".");
                    LoadItems();
                    LoadStats();
                    txtClaimantName.Clear();
                }
                catch (Exception ex)
                {
                    UiTheme.ShowError(this, "Gagal menyelesaikan laporan hilang: " + ex.Message);
                }

                return;
            }

            if (!TryGetSelectedClaimId(out int claimId))
            {
                UiTheme.ShowWarning(this, "Pilih request klaim " + DomainValues.ClaimStatuses.Pending + " yang akan disetujui.");
                return;
            }

            try
            {
                claim.ApprovePendingClaim(claimId, UserSession.UserID);
                UiTheme.ShowInfo(this, "Request klaim disetujui dan status item diubah menjadi " + DomainValues.ItemStatuses.Returned + ".");
                LoadItems();
                LoadStats();
                txtClaimantName.Clear();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memproses klaim: " + ex.Message);
            }
        }

        private string GetSelectedCellText(string columnName)
        {
            if (dgvItems.SelectedRows.Count == 0 || !dgvItems.Columns.Contains(columnName))
            {
                return string.Empty;
            }

            object value = dgvItems.SelectedRows[0].Cells[columnName].Value;
            return value == DBNull.Value || value == null ? string.Empty : Convert.ToString(value);
        }

        private bool TryGetSelectedClaimId(out int claimId)
        {
            claimId = 0;

            if (dgvItems.SelectedRows.Count == 0 || !dgvItems.Columns.Contains("ClaimID"))
            {
                return false;
            }

            object value = dgvItems.SelectedRows[0].Cells["ClaimID"].Value;
            return value != DBNull.Value && value != null && int.TryParse(Convert.ToString(value), out claimId);
        }

        private bool TryGetSelectedItemId(out int itemId)
        {
            itemId = 0;

            if (dgvItems.SelectedRows.Count == 0 || !dgvItems.Columns.Contains("ItemID"))
            {
                return false;
            }

            object value = dgvItems.SelectedRows[0].Cells["ItemID"].Value;
            return value != DBNull.Value && value != null && int.TryParse(Convert.ToString(value), out itemId);
        }

        private void LoadStats()
        {
            try
            {
                ItemStats stats = item.GetStats();
                chartStats.Datasets.Clear();
                if (lblLostMetric != null)
                {
                    lblLostMetric.Text = stats.LostCount.ToString();
                }

                if (lblFoundMetric != null)
                {
                    lblFoundMetric.Text = stats.FoundCount.ToString();
                }

                if (lblReturnedMetric != null)
                {
                    lblReturnedMetric.Text = stats.ReturnedCount.ToString();
                }

                if (lblHeaderActiveMetric != null)
                {
                    lblHeaderActiveMetric.Text = stats.ActiveCount.ToString();
                }

                if (lblHeaderLostMetric != null)
                {
                    lblHeaderLostMetric.Text = stats.LostCount.ToString();
                }

                if (lblHeaderReturnedMetric != null)
                {
                    lblHeaderReturnedMetric.Text = stats.ReturnedCount.ToString();
                }

                GunaDoughnutDataset statusDataset = new GunaDoughnutDataset
                {
                    Label = "Items",
                    BorderWidth = 0
                };

                statusDataset.FillColors.Add(UiTheme.Danger);
                statusDataset.FillColors.Add(UiTheme.Info);
                statusDataset.FillColors.Add(UiTheme.Success);
                statusDataset.DataPoints.Add("Hilang", stats.LostCount);
                statusDataset.DataPoints.Add("Ditemukan", stats.FoundCount);
                statusDataset.DataPoints.Add("Dikembalikan", stats.ReturnedCount);

                chartStats.Datasets.Add(statusDataset);
                chartStats.Update();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memuat statistik: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            new LoginForm().Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new ReportForm().ShowDialog(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ClearSelectedItemImage(string.Empty);
            base.OnFormClosing(e);
        }
    }
}
