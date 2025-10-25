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
    public partial class FormHouseManagement : Form
    {
        public FormHouseManagement()
        {
            InitializeComponent();
            SetupEventHandlers();
            ApplyCustomStyling();
        }

        private void SetupEventHandlers()
        {
            btnAddHouse.Click += BtnAddHouse_Click;
            btnEditHouseA.Click += BtnEditHouse_Click;
            btnEditHouseB.Click += BtnEditHouse_Click;
            panelHouseA.Click += PanelHouse_Click;
            panelHouseB.Click += PanelHouse_Click;

            // Add hover effects
            panelHouseA.MouseEnter += PanelHouse_MouseEnter;
            panelHouseA.MouseLeave += PanelHouse_MouseLeave;
            panelHouseB.MouseEnter += PanelHouse_MouseEnter;
            panelHouseB.MouseLeave += PanelHouse_MouseLeave;

            // Add resize event
            this.Resize += FormHouseManagement_Resize;
        }

        private void ApplyCustomStyling()
        {
            // Set form BackColor to prevent transparent background error
            this.BackColor = Color.White;
            
            // Set cursor for clickable panels
            panelHouseA.Cursor = Cursors.Hand;
            panelHouseB.Cursor = Cursors.Hand;
            
            // Set BackColor for panels to prevent transparent background error
            if (panelHouseA != null) panelHouseA.BackColor = Color.White;
            if (panelHouseB != null) panelHouseB.BackColor = Color.White;
            
            // Set address text for houses
            if (lblHouseAAddress != null) lblHouseAAddress.Text = "19 Nguyễn Thị Thập, Quận 7, TP.HCM";
            if (lblHouseBAddress != null) lblHouseBAddress.Text = "52 Cộng Hòa, Tân Bình, TP.HCM";
            
            // Add border radius effect (simulated with padding)
            panelHouseA.Padding = new Padding(0, 0, 0, 1);
            panelHouseB.Padding = new Padding(0, 0, 0, 1);
            
            // Adjust panel heights based on content
            AdjustPanelHeights();
        }

        private void AdjustPanelHeights()
        {
            // Calculate required height for House A
            int houseAHeight = CalculateRequiredHeight(lblHouseAAddress);
            panelHouseA.Height = Math.Max(80, houseAHeight + 40); // Minimum 80px, add padding

            // Calculate required height for House B  
            int houseBHeight = CalculateRequiredHeight(lblHouseBAddress);
            panelHouseB.Height = Math.Max(80, houseBHeight + 40); // Minimum 80px, add padding

            // Update House B position (if panels are not docked)
            if (panelHouseB.Dock == DockStyle.None)
                panelHouseB.Location = new Point(0, panelHouseA.Height + 60); // 60px for header
        }

        // ✅ Đổi Label → Control để tương thích Guna2HtmlLabel
        private int CalculateRequiredHeight(Control ctl)
        {
            if (ctl == null) return 0;

            var proposedSize = new Size(ctl.Width, int.MaxValue);
            var flags = TextFormatFlags.WordBreak;
            Size textSize = TextRenderer.MeasureText(ctl.Text ?? string.Empty, ctl.Font, proposedSize, flags);

            int padding = ctl.Padding.Top + ctl.Padding.Bottom;
            return textSize.Height + padding;
        }

        private void BtnAddHouse_Click(object sender, EventArgs e)
        {
            FormAddHouse formAddHouse = new FormAddHouse();
            formAddHouse.ShowDialog();
        }

        private void BtnEditHouse_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton == null) return;

            string houseName = "";
            string houseAddress = "";

            if (clickedButton == btnEditHouseA)
            {
                houseName = lblHouseAName.Text;
                houseAddress = lblHouseAAddress.Text;
            }
            else if (clickedButton == btnEditHouseB)
            {
                houseName = lblHouseBName.Text;
                houseAddress = lblHouseBAddress.Text;
            }

            // Tạo popup sửa nhà
            FormEditHousePopup editPopup = new FormEditHousePopup(houseName, houseAddress);
            editPopup.ShowDialog();
        }

        private void PanelHouse_Click(object sender, EventArgs e)
        {
            // Cho phép click trên Guna2Panel
            var clickedPanel = sender as Control;
            if (clickedPanel == null) return;

            string houseName = "";
            string houseAddress = "";

            if (clickedPanel == panelHouseA)
            {
                houseName = lblHouseAName.Text;
                houseAddress = lblHouseAAddress.Text;
            }
            else if (clickedPanel == panelHouseB)
            {
                houseName = lblHouseBName.Text;
                houseAddress = lblHouseBAddress.Text;
            }

            // Load FormRoom vào panel chính
            LoadFormRoom(houseName, houseAddress);
        }

        private void LoadFormRoom(string houseName, string houseAddress)
        {
            // Tìm FormMainSystem để load FormRoom vào mainPanel
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormRoom formRoom = new FormRoom(houseName, houseAddress);
                formRoom.TopLevel = false;
                formRoom.FormBorderStyle = FormBorderStyle.None;
                
                // Load vào mainPanel của FormMainSystem
                mainForm.LoadFormIntoMainPanel(formRoom);
            }
        }

        private void PanelHouse_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Control;
            if (panel != null)
                panel.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void PanelHouse_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Control;
            if (panel != null)
                panel.BackColor = Color.White;
        }

        private void lblSubtitle_Click(object sender, EventArgs e) { }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(240, 240, 240), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, panelContent.Width - 1, panelContent.Height - 1);
        }

        private void FormHouseManagement_Resize(object sender, EventArgs e)
        {
            // Ensure minimum size constraints
            if (this.Width < 800) this.Width = 800;
            if (this.Height < 500) this.Height = 500;

            // Update button position when form resizes
            if (this.Width > 900)
                btnAddHouse.Location = new Point(this.Width - 200, btnAddHouse.Location.Y);

            // Recalculate panel heights when form resizes
            AdjustPanelHeights();
        }

        private void lblActionHeader_Click(object sender, EventArgs e) { }
        private void lblHouseBAddress_Click(object sender, EventArgs e) { }
        private void lblHouseBName_Click(object sender, EventArgs e) { }
    }
}
