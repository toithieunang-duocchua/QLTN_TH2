using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormTenant : Form
    {
        private readonly TenantService tenantService = new TenantService();
        private readonly BindingSource tenantBindingSource = new BindingSource();
        private List<Tenant> tenants = new List<Tenant>();

        public FormTenant()
        {
            InitializeComponent();
            ConfigureGrid();
            dataGridViewTenants.DataSource = tenantBindingSource;
            Load += FormTenant_Load;
        }

        private void FormTenant_Load(object sender, EventArgs e)
        {
            LoadTenantData();
        }

        private void ConfigureGrid()
        {
            dataGridViewTenants.AutoGenerateColumns = false;

            dataGridViewTenants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewTenants.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dataGridViewTenants.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewTenants.DefaultCellStyle.BackColor = Color.White;
            dataGridViewTenants.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewTenants.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewTenants.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewTenants.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dataGridViewTenants.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);

            TenantNameColumn.DataPropertyName = nameof(Tenant.FullName);
            RoomColumn.DataPropertyName = nameof(Tenant.RoomCode);
            PhoneColumn.DataPropertyName = nameof(Tenant.PhoneNumber);
            StatusColumn.DataPropertyName = nameof(Tenant.ContractStatus);

            if (EditColumn != null)
            {
                EditColumn.TrackVisitedState = false;
                EditColumn.LinkColor = Color.FromArgb(94, 148, 255);
                EditColumn.VisitedLinkColor = Color.FromArgb(94, 148, 255);
                EditColumn.ActiveLinkColor = Color.FromArgb(94, 148, 255);
            }

            if (DeleteColumn != null)
            {
                DeleteColumn.TrackVisitedState = false;
                DeleteColumn.LinkColor = Color.FromArgb(255, 77, 79);
                DeleteColumn.VisitedLinkColor = Color.FromArgb(255, 77, 79);
                DeleteColumn.ActiveLinkColor = Color.FromArgb(255, 77, 79);
            }
        }

        private void LoadTenantData()
        {
            try
            {
                tenants = tenantService.GetTenantSummaries().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Khong the tai danh sach nguoi thue.\nChi tiet: " + ex.Message,
                    "Loi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();

            IEnumerable<Tenant> filtered = tenants;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(t =>
                    (!string.IsNullOrEmpty(t.FullName) && t.FullName.ToLowerInvariant().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(t.RoomCode) && t.RoomCode.ToLowerInvariant().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(t.PhoneNumber) && t.PhoneNumber.ToLowerInvariant().Contains(keyword)));
            }

            tenantBindingSource.DataSource = filtered.ToList();
            tenantBindingSource.ResetBindings(false);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void BtnAddTenant_Click(object sender, EventArgs e)
        {
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm == null)
            {
                return;
            }

            FormAddTenant formAddTenant = new FormAddTenant
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainForm.LoadFormIntoMainPanel(formAddTenant);
        }

        private void DataGridViewTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (!(tenantBindingSource[e.RowIndex] is Tenant tenant))
            {
                return;
            }

            // Handle Edit button
            if (e.ColumnIndex == EditColumn.Index)
            {
                EditTenant(tenant);
            }
            // Handle Delete button
            else if (e.ColumnIndex == DeleteColumn.Index)
            {
                DeleteTenant(tenant);
            }
        }

        private void EditTenant(Tenant tenant)
        {
            if (tenant == null)
            {
                return;
            }

            // TODO: Implement edit tenant functionality
            // This will open an edit form or inline edit
            MessageBox.Show(
                $"Chuc nang sua nguoi thue se duoc phat trien.\n\nThong tin:\nTen: {tenant.FullName}\nPhong: {tenant.RoomCode}",
                "Sua nguoi thue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void DeleteTenant(Tenant tenant)
        {
            if (tenant == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Ban co chac chan muon xoa nguoi thue '{tenant.FullName}'?\n\nPhong: {tenant.RoomCode}\nSo dien thoai: {tenant.PhoneNumber}",
                "Xac nhan xoa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // TODO: Implement delete tenant functionality
                    // tenantService.DeleteTenant(tenant.Id);
                    MessageBox.Show(
                        $"Da xoa nguoi thue '{tenant.FullName}' thanh cong.",
                        "Xoa thanh cong",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                    // Reload data
                    LoadTenantData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Khong the xoa nguoi thue.\nChi tiet: {ex.Message}",
                        "Loi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ShowTenantDetail(Tenant tenant)
        {
            string room = string.IsNullOrWhiteSpace(tenant.RoomCode) ? "Chua cap" : tenant.RoomCode;
            string message =
                $"Ho ten: {tenant.FullName}\n" +
                $"Phong: {room}\n" +
                $"Dien thoai: {tenant.PhoneNumber}\n" +
                $"Email: {tenant.Email}\n" +
                $"Ghi chu: {tenant.Notes}";

            MessageBox.Show(message, "Thong tin nguoi thue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataGridViewTenants_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == RoomColumn.Index && e.Value is string value)
            {
                e.Value = string.IsNullOrWhiteSpace(value) ? "Chua cap" : value;
            }

            if (e.ColumnIndex == StatusColumn.Index)
            {
                string status = e.Value?.ToString() ?? string.Empty;
                
                // Format text và màu nền
                switch (status.ToLowerInvariant())
                {
                    case "đang hiệu lực":
                    case "dang hieu luc":
                        e.Value = "Đang thuê";
                        e.CellStyle.BackColor = Color.FromArgb(220, 237, 200);
                        e.CellStyle.ForeColor = Color.FromArgb(76, 128, 50);
                        break;
                    case "đã kết thúc":
                    case "da ket thuc":
                        e.Value = "Đã trả phòng";
                        e.CellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        e.CellStyle.ForeColor = Color.FromArgb(140, 140, 140);
                        break;
                    case "hết hạn":
                    case "het han":
                        e.Value = "Lịch trả phòng";
                        e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                        e.CellStyle.ForeColor = Color.FromArgb(170, 120, 0);
                        break;
                    case "chưa có":
                    case "chua co":
                    default:
                        if (string.IsNullOrWhiteSpace(status))
                        {
                            e.Value = "Chưa có";
                            e.CellStyle.BackColor = Color.FromArgb(250, 250, 250);
                            e.CellStyle.ForeColor = Color.FromArgb(150, 150, 150);
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(250, 250, 250);
                            e.CellStyle.ForeColor = Color.FromArgb(100, 100, 100);
                        }
                        break;
                }

                // Center align cho cột status
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
