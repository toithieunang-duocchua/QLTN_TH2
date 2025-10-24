using QLTN.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace QLTN.Forms
{
    public partial class FormMainSystem : ThemedForm
    {
        private static readonly Size TargetFormSize = new Size(1024, 576);
        string path = Path.Combine(Application.StartupPath, "Assets", "logo.png");
        private Panel sidebar;
        private Panel mainPanel;

        public FormMainSystem()
        {
            InitializeComponent();
            SetupForm();     
            LoadWpfControl(); 
        }

        private void LoadWpfControl()
        {
            // Tạo ElementHost chứa WPF UserControl
            ElementHost host = new ElementHost
            {
                Dock = DockStyle.Fill,
                Child = new FormTenantManagerment()
            };

            mainPanel.Controls.Clear();
            this.Controls.Add(host);
        }

        private void SetupForm()
        {
            Text = "H\u1EC7 th\u1ED1ng QLTN - Trang ch\u00EDnh";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;


            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = Color.White
            };


            PictureBox logo = new PictureBox
            {
                Image = Image.FromFile(path),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Height = 100
            };
            sidebar.Controls.Add(logo);

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                Padding = new Padding(0, 0, 0, 10)
            };


            Controls.Add(mainPanel);
            Controls.Add(sidebar);

            AuthNavigationManager.Initialize(mainPanel);

            AddSidebarButton("\uf52b", "Nhà && Phòng", (s, e) => ShowMessage("Hợp đồng"));
            AddSidebarButton("\uf0c0", "Người thuê", (s, e) => AuthNavigationManager.LoadWpfControl<FormTenantManagerment>());
            AddSidebarButton("\uf15c", "Hợp đồng", (s, e) => ShowMessage("Hợp đồng"));
            AddSidebarButton("\uf555", "Tài chính", (s, e) => ShowMessage("Tài chính"));
            AddSidebarButton("\uf53a", "Thanh Toán", (s, e) => ShowMessage("Thanh Toán"));
            AddSidebarButton("\uf201", "Báo cáo && Thống kê", (s, e) => ShowMessage("Báo cáo & Thống kê"));
            AddSidebarButton("\uf071", "Quản lý sự cố", (s, e) => ShowMessage("Quản lý sự cố"));
            AddSidebarButton("\uf007", "Accounts", (s, e) => Application.Exit());

        }

        private Panel AddSidebarButton(string icon, string txt, EventHandler onClick)
        {
            Panel itemPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Icon
            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Font Awesome 7 Free Solid", 16, FontStyle.Regular),
                Dock = DockStyle.Left,
                Width = 45,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Text
            Label lblText = new Label
            {
                Text = txt,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            // Hover effect
            itemPanel.MouseEnter += (s, e) =>
            {
                itemPanel.BackColor = Color.FromArgb(254, 140, 27);
                lblText.Font = new Font(lblText.Font, FontStyle.Bold);
            };

            itemPanel.MouseLeave += (s, e) =>
            {
                itemPanel.BackColor = Color.White;
                lblText.Font = new Font(lblText.Font, FontStyle.Regular);
            };

            // Click event
            itemPanel.Click += onClick;
            lblIcon.Click += onClick;
            lblText.Click += onClick;

            itemPanel.Controls.Add(lblText);
            itemPanel.Controls.Add(lblIcon);
            sidebar.Controls.Add(itemPanel);
            sidebar.Controls.SetChildIndex(itemPanel, 0);

            return itemPanel;
        }

        //Test0
        private void ShowMessage(string msg)
        {
            if ((mainPanel) == null) return;

            mainPanel.Controls.Clear();

            Label lbl = new Label
            {
                Dock = DockStyle.Fill,
                Text = msg,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            mainPanel.Controls.Add(lbl);
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
