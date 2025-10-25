using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace QLTN.Forms
{
    public class FormRoomDetail : ThemedForm
    {
        private TextBox txtName, txtArea, txtCode, txtFloors, txtAddress, txtRooms;
        private static readonly Size TargetFormSize = new Size(1024 - 250, 576);
        private Panel topPanel;
        public FormRoomDetail()
        {
            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = TargetFormSize;
            Name = "FormEditHouse";
            Text = "Chỉnh sửa thông tin nhà";
            ResumeLayout(false);
        }

        private void SetupForm()
        {
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(243, 243, 243)
            };

            TableLayoutPanel topLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            Label Name = new Label
            {
                Text = "Tên Tòa Nhà",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            Label roomCode = new Label
            {
                Text = "Mã số phòng",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };


            topLayout.Controls.Add(Name, 0, 0);
            topLayout.Controls.Add(roomCode, 1, 0);
            topPanel.Controls.Add(topLayout);



            //======== Mainlayout ========
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(40, 24, 40, 24),
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None
            };

            mainLayout.ColumnStyles.Clear();
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            mainLayout.RowStyles.Clear();
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));


            AddField(mainLayout, "Tên người thuê", out txtName, 0, 0);
            AddField(mainLayout, "Nội thất", out txtArea, 0, 1);
            AddField(mainLayout, "Diện tích", out txtCode, 1, 0);
            AddField(mainLayout, "Giá thuê", out txtFloors, 1, 1);
            AddField(mainLayout, "Trạng thái", out txtAddress, 2, 0);
            AddField(mainLayout, "Ghi chú", out txtRooms, 2, 1);

            Panel centerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(0, topPanel.Height + 10, 0, 0)
            };

            centerPanel.Controls.Add(mainLayout);
            mainLayout.Location = new Point(
                (centerPanel.Width - mainLayout.Width) / 2,
                (centerPanel.Height - mainLayout.Height) / 2
            );
            centerPanel.Resize += (s, e) =>
            {
                mainLayout.Location = new Point(
                    (centerPanel.Width - mainLayout.Width) / 2,
                    (centerPanel.Height - mainLayout.Height) / 2
                );
            };

            // ===== Thêm vào Form =====
            Controls.Add(centerPanel);
            Controls.Add(topPanel);
        }

        private void AddField(TableLayoutPanel parent, string labelText, out TextBox textBox, int row, int col)
        {
            // Cam
            Panel outerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
                Padding = new Padding(14, 5, 14, 5),
                BackColor = Color.FromArgb(255, 140, 27),
                MinimumSize = new Size(0, 80),
            };
            outerPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(outerPanel, true, null);

            outerPanel.Paint += (s, e) =>
            {
                ApplyRoundedCorners(outerPanel, 8, Corners.All);
            };

            Label label = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Dock = DockStyle.Top,
                Height = 26,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Padding = new Padding(6, 2, 0, 0)
            };

            // Xám
            Panel textPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(245, 245, 245),
                Margin = new Padding(5, 8, 5, 0),
            };
            textPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(textPanel, true, null);

            textPanel.Paint += (s, e) =>
            {
                ApplyRoundedCorners(textPanel, 8, Corners.All);
            };

            // TextBox
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = textPanel.BackColor,
                Margin = new Padding(10, 6, 10, 6)
            };


            textPanel.Controls.Add(textBox);
            outerPanel.Controls.Add(textPanel);
            outerPanel.Controls.Add(label);
            parent.Controls.Add(outerPanel, col, row);
        }


    }
}
