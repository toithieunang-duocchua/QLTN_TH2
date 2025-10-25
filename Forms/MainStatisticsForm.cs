using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    /// <summary>
    /// Placeholder view for analytics and statistics.
    /// </summary>
    public sealed class MainStatisticsForm : ThemedForm
    {
        public MainStatisticsForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Thống kê - Hệ thống QLTN";

            Panel surface = CreateSurfacePanel(new Size(860, 520));
            surface.Anchor = AnchorStyles.None;
            Controls.Add(surface);
            AttachCentering(surface);

            Label label = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Text = "Giao diện thống kê\nSẽ được bổ sung sau."
            };
            surface.Controls.Add(label);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainStatisticsForm";
            Text = "Thống kê";
            ResumeLayout(false);
        }
    }
}
