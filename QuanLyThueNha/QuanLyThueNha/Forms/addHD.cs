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
    public partial class addHD : Form
    {
        public addHD()
        {
            InitializeComponent();
        }

        
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = (MainMenu)Application.OpenForms["MainMenu"];
            if (mainmenu != null)
            {
                mainmenu.openChildForm(new QLHD());
            }
        }
    }
}
