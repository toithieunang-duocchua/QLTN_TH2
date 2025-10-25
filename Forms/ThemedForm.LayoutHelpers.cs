using System.Drawing;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    public partial class ThemedForm
    {
        protected FlowLayoutPanel CreateCenteredContentPanel(int width, out Panel surfacePanel, Padding? padding = null, double heightRatio = 0.85)
        {
            surfacePanel = CreateSurfacePanel(new Size(width, 100));
            surfacePanel.AutoSize = true;
            surfacePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            surfacePanel.MinimumSize = new Size(width, 0);
            surfacePanel.MaximumSize = new Size(width, (int)(ClientSize.Height * heightRatio));
            FlowLayoutPanel innerFlow = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Padding = padding ?? new Padding(36, 24, 36, 24),
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            surfacePanel.Controls.Add(innerFlow);
            Controls.Add(surfacePanel);
            AttachCentering(surfacePanel);
            Panel capturedPanel = surfacePanel;
            Resize += (_, __) =>
            {
                if (capturedPanel.IsDisposed)
                {
                    return;
                }
                capturedPanel.MaximumSize = new Size(width, (int)(ClientSize.Height * heightRatio));
                CenterControl(capturedPanel);
            };
            return innerFlow;
        }

        protected Panel CreateFieldGroup(string labelText, StyledTextBox textBox, int width, int bottomMargin = 14, int spacing = 6)
        {
            Panel group = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = width,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, bottomMargin)
            };
            Label label = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                Location = new Point(0, 0)
            };
            group.Controls.Add(label);
            textBox.Width = width;
            textBox.Location = new Point(0, label.Bottom + spacing);
            group.Controls.Add(textBox);
            group.Height = textBox.Bottom;
            return group;
        }
    }
}
