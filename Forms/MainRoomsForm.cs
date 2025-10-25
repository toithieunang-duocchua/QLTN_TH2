using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Room inventory overview with quick filters for building and status.
    /// </summary>
    public sealed class MainRoomsForm : ThemedForm
    {
        private Panel surfacePanel;
        private StyledTextBox searchTextBox;
        private ComboBox buildingComboBox;
        private ComboBox statusComboBox;
        private DataGridView roomsGrid;
        private readonly List<RoomItem> allRooms = new List<RoomItem>();
        private BindingSource roomBindingSource;

        public MainRoomsForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Phòng - Hệ thống QLTN";

            surfacePanel = CreateSurfacePanel(new Size(860, 520));
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
                Text = "Danh mục phòng",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 46,
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(titleLabel, 0, 0);

            Label subtitleLabel = new Label
            {
                Text = "Theo dõi tình trạng phòng, giá thuê và tiến trình bàn giao.",
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
                WrapContents = true,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 16)
            };
            layout.Controls.Add(filterPanel, 0, 2);

            searchTextBox = new StyledTextBox
            {
                Width = 200,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(0, 0, 12, 8)
            };
            StyleInputTextBox(searchTextBox);
            searchTextBox.TextChanged += (_, __) => ApplyRoomFilter();
            filterPanel.Controls.Add(LabeledControl("Tìm kiếm", searchTextBox));

            buildingComboBox = CreateFilterComboBox(new[] { "Tất cả", "Tòa A", "Tòa B" });
            buildingComboBox.SelectedIndexChanged += (_, __) => ApplyRoomFilter();
            filterPanel.Controls.Add(LabeledControl("Tòa nhà", buildingComboBox));

            statusComboBox = CreateFilterComboBox(new[] { "Tất cả", "Trống", "Đang thuê", "Đang bảo trì" });
            statusComboBox.SelectedIndexChanged += (_, __) => ApplyRoomFilter();
            filterPanel.Controls.Add(LabeledControl("Trạng thái", statusComboBox));

            Button addRoomButton = new Button
            {
                Text = "Thêm phòng",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(150, 36),
                Margin = new Padding(18, 0, 0, 8)
            };
            StylePrimaryButton(addRoomButton);
            addRoomButton.Click += (_, __) => MessageBox.Show(
                "Tính năng thêm phòng sẽ có trong phiên bản kế tiếp.",
                "Đang phát triển",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            filterPanel.Controls.Add(addRoomButton);

            roomsGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                BackgroundColor = Color.FromArgb(48, 48, 48),
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(66, 66, 66),
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            roomsGrid.EnableHeadersVisualStyles = false;
            roomsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 65, 65);
            roomsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            roomsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            roomsGrid.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            roomsGrid.DefaultCellStyle.ForeColor = Color.White;
            roomsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 80, 80);
            roomsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            roomsGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã phòng",
                DataPropertyName = nameof(RoomItem.RoomCode),
                Width = 110
            });
            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tòa",
                DataPropertyName = nameof(RoomItem.Building),
                Width = 80
            });
            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại phòng",
                DataPropertyName = nameof(RoomItem.RoomType),
                Width = 160
            });
            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trạng thái",
                DataPropertyName = nameof(RoomItem.Status),
                Width = 130
            });
            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá thuê",
                DataPropertyName = nameof(RoomItem.Rent),
                DefaultCellStyle = new DataGridViewCellStyle { Format = "c0" },
                Width = 120
            });
            roomsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ghi chú",
                DataPropertyName = nameof(RoomItem.Note),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            layout.Controls.Add(roomsGrid, 0, 3);

            roomBindingSource = new BindingSource();
            roomsGrid.DataSource = roomBindingSource;
            PopulateRooms();
            ApplyRoomFilter();
        }

        private Control LabeledControl(string label, Control control)
        {
            FlowLayoutPanel wrapper = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 0, 16, 8),
                BackColor = Color.Transparent
            };

            Label caption = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 4)
            };
            wrapper.Controls.Add(caption);
            control.Margin = new Padding(0);
            wrapper.Controls.Add(control);
            return wrapper;
        }

        private ComboBox CreateFilterComboBox(IEnumerable<string> items)
        {
            ComboBox comboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Width = 160,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(55, 55, 55),
                ForeColor = Color.White,
            };

            comboBox.Items.AddRange(items.ToArray());
            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        private void PopulateRooms()
        {
            allRooms.Clear();
            allRooms.Add(new RoomItem("A101", "Tòa A", "Studio 35m²", "Đang thuê", 5500000, "Khách ở 8 tháng."));
            allRooms.Add(new RoomItem("A102", "Tòa A", "Studio 28m²", "Trống", 5200000, "Vừa hoàn thiện nội thất."));
            allRooms.Add(new RoomItem("A301", "Tòa A", "2 phòng ngủ", "Đang thuê", 7500000, "Gia hạn đến 12/2024."));
            allRooms.Add(new RoomItem("B201", "Tòa B", "Premium 40m²", "Đang thuê", 6200000, "Khách ưu tiên thanh toán chuyển khoản."));
            allRooms.Add(new RoomItem("B305", "Tòa B", "1 phòng ngủ", "Đang bảo trì", 5800000, "Thay máy lạnh tuần này."));
            allRooms.Add(new RoomItem("B402", "Tòa B", "Studio 30m²", "Trống", 5400000, "Khả dụng ngay."));
        }

        private void ApplyRoomFilter()
        {
            IEnumerable<RoomItem> filtered = allRooms;

            string keyword = (searchTextBox?.Text ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(room =>
                    room.RoomCode.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    room.RoomType.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            string building = buildingComboBox?.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(building) && !building.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(room => room.Building.Equals(building, StringComparison.OrdinalIgnoreCase));
            }

            string status = statusComboBox?.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status) && !status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(room => room.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            List<RoomItem> list = filtered.ToList();
            roomBindingSource.DataSource = new BindingList<RoomItem>(list);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "MainRoomsForm";
            Text = "Phòng";
            ResumeLayout(false);
        }

        private readonly struct RoomItem
        {
            public RoomItem(string roomCode, string building, string roomType, string status, decimal rent, string note)
            {
                RoomCode = roomCode;
                Building = building;
                RoomType = roomType;
                Status = status;
                Rent = rent;
                Note = note;
            }

            public string RoomCode { get; }
            public string Building { get; }
            public string RoomType { get; }
            public string Status { get; }
            public decimal Rent { get; }
            public string Note { get; }
        }
    }
}
