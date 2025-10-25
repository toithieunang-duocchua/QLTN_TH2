using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Database;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    /// <summary>
    /// Payment workspace with VietQR integration.
    /// </summary>
    public sealed class MainPaymentsForm : ThemedForm
    {
        private Panel surfacePanel;
        private FlowLayoutPanel summaryPanel;
        private StyledTextBox searchTextBox;
        private ComboBox statusComboBox;
        private ComboBox periodComboBox;
        private DataGridView paymentsGrid;
        private DataTable paymentsTable;
        private BindingSource paymentsBindingSource;

        private Label totalInvoicesValueLabel;
        private Label totalInvoicesHintLabel;
        private Label outstandingValueLabel;
        private Label outstandingHintLabel;
        private Label overdueValueLabel;
        private Label overdueHintLabel;

        private Panel qrPreviewPanel;
        private Label qrPreviewStatusLabel;
        private Label qrPreviewInfoLabel;
        private LinkLabel qrPreviewLinkLabel;
        private PictureBox qrPreviewPictureBox;

        private PaymentService paymentService;
        private VietQRConfig vietQrConfig;

        public MainPaymentsForm()
        {
            InitializeComponent();
            InitializeServices();
            BuildLayout();
            SeedPaymentData();
            RefreshPeriodOptions();
            UpdateSummaryCards();
            ApplyFilters();
        }

        private void InitializeServices()
        {
            try
            {
                vietQrConfig = LoadVietQrConfig();
                paymentService = new PaymentService(vietQrConfig, DatabaseConnection.Instance);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khong the khoi tao dich vu thanh toan: {ex.Message}", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private VietQRConfig LoadVietQrConfig()
        {
            VietQRConfig config = new VietQRConfig();

            try
            {
                using (var connection = DatabaseConnection.Instance.GetConnection())
                {
                    connection.Open();

                    const string sql = "SELECT ConfigKey, ConfigValue FROM VietQRConfig WHERE IsActive = 1";
                    using (var command = new System.Data.SqlClient.SqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string key = reader["ConfigKey"].ToString();
                            string value = reader["ConfigValue"].ToString();

                            switch (key)
                            {
                                case "VietQR_ApiKey":
                                    config.ApiKey = value;
                                    break;
                                case "VietQR_ApiKeyHeader":
                                    config.ApiKeyHeader = value;
                                    break;
                                case "VietQR_AccountNo":
                                    config.AccountNo = value;
                                    break;
                                case "VietQR_AccountName":
                                    config.AccountName = value;
                                    break;
                                case "VietQR_AcqId":
                                    config.AcqId = value;
                                    break;
                                case "VietQR_BankCode":
                                    config.BankCode = value;
                                    break;
                                case "VietQR_BankName":
                                    config.BankName = value;
                                    break;
                                case "VietQR_BaseUrl":
                                    config.BaseUrl = value;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khong the tai cau hinh VietQR: {ex.Message}", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return config;
        }

        private void BuildLayout()
        {
            Text = "Quan ly thanh toan";

            surfacePanel = CreateSurfacePanel(new Size(960, 560));
            surfacePanel.Dock = DockStyle.Fill;
            Controls.Add(surfacePanel);

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 7,
                Padding = new Padding(28),
                BackColor = Color.Transparent
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            surfacePanel.Controls.Add(layout);

            var titleLabel = new Label
            {
                Text = "Quan ly thanh toan",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 48,
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(titleLabel, 0, 0);

            var subtitleLabel = new Label
            {
                Text = "Theo doi hoa don, cap nhat tien do thanh toan va tao ma VietQR cho khach thue.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Dock = DockStyle.Top,
                Height = 26,
                Margin = new Padding(0, 4, 0, 18),
                TextAlign = ContentAlignment.MiddleLeft
            };
            layout.Controls.Add(subtitleLabel, 0, 1);

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
            layout.Controls.Add(summaryPanel, 0, 2);

            summaryPanel.Controls.Add(CreateSummaryCard("Tong so ky", out totalInvoicesValueLabel, out totalInvoicesHintLabel));
            summaryPanel.Controls.Add(CreateSummaryCard("Cho thanh toan", out outstandingValueLabel, out outstandingHintLabel));
            summaryPanel.Controls.Add(CreateSummaryCard("Qua han", out overdueValueLabel, out overdueHintLabel));

            paymentsBindingSource = new BindingSource();

            var filterPanel = BuildFilterPanel();
            layout.Controls.Add(filterPanel, 0, 3);

            paymentsGrid = BuildPaymentsGrid();
            paymentsGrid.DataSource = paymentsBindingSource;
            layout.Controls.Add(paymentsGrid, 0, 4);

            qrPreviewPanel = BuildQrPreviewPanel();
            layout.Controls.Add(qrPreviewPanel, 0, 5);

            FlowLayoutPanel actionsPanel = BuildActionsPanel();
            layout.Controls.Add(actionsPanel, 0, 6);
        }

        private FlowLayoutPanel BuildFilterPanel()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 12)
            };

            searchTextBox = new StyledTextBox
            {
                Width = 220,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(0, 0, 12, 8)
            };
            searchTextBox.BackColor = InputBackColor;
            searchTextBox.ForeColor = Color.White;
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.TextChanged += (_, __) => ApplyFilters();
            panel.Controls.Add(LabeledControl("Tim kiem", searchTextBox));

            statusComboBox = CreateFilterComboBox(new[]
            {
                "Tat ca",
                "Da thanh toan",
                "Dang xu ly",
                "Qua han",
                "Cho thanh toan"
            });
            statusComboBox.SelectedIndexChanged += (_, __) => ApplyFilters();
            panel.Controls.Add(LabeledControl("Trang thai", statusComboBox));

            periodComboBox = CreateFilterComboBox(Array.Empty<string>());
            periodComboBox.SelectedIndexChanged += (_, __) => ApplyFilters();
            panel.Controls.Add(LabeledControl("Ky thanh toan", periodComboBox));

            return panel;
        }

        private ComboBox CreateFilterComboBox(string[] items)
        {
            ComboBox comboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                BackColor = InputBackColor,
                ForeColor = Color.White,
                Width = 180,
                Margin = new Padding(0, 0, 12, 8)
            };

            if (items.Length > 0)
            {
                comboBox.Items.AddRange(items);
                comboBox.SelectedIndex = 0;
            }

            return comboBox;
        }

        private DataGridView BuildPaymentsGrid()
        {
            DataGridView grid = new DataGridView
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

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            grid.EnableHeadersVisualStyles = false;

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hop dong",
                DataPropertyName = "Contract",
                Width = 120
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phong",
                DataPropertyName = "Room",
                Width = 80
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Khach",
                DataPropertyName = "Tenant",
                Width = 160
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ky thanh toan",
                DataPropertyName = "Period",
                Width = 140
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "So tien",
                DataPropertyName = "Amount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" },
                Width = 120
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trang thai",
                DataPropertyName = "Status",
                Width = 140
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Han thanh toan",
                DataPropertyName = "DueDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thanh toan gan nhat",
                DataPropertyName = "LastPayment",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 150
            });

            grid.CellFormatting += PaymentsGrid_CellFormatting;
            return grid;
        }

        private Panel BuildQrPreviewPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 10, 0, 10),
                BackColor = Color.Transparent,
                Visible = false
            };

            TableLayoutPanel previewLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            previewLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            previewLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.Controls.Add(previewLayout);

            FlowLayoutPanel infoPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent
            };
            previewLayout.Controls.Add(infoPanel, 0, 0);

            qrPreviewStatusLabel = new Label
            {
                Text = "Chua co ma VietQR nao duoc tao.",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 6)
            };
            infoPanel.Controls.Add(qrPreviewStatusLabel);

            qrPreviewInfoLabel = new Label
            {
                Text = string.Empty,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                MaximumSize = new Size(420, 0),
                Margin = new Padding(0, 0, 0, 6)
            };
            infoPanel.Controls.Add(qrPreviewInfoLabel);

            qrPreviewLinkLabel = new LinkLabel
            {
                Text = "Sao chep link thanh toan",
                Font = new Font("Segoe UI", 9, FontStyle.Underline),
                LinkColor = Color.FromArgb(255, 160, 0),
                ActiveLinkColor = Color.FromArgb(255, 200, 0),
                AutoSize = true,
                Visible = false,
                Margin = new Padding(0, 0, 0, 6)
            };
            qrPreviewLinkLabel.LinkClicked += (_, __) =>
            {
                if (qrPreviewLinkLabel.Tag is string link && !string.IsNullOrWhiteSpace(link))
                {
                    Clipboard.SetText(link);
                    MessageBox.Show("Đã sao chép link VietQR vào clipboard.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            infoPanel.Controls.Add(qrPreviewLinkLabel);

            qrPreviewPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(16, 0, 0, 0),
                MinimumSize = new Size(200, 200)
            };
            previewLayout.Controls.Add(qrPreviewPictureBox, 1, 0);

            return panel;
        }

        private FlowLayoutPanel BuildActionsPanel()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 12, 0, 0),
                BackColor = Color.Transparent
            };

            Button createQrButton = new Button
            {
                Text = "Tao ma VietQR",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(180, 38),
                Margin = new Padding(0, 0, 12, 0)
            };
            StylePrimaryButton(createQrButton);
            createQrButton.Click += CreateQRButton_Click;
            panel.Controls.Add(createQrButton);

            Button recordPaymentButton = new Button
            {
                Text = "Ghi nhan thanh toan",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(190, 38),
                Margin = new Padding(0, 0, 12, 0)
            };
            StylePrimaryButton(recordPaymentButton);
            recordPaymentButton.Click += RecordPaymentButton_Click;
            panel.Controls.Add(recordPaymentButton);

            Button reminderButton = CreateSecondaryButton("Gui nhac nho");
            reminderButton.Click += (_, __) =>
            {
                int overdueCount = paymentsTable?.AsEnumerable()
                    .Count(row => string.Equals(row.Field<string>("Status"), "Qua han", StringComparison.OrdinalIgnoreCase)) ?? 0;
                MessageBox.Show($"Da len lich gui nhac nho cho {overdueCount} ky qua han.", "Nhac thanh toan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            panel.Controls.Add(reminderButton);

            Button configButton = CreateSecondaryButton("Cau hinh VietQR");
            configButton.Click += (_, __) =>
            {
                using (var configForm = new VietQRConfigForm())
                {
                    if (configForm.ShowDialog(this) == DialogResult.OK)
                    {
                        InitializeServices();
                        MessageBox.Show("Cấu hình VietQR đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };
            panel.Controls.Add(configButton);

            Button exportButton = CreateSecondaryButton("Xuất báo cáo");
            exportButton.Click += (_, __) =>
            {
                MessageBox.Show("Báo cáo thanh toán sẽ được bổ sung trong phiên bản tiếp theo.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            panel.Controls.Add(exportButton);

            return panel;
        }

        private Control CreateSummaryCard(string title, out Label valueLabel, out Label hintLabel)
        {
            Panel card = new Panel
            {
                Size = new Size(250, 120),
                Margin = new Padding(0, 0, 18, 18),
                BackColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(18)
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
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
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

        private Control LabeledControl(string caption, Control control)
        {
            FlowLayoutPanel wrapper = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 0, 16, 8),
                BackColor = Color.Transparent
            };

            Label label = new Label
            {
                Text = caption,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 4)
            };
            wrapper.Controls.Add(label);
            wrapper.Controls.Add(control);
            return wrapper;
        }

        private Button CreateSecondaryButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                Size = new Size(150, 36),
                Margin = new Padding(0, 0, 12, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White
            };
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            return button;
        }private void SeedPaymentData()
        {
            paymentsTable = new DataTable();
            paymentsTable.Columns.Add("Contract", typeof(string));
            paymentsTable.Columns.Add("Room", typeof(string));
            paymentsTable.Columns.Add("Tenant", typeof(string));
            paymentsTable.Columns.Add("Period", typeof(string));
            paymentsTable.Columns.Add("Amount", typeof(decimal));
            paymentsTable.Columns.Add("Status", typeof(string));
            paymentsTable.Columns.Add("DueDate", typeof(DateTime));
            paymentsTable.Columns.Add("LastPayment", typeof(DateTime));

            paymentsTable.Rows.Add("HD001", "P101", "Nguyen Van A", "Thang 01/2025", 5500000m, "Cho thanh toan", DateTime.Today.AddDays(5), DateTime.Today.AddMonths(-1));
            paymentsTable.Rows.Add("HD002", "P102", "Tran Thi B", "Thang 01/2025", 6200000m, "Qua han", DateTime.Today.AddDays(-3), DateTime.Today.AddMonths(-1).AddDays(2));
            paymentsTable.Rows.Add("HD003", "P201", "Le Van C", "Thang 01/2025", 4800000m, "Da thanh toan", DateTime.Today.AddDays(10), DateTime.Today);
            paymentsTable.Rows.Add("HD004", "P202", "Pham Thi D", "Thang 01/2025", 7000000m, "Dang xu ly", DateTime.Today.AddDays(2), DateTime.Today.AddMonths(-1).AddDays(4));
            paymentsTable.Rows.Add("HD005", "P301", "Doan Van E", "Thang 01/2025", 5300000m, "Cho thanh toan", DateTime.Today.AddDays(7), DateTime.Today.AddMonths(-1).AddDays(-1));

            paymentsBindingSource.DataSource = paymentsTable;
        }

        private void RefreshPeriodOptions()
        {
            periodComboBox.SelectedIndexChanged -= PeriodComboBox_SelectedIndexChanged;

            var periods = paymentsTable.AsEnumerable()
                .Select(row => row.Field<string>("Period"))
                .Distinct()
                .OrderByDescending(p => p)
                .ToList();
            periods.Insert(0, "Tat ca");

            periodComboBox.Items.Clear();
            foreach (string period in periods)
            {
                periodComboBox.Items.Add(period);
            }
            periodComboBox.SelectedIndex = 0;

            periodComboBox.SelectedIndexChanged += PeriodComboBox_SelectedIndexChanged;
        }

        private void PeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (paymentsTable == null)
            {
                return;
            }

            string searchTerm = searchTextBox.Text?.Trim() ?? string.Empty;
            string status = statusComboBox.SelectedItem as string ?? "Tat ca";
            string period = periodComboBox.SelectedItem as string ?? "Tat ca";

            var filteredRows = paymentsTable.AsEnumerable().Where(row =>
            {
                bool matchesSearch = string.IsNullOrWhiteSpace(searchTerm)
                    || row.ItemArray.Any(value => value != null && value.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

                bool matchesStatus = status == "Tat ca"
                    || string.Equals(row.Field<string>("Status"), status, StringComparison.OrdinalIgnoreCase);

                bool matchesPeriod = period == "Tat ca"
                    || string.Equals(row.Field<string>("Period"), period, StringComparison.OrdinalIgnoreCase);

                return matchesSearch && matchesStatus && matchesPeriod;
            });

            DataTable filteredTable = paymentsTable.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            paymentsBindingSource.DataSource = filteredTable;
            UpdateSummaryCards();
        }

        private void PaymentsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (paymentsGrid.Columns[e.ColumnIndex].DataPropertyName != "Status")
            {
                return;
            }

            string status = e.Value?.ToString();
            if (string.Equals(status, "Qua han", StringComparison.OrdinalIgnoreCase))
            {
                paymentsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(100, 40, 40);
            }
            else if (string.Equals(status, "Da thanh toan", StringComparison.OrdinalIgnoreCase))
            {
                paymentsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(40, 80, 40);
            }
            else if (string.Equals(status, "Dang xu ly", StringComparison.OrdinalIgnoreCase))
            {
                paymentsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 30);
            }
            else
            {
                paymentsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(48, 48, 48);
            }
        }

        private void UpdateSummaryCards()
        {
            DataTable currentTable = paymentsBindingSource.DataSource as DataTable ?? paymentsTable;

            int total = currentTable.Rows.Count;
            int outstanding = currentTable.AsEnumerable()
                .Count(row => string.Equals(row.Field<string>("Status"), "Cho thanh toan", StringComparison.OrdinalIgnoreCase)
                           || string.Equals(row.Field<string>("Status"), "Dang xu ly", StringComparison.OrdinalIgnoreCase));
            int overdue = currentTable.AsEnumerable()
                .Count(row => string.Equals(row.Field<string>("Status"), "Qua han", StringComparison.OrdinalIgnoreCase));

            decimal outstandingAmount = currentTable.AsEnumerable()
                .Where(row => string.Equals(row.Field<string>("Status"), "Cho thanh toan", StringComparison.OrdinalIgnoreCase)
                           || string.Equals(row.Field<string>("Status"), "Dang xu ly", StringComparison.OrdinalIgnoreCase))
                .Sum(row => row.Field<decimal>("Amount"));

            totalInvoicesValueLabel.Text = total.ToString();
            totalInvoicesHintLabel.Text = "Ky thanh toan trong danh sach hien tai.";

            outstandingValueLabel.Text = outstanding.ToString();
            outstandingHintLabel.Text = $"Tong so tien chua nhan: {outstandingAmount.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"))}";

            overdueValueLabel.Text = overdue.ToString();
            overdueHintLabel.Text = overdue == 0 ? "Khong co ky nao qua han." : "Can xu ly som cac ky nay.";
        }

        private async void RefreshPaymentData()
        {
            try
            {
                var payments = await paymentService.GetPaymentsAsync();
                
                // Cập nhật DataTable
                paymentsTable.Clear();
                foreach (var payment in payments)
                {
                    var row = paymentsTable.NewRow();
                    row["ContractId"] = payment.ContractId;
                    row["TenantName"] = payment.TenantName;
                    row["Period"] = payment.Period;
                    row["Amount"] = payment.Amount;
                    row["DueDate"] = payment.DueDate;
                    row["OrderId"] = payment.OrderId;
                    row["Status"] = payment.Status.ToString();
                    row["QrCodeUrl"] = payment.QrCodeUrl ?? "";
                    row["PaymentLink"] = payment.PaymentLink ?? "";
                    row["RoomId"] = payment.RoomId;
                    row["Month"] = payment.Month;
                    row["Description"] = payment.Description;
                    row["CreatedAt"] = payment.CreatedAt;
                    paymentsTable.Rows.Add(row);
                }
                
                paymentsBindingSource.ResetBindings(false);
                UpdateSummaryCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CreateQRButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentsGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một kỳ thanh toán để tạo mã QR.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = paymentsGrid.SelectedRows[0];
                var contractId = selectedRow.Cells["ContractId"].Value?.ToString();
                var roomId = selectedRow.Cells["RoomId"].Value?.ToString();
                var tenantName = selectedRow.Cells["TenantName"].Value?.ToString();
                var period = selectedRow.Cells["Period"].Value?.ToString();
                var amount = Convert.ToDecimal(selectedRow.Cells["Amount"].Value);
                var dueDate = Convert.ToDateTime(selectedRow.Cells["DueDate"].Value);

                // Tạo PaymentInfo
                var paymentInfo = await paymentService.CreatePaymentQrAsync(
                    contractId, roomId, tenantName, period, amount, dueDate);

                if (paymentInfo != null)
                {
                    MessageBox.Show("Đã tạo mã QR thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Cập nhật preview
                    RenderPaymentPreview(paymentInfo);
                    
                    // Refresh danh sách
                    RefreshPaymentData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã QR: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RenderPaymentPreview(PaymentInfo paymentInfo)
        {
            qrPreviewPanel.Visible = true;

            if (paymentInfo == null)
            {
                qrPreviewStatusLabel.Text = "Không có dữ liệu VietQR.";
                qrPreviewInfoLabel.Text = string.Empty;
                qrPreviewLinkLabel.Visible = false;
                ClearQrPreviewImage();
                return;
            }

            CultureInfo culture = CultureInfo.GetCultureInfo("vi-VN");
            qrPreviewStatusLabel.Text = $"QR cho hop dong {paymentInfo.ContractId}";
            qrPreviewInfoLabel.Text =
                $"Khách: {paymentInfo.TenantName}\n" +
                $"Phòng: {paymentInfo.RoomId}\n" +
                $"Kỳ: {paymentInfo.Period}\n" +
                $"Số tiền: {paymentInfo.Amount.ToString("C0", culture)}\n" +
                $"Hạn thanh toán: {paymentInfo.DueDate:dd/MM/yyyy}";

            if (!string.IsNullOrWhiteSpace(paymentInfo.PaymentLink))
            {
                qrPreviewLinkLabel.Tag = paymentInfo.PaymentLink;
                qrPreviewLinkLabel.Visible = true;
            }
            else
            {
                qrPreviewLinkLabel.Tag = null;
                qrPreviewLinkLabel.Visible = false;
            }

            ClearQrPreviewImage();

            if (!string.IsNullOrWhiteSpace(paymentInfo.QrCodeUrl))
            {
                try
                {
                    if (!string.IsNullOrEmpty(paymentInfo.QrCodeUrl))
                    {
                        // Load QR image from URL
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            var imageBytes = await client.GetByteArrayAsync(paymentInfo.QrCodeUrl);
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                qrPreviewPictureBox.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    qrPreviewStatusLabel.Text = $"Khong the hien thi QR: {ex.Message}";
                }
            }
            else
            {
                qrPreviewStatusLabel.Text = "Gateway khong tra ve anh QR.";
            }
        }

        private void ClearQrPreviewImage()
        {
            if (qrPreviewPictureBox.Image != null)
            {
                qrPreviewPictureBox.Image.Dispose();
                qrPreviewPictureBox.Image = null;
            }
        }

        private void RecordPaymentButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tinh nang ghi nhan thanh toan se duoc bo sung trong cac ban cap nhat tiep theo.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 640);
            Name = "MainPaymentsForm";
            Text = "Quan ly thanh toan";
            ResumeLayout(false);
        }
    }
}
