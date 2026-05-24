using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    public partial class LoginForm : Form
    {
        private Guna2GradientPanel brandCanvas;
        private Label lblLoginError;

        public LoginForm()
        {
            InitializeComponent();
            ConfigureVisualDesign();
        }

        private void ConfigureVisualDesign()
        {
            UiTheme.StyleForm(this, new Size(920, 560), false);
            ClientSize = new Size(920, 560);
            UiTheme.SetDoubleBuffered(this);

            guna2PanelBrand.Location = new Point(32, 32);
            guna2PanelBrand.Size = new Size(360, 496);
            guna2PanelBrand.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            guna2PanelBrand.BorderRadius = 18;
            guna2PanelBrand.FillColor = Color.Transparent;
            BuildBrandCanvas();

            lblBrand.Text = "Lost & Found";
            UiTheme.StyleTitle(lblBrand, 25F);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(34, 92);

            AddBrandLabel("ASSET RECOVERY DESK", new Point(36, 58), 8.8F, UiTheme.Accent, FontStyle.Bold);
            AddBrandLabel("Temukan. Verifikasi. Kembalikan.", new Point(36, 142), 10F, Color.FromArgb(217, 226, 232), FontStyle.Regular);
            AddBrandLabel("Admin / Security access", new Point(36, 446), 9.2F, Color.FromArgb(196, 212, 220), FontStyle.Bold);

            UiTheme.StyleCard(guna2ShadowPanelLogin);
            guna2ShadowPanelLogin.Location = new Point(486, 78);
            guna2ShadowPanelLogin.Size = new Size(360, 414);
            guna2ShadowPanelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ShadowPanelLogin.Radius = 16;
            guna2ShadowPanelLogin.ShadowDepth = 0;
            guna2ShadowPanelLogin.ShadowShift = 0;

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

            txtUsername.TextChanged += (sender, e) => ClearLoginError();
            txtPassword.TextChanged += (sender, e) => ClearLoginError();
            Resize += (sender, e) => LayoutLoginSurface();
            LayoutLoginSurface();
        }

        private void LayoutLoginSurface()
        {
            const int brandWidth = 360;
            const int brandHeight = 496;
            const int cardWidth = 360;
            const int cardHeight = 414;
            const int gap = 92;
            int totalWidth = brandWidth + gap + cardWidth;
            int left = Math.Max(32, (ClientSize.Width - totalWidth) / 2);
            int top = Math.Max(28, (ClientSize.Height - brandHeight) / 2);

            guna2PanelBrand.Location = new Point(left, top);
            guna2PanelBrand.Size = new Size(brandWidth, brandHeight);
            guna2ShadowPanelLogin.Location = new Point(left + brandWidth + gap, top + (brandHeight - cardHeight) / 2);
            guna2ShadowPanelLogin.Size = new Size(cardWidth, cardHeight);
        }

        private void BuildBrandCanvas()
        {
            guna2PanelBrand.Controls.Clear();
            brandCanvas = new Guna2GradientPanel
            {
                BorderRadius = 18,
                Dock = DockStyle.Fill,
                FillColor = UiTheme.HeaderDark,
                FillColor2 = UiTheme.HeaderDeep,
                GradientMode = LinearGradientMode.ForwardDiagonal,
                Name = "brandCanvas"
            };

            guna2PanelBrand.Controls.Add(brandCanvas);
            brandCanvas.Controls.Add(lblBrand);
        }

        private void AddBrandLabel(string text, Point location, float size, Color color, FontStyle style)
        {
            var label = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = UiTheme.Font(size, style),
                ForeColor = color,
                Location = location,
                Text = text
            };

            brandCanvas.Controls.Add(label);
        }

        private void AddBrandMetric(string value, string caption, Point location)
        {
            var panel = new Guna2Panel
            {
                BorderColor = Color.FromArgb(53, 91, 105),
                BorderRadius = 0,
                BorderThickness = 1,
                FillColor = Color.FromArgb(21, 49, 63),
                Location = location,
                Size = new Size(136, 48)
            };

            var valueLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.DisplayFont(13F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(12, 5),
                Size = new Size(110, 22),
                Text = value
            };

            var captionLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = UiTheme.Font(7.8F),
                ForeColor = Color.FromArgb(184, 199, 208),
                Location = new Point(12, 27),
                Size = new Size(110, 16),
                Text = caption
            };

            panel.Controls.Add(valueLabel);
            panel.Controls.Add(captionLabel);
            brandCanvas.Controls.Add(panel);
        }

        private void EnsureLoginErrorLabel()
        {
            if (lblLoginError == null)
            {
                lblLoginError = new Label
                {
                    Name = "lblLoginError"
                };
                UiTheme.StyleInlineValidationLabel(lblLoginError);
                guna2ShadowPanelLogin.Controls.Add(lblLoginError);
            }

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
