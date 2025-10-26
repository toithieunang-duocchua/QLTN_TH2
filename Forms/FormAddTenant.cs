using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormAddTenant : Form
    {
        private readonly TenantService tenantService = new TenantService();
        private readonly RoomService roomService = new RoomService();
        private IReadOnlyList<Room> availableRooms = Array.Empty<Room>();

        public FormAddTenant()
        {
            InitializeComponent();
            ConfigureForm();
            HookEvents();
            LoadAvailableRooms();
        }

        private void ConfigureForm()
        {
            BackColor = Color.FromArgb(248, 249, 250);
            cmbFingerprintStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(12);
        }

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnBack.Click += BtnBack_Click;
        }

        private void LoadAvailableRooms()
        {
            try
            {
                availableRooms = roomService.GetVacantRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load available rooms.\nDetails: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbRoom.DisplayMember = "Text";
            cmbRoom.ValueMember = "Value";
            cmbRoom.Items.Clear();

            foreach (Room room in availableRooms)
            {
                cmbRoom.Items.Add(new ComboItem($"{room.HouseCode} - {room.Code}", room.Id));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out ComboItem selectedRoomItem))
            {
                return;
            }

            Room selectedRoom = availableRooms.FirstOrDefault(r => r.Id == selectedRoomItem.Value);
            if (selectedRoom == null)
            {
                MessageBox.Show("Selected room is no longer available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tenant tenant = new Tenant
            {
                FullName = txtFullName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                CitizenId = txtID.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Notes = txtNotes.Text.Trim()
            };

            try
            {
                tenantService.CreateTenantWithContract(
                    tenant,
                    selectedRoom.Id,
                    dtpStartDate.Value.Date,
                    dtpEndDate.Value.Date,
                    0,
                    txtNotes.Text.Trim());

                MessageBox.Show("Tenant created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to save tenant information.\nDetails: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out ComboItem selectedRoom)
        {
            selectedRoom = null;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui long nhap ho ten.", "Thieu du lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            string phone = txtPhone.Text?.Trim() ?? string.Empty;
            if (phone.Length < 10 || phone.Length > 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("So dien thoai khong hop le. Vui long nhap tu 10 den 11 chu so.", "Du lieu khong hop le",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui long chon phong.", "Thieu du lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoom.Focus();
                return false;
            }

            if (dtpEndDate.Value.Date <= dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngay ket thuc phai sau ngay bat dau.", "Du lieu khong hop le", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            ComboItem roomSelection = cmbRoom.SelectedItem as ComboItem;
            if (roomSelection == null)
            {
                MessageBox.Show("Phong duoc chon khong hop le.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            selectedRoom = roomSelection;
            int selectedRoomId = roomSelection.Value;
            Room room = availableRooms.FirstOrDefault(r => r.Id == selectedRoomId);
            if (room == null)
            {
                MessageBox.Show("Khong tim thay phong trong danh sach.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (room.Status != RoomStatus.Vacant && room.Status != RoomStatus.Reserved)
            {
                MessageBox.Show("Phong da duoc su dung. Vui long chon phong khac.", "Phong khong kha dung",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRoom.Focus();
                return false;
            }

            return true;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtID.Clear();
            txtEmail.Clear();
            txtNotes.Clear();
            cmbRoom.SelectedIndex = -1;
            cmbFingerprintStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(12);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ban co chac chan muon quay lai? Cac thay doi se khong duoc luu.",
                "Xac nhan quay lai",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private sealed class ComboItem
        {
            public ComboItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public string Text { get; }
            public int Value { get; }

            public override string ToString() => Text;
        }
    }
}
