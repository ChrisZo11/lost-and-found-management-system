using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    public partial class SecurityForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private enum SecurityGridMode
        {
            FoundItems,
            LostItems
        }

        private readonly IItem item;
        private readonly IClaim claim;
        private readonly IPhotoStorageService photoStorage;
        private readonly ICameraController cameraController;
        private readonly ClaimRequestValidator claimRequestValidator;
        private readonly ItemReportValidator itemReportValidator;
        private Bitmap capturedImage;
        private bool hasCapturedPhoto;
        private Guna2TextBox txtStudentNim;
        private Guna2TextBox txtStudentName;
        private Guna2Button btnUploadClaimPhoto;
        private Guna2Button btnUseCameraClaimPhoto;
        private Guna2Button btnSaveClaim;
        private Guna2HtmlLabel lblStudentNim;
        private Guna2HtmlLabel lblStudentName;
        private Guna2PictureBox picClaimPhoto;
        private Label lblClaimRequestHint;
        private Bitmap claimPhotoImage;
        private string selectedClaimPhotoSourcePath;
        private TableLayoutPanel contentLayout;
        private Guna2Panel panelClaimToolbar;
        private Label lblReportValidation;
        private Label lblCameraEmptyState;
        private Label lblClaimPhotoStatus;
        private Label lblItemsEmptyState;
        private Guna2Button btnShowFoundItems;
        private Guna2Button btnShowLostItems;
        private Guna2Button btnMarkLostReturned;
        private SecurityGridMode gridMode = SecurityGridMode.FoundItems;

        public SecurityForm()
            : this(
                new Item(),
                new Claim(),
                PhotoStorageService.CreateDefault(),
                new CameraController(),
                new ClaimRequestValidator(),
                new ItemReportValidator())
        {
        }

        public SecurityForm(
            IItem item,
            IClaim claim,
            IPhotoStorageService photoStorage,
            ICameraController cameraController,
            ClaimRequestValidator claimRequestValidator,
            ItemReportValidator itemReportValidator)
        {
            this.item = item ?? throw new ArgumentNullException(nameof(item));
            this.claim = claim ?? throw new ArgumentNullException(nameof(claim));
            this.photoStorage = photoStorage ?? throw new ArgumentNullException(nameof(photoStorage));
            this.cameraController = cameraController ?? throw new ArgumentNullException(nameof(cameraController));
            this.claimRequestValidator = claimRequestValidator ?? throw new ArgumentNullException(nameof(claimRequestValidator));
            this.itemReportValidator = itemReportValidator ?? throw new ArgumentNullException(nameof(itemReportValidator));

            InitializeComponent();

            ConfigureHeader();
            ConfigureCameraPanel();

            if (UiTheme.IsDesignMode(this))
            {
                return;
            }

            this.cameraController.FrameReady += cameraController_FrameReady;
            LoadCameraDevices();
            LoadRecentItems();
        }

        private void ConfigureHeader()
        {
            UiTheme.StyleForm(this, new Size(1180, 720), true);
            UiTheme.SetDoubleBuffered(this);
            Text = "Konsol Security - Lost and Found";
            Guna2HtmlLabel lblSubtitle = EnsureHeaderSubtitle();

            ConfigureWindowChrome();
            lblTitle.Text = "Dashboard Security";
            lblSubtitle.Text = "Catat laporan, ambil foto, dan proses klaim item aktif";
            UiTheme.StyleTitle(lblTitle, 20F);
            UiTheme.StyleSubtitle(lblSubtitle);
            lblTitle.Location = new Point(32, 66);
            lblSubtitle.Location = new Point(34, 103);
            lblSubtitle.AutoSize = false;
            lblSubtitle.Size = new Size(340, 20);
            lblTitle.ForeColor = UiTheme.Ink;
            lblSubtitle.ForeColor = UiTheme.Muted;

            btnLogout.Text = "Keluar";
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UiTheme.StyleSecondaryButton(btnLogout);
            btnLogout.Location = new Point(ClientSize.Width - 116, 72);
            ConfigureUserBadge(new Point(ClientSize.Width - 368, 72), new Size(232, 36));
            HideWorkflowChips();
        }

        private void ConfigureWindowChrome()
        {
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = true;
            MinimizeBox = true;
            panelWindowChrome.MouseDown += WindowChrome_MouseDown;
            lblWindowTitle.MouseDown += WindowChrome_MouseDown;
            panelWindowIcon.MouseDown += WindowChrome_MouseDown;
            panelWindowChrome.BringToFront();

            ConfigureChromeButton(btnWindowMinimize, "-");
            ConfigureChromeButton(btnWindowMaximize, "□");
            ConfigureChromeButton(btnWindowClose, "x");
            btnWindowClose.HoverState.FillColor = UiTheme.Danger;
            btnWindowClose.HoverState.ForeColor = Color.White;

            btnWindowMinimize.Click += btnWindowMinimize_Click;
            btnWindowMaximize.Click += btnWindowMaximize_Click;
            btnWindowClose.Click += btnWindowClose_Click;
            Resize += (sender, e) =>
            {
                UpdateMaximizeButtonText();
                LayoutSecurityPanels();
            };
            UpdateMaximizeButtonText();
        }

        private void ConfigureChromeButton(Guna2Button button, string text)
        {
            button.Text = text;
            button.FillColor = Color.Transparent;
            button.ForeColor = UiTheme.Muted;
            button.BorderRadius = 8;
            button.Font = new Font("Segoe UI Variable Text", 10F, FontStyle.Bold);
            button.HoverState.FillColor = Color.FromArgb(230, 238, 243);
            button.TextOffset = new Point(0, -1);
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

            btnWindowMaximize.Text = WindowState == FormWindowState.Maximized ? "❐" : "□";
        }

        private void ConfigurePanel(Guna2Panel panel, Point location, Size size, Color fillColor, int radius)
        {
            panel.BackColor = Color.Transparent;
            panel.BorderRadius = radius;
            panel.FillColor = fillColor;
            panel.Location = location;
            panel.Size = size;
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

        private void ConfigureCameraPanel()
        {
            panelReport.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelTips.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelReport.Location = new Point(24, 146);
            panelReport.Size = new Size(500, 320);
            panelTips.Location = new Point(546, 146);
            panelTips.Size = new Size(650, 320);
            panelGrid.Location = new Point(24, 490);
            panelGrid.Size = new Size(1172, 316);

            UiTheme.StyleCard(panelReport);
            UiTheme.StyleCard(panelTips);
            UiTheme.StyleCard(panelGrid);
            StyleSecurityCard(panelReport);
            StyleSecurityCard(panelTips);
            StyleSecurityCard(panelGrid);
            ConfigureAccentPanels();
            ConfigureSecurityLayout();

            lblReportTitle.Text = "Laporan Baru";
            lblReportSubtitle.Text = "Catat item hilang atau temuan";
            lblItemName.Text = "Nama Barang";
            lblLoc.Text = "Lokasi";
            lblDesc.Text = "Deskripsi";
            lblType.Text = "Tipe";
            rbFound.Text = "Ditemukan";
            rbLost.Text = "Hilang";
            btnSave.Text = "Simpan Laporan";
            lblPhotoTitle.Text = "Foto Item";
            lblPhotoSubtitle.Text = "Ambil foto dari kamera sebelum laporan disimpan";
            lblRecentTitle.Text = "Item Aktif";
            lblRecentSubtitle.Text = "Pilih item found, isi NIM/nama, lalu setujui klaim";

            UiTheme.StyleTitle(lblReportTitle, 14F);
            UiTheme.StyleSubtitle(lblReportSubtitle);
            UiTheme.StyleFieldLabel(lblItemName);
            UiTheme.StyleFieldLabel(lblLoc);
            UiTheme.StyleFieldLabel(lblDesc);
            UiTheme.StyleFieldLabel(lblType);
            UiTheme.StyleTextBox(txtItemName);
            UiTheme.StyleTextBox(txtDescription);
            UiTheme.StyleTextBox(txtLocation);
            UiTheme.StyleRadio(rbFound, UiTheme.Info);
            UiTheme.StyleRadio(rbLost, UiTheme.Danger);
            UiTheme.StylePrimaryButton(btnSave);
            UiTheme.StyleTitle(lblPhotoTitle, 14F);
            UiTheme.StyleSubtitle(lblPhotoSubtitle);
            UiTheme.StyleComboBox(cmbCamera);
            UiTheme.StyleMutedLabel(lblCameraStatus);
            UiTheme.StyleTitle(lblRecentTitle, 14F);
            UiTheme.StyleSubtitle(lblRecentSubtitle);
            UiTheme.StyleGrid(dgvItems);
            UiTheme.AttachStatusBadgeRenderer(dgvItems, "Type", "Status", "ActiveClaims");
            HidePanelHeaders();

            txtItemName.PlaceholderText = "Dompet, HP, dokumen...";
            txtLocation.PlaceholderText = "Lokasi ditemukan/hilang";
            txtDescription.PlaceholderText = "Ciri-ciri, warna, atau detail penting";
            txtDescription.TextOffset = new Point(4, 4);

            cmbCamera.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picCamera.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picCamera.BackColor = Color.Transparent;
            picCamera.FillColor = UiTheme.Ink;
            picCamera.Location = new Point(34, 122);
            picCamera.Size = new Size(356, 164);
            picCamera.SizeMode = PictureBoxSizeMode.Zoom;
            picCamera.BorderRadius = 8;
            lblCameraStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCameraStatus.Location = new Point(410, 226);
            btnStartCamera.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopCamera.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCapturePhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRetakePhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvItems.Location = new Point(28, 128);
            dgvItems.Size = new Size(panelGrid.Width - 56, panelGrid.Height - 154);
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.SelectionChanged -= dgvItems_SelectionChanged;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;

            EnsureReportValidationLabel();
            EnsureCameraEmptyState();
            EnsureItemsEmptyState();
            ConfigureClaimRequestPanel();
            ConfigureItemsModeButtons();
            ConfigureLostActionButton();
            ApplyGridModeText();
            LayoutSecurityPanels();
            Resize += (sender, e) => LayoutSecurityPanels();
            panelReport.Resize += (sender, e) => LayoutReportPanel();
            panelTips.Resize += (sender, e) => LayoutCameraPanel();
            panelGrid.Resize += (sender, e) => LayoutClaimToolbar();

            btnStartCamera.Text = "Mulai";
            btnStopCamera.Text = "Stop";
            btnCapturePhoto.Text = "Ambil";
            btnRetakePhoto.Text = "Ulangi";
            UiTheme.StylePrimaryButton(btnStartCamera);
            UiTheme.StylePrimaryButton(btnCapturePhoto);
            UiTheme.StylePrimaryButton(btnRetakePhoto);
            ConfigureStopButtonStyle();

            btnStartCamera.Click += btnStartCamera_Click;
            btnStopCamera.Enabled = false;
            btnStopCamera.Click += btnStopCamera_Click;
            btnCapturePhoto.Enabled = false;
            btnCapturePhoto.Click += btnCapturePhoto_Click;
            btnRetakePhoto.Enabled = false;
            btnRetakePhoto.Click += btnRetakePhoto_Click;
        }

        private void StyleSecurityCard(Guna2ShadowPanel panel)
        {
            panel.Radius = 16;
            panel.ShadowColor = Color.FromArgb(210, 222, 230);
            panel.ShadowDepth = 4;
            panel.ShadowShift = 2;
        }

        private void ConfigureAccentPanels()
        {
            ConfigurePanel(panelCanvasAccentTop, new Point(438, 96), new Size(122, 5), Color.FromArgb(210, 230, 229), 2);
            panelCanvasAccentTop.SendToBack();

            ConfigurePanel(panelReportAccent, new Point(28, 22), new Size(64, 4), UiTheme.Accent, 2);
            ConfigurePanel(panelReportRail, new Point(10, 54), new Size(3, 172), Color.FromArgb(230, 247, 244), 2);
            ConfigurePanel(panelItemDot, new Point(7, 74), new Size(9, 9), UiTheme.Accent, 4);
            ConfigurePanel(panelTypeDot, new Point(7, 230), new Size(9, 9), Color.FromArgb(63, 176, 165), 4);

            ConfigurePanel(panelPhotoAccent, new Point(34, 22), new Size(112, 4), Color.FromArgb(63, 176, 165), 2);
            ConfigurePanel(panelPhotoCornerTop, new Point(panelTips.Width - 112, panelTips.Height - 42), new Size(54, 4), Color.FromArgb(230, 247, 244), 2);
            ConfigurePanel(panelPhotoCornerSide, new Point(panelTips.Width - 58, panelTips.Height - 80), new Size(4, 42), Color.FromArgb(230, 247, 244), 2);
            panelPhotoCornerTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelPhotoCornerSide.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            ConfigurePanel(panelGridAccent, new Point(28, 24), new Size(96, 4), Color.FromArgb(235, 224, 207), 2);
            panelReportAccent.BringToFront();
            panelReportRail.BringToFront();
            panelItemDot.BringToFront();
            panelTypeDot.BringToFront();
            panelPhotoAccent.BringToFront();
            panelPhotoCornerTop.SendToBack();
            panelPhotoCornerSide.SendToBack();
            panelGridAccent.BringToFront();
        }

        private void ConfigureSecurityLayout()
        {
            if (contentLayout == null)
            {
                contentLayout = new TableLayoutPanel
                {
                    BackColor = Color.Transparent,
                    ColumnCount = 2,
                    RowCount = 2,
                    Name = "securityContentLayout",
                    Padding = new Padding(0)
                };
                contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
                contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
                contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 326F));
                contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                Controls.Add(contentLayout);
            }

            contentLayout.Controls.Clear();
            contentLayout.Controls.Add(panelReport, 0, 0);
            contentLayout.Controls.Add(panelTips, 1, 0);
            contentLayout.Controls.Add(panelGrid, 0, 1);
            contentLayout.SetColumnSpan(panelGrid, 2);

            panelReport.Dock = DockStyle.Fill;
            panelTips.Dock = DockStyle.Fill;
            panelGrid.Dock = DockStyle.Fill;
            panelReport.Margin = new Padding(0, 0, 10, 10);
            panelTips.Margin = new Padding(10, 0, 0, 10);
            panelGrid.Margin = new Padding(0);
        }

        private void LayoutSecurityPanels()
        {
            if (contentLayout == null)
            {
                return;
            }

            contentLayout.Location = new Point(24, 146);
            contentLayout.Size = new Size(Math.Max(1, ClientSize.Width - 48), Math.Max(1, ClientSize.Height - 170));
            contentLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCanvasAccentTop.Location = new Point(
                contentLayout.Left + Math.Max(360, contentLayout.Width / 3),
                Math.Max(58, contentLayout.Top - 50));
            LayoutReportPanel();
            LayoutCameraPanel();
            LayoutClaimToolbar();
        }

        private void HidePanelHeaders()
        {
            SetControlHidden(lblReportTitle);
            SetControlHidden(lblReportSubtitle);
            SetControlHidden(lblPhotoTitle);
            SetControlHidden(lblPhotoSubtitle);
            SetControlHidden(lblRecentTitle);
            SetControlHidden(lblRecentSubtitle);
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

        private void LayoutReportPanel()
        {
            if (panelReport == null || txtItemName == null || txtLocation == null || txtDescription == null)
            {
                return;
            }

            int width = Math.Max(1, panelReport.ClientSize.Width);
            int left = 28;
            int right = 28;
            int gap = 20;
            int fieldWidth = Math.Max(170, (width - left - right - gap) / 2);
            int locationX = left + fieldWidth + gap;
            int fullWidth = Math.Max(1, width - left - right);

            lblItemName.Location = new Point(left, 24);
            txtItemName.Location = new Point(left, 48);
            txtItemName.Size = new Size(fieldWidth, 42);
            lblLoc.Location = new Point(locationX, 24);
            txtLocation.Location = new Point(locationX, 48);
            txtLocation.Size = new Size(Math.Max(150, width - locationX - right), 42);

            lblDesc.Location = new Point(left, 104);
            txtDescription.Location = new Point(left, 128);
            txtDescription.Size = new Size(fullWidth, 66);

            lblType.Location = new Point(left, 210);
            rbFound.Location = new Point(left + 66, 207);
            rbLost.Location = new Point(left + 170, 207);
            btnSave.Location = new Point(left, 238);
            btnSave.Size = new Size(190, 42);

            if (lblReportValidation != null)
            {
                lblReportValidation.Location = new Point(btnSave.Right + 16, 243);
                lblReportValidation.Size = new Size(Math.Max(180, width - btnSave.Right - 44), 32);
            }
        }

        private void HideWorkflowChips()
        {
            if (panelStepReport != null)
            {
                panelStepReport.Visible = false;
            }

            if (panelStepPhoto != null)
            {
                panelStepPhoto.Visible = false;
            }

            if (panelStepMonitor != null)
            {
                panelStepMonitor.Visible = false;
            }
        }

        private void ConfigureHeaderChip(Guna2Panel panel, Point location)
        {
            if (panel == null)
            {
                return;
            }

            panel.BackColor = UiTheme.Canvas;
            panel.BorderColor = UiTheme.Border;
            panel.BorderRadius = 10;
            panel.BorderThickness = 1;
            panel.FillColor = UiTheme.Surface;
            panel.Location = location;
            panel.Size = new Size(108, 52);
            panel.BringToFront();
        }

        private void ConfigureUserBadge(Point location, Size size)
        {
            if (panelUserBadge == null)
            {
                AddUserBadge(location, size);
                return;
            }

            panelUserBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelUserBadge.BorderColor = UiTheme.Border;
            panelUserBadge.BorderRadius = 10;
            panelUserBadge.BorderThickness = 1;
            panelUserBadge.FillColor = UiTheme.Surface;
            panelUserBadge.Location = location;
            panelUserBadge.Size = size;

            if (lblUserBadge != null)
            {
                lblUserBadge.Text = GetHeaderIdentity();
            }

            panelUserBadge.BringToFront();
        }

        private void AddHeaderChip(string step, string caption, Color color, Point location)
        {
            var panel = new Guna2Panel
            {
                BackColor = UiTheme.Canvas,
                BorderColor = UiTheme.Border,
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = UiTheme.Surface,
                Location = location,
                Name = "panelStep" + step,
                Size = new Size(108, 52)
            };

            var marker = new Guna2Panel
            {
                BorderRadius = 4,
                FillColor = color,
                Location = new Point(12, 12),
                Size = new Size(8, 8)
            };

            var stepLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.MonoFont(8F, FontStyle.Bold),
                ForeColor = UiTheme.Ink,
                Location = new Point(27, 6),
                Size = new Size(68, 20),
                Text = step,
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
            panel.Controls.Add(stepLabel);
            panel.Controls.Add(captionLabel);
            Controls.Add(panel);
            panel.BringToFront();
        }

        private void AddPanelAccent(Guna2ShadowPanel panel, Color color)
        {
            foreach (Control child in panel.Controls)
            {
                if (child.Name.EndsWith("Accent", StringComparison.Ordinal))
                {
                    child.BackColor = Color.Transparent;
                    child.Location = new Point(18, 23);
                    child.Size = new Size(6, 34);
                    child.BringToFront();
                    return;
                }
            }

            var accent = new Guna2Panel
            {
                BackColor = Color.Transparent,
                BorderRadius = 4,
                FillColor = color,
                Location = new Point(18, 23),
                Name = panel.Name + "Accent",
                Size = new Size(6, 34)
            };

            panel.Controls.Add(accent);
            accent.BringToFront();
        }

        private void ConfigureStopButtonStyle()
        {
            UiTheme.StyleDangerButton(btnStopCamera);
        }

        private void EnsureReportValidationLabel()
        {
            if (lblReportValidation == null)
            {
                lblReportValidation = new Label
                {
                    Name = "lblReportValidation"
                };
                UiTheme.StyleInlineValidationLabel(lblReportValidation);
                panelReport.Controls.Add(lblReportValidation);
            }

            LayoutReportPanel();
            lblReportValidation.BringToFront();

            txtItemName.TextChanged -= ReportInput_TextChanged;
            txtLocation.TextChanged -= ReportInput_TextChanged;
            txtDescription.TextChanged -= ReportInput_TextChanged;
            txtItemName.TextChanged += ReportInput_TextChanged;
            txtLocation.TextChanged += ReportInput_TextChanged;
            txtDescription.TextChanged += ReportInput_TextChanged;
        }

        private void ReportInput_TextChanged(object sender, EventArgs e)
        {
            if (lblReportValidation != null && lblReportValidation.Visible)
            {
                ClearReportValidation();
            }
        }

        private void ShowReportValidation(string message)
        {
            EnsureReportValidationLabel();
            lblReportValidation.Text = message;
            lblReportValidation.Visible = true;
            lblReportValidation.BringToFront();
        }

        private void ClearReportValidation()
        {
            if (lblReportValidation != null)
            {
                lblReportValidation.Text = string.Empty;
                lblReportValidation.Visible = false;
            }

            UiTheme.SetInputError(txtItemName, false);
            UiTheme.SetInputError(txtLocation, false);
            UiTheme.SetInputError(txtDescription, false);
        }

        private void EnsureCameraEmptyState()
        {
            if (lblCameraEmptyState == null)
            {
                lblCameraEmptyState = new Label
                {
                    AutoEllipsis = true,
                    BackColor = UiTheme.Ink,
                    Font = UiTheme.Font(9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(197, 212, 222),
                    Name = "lblCameraEmptyState",
                    Text = "Belum ada preview kamera\r\nPilih kamera lalu tekan Mulai",
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelTips.Controls.Add(lblCameraEmptyState);
            }

            lblCameraEmptyState.BringToFront();
            lblCameraEmptyState.Visible = picCamera.Image == null;
        }

        private void EnsureItemsEmptyState()
        {
            if (lblItemsEmptyState == null)
            {
                lblItemsEmptyState = new Label
                {
                    AutoEllipsis = true,
                    BackColor = UiTheme.Surface,
                    Font = UiTheme.Font(10F, FontStyle.Bold),
                    ForeColor = UiTheme.Muted,
                    Name = "lblItemsEmptyState",
                    Text = "Belum ada item aktif untuk diklaim.",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = false
                };
                panelGrid.Controls.Add(lblItemsEmptyState);
            }
        }

        private void ConfigureItemsModeButtons()
        {
            if (btnShowFoundItems == null)
            {
                btnShowFoundItems = new Guna2Button
                {
                    Name = "btnShowFoundItems",
                    Text = "Ditemukan"
                };
                panelGrid.Controls.Add(btnShowFoundItems);
            }

            if (btnShowLostItems == null)
            {
                btnShowLostItems = new Guna2Button
                {
                    Name = "btnShowLostItems",
                    Text = "Hilang"
                };
                panelGrid.Controls.Add(btnShowLostItems);
            }

            btnShowFoundItems.Size = new Size(112, 34);
            btnShowLostItems.Size = new Size(96, 34);
            btnShowFoundItems.Click -= btnShowFoundItems_Click;
            btnShowFoundItems.Click += btnShowFoundItems_Click;
            btnShowLostItems.Click -= btnShowLostItems_Click;
            btnShowLostItems.Click += btnShowLostItems_Click;
            StyleItemsModeButtons();
        }

        private void ConfigureLostActionButton()
        {
            EnsureClaimToolbar();

            if (btnMarkLostReturned == null)
            {
                btnMarkLostReturned = new Guna2Button
                {
                    Name = "btnMarkLostReturned",
                    Text = "Tandai Selesai"
                };
            }

            if (btnMarkLostReturned.Parent == null)
            {
                panelClaimToolbar.Controls.Add(btnMarkLostReturned);
            }

            UiTheme.StylePrimaryButton(btnMarkLostReturned);
            btnMarkLostReturned.Click -= btnMarkLostReturned_Click;
            btnMarkLostReturned.Click += btnMarkLostReturned_Click;
        }

        private void LayoutCameraPanel()
        {
            if (panelTips == null || picCamera == null)
            {
                return;
            }

            int panelWidth = Math.Max(1, panelTips.ClientSize.Width);
            int panelHeight = Math.Max(1, panelTips.ClientSize.Height);
            int sideWidth = 188;
            int previewWidth = Math.Max(260, panelWidth - sideWidth - 72);
            int previewHeight = Math.Max(126, panelHeight - 96);

            cmbCamera.Location = new Point(34, 28);
            cmbCamera.Size = new Size(previewWidth, 36);
            picCamera.Location = new Point(34, 72);
            picCamera.Size = new Size(previewWidth, previewHeight);

            int sideX = picCamera.Right + 20;
            btnStartCamera.Location = new Point(sideX, 28);
            btnStopCamera.Location = new Point(sideX + 102, 28);
            btnCapturePhoto.Location = new Point(sideX, 72);
            btnRetakePhoto.Location = new Point(sideX, 120);
            btnStartCamera.Size = new Size(92, 36);
            btnStopCamera.Size = new Size(92, 36);
            btnCapturePhoto.Size = new Size(112, 38);
            btnRetakePhoto.Size = new Size(112, 38);
            lblCameraStatus.Location = new Point(sideX, Math.Min(picCamera.Bottom - 58, 168));
            lblCameraStatus.Size = new Size(Math.Max(150, panelWidth - sideX - 24), 58);

            if (lblCameraEmptyState != null)
            {
                lblCameraEmptyState.Location = new Point(picCamera.Left + 1, picCamera.Top + 1);
                lblCameraEmptyState.Size = new Size(Math.Max(1, picCamera.Width - 2), Math.Max(1, picCamera.Height - 2));
                lblCameraEmptyState.Visible = picCamera.Image == null;
                lblCameraEmptyState.BringToFront();
            }
        }

        private void EnsureClaimToolbar()
        {
            if (panelClaimToolbar == null)
            {
                panelClaimToolbar = new Guna2Panel
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    BackColor = Color.Transparent,
                    Name = "panelClaimToolbar"
                };
                panelGrid.Controls.Add(panelClaimToolbar);
            }

            panelClaimToolbar.BackColor = Color.Transparent;
            panelClaimToolbar.BorderColor = UiTheme.Border;
            panelClaimToolbar.BorderRadius = 8;
            panelClaimToolbar.BorderThickness = 1;
            panelClaimToolbar.FillColor = Color.FromArgb(249, 252, 252);
            panelClaimToolbar.BringToFront();
        }

        private void EnsureClaimPhotoStatusLabel()
        {
            if (lblClaimPhotoStatus == null)
            {
                lblClaimPhotoStatus = new Label
                {
                    AutoEllipsis = true,
                    BackColor = Color.Transparent,
                    Font = UiTheme.Font(7.5F, FontStyle.Bold),
                    ForeColor = UiTheme.Muted,
                    Name = "lblClaimPhotoStatus",
                    Text = "Foto",
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelClaimToolbar.Controls.Add(lblClaimPhotoStatus);
            }

            lblClaimPhotoStatus.BringToFront();
        }

        private void LayoutClaimToolbar()
        {
            if (panelGrid == null || panelClaimToolbar == null)
            {
                return;
            }

            int gridWidth = Math.Max(1, panelGrid.ClientSize.Width);
            int right = Math.Max(240, gridWidth - 28);

            if (btnShowLostItems != null)
            {
                btnShowLostItems.Location = new Point(right - btnShowLostItems.Width, 20);
                btnShowLostItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnShowLostItems.BringToFront();
            }

            if (btnShowFoundItems != null)
            {
                int lostButtonLeft = btnShowLostItems == null ? right : btnShowLostItems.Left;
                btnShowFoundItems.Location = new Point(lostButtonLeft - btnShowFoundItems.Width - 10, 20);
                btnShowFoundItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnShowFoundItems.BringToFront();
            }

            bool isLostMode = gridMode == SecurityGridMode.LostItems;
            int toolbarHeight = isLostMode ? 58 : 78;
            panelClaimToolbar.Location = new Point(28, 64);
            panelClaimToolbar.Size = new Size(Math.Max(1, gridWidth - 56), toolbarHeight);

            int width = panelClaimToolbar.ClientSize.Width;

            if (isLostMode)
            {
                SetClaimControlsVisible(false);

                if (btnMarkLostReturned != null)
                {
                    btnMarkLostReturned.Visible = true;
                    btnMarkLostReturned.Location = new Point(16, 10);
                    btnMarkLostReturned.Size = new Size(160, 38);
                    btnMarkLostReturned.Enabled = dgvItems != null && dgvItems.SelectedRows.Count > 0;
                }

                if (lblClaimRequestHint != null)
                {
                    lblClaimRequestHint.Visible = true;
                    lblClaimRequestHint.Location = new Point(194, 19);
                    lblClaimRequestHint.Size = new Size(Math.Max(260, width - 216), 22);
                }
            }
            else
            {
                SetClaimControlsVisible(true);

                if (btnMarkLostReturned != null)
                {
                    btnMarkLostReturned.Visible = false;
                }

                int rightSectionWidth = 360;
                int photoX = Math.Max(650, width - rightSectionWidth);
                int buttonX = photoX + 82;
                int nameX = 270;
                int nameWidth = Math.Max(170, photoX - nameX - 28);

                lblStudentNim.Location = new Point(16, 13);
                lblStudentNim.Size = new Size(42, 18);
                txtStudentNim.Location = new Point(58, 8);
                txtStudentNim.Size = new Size(150, 36);
                lblStudentName.Location = new Point(226, 13);
                lblStudentName.Size = new Size(48, 18);
                txtStudentName.Location = new Point(nameX, 8);
                txtStudentName.Size = new Size(nameWidth, 36);

                picClaimPhoto.Location = new Point(photoX, 8);
                picClaimPhoto.Size = new Size(62, 62);
                btnUploadClaimPhoto.Location = new Point(buttonX, 8);
                btnUploadClaimPhoto.Size = new Size(112, 34);
                btnUseCameraClaimPhoto.Text = "Pakai Foto";
                btnUseCameraClaimPhoto.Location = new Point(buttonX + 120, 8);
                btnUseCameraClaimPhoto.Size = new Size(144, 34);
                btnSaveClaim.Location = new Point(buttonX, 46);
                btnSaveClaim.Size = new Size(264, 28);
                lblClaimRequestHint.Location = new Point(16, 52);
                lblClaimRequestHint.Size = new Size(Math.Max(260, photoX - 40), 20);

                if (lblClaimPhotoStatus != null)
                {
                    lblClaimPhotoStatus.Location = new Point(photoX + 4, 31);
                    lblClaimPhotoStatus.Size = new Size(58, 20);
                    lblClaimPhotoStatus.Visible = picClaimPhoto.Image == null;
                }
            }

            int gridTop = panelClaimToolbar.Bottom + 10;
            dgvItems.Location = new Point(28, gridTop);
            dgvItems.Size = new Size(Math.Max(1, gridWidth - 56), Math.Max(80, panelGrid.ClientSize.Height - gridTop - 22));

            if (lblItemsEmptyState != null)
            {
                lblItemsEmptyState.Location = dgvItems.Location;
                lblItemsEmptyState.Size = dgvItems.Size;
                if (lblItemsEmptyState.Visible)
                {
                    lblItemsEmptyState.BringToFront();
                }
            }
        }

        private void SetClaimControlsVisible(bool visible)
        {
            if (lblStudentNim != null)
            {
                lblStudentNim.Visible = visible;
            }

            if (txtStudentNim != null)
            {
                txtStudentNim.Visible = visible;
            }

            if (lblStudentName != null)
            {
                lblStudentName.Visible = visible;
            }

            if (txtStudentName != null)
            {
                txtStudentName.Visible = visible;
            }

            if (picClaimPhoto != null)
            {
                picClaimPhoto.Visible = visible;
            }

            if (btnUploadClaimPhoto != null)
            {
                btnUploadClaimPhoto.Visible = visible;
            }

            if (btnUseCameraClaimPhoto != null)
            {
                btnUseCameraClaimPhoto.Visible = visible;
            }

            if (btnSaveClaim != null)
            {
                btnSaveClaim.Visible = visible;
            }

            if (lblClaimPhotoStatus != null)
            {
                lblClaimPhotoStatus.Visible = visible && picClaimPhoto != null && picClaimPhoto.Image == null;
            }
        }

        private void ConfigureClaimRequestPanel()
        {
            EnsureClaimToolbar();

            if (lblStudentNim == null)
            {
                lblStudentNim = new Guna2HtmlLabel
                {
                    BackColor = Color.Transparent,
                    Text = "NIM"
                };
            }

            if (txtStudentNim == null)
            {
                txtStudentNim = new Guna2TextBox
                {
                    Name = "txtStudentNim",
                    PlaceholderText = "NIM"
                };
            }

            if (lblStudentName == null)
            {
                lblStudentName = new Guna2HtmlLabel
                {
                    BackColor = Color.Transparent,
                    Text = "Nama"
                };
            }

            if (txtStudentName == null)
            {
                txtStudentName = new Guna2TextBox
                {
                    Name = "txtStudentName",
                    PlaceholderText = "Nama lengkap"
                };
            }

            if (picClaimPhoto == null)
            {
                picClaimPhoto = new Guna2PictureBox
                {
                    Name = "picClaimPhoto",
                    SizeMode = PictureBoxSizeMode.Zoom
                };
            }

            if (btnUploadClaimPhoto == null)
            {
                btnUploadClaimPhoto = new Guna2Button
                {
                    Name = "btnUploadClaimPhoto",
                    Text = "Upload Foto"
                };
            }

            if (btnUseCameraClaimPhoto == null)
            {
                btnUseCameraClaimPhoto = new Guna2Button
                {
                    Name = "btnUseCameraClaimPhoto",
                    Text = "Pakai Foto"
                };
            }

            if (btnSaveClaim == null)
            {
                btnSaveClaim = new Guna2Button
                {
                    Name = "btnSaveClaim",
                    Text = "Setujui Klaim"
                };
            }

            if (lblClaimRequestHint == null)
            {
                lblClaimRequestHint = new Label
                {
                    AutoEllipsis = true,
                    BackColor = Color.Transparent,
                    Text = "Pilih item found yang akan diklaim."
                };
            }

            UiTheme.StyleFieldLabel(lblStudentNim);
            UiTheme.StyleTextBox(txtStudentNim);
            UiTheme.StyleFieldLabel(lblStudentName);
            UiTheme.StyleTextBox(txtStudentName);
            UiTheme.StyleSecondaryButton(btnUploadClaimPhoto);
            UiTheme.StyleSecondaryButton(btnUseCameraClaimPhoto);
            UiTheme.StylePrimaryButton(btnSaveClaim);
            btnSaveClaim.Text = "Setujui Klaim";
            UiTheme.StyleMutedLabel(lblClaimRequestHint);

            lblStudentNim.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtStudentNim.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblStudentName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtStudentName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picClaimPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUploadClaimPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUseCameraClaimPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClaim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClaimRequestHint.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            picClaimPhoto.BorderRadius = 8;
            picClaimPhoto.FillColor = UiTheme.SurfaceSoft;

            if (lblStudentNim.Parent == null)
            {
                panelClaimToolbar.Controls.Add(lblStudentNim);
            }

            if (txtStudentNim.Parent == null)
            {
                panelClaimToolbar.Controls.Add(txtStudentNim);
            }

            if (lblStudentName.Parent == null)
            {
                panelClaimToolbar.Controls.Add(lblStudentName);
            }

            if (txtStudentName.Parent == null)
            {
                panelClaimToolbar.Controls.Add(txtStudentName);
            }

            if (picClaimPhoto.Parent == null)
            {
                panelClaimToolbar.Controls.Add(picClaimPhoto);
            }

            if (btnUploadClaimPhoto.Parent == null)
            {
                panelClaimToolbar.Controls.Add(btnUploadClaimPhoto);
            }

            if (btnUseCameraClaimPhoto.Parent == null)
            {
                panelClaimToolbar.Controls.Add(btnUseCameraClaimPhoto);
            }

            if (btnSaveClaim.Parent == null)
            {
                panelClaimToolbar.Controls.Add(btnSaveClaim);
            }

            if (lblClaimRequestHint.Parent == null)
            {
                panelClaimToolbar.Controls.Add(lblClaimRequestHint);
            }

            EnsureClaimPhotoStatusLabel();
            LayoutClaimToolbar();

            txtStudentNim.TextChanged -= ClaimInput_TextChanged;
            txtStudentNim.TextChanged += ClaimInput_TextChanged;
            txtStudentName.TextChanged -= ClaimInput_TextChanged;
            txtStudentName.TextChanged += ClaimInput_TextChanged;
            btnUploadClaimPhoto.Click -= btnUploadClaimPhoto_Click;
            btnUploadClaimPhoto.Click += btnUploadClaimPhoto_Click;
            btnUseCameraClaimPhoto.Click -= btnUseCameraClaimPhoto_Click;
            btnUseCameraClaimPhoto.Click += btnUseCameraClaimPhoto_Click;
            btnSaveClaim.Click -= btnSaveClaim_Click;
            btnSaveClaim.Click += btnSaveClaim_Click;
            UpdateClaimRequestHint();
        }

        private void StyleItemsModeButtons()
        {
            StyleItemsModeButton(btnShowFoundItems, gridMode == SecurityGridMode.FoundItems);
            StyleItemsModeButton(btnShowLostItems, gridMode == SecurityGridMode.LostItems);
        }

        private void StyleItemsModeButton(Guna2Button button, bool active)
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

        private void btnShowFoundItems_Click(object sender, EventArgs e)
        {
            SetGridMode(SecurityGridMode.FoundItems);
        }

        private void btnShowLostItems_Click(object sender, EventArgs e)
        {
            SetGridMode(SecurityGridMode.LostItems);
        }

        private void SetGridMode(SecurityGridMode mode)
        {
            if (gridMode == mode)
            {
                return;
            }

            gridMode = mode;
            ApplyGridModeText();
            StyleItemsModeButtons();
            LayoutClaimToolbar();
            LoadRecentItems();
        }

        private void ApplyGridModeText()
        {
            if (gridMode == SecurityGridMode.LostItems)
            {
                lblRecentTitle.Text = "Laporan Hilang";
                lblRecentSubtitle.Text = "Pantau laporan hilang dan tandai selesai saat barang kembali";
                UpdateClaimRequestHint();
                return;
            }

            lblRecentTitle.Text = "Item Aktif";
            lblRecentSubtitle.Text = "Pilih item found, isi NIM/nama, lalu setujui klaim";
            UpdateClaimRequestHint();
        }

        private void LoadCameraDevices()
        {
            try
            {
                IList<string> cameraNames = cameraController.LoadDeviceNames();
                cmbCamera.Items.Clear();

                foreach (string cameraName in cameraNames)
                {
                    cmbCamera.Items.Add(cameraName);
                }

                if (cmbCamera.Items.Count > 0)
                {
                    cmbCamera.SelectedIndex = 0;
                    lblCameraStatus.Text = "Pilih kamera, lalu mulai preview.";
                }
                else
                {
                    lblCameraStatus.Text = "Perangkat kamera tidak ditemukan.";
                    btnStartCamera.Enabled = false;
                    btnStopCamera.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblCameraStatus.Text = "Tidak dapat membaca perangkat kamera.";
                btnStartCamera.Enabled = false;
                btnStopCamera.Enabled = false;
                UiTheme.ShowError(this, "Gagal memuat perangkat kamera: " + ex.Message);
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            StartSelectedCamera();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            StopCamera();
            DisposeCapturedImage();
            hasCapturedPhoto = false;
            ClearCameraPreview();
            lblCameraStatus.Text = "Kamera dihentikan.";
            btnStartCamera.Enabled = cameraController.HasDevices;
            btnStopCamera.Enabled = false;
            btnCapturePhoto.Enabled = false;
            btnRetakePhoto.Enabled = false;
            cmbCamera.Enabled = true;
        }

        private void btnCapturePhoto_Click(object sender, EventArgs e)
        {
            if (picCamera.Image == null)
            {
                UiTheme.ShowWarning(this, "Mulai kamera sebelum mengambil foto.");
                return;
            }

            DisposeCapturedImage();
            capturedImage = new Bitmap(picCamera.Image);
            hasCapturedPhoto = true;
            StopCamera();
            lblCameraStatus.Text = "Foto tersimpan sementara. Simpan laporan atau ulangi.";
            btnStartCamera.Enabled = true;
            btnStopCamera.Enabled = false;
            btnCapturePhoto.Enabled = false;
            btnRetakePhoto.Enabled = true;
            cmbCamera.Enabled = true;
        }

        private void btnRetakePhoto_Click(object sender, EventArgs e)
        {
            DisposeCapturedImage();
            hasCapturedPhoto = false;
            ClearCameraPreview();
            StartSelectedCamera();
        }

        private void StartSelectedCamera()
        {
            if (!cameraController.HasDevices)
            {
                UiTheme.ShowWarning(this, "Perangkat kamera tidak ditemukan.");
                return;
            }

            if (cmbCamera.SelectedIndex < 0)
            {
                UiTheme.ShowWarning(this, "Pilih kamera terlebih dahulu.");
                return;
            }

            StopCamera();
            DisposeCapturedImage();
            hasCapturedPhoto = false;

            cameraController.Start(cmbCamera.SelectedIndex);

            lblCameraStatus.Text = "Preview kamera sedang berjalan.";
            btnStartCamera.Enabled = false;
            btnStopCamera.Enabled = true;
            btnCapturePhoto.Enabled = true;
            btnRetakePhoto.Enabled = false;
            cmbCamera.Enabled = false;
        }

        private void cameraController_FrameReady(object sender, CameraFrameEventArgs eventArgs)
        {
            if (hasCapturedPhoto || picCamera == null || picCamera.IsDisposed)
            {
                eventArgs.Frame.Dispose();
                return;
            }

            Bitmap frame = eventArgs.Frame;

            try
            {
                picCamera.BeginInvoke(new Action(() => SetCameraPreview(frame)));
            }
            catch
            {
                frame.Dispose();
            }
        }

        private void SetCameraPreview(Bitmap frame)
        {
            if (hasCapturedPhoto || picCamera.IsDisposed)
            {
                frame.Dispose();
                return;
            }

            Image oldImage = picCamera.Image;
            picCamera.Image = frame;
            oldImage?.Dispose();

            if (lblCameraEmptyState != null)
            {
                lblCameraEmptyState.Visible = false;
            }
        }

        private void ResetCameraCapture()
        {
            StopCamera();
            DisposeCapturedImage();
            hasCapturedPhoto = false;
            ClearCameraPreview();
            lblCameraStatus.Text = cmbCamera.Items.Count > 0
                ? "Pilih kamera, lalu mulai preview."
                : "Perangkat kamera tidak ditemukan.";
            btnStartCamera.Enabled = cmbCamera.Items.Count > 0;
            btnStopCamera.Enabled = false;
            btnCapturePhoto.Enabled = false;
            btnRetakePhoto.Enabled = false;
            cmbCamera.Enabled = true;
        }

        private void ClearCameraPreview()
        {
            if (picCamera == null)
            {
                return;
            }

            Image oldImage = picCamera.Image;
            picCamera.Image = null;
            oldImage?.Dispose();

            if (lblCameraEmptyState != null)
            {
                lblCameraEmptyState.Visible = true;
                lblCameraEmptyState.BringToFront();
            }
        }

        private void StopCamera()
        {
            cameraController.Stop();
        }

        private void DisposeCapturedImage()
        {
            capturedImage?.Dispose();
            capturedImage = null;
        }

        private void AddUserBadge(Point location, Size size)
        {
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

        private string GetHeaderIdentity()
        {
            string role = string.IsNullOrWhiteSpace(UserSession.Role) ? DomainValues.Roles.Security : UserSession.Role;
            string username = string.IsNullOrWhiteSpace(UserSession.Username) ? "User" : UserSession.Username;
            return role + " / " + username;
        }

        private void LoadRecentItems()
        {
            try
            {
                DataTable dt = gridMode == SecurityGridMode.LostItems
                    ? item.GetActiveLostItems()
                    : item.GetActiveFoundItems();
                dgvItems.DataSource = dt;
                ConfigureItemsGridColumns();
                UpdateItemsEmptyState(dt.Rows.Count == 0);
                UpdateClaimRequestHint();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal memuat item: " + ex.Message);
            }
        }

        private void ConfigureItemsGridColumns()
        {
            if (dgvItems.Columns.Count == 0)
            {
                return;
            }

            if (dgvItems.Columns.Contains("ItemID"))
            {
                dgvItems.Columns["ItemID"].HeaderText = "ID";
            }

            if (dgvItems.Columns.Contains("ItemName"))
            {
                dgvItems.Columns["ItemName"].HeaderText = "Item";
            }

            if (dgvItems.Columns.Contains("DateReported"))
            {
                dgvItems.Columns["DateReported"].HeaderText = "Tanggal";
                dgvItems.Columns["DateReported"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvItems.Columns.Contains("ActiveClaims"))
            {
                dgvItems.Columns["ActiveClaims"].HeaderText = "Klaim Aktif";
            }

            if (dgvItems.Columns.Contains("ImagePath"))
            {
                dgvItems.Columns["ImagePath"].Visible = false;
            }

            if (dgvItems.Columns.Contains("ItemID"))
            {
                dgvItems.Columns["ItemID"].FillWeight = 42;
            }

            if (dgvItems.Columns.Contains("ItemName"))
            {
                dgvItems.Columns["ItemName"].FillWeight = 150;
            }

            if (dgvItems.Columns.Contains("Type"))
            {
                dgvItems.Columns["Type"].FillWeight = 92;
            }

            if (dgvItems.Columns.Contains("Status"))
            {
                dgvItems.Columns["Status"].FillWeight = 96;
            }

            if (dgvItems.Columns.Contains("ActiveClaims"))
            {
                dgvItems.Columns["ActiveClaims"].FillWeight = 96;
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateClaimRequestHint();
        }

        private void ClaimInput_TextChanged(object sender, EventArgs e)
        {
            UpdateClaimRequestHint();
        }

        private void UpdateClaimRequestHint()
        {
            if (lblClaimRequestHint == null || btnSaveClaim == null)
            {
                return;
            }

            if (gridMode == SecurityGridMode.LostItems)
            {
                bool hasSelection = dgvItems != null && dgvItems.SelectedRows.Count > 0;
                lblClaimRequestHint.Text = hasSelection
                    ? "Klik Tandai Selesai jika barang sudah ditemukan atau dikembalikan."
                    : "Pilih laporan hilang yang akan ditandai selesai.";
                lblClaimRequestHint.ForeColor = hasSelection ? UiTheme.Success : UiTheme.Muted;
                btnSaveClaim.Enabled = false;

                if (btnMarkLostReturned != null)
                {
                    btnMarkLostReturned.Enabled = hasSelection;
                }

                return;
            }

            ClaimRequestValidationResult result = ValidateCurrentClaimRequest();
            lblClaimRequestHint.Text = result.Message;
            lblClaimRequestHint.ForeColor = GetClaimHintColor(result.State);
            btnSaveClaim.Enabled = result.CanSubmit;
        }

        private ClaimRequestValidationResult ValidateCurrentClaimRequest()
        {
            return claimRequestValidator.Validate(
                dgvItems.SelectedRows.Count > 0,
                GetSelectedActiveClaimCount(),
                txtStudentNim == null ? string.Empty : txtStudentNim.Text,
                txtStudentName == null ? string.Empty : txtStudentName.Text,
                HasClaimPhoto());
        }

        private Color GetClaimHintColor(ClaimRequestState state)
        {
            switch (state)
            {
                case ClaimRequestState.Ready:
                    return UiTheme.Success;
                case ClaimRequestState.ActiveClaimExists:
                    return UiTheme.Warning;
                case ClaimRequestState.MissingStudent:
                case ClaimRequestState.MissingPhoto:
                    return UiTheme.Danger;
                default:
                    return UiTheme.Muted;
            }
        }

        private void UpdateItemsEmptyState(bool isEmpty)
        {
            if (lblItemsEmptyState == null)
            {
                return;
            }

            lblItemsEmptyState.Visible = isEmpty;
            lblItemsEmptyState.Text = gridMode == SecurityGridMode.LostItems
                ? "Belum ada laporan hilang aktif."
                : "Belum ada item aktif untuk diklaim.";
            if (isEmpty)
            {
                lblItemsEmptyState.BringToFront();
            }
        }

        private int GetSelectedActiveClaimCount()
        {
            if (dgvItems.SelectedRows.Count == 0 || !dgvItems.Columns.Contains("ActiveClaims"))
            {
                return 0;
            }

            object value = dgvItems.SelectedRows[0].Cells["ActiveClaims"].Value;
            return value == DBNull.Value || value == null ? 0 : Convert.ToInt32(value);
        }

        private bool HasClaimPhoto()
        {
            return claimPhotoImage != null || !string.IsNullOrWhiteSpace(selectedClaimPhotoSourcePath);
        }

        private void btnUploadClaimPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                dialog.Title = "Pilih foto verifikasi klaim";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (Image image = Image.FromFile(dialog.FileName))
                    {
                        SetClaimPhotoPreview(new Bitmap(image));
                    }

                    claimPhotoImage?.Dispose();
                    claimPhotoImage = null;
                    selectedClaimPhotoSourcePath = dialog.FileName;
                    UpdateClaimRequestHint();
                }
                catch (Exception ex)
                {
                    UiTheme.ShowError(this, "Foto klaim tidak dapat dibuka: " + ex.Message);
                }
            }
        }

        private void btnUseCameraClaimPhoto_Click(object sender, EventArgs e)
        {
            if (capturedImage == null)
            {
                UiTheme.ShowWarning(this, "Ambil foto kamera terlebih dahulu.");
                return;
            }

            claimPhotoImage?.Dispose();
            claimPhotoImage = new Bitmap(capturedImage);
            selectedClaimPhotoSourcePath = null;
            SetClaimPhotoPreview(new Bitmap(claimPhotoImage));
            UpdateClaimRequestHint();
        }

        private void SetClaimPhotoPreview(Image image)
        {
            if (picClaimPhoto == null)
            {
                image.Dispose();
                return;
            }

            Image oldImage = picClaimPhoto.Image;
            picClaimPhoto.Image = image;
            oldImage?.Dispose();

            if (lblClaimPhotoStatus != null)
            {
                lblClaimPhotoStatus.Visible = false;
            }
        }

        private void ClearClaimPhoto()
        {
            selectedClaimPhotoSourcePath = null;
            claimPhotoImage?.Dispose();
            claimPhotoImage = null;

            if (picClaimPhoto != null)
            {
                Image oldImage = picClaimPhoto.Image;
                picClaimPhoto.Image = null;
                oldImage?.Dispose();
            }

            if (lblClaimPhotoStatus != null)
            {
                lblClaimPhotoStatus.Visible = true;
            }
        }

        private void btnMarkLostReturned_Click(object sender, EventArgs e)
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
                LoadRecentItems();
            }
            catch (Exception ex)
            {
                UiTheme.ShowError(this, "Gagal menyelesaikan laporan hilang: " + ex.Message);
            }
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

        private void btnSaveClaim_Click(object sender, EventArgs e)
        {
            ClaimRequestValidationResult validation = ValidateCurrentClaimRequest();
            if (!validation.CanSubmit)
            {
                UiTheme.ShowWarning(this, validation.Message);
                return;
            }

            int itemId = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["ItemID"].Value);
            string studentNim = txtStudentNim.Text.Trim();
            string studentName = txtStudentName.Text.Trim();
            string savedPhotoPath = null;

            try
            {
                savedPhotoPath = photoStorage.SaveClaimPhoto(claimPhotoImage, selectedClaimPhotoSourcePath);
                claim.CreateApprovedClaim(new ClaimRequest
                {
                    ItemId = itemId,
                    StudentNim = studentNim,
                    StudentName = studentName,
                    ClaimPhotoPath = savedPhotoPath
                }, UserSession.UserID);

                UiTheme.ShowInfo(this, "Klaim disetujui. Status item sudah menjadi " + DomainValues.ItemStatuses.Returned + ".");
                txtStudentNim.Clear();
                txtStudentName.Clear();
                ClearClaimPhoto();
                LoadRecentItems();
                UpdateClaimRequestHint();
            }
            catch (Exception ex)
            {
                photoStorage.DeleteIfExists(savedPhotoPath);
                UiTheme.ShowError(this, "Gagal menyetujui klaim: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string location = txtLocation.Text.Trim();
            string type = rbLost.Checked ? DomainValues.ItemTypes.Lost : DomainValues.ItemTypes.Found;

            ItemReportValidationResult validation = itemReportValidator.Validate(itemName, description, location);
            UiTheme.SetInputError(txtItemName, validation.MissingItemName);
            UiTheme.SetInputError(txtDescription, validation.MissingDescription);
            UiTheme.SetInputError(txtLocation, validation.MissingLocation);

            if (!validation.IsValid)
            {
                ShowReportValidation(validation.Message);
                return;
            }

            ClearReportValidation();

            string savedImagePath = null;

            try
            {
                savedImagePath = photoStorage.SaveItemPhoto(capturedImage);
                item.CreateReport(new ItemReportRequest
                {
                    ItemName = itemName,
                    Description = description,
                    Location = location,
                    Type = type,
                    ReportedBy = UserSession.UserID,
                    ImagePath = savedImagePath
                });

                UiTheme.ShowInfo(this, "Laporan berhasil disimpan.");
                txtItemName.Clear();
                txtDescription.Clear();
                txtLocation.Clear();
                rbFound.Checked = true;
                ResetCameraCapture();
                ClearReportValidation();

                SecurityGridMode targetMode = type == DomainValues.ItemTypes.Lost
                    ? SecurityGridMode.LostItems
                    : SecurityGridMode.FoundItems;

                if (gridMode == targetMode)
                {
                    LoadRecentItems();
                }
                else
                {
                    SetGridMode(targetMode);
                }
            }
            catch (Exception ex)
            {
                photoStorage.DeleteIfExists(savedImagePath);
                UiTheme.ShowError(this, "Gagal menyimpan laporan: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            new LoginForm().Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopCamera();
            cameraController.FrameReady -= cameraController_FrameReady;
            cameraController.Dispose();
            DisposeCapturedImage();
            ClearCameraPreview();
            ClearClaimPhoto();
            base.OnFormClosing(e);
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
