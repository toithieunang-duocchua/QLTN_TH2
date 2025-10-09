
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
    public partial class QLHD : Form
    {
        public QLHD()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btn_them_click(object sender, EventArgs e)
        {
            MainMenu mn = (MainMenu)Application.OpenForms["MainMenu"];
            if (mn != null)
            {
                mn.openChildForm(new addHD());
            }
        }

        private void QLHD_Load(object sender, EventArgs e)
        {

        }
        //Tao dataset

        //private void crytalReportViewer1_Load(object sender, EventArgs e)
        //{
        //    DataTable2TableAdapter hd = new DataTable2TableAdapter();
        //    DataTable nt = hd.getData();
        //    ReportDocument hopdong = new ReportDocument();
        //    hopdong.Load(@"C:\Users\Admin\source\repos\QuanLyThueNha\QuanLyThueNha\Report\HopDong.rpt");
        //    hopdong.SetDataSource(nt);
        //    crystalReportViewer1.ReportSource = hopdong;
        //}




    }
}
