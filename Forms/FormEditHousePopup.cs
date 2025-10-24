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
    public partial class FormEditHousePopup : Form
    {
        private string originalHouseName;
        private string originalAddress;

        public FormEditHousePopup(string houseName, string address)
        {
            InitializeComponent();
            this.originalHouseName = houseName;
            this.originalAddress = address;
            SetupEventHandlers();
            ApplyCustomStyling();
            LoadData();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void ApplyCustomStyling()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadData()
        {
            txtHouseName.Text = originalHouseName;
            txtAddress.Text = originalAddress;
            
            // Set default values for other fields (you can modify these based on your data)
            txtArea.Text = "120.5";
            txtFloors.Text = "3";
            txtRooms.Text = "10";
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

            // Here you would typically update the database
            MessageBox.Show("Cập nhật thông tin nhà thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
