using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Lightweight tenant directory with search and status filtering.
    /// </summary>
    public sealed class MainTenantsForm : ThemedForm
    {
        private Panel surfacePanel;
        private StyledTextBox searchTextBox;
        private ComboBox statusComboBox;
        private ListView tenantsListView;
        private readonly List<TenantItem> tenantItems = new List<TenantItem>();

        public MainTenantsForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Người thuê - Hệ thống QLTN";

            surfacePanel = CreateSurfacePanel(new Size(840, 520));
            surfacePanel.Anchor = AnchorStyles.None;
            Controls.Add(surfacePanel);
            AttachCentering(surfacePanel);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(30),
                BackColor = Color.Transparent
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            surfacePanel.Controls.Add(layout);

            Label titleLabel = new Label
            {
                Text = "Danh sách người thuê",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 46,
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(titleLabel, 0, 0);

            Label subtitleLabel = new Label
            {
                Text = "Quản lý hồ sơ khách thuê, hợp đồng và tình trạng cư trú.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                AutoSize = false,
                Height = 24,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 4, 0, 12),
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(subtitleLabel, 0, 1);

            FlowLayoutPanel filterPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 16)
            };
            layout.Controls.Add(filterPanel, 0, 2);

            Label searchLabel = new Label
            {
                Text = "Tìm kiếm:",
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                Margin = new Padding(0, 6, 12, 0)
            };
            filterPanel.Controls.Add(searchLabel);

            searchTextBox = new StyledTextBox
            {
                Width = 220,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(0, 0, 12, 0)
            };
            StyleInputTextBox(searchTextBox);
            searchTextBox.TextChanged += (_, __) => ApplyTenantFilter();
            filterPanel.Controls.Add(searchTextBox);

            Label statusLabel = new Label
            {
                Text = "Trạng thái:",
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                Margin = new Padding(0, 6, 12, 0)
            };
            filterPanel.Controls.Add(statusLabel);

            statusComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Width = 160,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(55, 55, 55),
                ForeColor = Color.White,
                Margin = new Padding(0, 0, 12, 0)
            };
            statusComboBox.Items.AddRange(new object[] { "Tất cả", "Đang ở", "Sắp trả phòng", "Tiềm năng" });
            statusComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndexChanged += (_, __) => ApplyTenantFilter();
            filterPanel.Controls.Add(statusComboBox);

            Button addTenantButton = new Button
            {
                Text = "Thêm người thuê",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(170, 36),
                Margin = new Padding(18, 0, 0, 0)
            };
            StylePrimaryButton(addTenantButton);
            addTenantButton.Click += (_, __) => MessageBox.Show(
                "Tính năng thêm người thuê sẽ được triển khai ở bước tiếp theo.",
                "Đang phát triển",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            filterPanel.Controls.Add(addTenantButton);

            tenantsListView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                HideSelection = false,
                BorderStyle = BorderStyle.None,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(0),
                MultiSelect = false
            };
            tenantsListView.Columns.Add("Họ tên", 220);
            tenantsListView.Columns.Add("Số điện thoại", 120);
            tenantsListView.Columns.Add("Phòng", 80);
            tenantsListView.Columns.Add("Trạng thái", 140);
            tenantsListView.Columns.Add("Ghi chú", 220);
            layout.Controls.Add(tenantsListView, 0, 3);

            PopulateTenantItems();
            ApplyTenantFilter();
        }

        private void PopulateTenantItems()
        {
            tenantItems.Clear();
            tenantItems.Add(new TenantItem("Nguyễn Minh Trí", "0905123456", "A203", "Đang ở", "Thanh toán đúng hạn."));
            tenantItems.Add(new TenantItem("Trần Thị Ngọc Mai", "0938123999", "B102", "Đang ở", "Ưu tiên xử lý yêu cầu bảo trì."));
            tenantItems.Add(new TenantItem("Huỳnh Đức Khải", "0978888123", "B305", "Sắp trả phòng", "Hẹn bàn giao ngày 15/11."));
            tenantItems.Add(new TenantItem("Phạm Hữu Quang", "0967234466", "A105", "Đang ở", "Gia hạn hợp đồng tháng tới."));
            tenantItems.Add(new TenantItem("Vũ Phương Thảo", "0987654321", "---", "Tiềm năng", "Đang giữ chỗ phòng A401."));
            tenantItems.Add(new TenantItem("Lê Quốc Việt", "0912345678", "B201", "Đang ở", "Chưa thanh toán kỳ 10/2024."));
        }

        private void ApplyTenantFilter()
        {
            if (tenantsListView == null)
            {
                return;
            }

            string keyword = (searchTextBox?.Text ?? string.Empty).Trim();
            string status = statusComboBox?.SelectedItem?.ToString() ?? "Tất cả";

            tenantsListView.BeginUpdate();
            tenantsListView.Items.Clear();

            IEnumerable<TenantItem> filtered = tenantItems;

            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(item =>
                    item.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Phone.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Room.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrEmpty(status) && !status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(item => item.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            foreach (TenantItem tenant in filtered)
            {
                ListViewItem listViewItem = new ListViewItem(tenant.FullName);
                listViewItem.SubItems.Add(tenant.Phone);
                listViewItem.SubItems.Add(tenant.Room);
                listViewItem.SubItems.Add(tenant.Status);
                listViewItem.SubItems.Add(tenant.Note);
                tenantsListView.Items.Add(listViewItem);
            }

            tenantsListView.EndUpdate();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainTenantsForm";
            Text = "Người thuê";
            ResumeLayout(false);
        }

        private readonly struct TenantItem
        {
            public TenantItem(string fullName, string phone, string room, string status, string note)
            {
                FullName = fullName;
                Phone = phone;
                Room = room;
                Status = status;
                Note = note;
            }

            public string FullName { get; }
            public string Phone { get; }
            public string Room { get; }
            public string Status { get; }
            public string Note { get; }
        }
    }
}
