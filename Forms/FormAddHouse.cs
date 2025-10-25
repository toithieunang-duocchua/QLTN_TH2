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
    public partial class FormAddHouse : Form
    {
        public FormAddHouse()
        {
            InitializeComponent();
            SetupEventHandlers();
            ApplyCustomStyling();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnReset.Click += BtnReset_Click;
        }

        private void ApplyCustomStyling()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable; // Cho phép resize
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new Size(600, 500); // Kích thước tối thiểu
            this.AutoScaleMode = AutoScaleMode.Dpi; // Cải thiện scaling
            
            // Set BackColor to prevent transparent background error
            this.BackColor = Color.White;
            
            // Thêm event handler cho resize
            this.Resize += FormAddHouse_Resize;
        }
        
        private void FormAddHouse_Resize(object sender, EventArgs e)
        {
            // Đảm bảo form không bị thu nhỏ quá mức
            if (this.Width < 600)
            {
                this.Width = 600;
            }
            if (this.Height < 500)
            {
                this.Height = 500;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtHouseName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHouseName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                MessageBox.Show("Vui lòng nhập diện tích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArea.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFloors.Text))
            {
                MessageBox.Show("Vui lòng nhập số tầng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFloors.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRooms.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRooms.Focus();
                return;
            }

            // Validate numeric fields
            if (!decimal.TryParse(txtArea.Text, out decimal area))
            {
                MessageBox.Show("Diện tích phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArea.Focus();
                return;
            }

            if (!int.TryParse(txtFloors.Text, out int floors))
            {
                MessageBox.Show("Số tầng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFloors.Focus();
                return;
            }

            if (!int.TryParse(txtRooms.Text, out int rooms))
            {
                MessageBox.Show("Số phòng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRooms.Focus();
                return;
            }

            // Here you would typically save to database
            MessageBox.Show("Thêm nhà thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtHouseName.Clear();
            txtArea.Clear();
            txtFloors.Clear();
            txtRooms.Clear();
            txtAddress.Clear();
        }
    }
}