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
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddTenant = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).BeginInit();
            this.panelTop.SuspendLayout();
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
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1200, 760);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.dataGridViewTenants);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(20, 150);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1160, 590);
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
            this.dataGridViewTenants.ColumnHeadersHeight = 48;
            this.dataGridViewTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTenants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenantNameColumn,
            this.RoomColumn,
            this.PhoneColumn,
            this.StatusColumn,
            this.ActionColumn});
            this.dataGridViewTenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTenants.EnableHeadersVisualStyles = false;
            this.dataGridViewTenants.GridColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.dataGridViewTenants.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewTenants.MultiSelect = false;
            this.dataGridViewTenants.Name = "dataGridViewTenants";
            this.dataGridViewTenants.ReadOnly = true;
            this.dataGridViewTenants.RowHeadersVisible = false;
            this.dataGridViewTenants.RowTemplate.Height = 48;
            this.dataGridViewTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenants.Size = new System.Drawing.Size(1120, 550);
            this.dataGridViewTenants.TabIndex = 0;
            this.dataGridViewTenants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewTenants_CellContentClick);
            this.dataGridViewTenants.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewTenants_CellFormatting);
            // 
            // TenantNameColumn
            // 
            this.TenantNameColumn.DataPropertyName = "FullName";
            this.TenantNameColumn.FillWeight = 30F;
            this.TenantNameColumn.HeaderText = "Nguoi thue";
            this.TenantNameColumn.Name = "TenantNameColumn";
            this.TenantNameColumn.ReadOnly = true;
            // 
            // RoomColumn
            // 
            this.RoomColumn.DataPropertyName = "RoomCode";
            this.RoomColumn.FillWeight = 15F;
            this.RoomColumn.HeaderText = "Phong";
            this.RoomColumn.Name = "RoomColumn";
            this.RoomColumn.ReadOnly = true;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.DataPropertyName = "PhoneNumber";
            this.PhoneColumn.FillWeight = 20F;
            this.PhoneColumn.HeaderText = "So dien thoai";
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.FillWeight = 20F;
            this.StatusColumn.HeaderText = "Trang thai";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            // 
            // ActionColumn
            // 
            this.ActionColumn.FillWeight = 15F;
            this.ActionColumn.HeaderText = "Thao tac";
            this.ActionColumn.Name = "ActionColumn";
            this.ActionColumn.ReadOnly = true;
            this.ActionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ActionColumn.Text = "Xem";
            this.ActionColumn.UseColumnTextForLinkValue = true;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.btnAddTenant);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1160, 130);
            this.panelTop.TabIndex = 0;
            // 
            // btnAddTenant
            // 
            this.btnAddTenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTenant.BorderRadius = 8;
            this.btnAddTenant.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTenant.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTenant.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnAddTenant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnAddTenant.FillColor = System.Drawing.Color.FromArgb(128, 90, 213);
            this.btnAddTenant.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTenant.ForeColor = System.Drawing.Color.White;
            this.btnAddTenant.Location = new System.Drawing.Point(940, 74);
            this.btnAddTenant.Name = "btnAddTenant";
            this.btnAddTenant.Size = new System.Drawing.Size(200, 40);
            this.btnAddTenant.TabIndex = 2;
            this.btnAddTenant.Text = "+ Them nguoi thue";
            this.btnAddTenant.Click += new System.EventHandler(this.BtnAddTenant_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Location = new System.Drawing.Point(0, 74);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tim theo ten, phong hoac so dien thoai...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(920, 40);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(47, 47, 65);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1160, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sach nguoi thue";
            // 
            // FormTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.panelMain);
            this.Name = "FormTenant";
            this.Text = "Quan ly nguoi thue";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel panelMain;
        private Guna2Panel panelContent;
        private DataGridView dataGridViewTenants;
        private DataGridViewTextBoxColumn TenantNameColumn;
        private DataGridViewTextBoxColumn RoomColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private DataGridViewLinkColumn ActionColumn;
        private Guna2Panel panelTop;
        private Guna2Button btnAddTenant;
        private Guna2TextBox txtSearch;
        private Label lblTitle;
    }
}
