namespace LostAndFound
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.panelUserBadge = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserBadge = new System.Windows.Forms.Label();
            this.panelUserBadgeMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelHeaderActive = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeaderActiveCaption = new System.Windows.Forms.Label();
            this.lblHeaderActiveMetric = new System.Windows.Forms.Label();
            this.panelHeaderActiveMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelHeaderLost = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeaderLostCaption = new System.Windows.Forms.Label();
            this.lblHeaderLostMetric = new System.Windows.Forms.Label();
            this.panelHeaderLostMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelHeaderReturned = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeaderReturnedCaption = new System.Windows.Forms.Label();
            this.lblHeaderReturnedMetric = new System.Windows.Forms.Label();
            this.panelHeaderReturnedMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelChart = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.panelReturnedMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReturnedMetricCaption = new System.Windows.Forms.Label();
            this.lblReturnedMetric = new System.Windows.Forms.Label();
            this.panelReturnedMetricMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelFoundMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFoundMetricCaption = new System.Windows.Forms.Label();
            this.lblFoundMetric = new System.Windows.Forms.Label();
            this.panelFoundMetricMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelLostMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLostMetricCaption = new System.Windows.Forms.Label();
            this.lblLostMetric = new System.Windows.Forms.Label();
            this.panelLostMetricMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblChartTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chartStats = new Guna.Charts.WinForms.GunaChart();
            this.panelClaim = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblImageStatus = new System.Windows.Forms.Label();
            this.picItemImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblClaimSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblClaimTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblClaimant = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnApproveClaim = new Guna.UI2.WinForms.Guna2Button();
            this.txtClaimantName = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelItems = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnShowClaims = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowFoundItems = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowLostItems = new Guna.UI2.WinForms.Guna2Button();
            this.panelDateFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnClearDateFilter = new Guna.UI2.WinForms.Guna2Button();
            this.lblItemsTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblItemsSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelUserBadge.SuspendLayout();
            this.panelHeaderActive.SuspendLayout();
            this.panelHeaderLost.SuspendLayout();
            this.panelHeaderReturned.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panelReturnedMetric.SuspendLayout();
            this.panelFoundMetric.SuspendLayout();
            this.panelLostMetric.SuspendLayout();
            this.panelClaim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panelItems.SuspendLayout();
            this.panelDateFilter.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(32, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(243, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard Admin";
            //
            // btnLogout
            //
            this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.BorderThickness = 1;
            this.btnLogout.FillColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.btnLogout.Location = new System.Drawing.Point(1116, 30);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 36);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Keluar";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // btnReport
            //
            this.btnReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnReport.BorderRadius = 8;
            this.btnReport.BorderThickness = 1;
            this.btnReport.FillColor = System.Drawing.Color.White;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnReport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.btnReport.Location = new System.Drawing.Point(1010, 30);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 36);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Laporan";
            //
            // panelUserBadge
            //
            this.panelUserBadge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelUserBadge.BorderRadius = 10;
            this.panelUserBadge.BorderThickness = 1;
            this.panelUserBadge.Controls.Add(this.lblUserBadge);
            this.panelUserBadge.Controls.Add(this.panelUserBadgeMarker);
            this.panelUserBadge.FillColor = System.Drawing.Color.White;
            this.panelUserBadge.Location = new System.Drawing.Point(764, 30);
            this.panelUserBadge.Name = "panelUserBadge";
            this.panelUserBadge.Size = new System.Drawing.Size(232, 36);
            this.panelUserBadge.TabIndex = 7;
            //
            // lblUserBadge
            //
            this.lblUserBadge.BackColor = System.Drawing.Color.Transparent;
            this.lblUserBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserBadge.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.8F, System.Drawing.FontStyle.Bold);
            this.lblUserBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblUserBadge.Location = new System.Drawing.Point(0, 0);
            this.lblUserBadge.Name = "lblUserBadge";
            this.lblUserBadge.Padding = new System.Windows.Forms.Padding(32, 0, 12, 0);
            this.lblUserBadge.Size = new System.Drawing.Size(232, 36);
            this.lblUserBadge.TabIndex = 1;
            this.lblUserBadge.Text = "Admin / admin";
            this.lblUserBadge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelUserBadgeMarker
            //
            this.panelUserBadgeMarker.BorderRadius = 5;
            this.panelUserBadgeMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(161)))), ((int)(((byte)(99)))));
            this.panelUserBadgeMarker.Location = new System.Drawing.Point(13, 13);
            this.panelUserBadgeMarker.Name = "panelUserBadgeMarker";
            this.panelUserBadgeMarker.Size = new System.Drawing.Size(10, 10);
            this.panelUserBadgeMarker.TabIndex = 0;
            //
            // panelHeaderActive
            //
            this.panelHeaderActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelHeaderActive.BorderRadius = 10;
            this.panelHeaderActive.BorderThickness = 1;
            this.panelHeaderActive.Controls.Add(this.lblHeaderActiveCaption);
            this.panelHeaderActive.Controls.Add(this.lblHeaderActiveMetric);
            this.panelHeaderActive.Controls.Add(this.panelHeaderActiveMarker);
            this.panelHeaderActive.FillColor = System.Drawing.Color.White;
            this.panelHeaderActive.Location = new System.Drawing.Point(382, 26);
            this.panelHeaderActive.Name = "panelHeaderActive";
            this.panelHeaderActive.Size = new System.Drawing.Size(112, 52);
            this.panelHeaderActive.TabIndex = 8;
            //
            // lblHeaderActiveCaption
            //
            this.lblHeaderActiveCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderActiveCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblHeaderActiveCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblHeaderActiveCaption.Location = new System.Drawing.Point(12, 30);
            this.lblHeaderActiveCaption.Name = "lblHeaderActiveCaption";
            this.lblHeaderActiveCaption.Size = new System.Drawing.Size(86, 16);
            this.lblHeaderActiveCaption.TabIndex = 2;
            this.lblHeaderActiveCaption.Text = "Aktif";
            //
            // lblHeaderActiveMetric
            //
            this.lblHeaderActiveMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderActiveMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderActiveMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblHeaderActiveMetric.Location = new System.Drawing.Point(27, 6);
            this.lblHeaderActiveMetric.Name = "lblHeaderActiveMetric";
            this.lblHeaderActiveMetric.Size = new System.Drawing.Size(68, 22);
            this.lblHeaderActiveMetric.TabIndex = 1;
            this.lblHeaderActiveMetric.Text = "0";
            //
            // panelHeaderActiveMarker
            //
            this.panelHeaderActiveMarker.BorderRadius = 4;
            this.panelHeaderActiveMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.panelHeaderActiveMarker.Location = new System.Drawing.Point(12, 12);
            this.panelHeaderActiveMarker.Name = "panelHeaderActiveMarker";
            this.panelHeaderActiveMarker.Size = new System.Drawing.Size(8, 8);
            this.panelHeaderActiveMarker.TabIndex = 0;
            //
            // panelHeaderLost
            //
            this.panelHeaderLost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelHeaderLost.BorderRadius = 10;
            this.panelHeaderLost.BorderThickness = 1;
            this.panelHeaderLost.Controls.Add(this.lblHeaderLostCaption);
            this.panelHeaderLost.Controls.Add(this.lblHeaderLostMetric);
            this.panelHeaderLost.Controls.Add(this.panelHeaderLostMarker);
            this.panelHeaderLost.FillColor = System.Drawing.Color.White;
            this.panelHeaderLost.Location = new System.Drawing.Point(510, 26);
            this.panelHeaderLost.Name = "panelHeaderLost";
            this.panelHeaderLost.Size = new System.Drawing.Size(112, 52);
            this.panelHeaderLost.TabIndex = 9;
            //
            // lblHeaderLostCaption
            //
            this.lblHeaderLostCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderLostCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblHeaderLostCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblHeaderLostCaption.Location = new System.Drawing.Point(12, 30);
            this.lblHeaderLostCaption.Name = "lblHeaderLostCaption";
            this.lblHeaderLostCaption.Size = new System.Drawing.Size(86, 16);
            this.lblHeaderLostCaption.TabIndex = 2;
            this.lblHeaderLostCaption.Text = "Hilang";
            //
            // lblHeaderLostMetric
            //
            this.lblHeaderLostMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderLostMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLostMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblHeaderLostMetric.Location = new System.Drawing.Point(27, 6);
            this.lblHeaderLostMetric.Name = "lblHeaderLostMetric";
            this.lblHeaderLostMetric.Size = new System.Drawing.Size(68, 22);
            this.lblHeaderLostMetric.TabIndex = 1;
            this.lblHeaderLostMetric.Text = "0";
            //
            // panelHeaderLostMarker
            //
            this.panelHeaderLostMarker.BorderRadius = 4;
            this.panelHeaderLostMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.panelHeaderLostMarker.Location = new System.Drawing.Point(12, 12);
            this.panelHeaderLostMarker.Name = "panelHeaderLostMarker";
            this.panelHeaderLostMarker.Size = new System.Drawing.Size(8, 8);
            this.panelHeaderLostMarker.TabIndex = 0;
            //
            // panelHeaderReturned
            //
            this.panelHeaderReturned.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelHeaderReturned.BorderRadius = 10;
            this.panelHeaderReturned.BorderThickness = 1;
            this.panelHeaderReturned.Controls.Add(this.lblHeaderReturnedCaption);
            this.panelHeaderReturned.Controls.Add(this.lblHeaderReturnedMetric);
            this.panelHeaderReturned.Controls.Add(this.panelHeaderReturnedMarker);
            this.panelHeaderReturned.FillColor = System.Drawing.Color.White;
            this.panelHeaderReturned.Location = new System.Drawing.Point(638, 26);
            this.panelHeaderReturned.Name = "panelHeaderReturned";
            this.panelHeaderReturned.Size = new System.Drawing.Size(112, 52);
            this.panelHeaderReturned.TabIndex = 10;
            //
            // lblHeaderReturnedCaption
            //
            this.lblHeaderReturnedCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderReturnedCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblHeaderReturnedCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblHeaderReturnedCaption.Location = new System.Drawing.Point(12, 30);
            this.lblHeaderReturnedCaption.Name = "lblHeaderReturnedCaption";
            this.lblHeaderReturnedCaption.Size = new System.Drawing.Size(86, 16);
            this.lblHeaderReturnedCaption.TabIndex = 2;
            this.lblHeaderReturnedCaption.Text = "Kembali";
            //
            // lblHeaderReturnedMetric
            //
            this.lblHeaderReturnedMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderReturnedMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderReturnedMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblHeaderReturnedMetric.Location = new System.Drawing.Point(27, 6);
            this.lblHeaderReturnedMetric.Name = "lblHeaderReturnedMetric";
            this.lblHeaderReturnedMetric.Size = new System.Drawing.Size(68, 22);
            this.lblHeaderReturnedMetric.TabIndex = 1;
            this.lblHeaderReturnedMetric.Text = "0";
            //
            // panelHeaderReturnedMarker
            //
            this.panelHeaderReturnedMarker.BorderRadius = 4;
            this.panelHeaderReturnedMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(161)))), ((int)(((byte)(99)))));
            this.panelHeaderReturnedMarker.Location = new System.Drawing.Point(12, 12);
            this.panelHeaderReturnedMarker.Name = "panelHeaderReturnedMarker";
            this.panelHeaderReturnedMarker.Size = new System.Drawing.Size(8, 8);
            this.panelHeaderReturnedMarker.TabIndex = 0;
            //
            // panelChart
            //
            this.panelChart.BackColor = System.Drawing.Color.Transparent;
            this.panelChart.Controls.Add(this.panelReturnedMetric);
            this.panelChart.Controls.Add(this.panelFoundMetric);
            this.panelChart.Controls.Add(this.panelLostMetric);
            this.panelChart.Controls.Add(this.lblChartSubtitle);
            this.panelChart.Controls.Add(this.lblChartTitle);
            this.panelChart.Controls.Add(this.chartStats);
            this.panelChart.FillColor = System.Drawing.Color.White;
            this.panelChart.Location = new System.Drawing.Point(883, 116);
            this.panelChart.Name = "panelChart";
            this.panelChart.Radius = 12;
            this.panelChart.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelChart.ShadowDepth = 0;
            this.panelChart.ShadowShift = 0;
            this.panelChart.Size = new System.Drawing.Size(386, 392);
            this.panelChart.TabIndex = 4;
            //
            // panelReturnedMetric
            //
            this.panelReturnedMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelReturnedMetric.BorderRadius = 8;
            this.panelReturnedMetric.BorderThickness = 1;
            this.panelReturnedMetric.Controls.Add(this.lblReturnedMetricCaption);
            this.panelReturnedMetric.Controls.Add(this.lblReturnedMetric);
            this.panelReturnedMetric.Controls.Add(this.panelReturnedMetricMarker);
            this.panelReturnedMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.panelReturnedMetric.Location = new System.Drawing.Point(254, 324);
            this.panelReturnedMetric.Name = "panelReturnedMetric";
            this.panelReturnedMetric.Size = new System.Drawing.Size(104, 54);
            this.panelReturnedMetric.TabIndex = 6;
            //
            // lblReturnedMetricCaption
            //
            this.lblReturnedMetricCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnedMetricCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblReturnedMetricCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblReturnedMetricCaption.Location = new System.Drawing.Point(13, 31);
            this.lblReturnedMetricCaption.Name = "lblReturnedMetricCaption";
            this.lblReturnedMetricCaption.Size = new System.Drawing.Size(92, 17);
            this.lblReturnedMetricCaption.TabIndex = 2;
            this.lblReturnedMetricCaption.Text = "Kembali";
            //
            // lblReturnedMetric
            //
            this.lblReturnedMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnedMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblReturnedMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblReturnedMetric.Location = new System.Drawing.Point(28, 6);
            this.lblReturnedMetric.Name = "lblReturnedMetric";
            this.lblReturnedMetric.Size = new System.Drawing.Size(76, 23);
            this.lblReturnedMetric.TabIndex = 1;
            this.lblReturnedMetric.Text = "0";
            //
            // panelReturnedMetricMarker
            //
            this.panelReturnedMetricMarker.BorderRadius = 4;
            this.panelReturnedMetricMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(161)))), ((int)(((byte)(99)))));
            this.panelReturnedMetricMarker.Location = new System.Drawing.Point(13, 13);
            this.panelReturnedMetricMarker.Name = "panelReturnedMetricMarker";
            this.panelReturnedMetricMarker.Size = new System.Drawing.Size(8, 8);
            this.panelReturnedMetricMarker.TabIndex = 0;
            //
            // panelFoundMetric
            //
            this.panelFoundMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelFoundMetric.BorderRadius = 8;
            this.panelFoundMetric.BorderThickness = 1;
            this.panelFoundMetric.Controls.Add(this.lblFoundMetricCaption);
            this.panelFoundMetric.Controls.Add(this.lblFoundMetric);
            this.panelFoundMetric.Controls.Add(this.panelFoundMetricMarker);
            this.panelFoundMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.panelFoundMetric.Location = new System.Drawing.Point(141, 324);
            this.panelFoundMetric.Name = "panelFoundMetric";
            this.panelFoundMetric.Size = new System.Drawing.Size(104, 54);
            this.panelFoundMetric.TabIndex = 5;
            //
            // lblFoundMetricCaption
            //
            this.lblFoundMetricCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblFoundMetricCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblFoundMetricCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblFoundMetricCaption.Location = new System.Drawing.Point(13, 31);
            this.lblFoundMetricCaption.Name = "lblFoundMetricCaption";
            this.lblFoundMetricCaption.Size = new System.Drawing.Size(92, 17);
            this.lblFoundMetricCaption.TabIndex = 2;
            this.lblFoundMetricCaption.Text = "Ditemukan";
            //
            // lblFoundMetric
            //
            this.lblFoundMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblFoundMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblFoundMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblFoundMetric.Location = new System.Drawing.Point(28, 6);
            this.lblFoundMetric.Name = "lblFoundMetric";
            this.lblFoundMetric.Size = new System.Drawing.Size(76, 23);
            this.lblFoundMetric.TabIndex = 1;
            this.lblFoundMetric.Text = "0";
            //
            // panelFoundMetricMarker
            //
            this.panelFoundMetricMarker.BorderRadius = 4;
            this.panelFoundMetricMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.panelFoundMetricMarker.Location = new System.Drawing.Point(13, 13);
            this.panelFoundMetricMarker.Name = "panelFoundMetricMarker";
            this.panelFoundMetricMarker.Size = new System.Drawing.Size(8, 8);
            this.panelFoundMetricMarker.TabIndex = 0;
            //
            // panelLostMetric
            //
            this.panelLostMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelLostMetric.BorderRadius = 8;
            this.panelLostMetric.BorderThickness = 1;
            this.panelLostMetric.Controls.Add(this.lblLostMetricCaption);
            this.panelLostMetric.Controls.Add(this.lblLostMetric);
            this.panelLostMetric.Controls.Add(this.panelLostMetricMarker);
            this.panelLostMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.panelLostMetric.Location = new System.Drawing.Point(28, 324);
            this.panelLostMetric.Name = "panelLostMetric";
            this.panelLostMetric.Size = new System.Drawing.Size(104, 54);
            this.panelLostMetric.TabIndex = 4;
            //
            // lblLostMetricCaption
            //
            this.lblLostMetricCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLostMetricCaption.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblLostMetricCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblLostMetricCaption.Location = new System.Drawing.Point(13, 31);
            this.lblLostMetricCaption.Name = "lblLostMetricCaption";
            this.lblLostMetricCaption.Size = new System.Drawing.Size(92, 17);
            this.lblLostMetricCaption.TabIndex = 2;
            this.lblLostMetricCaption.Text = "Hilang";
            //
            // lblLostMetric
            //
            this.lblLostMetric.BackColor = System.Drawing.Color.Transparent;
            this.lblLostMetric.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblLostMetric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblLostMetric.Location = new System.Drawing.Point(28, 6);
            this.lblLostMetric.Name = "lblLostMetric";
            this.lblLostMetric.Size = new System.Drawing.Size(76, 23);
            this.lblLostMetric.TabIndex = 1;
            this.lblLostMetric.Text = "0";
            //
            // panelLostMetricMarker
            //
            this.panelLostMetricMarker.BorderRadius = 4;
            this.panelLostMetricMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.panelLostMetricMarker.Location = new System.Drawing.Point(13, 13);
            this.panelLostMetricMarker.Name = "panelLostMetricMarker";
            this.panelLostMetricMarker.Size = new System.Drawing.Size(8, 8);
            this.panelLostMetricMarker.TabIndex = 0;
            //
            // lblChartSubtitle
            //
            this.lblChartSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblChartSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblChartSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChartSubtitle.Location = new System.Drawing.Point(28, 43);
            this.lblChartSubtitle.Name = "lblChartSubtitle";
            this.lblChartSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblChartSubtitle.TabIndex = 2;
            this.lblChartSubtitle.Text = null;
            this.lblChartSubtitle.Visible = false;
            //
            // lblChartTitle
            //
            this.lblChartTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblChartTitle.Location = new System.Drawing.Point(28, 18);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(3, 2);
            this.lblChartTitle.TabIndex = 1;
            this.lblChartTitle.Text = null;
            this.lblChartTitle.Visible = false;
            //
            // chartStats
            //
            this.chartStats.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F);
            this.chartStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            chartFont1.FontName = "Arial";
            this.chartStats.Legend.LabelFont = chartFont1;
            this.chartStats.Location = new System.Drawing.Point(28, 20);
            this.chartStats.Name = "chartStats";
            this.chartStats.Size = new System.Drawing.Size(330, 246);
            this.chartStats.TabIndex = 0;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartStats.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            this.chartStats.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartStats.Tooltips.TitleFont = chartFont4;
            this.chartStats.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            this.chartStats.XAxes.Ticks = tick1;
            this.chartStats.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            this.chartStats.YAxes.Ticks = tick2;
            this.chartStats.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            this.chartStats.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            this.chartStats.ZAxes.Ticks = tick3;
            //
            // panelClaim
            //
            this.panelClaim.BackColor = System.Drawing.Color.Transparent;
            this.panelClaim.Controls.Add(this.lblImageStatus);
            this.panelClaim.Controls.Add(this.picItemImage);
            this.panelClaim.Controls.Add(this.lblClaimSubtitle);
            this.panelClaim.Controls.Add(this.lblClaimTitle);
            this.panelClaim.Controls.Add(this.lblClaimant);
            this.panelClaim.Controls.Add(this.btnApproveClaim);
            this.panelClaim.Controls.Add(this.txtClaimantName);
            this.panelClaim.FillColor = System.Drawing.Color.White;
            this.panelClaim.Location = new System.Drawing.Point(24, 532);
            this.panelClaim.Name = "panelClaim";
            this.panelClaim.Radius = 12;
            this.panelClaim.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelClaim.ShadowDepth = 0;
            this.panelClaim.ShadowShift = 0;
            this.panelClaim.Size = new System.Drawing.Size(1264, 158);
            this.panelClaim.TabIndex = 5;
            //
            // lblImageStatus
            //
            this.lblImageStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblImageStatus.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.7F);
            this.lblImageStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblImageStatus.Location = new System.Drawing.Point(1138, 32);
            this.lblImageStatus.Name = "lblImageStatus";
            this.lblImageStatus.Size = new System.Drawing.Size(106, 72);
            this.lblImageStatus.TabIndex = 7;
            this.lblImageStatus.Text = "Pilih barang\r\nuntuk melihat foto";
            //
            // picItemImage
            //
            this.picItemImage.BorderRadius = 8;
            this.picItemImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.picItemImage.ImageRotate = 0F;
            this.picItemImage.Location = new System.Drawing.Point(1018, 20);
            this.picItemImage.Name = "picItemImage";
            this.picItemImage.Size = new System.Drawing.Size(104, 100);
            this.picItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItemImage.TabIndex = 6;
            this.picItemImage.TabStop = false;
            //
            // lblClaimSubtitle
            //
            this.lblClaimSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblClaimSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClaimSubtitle.Location = new System.Drawing.Point(28, 43);
            this.lblClaimSubtitle.Name = "lblClaimSubtitle";
            this.lblClaimSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblClaimSubtitle.TabIndex = 4;
            this.lblClaimSubtitle.Text = null;
            this.lblClaimSubtitle.Visible = false;
            //
            // lblClaimTitle
            //
            this.lblClaimTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblClaimTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblClaimTitle.Location = new System.Drawing.Point(28, 18);
            this.lblClaimTitle.Name = "lblClaimTitle";
            this.lblClaimTitle.Size = new System.Drawing.Size(3, 2);
            this.lblClaimTitle.TabIndex = 3;
            this.lblClaimTitle.Text = null;
            this.lblClaimTitle.Visible = false;
            //
            // lblClaimant
            //
            this.lblClaimant.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimant.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblClaimant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblClaimant.Location = new System.Drawing.Point(28, 48);
            this.lblClaimant.Name = "lblClaimant";
            this.lblClaimant.Size = new System.Drawing.Size(45, 18);
            this.lblClaimant.TabIndex = 2;
            this.lblClaimant.Text = "Barang";
            //
            // btnApproveClaim
            //
            this.btnApproveClaim.BorderRadius = 8;
            this.btnApproveClaim.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnApproveClaim.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnApproveClaim.ForeColor = System.Drawing.Color.White;
            this.btnApproveClaim.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnApproveClaim.Location = new System.Drawing.Point(-200, -200);
            this.btnApproveClaim.Name = "btnApproveClaim";
            this.btnApproveClaim.Size = new System.Drawing.Size(1, 1);
            this.btnApproveClaim.TabIndex = 1;
            this.btnApproveClaim.Visible = false;
            this.btnApproveClaim.Click += new System.EventHandler(this.btnApproveClaim_Click);
            //
            // txtClaimantName
            //
            this.txtClaimantName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtClaimantName.BorderRadius = 8;
            this.txtClaimantName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClaimantName.DefaultText = "";
            this.txtClaimantName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtClaimantName.Location = new System.Drawing.Point(134, 40);
            this.txtClaimantName.Name = "txtClaimantName";
            this.txtClaimantName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtClaimantName.PlaceholderText = "Pilih barang ditemukan";
            this.txtClaimantName.SelectedText = "";
            this.txtClaimantName.Size = new System.Drawing.Size(856, 42);
            this.txtClaimantName.TabIndex = 0;
            //
            // dgvItems
            //
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.ColumnHeadersHeight = 38;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvItems.Location = new System.Drawing.Point(28, 76);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 40;
            this.dgvItems.Size = new System.Drawing.Size(779, 292);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvItems.ThemeStyle.ReadOnly = false;
            this.dgvItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvItems.ThemeStyle.RowsStyle.Height = 40;
            this.dgvItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            //
            // panelItems
            //
            this.panelItems.BackColor = System.Drawing.Color.Transparent;
            this.panelItems.Controls.Add(this.btnShowClaims);
            this.panelItems.Controls.Add(this.btnShowLostItems);
            this.panelItems.Controls.Add(this.btnShowFoundItems);
            this.panelItems.Controls.Add(this.panelDateFilter);
            this.panelItems.Controls.Add(this.dgvItems);
            this.panelItems.FillColor = System.Drawing.Color.White;
            this.panelItems.Location = new System.Drawing.Point(24, 116);
            this.panelItems.Name = "panelItems";
            this.panelItems.Radius = 12;
            this.panelItems.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelItems.ShadowDepth = 0;
            this.panelItems.ShadowShift = 0;
            this.panelItems.Size = new System.Drawing.Size(835, 392);
            this.panelItems.TabIndex = 3;
            //
            // btnShowClaims
            //
            this.btnShowClaims.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnShowClaims.BorderRadius = 8;
            this.btnShowClaims.BorderThickness = 1;
            this.btnShowClaims.FillColor = System.Drawing.Color.White;
            this.btnShowClaims.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowClaims.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnShowClaims.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.btnShowClaims.Location = new System.Drawing.Point(711, 20);
            this.btnShowClaims.Name = "btnShowClaims";
            this.btnShowClaims.Size = new System.Drawing.Size(96, 34);
            this.btnShowClaims.TabIndex = 5;
            this.btnShowClaims.Text = "Histori";
            //
            // btnShowFoundItems
            //
            this.btnShowFoundItems.BorderRadius = 8;
            this.btnShowFoundItems.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnShowFoundItems.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowFoundItems.ForeColor = System.Drawing.Color.White;
            this.btnShowFoundItems.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnShowFoundItems.Location = new System.Drawing.Point(491, 20);
            this.btnShowFoundItems.Name = "btnShowFoundItems";
            this.btnShowFoundItems.Size = new System.Drawing.Size(104, 34);
            this.btnShowFoundItems.TabIndex = 4;
            this.btnShowFoundItems.Text = "Barang";
            //
            // btnShowLostItems
            //
            this.btnShowLostItems.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnShowLostItems.BorderRadius = 8;
            this.btnShowLostItems.BorderThickness = 1;
            this.btnShowLostItems.FillColor = System.Drawing.Color.White;
            this.btnShowLostItems.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowLostItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnShowLostItems.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.btnShowLostItems.Location = new System.Drawing.Point(605, 20);
            this.btnShowLostItems.Name = "btnShowLostItems";
            this.btnShowLostItems.Size = new System.Drawing.Size(96, 34);
            this.btnShowLostItems.TabIndex = 6;
            this.btnShowLostItems.Text = "Hilang";
            //
            // panelDateFilter
            //
            this.panelDateFilter.BackColor = System.Drawing.Color.Transparent;
            this.panelDateFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelDateFilter.BorderRadius = 10;
            this.panelDateFilter.BorderThickness = 1;
            this.panelDateFilter.Controls.Add(this.lblFromDate);
            this.panelDateFilter.Controls.Add(this.dtpFromDate);
            this.panelDateFilter.Controls.Add(this.lblToDate);
            this.panelDateFilter.Controls.Add(this.dtpToDate);
            this.panelDateFilter.Controls.Add(this.btnClearDateFilter);
            this.panelDateFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelDateFilter.Location = new System.Drawing.Point(39, 14);
            this.panelDateFilter.Name = "panelDateFilter";
            this.panelDateFilter.Size = new System.Drawing.Size(438, 44);
            this.panelDateFilter.TabIndex = 3;
            //
            // lblFromDate
            //
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblFromDate.Location = new System.Drawing.Point(14, 11);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(40, 22);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "From";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpFromDate
            //
            this.dtpFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.dtpFromDate.BorderRadius = 8;
            this.dtpFromDate.BorderThickness = 1;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F);
            this.dtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(56, 7);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(132, 30);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.Value = new System.DateTime(2026, 5, 24, 1, 55, 38, 600);
            //
            // lblToDate
            //
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblToDate.Location = new System.Drawing.Point(200, 11);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(22, 22);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpToDate
            //
            this.dtpToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.dtpToDate.BorderRadius = 8;
            this.dtpToDate.BorderThickness = 1;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F);
            this.dtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(224, 7);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(132, 30);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.Value = new System.DateTime(2026, 5, 24, 1, 55, 38, 660);
            //
            // btnClearDateFilter
            //
            this.btnClearDateFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnClearDateFilter.BorderRadius = 8;
            this.btnClearDateFilter.BorderThickness = 1;
            this.btnClearDateFilter.FillColor = System.Drawing.Color.White;
            this.btnClearDateFilter.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F, System.Drawing.FontStyle.Bold);
            this.btnClearDateFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnClearDateFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.btnClearDateFilter.Location = new System.Drawing.Point(366, 7);
            this.btnClearDateFilter.Name = "btnClearDateFilter";
            this.btnClearDateFilter.Size = new System.Drawing.Size(64, 30);
            this.btnClearDateFilter.TabIndex = 4;
            this.btnClearDateFilter.Text = "Reset";
            //
            // lblItemsTitle
            //
            this.lblItemsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblItemsTitle.Location = new System.Drawing.Point(28, 18);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Size = new System.Drawing.Size(3, 2);
            this.lblItemsTitle.TabIndex = 1;
            this.lblItemsTitle.Text = null;
            this.lblItemsTitle.Visible = false;
            //
            // lblItemsSubtitle
            //
            this.lblItemsSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblItemsSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblItemsSubtitle.Location = new System.Drawing.Point(28, 43);
            this.lblItemsSubtitle.Name = "lblItemsSubtitle";
            this.lblItemsSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblItemsSubtitle.TabIndex = 2;
            this.lblItemsSubtitle.Text = null;
            this.lblItemsSubtitle.Visible = false;
            //
            // AdminForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1300, 724);
            this.Controls.Add(this.panelClaim);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.panelUserBadge);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Admin - Lost and Found";
            this.panelUserBadge.ResumeLayout(false);
            this.panelHeaderActive.ResumeLayout(false);
            this.panelHeaderLost.ResumeLayout(false);
            this.panelHeaderReturned.ResumeLayout(false);
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            this.panelReturnedMetric.ResumeLayout(false);
            this.panelFoundMetric.ResumeLayout(false);
            this.panelLostMetric.ResumeLayout(false);
            this.panelClaim.ResumeLayout(false);
            this.panelClaim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panelItems.ResumeLayout(false);
            this.panelDateFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelChart;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelClaim;
        private Guna.Charts.WinForms.GunaChart chartStats;
        private Guna.UI2.WinForms.Guna2TextBox txtClaimantName;
        private Guna.UI2.WinForms.Guna2Button btnApproveClaim;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClaimant;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChartTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChartSubtitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClaimTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClaimSubtitle;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        private Guna.UI2.WinForms.Guna2Panel panelUserBadge;
        private Guna.UI2.WinForms.Guna2Panel panelUserBadgeMarker;
        private System.Windows.Forms.Label lblUserBadge;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderActive;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderActiveMarker;
        private System.Windows.Forms.Label lblHeaderActiveCaption;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderLost;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderLostMarker;
        private System.Windows.Forms.Label lblHeaderLostCaption;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderReturned;
        private Guna.UI2.WinForms.Guna2Panel panelHeaderReturnedMarker;
        private System.Windows.Forms.Label lblHeaderReturnedCaption;
        private Guna.UI2.WinForms.Guna2Panel panelLostMetric;
        private Guna.UI2.WinForms.Guna2Panel panelLostMetricMarker;
        private System.Windows.Forms.Label lblLostMetricCaption;
        private Guna.UI2.WinForms.Guna2Panel panelFoundMetric;
        private Guna.UI2.WinForms.Guna2Panel panelFoundMetricMarker;
        private System.Windows.Forms.Label lblFoundMetricCaption;
        private Guna.UI2.WinForms.Guna2Panel panelReturnedMetric;
        private Guna.UI2.WinForms.Guna2Panel panelReturnedMetricMarker;
        private System.Windows.Forms.Label lblReturnedMetricCaption;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItems;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelItems;
        private Guna.UI2.WinForms.Guna2Panel panelDateFilter;
        private System.Windows.Forms.Label lblFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2Button btnClearDateFilter;
        private Guna.UI2.WinForms.Guna2Button btnShowFoundItems;
        private Guna.UI2.WinForms.Guna2Button btnShowClaims;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblItemsTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblItemsSubtitle;
    }
}
