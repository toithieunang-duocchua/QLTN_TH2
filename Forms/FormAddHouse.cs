using System;
using System.Drawing;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormAddHouse : Form
    {
        private readonly HouseService houseService = new HouseService();

        public FormAddHouse()
        {
            InitializeComponent();
            ConfigureForm();
            HookEvents();
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
            btnReset.Click += BtnReset_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal? area, out int? floors, out int roomCount))
            {
                return;
            }

            House house = new House
            {
                Name = txtHouseName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Area = area,
                FloorCount = floors,
                RoomCount = roomCount
            };

            try
            {
                houseService.CreateHouse(house);
                MessageBox.Show("House created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to save the new house.\nDetails: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out decimal? area, out int? floors, out int roomCount)
        {
            area = null;
            floors = null;
            roomCount = 0;

            if (string.IsNullOrWhiteSpace(txtHouseName.Text))
            {
                MessageBox.Show("Please enter a house name.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHouseName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtArea.Text))
            {
                if (!decimal.TryParse(txtArea.Text, out decimal parsedArea) || parsedArea < 0)
                {
                    MessageBox.Show("Area must be a non-negative number.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArea.Focus();
                    return false;
                }

                area = parsedArea;
            }

            if (!string.IsNullOrWhiteSpace(txtFloors.Text))
            {
                if (!int.TryParse(txtFloors.Text, out int parsedFloors) || parsedFloors < 0)
                {
                    MessageBox.Show("Floor count must be a non-negative integer.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFloors.Focus();
                    return false;
                }

                floors = parsedFloors;
            }

            if (!int.TryParse(txtRooms.Text, out roomCount) || roomCount < 0)
            {
                MessageBox.Show("Room count must be a non-negative integer.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRooms.Focus();
                return false;
            }

            return true;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtHouseName.Clear();
            txtArea.Clear();
            txtFloors.Clear();
            txtRooms.Clear();
            txtAddress.Clear();
            txtHouseName.Focus();
        }
    }
}
