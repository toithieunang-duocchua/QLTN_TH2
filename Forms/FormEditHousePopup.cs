using System;
using System.Drawing;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormEditHousePopup : Form
    {
        private readonly HouseService houseService = new HouseService();
        private readonly House house;

        public FormEditHousePopup(House house)
        {
            this.house = house ?? throw new ArgumentNullException(nameof(house));
            InitializeComponent();
            ConfigureForm();
            HookEvents();
            LoadHouseData();
        }

        private void ConfigureForm()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
        }

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnClose.Click += (s, _) => Close();
        }

        private void LoadHouseData()
        {
            txtHouseName.Text = house.Name;
            txtAddress.Text = house.Address;
            txtArea.Text = house.Area?.ToString("0.##") ?? string.Empty;
            txtFloors.Text = house.FloorCount?.ToString() ?? string.Empty;
            txtRooms.Text = house.RoomCount.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal? area, out int? floors, out int rooms))
            {
                return;
            }

            house.Name = txtHouseName.Text.Trim();
            house.Address = txtAddress.Text.Trim();
            house.Area = area;
            house.FloorCount = floors;
            house.RoomCount = rooms;

            try
            {
                houseService.UpdateHouse(house);
                MessageBox.Show("Cập nhật thông tin nhà thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể cập nhật nhà.\nChi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out decimal? area, out int? floors, out int rooms)
        {
            area = null;
            floors = null;
            rooms = house.RoomCount;

            if (string.IsNullOrWhiteSpace(txtHouseName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHouseName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtArea.Text))
            {
                if (!decimal.TryParse(txtArea.Text, out decimal parsedArea) || parsedArea < 0)
                {
                    MessageBox.Show("Diện tích phải là số không âm.", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArea.Focus();
                    return false;
                }

                area = parsedArea;
            }

            if (!string.IsNullOrWhiteSpace(txtFloors.Text))
            {
                if (!int.TryParse(txtFloors.Text, out int parsedFloors) || parsedFloors < 0)
                {
                    MessageBox.Show("Số tầng phải là số nguyên không âm.", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFloors.Focus();
                    return false;
                }

                floors = parsedFloors;
            }

            if (!int.TryParse(txtRooms.Text, out rooms) || rooms < 0)
            {
                MessageBox.Show("Số phòng phải là số nguyên không âm.", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRooms.Focus();
                return false;
            }

            return true;
        }
    }
}
