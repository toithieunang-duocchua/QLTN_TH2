using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    partial class FormTenant
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dataGridViewTenants = new System.Windows.Forms.DataGridView();
            this.TenantNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FingerprintColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.tableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbRoomFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddTenant = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).BeginInit();
            this.panelTop.SuspendLayout();
            this.tableHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(24);
            this.panelMain.Size = new System.Drawing.Size(1200, 760);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.BorderRadius = 18;
            this.panelContent.Controls.Add(this.dataGridViewTenants);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(24, 164);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(24);
            this.panelContent.ShadowDecoration.Enabled = true;
            this.panelContent.ShadowDecoration.Depth = 8;
            this.panelContent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 12, 12);
            this.panelContent.Size = new System.Drawing.Size(1152, 572);
            this.panelContent.TabIndex = 1;
            // 
            // dataGridViewTenants
            // 
            this.dataGridViewTenants.AllowUserToAddRows = false;
            this.dataGridViewTenants.AllowUserToDeleteRows = false;
            this.dataGridViewTenants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTenants.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTenants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTenants.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewTenants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTenants.ColumnHeadersHeight = 56;
            this.dataGridViewTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTenants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenantNameColumn,
            this.RoomColumn,
            this.PhoneColumn,
            this.FingerprintColumn,
            this.ContractColumn});
            this.dataGridViewTenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTenants.EnableHeadersVisualStyles = false;
            this.dataGridViewTenants.GridColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.dataGridViewTenants.Location = new System.Drawing.Point(24, 24);
            this.dataGridViewTenants.MultiSelect = false;
            this.dataGridViewTenants.Name = "dataGridViewTenants";
            this.dataGridViewTenants.ReadOnly = true;
            this.dataGridViewTenants.RowHeadersVisible = false;
            this.dataGridViewTenants.RowTemplate.Height = 56;
            this.dataGridViewTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenants.Size = new System.Drawing.Size(1104, 524);
            this.dataGridViewTenants.TabIndex = 0;
            this.dataGridViewTenants.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewTenants_CellDoubleClick);
            this.dataGridViewTenants.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewTenants_CellFormatting);
            this.dataGridViewTenants.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewTenants_CellPainting);
            // 
            // TenantNameColumn
            // 
            this.TenantNameColumn.HeaderText = "Người thuê";
            this.TenantNameColumn.MinimumWidth = 160;
            this.TenantNameColumn.Name = "TenantNameColumn";
            this.TenantNameColumn.ReadOnly = true;
            // 
            // RoomColumn
            // 
            this.RoomColumn.HeaderText = "Phòng";
            this.RoomColumn.MinimumWidth = 110;
            this.RoomColumn.Name = "RoomColumn";
            this.RoomColumn.ReadOnly = true;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.HeaderText = "Số điện thoại";
            this.PhoneColumn.MinimumWidth = 140;
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.ReadOnly = true;
            // 
            // FingerprintColumn
            // 
            this.FingerprintColumn.HeaderText = "Vân tay";
            this.FingerprintColumn.MinimumWidth = 140;
            this.FingerprintColumn.Name = "FingerprintColumn";
            this.FingerprintColumn.ReadOnly = true;
            // 
            // ContractColumn
            // 
            this.ContractColumn.HeaderText = "Hợp đồng";
            this.ContractColumn.MinimumWidth = 140;
            this.ContractColumn.Name = "ContractColumn";
            this.ContractColumn.ReadOnly = true;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.BorderRadius = 18;
            this.panelTop.Controls.Add(this.tableHeader);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(24, 24);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(24);
            this.panelTop.ShadowDecoration.Enabled = true;
            this.panelTop.ShadowDecoration.Depth = 6;
            this.panelTop.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 10, 8);
            this.panelTop.Size = new System.Drawing.Size(1152, 140);
            this.panelTop.TabIndex = 0;
            // 
            // tableHeader
            // 
            this.tableHeader.ColumnCount = 3;
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableHeader.Controls.Add(this.txtSearch, 0, 0);
            this.tableHeader.Controls.Add(this.cmbRoomFilter, 1, 0);
            this.tableHeader.Controls.Add(this.btnAddTenant, 2, 0);
            this.tableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableHeader.Location = new System.Drawing.Point(24, 66);
            this.tableHeader.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.RowCount = 1;
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableHeader.Size = new System.Drawing.Size(1104, 50);
            this.tableHeader.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.txtSearch.PlaceholderText = "Tìm kiếm theo tên, SĐT...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(606, 50);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // cmbRoomFilter
            // 
            this.cmbRoomFilter.BackColor = System.Drawing.Color.Transparent;
            this.cmbRoomFilter.BorderRadius = 10;
            this.cmbRoomFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRoomFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRoomFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.cmbRoomFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoomFilter.ForeColor = System.Drawing.Color.Black;
            this.cmbRoomFilter.ItemHeight = 30;
            this.cmbRoomFilter.Location = new System.Drawing.Point(618, 0);
            this.cmbRoomFilter.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.cmbRoomFilter.Name = "cmbRoomFilter";
            this.cmbRoomFilter.Size = new System.Drawing.Size(220, 36);
            this.cmbRoomFilter.TabIndex = 1;
            this.cmbRoomFilter.SelectedIndexChanged += new System.EventHandler(this.CmbRoomFilter_SelectedIndexChanged);
            // 
            // btnAddTenant
            // 
            this.btnAddTenant.BorderRadius = 10;
            this.btnAddTenant.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTenant.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTenant.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnAddTenant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnAddTenant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTenant.FillColor = System.Drawing.Color.FromArgb(128, 90, 213);
            this.btnAddTenant.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAddTenant.ForeColor = System.Drawing.Color.White;
            this.btnAddTenant.Location = new System.Drawing.Point(850, 0);
            this.btnAddTenant.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTenant.Name = "btnAddTenant";
            this.btnAddTenant.Size = new System.Drawing.Size(254, 50);
            this.btnAddTenant.TabIndex = 2;
            this.btnAddTenant.Text = "+ Thêm người thuê mới";
            this.btnAddTenant.Click += new System.EventHandler(this.BtnAddTenant_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(47, 47, 65);
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1104, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách người thuê";
            // 
            // FormTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.panelMain);
            this.Name = "FormTenant";
            this.Text = "Quản lý người thuê";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.tableHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel panelMain;
        private Guna2Panel panelContent;
        private DataGridView dataGridViewTenants;
        private DataGridViewTextBoxColumn TenantNameColumn;
        private DataGridViewTextBoxColumn RoomColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn FingerprintColumn;
        private DataGridViewTextBoxColumn ContractColumn;
        private Guna2Panel panelTop;
        private TableLayoutPanel tableHeader;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cmbRoomFilter;
        private Guna2Button btnAddTenant;
        private Label lblTitle;
    }
}
