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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tssubmenu.Visible = false;

        }

        private void btn_taisan_Click(object sender, EventArgs e)
        {
            tssubmenu.Visible = !tssubmenu.Visible;
        }

        private Form currentFormChild;
        public void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //private void btn_logout_Click(object sender, EventArgs e)
        //{
        //    this.Hide();

        //    FormLogin loginForm = new FormLogin();
        //    loginForm.Show();

        //    this.Close();
        //}

        //private void btn_user_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new UserProfile());
        //    labelPage.Text = btn_user.Text;
        //}

        
        private void btnsubqQL_Click(object sender, EventArgs e)
        {
            openChildForm(new QLP());
            labelPage.Text = btn_taisan.Text;
        }

        private void btnsubDK_Click(object sender, EventArgs e)
        {
            openChildForm(new DKTS());
            labelPage.Text = btn_taisan.Text;
        }
        private void btn_ngthue_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNT());
            labelPage.Text = btn_ngthue.Text;
        }
        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            openChildForm(new QLHD());
            labelPage.Text = btn_hopdong.Text;
        }
        //private void btn_taichinh_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new TC());
        //    labelPage.Text = btn_taichinh.Text;
        //}
        //private void btn_thanhtoan__Click(object sender, EventArgs e)
        //{
        //    openChildForm(new TT());
        //    labelPage.Text = btn_thanhtoan_.Text;
        //}
        //private void btn_bctk_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new BCTK());
        //    labelPage.Text = btn_bctk.Text;
        //}
        //private void btn_btsc_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new BTSC());
        //    labelPage.Text = btn_btsc.Text;
        //}
        //private void btn_bm_ql_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new BMQL());
        //    labelPage.Text = btn_bm_ql.Text;
        //}


    }
}
