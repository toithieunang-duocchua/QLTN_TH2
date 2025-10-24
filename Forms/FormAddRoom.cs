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
    public partial class FormAddRoom : Form
    {
        public FormAddRoom()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Set default values
            cmbStatus.SelectedIndex = 0; // "Trống"
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtRoomCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomCode.Focus();
                return;
            }

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
            if (chkNoFurniture.Checked) furnitureList.Add("Không có nội thất");

            // Prepare data for saving
            string roomCode = txtRoomCode.Text.Trim();
            string area = txtArea.Text.Trim();
            string rentPrice = txtRentPrice.Text.Trim();
            string status = cmbStatus.SelectedItem?.ToString() ?? "Trống";
            string notes = txtNotes.Text.Trim();
            string furniture = string.Join(", ", furnitureList);

            // Here you would typically save to database
            // For now, just show a success message
            MessageBox.Show($"Đã thêm phòng thành công!\n\n" +
                           $"Mã phòng: {roomCode}\n" +
                           $"Diện tích: {area} m²\n" +
                           $"Giá thuê: {rentPrice} VNĐ/tháng\n" +
                           $"Trạng thái: {status}\n" +
                           $"Nội thất: {furniture}\n" +
                           $"Ghi chú: {notes}", 
                           "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form
            this.Close();
        }
    }
}