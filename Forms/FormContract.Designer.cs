using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    partial class FormContract
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.flowFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
             this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
             this.btnAddContract = new Guna.UI2.WinForms.Guna2Button();
             this.panelTable = new System.Windows.Forms.Panel();
             this.colView = new System.Windows.Forms.DataGridViewLinkColumn();
             this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.flowPagination = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.panelExport = new System.Windows.Forms.Panel();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.flowFilters.SuspendLayout();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.flowPagination.SuspendLayout();
            this.panelExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.tableMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1600, 862);
            this.panelMain.TabIndex = 0;
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.panelHeader, 0, 0);
            this.tableMain.Controls.Add(this.panelFilters, 0, 1);
            this.tableMain.Controls.Add(this.panelTable, 0, 2);
            this.tableMain.Controls.Add(this.panelPagination, 0, 3);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(53, 49, 53, 49);
            this.tableMain.RowCount = 4;
             this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
             this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
             this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
             this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableMain.Size = new System.Drawing.Size(1600, 862);
            this.tableMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(57, 53);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1486, 115);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1486, 77);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý hợp đồng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.flowFilters);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilters.Location = new System.Drawing.Point(57, 176);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1486, 78);
            this.panelFilters.TabIndex = 1;
            this.panelFilters.AutoSize = false;
            // 
            // flowFilters
            // 
            this.flowFilters.Controls.Add(this.lblSearch);
            this.flowFilters.Controls.Add(this.txtSearch);
            this.flowFilters.Controls.Add(this.lblStatus);
            this.flowFilters.Controls.Add(this.cmbStatus);
            this.flowFilters.Controls.Add(this.btnAddContract);
            this.flowFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowFilters.Location = new System.Drawing.Point(0, 0);
            this.flowFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowFilters.Name = "flowFilters";
            this.flowFilters.Size = new System.Drawing.Size(1486, 78);
            this.flowFilters.TabIndex = 0;
            this.flowFilters.WrapContents = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSearch.Location = new System.Drawing.Point(4, 17);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 17, 13, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(209, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm theo mã, khách hàng:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(203)))), ((int)(((byte)(207)))));
            this.txtSearch.BorderRadius = 4;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.txtSearch.Location = new System.Drawing.Point(230, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 12, 20, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtSearch.PlaceholderText = "Nhập mã HĐ hoặc tên khách hàng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(400, 44);
            this.txtSearch.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStatus.Location = new System.Drawing.Point(654, 17);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 17, 13, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(91, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(203)))), ((int)(((byte)(207)))));
            this.cmbStatus.BorderRadius = 4;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FillColor = System.Drawing.Color.White;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Đang hiệu lực",
            "Đã hết hạn",
            "Chưa có hiệu lực"});
            this.cmbStatus.Location = new System.Drawing.Point(762, 12);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 12, 20, 0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(265, 36);
            this.cmbStatus.TabIndex = 3;
            // 
            // btnAddContract
            // 
            this.btnAddContract.BorderRadius = 6;
            this.btnAddContract.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddContract.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddContract.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddContract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddContract.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddContract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddContract.ForeColor = System.Drawing.Color.White;
            this.btnAddContract.Location = new System.Drawing.Point(1051, 12);
            this.btnAddContract.Margin = new System.Windows.Forms.Padding(4, 12, 0, 0);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(240, 44);
            this.btnAddContract.TabIndex = 4;
            this.btnAddContract.Text = "+ Thêm hợp đồng";
            // 
            // panelTable
            // 
            this.panelTable.Controls.Add(this.dgvContracts);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.Location = new System.Drawing.Point(57, 262);
            this.panelTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(1486, 449);
            this.panelTable.TabIndex = 2;
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvContracts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvContracts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvContracts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContracts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContracts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContracts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContracts.ColumnHeadersHeight = 50;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContracts.RowTemplate.Height = 45;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colCustomer,
            this.colStartDate,
            this.colEndDate,
            this.colRoom,
             this.colStatus,
             this.colView,
             this.colDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContracts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContracts.EnableHeadersVisualStyles = false;
            this.dgvContracts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvContracts.Location = new System.Drawing.Point(0, 0);
            this.dgvContracts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.RowHeadersWidth = 51;
            this.dgvContracts.Size = new System.Drawing.Size(1486, 449);
            this.dgvContracts.TabIndex = 0;
            this.dgvContracts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContracts_CellContentClick);
            // 
             // colCode
             // 
             this.colCode.HeaderText = "Mã HĐ";
             this.colCode.MinimumWidth = 100;
             this.colCode.Name = "colCode";
             this.colCode.ReadOnly = true;
             this.colCode.Width = 120;
             // 
             // colCustomer
             // 
             this.colCustomer.HeaderText = "Khách hàng";
             this.colCustomer.MinimumWidth = 150;
             this.colCustomer.Name = "colCustomer";
             this.colCustomer.ReadOnly = true;
             this.colCustomer.Width = 200;
             // 
             // colStartDate
             // 
             this.colStartDate.HeaderText = "Ngày bắt đầu";
             this.colStartDate.MinimumWidth = 100;
             this.colStartDate.Name = "colStartDate";
             this.colStartDate.ReadOnly = true;
             this.colStartDate.Width = 150;
             // 
             // colEndDate
             // 
             this.colEndDate.HeaderText = "Ngày kết thúc";
             this.colEndDate.MinimumWidth = 100;
             this.colEndDate.Name = "colEndDate";
             this.colEndDate.ReadOnly = true;
             this.colEndDate.Width = 150;
             // 
             // colRoom
             // 
             this.colRoom.HeaderText = "Phòng";
             this.colRoom.MinimumWidth = 80;
             this.colRoom.Name = "colRoom";
             this.colRoom.ReadOnly = true;
             this.colRoom.Width = 100;
             // 
             // colStatus
             // 
             this.colStatus.HeaderText = "Trạng thái";
             this.colStatus.MinimumWidth = 100;
             this.colStatus.Name = "colStatus";
             this.colStatus.ReadOnly = true;
             this.colStatus.Width = 150;
             // 
             // colView
             // 
             this.colView.HeaderText = "Xem";
             this.colView.MinimumWidth = 80;
             this.colView.Name = "colView";
             this.colView.ReadOnly = true;
             this.colView.Text = "Xem";
             this.colView.Width = 80;
             this.colView.LinkColor = System.Drawing.Color.FromArgb(59, 130, 246);
             this.colView.VisitedLinkColor = System.Drawing.Color.FromArgb(59, 130, 246);
             this.colView.ActiveLinkColor = System.Drawing.Color.FromArgb(37, 99, 235);
             this.colView.UseColumnTextForLinkValue = true;
             // 
             // colDelete
             // 
             this.colDelete.HeaderText = "Xóa";
             this.colDelete.MinimumWidth = 80;
             this.colDelete.Name = "colDelete";
             this.colDelete.ReadOnly = true;
             this.colDelete.Text = "Xóa";
             this.colDelete.Width = 80;
             this.colDelete.LinkColor = System.Drawing.Color.FromArgb(239, 68, 68);
             this.colDelete.VisitedLinkColor = System.Drawing.Color.FromArgb(239, 68, 68);
             this.colDelete.ActiveLinkColor = System.Drawing.Color.FromArgb(220, 38, 38);
             this.colDelete.UseColumnTextForLinkValue = true;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.flowPagination);
            this.panelPagination.Controls.Add(this.panelExport);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPagination.Location = new System.Drawing.Point(57, 719);
            this.panelPagination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1486, 90);
            this.panelPagination.TabIndex = 3;
            // 
            // flowPagination
            // 
            this.flowPagination.Controls.Add(this.btnPrevious);
            this.flowPagination.Controls.Add(this.lblPageInfo);
            this.flowPagination.Controls.Add(this.btnNext);
            this.flowPagination.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowPagination.Location = new System.Drawing.Point(0, 0);
            this.flowPagination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowPagination.Name = "flowPagination";
            this.flowPagination.Size = new System.Drawing.Size(747, 90);
            this.flowPagination.TabIndex = 0;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BorderRadius = 6;
            this.btnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevious.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.btnPrevious.Location = new System.Drawing.Point(4, 23);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 23, 13, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(133, 44);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "< Trước";
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPageInfo.Location = new System.Drawing.Point(154, 33);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 33, 13, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(191, 23);
            this.lblPageInfo.TabIndex = 1;
            this.lblPageInfo.Text = "Trang 1 / 1 — 3 kết quả";
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 6;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.btnNext.Location = new System.Drawing.Point(362, 23);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 23, 0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(133, 44);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Tiếp >";
            // 
            // panelExport
            // 
            this.panelExport.Controls.Add(this.btnExport);
            this.panelExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelExport.Location = new System.Drawing.Point(1313, 0);
            this.panelExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(173, 90);
            this.panelExport.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 6;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.btnExport.Location = new System.Drawing.Point(0, 23);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0, 23, 0, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(173, 44);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export CSV";
            // 
            // FormContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hợp đồng";
            this.panelMain.ResumeLayout(false);
            this.tableMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.flowPagination.ResumeLayout(false);
            this.flowPagination.PerformLayout();
            this.panelExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.FlowLayoutPanel flowFilters;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private Guna.UI2.WinForms.Guna2Button btnAddContract;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewLinkColumn colView;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.FlowLayoutPanel flowPagination;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private System.Windows.Forms.Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.Panel panelExport;
        private Guna.UI2.WinForms.Guna2Button btnExport;
    }
}
