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

            Panel surface = CreateSurfacePanel(new Size(620, 360));
            surface.Anchor = AnchorStyles.None;
            Controls.Add(surface);
            AttachCentering(surface);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                Padding = new Padding(32),
                BackColor = Color.Transparent
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            surface.Controls.Add(layout);

            Label placeholderLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Text = "Trang ch\u00EDnh \u0111ang \u0111\u01B0\u1EE3c x\u00E2y d\u1EF1ng.\nVui l\u00F2ng quay l\u1EA1i menu ch\u00EDnh khi c\u1EA7n."
            };
            layout.Controls.Add(placeholderLabel, 0, 0);
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
