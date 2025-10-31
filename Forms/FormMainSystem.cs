using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormMainSystem : ThemedForm
    {
        private static readonly Size TargetFormSize = new Size(1024, 576);
        string path = Path.Combine(Application.StartupPath, "Assets", "logo.png");

        private Panel sidebar, mainPanel, topPanel;
        private readonly ContractMonitorService contractMonitor = new ContractMonitorService();

        public FormMainSystem()
        {
            InitializeComponent();
            SetupForm();
            LoadWpfControl();
            contractMonitor.Start();
        }

        private void LoadWpfControl()
        {
            // For now, just show a message instead of WPF control
            ShowMessage("Người thuê - WPF Control sẽ được tích hợp sau");
        }

        public void LoadFormIntoMainPanel(Form form)
        {
            // Clear existing controls
            mainPanel.Controls.Clear();

            // Set form properties for proper layout
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill; // Fill the entire mainPanel
            
            // Add the form to mainPanel
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void SetupForm()
        {
            Text = "Hệ thống QLTN - Trang chính";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;


            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 270,
                BackColor = Color.White
            };


            PictureBox logo = new PictureBox
            {
                Image = Image.FromFile(path),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.White
            };
            sidebar.Controls.Add(logo);

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                Padding = new Padding(0, 0, 0, 10)
            };


            // ======= TOP PANEL =======
            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            // Tiêu đề lớn
            Label lblTitle = new Label
            {
                Text = "Đang xem:",
                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                AutoSize = true,
                Location = new Point(10, 10),
                BackColor = Color.White
            };
            topPanel.Controls.Add(lblTitle);

            // Tên nhà
            Label lblHouseName = new Label
            {
                Text = "Nhà A",
                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 200),
                AutoSize = true,
                Location = new Point(lblTitle.Right + 120, 10),
                Name = "lblHouseName",
                BackColor = Color.White
            };
            topPanel.Controls.Add(lblHouseName);

            // Địa chỉ
            Label lblAddress = new Label
            {
                Text = "19 Nguyễn Thị Thập, Q7",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(15, 50),
                Name = "lblAddress",
                BackColor = Color.White
            };
            topPanel.Controls.Add(lblAddress);

            // ComboBox chọn nhà
            ComboBox cbHouse = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11),
                Width = 200,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(topPanel.Width - 230, 25),
                Name = "cbHouse",
                BackColor = Color.White
            };
            cbHouse.Items.AddRange(new string[] { "Nhà A", "Nhà B", "Nhà C" });
            cbHouse.SelectedIndex = 0;

            // Sự kiện chọn nhà
            cbHouse.SelectedIndexChanged += (s, e) =>
            {
                var name = cbHouse.SelectedItem.ToString();
                lblHouseName.Text = name;

                string address;
                switch (name)
                {
                    case "Nhà A":
                        address = "19 Nguyễn Thị Thập, Q7";
                        break;
                    case "Nhà B":
                        address = "52 Cộng Hòa, Tân Bình";
                        break;
                    case "Nhà C":
                        address = "10 Pasteur, Q1";
                        break;
                    default:
                        address = "Không rõ địa chỉ";
                        break;
                }

                lblAddress.Text = address;
            };

            topPanel.Resize += (s, e) =>
            {
                cbHouse.Left = topPanel.Width - cbHouse.Width - 20;
            };

            topPanel.Controls.Add(cbHouse);

            Controls.Add(mainPanel);

            Controls.Add(topPanel);

            Controls.Add(sidebar);

            AuthNavigationManager.Initialize(mainPanel);

            AddSidebarButton("\uf15c", "Trang Chủ", (s, e) => ShowMessage("Trang Chủ"));
            AddSidebarButton("\uf52b", "Nhà && Phòng", (s, e) => AuthNavigationManager.LoadWinForm<FormHouseManagement>());
            AddSidebarButton("\uf0c0", "Người thuê", (s, e) => LoadFormTenant());
            //AddSidebarButton("\uf15c", "Hợp đồng", (s, e) => AuthNavigationManager.LoadWinForm<FormContract>());
            AddSidebarButton("\uf15c", "Quản lý phương tiện", (s, e) => ShowMessage("Quản lý phương tiện"));
            AddSidebarButton("\uf555", "Tài chính", (s, e) => ShowMessage("Tài chính"));
            AddSidebarButton("\uf53a", "Thanh Toán", (s, e) => AuthNavigationManager.LoadWinForm<FormPayment>());
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
                Font = new Font("Font Awesome 7 Free Solid", 14, FontStyle.Regular),
                Dock = DockStyle.Left,
                Width = 45,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };

            // Text
            Label lblText = new Label
            {
                Text = txt,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                BackColor = Color.White
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
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };

            mainPanel.Controls.Add(lbl);
        }

        private void LoadFormTenant()
        {
            if (mainPanel != null && !mainPanel.IsDisposed)
            {
                FormTenant formTenant = new FormTenant();
                formTenant.TopLevel = false;
                formTenant.FormBorderStyle = FormBorderStyle.None;
                formTenant.Dock = DockStyle.Fill;

                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(formTenant);
                formTenant.Show();
            }
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
            Text = "Hệ thống QLTN";
            ResumeLayout(false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            contractMonitor.Dispose();
        }
    }
}
