using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormMainSystem : ThemedForm
    {
        private static readonly Size TargetFormSize = new Size(1024, 576);

        public FormMainSystem()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "H\u1EC7 th\u1ED1ng QLTN - Trang ch\u00EDnh";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            Panel surface = CreateSurfacePanel(new Size(560, 320));
            surface.Anchor = AnchorStyles.None;
            Controls.Add(surface);
            AttachCentering(surface);

            Label placeholderLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Text = "Trang ch\u00EDnh \u0111ang \u0111\u01B0\u1EE3c x\u00E2y d\u1EF1ng.\nC\u00E1c ch\u1EE9c n\u0103ng s\u1EBD s\u1EDBm c\u00F3 m\u1EB7t."
            };

            surface.Controls.Add(placeholderLabel);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormMainSystem
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormMainSystem";
            Text = "H\u1EC7 th\u1ED1ng QLTN";
            ResumeLayout(false);
        }
    }
}
