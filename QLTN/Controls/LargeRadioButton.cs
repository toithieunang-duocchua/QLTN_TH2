using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public class LargeRadioButton : RadioButton
    {
        private int glyphSize = 20;
        private const int GlyphPadding = 4;

        public LargeRadioButton()
        {
            AutoSize = false;
            Size = new Size(150, 36);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        public int GlyphSize
        {
            get => glyphSize;
            set
            {
                glyphSize = value < 12 ? 12 : value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);

            Rectangle glyphRect = new Rectangle(0, (Height - glyphSize) / 2, glyphSize, glyphSize);
            using (Pen pen = new Pen(ForeColor, 2))
            {
                e.Graphics.DrawEllipse(pen, glyphRect);
            }

            if (Checked)
            {
                Rectangle inner = Rectangle.Inflate(glyphRect, -GlyphPadding, -GlyphPadding);
                using (SolidBrush brush = new SolidBrush(ForeColor))
                {
                    e.Graphics.FillEllipse(brush, inner);
                }
            }

            Rectangle textRect = new Rectangle(glyphRect.Right + 10, 0, Width - glyphRect.Right - 10, Height);
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                textRect,
                ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            if (Focused && ShowFocusCues)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, textRect, ForeColor, BackColor);
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = glyphSize + (GlyphPadding * 2);
        }
    }
}
