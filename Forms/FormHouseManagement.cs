using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormHouseManagement : Form
    {
        private readonly HouseService houseService = new HouseService();
        private IReadOnlyList<House> currentHouses = Array.Empty<House>();

        public FormHouseManagement()
        {
            InitializeComponent();
            ApplyCustomStyling();
            HookEvents();
        }

        private void HookEvents()
        {
            Load += FormHouseManagement_Load;
            btnAddHouse.Click += BtnAddHouse_Click;
            Resize += FormHouseManagement_Resize;
        }

        private void FormHouseManagement_Load(object sender, EventArgs e)
        {
            RefreshHouseList();
        }

        private void ApplyCustomStyling()
        {
            DoubleBuffered = true;
            EnableDoubleBuffering(flowLayoutHouses);
            EnableDoubleBuffering(panelHouseList);

            BackColor = Color.White;
            flowLayoutHouses.WrapContents = false;
            flowLayoutHouses.AutoScroll = true;
            flowLayoutHouses.FlowDirection = FlowDirection.TopDown;
            flowLayoutHouses.Padding = new Padding(5, 5, 5, 5);
            flowLayoutHouses.Margin = new Padding(0);

            lblEmptyState.Visible = false;
            lblEmptyState.Text = "Chua co can nha nao. Nhan \"Them nha\" de bat dau.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.ForeColor = Color.FromArgb(120, 120, 120);
        }

        private void RefreshHouseList()
        {
            try
            {
                currentHouses = houseService.GetAllHouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khong the tai danh sach nha.\nChi tiet: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flowLayoutHouses.SuspendLayout();
            flowLayoutHouses.Controls.Clear();

            if (currentHouses.Count == 0)
            {
                lblEmptyState.Dock = DockStyle.Fill;
                lblEmptyState.Visible = true;
                if (!panelHouseList.Controls.Contains(lblEmptyState))
                {
                    panelHouseList.Controls.Add(lblEmptyState);
                    lblEmptyState.BringToFront();
                }
            }
            else
            {
                lblEmptyState.Visible = false;
                foreach (House house in currentHouses)
                {
                    flowLayoutHouses.Controls.Add(CreateHouseCard(house));
                }
            }

            flowLayoutHouses.ResumeLayout();
            UpdateCardWidths();
        }

        private Control CreateHouseCard(House house)
        {
            Guna2Panel card = new Guna2Panel
            {
                Width = CalculateAvailableCardWidth(),
                Height = 160,
                BorderRadius = 16,
                FillColor = Color.White,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(233, 236, 239),
                Margin = new Padding(8),
                ShadowDecoration = { Depth = 6, Enabled = true },
                Tag = house,
                Name = $"cardHouse_{house.Id}"
            };

            card.MouseEnter += (s, _) => card.FillColor = Color.FromArgb(249, 250, 252);
            card.MouseLeave += (s, _) => card.FillColor = Color.White;

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(16, 14, 16, 14)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Label lblName = new Label
            {
                Text = string.IsNullOrWhiteSpace(house.Name) ? "(Chua dat ten)" : house.Name,
                Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 60),
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            FlowLayoutPanel actionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            Guna2Button btnDelete = CreateSecondaryButton("Xoa", Color.FromArgb(231, 76, 60), Color.White);
            btnDelete.Tag = house;
            btnDelete.Name = $"btnDeleteHouse_{house.Id}";
            btnDelete.Click += (s, _) => DeleteHouse((House)((Guna2Button)s).Tag);

            Guna2Button btnEdit = CreateOutlineButton("Chinh sua");
            btnEdit.Tag = house;
            btnEdit.Name = $"btnEditHouse_{house.Id}";
            btnEdit.Click += (s, _) => OpenEditPopup((House)((Guna2Button)s).Tag);

            Guna2Button btnViewRooms = CreatePrimaryButton("Xem phong");
            btnViewRooms.Tag = house;
            btnViewRooms.Name = $"btnViewRooms_{house.Id}";
            btnViewRooms.Click += (s, _) => NavigateToRooms((House)((Guna2Button)s).Tag);

            actionPanel.Controls.Add(btnDelete);
            actionPanel.Controls.Add(btnEdit);
            actionPanel.Controls.Add(btnViewRooms);

            Label lblAddress = new Label
            {
                Text = string.IsNullOrWhiteSpace(house.Address) ? "Chua cap nhat dia chi" : house.Address,
                Font = new Font("Segoe UI", 10.25F, FontStyle.Regular),
                ForeColor = Color.FromArgb(109, 109, 128),
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 0, 4)
            };

            string areaPart = house.Area.HasValue ? $"{house.Area:#,##0.##} m2" : "Chua ro dien tich";
            string floorPart = house.FloorCount.HasValue ? $"{house.FloorCount} tang" : "Chua ro so tang";
            string roomPart = $"{house.RoomCount} phong";

            Label lblMeta = new Label
            {
                Text = $"{areaPart} - {floorPart} - {roomPart}",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(140, 140, 155),
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                Margin = new Padding(0, 4, 0, 0)
            };

            layout.Controls.Add(lblName, 0, 0);
            layout.Controls.Add(actionPanel, 1, 0);
            layout.Controls.Add(lblAddress, 0, 1);
            layout.SetColumnSpan(lblAddress, 2);
            layout.Controls.Add(lblMeta, 0, 2);
            layout.SetColumnSpan(lblMeta, 2);

            card.Controls.Add(layout);
            return card;
        }
        private static Guna2Button CreatePrimaryButton(string text)
        {
            return new Guna2Button
            {
                Text = text,
                BorderRadius = 10,
                FillColor = Color.FromArgb(76, 132, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9.5F),
                Margin = new Padding(6, 0, 0, 0),
                Size = new Size(120, 36)
            };
        }

        private static Guna2Button CreateOutlineButton(string text)
        {
            return new Guna2Button
            {
                Text = text,
                BorderRadius = 10,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(210, 210, 210),
                BorderThickness = 1,
                ForeColor = Color.FromArgb(55, 55, 70),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Margin = new Padding(6, 0, 0, 0),
                Size = new Size(120, 36)
            };
        }

        private static Guna2Button CreateSecondaryButton(string text, Color fillColor, Color foreColor)
        {
            return new Guna2Button
            {
                Text = text,
                BorderRadius = 10,
                FillColor = fillColor,
                ForeColor = foreColor,
                Font = new Font("Segoe UI Semibold", 9.5F),
                Margin = new Padding(6, 0, 0, 0),
                Size = new Size(110, 36)
            };
        }

        private void BtnAddHouse_Click(object sender, EventArgs e)
        {
            using (FormAddHouse addHouseForm = new FormAddHouse())
            {
                if (addHouseForm.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshHouseList();
                }
            }
        }

        private void OpenEditPopup(House house)
        {
            using (FormEditHousePopup editPopup = new FormEditHousePopup(house))
            {
                if (editPopup.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshHouseList();
                }
            }
        }

        private void NavigateToRooms(House house)
        {
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm == null)
            {
                return;
            }

            FormRoom formRoom = new FormRoom(house)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainForm.LoadFormIntoMainPanel(formRoom);
        }

                private void DeleteHouse(House house)
        {
            DialogResult confirm = MessageBox.Show(
                $"Ban co chac chan muon xoa nha \"{house.Name}\"?\nMoi phong va du lieu lien quan se bi xoa theo.",
                "Xac nhan xoa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool deleted = houseService.DeleteHouse(house.Id);
                if (!deleted)
                {
                    MessageBox.Show("Khong tim thay can nha de xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khong the xoa nha.\nChi tiet: {ex.Message}", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshHouseList();
        }

        private void FormHouseManagement_Resize(object sender, EventArgs e)
        {
            UpdateCardWidths();
        }

        private void UpdateCardWidths()
        {
            int availableWidth = CalculateAvailableCardWidth();
            flowLayoutHouses.SuspendLayout();
            foreach (Control ctrl in flowLayoutHouses.Controls)
            {
                if (ctrl is Guna2Panel panel)
                {
                    if (panel.Width != availableWidth)
                    {
                        panel.Width = availableWidth;
                    }
                }
            }
            flowLayoutHouses.ResumeLayout();
        }

        private int CalculateAvailableCardWidth()
        {
            int width = flowLayoutHouses.ClientSize.Width - flowLayoutHouses.Padding.Horizontal;

            if (flowLayoutHouses.VerticalScroll.Visible)
            {
                width -= SystemInformation.VerticalScrollBarWidth;
            }

            // Subtract card horizontal margins (Padding(8) => 16px total).
            width -= 16;

            return Math.Max(width, 240);
        }

        private static void EnableDoubleBuffering(Control control)
        {
            if (control == null || SystemInformation.TerminalServerSession)
            {
                return;
            }

            PropertyInfo doubleBufferedProperty = control.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            doubleBufferedProperty?.SetValue(control, true, null);
        }
    }
}










