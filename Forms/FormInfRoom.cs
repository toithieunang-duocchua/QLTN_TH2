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
    public partial class FormInfRoom : Form
    {
        private string roomNumber;
        private bool isEditMode = false;

        public FormInfRoom(string roomNumber)
        {
            this.roomNumber = roomNumber;
            InitializeComponent();
            SetupForm();
            LoadRoomData();
        }

        private void SetupForm()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable; // Cho phép resize
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new Size(800, 700); // Kích thước tối thiểu
            this.AutoScaleMode = AutoScaleMode.Dpi; // Cải thiện scaling
            
            // Thêm event handler cho resize
            this.Resize += FormInfRoom_Resize;
        }
        
        private void FormInfRoom_Resize(object sender, EventArgs e)
        {
            // Đảm bảo form không bị thu nhỏ quá mức
            if (this.Width < 800)
            {
                this.Width = 800;
            }
            if (this.Height < 700)
            {
                this.Height = 700;
            }
        }

        private void LoadRoomData()
        {
            // Load room data based on room number
            txtRoomCode.Text = $"P{roomNumber}";
            
            // Set furniture based on room (example data)
            if (roomNumber == "101")
            {
                txtArea.Text = "25";
                txtRentPrice.Text = "3500000";
                cmbStatus.SelectedIndex = 0; // "Trống"
                txtNotes.Text = "Phòng có ban công nhỏ, hướng gió mát.";
                
                // Furniture for room 101
                chkRefrigerator.Checked = true;
                chkAirConditioner.Checked = true;
                chkWashingMachine.Checked = false;
                chkTable.Checked = true;
                chkWardrobe.Checked = true;
                chkChair.Checked = false;
                checkNone.Checked = false;
            }
            else if (roomNumber == "102")
            {
                txtArea.Text = "25";
                txtRentPrice.Text = "3800000";
                cmbStatus.SelectedIndex = 1; // "Đang thuê"
                txtNotes.Text = "Phòng có nội thất đầy đủ.";
                
                // Furniture for room 102
                chkRefrigerator.Checked = true;
                chkAirConditioner.Checked = true;
                chkWashingMachine.Checked = true;
                chkTable.Checked = true;
                chkWardrobe.Checked = true;
                chkChair.Checked = true;
                checkNone.Checked = false;
            }
            else if (roomNumber == "103")
            {
                txtArea.Text = "30";
                txtRentPrice.Text = "4000000";
                cmbStatus.SelectedIndex = 0; // "Trống"
                txtNotes.Text = "Phòng rộng rãi, có view đẹp.";
                
                // Furniture for room 103
                chkRefrigerator.Checked = true;
                chkAirConditioner.Checked = true;
                chkWashingMachine.Checked = false;
                chkTable.Checked = true;
                chkWardrobe.Checked = true;
                chkChair.Checked = true;
                checkNone.Checked = false;
            }
            else if (roomNumber == "201")
            {
                txtArea.Text = "25";
                txtRentPrice.Text = "3500000";
                cmbStatus.SelectedIndex = 0; // "Trống"
                txtNotes.Text = "Phòng tầng 2, yên tĩnh.";
                
                // Furniture for room 201
                chkRefrigerator.Checked = true;
                chkAirConditioner.Checked = true;
                chkWashingMachine.Checked = false;
                chkTable.Checked = true;
                chkWardrobe.Checked = true;
                chkChair.Checked = false;
                checkNone.Checked = false;
            }

            // Set all controls to read-only initially
            SetControlsReadOnly(true);
        }

        private void SetControlsReadOnly(bool readOnly)
        {
            txtRoomCode.ReadOnly = readOnly;
            txtArea.ReadOnly = readOnly;
            txtRentPrice.ReadOnly = readOnly;
            txtNotes.ReadOnly = readOnly;

            // Enable/disable checkboxes and combobox
            chkRefrigerator.Enabled = !readOnly;
            chkAirConditioner.Enabled = !readOnly;
            chkWashingMachine.Enabled = !readOnly;
            chkTable.Enabled = !readOnly;
            chkWardrobe.Enabled = !readOnly;
            chkChair.Enabled = !readOnly;
            checkNone.Enabled = !readOnly;
            cmbStatus.Enabled = !readOnly;

            // Update button visibility
            if (readOnly)
            {
                btnEdit.Text = "Sửa";
                btnEdit.FillColor = Color.FromArgb(155, 89, 182);
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnEdit.Text = "Hủy";
                btnEdit.FillColor = Color.FromArgb(231, 76, 60);
                btnEdit.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                // Switch to edit mode
                isEditMode = true;
                SetControlsReadOnly(false);
            }
            else
            {
                // Cancel editing - switch back to view mode
                isEditMode = false;
                SetControlsReadOnly(true);
                LoadRoomData(); // Reload original data
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Save changes
            SaveChanges();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to room management
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormRoom formRoom = new FormRoom("Nhà A", "19 Nguyễn Thị Thập, Quận 7"); // Default values
                formRoom.TopLevel = false;
                formRoom.FormBorderStyle = FormBorderStyle.None;
                formRoom.Dock = DockStyle.Fill;

                mainForm.LoadFormIntoMainPanel(formRoom);
            }
        }

        private void SaveChanges()
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                MessageBox.Show("Vui lòng nhập diện tích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArea.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRentPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập giá thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRentPrice.Focus();
                return;
            }

            // Get furniture list
            List<string> furnitureList = new List<string>();
            if (chkRefrigerator.Checked) furnitureList.Add("Tủ lạnh");
            if (chkAirConditioner.Checked) furnitureList.Add("Máy lạnh");
            if (chkWashingMachine.Checked) furnitureList.Add("Máy giặt");
            if (chkTable.Checked) furnitureList.Add("Bàn");
            if (chkWardrobe.Checked) furnitureList.Add("Tủ áo quần");
            if (chkChair.Checked) furnitureList.Add("Ghế");
            if (checkNone.Checked) furnitureList.Add("Không có nội thất");

            // Here you would typically save to database
            // For now, just show a success message
            MessageBox.Show($"Đã cập nhật thông tin phòng {roomNumber} thành công!\n\n" +
                           $"Diện tích: {txtArea.Text} m²\n" +
                           $"Giá thuê: {txtRentPrice.Text} VNĐ/tháng\n" +
                           $"Trạng thái: {cmbStatus.SelectedItem?.ToString()}\n" +
                           $"Nội thất: {string.Join(", ", furnitureList)}\n" +
                           $"Ghi chú: {txtNotes.Text}", 
                           "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Switch back to view mode
            isEditMode = false;
            SetControlsReadOnly(true);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRentPrice_Click(object sender, EventArgs e)
        {

        }

        private void chkChair_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblRoomCode_Click(object sender, EventArgs e)
        {

        }

        private void chkAirConditioner_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
