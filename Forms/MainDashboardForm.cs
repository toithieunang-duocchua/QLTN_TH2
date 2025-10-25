using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Database;
using QLTN.Services;

namespace QLTN.Forms
{
    /// <summary>
    /// Dashboard chính với tổng quan hệ thống và thống kê
    /// </summary>
    public sealed class MainDashboardForm : ThemedForm
    {
        private Panel surfacePanel;
        private FlowLayoutPanel summaryPanel;
        private DataGridView recentActivityGrid;
        private DataTable activityTable;
        private BindingSource activityBindingSource;

        // Summary cards
        private Label totalHousesValueLabel;
        private Label totalHousesHintLabel;
        private Label totalRoomsValueLabel;
        private Label totalRoomsHintLabel;
        private Label occupiedRoomsValueLabel;
        private Label occupiedRoomsHintLabel;
        private Label monthlyRevenueValueLabel;
        private Label monthlyRevenueHintLabel;

        // Charts placeholders
        private Panel revenueChartPanel;
        private Panel occupancyChartPanel;

        public MainDashboardForm()
        {
            InitializeComponent();
            BuildLayout();
            SeedDashboardData();
            UpdateSummaryCards();
            RefreshRecentActivity();
        }

        private void BuildLayout()
        {
            Text = "Dashboard - Tổng quan hệ thống";

            surfacePanel = CreateSurfacePanel(new Size(1200, 700));
            surfacePanel.Dock = DockStyle.Fill;
            Controls.Add(surfacePanel);

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(28),
                BackColor = Color.Transparent
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            surfacePanel.Controls.Add(layout);

            // Header
            var headerPanel = BuildHeaderPanel();
            layout.Controls.Add(headerPanel, 0, 0);

            // Summary cards
            summaryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 0, 0, 16),
                BackColor = Color.Transparent
            };
            layout.Controls.Add(summaryPanel, 0, 1);

            summaryPanel.Controls.Add(CreateSummaryCard("Tổng số nhà", out totalHousesValueLabel, out totalHousesHintLabel, Color.FromArgb(52, 152, 219)));
            summaryPanel.Controls.Add(CreateSummaryCard("Tổng số phòng", out totalRoomsValueLabel, out totalRoomsHintLabel, Color.FromArgb(46, 204, 113)));
            summaryPanel.Controls.Add(CreateSummaryCard("Phòng đã thuê", out occupiedRoomsValueLabel, out occupiedRoomsHintLabel, Color.FromArgb(241, 196, 15)));
            summaryPanel.Controls.Add(CreateSummaryCard("Doanh thu tháng", out monthlyRevenueValueLabel, out monthlyRevenueHintLabel, Color.FromArgb(231, 76, 60)));

            // Charts row
            var chartsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            chartsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            chartsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout.Controls.Add(chartsPanel, 0, 2);

            revenueChartPanel = BuildChartPanel("Biểu đồ doanh thu", "Doanh thu theo tháng (triệu VNĐ)");
            chartsPanel.Controls.Add(revenueChartPanel, 0, 0);

            occupancyChartPanel = BuildChartPanel("Tỷ lệ lấp đầy", "Tỷ lệ phòng đã thuê (%)");
            chartsPanel.Controls.Add(occupancyChartPanel, 1, 0);

            // Recent activity
            var activityPanel = BuildActivityPanel();
            layout.Controls.Add(activityPanel, 0, 3);

            // Quick actions
            var actionsPanel = BuildQuickActionsPanel();
            layout.Controls.Add(actionsPanel, 0, 4);
        }

        private Panel BuildHeaderPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 80,
                BackColor = Color.Transparent
            };

            var titleLabel = new Label
            {
                Text = "Dashboard - Tổng quan hệ thống",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 48,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(titleLabel);

            var subtitleLabel = new Label
            {
                Text = $"Cập nhật lần cuối: {DateTime.Now:dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Top,
                Height = 26,
                Margin = new Padding(0, 4, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(subtitleLabel);

            return panel;
        }

        private Panel BuildChartPanel(string title, string subtitle)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 0),
                BackColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(titleLabel);

            var subtitleLabel = new Label
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Top,
                Height = 24,
                Margin = new Padding(0, 0, 0, 16),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(subtitleLabel);

            // Placeholder for chart
            var chartPlaceholder = new Label
            {
                Text = "📊\n\nBiểu đồ sẽ được hiển thị ở đây\n\n(Đang phát triển)",
                Font = new Font("Segoe UI", 12),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(chartPlaceholder);

            return panel;
        }

        private Panel BuildActivityPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 12, 0, 0),
                BackColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = "Hoạt động gần đây",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(titleLabel);

            recentActivityGrid = new DataGridView
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
                MultiSelect = false,
                Margin = new Padding(0, 16, 0, 0)
            };

            recentActivityGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            recentActivityGrid.EnableHeadersVisualStyles = false;

            recentActivityGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thời gian",
                DataPropertyName = "Time",
                Width = 120
            });
            recentActivityGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại hoạt động",
                DataPropertyName = "ActivityType",
                Width = 150
            });
            recentActivityGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô tả",
                DataPropertyName = "Description",
                Width = 300
            });
            recentActivityGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Người thực hiện",
                DataPropertyName = "User",
                Width = 150
            });

            panel.Controls.Add(recentActivityGrid);

            return panel;
        }

        private FlowLayoutPanel BuildQuickActionsPanel()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 16, 0, 0),
                BackColor = Color.Transparent
            };

            Button addHouseButton = new Button
            {
                Text = "Thêm nhà mới",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(140, 38),
                Margin = new Padding(0, 0, 12, 0)
            };
            StylePrimaryButton(addHouseButton);
            addHouseButton.Click += (_, __) => MessageBox.Show("Chuyển đến form thêm nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panel.Controls.Add(addHouseButton);

            Button addRoomButton = new Button
            {
                Text = "Thêm phòng",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 38),
                Margin = new Padding(0, 0, 12, 0)
            };
            StylePrimaryButton(addRoomButton);
            addRoomButton.Click += (_, __) => MessageBox.Show("Chuyển đến form thêm phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panel.Controls.Add(addRoomButton);

            Button viewReportsButton = CreateSecondaryButton("Xem báo cáo");
            viewReportsButton.Click += (_, __) => MessageBox.Show("Chuyển đến module báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panel.Controls.Add(viewReportsButton);

            Button refreshButton = CreateSecondaryButton("Làm mới");
            refreshButton.Click += (_, __) =>
            {
                UpdateSummaryCards();
                RefreshRecentActivity();
                MessageBox.Show("Đã cập nhật dữ liệu dashboard", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            panel.Controls.Add(refreshButton);

            return panel;
        }

        private Control CreateSummaryCard(string title, out Label valueLabel, out Label hintLabel, Color accentColor)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 140),
                Margin = new Padding(0, 0, 18, 18),
                BackColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Top,
                Height = 24
            };
            card.Controls.Add(titleLabel);

            valueLabel = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = accentColor,
                Dock = DockStyle.Top,
                Height = 48
            };
            card.Controls.Add(valueLabel);

            hintLabel = new Label
            {
                Text = string.Empty,
                Font = new Font("Segoe UI", 9),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Fill
            };
            card.Controls.Add(hintLabel);

            return card;
        }

        private Button CreateSecondaryButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                Size = new Size(120, 36),
                Margin = new Padding(0, 0, 12, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White
            };
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            return button;
        }

        private void SeedDashboardData()
        {
            activityTable = new DataTable();
            activityTable.Columns.Add("Time", typeof(string));
            activityTable.Columns.Add("ActivityType", typeof(string));
            activityTable.Columns.Add("Description", typeof(string));
            activityTable.Columns.Add("User", typeof(string));

            activityTable.Rows.Add("10:30", "Đăng nhập", "Người dùng đăng nhập vào hệ thống", "admin");
            activityTable.Rows.Add("09:15", "Thêm phòng", "Thêm phòng P301 vào nhà A", "admin");
            activityTable.Rows.Add("08:45", "Cập nhật hợp đồng", "Gia hạn hợp đồng HD001", "admin");
            activityTable.Rows.Add("08:00", "Thanh toán", "Nhận thanh toán từ khách HD002", "system");
            activityTable.Rows.Add("07:30", "Báo cáo", "Xuất báo cáo tháng 01/2025", "admin");

            activityBindingSource = new BindingSource();
            activityBindingSource.DataSource = activityTable;
            recentActivityGrid.DataSource = activityBindingSource;
        }

        private void UpdateSummaryCards()
        {
            // Giả lập dữ liệu từ database
            int totalHouses = 5;
            int totalRooms = 25;
            int occupiedRooms = 18;
            decimal monthlyRevenue = 125000000m; // 125 triệu VNĐ

            CultureInfo culture = CultureInfo.GetCultureInfo("vi-VN");

            totalHousesValueLabel.Text = totalHouses.ToString();
            totalHousesHintLabel.Text = "Tòa nhà đang quản lý";

            totalRoomsValueLabel.Text = totalRooms.ToString();
            totalRoomsHintLabel.Text = "Tổng số phòng cho thuê";

            occupiedRoomsValueLabel.Text = occupiedRooms.ToString();
            occupiedRoomsHintLabel.Text = $"Tỷ lệ lấp đầy: {(occupiedRooms * 100.0 / totalRooms):F1}%";

            monthlyRevenueValueLabel.Text = (monthlyRevenue / 1000000).ToString("F0");
            monthlyRevenueHintLabel.Text = $"Doanh thu tháng {DateTime.Now:MM/yyyy}";
        }

        private void RefreshRecentActivity()
        {
            // Cập nhật lại dữ liệu hoạt động
            activityBindingSource.DataSource = activityTable;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Name = "MainDashboardForm";
            Text = "Dashboard";
            ResumeLayout(false);
        }
    }
}