namespace LostAndFound
{
    partial class SecurityForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panelUserBadge = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserBadge = new System.Windows.Forms.Label();
            this.panelUserBadgeMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelStepReport = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepReportText = new System.Windows.Forms.Label();
            this.lblStepReportNumber = new System.Windows.Forms.Label();
            this.panelStepReportMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelStepPhoto = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepPhotoText = new System.Windows.Forms.Label();
            this.lblStepPhotoNumber = new System.Windows.Forms.Label();
            this.panelStepPhotoMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelStepMonitor = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStepMonitorText = new System.Windows.Forms.Label();
            this.lblStepMonitorNumber = new System.Windows.Forms.Label();
            this.panelStepMonitorMarker = new Guna.UI2.WinForms.Guna2Panel();
            this.panelReport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblReportSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblReportTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.rbLost = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbFound = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblLoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDesc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblItemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtItemName = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelTips = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.btnRetakePhoto = new Guna.UI2.WinForms.Guna2Button();
            this.btnCapturePhoto = new Guna.UI2.WinForms.Guna2Button();
            this.btnStopCamera = new Guna.UI2.WinForms.Guna2Button();
            this.btnStartCamera = new Guna.UI2.WinForms.Guna2Button();
            this.picCamera = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmbCamera = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhotoSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPhotoTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelGrid = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnShowFoundItems = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowLostItems = new Guna.UI2.WinForms.Guna2Button();
            this.lblRecentSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRecentTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelClaimToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudentNim = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStudentNim = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStudentName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStudentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.picClaimPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblClaimPhotoStatus = new System.Windows.Forms.Label();
            this.btnUploadClaimPhoto = new Guna.UI2.WinForms.Guna2Button();
            this.btnUseCameraClaimPhoto = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveClaim = new Guna.UI2.WinForms.Guna2Button();
            this.btnMarkLostReturned = new Guna.UI2.WinForms.Guna2Button();
            this.lblClaimRequestHint = new System.Windows.Forms.Label();
            this.dgvItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelUserBadge.SuspendLayout();
            this.panelStepReport.SuspendLayout();
            this.panelStepPhoto.SuspendLayout();
            this.panelStepMonitor.SuspendLayout();
            this.panelReport.SuspendLayout();
            this.panelTips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.panelGrid.SuspendLayout();
            this.panelClaimToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClaimPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(32, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard Security";
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
            this.btnLogout.Location = new System.Drawing.Point(1104, 30);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 36);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Keluar";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // panelUserBadge
            //
            this.panelUserBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserBadge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelUserBadge.BorderRadius = 10;
            this.panelUserBadge.BorderThickness = 1;
            this.panelUserBadge.Controls.Add(this.lblUserBadge);
            this.panelUserBadge.Controls.Add(this.panelUserBadgeMarker);
            this.panelUserBadge.FillColor = System.Drawing.Color.White;
            this.panelUserBadge.Location = new System.Drawing.Point(852, 30);
            this.panelUserBadge.Name = "panelUserBadge";
            this.panelUserBadge.Size = new System.Drawing.Size(232, 36);
            this.panelUserBadge.TabIndex = 6;
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
            this.lblUserBadge.Text = "Security / security";
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
            // panelStepReport
            //
            this.panelStepReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelStepReport.BorderRadius = 10;
            this.panelStepReport.BorderThickness = 1;
            this.panelStepReport.Controls.Add(this.lblStepReportText);
            this.panelStepReport.Controls.Add(this.lblStepReportNumber);
            this.panelStepReport.Controls.Add(this.panelStepReportMarker);
            this.panelStepReport.FillColor = System.Drawing.Color.White;
            this.panelStepReport.Location = new System.Drawing.Point(408, 26);
            this.panelStepReport.Name = "panelStepReport";
            this.panelStepReport.Size = new System.Drawing.Size(108, 52);
            this.panelStepReport.TabIndex = 7;
            //
            // lblStepReportText
            //
            this.lblStepReportText.BackColor = System.Drawing.Color.Transparent;
            this.lblStepReportText.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblStepReportText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblStepReportText.Location = new System.Drawing.Point(12, 30);
            this.lblStepReportText.Name = "lblStepReportText";
            this.lblStepReportText.Size = new System.Drawing.Size(86, 16);
            this.lblStepReportText.TabIndex = 2;
            this.lblStepReportText.Text = "Lapor";
            this.lblStepReportText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStepReportNumber
            //
            this.lblStepReportNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblStepReportNumber.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblStepReportNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblStepReportNumber.Location = new System.Drawing.Point(27, 6);
            this.lblStepReportNumber.Name = "lblStepReportNumber";
            this.lblStepReportNumber.Size = new System.Drawing.Size(68, 20);
            this.lblStepReportNumber.TabIndex = 1;
            this.lblStepReportNumber.Text = "01";
            this.lblStepReportNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelStepReportMarker
            //
            this.panelStepReportMarker.BorderRadius = 4;
            this.panelStepReportMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.panelStepReportMarker.Location = new System.Drawing.Point(12, 12);
            this.panelStepReportMarker.Name = "panelStepReportMarker";
            this.panelStepReportMarker.Size = new System.Drawing.Size(8, 8);
            this.panelStepReportMarker.TabIndex = 0;
            //
            // panelStepPhoto
            //
            this.panelStepPhoto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelStepPhoto.BorderRadius = 10;
            this.panelStepPhoto.BorderThickness = 1;
            this.panelStepPhoto.Controls.Add(this.lblStepPhotoText);
            this.panelStepPhoto.Controls.Add(this.lblStepPhotoNumber);
            this.panelStepPhoto.Controls.Add(this.panelStepPhotoMarker);
            this.panelStepPhoto.FillColor = System.Drawing.Color.White;
            this.panelStepPhoto.Location = new System.Drawing.Point(532, 26);
            this.panelStepPhoto.Name = "panelStepPhoto";
            this.panelStepPhoto.Size = new System.Drawing.Size(108, 52);
            this.panelStepPhoto.TabIndex = 8;
            //
            // lblStepPhotoText
            //
            this.lblStepPhotoText.BackColor = System.Drawing.Color.Transparent;
            this.lblStepPhotoText.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblStepPhotoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblStepPhotoText.Location = new System.Drawing.Point(12, 30);
            this.lblStepPhotoText.Name = "lblStepPhotoText";
            this.lblStepPhotoText.Size = new System.Drawing.Size(86, 16);
            this.lblStepPhotoText.TabIndex = 2;
            this.lblStepPhotoText.Text = "Foto";
            this.lblStepPhotoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStepPhotoNumber
            //
            this.lblStepPhotoNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblStepPhotoNumber.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblStepPhotoNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblStepPhotoNumber.Location = new System.Drawing.Point(27, 6);
            this.lblStepPhotoNumber.Name = "lblStepPhotoNumber";
            this.lblStepPhotoNumber.Size = new System.Drawing.Size(68, 20);
            this.lblStepPhotoNumber.TabIndex = 1;
            this.lblStepPhotoNumber.Text = "02";
            this.lblStepPhotoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelStepPhotoMarker
            //
            this.panelStepPhotoMarker.BorderRadius = 4;
            this.panelStepPhotoMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(174)))), ((int)(((byte)(45)))));
            this.panelStepPhotoMarker.Location = new System.Drawing.Point(12, 12);
            this.panelStepPhotoMarker.Name = "panelStepPhotoMarker";
            this.panelStepPhotoMarker.Size = new System.Drawing.Size(8, 8);
            this.panelStepPhotoMarker.TabIndex = 0;
            //
            // panelStepMonitor
            //
            this.panelStepMonitor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelStepMonitor.BorderRadius = 10;
            this.panelStepMonitor.BorderThickness = 1;
            this.panelStepMonitor.Controls.Add(this.lblStepMonitorText);
            this.panelStepMonitor.Controls.Add(this.lblStepMonitorNumber);
            this.panelStepMonitor.Controls.Add(this.panelStepMonitorMarker);
            this.panelStepMonitor.FillColor = System.Drawing.Color.White;
            this.panelStepMonitor.Location = new System.Drawing.Point(656, 26);
            this.panelStepMonitor.Name = "panelStepMonitor";
            this.panelStepMonitor.Size = new System.Drawing.Size(108, 52);
            this.panelStepMonitor.TabIndex = 9;
            //
            // lblStepMonitorText
            //
            this.lblStepMonitorText.BackColor = System.Drawing.Color.Transparent;
            this.lblStepMonitorText.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F);
            this.lblStepMonitorText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblStepMonitorText.Location = new System.Drawing.Point(12, 30);
            this.lblStepMonitorText.Name = "lblStepMonitorText";
            this.lblStepMonitorText.Size = new System.Drawing.Size(86, 16);
            this.lblStepMonitorText.TabIndex = 2;
            this.lblStepMonitorText.Text = "Pantau";
            this.lblStepMonitorText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStepMonitorNumber
            //
            this.lblStepMonitorNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblStepMonitorNumber.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold);
            this.lblStepMonitorNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblStepMonitorNumber.Location = new System.Drawing.Point(27, 6);
            this.lblStepMonitorNumber.Name = "lblStepMonitorNumber";
            this.lblStepMonitorNumber.Size = new System.Drawing.Size(68, 20);
            this.lblStepMonitorNumber.TabIndex = 1;
            this.lblStepMonitorNumber.Text = "03";
            this.lblStepMonitorNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelStepMonitorMarker
            //
            this.panelStepMonitorMarker.BorderRadius = 4;
            this.panelStepMonitorMarker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.panelStepMonitorMarker.Location = new System.Drawing.Point(12, 12);
            this.panelStepMonitorMarker.Name = "panelStepMonitorMarker";
            this.panelStepMonitorMarker.Size = new System.Drawing.Size(8, 8);
            this.panelStepMonitorMarker.TabIndex = 0;
            //
            // panelReport
            //
            this.panelReport.BackColor = System.Drawing.Color.Transparent;
            this.panelReport.Controls.Add(this.lblType);
            this.panelReport.Controls.Add(this.lblReportSubtitle);
            this.panelReport.Controls.Add(this.lblReportTitle);
            this.panelReport.Controls.Add(this.btnSave);
            this.panelReport.Controls.Add(this.rbLost);
            this.panelReport.Controls.Add(this.rbFound);
            this.panelReport.Controls.Add(this.lblLoc);
            this.panelReport.Controls.Add(this.lblDesc);
            this.panelReport.Controls.Add(this.lblItemName);
            this.panelReport.Controls.Add(this.txtLocation);
            this.panelReport.Controls.Add(this.txtDescription);
            this.panelReport.Controls.Add(this.txtItemName);
            this.panelReport.FillColor = System.Drawing.Color.White;
            this.panelReport.Location = new System.Drawing.Point(24, 116);
            this.panelReport.Name = "panelReport";
            this.panelReport.Radius = 12;
            this.panelReport.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelReport.ShadowDepth = 0;
            this.panelReport.ShadowShift = 0;
            this.panelReport.Size = new System.Drawing.Size(500, 338);
            this.panelReport.TabIndex = 3;
            //
            // lblType
            //
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblType.Location = new System.Drawing.Point(28, 210);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 18);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Tipe";
            //
            // lblReportSubtitle
            //
            this.lblReportSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReportSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblReportSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReportSubtitle.Location = new System.Drawing.Point(28, 43);
            this.lblReportSubtitle.Name = "lblReportSubtitle";
            this.lblReportSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblReportSubtitle.TabIndex = 10;
            this.lblReportSubtitle.Text = null;
            this.lblReportSubtitle.Visible = false;
            //
            // lblReportTitle
            //
            this.lblReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblReportTitle.Location = new System.Drawing.Point(28, 18);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(3, 2);
            this.lblReportTitle.TabIndex = 9;
            this.lblReportTitle.Text = null;
            this.lblReportTitle.Visible = false;
            //
            // btnSave
            //
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnSave.Location = new System.Drawing.Point(28, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 42);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Simpan Laporan";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // rbLost
            //
            this.rbLost.AutoSize = true;
            this.rbLost.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbLost.CheckedState.BorderThickness = 0;
            this.rbLost.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbLost.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbLost.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.rbLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.rbLost.Location = new System.Drawing.Point(198, 207);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(67, 20);
            this.rbLost.TabIndex = 4;
            this.rbLost.Text = "Hilang";
            this.rbLost.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.rbLost.UncheckedState.BorderThickness = 0;
            this.rbLost.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbLost.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            //
            // rbFound
            //
            this.rbFound.AutoSize = true;
            this.rbFound.Checked = true;
            this.rbFound.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.rbFound.CheckedState.BorderThickness = 0;
            this.rbFound.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.rbFound.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFound.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.rbFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.rbFound.Location = new System.Drawing.Point(94, 207);
            this.rbFound.Name = "rbFound";
            this.rbFound.Size = new System.Drawing.Size(88, 20);
            this.rbFound.TabIndex = 3;
            this.rbFound.TabStop = true;
            this.rbFound.Text = "Ditemukan";
            this.rbFound.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.rbFound.UncheckedState.BorderThickness = 0;
            this.rbFound.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFound.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            //
            // lblLoc
            //
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblLoc.Location = new System.Drawing.Point(240, 24);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(45, 18);
            this.lblLoc.TabIndex = 5;
            this.lblLoc.Text = "Lokasi";
            //
            // lblDesc
            //
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblDesc.Location = new System.Drawing.Point(28, 104);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(66, 18);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Deskripsi";
            //
            // lblItemName
            //
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblItemName.Location = new System.Drawing.Point(28, 24);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(80, 18);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Nama Barang";
            //
            // txtLocation
            //
            this.txtLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtLocation.BorderRadius = 8;
            this.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLocation.DefaultText = "";
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtLocation.Location = new System.Drawing.Point(240, 48);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtLocation.PlaceholderText = "Lokasi ditemukan/hilang";
            this.txtLocation.SelectedText = "";
            this.txtLocation.Size = new System.Drawing.Size(232, 42);
            this.txtLocation.TabIndex = 2;
            //
            // txtDescription
            //
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtDescription.BorderRadius = 8;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtDescription.Location = new System.Drawing.Point(28, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtDescription.PlaceholderText = "Ciri-ciri, warna, atau detail penting";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(444, 66);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            //
            // txtItemName
            //
            this.txtItemName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtItemName.BorderRadius = 8;
            this.txtItemName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtItemName.DefaultText = "";
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtItemName.Location = new System.Drawing.Point(28, 48);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtItemName.PlaceholderText = "Dompet, HP, dokumen...";
            this.txtItemName.SelectedText = "";
            this.txtItemName.Size = new System.Drawing.Size(212, 42);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            //
            // panelTips
            //
            this.panelTips.BackColor = System.Drawing.Color.Transparent;
            this.panelTips.Controls.Add(this.lblCameraStatus);
            this.panelTips.Controls.Add(this.btnRetakePhoto);
            this.panelTips.Controls.Add(this.btnCapturePhoto);
            this.panelTips.Controls.Add(this.btnStopCamera);
            this.panelTips.Controls.Add(this.btnStartCamera);
            this.panelTips.Controls.Add(this.picCamera);
            this.panelTips.Controls.Add(this.cmbCamera);
            this.panelTips.Controls.Add(this.lblPhotoSubtitle);
            this.panelTips.Controls.Add(this.lblPhotoTitle);
            this.panelTips.FillColor = System.Drawing.Color.White;
            this.panelTips.Location = new System.Drawing.Point(546, 116);
            this.panelTips.Name = "panelTips";
            this.panelTips.Radius = 12;
            this.panelTips.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelTips.ShadowDepth = 0;
            this.panelTips.ShadowShift = 0;
            this.panelTips.Size = new System.Drawing.Size(650, 338);
            this.panelTips.TabIndex = 4;
            //
            // lblCameraStatus
            //
            this.lblCameraStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCameraStatus.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.7F);
            this.lblCameraStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblCameraStatus.Location = new System.Drawing.Point(444, 168);
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(200, 54);
            this.lblCameraStatus.TabIndex = 7;
            this.lblCameraStatus.Text = "Pilih kamera, lalu mulai preview.";
            //
            // btnRetakePhoto
            //
            this.btnRetakePhoto.BorderRadius = 8;
            this.btnRetakePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetakePhoto.Enabled = false;
            this.btnRetakePhoto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnRetakePhoto.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnRetakePhoto.ForeColor = System.Drawing.Color.White;
            this.btnRetakePhoto.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnRetakePhoto.Location = new System.Drawing.Point(444, 120);
            this.btnRetakePhoto.Name = "btnRetakePhoto";
            this.btnRetakePhoto.Size = new System.Drawing.Size(112, 38);
            this.btnRetakePhoto.TabIndex = 6;
            this.btnRetakePhoto.Text = "Ulangi";
            //
            // btnCapturePhoto
            //
            this.btnCapturePhoto.BorderRadius = 8;
            this.btnCapturePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturePhoto.Enabled = false;
            this.btnCapturePhoto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnCapturePhoto.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapturePhoto.ForeColor = System.Drawing.Color.White;
            this.btnCapturePhoto.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnCapturePhoto.Location = new System.Drawing.Point(444, 72);
            this.btnCapturePhoto.Name = "btnCapturePhoto";
            this.btnCapturePhoto.Size = new System.Drawing.Size(112, 38);
            this.btnCapturePhoto.TabIndex = 5;
            this.btnCapturePhoto.Text = "Ambil";
            //
            // btnStopCamera
            //
            this.btnStopCamera.BorderRadius = 8;
            this.btnStopCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopCamera.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStopCamera.Enabled = false;
            this.btnStopCamera.FillColor = System.Drawing.Color.Red;
            this.btnStopCamera.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnStopCamera.ForeColor = System.Drawing.Color.White;
            this.btnStopCamera.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnStopCamera.Location = new System.Drawing.Point(546, 28);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnStopCamera.Size = new System.Drawing.Size(92, 36);
            this.btnStopCamera.TabIndex = 8;
            this.btnStopCamera.Text = "Stop";
            //
            // btnStartCamera
            //
            this.btnStartCamera.BorderRadius = 8;
            this.btnStartCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartCamera.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnStartCamera.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnStartCamera.ForeColor = System.Drawing.Color.White;
            this.btnStartCamera.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnStartCamera.Location = new System.Drawing.Point(444, 28);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(92, 36);
            this.btnStartCamera.TabIndex = 4;
            this.btnStartCamera.Text = "Mulai";
            //
            // picCamera
            //
            this.picCamera.BackColor = System.Drawing.Color.Transparent;
            this.picCamera.BorderRadius = 8;
            this.picCamera.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.picCamera.ImageRotate = 0F;
            this.picCamera.Location = new System.Drawing.Point(34, 72);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(390, 242);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera.TabIndex = 3;
            this.picCamera.TabStop = false;
            //
            // cmbCamera
            //
            this.cmbCamera.BackColor = System.Drawing.Color.Transparent;
            this.cmbCamera.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.cmbCamera.BorderRadius = 8;
            this.cmbCamera.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamera.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCamera.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.cmbCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.ItemHeight = 30;
            this.cmbCamera.Location = new System.Drawing.Point(34, 28);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(390, 36);
            this.cmbCamera.TabIndex = 2;
            //
            // lblPhotoSubtitle
            //
            this.lblPhotoSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPhotoSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblPhotoSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPhotoSubtitle.Location = new System.Drawing.Point(34, 52);
            this.lblPhotoSubtitle.Name = "lblPhotoSubtitle";
            this.lblPhotoSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblPhotoSubtitle.TabIndex = 1;
            this.lblPhotoSubtitle.Text = null;
            this.lblPhotoSubtitle.Visible = false;
            //
            // lblPhotoTitle
            //
            this.lblPhotoTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPhotoTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblPhotoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblPhotoTitle.Location = new System.Drawing.Point(34, 20);
            this.lblPhotoTitle.Name = "lblPhotoTitle";
            this.lblPhotoTitle.Size = new System.Drawing.Size(3, 2);
            this.lblPhotoTitle.TabIndex = 0;
            this.lblPhotoTitle.Text = null;
            this.lblPhotoTitle.Visible = false;
            //
            // panelGrid
            //
            this.panelGrid.BackColor = System.Drawing.Color.Transparent;
            this.panelGrid.Controls.Add(this.btnShowLostItems);
            this.panelGrid.Controls.Add(this.btnShowFoundItems);
            this.panelGrid.Controls.Add(this.lblRecentSubtitle);
            this.panelGrid.Controls.Add(this.lblRecentTitle);
            this.panelGrid.Controls.Add(this.panelClaimToolbar);
            this.panelGrid.Controls.Add(this.dgvItems);
            this.panelGrid.FillColor = System.Drawing.Color.White;
            this.panelGrid.Location = new System.Drawing.Point(24, 460);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Radius = 12;
            this.panelGrid.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelGrid.ShadowDepth = 0;
            this.panelGrid.ShadowShift = 0;
            this.panelGrid.Size = new System.Drawing.Size(1172, 316);
            this.panelGrid.TabIndex = 5;
            //
            // btnShowFoundItems
            //
            this.btnShowFoundItems.BorderRadius = 8;
            this.btnShowFoundItems.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnShowFoundItems.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowFoundItems.ForeColor = System.Drawing.Color.White;
            this.btnShowFoundItems.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnShowFoundItems.Location = new System.Drawing.Point(926, 20);
            this.btnShowFoundItems.Name = "btnShowFoundItems";
            this.btnShowFoundItems.Size = new System.Drawing.Size(112, 34);
            this.btnShowFoundItems.TabIndex = 5;
            this.btnShowFoundItems.Text = "Ditemukan";
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
            this.btnShowLostItems.Location = new System.Drawing.Point(1048, 20);
            this.btnShowLostItems.Name = "btnShowLostItems";
            this.btnShowLostItems.Size = new System.Drawing.Size(96, 34);
            this.btnShowLostItems.TabIndex = 6;
            this.btnShowLostItems.Text = "Hilang";
            //
            // lblRecentSubtitle
            //
            this.lblRecentSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblRecentSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRecentSubtitle.Location = new System.Drawing.Point(28, 43);
            this.lblRecentSubtitle.Name = "lblRecentSubtitle";
            this.lblRecentSubtitle.Size = new System.Drawing.Size(3, 2);
            this.lblRecentSubtitle.TabIndex = 2;
            this.lblRecentSubtitle.Text = null;
            this.lblRecentSubtitle.Visible = false;
            //
            // lblRecentTitle
            //
            this.lblRecentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(28, 18);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(3, 2);
            this.lblRecentTitle.TabIndex = 1;
            this.lblRecentTitle.Text = null;
            this.lblRecentTitle.Visible = false;
            //
            // panelClaimToolbar
            //
            this.panelClaimToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelClaimToolbar.BackColor = System.Drawing.Color.Transparent;
            this.panelClaimToolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.panelClaimToolbar.BorderRadius = 8;
            this.panelClaimToolbar.BorderThickness = 1;
            this.panelClaimToolbar.Controls.Add(this.lblStudentNim);
            this.panelClaimToolbar.Controls.Add(this.txtStudentNim);
            this.panelClaimToolbar.Controls.Add(this.lblStudentName);
            this.panelClaimToolbar.Controls.Add(this.txtStudentName);
            this.panelClaimToolbar.Controls.Add(this.picClaimPhoto);
            this.panelClaimToolbar.Controls.Add(this.lblClaimPhotoStatus);
            this.panelClaimToolbar.Controls.Add(this.btnUploadClaimPhoto);
            this.panelClaimToolbar.Controls.Add(this.btnUseCameraClaimPhoto);
            this.panelClaimToolbar.Controls.Add(this.btnSaveClaim);
            this.panelClaimToolbar.Controls.Add(this.lblClaimRequestHint);
            this.panelClaimToolbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelClaimToolbar.Location = new System.Drawing.Point(28, 64);
            this.panelClaimToolbar.Name = "panelClaimToolbar";
            this.panelClaimToolbar.Size = new System.Drawing.Size(1116, 78);
            this.panelClaimToolbar.TabIndex = 4;
            //
            // lblStudentNim
            //
            this.lblStudentNim.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentNim.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblStudentNim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblStudentNim.Location = new System.Drawing.Point(16, 13);
            this.lblStudentNim.Name = "lblStudentNim";
            this.lblStudentNim.Size = new System.Drawing.Size(24, 18);
            this.lblStudentNim.TabIndex = 0;
            this.lblStudentNim.Text = "NIM";
            //
            // txtStudentNim
            //
            this.txtStudentNim.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtStudentNim.BorderRadius = 8;
            this.txtStudentNim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStudentNim.DefaultText = "";
            this.txtStudentNim.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtStudentNim.Location = new System.Drawing.Point(58, 8);
            this.txtStudentNim.Name = "txtStudentNim";
            this.txtStudentNim.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtStudentNim.PlaceholderText = "NIM";
            this.txtStudentNim.SelectedText = "";
            this.txtStudentNim.Size = new System.Drawing.Size(150, 36);
            this.txtStudentNim.TabIndex = 1;
            //
            // lblStudentName
            //
            this.lblStudentName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblStudentName.Location = new System.Drawing.Point(226, 13);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(31, 18);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "Nama";
            //
            // txtStudentName
            //
            this.txtStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtStudentName.BorderRadius = 8;
            this.txtStudentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStudentName.DefaultText = "";
            this.txtStudentName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtStudentName.Location = new System.Drawing.Point(270, 8);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtStudentName.PlaceholderText = "Nama lengkap";
            this.txtStudentName.SelectedText = "";
            this.txtStudentName.Size = new System.Drawing.Size(346, 36);
            this.txtStudentName.TabIndex = 3;
            //
            // picClaimPhoto
            //
            this.picClaimPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClaimPhoto.BackColor = System.Drawing.Color.Transparent;
            this.picClaimPhoto.BorderRadius = 10;
            this.picClaimPhoto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.picClaimPhoto.ImageRotate = 0F;
            this.picClaimPhoto.Location = new System.Drawing.Point(726, 8);
            this.picClaimPhoto.Name = "picClaimPhoto";
            this.picClaimPhoto.Size = new System.Drawing.Size(62, 62);
            this.picClaimPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClaimPhoto.TabIndex = 4;
            this.picClaimPhoto.TabStop = false;
            //
            // lblClaimPhotoStatus
            //
            this.lblClaimPhotoStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClaimPhotoStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimPhotoStatus.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblClaimPhotoStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblClaimPhotoStatus.Location = new System.Drawing.Point(730, 31);
            this.lblClaimPhotoStatus.Name = "lblClaimPhotoStatus";
            this.lblClaimPhotoStatus.Size = new System.Drawing.Size(58, 20);
            this.lblClaimPhotoStatus.TabIndex = 5;
            this.lblClaimPhotoStatus.Text = "Foto";
            this.lblClaimPhotoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnUploadClaimPhoto
            //
            this.btnUploadClaimPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadClaimPhoto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnUploadClaimPhoto.BorderRadius = 8;
            this.btnUploadClaimPhoto.BorderThickness = 1;
            this.btnUploadClaimPhoto.FillColor = System.Drawing.Color.White;
            this.btnUploadClaimPhoto.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadClaimPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnUploadClaimPhoto.Location = new System.Drawing.Point(808, 8);
            this.btnUploadClaimPhoto.Name = "btnUploadClaimPhoto";
            this.btnUploadClaimPhoto.Size = new System.Drawing.Size(112, 34);
            this.btnUploadClaimPhoto.TabIndex = 6;
            this.btnUploadClaimPhoto.Text = "Upload Foto";
            //
            // btnUseCameraClaimPhoto
            //
            this.btnUseCameraClaimPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseCameraClaimPhoto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnUseCameraClaimPhoto.BorderRadius = 8;
            this.btnUseCameraClaimPhoto.BorderThickness = 1;
            this.btnUseCameraClaimPhoto.FillColor = System.Drawing.Color.White;
            this.btnUseCameraClaimPhoto.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnUseCameraClaimPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnUseCameraClaimPhoto.Location = new System.Drawing.Point(928, 8);
            this.btnUseCameraClaimPhoto.Name = "btnUseCameraClaimPhoto";
            this.btnUseCameraClaimPhoto.Size = new System.Drawing.Size(144, 34);
            this.btnUseCameraClaimPhoto.TabIndex = 7;
            this.btnUseCameraClaimPhoto.Text = "Pakai Foto";
            //
            // btnSaveClaim
            //
            this.btnSaveClaim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClaim.BorderRadius = 8;
            this.btnSaveClaim.Enabled = false;
            this.btnSaveClaim.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(177)))), ((int)(((byte)(191)))));
            this.btnSaveClaim.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveClaim.ForeColor = System.Drawing.Color.White;
            this.btnSaveClaim.Location = new System.Drawing.Point(808, 46);
            this.btnSaveClaim.Name = "btnSaveClaim";
            this.btnSaveClaim.Size = new System.Drawing.Size(264, 28);
            this.btnSaveClaim.TabIndex = 8;
            this.btnSaveClaim.Text = "Setujui Klaim";
            //
            // btnMarkLostReturned
            //
            this.btnMarkLostReturned.BorderRadius = 8;
            this.btnMarkLostReturned.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(139)))));
            this.btnMarkLostReturned.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarkLostReturned.ForeColor = System.Drawing.Color.White;
            this.btnMarkLostReturned.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnMarkLostReturned.Location = new System.Drawing.Point(16, 10);
            this.btnMarkLostReturned.Name = "btnMarkLostReturned";
            this.btnMarkLostReturned.Size = new System.Drawing.Size(160, 38);
            this.btnMarkLostReturned.TabIndex = 10;
            this.btnMarkLostReturned.Text = "Tandai Selesai";
            this.btnMarkLostReturned.Visible = false;
            //
            // lblClaimRequestHint
            //
            this.lblClaimRequestHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClaimRequestHint.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimRequestHint.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.7F);
            this.lblClaimRequestHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblClaimRequestHint.Location = new System.Drawing.Point(16, 52);
            this.lblClaimRequestHint.Name = "lblClaimRequestHint";
            this.lblClaimRequestHint.Size = new System.Drawing.Size(690, 20);
            this.lblClaimRequestHint.TabIndex = 9;
            this.lblClaimRequestHint.Text = "Isi NIM dan nama lengkap mahasiswa.";
            //
            // dgvItems
            //
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItems.ColumnHeadersHeight = 38;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvItems.Location = new System.Drawing.Point(28, 152);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 40;
            this.dgvItems.Size = new System.Drawing.Size(1116, 142);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(56)))), ((int)(((byte)(72)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.dgvItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvItems.ThemeStyle.ReadOnly = false;
            this.dgvItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.8F);
            this.dgvItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.dgvItems.ThemeStyle.RowsStyle.Height = 40;
            this.dgvItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            this.dgvItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            //
            // SecurityForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelTips);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panelUserBadge);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.Name = "SecurityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konsol Security - Lost and Found";
            this.panelUserBadge.ResumeLayout(false);
            this.panelStepReport.ResumeLayout(false);
            this.panelStepPhoto.ResumeLayout(false);
            this.panelStepMonitor.ResumeLayout(false);
            this.panelReport.ResumeLayout(false);
            this.panelReport.PerformLayout();
            this.panelTips.ResumeLayout(false);
            this.panelTips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            this.panelClaimToolbar.ResumeLayout(false);
            this.panelClaimToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClaimPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel panelUserBadge;
        private Guna.UI2.WinForms.Guna2Panel panelUserBadgeMarker;
        private System.Windows.Forms.Label lblUserBadge;
        private Guna.UI2.WinForms.Guna2Panel panelStepReport;
        private Guna.UI2.WinForms.Guna2Panel panelStepReportMarker;
        private System.Windows.Forms.Label lblStepReportNumber;
        private System.Windows.Forms.Label lblStepReportText;
        private Guna.UI2.WinForms.Guna2Panel panelStepPhoto;
        private Guna.UI2.WinForms.Guna2Panel panelStepPhotoMarker;
        private System.Windows.Forms.Label lblStepPhotoNumber;
        private System.Windows.Forms.Label lblStepPhotoText;
        private Guna.UI2.WinForms.Guna2Panel panelStepMonitor;
        private Guna.UI2.WinForms.Guna2Panel panelStepMonitorMarker;
        private System.Windows.Forms.Label lblStepMonitorNumber;
        private System.Windows.Forms.Label lblStepMonitorText;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelReport;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelTips;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelGrid;
        private Guna.UI2.WinForms.Guna2TextBox txtItemName;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtLocation;
        private Guna.UI2.WinForms.Guna2RadioButton rbFound;
        private Guna.UI2.WinForms.Guna2RadioButton rbLost;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItems;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblItemName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDesc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReportTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReportSubtitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPhotoTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPhotoSubtitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCamera;
        private Guna.UI2.WinForms.Guna2PictureBox picCamera;
        private Guna.UI2.WinForms.Guna2Button btnStartCamera;
        private Guna.UI2.WinForms.Guna2Button btnStopCamera;
        private Guna.UI2.WinForms.Guna2Button btnCapturePhoto;
        private Guna.UI2.WinForms.Guna2Button btnRetakePhoto;
        private System.Windows.Forms.Label lblCameraStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecentTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecentSubtitle;
    }
}
