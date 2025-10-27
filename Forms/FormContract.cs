using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    public partial class FormContract : Form
    {
        private List<ContractData> contracts = new List<ContractData>();
        private int currentPage = 1;
        private const int itemsPerPage = 10;

        public FormContract()
        {
            InitializeComponent();
            InitializeData();
            SetupEventHandlers();
            LoadContracts();
        }

        private void InitializeData()
        {
            contracts.Add(new ContractData("HD-001", "Nguyễn Văn A", "2025-01-01", "2025-12-31", "P101", "Đang hiệu lực"));
            contracts.Add(new ContractData("HD-002", "Công ty B", "2024-06-01", "2025-06-01", "P203", "Đã hết hạn"));
            contracts.Add(new ContractData("HD-003", "Trần Thị C", "2025-09-01", "2026-08-31", "P305", "Đang hiệu lực"));
        }

        private void SetupEventHandlers()
        {
            // Search
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Nhập mã HĐ hoặc tên khách hàng...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.White;
                }
            };
            this.txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Nhập mã HĐ hoặc tên khách hàng...";
                    txtSearch.PlaceholderForeColor = Color.FromArgb(100, 116, 139);
                }
            };

            // Status filter
            this.cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;

            // Buttons
            this.btnAddContract.Click += BtnAddContract_Click;
            this.btnPrevious.Click += BtnPrevious_Click;
            this.btnNext.Click += BtnNext_Click;
            this.btnExport.Click += BtnExport_Click;

            // Setup initial placeholder
            this.txtSearch.Text = "";
            this.txtSearch.PlaceholderText = "Nhập mã HĐ hoặc tên khách hàng...";
        }

        private void LoadContracts()
        {
            dgvContracts.Rows.Clear();

            foreach (var contract in contracts)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvContracts,
                    contract.Code,
                    contract.Customer,
                    contract.StartDate,
                    contract.EndDate,
                    contract.Room,
                    contract.Status,
                    "Xem",
                    "Xóa"
                );

                // Style status cells with colors and pill shape
                var statusCell = row.Cells[5];
                statusCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                statusCell.Style.ForeColor = Color.White;
                statusCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                if (contract.Status == "Đang hiệu lực")
                {
                    statusCell.Style.BackColor = Color.FromArgb(34, 197, 94);
                }
                else if (contract.Status == "Đã hết hạn")
                {
                    statusCell.Style.BackColor = Color.FromArgb(239, 68, 68);
                }
                else
                {
                    statusCell.Style.BackColor = Color.FromArgb(148, 163, 184);
                }

                // Add padding to make it look like a pill
                statusCell.Style.Padding = new Padding(15, 8, 15, 8);
                
                // Set minimum row height to avoid clipping
                row.MinimumHeight = 45;
                
                // Style the action cells (View and Delete) - columns 6 and 7
                if (row.Cells.Count > 6)
                {
                    row.Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (row.Cells.Count > 7)
                {
                    row.Cells[7].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvContracts.Rows.Add(row);
            }

            UpdatePagination();
        }

        private void UpdatePagination()
        {
            int totalPages = (int)Math.Ceiling((double)contracts.Count / itemsPerPage);
            lblPageInfo.Text = $"Trang {currentPage} / {totalPages} — {contracts.Count} kết quả";

            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterContracts();
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterContracts();
        }

        private void FilterContracts()
        {
            string searchText = txtSearch.Text.ToLower();

            // Check if it's just the placeholder text
            if (searchText == "nhập mã hđ hoặc tên khách hàng...")
            {
                searchText = "";
            }

            string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            var filtered = contracts.Where(c =>
                (string.IsNullOrEmpty(searchText) ||
                 c.Code.ToLower().Contains(searchText) ||
                 c.Customer.ToLower().Contains(searchText)) &&
                (selectedStatus == "Tất cả trạng thái" || c.Status == selectedStatus)
            ).ToList();

            dgvContracts.Rows.Clear();
            foreach (var contract in filtered)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvContracts,
                    contract.Code,
                    contract.Customer,
                    contract.StartDate,
                    contract.EndDate,
                    contract.Room,
                    contract.Status,
                    "Xem",
                    "Xóa"
                );

                var statusCell = row.Cells[5];
                statusCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                statusCell.Style.ForeColor = Color.White;
                statusCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                if (contract.Status == "Đang hiệu lực")
                {
                    statusCell.Style.BackColor = Color.FromArgb(34, 197, 94);
                }
                else if (contract.Status == "Đã hết hạn")
                {
                    statusCell.Style.BackColor = Color.FromArgb(239, 68, 68);
                }
                else
                {
                    statusCell.Style.BackColor = Color.FromArgb(148, 163, 184);
                }

                // Add padding to make it look like a pill
                statusCell.Style.Padding = new Padding(15, 8, 15, 8);
                
                // Set minimum row height to avoid clipping
                row.MinimumHeight = 45;

                dgvContracts.Rows.Add(row);
            }

            UpdatePagination();
        }

        private void BtnAddContract_Click(object sender, EventArgs e)
        {
            // Tạo form thêm hợp đồng mới
            FormAddContract addContractForm = new FormAddContract();
            
            // Tìm FormMainSystem để load form vào mainPanel
            FormMainSystem mainForm = null;
            Control current = this;
            
            // Tìm FormMainSystem trong control tree
            while (current != null)
            {
                if (current is FormMainSystem)
                {
                    mainForm = current as FormMainSystem;
                    break;
                }
                current = current.Parent;
            }
            
            if (mainForm != null)
            {
                // Load vào mainPanel của FormMainSystem
                mainForm.LoadFormIntoMainPanel(addContractForm);
            }
            else
            {
                // Fallback: hiển thị như dialog nếu không tìm thấy
                addContractForm.ShowDialog();
                addContractForm.Dispose();
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadContracts();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)contracts.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadContracts();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng xuất CSV sẽ được triển khai.",
                "Chức năng sắp phát hành",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void dgvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Xem (cột 6)
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                string contractCode = dgvContracts.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                string customer = dgvContracts.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                string startDate = dgvContracts.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                string endDate = dgvContracts.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string room = dgvContracts.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
                string status = dgvContracts.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";

                // Mở FormEditContract để xem/chỉnh sửa hợp đồng
                FormEditContract editContractForm = new FormEditContract();
                editContractForm.LoadContractData(contractCode, customer, startDate, endDate, room, status);
                
                // Tìm FormMainSystem bằng cách duyệt cây control
                FormMainSystem mainForm = null;
                Control current = this;
                
                // Tìm FormMainSystem trong control tree
                while (current != null)
                {
                    if (current is FormMainSystem)
                    {
                        mainForm = current as FormMainSystem;
                        break;
                    }
                    current = current.Parent;
                }
                
                if (mainForm != null)
                {
                    // Load vào mainPanel của FormMainSystem
                    mainForm.LoadFormIntoMainPanel(editContractForm);
                }
                else
                {
                    // Fallback: hiển thị như dialog nếu không tìm thấy
                    editContractForm.ShowDialog();
                    editContractForm.Dispose();
                }
            }
            // Kiểm tra nếu click vào cột Xóa (cột 7)
            else if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                string contractCode = dgvContracts.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                string customer = dgvContracts.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa hợp đồng {contractCode} của {customer}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    // Xóa hợp đồng khỏi danh sách
                    var contractToRemove = contracts.FirstOrDefault(c => c.Code == contractCode);
                    if (contractToRemove != null)
                    {
                        contracts.Remove(contractToRemove);
                        LoadContracts();
                        MessageBox.Show("Xóa hợp đồng thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private class ContractData
        {
            public string Code { get; set; }
            public string Customer { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Room { get; set; }
            public string Status { get; set; }

            public ContractData(string code, string customer, string startDate, string endDate, string room, string status)
            {
                Code = code;
                Customer = customer;
                StartDate = startDate;
                EndDate = endDate;
                Room = room;
                Status = status;
            }
        }
    }
}
