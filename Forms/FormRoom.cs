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
        }

        private void ApplyCustomStyling()
        {
            // Set house information
            lblHouseName.Text = houseName;
            lblHouseAddress.Text = houseAddress;

            // Configure DataGridView columns
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Set column headers
            dataGridViewRooms.Columns[0].HeaderText = "Tên phòng";
            dataGridViewRooms.Columns[1].HeaderText = "Trạng thái";
            dataGridViewRooms.Columns[2].HeaderText = "Thao tác";

            // Set column widths
            dataGridViewRooms.Columns[0].Width = 200;
            dataGridViewRooms.Columns[1].Width = 150;
            dataGridViewRooms.Columns[2].Width = 100;

            // Configure button column
            DataGridViewButtonColumn buttonColumn = dataGridViewRooms.Columns[2] as DataGridViewButtonColumn;
            if (buttonColumn != null)
            {
                buttonColumn.Text = "Xem thông tin";
                buttonColumn.UseColumnTextForButtonValue = true;
            }

            // Style the DataGridView
            dataGridViewRooms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            // Row styling
            dataGridViewRooms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewRooms.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewRooms.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadRoomData()
        {
            // Clear existing data
            dataGridViewRooms.Rows.Clear();

            // Sample room data
            var rooms = new List<object[]>
            {
                new object[] { "Phòng 101", "Còn trống", "Xem thông tin" },
                new object[] { "Phòng 102", "Đang thuê", "Xem thông tin" },
                new object[] { "Phòng 103", "Còn trống", "Xem thông tin" },
                new object[] { "Phòng 201", "Còn trống", "Xem thông tin" },
                new object[] { "Phòng 202", "Đang thuê", "Xem thông tin" },
                new object[] { "Phòng 301", "Còn trống", "Xem thông tin" }
            };

            // Add rows to DataGridView
            foreach (var room in rooms)
            {
                dataGridViewRooms.Rows.Add(room);
            }

            // Color code status column
            foreach (DataGridViewRow row in dataGridViewRooms.Rows)
            {
                if (row.Cells[1].Value?.ToString() == "Còn trống")
                {
                    row.Cells[1].Style.ForeColor = Color.FromArgb(46, 204, 113); // Green
                }
                else if (row.Cells[1].Value?.ToString() == "Đang thuê")
                {
                    row.Cells[1].Style.ForeColor = Color.FromArgb(231, 76, 60); // Red
                }
            }
        }

        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            // Navigate to add room form
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
            // Temporarily disabled FormAddRoom
            MessageBox.Show("Chức năng thêm phòng tạm thời bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /* FormAddRoom formAddRoom = new FormAddRoom();
            formAddRoom.TopLevel = false;
            formAddRoom.FormBorderStyle = FormBorderStyle.None;
            formAddRoom.Dock = DockStyle.Fill;

            mainForm.LoadFormIntoMainPanel(formAddRoom); */
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to house management
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormHouseManagement formHouseManagement = new FormHouseManagement();
                formHouseManagement.TopLevel = false;
                formHouseManagement.FormBorderStyle = FormBorderStyle.None;
                formHouseManagement.Dock = DockStyle.Fill;

                mainForm.LoadFormIntoMainPanel(formHouseManagement);
            }
        }

        private void dataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle button column clicks
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Action column
            {
                string roomName = dataGridViewRooms.Rows[e.RowIndex].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(roomName))
                {
                    // Navigate to room detail form
                    FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
                    if (mainForm != null)
                    {
                        FormInfRoom formInfRoom = new FormInfRoom(roomName);
                        formInfRoom.TopLevel = false;
                        formInfRoom.FormBorderStyle = FormBorderStyle.None;
                        formInfRoom.Dock = DockStyle.Fill;

                        mainForm.LoadFormIntoMainPanel(formInfRoom);
                    }
                }
            }
        }
    }
}