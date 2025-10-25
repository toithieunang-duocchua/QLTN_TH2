using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    /// <summary>
    /// Placeholder view for contract management until business logic is wired up.
    /// </summary>
    public sealed class MainContractsForm : ThemedForm
    {
        public MainContractsForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Hợp đồng - Hệ thống QLTN";

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
                Text = "Khu vực quản lý hợp đồng\nĐang chờ hoàn thiện nghiệp vụ."
            };
            surface.Controls.Add(label);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainContractsForm";
            Text = "Hợp đồng";
            ResumeLayout(false);
        }
    }
}
