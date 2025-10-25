using System;
using System.Drawing;
using System.Windows.Forms;
using QLTN.Models;

namespace QLTN.Forms
{
    public partial class VietQRConfigForm : Form
    {
        private TextBox baseUrlTextBox;
        private TextBox apiKeyHeaderTextBox;
        private TextBox apiKeyTextBox;
        private TextBox acqIdTextBox;
        private TextBox bankCodeTextBox;
        private TextBox bankNameTextBox;
        private TextBox accountNoTextBox;
        private TextBox accountNameTextBox;
        private ComboBox templateComboBox;
        private TextBox messagePatternTextBox;
        private Button saveButton;
        private Button cancelButton;

        public VietQRConfig Config { get; private set; }

        public VietQRConfigForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // Form properties
            Text = "Cấu hình VietQR";
            Size = new Size(500, 600);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // Main layout
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };
            Controls.Add(mainPanel);

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 12,
                Padding = new Padding(5)
            };
            mainPanel.Controls.Add(layout);

            int row = 0;

            // Base URL
            layout.Controls.Add(new Label { Text = "Base URL:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            baseUrlTextBox = new TextBox { Text = "https://terrykozte.app.n8n.cloud/", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(baseUrlTextBox, 1, row++);

            // API Key Header
            layout.Controls.Add(new Label { Text = "API Key Header:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            apiKeyHeaderTextBox = new TextBox { Text = "X-N8N-API-KEY", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(apiKeyHeaderTextBox, 1, row++);

            // API Key
            layout.Controls.Add(new Label { Text = "API Key:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            apiKeyTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(apiKeyTextBox, 1, row++);

            // AcqId
            layout.Controls.Add(new Label { Text = "AcqId:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            acqIdTextBox = new TextBox { Text = "970415", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(acqIdTextBox, 1, row++);

            // Bank Code
            layout.Controls.Add(new Label { Text = "Bank Code:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            bankCodeTextBox = new TextBox { Text = "970415", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(bankCodeTextBox, 1, row++);

            // Bank Name
            layout.Controls.Add(new Label { Text = "Bank Name:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            bankNameTextBox = new TextBox { Text = "Vietcombank", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(bankNameTextBox, 1, row++);

            // Account No
            layout.Controls.Add(new Label { Text = "Account No:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            accountNoTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(accountNoTextBox, 1, row++);

            // Account Name
            layout.Controls.Add(new Label { Text = "Account Name:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            accountNameTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(accountNameTextBox, 1, row++);

            // Template
            layout.Controls.Add(new Label { Text = "Template:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            templateComboBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            templateComboBox.Items.AddRange(new[] { "compact", "compact2", "qr_only" });
            templateComboBox.SelectedIndex = 0;
            layout.Controls.Add(templateComboBox, 1, row++);

            // Message Pattern
            layout.Controls.Add(new Label { Text = "Message Pattern:", TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            messagePatternTextBox = new TextBox { Text = "P{RoomId}_T{Month}", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            layout.Controls.Add(messagePatternTextBox, 1, row++);

            // Buttons panel
            var buttonsPanel = new Panel { Dock = DockStyle.Fill };

            saveButton = new Button
            {
                Text = "Lưu",
                Size = new Size(80, 35),
                Location = new Point(0, 0),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            saveButton.Click += SaveButton_Click;
            buttonsPanel.Controls.Add(saveButton);

            cancelButton = new Button
            {
                Text = "Hủy",
                Size = new Size(80, 35),
                Location = new Point(90, 0),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            cancelButton.Click += CancelButton_Click;
            buttonsPanel.Controls.Add(cancelButton);

            layout.Controls.Add(buttonsPanel, 1, row);

            ResumeLayout(false);
        }

        private void LoadConfig()
        {
            // Load from App.config or use defaults
            Config = new VietQRConfig
            {
                BaseUrl = System.Configuration.ConfigurationManager.AppSettings["N8nBaseUrl"] ?? "https://terrykozte.app.n8n.cloud/",
                ApiKeyHeader = System.Configuration.ConfigurationManager.AppSettings["N8nApiKeyHeader"] ?? "X-N8N-API-KEY",
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["N8nApiKey"] ?? "",
                AcqId = System.Configuration.ConfigurationManager.AppSettings["DefaultBankId"] ?? "970415",
                BankCode = System.Configuration.ConfigurationManager.AppSettings["DefaultBankId"] ?? "970415",
                BankName = "Vietcombank",
                AccountNo = System.Configuration.ConfigurationManager.AppSettings["DefaultAccountNo"] ?? "",
                AccountName = System.Configuration.ConfigurationManager.AppSettings["DefaultAccountName"] ?? "",
                Template = "compact",
                MessagePattern = "P{RoomId}_T{Month}"
            };

            // Update UI
            baseUrlTextBox.Text = Config.BaseUrl;
            apiKeyHeaderTextBox.Text = Config.ApiKeyHeader;
            apiKeyTextBox.Text = Config.ApiKey;
            acqIdTextBox.Text = Config.AcqId;
            bankCodeTextBox.Text = Config.BankCode;
            bankNameTextBox.Text = Config.BankName;
            accountNoTextBox.Text = Config.AccountNo;
            accountNameTextBox.Text = Config.AccountName;
            templateComboBox.SelectedItem = Config.Template;
            messagePatternTextBox.Text = Config.MessagePattern;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(baseUrlTextBox.Text))
                {
                    MessageBox.Show("Vui lòng nhập Base URL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                }

                if (string.IsNullOrWhiteSpace(accountNoTextBox.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(accountNameTextBox.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên chủ tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update config
                Config.BaseUrl = baseUrlTextBox.Text.Trim();
                Config.ApiKeyHeader = apiKeyHeaderTextBox.Text.Trim();
                Config.ApiKey = apiKeyTextBox.Text.Trim();
                Config.AcqId = acqIdTextBox.Text.Trim();
                Config.BankCode = bankCodeTextBox.Text.Trim();
                Config.BankName = bankNameTextBox.Text.Trim();
                Config.AccountNo = accountNoTextBox.Text.Trim();
                Config.AccountName = accountNameTextBox.Text.Trim();
                Config.Template = templateComboBox.SelectedItem?.ToString() ?? "compact";
                Config.MessagePattern = messagePatternTextBox.Text.Trim();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}