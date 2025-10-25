using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    /// <summary>
    /// Placeholder view for account and profile settings.
    /// </summary>
    public sealed class MainAccountForm : ThemedForm
    {
        public MainAccountForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Tài khoản - Hệ thống QLTN";

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
                Text = "Cài đặt tài khoản\nĐang cập nhật."
            };
            surface.Controls.Add(label);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainAccountForm";
            Text = "Tài khoản";
            ResumeLayout(false);
        }
    }
}
