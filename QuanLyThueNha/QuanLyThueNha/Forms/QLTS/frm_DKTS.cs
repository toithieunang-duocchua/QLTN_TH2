using QuanLyThueNha.Models;
using QuanLyThueNha.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThueNha.Forms
{
    public partial class frm_DKTS : Form
    {
        public frm_DKTS()
        {
            InitializeComponent();
            this.Load += frm_DKTS_Load;
        }

        private void frm_DKTS_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DKTS_ser ser = new DKTS_ser();
                var data = ser.GetAllBuildings();

                dataGridView1.DataSource = data;

                dataGridView1.Columns["id"].HeaderText = "ID";
                dataGridView1.Columns["tenTN"].HeaderText = "Tên Tòa Nhà";
                dataGridView1.Columns["diaChi"].HeaderText = "Địa Chỉ";
                dataGridView1.Columns["sotang"].HeaderText = "Số Tầng";
                dataGridView1.Columns["tongSoPhong"].HeaderText = "Tổng Số Phòng";
                dataGridView1.Columns["ngaytao"].HeaderText = "Ngày Tạo";
                dataGridView1.Columns["ghichu"].HeaderText = "Ghi Chú";

                dataGridView1.Columns["id"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textTN.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tòa nhà!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textdc.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ!");
                    return;
                }

                int soTang = 0, soPhong = 0;
                int.TryParse(textst.Text.Trim(), out soTang);
                int.TryParse(textslp.Text.Trim(), out soPhong);

                var cn = new Cannha
                {
                    tenTN = textTN.Text.Trim(),
                    diaChi = textdc.Text.Trim(),
                    sotang = soTang,
                    tongSoPhong = soPhong,
                    ngaytao = DateTime.Now,
                    ghichu = Note.Text.Trim()
                };

                DKTS_ser ser = new DKTS_ser();
                bool added = ser.AddBuilding(cn);

                if (added)
                {
                    MessageBox.Show("Thêm tòa nhà thành công!");
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Kiểm tra lại dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi khi thêm tòa nhà: " + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearForm()
        {
            textTN.Clear();
            textdc.Clear();
            textst.Clear();
            textslp.Clear();
            Note.Clear();
        }

        private void textst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textslp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                textTN.Text = row.Cells["tenTN"].Value?.ToString();
                textdc.Text = row.Cells["diaChi"].Value?.ToString();
                textst.Text = row.Cells["sotang"].Value?.ToString();
                textslp.Text = row.Cells["tongSoPhong"].Value?.ToString();
                Note.Text = row.Cells["ghichu"].Value?.ToString();
            }
        }
    }
}
