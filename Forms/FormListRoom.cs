using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormListRoom : ThemedForm
    {
        private Panel topPanel;
        private Panel contentPanel;
        private Panel headerPanel;
        private static readonly Size TargetFormSize = new Size(1024 - 250, 576);

        public FormListRoom()
        {
            InitializeComponent();
            SetupForm();
        }
        public FormListRoom(Panel parent) : this()
        {
            Panel parentPanel = parent;

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            parentPanel.Controls.Add(this);
            Show();
        }

        private void SetupForm()
        {
           

            Panel mainContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };


            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(234, 234, 234),
                Padding = new Padding(10)
            };
            Label pageTitle = new Label
            {
                Text = "tên phòng",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Black
            };
            topPanel.Controls.Add(pageTitle);

       
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(234, 234, 234),
                Padding = new Padding(15, 0, 15, 0)
            };


            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240),
                AutoScroll = true,
                Padding = new Padding(15, 5, 15, 5)
            };


            FlowLayoutPanel btnContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            AddButton(btnContainer, "\uf2ed", "Xóa", null);
            AddButton(btnContainer, "\uf015", "Thêm", (s, e) => AuthNavigationManager.Navigate<FormAddHouse>());

            mainContainer.Controls.Add(contentPanel);
            mainContainer.Controls.Add(headerPanel);
            mainContainer.Controls.Add(topPanel);

            Controls.Add(mainContainer);

            //
            // ====== TEST ======
            //
            AddRoomItem("Phòng a", "Đang thuê");
            AddRoomItem("Phòng b", "Trống");
        }


        private void AddRoomItem(string roomName, string status)
        {
            Panel wrapper = new Panel
            {
                Height = 50,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 0, 0, 5),
                BackColor = Color.Transparent
            };

            Panel panel = new Panel
            {
                Height = 45,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(234, 234, 234),
                Cursor = Cursors.Hand,
                Margin = new Padding(0),
                Tag = roomName
            };

            TableLayoutPanel row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); 
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); 

            Label name = new Label
            {
                Text = roomName,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(254, 140, 27),
                Padding = new Padding(20, 0, 0, 0),
                Tag = roomName
            };

            Button statusBtn = new Button
            {
                Text = status,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Dock = DockStyle.Right,
                Width = 200,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
                Height = 45,
                Margin = new Padding(0, 0, 0, 0)
            };
            statusBtn.FlatAppearance.BorderSize = 0;
            statusBtn.BackColor = status == "Trống"
                ? Color.FromArgb(254, 140, 27)
                : Color.FromArgb(255, 172, 73);

            statusBtn.Resize += (s, e) =>
            ApplyRoundedCorners(statusBtn, 40, Corners.TopLeft | Corners.BottomLeft);


            EventHandler showDetail = (s, e) =>
            {
                string tenPhong = (s as Control)?.Tag?.ToString();
                if (!string.IsNullOrEmpty(tenPhong))
                {
                    AuthNavigationManager.Navigate<FormRoomDetail>();
                }
            };


            name.Click += showDetail;
            panel.Click += showDetail;

            row.Controls.Add(name, 0, 0);
            row.Controls.Add(statusBtn, 1, 0);

            panel.Controls.Add(row);
            wrapper.Controls.Add(panel);

            contentPanel.Controls.Add(wrapper);
            contentPanel.Controls.SetChildIndex(wrapper, 0);
        }


        private void AddButton(FlowLayoutPanel parent, string icon, string txt, EventHandler onClick)
        {

            Color defaultBack = Color.FromArgb(234, 234, 234);
            Color hoverBack = Color.FromArgb(80, 80, 80);
            Color defaultFore = Color.Black;
            Color hoverFore = Color.White;

            Panel btnPanel = new Panel
            {
                Width = 100,
                Height = 40,
                BackColor = defaultBack,
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 5, 5, 5),
                Anchor = AnchorStyles.None

            };


            Label ic = new Label
            {
                Text = icon,
                Font = new Font("Font Awesome 7 Free Solid", 13, FontStyle.Regular),
                Dock = DockStyle.Left,
                Width = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = defaultFore,
                Margin = new Padding(10, 5, 5, 0)
            };

            Label text = new Label
            {
                Text = txt,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = defaultFore,
                Margin = new Padding(0, 0, 10, 0),
            };

            if (onClick != null)
            {
                btnPanel.Click += onClick;
                ic.Click += onClick;
                text.Click += onClick;
            }


            EventHandler mouseEnter = (s, e) => {
                btnPanel.BackColor = hoverBack;
                ic.ForeColor = hoverFore;
                text.ForeColor = hoverFore;
            };

            EventHandler mouseLeave = (s, e) => {
                btnPanel.BackColor = defaultBack;
                ic.ForeColor = defaultFore;
                text.ForeColor = defaultFore;
            };

            btnPanel.MouseEnter += mouseEnter;
            btnPanel.MouseLeave += mouseLeave;


            ic.MouseEnter += mouseEnter;
            text.MouseEnter += mouseEnter;
            ic.MouseLeave += mouseLeave;
            text.MouseLeave += mouseLeave;

            btnPanel.Controls.Add(text);
            btnPanel.Controls.Add(ic);
            parent.Controls.Add(btnPanel);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormHouseAndRoom";
            Text = "Hệ thống QLTN";
            ResumeLayout(false);
        }
    }
}
