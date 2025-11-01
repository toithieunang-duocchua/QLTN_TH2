using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class ActivityLog : Form
    {
        public ActivityLog()
        {
            InitializeComponent();
        }

        private void ActivityLog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qltnDataSet2.loghoatdong' table. You can move, or remove it, as needed.
            this.loghoatdongTableAdapter.Fill(this.qltnDataSet2.loghoatdong);
            // TODO: This line of code loads data into the 'qltnDataSet2.nguoithue' table. You can move, or remove it, as needed.
            this.nguoithueTableAdapter.Fill(this.qltnDataSet2.nguoithue);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
