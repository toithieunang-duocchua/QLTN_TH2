using System.Drawing;
using System.Drawing.Drawing2D;

namespace QLTN.Forms
{
    internal static class GraphicsPathRoundedExtensions
    {
        public static void AddRoundedRectanglePath(this GraphicsPath path, Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
        }
    }
}
