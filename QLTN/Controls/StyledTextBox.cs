using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Controls
{
    public enum ValidationState
    {
        Neutral,
        Error,
        Success
    }

    public class StyledTextBox : TextBox
    {
        private const int WM_NCPAINT = 0x85;
        private const int WM_PAINT = 0x0F;
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_SIZE = 0x05;

        private ValidationState validationState = ValidationState.Neutral;

        public StyledTextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            DoubleBuffered = true;
            Resize += (_, __) => Invalidate();
        }

        public Color NeutralBorderColor { get; set; } = Color.FromArgb(90, 90, 90);
        public Color ErrorBorderColor { get; set; } = Color.FromArgb(220, 70, 70);
        public Color SuccessBorderColor { get; set; } = Color.FromArgb(70, 180, 120);

        public ValidationState ValidationState => validationState;

        public void SetValidationState(ValidationState state)
        {
            validationState = state;
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT || m.Msg == WM_NCPAINT || m.Msg == WM_ERASEBKGND || m.Msg == WM_SIZE)
            {
                DrawBorder();
            }
        }

        private void DrawBorder()
        {
            Color color = NeutralBorderColor;
            if (validationState == ValidationState.Error)
            {
                color = ErrorBorderColor;
            }
            else if (validationState == ValidationState.Success)
            {
                color = SuccessBorderColor;
            }

            using (Graphics graphics = Graphics.FromHwnd(Handle))
            using (Pen pen = new Pen(color, 2))
            {
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
