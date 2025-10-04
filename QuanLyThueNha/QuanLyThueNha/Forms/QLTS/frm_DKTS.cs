using QuanLyThueNha;
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
    public partial class frm_DKTS : Form
    {
        public frm_DKTS()
        {
            InitializeComponent();
            this.Load += frm_DKTS_Load;

        }

        // Load data vào gridvieww
        private void LoadData()
        {
            DKTS_ser ser = new DKTS_ser();
            dataGridView1.DataSource = ser.showInfor();
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["tenTN"].DisplayIndex = 1;
            dataGridView1.Columns["diaChi"].DisplayIndex = 2;
            dataGridView1.Columns["sotang"].DisplayIndex = 3;
            dataGridView1.Columns["tongSoPhong"].DisplayIndex = 4;
            dataGridView1.Columns["ngayTao"].DisplayIndex = 5;
            dataGridView1.Columns["ghiChu"].DisplayIndex = 6;

            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["tenTN"].HeaderText = "Tên Tòa Nhà";
            dataGridView1.Columns["diaChi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["sotang"].HeaderText = "Số Tầng";
            dataGridView1.Columns["tongSoPhong"].HeaderText = "Tổng Số Phòng";
            dataGridView1.Columns["ngayTao"].HeaderText = "Ngày Tạo";
            dataGridView1.Columns["ghiChu"].HeaderText = "Ghi Chú";


            dataGridView1.DataSource = ser.showInfor();

        }

        private void frm_DKTS_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            DKTS_ser ser = new DKTS_ser();
            bool add = ser.getInfor(textTN.Text, textdc.Text, int.Parse(textst.Text), int.Parse(textslp.Text), Note.Text);
            MessageBox.Show(add ? "Done!" : "Error!");
            if (add)
            {
                LoadData(); 
            }
        }

        // KeyPress
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
                textTN.Text = row.Cells["tenTN"].Value.ToString();
                textdc.Text = row.Cells["diaChi"].Value.ToString();
                textst.Text = row.Cells["sotang"].Value.ToString();
                textslp.Text = row.Cells["tongSoPhong"].Value.ToString();
                Note.Text = row.Cells["ghiChu"].Value.ToString();
                
            }
        }

    }

}
