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
    public partial class FormTenant : Form
    {
        public FormTenant()
        {
            InitializeComponent();
            SetupForm();
            LoadTenantData();
            ApplyCustomStyling();
        }

        private void SetupForm()
        {
            // Set form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new Size(1000, 600);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            
            // Set BackColor to prevent transparent background error
            this.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void ApplyCustomStyling()
        {
            // DataGridView styling - clean and simple
            dataGridViewTenants.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewTenants.EnableHeadersVisualStyles = false;
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // Clean white
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Black text
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewTenants.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // No alternating colors
            dataGridViewTenants.DefaultCellStyle.BackColor = Color.White; // All rows white
            dataGridViewTenants.BackgroundColor = Color.White; // Grid background white
            
            // Change selection color to light gray
            dataGridViewTenants.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240); // Light gray
            dataGridViewTenants.DefaultCellStyle.SelectionForeColor = Color.Black; // Black text when selected

            // Column setup
            dataGridViewTenants.Columns[0].HeaderText = "Tên người thuê";
            dataGridViewTenants.Columns[0].Width = 400;
            dataGridViewTenants.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable; // No sorting arrow

            dataGridViewTenants.Columns[1].HeaderText = "Phòng";
            dataGridViewTenants.Columns[1].Width = 200;
            dataGridViewTenants.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTenants.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable; // No sorting arrow

            DataGridViewLinkColumn linkColumn = dataGridViewTenants.Columns[2] as DataGridViewLinkColumn;
            if (linkColumn != null)
            {
                linkColumn.HeaderText = "Chức năng";
                linkColumn.Text = "Xem";
                linkColumn.Width = 150;
                linkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                linkColumn.LinkColor = Color.Black; // Black text instead of blue
                linkColumn.VisitedLinkColor = Color.Black; // Keep black when visited
                linkColumn.ActiveLinkColor = Color.Black; // Keep black when clicked
                linkColumn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240); // Light gray selection
                linkColumn.DefaultCellStyle.SelectionForeColor = Color.Black; // Black text when selected
                linkColumn.SortMode = DataGridViewColumnSortMode.NotSortable; // No sorting arrow
            }
        }

        private void LoadTenantData()
        {
            // Clear existing data
            dataGridViewTenants.Rows.Clear();

            // Sample data
            AddTenantToGrid("Nguyễn Văn A", "A101");
            AddTenantToGrid("Trần Thị B", "A102");
            AddTenantToGrid("Phạm Quang C", "B203");
            AddTenantToGrid("Lê Thị D", "A201");
            AddTenantToGrid("Hoàng Văn E", "B101");
        }

        private void AddTenantToGrid(string tenantName, string roomNumber)
        {
            int rowIndex = dataGridViewTenants.Rows.Add(tenantName, roomNumber, "Xem");
            DataGridViewRow row = dataGridViewTenants.Rows[rowIndex];

            // Keep everything clean and simple - no special styling
            if (row.Cells[1] != null)
            {
                row.Cells[1].Style.BackColor = Color.White; // Keep white background
                row.Cells[1].Style.ForeColor = Color.Black; // Black text
                row.Cells[1].Style.Font = new Font("Segoe UI", 10); // Normal font
            }
            
            // Ensure the link cell shows "Xem" text with black color
            if (row.Cells[2] != null)
            {
                row.Cells[2].Value = "Xem";
                row.Cells[2].Style.ForeColor = Color.Black; // Black text instead of blue
            }
        }

        private void BtnAddTenant_Click(object sender, EventArgs e)
        {
            // Load FormAddTenant into main panel
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormAddTenant formAddTenant = new FormAddTenant();
                formAddTenant.TopLevel = false;
                formAddTenant.FormBorderStyle = FormBorderStyle.None;
                formAddTenant.Dock = DockStyle.Fill;

                mainForm.LoadFormIntoMainPanel(formAddTenant);
            }
        }


        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Implement search functionality
            string searchText = txtSearch.Text.ToLower();
            
            foreach (DataGridViewRow row in dataGridViewTenants.Rows)
            {
                bool visible = false;
                
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower().Contains(searchText))
                {
                    visible = true;
                }
                else if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().ToLower().Contains(searchText))
                {
                    visible = true;
                }
                
                row.Visible = visible;
            }
        }

        private void DataGridViewTenants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle link column clicks
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Action column
            {
                string tenantName = dataGridViewTenants.Rows[e.RowIndex].Cells[0].Value?.ToString();
                string roomNumber = dataGridViewTenants.Rows[e.RowIndex].Cells[1].Value?.ToString();
                
                if (!string.IsNullOrEmpty(tenantName))
                {
                    // Show tenant details
                    MessageBox.Show($"Thông tin người thuê:\n\nTên: {tenantName}\nPhòng: {roomNumber}", 
                        "Chi tiết người thuê", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}