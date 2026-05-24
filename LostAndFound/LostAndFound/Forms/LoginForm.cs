using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    public partial class LoginForm : Form
    {
        private const int WindowDragMessage = 0xA1;
        private const int WindowDragCaption = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int message, int wParam, int lParam);

        public LoginForm()
        {
            InitializeComponent();
            ConfigureVisualDesign();
        }

        private void ConfigureVisualDesign()
        {
            UiTheme.StyleForm(this, new Size(920, 600), false);
            ClientSize = new Size(920, 600);
            UiTheme.SetDoubleBuffered(this);
            ConfigureWindowChrome();
            ConfigurePanel(panelCanvasAccentTop, new Point(424, 54), new Size(122, 5), Color.FromArgb(210, 230, 229), 2);
            ConfigurePanel(panelCanvasAccentBottom, new Point(424, 506), new Size(168, 5), Color.FromArgb(233, 224, 207), 2);
            panelCanvasAccentTop.SendToBack();
            panelCanvasAccentBottom.SendToBack();

            guna2PanelBrand.Location = new Point(32, 32);
            guna2PanelBrand.Size = new Size(360, 496);
            guna2PanelBrand.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            guna2PanelBrand.BorderRadius = 18;
            ConfigureBrandPanel();
            ConfigureDecorativePanels();

            lblBrand.Text = "Lost & Found";
            UiTheme.StyleTitle(lblBrand, 25F);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(54, 92);

            UiTheme.StyleCard(guna2ShadowPanelLogin);
            guna2ShadowPanelLogin.Location = new Point(486, 78);
            guna2ShadowPanelLogin.Size = new Size(360, 414);
            guna2ShadowPanelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ShadowPanelLogin.Radius = 16;
            guna2ShadowPanelLogin.ShadowColor = Color.FromArgb(210, 222, 230);
            guna2ShadowPanelLogin.ShadowDepth = 4;
            guna2ShadowPanelLogin.ShadowShift = 2;

            lblLoginTitle.Text = "Masuk Sistem";
            lblLoginSubtitle.Text = "Akses dashboard sesuai role akun";
            lblUsername.Text = "Nama Pengguna";
            lblPassword.Text = "Kata Sandi";
            btnLogin.Text = "Masuk";

            UiTheme.StyleTitle(lblLoginTitle, 18F);
            UiTheme.StyleSubtitle(lblLoginSubtitle);
            UiTheme.StyleFieldLabel(lblUsername);
            UiTheme.StyleFieldLabel(lblPassword);
            UiTheme.StyleTextBox(txtUsername);
            UiTheme.StyleTextBox(txtPassword);
            UiTheme.StylePrimaryButton(btnLogin);

            lblLoginTitle.Location = new Point(34, 32);
            lblLoginSubtitle.Location = new Point(34, 66);
            lblUsername.Location = new Point(34, 116);
            txtUsername.Location = new Point(34, 142);
            lblPassword.Location = new Point(34, 208);
            txtPassword.Location = new Point(34, 234);
            EnsureLoginErrorLabel();
            btnLogin.Location = new Point(34, 326);

            txtUsername.PlaceholderText = "Masukkan username";
            txtPassword.PlaceholderText = "Masukkan password";
            txtUsername.TextOffset = new Point(4, 0);
            txtPassword.TextOffset = new Point(4, 0);
            txtUsername.Size = new Size(292, 46);
            txtPassword.Size = new Size(292, 46);
            btnLogin.Size = new Size(292, 48);
            panelLoginRail.SendToBack();
            panelLoginAccent.BringToFront();
            panelLoginCornerTop.BringToFront();
            panelLoginCornerSide.BringToFront();
            panelUsernameDot.BringToFront();
            panelPasswordDot.BringToFront();

            panelWindowChrome.MouseDown += WindowChrome_MouseDown;
            lblWindowTitle.MouseDown += WindowChrome_MouseDown;
            btnWindowMinimize.Click += btnWindowMinimize_Click;
            btnWindowMaximize.Click += btnWindowMaximize_Click;
            btnWindowClose.Click += btnWindowClose_Click;
            txtUsername.TextChanged += (sender, e) => ClearLoginError();
            txtPassword.TextChanged += (sender, e) => ClearLoginError();
            Resize += (sender, e) =>
            {
                LayoutLoginSurface();
                UpdateMaximizeButtonText();
            };
            LayoutLoginSurface();
            UpdateMaximizeButtonText();
        }

        private void LayoutLoginSurface()
        {
            const int brandWidth = 360;
            const int brandHeight = 496;
            const int cardWidth = 360;
            const int cardHeight = 414;
            const int chromeHeight = 42;
            const int gap = 92;
            int totalWidth = brandWidth + gap + cardWidth;
            int contentHeight = ClientSize.Height - chromeHeight;
            int left = Math.Max(32, (ClientSize.Width - totalWidth) / 2);
            int top = chromeHeight + Math.Max(24, (contentHeight - brandHeight) / 2);

            guna2PanelBrand.Location = new Point(left, top);
            guna2PanelBrand.Size = new Size(brandWidth, brandHeight);
            guna2ShadowPanelLogin.Location = new Point(left + brandWidth + gap, top + (brandHeight - cardHeight) / 2);
            guna2ShadowPanelLogin.Size = new Size(cardWidth, cardHeight);
            panelCanvasAccentTop.Location = new Point(left + brandWidth + 24, top + 26);
            panelCanvasAccentBottom.Location = new Point(left + brandWidth + 56, top + brandHeight - 34);
        }

        private void ConfigureWindowChrome()
        {
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = true;
            MaximizeBox = true;
            panelWindowChrome.Height = 42;
            panelWindowChrome.Dock = DockStyle.Top;
            panelWindowChrome.FillColor = Color.FromArgb(246, 250, 252);
            ConfigurePanel(panelWindowDivider, new Point(0, 41), new Size(ClientSize.Width, 1), Color.FromArgb(224, 232, 238), 0);
            panelWindowDivider.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            ConfigurePanel(panelWindowIcon, new Point(24, 16), new Size(10, 10), UiTheme.Accent, 3);
            lblWindowTitle.Text = "Lost & Found";
            lblWindowTitle.BackColor = Color.Transparent;
            lblWindowTitle.Font = UiTheme.Font(9F, FontStyle.Bold);
            lblWindowTitle.ForeColor = UiTheme.Text;
            lblWindowTitle.Location = new Point(42, 12);

            ConfigureChromeButton(btnWindowMinimize, "-", new Point(ClientSize.Width - 126, 4));
            ConfigureChromeButton(btnWindowMaximize, "\u25A1", new Point(ClientSize.Width - 84, 4));
            ConfigureChromeButton(btnWindowClose, "x", new Point(ClientSize.Width - 42, 4));
            btnWindowClose.HoverState.FillColor = UiTheme.Danger;
            btnWindowClose.HoverState.ForeColor = Color.White;
        }

        private void ConfigureChromeButton(Guna2Button button, string text, Point location)
        {
            button.Animated = true;
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.BorderRadius = 8;
            button.FillColor = Color.Transparent;
            button.Font = UiTheme.Font(10F, FontStyle.Bold);
            button.ForeColor = UiTheme.Muted;
            button.HoverState.FillColor = Color.FromArgb(230, 238, 243);
            button.Location = location;
            button.Size = new Size(34, 30);
            button.Text = text;
            button.TextAlign = HorizontalAlignment.Center;
            button.TextOffset = new Point(0, -1);
        }

        private void ConfigureBrandPanel()
        {
            guna2PanelBrand.FillColor = UiTheme.HeaderDark;
            guna2PanelBrand.FillColor2 = UiTheme.HeaderDeep;
            guna2PanelBrand.GradientMode = LinearGradientMode.ForwardDiagonal;
        }

        private void ConfigureDecorativePanels()
        {
            ConfigurePanel(panelBrandTitleMarker, new Point(36, 93), new Size(6, 54), UiTheme.Accent, 3);
            ConfigurePanel(panelBrandTitleRule, new Point(54, 149), new Size(112, 3), Color.FromArgb(63, 176, 165), 2);
            ConfigurePanel(panelBrandBlockOne, new Point(250, 332), new Size(74, 8), Color.FromArgb(35, 82, 96), 4);
            ConfigurePanel(panelBrandBlockTwo, new Point(220, 354), new Size(104, 8), Color.FromArgb(38, 103, 115), 4);
            ConfigurePanel(panelBrandBlockThree, new Point(276, 376), new Size(48, 8), UiTheme.Accent, 4);
            ConfigurePanel(panelBrandArtifact, new Point(76, 246), new Size(176, 112), Color.FromArgb(16, 53, 67), 12);
            ConfigurePanel(panelBrandArtifactTop, new Point(96, 270), new Size(82, 5), Color.FromArgb(56, 132, 142), 2);
            ConfigurePanel(panelBrandArtifactMid, new Point(96, 294), new Size(118, 5), Color.FromArgb(37, 86, 100), 2);
            ConfigurePanel(panelBrandArtifactBottom, new Point(96, 318), new Size(64, 5), UiTheme.Accent, 2);
            ConfigurePanel(panelBrandArtifactDot, new Point(224, 270), new Size(10, 10), Color.FromArgb(63, 176, 165), 5);
            ConfigurePanel(panelBrandCornerBar, new Point(36, 438), new Size(84, 4), Color.FromArgb(52, 129, 139), 2);
            ConfigurePanel(panelBrandCornerRule, new Point(36, 456), new Size(132, 4), Color.FromArgb(32, 78, 91), 2);
            ConfigurePanel(panelLoginAccent, new Point(34, 20), new Size(64, 4), UiTheme.Accent, 2);
            ConfigurePanel(panelLoginRail, new Point(20, 116), new Size(3, 164), Color.FromArgb(230, 247, 244), 2);
            ConfigurePanel(panelLoginCornerTop, new Point(256, 20), new Size(54, 4), Color.FromArgb(230, 247, 244), 2);
            ConfigurePanel(panelLoginCornerSide, new Point(310, 20), new Size(4, 42), Color.FromArgb(230, 247, 244), 2);
            ConfigurePanel(panelUsernameDot, new Point(17, 140), new Size(9, 9), UiTheme.Accent, 4);
            ConfigurePanel(panelPasswordDot, new Point(17, 232), new Size(9, 9), Color.FromArgb(63, 176, 165), 4);
            panelBrandArtifact.SendToBack();
            panelBrandArtifactTop.BringToFront();
            panelBrandArtifactMid.BringToFront();
            panelBrandArtifactBottom.BringToFront();
            panelBrandArtifactDot.BringToFront();
        }

        private void ConfigurePanel(Guna2Panel panel, Point location, Size size, Color fillColor, int radius)
        {
            panel.BackColor = Color.Transparent;
            panel.BorderRadius = radius;
            panel.FillColor = fillColor;
            panel.Location = location;
            panel.Size = size;
        }

        private void EnsureLoginErrorLabel()
        {
            if (lblLoginError.Parent != guna2ShadowPanelLogin)
            {
                guna2ShadowPanelLogin.Controls.Add(lblLoginError);
            }

            UiTheme.StyleInlineValidationLabel(lblLoginError);
            lblLoginError.Location = new Point(34, 290);
            lblLoginError.Size = new Size(292, 24);
            lblLoginError.BringToFront();
        }

        private void ShowLoginError(string message)
        {
            EnsureLoginErrorLabel();
            lblLoginError.Text = message;
            lblLoginError.Visible = true;
        }

        private void WindowChrome_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, WindowDragMessage, WindowDragCaption, 0);
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
            if (btnWindowMaximize != null)
            {
                btnWindowMaximize.Text = WindowState == FormWindowState.Maximized ? "\u2750" : "\u25A1";
            }
        }

        private void ClearLoginError()
        {
            if (lblLoginError != null)
            {
                lblLoginError.Visible = false;
                lblLoginError.Text = string.Empty;
            }

            UiTheme.SetInputError(txtUsername, false);
            UiTheme.SetInputError(txtPassword, false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClearLoginError();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowLoginError("Isi username dan password terlebih dahulu.");
                UiTheme.SetInputError(txtUsername, string.IsNullOrEmpty(username));
                UiTheme.SetInputError(txtPassword, string.IsNullOrEmpty(password));
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.CreateConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT u.UserID, r.RoleName AS Role
                        FROM Users u
                        INNER JOIN Roles r ON r.RoleID = u.RoleID
                        WHERE u.Username = @username
                          AND u.PasswordHash = @password
                          AND u.IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["UserID"]);
                                string role = reader["Role"].ToString();
                                UiTheme.ShowInfo(this, "Login berhasil. Selamat datang, " + username + " (" + role + ").");

                                // Global state to keep track of logged in user
                                UserSession.UserID = userId;
                                UserSession.Username = username;
                                UserSession.Role = role;

                                if (string.Equals(role, DomainValues.Roles.Admin, StringComparison.OrdinalIgnoreCase))
                                {
                                    new AdminForm().Show();
                                }
                                else if (string.Equals(role, DomainValues.Roles.Security, StringComparison.OrdinalIgnoreCase))
                                {
                                    new SecurityForm().Show();
                                }
                                else
                                {
                                    ShowLoginError("Role akun ini tidak memiliki akses aplikasi.");
                                    return;
                                }
                                this.Hide();
                            }
                            else
                            {
                                ShowLoginError("Username atau password tidak valid.");
                                UiTheme.SetInputError(txtUsername, true);
                                UiTheme.SetInputError(txtPassword, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowLoginError("Tidak dapat masuk. Cek koneksi database.");
                UiTheme.ShowError(this, "Error: " + ex.Message);
            }
        }
    }

    public static class UserSession
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}
