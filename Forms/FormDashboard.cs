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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            // Make each dashboard panel fill its grid cell
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel2.Dock = DockStyle.Fill;
            guna2Panel3.Dock = DockStyle.Fill;
            guna2Panel4.Dock = DockStyle.Fill;
            guna2Panel5.Dock = DockStyle.Fill;
            guna2Panel6.Dock = DockStyle.Fill;
            guna2Panel7.Dock = DockStyle.Fill;
            guna2Panel8.Dock = DockStyle.Fill;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
