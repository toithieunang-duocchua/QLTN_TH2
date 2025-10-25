using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    /// <summary>
    /// Placeholder workspace for incident and maintenance tracking.
    /// </summary>
    public sealed class MainIssueManagementForm : ThemedForm
    {
        public MainIssueManagementForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Quản lý sự cố - Hệ thống QLTN";

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
                Text = "Quản lý sự cố & bảo trì\nĐang phát triển."
            };
            surface.Controls.Add(label);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainIssueManagementForm";
            Text = "Quản lý sự cố";
            ResumeLayout(false);
        }
    }
}
