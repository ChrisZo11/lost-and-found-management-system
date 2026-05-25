namespace LostAndFound
{
    partial class ReportForm
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
            Guna.UI2.WinForms.Guna2Panel markerLost;
            Guna.UI2.WinForms.Guna2Panel markerFound;
            Guna.UI2.WinForms.Guna2Panel markerReturned;
            System.Windows.Forms.Label captionLost;
            System.Windows.Forms.Label captionFound;
            System.Windows.Forms.Label captionReturned;
            this.panelWindowChrome = new Guna.UI2.WinForms.Guna2Panel();
            this.panelWindowIcon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.btnWindowMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnWindowMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btnWindowClose = new Guna.UI2.WinForms.Guna2Button();
            this.panelWindowDivider = new Guna.UI2.WinForms.Guna2Panel();
            this.reportHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.reportTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.reportSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.filterPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnShowAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowFound = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowLost = new Guna.UI2.WinForms.Guna2Button();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnClearDateFilter = new Guna.UI2.WinForms.Guna2Button();
            this.panelLostMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLost = new System.Windows.Forms.Label();
            this.panelFoundMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFound = new System.Windows.Forms.Label();
            this.panelReturnedMetric = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReturned = new System.Windows.Forms.Label();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblEmptyState = new System.Windows.Forms.Label();
            markerLost = new Guna.UI2.WinForms.Guna2Panel();
            markerFound = new Guna.UI2.WinForms.Guna2Panel();
            markerReturned = new Guna.UI2.WinForms.Guna2Panel();
            captionLost = new System.Windows.Forms.Label();
            captionFound = new System.Windows.Forms.Label();
            captionReturned = new System.Windows.Forms.Label();
            this.panelWindowChrome.SuspendLayout();
            this.reportHeader.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.panelLostMetric.SuspendLayout();
            this.panelFoundMetric.SuspendLayout();
            this.panelReturnedMetric.SuspendLayout();
            this.SuspendLayout();
            //
            // panelWindowChrome
            //
            this.panelWindowChrome.Controls.Add(this.panelWindowIcon);
            this.panelWindowChrome.Controls.Add(this.lblWindowTitle);
            this.panelWindowChrome.Controls.Add(this.btnWindowMinimize);
            this.panelWindowChrome.Controls.Add(this.btnWindowMaximize);
            this.panelWindowChrome.Controls.Add(this.btnWindowClose);
            this.panelWindowChrome.Controls.Add(this.panelWindowDivider);
            this.panelWindowChrome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindowChrome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelWindowChrome.Location = new System.Drawing.Point(0, 0);
            this.panelWindowChrome.Name = "panelWindowChrome";
            this.panelWindowChrome.Size = new System.Drawing.Size(1100, 42);
            this.panelWindowChrome.TabIndex = 0;
            //
            // panelWindowIcon
            //
            this.panelWindowIcon.BackColor = System.Drawing.Color.Transparent;
            this.panelWindowIcon.BackgroundImage = global::LostAndFound.UiTheme.TitleBarLogo;
            this.panelWindowIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelWindowIcon.BorderRadius = 4;
            this.panelWindowIcon.FillColor = System.Drawing.Color.Transparent;
            this.panelWindowIcon.Location = new System.Drawing.Point(20, 9);
            this.panelWindowIcon.Name = "panelWindowIcon";
            this.panelWindowIcon.Size = new System.Drawing.Size(24, 24);
            this.panelWindowIcon.TabIndex = 0;
            //
            // lblWindowTitle
            //
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.lblWindowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblWindowTitle.Location = new System.Drawing.Point(52, 12);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(160, 18);
            this.lblWindowTitle.TabIndex = 1;
            this.lblWindowTitle.Text = "Lost & Found";
            //
            // btnWindowMinimize
            //
            this.btnWindowMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMinimize.BorderRadius = 8;
            this.btnWindowMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnWindowMinimize.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Bold);
            this.btnWindowMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.btnWindowMinimize.Location = new System.Drawing.Point(974, 4);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.Size = new System.Drawing.Size(34, 30);
            this.btnWindowMinimize.TabIndex = 2;
            this.btnWindowMinimize.Text = "-";
            //
            // btnWindowMaximize
            //
            this.btnWindowMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMaximize.BorderRadius = 8;
            this.btnWindowMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnWindowMaximize.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Bold);
            this.btnWindowMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.btnWindowMaximize.Location = new System.Drawing.Point(1016, 4);
            this.btnWindowMaximize.Name = "btnWindowMaximize";
            this.btnWindowMaximize.Size = new System.Drawing.Size(34, 30);
            this.btnWindowMaximize.TabIndex = 3;
            this.btnWindowMaximize.Text = "â–¡";
            //
            // btnWindowClose
            //
            this.btnWindowClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowClose.BorderRadius = 8;
            this.btnWindowClose.FillColor = System.Drawing.Color.Transparent;
            this.btnWindowClose.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Bold);
            this.btnWindowClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.btnWindowClose.Location = new System.Drawing.Point(1058, 4);
            this.btnWindowClose.Name = "btnWindowClose";
            this.btnWindowClose.Size = new System.Drawing.Size(34, 30);
            this.btnWindowClose.TabIndex = 4;
            this.btnWindowClose.Text = "x";
            //
            // panelWindowDivider
            //
            this.panelWindowDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWindowDivider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.panelWindowDivider.Location = new System.Drawing.Point(0, 41);
            this.panelWindowDivider.Name = "panelWindowDivider";
            this.panelWindowDivider.Size = new System.Drawing.Size(1100, 1);
            this.panelWindowDivider.TabIndex = 5;
            //
            // reportHeader
            //
            this.reportHeader.Controls.Add(this.reportTitle);
            this.reportHeader.Controls.Add(this.reportSubtitle);
            this.reportHeader.FillColor = System.Drawing.Color.White;
            this.reportHeader.Location = new System.Drawing.Point(0, 42);
            this.reportHeader.Name = "reportHeader";
            this.reportHeader.Size = new System.Drawing.Size(1100, 82);
            this.reportHeader.TabIndex = 1;
            //
            // reportTitle
            //
            this.reportTitle.BackColor = System.Drawing.Color.Transparent;
            this.reportTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 16F, System.Drawing.FontStyle.Bold);
            this.reportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.reportTitle.Location = new System.Drawing.Point(28, 18);
            this.reportTitle.Name = "reportTitle";
            this.reportTitle.Size = new System.Drawing.Size(126, 32);
            this.reportTitle.TabIndex = 0;
            this.reportTitle.Text = "Laporan Item";
            //
            // reportSubtitle
            //
            this.reportSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.reportSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.reportSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.reportSubtitle.Location = new System.Drawing.Point(30, 48);
            this.reportSubtitle.Name = "reportSubtitle";
            this.reportSubtitle.Size = new System.Drawing.Size(270, 18);
            this.reportSubtitle.TabIndex = 1;
            this.reportSubtitle.Text = "Ringkasan item hilang, ditemukan, dan dikembalikan";
            //
            // filterPanel
            //
            this.filterPanel.BackColor = System.Drawing.Color.Transparent;
            this.filterPanel.Controls.Add(this.btnShowAll);
            this.filterPanel.Controls.Add(this.btnShowFound);
            this.filterPanel.Controls.Add(this.btnShowLost);
            this.filterPanel.Controls.Add(this.lblFromDate);
            this.filterPanel.Controls.Add(this.dtpFromDate);
            this.filterPanel.Controls.Add(this.lblToDate);
            this.filterPanel.Controls.Add(this.dtpToDate);
            this.filterPanel.Controls.Add(this.btnClearDateFilter);
            this.filterPanel.Location = new System.Drawing.Point(0, 124);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1100, 48);
            this.filterPanel.TabIndex = 2;
            //
            // btnShowAll
            //
            this.btnShowAll.BorderRadius = 8;
            this.btnShowAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(126)))));
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(28, 7);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 34);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "Semua";
            //
            // btnShowFound
            //
            this.btnShowFound.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnShowFound.BorderRadius = 8;
            this.btnShowFound.BorderThickness = 1;
            this.btnShowFound.FillColor = System.Drawing.Color.White;
            this.btnShowFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnShowFound.Location = new System.Drawing.Point(136, 7);
            this.btnShowFound.Name = "btnShowFound";
            this.btnShowFound.Size = new System.Drawing.Size(100, 34);
            this.btnShowFound.TabIndex = 1;
            this.btnShowFound.Text = "Ditemukan";
            //
            // btnShowLost
            //
            this.btnShowLost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnShowLost.BorderRadius = 8;
            this.btnShowLost.BorderThickness = 1;
            this.btnShowLost.FillColor = System.Drawing.Color.White;
            this.btnShowLost.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnShowLost.Location = new System.Drawing.Point(244, 7);
            this.btnShowLost.Name = "btnShowLost";
            this.btnShowLost.Size = new System.Drawing.Size(100, 34);
            this.btnShowLost.TabIndex = 2;
            this.btnShowLost.Text = "Hilang";
            //
            // lblFromDate
            //
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblFromDate.Location = new System.Drawing.Point(704, 13);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 22);
            this.lblFromDate.TabIndex = 3;
            this.lblFromDate.Text = "Dari";
            //
            // dtpFromDate
            //
            this.dtpFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.dtpFromDate.BorderRadius = 8;
            this.dtpFromDate.BorderThickness = 1;
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(740, 9);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(122, 30);
            this.dtpFromDate.TabIndex = 4;
            //
            // lblToDate
            //
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblToDate.Location = new System.Drawing.Point(878, 13);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(22, 22);
            this.lblToDate.TabIndex = 5;
            this.lblToDate.Text = "Ke";
            //
            // dtpToDate
            //
            this.dtpToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.dtpToDate.BorderRadius = 8;
            this.dtpToDate.BorderThickness = 1;
            this.dtpToDate.Checked = false;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(904, 9);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(122, 30);
            this.dtpToDate.TabIndex = 6;
            //
            // btnClearDateFilter
            //
            this.btnClearDateFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnClearDateFilter.BorderRadius = 8;
            this.btnClearDateFilter.BorderThickness = 1;
            this.btnClearDateFilter.FillColor = System.Drawing.Color.White;
            this.btnClearDateFilter.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearDateFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnClearDateFilter.Location = new System.Drawing.Point(1038, 9);
            this.btnClearDateFilter.Name = "btnClearDateFilter";
            this.btnClearDateFilter.Size = new System.Drawing.Size(64, 30);
            this.btnClearDateFilter.TabIndex = 7;
            this.btnClearDateFilter.Text = "Reset";
            //
            // panelLostMetric
            //
            this.panelLostMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelLostMetric.BorderRadius = 8;
            this.panelLostMetric.BorderThickness = 1;
            this.panelLostMetric.Controls.Add(markerLost);
            this.panelLostMetric.Controls.Add(this.lblLost);
            this.panelLostMetric.Controls.Add(captionLost);
            this.panelLostMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelLostMetric.Location = new System.Drawing.Point(28, 182);
            this.panelLostMetric.Name = "panelLostMetric";
            this.panelLostMetric.Size = new System.Drawing.Size(140, 54);
            this.panelLostMetric.TabIndex = 3;
            //
            // markerLost
            //
            markerLost.BorderRadius = 4;
            markerLost.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            markerLost.Location = new System.Drawing.Point(14, 14);
            markerLost.Name = "markerLost";
            markerLost.Size = new System.Drawing.Size(8, 8);
            markerLost.TabIndex = 0;
            //
            // lblLost
            //
            this.lblLost.BackColor = System.Drawing.Color.Transparent;
            this.lblLost.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblLost.Location = new System.Drawing.Point(30, 6);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(98, 23);
            this.lblLost.TabIndex = 1;
            this.lblLost.Text = "0";
            //
            // captionLost
            //
            captionLost.BackColor = System.Drawing.Color.Transparent;
            captionLost.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            captionLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            captionLost.Location = new System.Drawing.Point(14, 31);
            captionLost.Name = "captionLost";
            captionLost.Size = new System.Drawing.Size(114, 17);
            captionLost.TabIndex = 2;
            captionLost.Text = "Hilang";
            //
            // panelFoundMetric
            //
            this.panelFoundMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelFoundMetric.BorderRadius = 8;
            this.panelFoundMetric.BorderThickness = 1;
            this.panelFoundMetric.Controls.Add(markerFound);
            this.panelFoundMetric.Controls.Add(this.lblFound);
            this.panelFoundMetric.Controls.Add(captionFound);
            this.panelFoundMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelFoundMetric.Location = new System.Drawing.Point(480, 182);
            this.panelFoundMetric.Name = "panelFoundMetric";
            this.panelFoundMetric.Size = new System.Drawing.Size(140, 54);
            this.panelFoundMetric.TabIndex = 4;
            //
            // markerFound
            //
            markerFound.BorderRadius = 4;
            markerFound.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(103)))), ((int)(((byte)(214)))));
            markerFound.Location = new System.Drawing.Point(14, 14);
            markerFound.Name = "markerFound";
            markerFound.Size = new System.Drawing.Size(8, 8);
            markerFound.TabIndex = 0;
            //
            // lblFound
            //
            this.lblFound.BackColor = System.Drawing.Color.Transparent;
            this.lblFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblFound.Location = new System.Drawing.Point(30, 6);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(98, 23);
            this.lblFound.TabIndex = 1;
            this.lblFound.Text = "0";
            //
            // captionFound
            //
            captionFound.BackColor = System.Drawing.Color.Transparent;
            captionFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            captionFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            captionFound.Location = new System.Drawing.Point(14, 31);
            captionFound.Name = "captionFound";
            captionFound.Size = new System.Drawing.Size(114, 17);
            captionFound.TabIndex = 2;
            captionFound.Text = "Ditemukan";
            //
            // panelReturnedMetric
            //
            this.panelReturnedMetric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.panelReturnedMetric.BorderRadius = 8;
            this.panelReturnedMetric.BorderThickness = 1;
            this.panelReturnedMetric.Controls.Add(markerReturned);
            this.panelReturnedMetric.Controls.Add(this.lblReturned);
            this.panelReturnedMetric.Controls.Add(captionReturned);
            this.panelReturnedMetric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelReturnedMetric.Location = new System.Drawing.Point(932, 182);
            this.panelReturnedMetric.Name = "panelReturnedMetric";
            this.panelReturnedMetric.Size = new System.Drawing.Size(140, 54);
            this.panelReturnedMetric.TabIndex = 5;
            //
            // markerReturned
            //
            markerReturned.BorderRadius = 4;
            markerReturned.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(161)))), ((int)(((byte)(99)))));
            markerReturned.Location = new System.Drawing.Point(14, 14);
            markerReturned.Name = "markerReturned";
            markerReturned.Size = new System.Drawing.Size(8, 8);
            markerReturned.TabIndex = 0;
            //
            // lblReturned
            //
            this.lblReturned.BackColor = System.Drawing.Color.Transparent;
            this.lblReturned.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblReturned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblReturned.Location = new System.Drawing.Point(30, 6);
            this.lblReturned.Name = "lblReturned";
            this.lblReturned.Size = new System.Drawing.Size(98, 23);
            this.lblReturned.TabIndex = 1;
            this.lblReturned.Text = "0";
            //
            // captionReturned
            //
            captionReturned.BackColor = System.Drawing.Color.Transparent;
            captionReturned.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            captionReturned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            captionReturned.Location = new System.Drawing.Point(14, 31);
            captionReturned.Name = "captionReturned";
            captionReturned.Size = new System.Drawing.Size(114, 17);
            captionReturned.TabIndex = 2;
            captionReturned.Text = "Kembali";
            //
            // reportViewer
            //
            this.reportViewer.BackColor = System.Drawing.Color.White;
            this.reportViewer.Location = new System.Drawing.Point(24, 252);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1052, 420);
            this.reportViewer.TabIndex = 6;
            //
            // lblEmptyState
            //
            this.lblEmptyState.BackColor = System.Drawing.Color.White;
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmptyState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblEmptyState.Location = new System.Drawing.Point(24, 252);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(1052, 420);
            this.lblEmptyState.TabIndex = 7;
            this.lblEmptyState.Text = "Tidak ada data untuk filter yang dipilih.";
            this.lblEmptyState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyState.Visible = false;
            //
            // ReportForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.lblEmptyState);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelReturnedMetric);
            this.Controls.Add(this.panelFoundMetric);
            this.Controls.Add(this.panelLostMetric);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.reportHeader);
            this.Controls.Add(this.panelWindowChrome);
            this.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(980, 640);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Item - Lost and Found";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.panelWindowChrome.ResumeLayout(false);
            this.reportHeader.ResumeLayout(false);
            this.reportHeader.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.panelLostMetric.ResumeLayout(false);
            this.panelFoundMetric.ResumeLayout(false);
            this.panelReturnedMetric.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}
