using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormAddRoom : Form
    {
        private readonly House house;
        private readonly RoomService roomService = new RoomService();
        private readonly Dictionary<Guna2CheckBox, string> amenityMap = new Dictionary<Guna2CheckBox, string>();

        public FormAddRoom(House house)
        {
            this.house = house ?? throw new ArgumentNullException(nameof(house));
            InitializeComponent();
            ConfigureForm();
            HookEvents();
            InitializeAmenities();
        }

        private void ConfigureForm()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = System.Drawing.Color.White;

            lblTitle.Text = $"Them phong moi cho {house.Name}";
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Trong", "Dang thue", "Du kien", "Dang sua", "Bao tri" });
            cmbStatus.SelectedIndex = 0;
        }

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, _) => Close();
            btnBack.Click += (s, _) => Close();
        }

        private void InitializeAmenities()
        {
            amenityMap.Add(chkRefrigerator, "Tu lanh");
            amenityMap.Add(chkAirConditioner, "May lanh");
            amenityMap.Add(chkWashingMachine, "May giat");
            amenityMap.Add(chkTable, "Ban");
            amenityMap.Add(chkWardrobe, "Tu ao");
            amenityMap.Add(chkChair, "Ghe");

            chkNoFurniture.CheckedChanged += (s, _) =>
            {
                if (chkNoFurniture.Checked)
                {
                    foreach (Guna2CheckBox checkbox in amenityMap.Keys)
                    {
                        checkbox.Checked = false;
                    }
                }
            };

            foreach (Guna2CheckBox checkbox in amenityMap.Keys)
            {
                checkbox.CheckedChanged += (s, _) =>
                {
                    if (checkbox.Checked)
                    {
                        chkNoFurniture.Checked = false;
                    }
                };
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out double? area, out decimal rentPrice, out RoomStatus status))
            {
                return;
            }

            Room room = new Room
            {
                HouseId = house.Id,
                HouseCode = house.Code,
                Code = txtRoomCode.Text.Trim(),
                Area = area,
                RentPrice = rentPrice,
                Status = status,
                Amenities = CollectAmenities(),
                Notes = txtNotes.Text.Trim()
            };

            try
            {
                roomService.CreateRoom(room);
                MessageBox.Show("Room created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create room.\nDetails: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out double? area, out decimal rentPrice, out RoomStatus status)
        {
            area = null;
            rentPrice = 0;
            status = RoomStatus.Vacant;

            if (string.IsNullOrWhiteSpace(txtRoomCode.Text))
            {
                MessageBox.Show("Please enter a room code.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomCode.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtArea.Text))
            {
                if (!double.TryParse(txtArea.Text, out double parsedArea) || parsedArea < 0)
                {
                    MessageBox.Show("Area must be a non-negative number.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArea.Focus();
                    return false;
                }

                area = parsedArea;
            }

            if (!decimal.TryParse(txtRentPrice.Text, out rentPrice) || rentPrice < 0)
            {
                MessageBox.Show("Rent must be a non-negative number.", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRentPrice.Focus();
                return false;
            }

            status = ParseStatus(cmbStatus.SelectedItem as string);
            return true;
        }

        private string CollectAmenities()
        {
            if (chkNoFurniture.Checked)
            {
                return "Khong co noi that";
            }

            List<string> amenities = new List<string>();
            foreach (KeyValuePair<Guna2CheckBox, string> pair in amenityMap)
            {
                if (pair.Key.Checked)
                {
                    amenities.Add(pair.Value);
                }
            }

            return string.Join(", ", amenities);
        }

        private static RoomStatus ParseStatus(string display)
        {
            if (string.IsNullOrWhiteSpace(display))
            {
                return RoomStatus.Vacant;
            }

            string normalized = display.Trim().ToLowerInvariant();
            if (normalized.Contains("thue"))
            {
                return RoomStatus.Occupied;
            }

            if (normalized.Contains("du") || normalized.Contains("kien"))
            {
                return RoomStatus.Reserved;
            }

            if (normalized.Contains("sua"))
            {
                return RoomStatus.UnderRepair;
            }

            if (normalized.Contains("bao") || normalized.Contains("tri"))
            {
                return RoomStatus.Maintenance;
            }

            return RoomStatus.Vacant;
        }
    }
}
