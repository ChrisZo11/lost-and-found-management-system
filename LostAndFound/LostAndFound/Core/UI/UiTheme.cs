using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LostAndFound
{
    internal static class UiTheme
    {
        private static readonly ConditionalWeakTable<DataGridView, GridBadgeState> GridBadgeStates = new ConditionalWeakTable<DataGridView, GridBadgeState>();
        private const string AppFontName = "JetBrains Mono";
        private static readonly PrivateFontCollection AppFonts = new PrivateFontCollection();
        private static readonly FontFamily AppFontFamily = LoadAppFontFamily();

        internal static readonly Color Canvas = Color.FromArgb(242, 246, 248);
        internal static readonly Color Surface = Color.White;
        internal static readonly Color SurfaceSoft = Color.FromArgb(248, 251, 252);
        internal static readonly Color SurfaceTint = Color.FromArgb(230, 247, 244);
        internal static readonly Color Ink = Color.FromArgb(10, 21, 35);
        internal static readonly Color Text = Color.FromArgb(41, 55, 74);
        internal static readonly Color Muted = Color.FromArgb(91, 107, 130);
        internal static readonly Color MutedLight = Color.FromArgb(142, 158, 179);
        internal static readonly Color Border = Color.FromArgb(207, 219, 231);
        internal static readonly Color HeaderDark = Color.FromArgb(11, 24, 39);
        internal static readonly Color HeaderDeep = Color.FromArgb(18, 72, 86);
        internal static readonly Color HeaderPanel = Color.FromArgb(18, 48, 63);
        internal static readonly Color Primary = Color.FromArgb(0, 137, 126);
        internal static readonly Color PrimaryHover = Color.FromArgb(0, 126, 117);
        internal static readonly Color PrimaryPressed = Color.FromArgb(7, 94, 87);
        internal static readonly Color Accent = Color.FromArgb(235, 161, 38);
        internal static readonly Color Success = Color.FromArgb(34, 161, 99);
        internal static readonly Color Danger = Color.FromArgb(219, 59, 74);
        internal static readonly Color DangerHover = Color.FromArgb(183, 42, 55);
        internal static readonly Color Info = Color.FromArgb(44, 103, 214);
        internal static readonly Color Warning = Color.FromArgb(246, 174, 45);
        internal static readonly Color DisabledFill = Color.FromArgb(169, 178, 188);
        internal static readonly Color DisabledText = Color.FromArgb(102, 112, 124);

        internal static string FontFamilyName => AppFontFamily.Name;

        internal static Font Font(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(AppFontFamily, size, style, GraphicsUnit.Point);
        }

        internal static Font DisplayFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(AppFontFamily, size, style, GraphicsUnit.Point);
        }

        internal static Font MonoFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(AppFontFamily, size, style, GraphicsUnit.Point);
        }

        private static FontFamily LoadAppFontFamily()
        {
            try
            {
                string fontsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Fonts");
                string regularPath = Path.Combine(fontsPath, "JetBrainsMono-Regular.ttf");
                string boldPath = Path.Combine(fontsPath, "JetBrainsMono-Bold.ttf");

                if (File.Exists(regularPath))
                {
                    AppFonts.AddFontFile(regularPath);
                }

                if (File.Exists(boldPath))
                {
                    AppFonts.AddFontFile(boldPath);
                }

                foreach (FontFamily family in AppFonts.Families)
                {
                    if (string.Equals(family.Name, AppFontName, StringComparison.OrdinalIgnoreCase))
                    {
                        return family;
                    }
                }
            }
            catch
            {
                // Fall back below if the bundled font cannot be loaded.
            }

            try
            {
                return new FontFamily(AppFontName);
            }
            catch
            {
                return FontFamily.GenericSansSerif;
            }
        }

        internal static bool IsDesignMode(Control control)
        {
            string processName = Process.GetCurrentProcess().ProcessName;

            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || (control != null && (control.Site?.DesignMode ?? false))
                || processName == "devenv"
                || processName == "DesignToolsServer";
        }

        internal static void StyleForm(Form form, Size minimumSize, bool allowResize)
        {
            form.BackColor = Canvas;
            form.Font = Font(9F);
            ApplyFontTree(form);
            form.MinimumSize = minimumSize;
            form.StartPosition = FormStartPosition.CenterScreen;

            if (allowResize)
            {
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.MaximizeBox = true;
            }
            else
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.MaximizeBox = false;
            }

        }

        internal static void ApplyFontTree(Control parent)
        {
            if (parent == null)
            {
                return;
            }

            Font current = parent.Font;
            float size = current == null ? 9F : current.SizeInPoints;
            FontStyle style = current == null ? FontStyle.Regular : current.Style;
            parent.Font = Font(size, style);

            foreach (Control child in parent.Controls)
            {
                ApplyFontTree(child);
            }
        }

        internal static Guna2GradientPanel AddTopBand(Form form, int height)
        {
            var band = new Guna2GradientPanel
            {
                Dock = DockStyle.Top,
                FillColor = HeaderDark,
                FillColor2 = HeaderDeep,
                GradientMode = LinearGradientMode.ForwardDiagonal,
                Height = height,
                Name = "panelTopBand"
            };

            form.Controls.Add(band);
            band.SendToBack();
            return band;
        }

        internal static void StyleTitle(Guna2HtmlLabel label, float size)
        {
            label.BackColor = Color.Transparent;
            label.Font = DisplayFont(size, FontStyle.Bold);
            label.ForeColor = Ink;
        }

        internal static void StyleSubtitle(Guna2HtmlLabel label)
        {
            label.BackColor = Color.Transparent;
            label.Font = Font(9F);
            label.ForeColor = Muted;
        }

        internal static void StyleFieldLabel(Guna2HtmlLabel label)
        {
            label.BackColor = Color.Transparent;
            label.Font = Font(9.3F, FontStyle.Bold);
            label.ForeColor = Text;
        }

        internal static void StyleCard(Guna2ShadowPanel panel)
        {
            panel.BackColor = Color.Transparent;
            panel.FillColor = Surface;
            panel.Radius = 8;
            panel.ShadowColor = Color.FromArgb(211, 224, 231);
            panel.ShadowDepth = 4;
            panel.ShadowShift = 2;
        }

        internal static void StylePrimaryButton(Guna2Button button)
        {
            button.Animated = true;
            button.BorderRadius = 8;
            button.BorderThickness = 0;
            button.Cursor = Cursors.Hand;
            button.FillColor = Primary;
            button.Font = Font(9.5F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.HoverState.FillColor = PrimaryHover;
            button.PressedColor = PrimaryPressed;
            StyleDisabledState(button);
        }

        internal static void StyleSecondaryButton(Guna2Button button)
        {
            button.Animated = true;
            button.BorderColor = Border;
            button.BorderRadius = 8;
            button.BorderThickness = 1;
            button.Cursor = Cursors.Hand;
            button.FillColor = Surface;
            button.Font = Font(9F, FontStyle.Bold);
            button.ForeColor = HeaderDeep;
            button.HoverState.BorderColor = Primary;
            button.HoverState.FillColor = SurfaceTint;
            button.PressedColor = Color.FromArgb(209, 250, 229);
            StyleDisabledState(button);
        }

        internal static void StyleDangerButton(Guna2Button button)
        {
            button.Animated = true;
            button.BorderRadius = 8;
            button.BorderThickness = 0;
            button.Cursor = Cursors.Hand;
            button.FillColor = Danger;
            button.Font = Font(9F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.HoverState.FillColor = DangerHover;
            button.PressedColor = Color.FromArgb(127, 29, 29);
            StyleDisabledState(button);
        }

        internal static void StyleDisabledState(Guna2Button button)
        {
            button.DisabledState.BorderColor = Color.FromArgb(193, 202, 211);
            button.DisabledState.CustomBorderColor = Color.FromArgb(193, 202, 211);
            button.DisabledState.FillColor = DisabledFill;
            button.DisabledState.ForeColor = DisabledText;
        }

        internal static void StyleTextBox(Guna2TextBox textBox)
        {
            textBox.Animated = true;
            textBox.BorderColor = Border;
            textBox.BorderRadius = 8;
            textBox.BorderThickness = 1;
            textBox.Cursor = Cursors.IBeam;
            textBox.FillColor = Color.FromArgb(253, 254, 254);
            textBox.FocusedState.BorderColor = Primary;
            textBox.Font = Font(9F);
            textBox.ForeColor = Ink;
            textBox.HoverState.BorderColor = MutedLight;
            textBox.PlaceholderForeColor = MutedLight;
            textBox.DisabledState.BorderColor = Border;
            textBox.DisabledState.FillColor = SurfaceSoft;
            textBox.DisabledState.ForeColor = Muted;
            textBox.DisabledState.PlaceholderForeColor = MutedLight;
        }

        internal static void SetInputError(Guna2TextBox textBox, bool hasError)
        {
            if (textBox == null)
            {
                return;
            }

            textBox.BorderColor = hasError ? Danger : Border;
            textBox.FocusedState.BorderColor = hasError ? Danger : Primary;
        }

        internal static void StyleComboBox(Guna2ComboBox comboBox)
        {
            comboBox.Animated = true;
            comboBox.BackColor = Color.Transparent;
            comboBox.BorderColor = Border;
            comboBox.BorderRadius = 8;
            comboBox.BorderThickness = 1;
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FillColor = Color.FromArgb(253, 254, 254);
            comboBox.FocusedState.BorderColor = Primary;
            comboBox.Font = Font(9F);
            comboBox.ForeColor = Ink;
            comboBox.HoverState.BorderColor = MutedLight;
            comboBox.ItemHeight = 30;
            comboBox.ItemsAppearance.BackColor = Surface;
            comboBox.ItemsAppearance.ForeColor = Text;
            comboBox.ItemsAppearance.SelectedBackColor = SurfaceTint;
            comboBox.ItemsAppearance.SelectedForeColor = Ink;
            comboBox.MaxDropDownItems = 8;
        }

        internal static void StyleRadio(Guna2RadioButton radioButton, Color accentColor)
        {
            radioButton.BackColor = Color.Transparent;
            radioButton.CheckedState.BorderColor = accentColor;
            radioButton.CheckedState.BorderThickness = 2;
            radioButton.CheckedState.FillColor = accentColor;
            radioButton.CheckedState.InnerColor = Color.White;
            radioButton.Font = Font(9F, FontStyle.Bold);
            radioButton.ForeColor = Text;
            radioButton.UncheckedState.BorderColor = Border;
            radioButton.UncheckedState.BorderThickness = 2;
            radioButton.UncheckedState.FillColor = Surface;
            radioButton.UncheckedState.InnerColor = Surface;
        }

        internal static void StyleGrid(Guna2DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 252)
            };
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = HeaderPanel,
                Font = Font(9F, FontStyle.Bold),
                ForeColor = Color.White,
                Padding = new Padding(8, 0, 8, 0),
                SelectionBackColor = HeaderPanel,
                SelectionForeColor = Color.White,
                WrapMode = DataGridViewTriState.True
            };
            grid.ColumnHeadersHeight = 38;
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Surface,
                Font = Font(8.8F),
                ForeColor = Ink,
                Padding = new Padding(8, 0, 8, 0),
                SelectionBackColor = Color.FromArgb(214, 244, 238),
                SelectionForeColor = Ink,
                WrapMode = DataGridViewTriState.False
            };
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Color.FromArgb(226, 235, 241);
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 40;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SetDoubleBuffered(grid);
        }

        internal static void StyleMutedLabel(Label label)
        {
            label.BackColor = Color.Transparent;
            label.Font = Font(8.7F);
            label.ForeColor = Muted;
        }

        internal static void StyleInlineValidationLabel(Label label)
        {
            label.AutoEllipsis = true;
            label.BackColor = Color.Transparent;
            label.Font = Font(8.4F, FontStyle.Bold);
            label.ForeColor = Danger;
            label.Visible = false;
        }

        internal static void SetDoubleBuffered(Control control)
        {
            if (control == null)
            {
                return;
            }

            try
            {
                PropertyInfo property = typeof(Control).GetProperty(
                    "DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                property?.SetValue(control, true, null);
            }
            catch
            {
                // Double buffering is a visual optimization only.
            }
        }

        internal static Color GetStatusColor(string status)
        {
            switch (NormalizeStatus(status))
            {
                case "approved":
                case "returned":
                case "found":
                case "ditemukan":
                case "dikembalikan":
                case "kembali":
                case "siap klaim":
                    return Success;
                case "lost":
                case "missing":
                case "hilang":
                case "rejected":
                case "ditolak":
                    return Danger;
                case "pending":
                case "menunggu":
                case "klaim aktif":
                    return Warning;
                default:
                    return Info;
            }
        }

        internal static Color GetStatusSoftColor(string status)
        {
            Color color = GetStatusColor(status);
            return Color.FromArgb(
                color.R + (255 - color.R) * 3 / 4,
                color.G + (255 - color.G) * 3 / 4,
                color.B + (255 - color.B) * 3 / 4);
        }

        internal static void AttachStatusBadgeRenderer(Guna2DataGridView grid, params string[] columnNames)
        {
            if (grid == null || columnNames == null || columnNames.Length == 0)
            {
                return;
            }

            GridBadgeState state = GridBadgeStates.GetValue(grid, _ => new GridBadgeState());

            foreach (string columnName in columnNames)
            {
                if (!string.IsNullOrWhiteSpace(columnName) && !state.Contains(columnName))
                {
                    state.Columns.Add(columnName);
                }
            }

            if (!state.Attached)
            {
                grid.CellPainting += StatusGrid_CellPainting;
                state.Attached = true;
            }

            grid.Invalidate();
        }

        private static void StatusGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            GridBadgeState state;
            if (!GridBadgeStates.TryGetValue(grid, out state))
            {
                return;
            }

            string columnName = grid.Columns[e.ColumnIndex].Name;
            if (!state.Contains(columnName))
            {
                return;
            }

            string badgeText = GetBadgeDisplayText(columnName, e.Value);
            Color badgeColor = GetStatusColor(badgeText);
            Color badgeSoftColor = GetStatusSoftColor(badgeText);
            bool selected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
            Color cellBack = selected
                ? grid.DefaultCellStyle.SelectionBackColor
                : (e.RowIndex % 2 == 1 ? grid.AlternatingRowsDefaultCellStyle.BackColor : e.CellStyle.BackColor);

            using (SolidBrush backBrush = new SolidBrush(cellBack))
            using (Pen linePen = new Pen(grid.GridColor))
            {
                e.Graphics.FillRectangle(backBrush, e.CellBounds);
                e.Graphics.DrawLine(linePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }

            using (Font badgeFont = Font(8F, FontStyle.Bold))
            {
                Size textSize = TextRenderer.MeasureText(e.Graphics, badgeText, badgeFont);
                int badgeWidth = Math.Min(e.CellBounds.Width - 18, Math.Max(74, textSize.Width + 22));
                int badgeHeight = Math.Min(24, e.CellBounds.Height - 10);
                Rectangle badgeBounds = new Rectangle(
                    e.CellBounds.Left + 9,
                    e.CellBounds.Top + (e.CellBounds.Height - badgeHeight) / 2,
                    badgeWidth,
                    badgeHeight);

                using (GraphicsPath path = RoundedRect(badgeBounds, 7))
                using (SolidBrush fillBrush = new SolidBrush(badgeSoftColor))
                using (Pen borderPen = new Pen(Color.FromArgb(110, badgeColor)))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(fillBrush, path);
                    e.Graphics.DrawPath(borderPen, path);
                }

                Rectangle textBounds = new Rectangle(
                    badgeBounds.Left + 10,
                    badgeBounds.Top + 1,
                    badgeBounds.Width - 20,
                    badgeBounds.Height - 2);
                TextRenderer.DrawText(
                    e.Graphics,
                    badgeText,
                    badgeFont,
                    textBounds,
                    badgeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            }

            e.Handled = true;
        }

        private static string GetBadgeDisplayText(string columnName, object value)
        {
            string text = value == null || value == DBNull.Value ? string.Empty : Convert.ToString(value);

            if (string.Equals(columnName, "ActiveClaims", StringComparison.OrdinalIgnoreCase))
            {
                int activeClaims;
                if (int.TryParse(text, out activeClaims))
                {
                    return activeClaims > 0 ? "Klaim aktif" : "Siap klaim";
                }
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                return "Tidak ada";
            }

            return text;
        }

        private static string NormalizeStatus(string status)
        {
            return string.IsNullOrWhiteSpace(status)
                ? string.Empty
                : status.Trim().ToLowerInvariant();
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        internal static void ShowInfo(Form owner, string text)
        {
            ShowMessage(owner, text, "Lost and Found", MessageDialogIcon.Information);
        }

        internal static void ShowWarning(Form owner, string text)
        {
            ShowMessage(owner, text, "Perhatian", MessageDialogIcon.Warning);
        }

        internal static void ShowError(Form owner, string text)
        {
            ShowMessage(owner, text, "Error", MessageDialogIcon.Error);
        }

        private static DialogResult ShowMessage(Form owner, string text, string caption, MessageDialogIcon icon)
        {
            using (var dialog = new Guna2MessageDialog())
            {
                dialog.Parent = owner;
                dialog.Buttons = MessageDialogButtons.OK;
                dialog.Caption = caption;
                dialog.Icon = icon;
                dialog.Style = MessageDialogStyle.Light;
                return dialog.Show(text, caption);
            }
        }

        private sealed class GridBadgeState
        {
            internal readonly List<string> Columns = new List<string>();
            internal bool Attached;

            internal bool Contains(string columnName)
            {
                foreach (string item in Columns)
                {
                    if (string.Equals(item, columnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
