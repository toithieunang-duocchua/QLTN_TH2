namespace QLTN.Forms
{
    partial class FormHouseManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnAddHouse = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHouseList = new System.Windows.Forms.Panel();
            this.panelHouseB = new System.Windows.Forms.Panel();
            this.btnEditHouseB = new Guna.UI2.WinForms.Guna2Button();
            this.lblHouseBAddress = new System.Windows.Forms.Label();
            this.lblHouseBName = new System.Windows.Forms.Label();
            this.panelHouseA = new System.Windows.Forms.Panel();
            this.btnEditHouseA = new Guna.UI2.WinForms.Guna2Button();
            this.lblHouseAAddress = new System.Windows.Forms.Label();
            this.lblHouseAName = new System.Windows.Forms.Label();
            this.panelHeaderList = new System.Windows.Forms.Panel();
            this.lblActionHeader = new System.Windows.Forms.Label();
            this.lblAddressHeader = new System.Windows.Forms.Label();
            this.lblNameHeader = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelHouseList.SuspendLayout();
            this.panelHouseB.SuspendLayout();
            this.panelHouseA.SuspendLayout();
            this.panelHeaderList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(90)))), ((int)(((byte)(213)))));
            this.panelHeader.Controls.Add(this.btnAddHouse);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // btnAddHouse
            // 
            this.btnAddHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHouse.BorderRadius = 10;
            this.btnAddHouse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddHouse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddHouse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddHouse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddHouse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAddHouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHouse.ForeColor = System.Drawing.Color.White;
            this.btnAddHouse.Location = new System.Drawing.Point(720, 35);
            this.btnAddHouse.Name = "btnAddHouse";
            this.btnAddHouse.Size = new System.Drawing.Size(124, 61);
            this.btnAddHouse.TabIndex = 2;
            this.btnAddHouse.Text = "+ Thêm ";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(38, 82);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(324, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Chọn nhà để thực hiện các thao tác khác";
            this.lblSubtitle.Click += new System.EventHandler(this.lblSubtitle_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(58, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chọn nhà";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.panelHouseList);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 120);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1000, 530);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelHouseList
            // 
            this.panelHouseList.Controls.Add(this.panelHouseB);
            this.panelHouseList.Controls.Add(this.panelHouseA);
            this.panelHouseList.Controls.Add(this.panelHeaderList);
            this.panelHouseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHouseList.Location = new System.Drawing.Point(30, 30);
            this.panelHouseList.Name = "panelHouseList";
            this.panelHouseList.Size = new System.Drawing.Size(940, 470);
            this.panelHouseList.TabIndex = 0;
            // 
            // panelHouseB
            // 
            this.panelHouseB.Controls.Add(this.btnEditHouseB);
            this.panelHouseB.Controls.Add(this.lblHouseBAddress);
            this.panelHouseB.Controls.Add(this.lblHouseBName);
            this.panelHouseB.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHouseB.Location = new System.Drawing.Point(0, 140);
            this.panelHouseB.Name = "panelHouseB";
            this.panelHouseB.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHouseB.Size = new System.Drawing.Size(940, 80);
            this.panelHouseB.TabIndex = 2;
            // 
            // btnEditHouseB
            // 
            this.btnEditHouseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHouseB.BorderRadius = 10;
            this.btnEditHouseB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHouseB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHouseB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditHouseB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditHouseB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditHouseB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditHouseB.ForeColor = System.Drawing.Color.White;
            this.btnEditHouseB.Location = new System.Drawing.Point(743, 20);
            this.btnEditHouseB.Name = "btnEditHouseB";
            this.btnEditHouseB.Size = new System.Drawing.Size(96, 30);
            this.btnEditHouseB.TabIndex = 2;
            this.btnEditHouseB.Text = "Sửa";
            this.btnEditHouseB.Click += new System.EventHandler(this.BtnEditHouse_Click);
            // 
            // lblHouseBAddress
            // 
            this.lblHouseBAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHouseBAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseBAddress.ForeColor = System.Drawing.Color.Black;
            this.lblHouseBAddress.Location = new System.Drawing.Point(271, 10);
            this.lblHouseBAddress.Name = "lblHouseBAddress";
            this.lblHouseBAddress.Size = new System.Drawing.Size(430, 40);
            this.lblHouseBAddress.TabIndex = 1;
            this.lblHouseBAddress.Text = "1056/34/2/5 Nguyễn Thị Thập, Phường Tân Hưng, TP. HCM";
            // 
            // lblHouseBName
            // 
            this.lblHouseBName.AutoSize = true;
            this.lblHouseBName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseBName.ForeColor = System.Drawing.Color.Black;
            this.lblHouseBName.Location = new System.Drawing.Point(20, 18);
            this.lblHouseBName.Name = "lblHouseBName";
            this.lblHouseBName.Size = new System.Drawing.Size(70, 28);
            this.lblHouseBName.TabIndex = 0;
            this.lblHouseBName.Text = "Nhà B";
            // 
            // panelHouseA
            // 
            this.panelHouseA.Controls.Add(this.btnEditHouseA);
            this.panelHouseA.Controls.Add(this.lblHouseAAddress);
            this.panelHouseA.Controls.Add(this.lblHouseAName);
            this.panelHouseA.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHouseA.Location = new System.Drawing.Point(0, 60);
            this.panelHouseA.Name = "panelHouseA";
            this.panelHouseA.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHouseA.Size = new System.Drawing.Size(940, 80);
            this.panelHouseA.TabIndex = 1;
            // 
            // btnEditHouseA
            // 
            this.btnEditHouseA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHouseA.BorderRadius = 10;
            this.btnEditHouseA.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHouseA.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditHouseA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditHouseA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditHouseA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditHouseA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditHouseA.ForeColor = System.Drawing.Color.White;
            this.btnEditHouseA.Location = new System.Drawing.Point(743, 20);
            this.btnEditHouseA.Name = "btnEditHouseA";
            this.btnEditHouseA.Size = new System.Drawing.Size(97, 30);
            this.btnEditHouseA.TabIndex = 2;
            this.btnEditHouseA.Text = "Sửa";
            this.btnEditHouseA.Click += new System.EventHandler(this.BtnEditHouse_Click);
            // 
            // lblHouseAAddress
            // 
            this.lblHouseAAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHouseAAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseAAddress.ForeColor = System.Drawing.Color.Black;
            this.lblHouseAAddress.Location = new System.Drawing.Point(271, 20);
            this.lblHouseAAddress.Name = "lblHouseAAddress";
            this.lblHouseAAddress.Size = new System.Drawing.Size(430, 40);
            this.lblHouseAAddress.TabIndex = 1;
            this.lblHouseAAddress.Text = "19 Nguyễn Hữu Thọ, Phường Tân Hưng, TP. HCM";
            // 
            // lblHouseAName
            // 
            this.lblHouseAName.AutoSize = true;
            this.lblHouseAName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseAName.ForeColor = System.Drawing.Color.Black;
            this.lblHouseAName.Location = new System.Drawing.Point(20, 18);
            this.lblHouseAName.Name = "lblHouseAName";
            this.lblHouseAName.Size = new System.Drawing.Size(71, 28);
            this.lblHouseAName.TabIndex = 0;
            this.lblHouseAName.Text = "Nhà A";
            // 
            // panelHeaderList
            // 
            this.panelHeaderList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelHeaderList.Controls.Add(this.lblActionHeader);
            this.panelHeaderList.Controls.Add(this.lblAddressHeader);
            this.panelHeaderList.Controls.Add(this.lblNameHeader);
            this.panelHeaderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderList.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderList.Name = "panelHeaderList";
            this.panelHeaderList.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHeaderList.Size = new System.Drawing.Size(940, 60);
            this.panelHeaderList.TabIndex = 0;
            // 
            // lblActionHeader
            // 
            this.lblActionHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActionHeader.AutoSize = true;
            this.lblActionHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblActionHeader.Location = new System.Drawing.Point(745, 20);
            this.lblActionHeader.Name = "lblActionHeader";
            this.lblActionHeader.Size = new System.Drawing.Size(90, 23);
            this.lblActionHeader.TabIndex = 2;
            this.lblActionHeader.Text = "THAO TÁC";
            this.lblActionHeader.Click += new System.EventHandler(this.lblActionHeader_Click);
            // 
            // lblAddressHeader
            // 
            this.lblAddressHeader.AutoSize = true;
            this.lblAddressHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAddressHeader.Location = new System.Drawing.Point(362, 20);
            this.lblAddressHeader.Name = "lblAddressHeader";
            this.lblAddressHeader.Size = new System.Drawing.Size(71, 23);
            this.lblAddressHeader.TabIndex = 1;
            this.lblAddressHeader.Text = "ĐỊA CHỈ";
            // 
            // lblNameHeader
            // 
            this.lblNameHeader.AutoSize = true;
            this.lblNameHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNameHeader.Location = new System.Drawing.Point(20, 20);
            this.lblNameHeader.Name = "lblNameHeader";
            this.lblNameHeader.Size = new System.Drawing.Size(82, 23);
            this.lblNameHeader.TabIndex = 0;
            this.lblNameHeader.Text = "TÊN NHÀ";
            // 
            // FormHouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(90)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormHouseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelHouseList.ResumeLayout(false);
            this.panelHouseB.ResumeLayout(false);
            this.panelHouseB.PerformLayout();
            this.panelHouseA.ResumeLayout(false);
            this.panelHouseA.PerformLayout();
            this.panelHeaderList.ResumeLayout(false);
            this.panelHeaderList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Button btnAddHouse;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelHouseList;
        private System.Windows.Forms.Panel panelHouseB;
        private Guna.UI2.WinForms.Guna2Button btnEditHouseB;
        private System.Windows.Forms.Label lblHouseBAddress;
        private System.Windows.Forms.Label lblHouseBName;
        private System.Windows.Forms.Panel panelHouseA;
        private Guna.UI2.WinForms.Guna2Button btnEditHouseA;
        private System.Windows.Forms.Label lblHouseAAddress;
        private System.Windows.Forms.Label lblHouseAName;
        private System.Windows.Forms.Panel panelHeaderList;
        private System.Windows.Forms.Label lblActionHeader;
        private System.Windows.Forms.Label lblAddressHeader;
        private System.Windows.Forms.Label lblNameHeader;
    }
}