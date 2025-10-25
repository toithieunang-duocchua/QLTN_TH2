using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Provides a shared look & feel that mirrors the HTML prototype:
    /// - Fullscreen background image with a dark overlay
    /// - Rounded translucent content surfaces
    /// - Consistent accent colours for primary actions and links
    /// - Utility helpers to centre content and style common controls
    /// </summary>
    public class ThemedForm : Form
    {
        protected static readonly Color SurfaceColor = Color.FromArgb(217, 50, 50, 50);
        protected static readonly Color SurfaceBorderColor = Color.FromArgb(80, 255, 255, 255);
        protected static readonly Color PrimaryAccentColor = Color.FromArgb(255, 51, 51);
        protected static readonly Color PrimaryAccentHoverColor = Color.FromArgb(230, 46, 46);
        protected static readonly Color PrimaryAccentPressedColor = Color.FromArgb(200, 40, 40);
        protected static readonly Color SecondaryTextColor = Color.FromArgb(204, 204, 204);
        protected static readonly Color InputBackColor = Color.FromArgb(55, 55, 55);
        protected static readonly Color InputFocusBackColor = Color.FromArgb(70, 70, 70);

        protected ThemedForm()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            BackColor = Color.Black;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return createParams;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            Color target = Parent?.BackColor ?? Color.Black;
            if (target == Color.Transparent)
            {
                target = Color.Black;
            }

            BackColor = target;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!ShouldRenderOwnBackground())
            {
                base.OnPaintBackground(e);
                return;
            }

            e.Graphics.Clear(Color.White);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;
            if (m.Msg == WM_ERASEBKGND)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }

        private bool ShouldRenderOwnBackground()
        {
            return Parent == null || ReferenceEquals(TopLevelControl, this);
        }

        /// <summary>
        /// Creates a rounded surface panel that mimics the blurred glass panel from the HTML prototype.
        /// The caller is responsible for positioning the panel (typically by calling <see cref="AttachCentering"/>).
        /// </summary>
        protected Panel CreateSurfacePanel(Size size, int cornerRadius = 12)
        {
            SurfacePanel panel = new SurfacePanel
            {
                Size = size,
                BackColor = Color.Transparent
            };

            panel.Paint += (sender, args) => PaintSurfacePanel(panel, args, cornerRadius);

            return panel;
        }

        private static void PaintSurfacePanel(Control panel, PaintEventArgs e, int cornerRadius)
        {
            Rectangle bounds = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRoundedRectanglePath(bounds, cornerRadius);

                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
                {
                    Rectangle shadowRect = bounds;
                    shadowRect.Offset(4, 6);
                    using (GraphicsPath shadowPath = new GraphicsPath())
                    {
                        shadowPath.AddRoundedRectanglePath(shadowRect, cornerRadius + 2);
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }

                using (SolidBrush fillBrush = new SolidBrush(SurfaceColor))
                {
                    e.Graphics.FillPath(fillBrush, path);
                }

                using (Pen borderPen = new Pen(SurfaceBorderColor))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        /// <summary>
        /// Keeps the specified control centred within the form whenever the form is resized.
        /// </summary>
        protected void AttachCentering(Control control)
        {
            CenterControl(control);
            Resize += (_, __) => CenterControl(control);
        }

        protected void CenterControl(Control control)
        {
            if (control?.Parent == null)
            {
                return;
            }

            int x = Math.Max((control.Parent.ClientSize.Width - control.Width) / 2, 0);
            int y = Math.Max((control.Parent.ClientSize.Height - control.Height) / 2, 0);
            control.Location = new Point(x, y);
        }

        protected static int CenterContentX(int parentWidth, int contentWidth)
        {
            return Math.Max((parentWidth - contentWidth) / 2, 0);
        }

        /// <summary>
        /// Applies the accent styling and hover feedback used by the HTML prototype to a primary action button.
        /// </summary>
        protected void StylePrimaryButton(Button button)
        {
            if (button == null)
            {
                return;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = PrimaryAccentColor;
            button.ForeColor = Color.White;
            button.Cursor = Cursors.Hand;

            button.MouseEnter -= PrimaryButtonMouseEnter;
            button.MouseLeave -= PrimaryButtonMouseLeave;
            button.MouseDown -= PrimaryButtonMouseDown;
            button.MouseUp -= PrimaryButtonMouseUp;

            button.MouseEnter += PrimaryButtonMouseEnter;
            button.MouseLeave += PrimaryButtonMouseLeave;
            button.MouseDown += PrimaryButtonMouseDown;
            button.MouseUp += PrimaryButtonMouseUp;
        }

        private void PrimaryButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = PrimaryAccentHoverColor;
            }
        }

        private void PrimaryButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = PrimaryAccentColor;
            }
        }

        private void PrimaryButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button && e.Button == MouseButtons.Left)
            {
                button.BackColor = PrimaryAccentPressedColor;
                button.Padding = new Padding(button.Padding.Left, button.Padding.Top + 1, button.Padding.Right, button.Padding.Bottom - 1);
            }
        }

        private void PrimaryButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (sender is Button button)
            {
                button.Padding = new Padding(button.Padding.Left, Math.Max(button.Padding.Top - 1, 0), button.Padding.Right, button.Padding.Bottom + 1);
                Point cursor = button.PointToClient(Cursor.Position);
                if (button.ClientRectangle.Contains(cursor))
                {
                    button.BackColor = PrimaryAccentHoverColor;
                }
                else
                {
                    button.BackColor = PrimaryAccentColor;
                }
            }
        }

        /// <summary>
        /// Applies the muted grey link style from the prototype, including hover feedback.
        /// </summary>
        protected void StyleMutedLink(LinkLabel link)
        {
            if (link == null)
            {
                return;
            }

            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.LinkColor = SecondaryTextColor;
            link.ActiveLinkColor = Color.White;
            link.VisitedLinkColor = SecondaryTextColor;

            link.MouseEnter -= LinkMouseEnter;
            link.MouseLeave -= LinkMouseLeave;
            link.MouseEnter += LinkMouseEnter;
            link.MouseLeave += LinkMouseLeave;
        }

        private void LinkMouseEnter(object sender, EventArgs e)
        {
            if (sender is LinkLabel link)
            {
                link.LinkColor = Color.White;
            }
        }

        private void LinkMouseLeave(object sender, EventArgs e)
        {
            if (sender is LinkLabel link)
            {
                link.LinkColor = SecondaryTextColor;
            }
        }

        /// <summary>
        /// Applies consistent styling to text inputs, including subtle focus feedback.
        /// </summary>
        protected void StyleInputTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                return;
            }

            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = InputBackColor;
            textBox.ForeColor = Color.White;
            textBox.Margin = Padding.Empty;

            textBox.Enter -= InputTextBoxEnter;
            textBox.Leave -= InputTextBoxLeave;

            textBox.Enter += InputTextBoxEnter;
            textBox.Leave += InputTextBoxLeave;

            SetValidationState(textBox, ValidationState.Neutral);
        }

        private void InputTextBoxEnter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = InputFocusBackColor;
            }
        }

        private void InputTextBoxLeave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = InputBackColor;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected void SetValidationState(TextBox textBox, ValidationState state)
        {
            if (textBox is StyledTextBox styledTextBox)
            {
                styledTextBox.SetValidationState(state);
            }
        }

        protected void ResetValidationStates(params TextBox[] textBoxes)
        {
            if (textBoxes == null)
            {
                return;
            }

            foreach (TextBox textBox in textBoxes)
            {
                SetValidationState(textBox, ValidationState.Neutral);
            }
        }

        private sealed class SurfacePanel : Panel
        {
            public SurfacePanel()
            {
                DoubleBuffered = true;
                ResizeRedraw = true;
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw, true);
                UpdateStyles();
                BackColor = Color.Transparent;
            }
        }

        protected TControl FindControlRecursive<TControl>(string controlName) where TControl : Control
        {
            if (string.IsNullOrEmpty(controlName))
            {
                return null;
            }

            Control[] matches = Controls.Find(controlName, true);
            return matches.Length > 0 ? matches[0] as TControl : null;
        }

        public static void ApplyRoundedCorners(Control control, int radius, Corners corners)
        {
            if (control.Width == 0 || control.Height == 0) return;

            GraphicsPath path = new GraphicsPath();

            int w = control.Width;
            int h = control.Height;

            bool topLeft = corners.HasFlag(Corners.TopLeft);
            bool topRight = corners.HasFlag(Corners.TopRight);
            bool bottomLeft = corners.HasFlag(Corners.BottomLeft);
            bool bottomRight = corners.HasFlag(Corners.BottomRight);

            // B?t ??u t? góc trên trái
            if (topLeft)
                path.AddArc(0, 0, radius, radius, 180, 90);
            else
                path.AddLine(0, 0, radius, 0);

            // Trên ph?i
            if (topRight)
                path.AddArc(w - radius, 0, radius, radius, 270, 90);
            else
                path.AddLine(w, 0, w, radius);

            // D??i ph?i
            if (bottomRight)
                path.AddArc(w - radius, h - radius, radius, radius, 0, 90);
            else
                path.AddLine(w, h, w - radius, h);

            // D??i trái
            if (bottomLeft)
                path.AddArc(0, h - radius, radius, radius, 90, 90);
            else
                path.AddLine(0, h, 0, h - radius);

            path.CloseAllFigures();
            control.Region = new Region(path);
        }


        [System.Flags]
        public enum Corners
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 4,
            BottomLeft = 8,
            All = TopLeft | TopRight | BottomRight | BottomLeft
        }

    }
}
