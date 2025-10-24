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
    public partial class FormRoom : Form
    {
        private string houseName;
        private string houseAddress;

        public FormRoom(string houseName, string houseAddress)
        {
            this.houseName = houseName;
            this.houseAddress = houseAddress;
            InitializeComponent();
            SetupEventHandlers();
            ApplyCustomStyling();
            LoadRoomData();
        }

        private void SetupEventHandlers()
        {
            btnAddRoom.Click += BtnAddRoom_Click;
            btnBack.Click += BtnBack_Click;
            
            // Add click events for room cards
            panelRoom101.Click += RoomCard_Click;
            panelRoom102.Click += RoomCard_Click;
            panelRoom103.Click += RoomCard_Click;
            panelRoom201.Click += RoomCard_Click;
        }

        private void ApplyCustomStyling()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadRoomData()
        {
            // Set house information
            lblHouseName.Text = houseName;
            lblHouseAddress.Text = houseAddress;
            
            // Load room data theo thiết kế đã cập nhật
            LoadRoomCard(panelRoom101, "Phòng 101", "25 m²", "Nguyễn Văn Thiện Bảo", "3,500,000 đ/tháng", "Còn trống", Color.FromArgb(46, 204, 113));
            LoadRoomCard(panelRoom102, "Phòng 102", "25 m²", "Công Đức", "3,800,000 đ/tháng", "Đang thuê", Color.FromArgb(231, 76, 60));
            LoadRoomCard(panelRoom103, "Phòng 103", "30 m²", "--", "4,000,000 đ/tháng", "Còn trống", Color.FromArgb(46, 204, 113));
            LoadRoomCard(panelRoom201, "Phòng 201", "25 m²", "--", "3,500,000 đ/tháng", "Còn trống", Color.FromArgb(46, 204, 113));
        }

        private void LoadRoomCard(Panel panel, string roomNumber, string area, string tenantInfo, string price, string status, Color statusColor)
        {
            // Find controls in the panel
            Label lblRoomNumber = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("RoomNumber"));
            Label lblArea = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Area"));
            Label lblTenant = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Tenant"));
            Label lblPrice = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Price"));
            Label lblStatus = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Status"));

            if (lblRoomNumber != null) lblRoomNumber.Text = roomNumber;
            if (lblArea != null) lblArea.Text = area;
            if (lblTenant != null) lblTenant.Text = tenantInfo;
            if (lblPrice != null) lblPrice.Text = price;
            if (lblStatus != null)
            {
                lblStatus.Text = status;
                lblStatus.ForeColor = statusColor;
            }
        }

        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            FormAddRoom formAddRoom = new FormAddRoom();
            formAddRoom.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Load lại FormHouseManagement vào mainPanel
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormHouseManagement houseManagement = new FormHouseManagement();
                houseManagement.TopLevel = false;
                houseManagement.FormBorderStyle = FormBorderStyle.None;
                houseManagement.Dock = DockStyle.Fill;
                
                mainForm.LoadFormIntoMainPanel(houseManagement);
            }
            this.Close();
        }

        private void RoomCard_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            string roomNumber = "";
            if (clickedPanel == panelRoom101) roomNumber = "Phòng 101";
            else if (clickedPanel == panelRoom102) roomNumber = "Phòng 102";
            else if (clickedPanel == panelRoom103) roomNumber = "Phòng 103";
            else if (clickedPanel == panelRoom201) roomNumber = "Phòng 201";

            MessageBox.Show($"Bạn đã chọn {roomNumber}!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton == null) return;

            string roomNumber = "";
            if (clickedButton.Name.Contains("101"))
                roomNumber = "101";
            else if (clickedButton.Name.Contains("102"))
                roomNumber = "102";
            else if (clickedButton.Name.Contains("103"))
                roomNumber = "103";
            else if (clickedButton.Name.Contains("201"))
                roomNumber = "201";

            FormInfRoom formInfRoom = new FormInfRoom(roomNumber);
            formInfRoom.ShowDialog();
        }

        private void lblStatus101_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus103_Click(object sender, EventArgs e)
        {

        }
    }
}