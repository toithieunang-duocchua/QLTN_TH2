using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormListHouse : ThemedForm
    {
        private Panel topPanel;
        private Panel contentPanel;
        private Panel headerPanel;
        private Panel bottomPanel;
        private static readonly Size TargetFormSize = new Size(1024 - 250, 576);

        public FormListHouse()
        {
            InitializeComponent();
            SetupForm();
        }
        public FormListHouse(Panel parent) : this()
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
                Text = "Nhà && Phòng",
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
            CreateHeader();

            
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240),
                AutoScroll = true,
                Padding = new Padding(15, 5, 15, 5)
            };

            bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(234, 234, 234),
                Padding = new Padding(5)
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
            bottomPanel.Controls.Add(btnContainer);

            AddButton(btnContainer, "\uf2ed", "Xóa", null);
            AddButton(btnContainer, "\uf044", "Sửa", (s, e) => AuthNavigationManager.Navigate<FormEditHouse>());
            AddButton(btnContainer, "\uf015", "Thêm", (s, e) => AuthNavigationManager.Navigate<FormAddHouse>());


            mainContainer.Controls.Add(contentPanel);
            mainContainer.Controls.Add(bottomPanel);
            mainContainer.Controls.Add(headerPanel);
            mainContainer.Controls.Add(topPanel);

            Controls.Add(mainContainer);

            //
            // ====== TEST ======
            //
            AddHouseItem("Nhà A", "12/10/2025", 0);
            AddHouseItem("Nhà B", "16/10/2025", 50);
        }

        private void CreateHeader()
        {
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            Label lblName = new Label
            {
                Text = "Tên nhà",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDate = new Label
            {
                Text = "Ngày sửa đổi",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblOwner = new Label
            {
                Text = "Chú thích",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            table.Controls.Add(lblName, 0, 0);
            table.Controls.Add(lblDate, 1, 0);
            table.Controls.Add(lblOwner, 2, 0);

            headerPanel.Controls.Add(table);
        }

        private void AddHouseItem(string houseName, string date, int yPos)
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
                Tag = houseName
            };

            TableLayoutPanel row = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            Label name = new Label
            {
                Text = houseName,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(254, 140, 27),
                Tag = houseName
            };

            Label dateLabel = new Label
            {
                Text = date,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label owner = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            EventHandler showDetail = (s, e) =>
            {
                string tenToaNha = (s as Control)?.Tag?.ToString();
                if (!string.IsNullOrEmpty(tenToaNha))
                {
                    AuthNavigationManager.Navigate<FormListRoom>();
                }
            };
            name.Click += showDetail;
            panel.Click += showDetail;
            row.Click += showDetail;
            wrapper.Click += showDetail;

            row.Controls.Add(name, 0, 0);
            row.Controls.Add(dateLabel, 1, 0);
            row.Controls.Add(owner, 2, 0);

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
            Name = "FormListHouse";
            Text = "Hệ thống QLTN";
            ResumeLayout(false);
        }
    }
}
