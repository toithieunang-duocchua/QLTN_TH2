using QuanLyThueNha.Models;
using QuanLyThueNha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThueNha.Forms
{
    public partial class frm_QLNT : Form
    {
        bool isAdding = false;
        bool isEditing = false;
        int editingTenantId = -1;

        public frm_QLNT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetEnableFields(false);
            LoadComboBoxToaNha();
            LoadComboBoxGioiTinh();
            LoadDataGridView();

        }
        private void SetEnableFields(bool isEnabled)
        {
            hoten.Enabled = isEnabled;
            cangcuoc.Enabled = isEnabled;
            sodienthoai.Enabled = isEnabled;
            ngaysinh.Enabled = isEnabled;
            ngaythue.Enabled = isEnabled;
            toanha.Enabled = isEnabled;
            mphong.Enabled = isEnabled;
            gtinh.Enabled = isEnabled;
            diachi.Enabled = isEnabled;
        }

        private void LoadComboBoxToaNha()
        {
            DKTS_ser s = new DKTS_ser();
            var dt = s.GetAllBuildings();
            toanha.DataSource = dt;
            toanha.DisplayMember = "tenTN";
            toanha.ValueMember = "id";
            toanha.SelectedIndex = -1;
            toanha.SelectedIndexChanged += toanha_SelectedIndexChanged;
        }
        private void toanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBuilding = toanha.SelectedItem as Cannha;
            if (selectedBuilding == null) return;

            int idCanNha = selectedBuilding.id;

            QLNT_ser ser = new QLNT_ser();
            List<Phong> rooms = ser.GetRoomsByBuilding(idCanNha);

            if (rooms != null && rooms.Count > 0)
            {
                mphong.DataSource = rooms;
                mphong.DisplayMember = "maPhong";
                mphong.ValueMember = "id";
                mphong.SelectedIndex = -1;
            }
            else
            {
                mphong.DataSource = null;
            }
        }




        private void ClearFields()
        {
            hoten.Text = "";
            cangcuoc.Text = "";
            sodienthoai.Text = "";
            ngaysinh.Value = DateTime.Now;
            toanha.SelectedIndex = -1;
            mphong.SelectedIndex = -1;
            gtinh.SelectedIndex = -1;
            diachi.Text = "";
        }
        private void them_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                them.Text = "Lưu";
                xoa.Enabled = false;
                chinhsua.Enabled = false;

                SetEnableFields(true);
                ClearFields();
                hoten.Focus();
            }
            else
            {
                try
                {

                    var nt = new nguoithue()
                    {
                        hoTen = hoten.Text.Trim(),
                        soCCCD = cangcuoc.Text.Trim(),
                        soDienThoai = sodienthoai.Text.Trim(),
                        email = "",
                        diaChiThuongTru = diachi.Text.Trim(),
                        gioiTinh = gtinh.Text,
                        ngaySinh = ngaysinh.Value,
                        ngayTao = DateTime.Now,
                        ghiChu = ""
                    };


                    QLNT_ser s = new QLNT_ser();
                    bool success = s.AddTenant(nt);


                    if (success)
                    {
                        MessageBox.Show("Thêm người thuê thành công!");
                        LoadDataGridView();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show(" Lỗi khi thêm người thuê!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

                // Reset
                isAdding = false;
                them.Text = "Thêm";
                xoa.Enabled = true;
                chinhsua.Enabled = true;
                SetEnableFields(false);
            }
        }

        private void LoadComboBoxGioiTinh()
        {
            gtinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            gtinh.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                hoten.Text = row.Cells["hoTen"].Value.ToString();
                cangcuoc.Text = row.Cells["soCCCD"].Value.ToString();
                sodienthoai.Text = row.Cells["soDienThoai"].Value.ToString();
                ngaysinh.Value = Convert.ToDateTime(row.Cells["ngayThue"].Value);
                gtinh.Text = row.Cells["gioiTinh"].Value.ToString();
            }

        }
        private void LoadDataGridView()
        {
            QLNT_ser s = new QLNT_ser();
            dataGridView1.DataSource = s.GetTenants();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa người thuê này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    int tenantId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    QLNT_ser s = new QLNT_ser();
                    bool success = s.DeleteTenant(tenantId);
                    if (success)
                    {
                        MessageBox.Show("Xóa người thuê thành công!");
                        LoadDataGridView();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa người thuê!");
                    }
                }
            }
        }

   
        private void chinhsua_Click(object sender, EventArgs e)
        {
            QLNT_ser s = new QLNT_ser();

            if (!isEditing)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn người thuê cần chỉnh sửa!");
                    return;
                }

                editingTenantId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                var tenant = s.GetTenants().FirstOrDefault(t => t.id == editingTenantId);
                if (tenant == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin người thuê!");
                    return;
                }

                hoten.Text = tenant.hoTen;
                cangcuoc.Text = tenant.soCCCD;
                sodienthoai.Text = tenant.soDienThoai;
                gtinh.Text = tenant.gioiTinh;
                ngaysinh.Value = tenant.ngaySinh ?? DateTime.Now;
                diachi.Text = tenant.diaChiThuongTru;

                SetEnableFields(true);
                chinhsua.Text = "Lưu";
                them.Enabled = false;
                xoa.Enabled = false;
                isEditing = true;
            }
            else
            {
                try
                {
                    var updatedTenant = new nguoithue()
                    {
                        id = editingTenantId,
                        hoTen = hoten.Text.Trim(),
                        soCCCD = cangcuoc.Text.Trim(),
                        soDienThoai = sodienthoai.Text.Trim(),
                        email = "",
                        diaChiThuongTru = diachi.Text.Trim(),
                        gioiTinh = gtinh.Text,
                        ngaySinh = ngaysinh.Value,
                        ghiChu = ""
                    };

                    bool success = s.UpdateTenant(updatedTenant);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thông tin người thuê thành công!");
                        LoadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật người thuê!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

                isEditing = false;
                chinhsua.Text = "Chỉnh sửa";
                them.Enabled = true;
                xoa.Enabled = true;
                SetEnableFields(false);
            }
        }

    }
}
