using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormRoom : Form
    {
        private readonly House house;
        private readonly RoomService roomService = new RoomService();
        private readonly BindingSource roomBindingSource = new BindingSource();
        private List<Room> rooms = new List<Room>();

        public FormRoom(House house)
        {
            this.house = house ?? throw new ArgumentNullException(nameof(house));
            InitializeComponent();
            ConfigureLayout();
            HookEvents();
            LoadRoomData();
        }

        private void ConfigureLayout()
        {
            lblHouseName.Text = house.Name;
            lblHouseAddress.Text = house.Address;

            dataGridViewRooms.AutoGenerateColumns = false;
            dataGridViewRooms.Columns.Clear();

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCode",
                HeaderText = "Ma phong",
                DataPropertyName = nameof(Room.Code),
                Width = 140
            });

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFloor",
                HeaderText = "Tang",
                DataPropertyName = nameof(Room.Floor),
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArea",
                HeaderText = "Dien tich (m2)",
                DataPropertyName = nameof(Room.Area),
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.##" }
            });

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRent",
                HeaderText = "Gia thue (VND)",
                DataPropertyName = nameof(Room.RentPrice),
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridViewRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trang thai",
                DataPropertyName = nameof(Room.Status),
                Width = 140
            });

            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
            {
                Name = "colAction",
                HeaderText = "Thao tac",
                Text = "Xem chi tiet",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dataGridViewRooms.Columns.Add(actionColumn);

            dataGridViewRooms.DataSource = roomBindingSource;
        }

        private void HookEvents()
        {
            btnAddRoom.Click += BtnAddRoom_Click;
            btnBack.Click += BtnBack_Click;
            dataGridViewRooms.CellFormatting += DataGridViewRooms_CellFormatting;
        }

        private void LoadRoomData()
        {
            try
            {
                rooms = new List<Room>(roomService.GetRoomsByHouse(house.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khong the tai danh sach phong.{Environment.NewLine}Chi tiet: {ex.Message}",
                    "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            roomBindingSource.DataSource = rooms;
            roomBindingSource.ResetBindings(false);
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRooms.Columns[e.ColumnIndex].Name != "colStatus")
            {
                return;
            }

            if (e.Value is RoomStatus status)
            {
                switch (status)
                {
                    case RoomStatus.Occupied:
                        e.Value = "Dang thue";
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                        break;
                    case RoomStatus.Reserved:
                        e.Value = "Du kien";
                        e.CellStyle.ForeColor = Color.FromArgb(243, 156, 18);
                        break;
                    case RoomStatus.UnderRepair:
                        e.Value = "Dang sua";
                        e.CellStyle.ForeColor = Color.FromArgb(155, 89, 182);
                        break;
                    case RoomStatus.Maintenance:
                        e.Value = "Bao tri";
                        e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34);
                        break;
                    default:
                        e.Value = "Trong";
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113);
                        break;
                }
            }
        }

        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            using (FormAddRoom addRoom = new FormAddRoom(house))
            {
                if (addRoom.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRoomData();
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm == null)
            {
                return;
            }

            FormHouseManagement formHouseManagement = new FormHouseManagement
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainForm.LoadFormIntoMainPanel(formHouseManagement);
        }

        private void DataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewRooms.Columns[e.ColumnIndex].Name != "colAction")
            {
                return;
            }

            Room room = roomBindingSource[e.RowIndex] as Room;
            if (room == null)
            {
                return;
            }

            using (FormInfRoom roomDetail = new FormInfRoom(room))
            {
                if (roomDetail.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRoomData();
                }
            }
        }
    }
}
