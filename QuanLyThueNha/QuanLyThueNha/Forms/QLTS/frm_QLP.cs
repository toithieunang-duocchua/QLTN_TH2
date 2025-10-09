using QuanLyThueNha.Models;
using QuanLyThueNha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThueNha.Forms
{
    public partial class frm_QLP : Form
    {
        public frm_QLP()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            LoadComboBoxToaNha();
            LoadComboBoxLoaiPhong();
            LoadComboBoxTrangThai();
            LoadData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (toanha.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Tòa Nhà trước khi thêm phòng!");
                return;
            }

            groupBox2.Visible = !groupBox2.Visible;
        }

        private void LoadData()
        {
            QLP_ser ser = new QLP_ser();
            var dt = ser.ShowRoomInformation(); 
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("maPhong"))
            {
                dataGridView1.Columns["maPhong"].DisplayIndex = 0;
            }
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

        private void LoadComboBoxLoaiPhong()
        {
            loaiphong.Items.AddRange(new string[]
                { "Phòng đơn", "Phòng đôi", "Ban công", "Cửa sổ lớn" });
        }

        private void LoadComboBoxTrangThai()
        {
            trangthai.Items.AddRange(new string[]
                { "Trống", "Đang thuê", "Dự kiến" });
        }

        private void toanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toanha.SelectedIndex == -1) return;

            int idCanNha = Convert.ToInt32(toanha.SelectedValue);

            DKTS_ser ser = new DKTS_ser();
            Cannha building = ser.GetBuildingById(idCanNha);

            if (building != null)
            {
                diachi.Text = building.diaChi;
                sotang.Text = building.sotang.ToString();
                sophong.Text = building.tongSoPhong.ToString();
                ghichu.Text = building.ghichu;
            }

            QLP_ser p = new QLP_ser();
            var rooms = p.GetRoomsByBuilding(idCanNha); 
            dataGridView2.DataSource = rooms;

            btn_them.Enabled = true;
        }


        private void luu_Click(object sender, EventArgs e)
        {
            if (toanha.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Tòa Nhà trước!");
                return;
            }

            try
            {
                int idCanNha = Convert.ToInt32(toanha.SelectedValue);
                int idLoaiPhong = loaiphong.SelectedIndex + 1;
                string maPhong = maphong.Text.Trim();
                double dienTich = float.Parse(dientich.Text.Trim());
                decimal giaThue = decimal.Parse(giathue.Text.Trim());
                int soNguoiO = int.Parse(nguoio.Text.Trim());
                string trangThai = trangthai.Text.Trim();
                string ghiChu = txtNote.Text.Trim();
                
                Phong phong = new Phong
                {
                    maPhong = maPhong,
                    idCanNha = idCanNha,
                    idLoaiPhong = idLoaiPhong,
                    dienTich = dienTich,
                    soNguoiO = soNguoiO,
                    giaThue = giaThue,
                    trangThai = trangThai,
                    ghiChu = ghiChu,
                    ngayCapNhat = DateTime.Now,
                    ngayTao = DateTime.Now
                };

                QLP_ser p = new QLP_ser();

                bool kq = p.AddRoom(phong);

                if (kq)
                {
                    MessageBox.Show("Thêm phòng thành công!");
                    dataGridView2.DataSource = p.GetRoomsByBuilding(idCanNha); 
                    ClearFormInputs();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void ClearFormInputs()
        {
            maphong.Clear();
            dientich.Clear();
            giathue.Clear();
            nguoio.Clear();
            txtNote.Clear();
            trangthai.SelectedIndex = -1;
            loaiphong.SelectedIndex = -1;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex]; 
                maphong.Text = row.Cells["maPhong"].Value.ToString();
                dientich.Text = row.Cells["dienTich"].Value.ToString();
                nguoio.Text = row.Cells["soNguoiO"].Value.ToString();
                giathue.Text = row.Cells["giaThue"].Value.ToString();
                trangthai.Text = row.Cells["trangThai"].Value.ToString();
                txtNote.Text = row.Cells["ghiChu"].Value.ToString();
            }
        }

        private void dientich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void nguoio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void giathue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
