using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    public partial class ImageZoomForm : Form
    {
        private Image sourceImage;
        private float zoom = 1F;

        public ImageZoomForm()
            : this(CreateDesignPreviewImage(), "Preview Foto Barang")
        {
        }

        internal ImageZoomForm(Image image, string itemName)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            sourceImage = new Bitmap(image);

            InitializeComponent();
            ConfigureZoomForm(itemName);
            picture.Image = sourceImage;
            FitImage();
        }

        private static Image CreateDesignPreviewImage()
        {
            Bitmap preview = new Bitmap(1280, 720);

            using (Graphics graphics = Graphics.FromImage(preview))
            using (LinearGradientBrush background = new LinearGradientBrush(
                new Rectangle(0, 0, preview.Width, preview.Height),
                Color.FromArgb(220, 232, 236),
                Color.FromArgb(142, 158, 179),
                LinearGradientMode.ForwardDiagonal))
            using (SolidBrush cardBrush = new SolidBrush(Color.FromArgb(18, 72, 86)))
            using (SolidBrush labelBrush = new SolidBrush(Color.White))
            using (Font titleFont = UiTheme.Font(54F, FontStyle.Bold))
            using (Font detailFont = UiTheme.Font(22F))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.FillRectangle(background, 0, 0, preview.Width, preview.Height);
                graphics.FillRectangle(cardBrush, 160, 180, 960, 330);
                graphics.DrawString("PREVIEW FOTO BARANG", titleFont, labelBrush, 250, 285);
                graphics.DrawString("Design-time sample, runtime memakai foto asli.", detailFont, labelBrush, 255, 365);
            }

            return preview;
        }

        private void ConfigureZoomForm(string itemName)
        {
            UiTheme.StyleForm(this, new Size(720, 520), true);
            ClientSize = new Size(880, 620);
            KeyPreview = true;
            UiTheme.SetDoubleBuffered(this);
            UiTheme.SetDoubleBuffered(headerPanel);
            UiTheme.SetDoubleBuffered(viewport);
            Text = string.IsNullOrWhiteSpace(itemName)
                ? "Zoom Foto Barang"
                : "Zoom Foto Barang - " + itemName;

            headerPanel.Height = 78;
            lblTitle.Text = string.IsNullOrWhiteSpace(itemName) ? "Foto Barang" : itemName;
            lblTitle.Font = UiTheme.Font(13F, FontStyle.Bold);
            lblTitle.ForeColor = UiTheme.Ink;
            lblSubtitle.Font = UiTheme.Font(8.5F);
            lblSubtitle.ForeColor = UiTheme.Muted;
            lblSubtitle.Text = "Scroll untuk zoom, gunakan scrollbar untuk geser";
            lblZoom.Font = UiTheme.Font(8.8F, FontStyle.Bold);
            lblZoom.ForeColor = UiTheme.Text;
            headerPanel.FillColor = UiTheme.Surface;
            viewport.AutoScroll = true;
            viewport.BackColor = Color.FromArgb(8, 18, 31);
            picture.BackColor = Color.FromArgb(8, 18, 31);

            toolbar.FlowDirection = FlowDirection.LeftToRight;
            toolbar.WrapContents = false;
            toolbar.Width = 386;
            toolbar.Height = 38;
            btnZoomOut.Text = "-";
            btnZoomOut.Size = new Size(40, 34);
            btnFit.Text = "Fit";
            btnFit.Size = new Size(52, 34);
            btnActual.Text = "1:1";
            btnActual.Size = new Size(54, 34);
            btnZoomIn.Text = "+";
            btnZoomIn.Size = new Size(40, 34);
            btnClose.Text = "Tutup";
            btnClose.Size = new Size(68, 34);

            UiTheme.StyleSecondaryButton(btnZoomOut);
            UiTheme.StyleSecondaryButton(btnFit);
            UiTheme.StyleSecondaryButton(btnActual);
            UiTheme.StyleSecondaryButton(btnZoomIn);
            UiTheme.StyleSecondaryButton(btnClose);

            btnZoomOut.Click += (sender, e) => SetZoom(zoom / 1.2F);
            btnFit.Click += (sender, e) => FitImage();
            btnActual.Click += (sender, e) => SetZoom(1F);
            btnZoomIn.Click += (sender, e) => SetZoom(zoom * 1.2F);
            btnClose.Click += (sender, e) => Close();

            headerPanel.Resize += (sender, e) => LayoutToolbar();
            LayoutToolbar();

            viewport.MouseWheel += ZoomWithWheel;
            viewport.Resize += (sender, e) => ApplyZoom();
            picture.MouseWheel += ZoomWithWheel;
            picture.MouseEnter += (sender, e) => viewport.Focus();

            MouseWheel += ZoomWithWheel;
            KeyDown += ImageZoomForm_KeyDown;
        }

        private void LayoutToolbar()
        {
            toolbar.Location = new Point(Math.Max(24, headerPanel.ClientSize.Width - toolbar.Width - 24), 22);
            int textWidth = Math.Max(180, toolbar.Left - 36);
            lblTitle.Location = new Point(24, 14);
            lblSubtitle.Location = new Point(24, 42);
            lblTitle.Width = textWidth;
            lblSubtitle.Width = textWidth;
        }

        private void ImageZoomForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }

            if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                SetZoom(zoom * 1.2F);
            }
            else if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                SetZoom(zoom / 1.2F);
            }
            else if (e.Control && e.KeyCode == Keys.D0)
            {
                SetZoom(1F);
            }
        }

        private void ZoomWithWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                SetZoom(zoom * 1.12F);
            }
            else if (e.Delta < 0)
            {
                SetZoom(zoom / 1.12F);
            }
        }

        private void FitImage()
        {
            if (sourceImage == null)
            {
                return;
            }

            int availableWidth = Math.Max(1, viewport.ClientSize.Width - 48);
            int availableHeight = Math.Max(1, viewport.ClientSize.Height - 48);
            float widthRatio = availableWidth / (float)sourceImage.Width;
            float heightRatio = availableHeight / (float)sourceImage.Height;
            SetZoom(Math.Min(widthRatio, heightRatio));
        }

        private void SetZoom(float value)
        {
            zoom = Math.Max(0.15F, Math.Min(6F, value));
            ApplyZoom();
        }

        private void ApplyZoom()
        {
            if (sourceImage == null)
            {
                return;
            }

            int width = Math.Max(1, (int)(sourceImage.Width * zoom));
            int height = Math.Max(1, (int)(sourceImage.Height * zoom));

            picture.Size = new Size(width, height);
            viewport.AutoScrollMinSize = picture.Size;

            int x = width < viewport.ClientSize.Width
                ? (viewport.ClientSize.Width - width) / 2
                : 0;
            int y = height < viewport.ClientSize.Height
                ? (viewport.ClientSize.Height - height) / 2
                : 0;

            picture.Location = new Point(x, y);
            lblZoom.Text = Math.Round(zoom * 100F) + "%";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sourceImage?.Dispose();
                components?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
