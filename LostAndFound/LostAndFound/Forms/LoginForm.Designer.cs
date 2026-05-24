namespace LostAndFound
{
    partial class LoginForm
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
            this.guna2PanelBrand = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBrandFooter = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanelLogin = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLoginSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLoginTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.guna2PanelBrand.SuspendLayout();
            this.guna2ShadowPanelLogin.SuspendLayout();
            this.SuspendLayout();
            //
            // guna2PanelBrand
            //
            this.guna2PanelBrand.BorderRadius = 18;
            this.guna2PanelBrand.Controls.Add(this.lblBrandFooter);
            this.guna2PanelBrand.Controls.Add(this.lblBrand);
            this.guna2PanelBrand.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.guna2PanelBrand.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.guna2PanelBrand.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2PanelBrand.Location = new System.Drawing.Point(32, 32);
            this.guna2PanelBrand.Name = "guna2PanelBrand";
            this.guna2PanelBrand.Size = new System.Drawing.Size(360, 496);
            this.guna2PanelBrand.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Variable Text", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(34, 92);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(245, 47);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Lost & Found";
            //
            // lblBrandFooter
            //
            this.lblBrandFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandFooter.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblBrandFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(212)))), ((int)(((byte)(220)))));
            this.lblBrandFooter.Location = new System.Drawing.Point(36, 446);
            this.lblBrandFooter.Name = "lblBrandFooter";
            this.lblBrandFooter.Size = new System.Drawing.Size(148, 17);
            this.lblBrandFooter.TabIndex = 12;
            this.lblBrandFooter.Text = "Admin / Security access";
            // 
            // guna2ShadowPanelLogin
            // 
            this.guna2ShadowPanelLogin.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanelLogin.Controls.Add(this.lblPassword);
            this.guna2ShadowPanelLogin.Controls.Add(this.lblUsername);
            this.guna2ShadowPanelLogin.Controls.Add(this.lblLoginSubtitle);
            this.guna2ShadowPanelLogin.Controls.Add(this.lblLoginTitle);
            this.guna2ShadowPanelLogin.Controls.Add(this.btnLogin);
            this.guna2ShadowPanelLogin.Controls.Add(this.txtPassword);
            this.guna2ShadowPanelLogin.Controls.Add(this.txtUsername);
            this.guna2ShadowPanelLogin.Controls.Add(this.lblLoginError);
            this.guna2ShadowPanelLogin.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanelLogin.Location = new System.Drawing.Point(486, 78);
            this.guna2ShadowPanelLogin.Name = "guna2ShadowPanelLogin";
            this.guna2ShadowPanelLogin.Radius = 16;
            this.guna2ShadowPanelLogin.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.guna2ShadowPanelLogin.ShadowDepth = 0;
            this.guna2ShadowPanelLogin.ShadowShift = 0;
            this.guna2ShadowPanelLogin.Size = new System.Drawing.Size(360, 414);
            this.guna2ShadowPanelLogin.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblPassword.Location = new System.Drawing.Point(34, 208);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Kata Sandi";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.3F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblUsername.Location = new System.Drawing.Point(34, 116);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(96, 17);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Nama Pengguna";
            // 
            // lblLoginSubtitle
            // 
            this.lblLoginSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginSubtitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.lblLoginSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblLoginSubtitle.Location = new System.Drawing.Point(34, 66);
            this.lblLoginSubtitle.Name = "lblLoginSubtitle";
            this.lblLoginSubtitle.Size = new System.Drawing.Size(194, 17);
            this.lblLoginSubtitle.TabIndex = 4;
            this.lblLoginSubtitle.Text = "Akses dashboard sesuai role akun";
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblLoginTitle.Location = new System.Drawing.Point(34, 32);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(159, 34);
            this.lblLoginTitle.TabIndex = 3;
            this.lblLoginTitle.Text = "Masuk Sistem";
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 8;
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(126)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(117)))));
            this.btnLogin.Location = new System.Drawing.Point(34, 326);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(292, 48);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Masuk";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.txtPassword.Location = new System.Drawing.Point(34, 234);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtPassword.PlaceholderText = "Masukkan password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(292, 46);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.txtUsername.Location = new System.Drawing.Point(34, 142);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.txtUsername.PlaceholderText = "Masukkan username";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(292, 46);
            this.txtUsername.TabIndex = 0;
            //
            // lblLoginError
            //
            this.lblLoginError.AutoEllipsis = true;
            this.lblLoginError.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginError.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.4F, System.Drawing.FontStyle.Bold);
            this.lblLoginError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.lblLoginError.Location = new System.Drawing.Point(34, 290);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Size = new System.Drawing.Size(292, 24);
            this.lblLoginError.TabIndex = 7;
            this.lblLoginError.Visible = false;
            //
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.guna2ShadowPanelLogin);
            this.Controls.Add(this.guna2PanelBrand);
            this.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Lost and Found";
            this.guna2PanelBrand.ResumeLayout(false);
            this.guna2PanelBrand.PerformLayout();
            this.guna2ShadowPanelLogin.ResumeLayout(false);
            this.guna2ShadowPanelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GradientPanel guna2PanelBrand;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanelLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrand;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrandFooter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoginTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoginSubtitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label lblLoginError;
    }
}
