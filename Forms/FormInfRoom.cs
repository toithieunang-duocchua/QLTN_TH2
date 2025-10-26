using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QLTN.Models;
using QLTN.Services;


namespace QLTN.Forms
{
    public partial class FormInfRoom : Form
    {
        private readonly RoomService roomService = new RoomService();
        private readonly Room room;
        private bool isEditMode;
        private readonly Dictionary<Guna2CheckBox, string> amenityMap = new Dictionary<Guna2CheckBox, string>();

        public FormInfRoom(Room room)
        {
            this.room = room ?? throw new ArgumentNullException(nameof(room));
            InitializeComponent();
            InitializeAmenities();
            ConfigureForm();
            HookEvents();
            LoadRoomData();
        }

        private void InitializeAmenities()
        {
            amenityMap.Add(chkRefrigerator, "Tu lanh");
            amenityMap.Add(chkAirConditioner, "May lanh");
            amenityMap.Add(chkWashingMachine, "May giat");
            amenityMap.Add(chkTable, "Ban");
            amenityMap.Add(chkWardrobe, "Tu ao");
            amenityMap.Add(chkChair, "Ghe");
        }

        private void ConfigureForm()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Trong", "Dang thue", "Du kien", "Dang sua", "Bao tri" });
        }

        private void HookEvents()
        {
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnBack.Click += (s, _) => Close();
            checkNone.CheckedChanged += CheckNone_CheckedChanged;
        }

        private void LoadRoomData()
        {
            txtRoomCode.Text = room.Code;
            txtArea.Text = room.Area?.ToString("0.##") ?? string.Empty;
            txtRentPrice.Text = room.RentPrice.ToString("0");
            txtNotes.Text = room.Notes;
            lblTitle.Text = $"Room {room.Code}";

            cmbStatus.SelectedItem = MapStatusToDisplay(room.Status);
            ApplyAmenities(room.Amenities);
            SetControlsReadOnly(true);
        }

        private void ApplyAmenities(string amenities)
        {
            foreach (Guna2CheckBox checkbox in amenityMap.Keys)
            {
                checkbox.CheckedChanged -= AmenityCheckBox_CheckedChanged;
                checkbox.Checked = false;
            }

            checkNone.CheckedChanged -= CheckNone_CheckedChanged;
            checkNone.Checked = false;

            if (!string.IsNullOrWhiteSpace(amenities))
            {
                string[] tokens = amenities.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(item => item.Trim())
                    .ToArray();

                foreach (KeyValuePair<Guna2CheckBox, string> pair in amenityMap)
                {
                    if (tokens.Any(token => string.Equals(token, pair.Value, StringComparison.OrdinalIgnoreCase)))
                    {
                        pair.Key.Checked = true;
                    }
                }

                checkNone.Checked = amenityMap.Keys.All(cb => !cb.Checked);
            }
            else
            {
                checkNone.Checked = true;
            }

            foreach (Guna2CheckBox checkbox in amenityMap.Keys)
            {
                checkbox.CheckedChanged += AmenityCheckBox_CheckedChanged;
            }

            checkNone.CheckedChanged += CheckNone_CheckedChanged;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
            SetControlsReadOnly(!isEditMode);

            if (!isEditMode)
            {
                LoadRoomData();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                return;
            }

            if (!ValidateInputs(out double? area, out decimal rentPrice, out RoomStatus status))
            {
                return;
            }

            room.Area = area;
            room.RentPrice = rentPrice;
            room.Status = status;
            room.Notes = txtNotes.Text.Trim();
            room.Amenities = CollectAmenities();

            try
            {
                roomService.UpdateRoom(room);
                MessageBox.Show("Room updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEditMode = false;
                SetControlsReadOnly(true);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to update room.\nDetails: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out double? area, out decimal rentPrice, out RoomStatus status)
        {
            area = null;
            rentPrice = 0;
            status = RoomStatus.Vacant;

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
            if (checkNone.Checked)
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

        private void SetControlsReadOnly(bool readOnly)
        {
            txtRoomCode.ReadOnly = true;
            txtArea.ReadOnly = readOnly;
            txtRentPrice.ReadOnly = readOnly;
            txtNotes.ReadOnly = readOnly;
            cmbStatus.Enabled = !readOnly;
            checkNone.Enabled = !readOnly;

            foreach (Guna2CheckBox checkbox in amenityMap.Keys)
            {
                checkbox.Enabled = !readOnly;
            }

            btnSave.Visible = !readOnly;
            btnEdit.Text = readOnly ? "Edit" : "Cancel";
            btnEdit.FillColor = readOnly ? Color.FromArgb(155, 89, 182) : Color.FromArgb(231, 76, 60);
        }

        private static string MapStatusToDisplay(RoomStatus status)
        {
            switch (status)
            {
                case RoomStatus.Occupied:
                    return "Dang thue";
                case RoomStatus.Reserved:
                    return "Du kien";
                case RoomStatus.UnderRepair:
                    return "Dang sua";
                case RoomStatus.Maintenance:
                    return "Bao tri";
                default:
                    return "Trong";
            }
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

        private void AmenityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNone.Checked)
            {
                checkNone.CheckedChanged -= CheckNone_CheckedChanged;
                checkNone.Checked = false;
                checkNone.CheckedChanged += CheckNone_CheckedChanged;
            }
        }

        private void CheckNone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNone.Checked)
            {
                foreach (Guna2CheckBox checkbox in amenityMap.Keys)
                {
                    checkbox.CheckedChanged -= AmenityCheckBox_CheckedChanged;
                    checkbox.Checked = false;
                    checkbox.CheckedChanged += AmenityCheckBox_CheckedChanged;
                }
            }
        }
    }
}


