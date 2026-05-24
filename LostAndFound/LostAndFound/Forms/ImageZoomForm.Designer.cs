namespace LostAndFound
{
    partial class ImageZoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel toolbar;
        private System.Windows.Forms.Label lblZoom;
        private Guna.UI2.WinForms.Guna2Button btnZoomOut;
        private Guna.UI2.WinForms.Guna2Button btnFit;
        private Guna.UI2.WinForms.Guna2Button btnActual;
        private Guna.UI2.WinForms.Guna2Button btnZoomIn;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel viewport;
        private System.Windows.Forms.PictureBox picture;

        private void InitializeComponent()
        {
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.toolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblZoom = new System.Windows.Forms.Label();
            this.btnZoomOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnFit = new Guna.UI2.WinForms.Guna2Button();
            this.btnActual = new Guna.UI2.WinForms.Guna2Button();
            this.btnZoomIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.viewport = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.viewport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.toolbar);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(880, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("JetBrains Mono", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Preview Foto Barang";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("JetBrains Mono", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(360, 18);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Scroll mouse untuk zoom, drag scrollbar untuk geser gambar";
            // 
            // toolbar
            // 
            this.toolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbar.BackColor = System.Drawing.Color.Transparent;
            this.toolbar.Controls.Add(this.lblZoom);
            this.toolbar.Controls.Add(this.btnZoomOut);
            this.toolbar.Controls.Add(this.btnFit);
            this.toolbar.Controls.Add(this.btnActual);
            this.toolbar.Controls.Add(this.btnZoomIn);
            this.toolbar.Controls.Add(this.btnClose);
            this.toolbar.Location = new System.Drawing.Point(410, 18);
            this.toolbar.Margin = new System.Windows.Forms.Padding(0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(446, 36);
            this.toolbar.TabIndex = 2;
            this.toolbar.WrapContents = false;
            // 
            // lblZoom
            // 
            this.lblZoom.BackColor = System.Drawing.Color.Transparent;
            this.lblZoom.Font = new System.Drawing.Font("JetBrains Mono", 8.8F, System.Drawing.FontStyle.Bold);
            this.lblZoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(74)))));
            this.lblZoom.Location = new System.Drawing.Point(0, 7);
            this.lblZoom.Margin = new System.Windows.Forms.Padding(0, 7, 8, 0);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(54, 20);
            this.lblZoom.TabIndex = 0;
            this.lblZoom.Text = "100%";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnZoomOut.BorderRadius = 8;
            this.btnZoomOut.BorderThickness = 1;
            this.btnZoomOut.FillColor = System.Drawing.Color.White;
            this.btnZoomOut.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold);
            this.btnZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnZoomOut.Location = new System.Drawing.Point(62, 0);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(78, 34);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Text = "Perkecil";
            // 
            // btnFit
            // 
            this.btnFit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnFit.BorderRadius = 8;
            this.btnFit.BorderThickness = 1;
            this.btnFit.FillColor = System.Drawing.Color.White;
            this.btnFit.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold);
            this.btnFit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnFit.Location = new System.Drawing.Point(148, 0);
            this.btnFit.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(56, 34);
            this.btnFit.TabIndex = 2;
            this.btnFit.Text = "Fit";
            // 
            // btnActual
            // 
            this.btnActual.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnActual.BorderRadius = 8;
            this.btnActual.BorderThickness = 1;
            this.btnActual.FillColor = System.Drawing.Color.White;
            this.btnActual.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold);
            this.btnActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnActual.Location = new System.Drawing.Point(212, 0);
            this.btnActual.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnActual.Name = "btnActual";
            this.btnActual.Size = new System.Drawing.Size(60, 34);
            this.btnActual.TabIndex = 3;
            this.btnActual.Text = "100%";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnZoomIn.BorderRadius = 8;
            this.btnZoomIn.BorderThickness = 1;
            this.btnZoomIn.FillColor = System.Drawing.Color.White;
            this.btnZoomIn.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold);
            this.btnZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnZoomIn.Location = new System.Drawing.Point(280, 0);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(82, 34);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "Perbesar";
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.btnClose.Location = new System.Drawing.Point(370, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 34);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Tutup";
            // 
            // viewport
            // 
            this.viewport.AutoScroll = true;
            this.viewport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.viewport.Controls.Add(this.picture);
            this.viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewport.Location = new System.Drawing.Point(0, 70);
            this.viewport.Name = "viewport";
            this.viewport.Padding = new System.Windows.Forms.Padding(24);
            this.viewport.Size = new System.Drawing.Size(880, 550);
            this.viewport.TabIndex = 1;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.picture.Location = new System.Drawing.Point(24, 24);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(360, 220);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // ImageZoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(880, 620);
            this.Controls.Add(this.viewport);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("JetBrains Mono", 9F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(720, 520);
            this.Name = "ImageZoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zoom Foto Barang";
            this.headerPanel.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.viewport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
