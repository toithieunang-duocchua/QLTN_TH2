using Guna.UI2.WinForms;
using QLTN.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormPayment : Form
    {
        private FlowLayoutPanel flowPanel;
        private Guna2Panel header;
        private Guna2Panel mainPanel;

        public FormPayment()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();

            this.Load += FormPayment_Load;
            this.Resize += FormPayment_Resize;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Padding = new Padding(0);

            header = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(128, 90, 213),
                ShadowDecoration = { Depth = 2, Shadow = new Padding(0, 0, 0, 5) },
                Padding = new Padding(20, 15, 20, 10)
            };

            Guna2HtmlLabel title = new Guna2HtmlLabel
            {
                Text = "Quản lý thanh toán",
                Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 10)
            };

            Guna2HtmlLabel subtitle = new Guna2HtmlLabel
            {
                Text = "Thông tin thanh toán các phòng",
                Font = new Font("Segoe UI", 15F, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(22, 45)
            };

            header.Controls.Add(title);
            header.Controls.Add(subtitle);

            mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 250)
            };

            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(245, 247, 250),
                WrapContents = true
            };

            mainPanel.Controls.Add(flowPanel);

            this.Controls.Add(mainPanel);
            this.Controls.Add(header);

            // Téttt
            List<Payments> paymentsList = new List<Payments>
            {
                new Payments { RoomId = "Phòng A101", TenantName = "Nguyễn Văn A", Status = 1, Period = "10/2025", Amount = 2500000 },
                new Payments { RoomId = "Phòng A102", TenantName = "Trần Thị B", Status = 1, Period = "10/2025", Amount = 2750000 },
                new Payments { RoomId = "Phòng A103", TenantName = "—", Status = 0, Period = "10/2025", Amount = 0 },
                new Payments { RoomId = "Phòng A104", TenantName = "—", Status = 0, Period = "10/2025", Amount = 0 }
            };

            foreach (var pm in paymentsList)
            {
                var card = CreateRoomCard(pm);
                flowPanel.Controls.Add(card);
            }

            UpdateCardWidths();
        }

        public Guna2Panel CreateRoomCard(Payments pm)
        {
            Guna2Panel card = new Guna2Panel
            {
                Height = 90,
                Width = 700, 
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.Gainsboro,
                FillColor = Color.White,
                BackColor = Color.White,
                Margin = new Padding(10, 10, 10, 0),
                ShadowDecoration = { Depth = 2, Shadow = new Padding(3) }
            };

            card.MouseEnter += (s, _) => card.FillColor = Color.FromArgb(249, 250, 252);
            card.MouseLeave += (s, _) => card.FillColor = Color.White;
            card.MouseClick += (s, e) =>
            {
                AuthNavigationManager.LoadWinForm<FormPaymentInf>();
            };

            Label lblRoom = new Label
            {
                Text = pm.RoomId,
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 15),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label lblTenant = new Label
            {
                Text = pm.TenantName + "     •",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(73, 80, 87),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label lblStatus = new Label
            {
                Text = pm.Status == 1 ? "Đã thuê" : "Trống",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = pm.Status == 1 ? Color.ForestGreen : Color.OrangeRed,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            FlowLayoutPanel infoPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 45),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            infoPanel.Controls.Add(lblTenant);
            infoPanel.Controls.Add(lblStatus);

            card.Controls.Add(lblRoom);
            card.Controls.Add(infoPanel);

            return card;
        }

        private void FormPayment_Resize(object sender, EventArgs e)
        {
            UpdateCardWidths();
        }

        private void UpdateCardWidths()
        {
            if (flowPanel == null) return;

            foreach (Control ctrl in flowPanel.Controls)
            {
                ctrl.Width = flowPanel.ClientSize.Width - 40; 
            }
        }
    }
}
