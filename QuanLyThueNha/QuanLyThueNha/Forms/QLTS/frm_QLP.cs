using QuanLyThueNha.Services;
using System;
using System.Data;
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
            LoadData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = !groupBox2.Visible;
        }

        private void LoadData()
        {
            QLP_ser ser = new QLP_ser();
            DataTable dt = ser.showInfor();
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("maPhong"))
            {
                dataGridView1.Columns["maPhong"].DisplayIndex = 0;
            }
        }


        private void LoadComboBoxToaNha()
        {
            DKTS_ser s = new DKTS_ser();
            DataTable dt = s.showcannha();

            toanha.DataSource = dt;
            toanha.DisplayMember = "tenTN";
            toanha.ValueMember = "tenTN";
            toanha.SelectedIndex = -1;
            toanha.SelectedIndexChanged += toanha_SelectedIndexChanged;
        }

        private void toanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toanha.SelectedIndex != -1)
            {
                DKTS_ser ser = new DKTS_ser();
                DataRow row = ser.getInforByName(toanha.Text);

                if (row != null)
                {
                    diachi.Text = row["diaChi"].ToString();
                    sotang.Text = row["sotang"].ToString();
                    sophong.Text = row["tongSoPhong"].ToString();
                    ghichu.Text = row["ghiChu"].ToString();
                }
            }
            LoadData();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            QLP_ser ser = new QLP_ser();
            bool add = ser.getInforRoom(maphong.Text, int.Parse(row["id"].ToString()), int.Parse(loaiphong.SelectedValue.ToString()), float.Parse(dientich.Text), decimal.Parse(giathue.Text), trangthai.Text, ghichu.Text, int.Parse(nguoio.Text));
            if (add)
            {
                LoadData();
            }
        }

    }
}