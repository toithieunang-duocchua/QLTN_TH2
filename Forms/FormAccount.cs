using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            tinhTrang.Items.Add("Đang chờ");
            tinhTrang.Items.Add("Đã duyệt");
            tinhTrang.Items.Add("Hủy duyệt");
            History.UseColumnTextForButtonValue = true;
            History.Text = "Xem lịch sử";
            // TODO: This line of code loads data into the 'qltnDataSet1.nguoidung' table. You can move, or remove it, as needed.
            this.nguoidungTableAdapter1.Fill(this.qltnDataSet1.nguoidung);
            // TODO: This line of code loads data into the 'qltnDataSet.nguoidung' table. You can move, or remove it, as needed.
            this.nguoidungTableAdapter.Fill(this.qltnDataSet.nguoidung);
            // TODO: This line of code loads data into the 'qltnDataSet.nguoidung' table. You can move, or remove it, as needed.

        }

        private void ChangePassWordButton_Click(object sender, EventArgs e)
        {
            var CPForm = new ChangePasswordForm();
            CPForm.Show();
        }

        private void tableLayoutPanel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventLogButton_Click(object sender, EventArgs e)
        {
            var ActivityLogForm = new ActivityLog();
            ActivityLogForm.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra cột được click có phải là cột "History"
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "History")
                {
                    // (Tùy bạn) Lấy thông tin hàng đó
                    string idNguoiDung = guna2DataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    ActivityLog frm = new ActivityLog();
                    frm.Show();

                }
            }
        }

        private void AdminRegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = new FormRegister();
            registerForm.Show();
        }

        private void tableLayoutPanel16_Paint_1(object sender, PaintEventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.nguoidungTableAdapter.Fill(this.qltnDataSet.nguoidung);
        }
    }
}
