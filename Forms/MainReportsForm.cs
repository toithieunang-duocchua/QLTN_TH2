using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    /// <summary>
    /// Placeholder module for reporting dashboards.
    /// </summary>
    public sealed class MainReportsForm : ThemedForm
    {
        public MainReportsForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Báo cáo - Hệ thống QLTN";

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
                Text = "Màn hình báo cáo\nĐang chờ cập nhật."
            };
            surface.Controls.Add(label);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainReportsForm";
            Text = "Báo cáo";
            ResumeLayout(false);
        }
    }
}
