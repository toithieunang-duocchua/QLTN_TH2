namespace QLTN.Forms
{
    partial class FormRoom
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelAddRoom = new System.Windows.Forms.Panel();
            this.btnAddRoom = new Guna.UI2.WinForms.Guna2Button();
            this.lblAddRoom = new System.Windows.Forms.Label();
            this.panelRoom201 = new System.Windows.Forms.Panel();
            this.btnView201 = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus201 = new System.Windows.Forms.Label();
            this.lblPrice201 = new System.Windows.Forms.Label();
            this.lblTenant201 = new System.Windows.Forms.Label();
            this.lblArea201 = new System.Windows.Forms.Label();
            this.lblRoomNumber201 = new System.Windows.Forms.Label();
            this.panelRoom103 = new System.Windows.Forms.Panel();
            this.btnView103 = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus103 = new System.Windows.Forms.Label();
            this.lblPrice103 = new System.Windows.Forms.Label();
            this.lblTenant103 = new System.Windows.Forms.Label();
            this.lblArea103 = new System.Windows.Forms.Label();
            this.lblRoomNumber103 = new System.Windows.Forms.Label();
            this.panelRoom102 = new System.Windows.Forms.Panel();
            this.btnView102 = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus102 = new System.Windows.Forms.Label();
            this.lblPrice102 = new System.Windows.Forms.Label();
            this.lblTenant102 = new System.Windows.Forms.Label();
            this.lblArea102 = new System.Windows.Forms.Label();
            this.lblRoomNumber102 = new System.Windows.Forms.Label();
            this.panelRoom101 = new System.Windows.Forms.Panel();
            this.btnView101 = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus101 = new System.Windows.Forms.Label();
            this.lblPrice101 = new System.Windows.Forms.Label();
            this.lblTenant101 = new System.Windows.Forms.Label();
            this.lblArea101 = new System.Windows.Forms.Label();
            this.lblRoomNumber101 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.lblHouseAddress = new System.Windows.Forms.Label();
            this.lblHouseName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelAddRoom.SuspendLayout();
            this.panelRoom201.SuspendLayout();
            this.panelRoom103.SuspendLayout();
            this.panelRoom102.SuspendLayout();
            this.panelRoom101.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1200, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.panelAddRoom);
            this.panelContent.Controls.Add(this.panelRoom201);
            this.panelContent.Controls.Add(this.panelRoom103);
            this.panelContent.Controls.Add(this.panelRoom102);
            this.panelContent.Controls.Add(this.panelRoom101);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 224);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1200, 576);
            this.panelContent.TabIndex = 1;
            // 
            // panelAddRoom
            // 
            this.panelAddRoom.BackColor = System.Drawing.Color.White;
            this.panelAddRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddRoom.Controls.Add(this.btnAddRoom);
            this.panelAddRoom.Controls.Add(this.lblAddRoom);
            this.panelAddRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAddRoom.Location = new System.Drawing.Point(441, 303);
            this.panelAddRoom.Name = "panelAddRoom";
            this.panelAddRoom.Size = new System.Drawing.Size(350, 224);
            this.panelAddRoom.TabIndex = 4;
            this.panelAddRoom.Click += new System.EventHandler(this.BtnAddRoom_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.BorderRadius = 10;
            this.btnAddRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnAddRoom.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.White;
            this.btnAddRoom.Location = new System.Drawing.Point(125, 41);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(100, 100);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "+";
            this.btnAddRoom.Click += new System.EventHandler(this.BtnAddRoom_Click);
            // 
            // lblAddRoom
            // 
            this.lblAddRoom.AutoSize = true;
            this.lblAddRoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblAddRoom.Location = new System.Drawing.Point(100, 160);
            this.lblAddRoom.Name = "lblAddRoom";
            this.lblAddRoom.Size = new System.Drawing.Size(162, 28);
            this.lblAddRoom.TabIndex = 0;
            this.lblAddRoom.Text = "Thêm phòng mới";
            this.lblAddRoom.Click += new System.EventHandler(this.BtnAddRoom_Click);
            // 
            // panelRoom201
            // 
            this.panelRoom201.BackColor = System.Drawing.Color.White;
            this.panelRoom201.Controls.Add(this.btnView201);
            this.panelRoom201.Controls.Add(this.lblStatus201);
            this.panelRoom201.Controls.Add(this.lblPrice201);
            this.panelRoom201.Controls.Add(this.lblTenant201);
            this.panelRoom201.Controls.Add(this.lblArea201);
            this.panelRoom201.Controls.Add(this.lblRoomNumber201);
            this.panelRoom201.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRoom201.Location = new System.Drawing.Point(54, 303);
            this.panelRoom201.Name = "panelRoom201";
            this.panelRoom201.Size = new System.Drawing.Size(350, 224);
            this.panelRoom201.TabIndex = 3;
            this.panelRoom201.Click += new System.EventHandler(this.RoomCard_Click);
            // 
            // btnView201
            // 
            this.btnView201.BorderRadius = 10;
            this.btnView201.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView201.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView201.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView201.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView201.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnView201.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView201.ForeColor = System.Drawing.Color.White;
            this.btnView201.Location = new System.Drawing.Point(119, 176);
            this.btnView201.Name = "btnView201";
            this.btnView201.Size = new System.Drawing.Size(100, 30);
            this.btnView201.TabIndex = 6;
            this.btnView201.Text = "Xem";
            this.btnView201.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // lblStatus201
            // 
            this.lblStatus201.AutoSize = true;
            this.lblStatus201.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus201.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatus201.Location = new System.Drawing.Point(221, 27);
            this.lblStatus201.Name = "lblStatus201";
            this.lblStatus201.Size = new System.Drawing.Size(91, 23);
            this.lblStatus201.TabIndex = 5;
            this.lblStatus201.Text = "Còn trống";
            // 
            // lblPrice201
            // 
            this.lblPrice201.AutoSize = true;
            this.lblPrice201.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice201.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPrice201.Location = new System.Drawing.Point(20, 112);
            this.lblPrice201.Name = "lblPrice201";
            this.lblPrice201.Size = new System.Drawing.Size(189, 28);
            this.lblPrice201.TabIndex = 3;
            this.lblPrice201.Text = "3,500,000 đ/tháng";
            // 
            // lblTenant201
            // 
            this.lblTenant201.AutoSize = true;
            this.lblTenant201.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenant201.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTenant201.Location = new System.Drawing.Point(20, 90);
            this.lblTenant201.Name = "lblTenant201";
            this.lblTenant201.Size = new System.Drawing.Size(24, 23);
            this.lblTenant201.TabIndex = 2;
            this.lblTenant201.Text = "--";
            // 
            // lblArea201
            // 
            this.lblArea201.AutoSize = true;
            this.lblArea201.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea201.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblArea201.Location = new System.Drawing.Point(20, 60);
            this.lblArea201.Name = "lblArea201";
            this.lblArea201.Size = new System.Drawing.Size(54, 23);
            this.lblArea201.TabIndex = 1;
            this.lblArea201.Text = "25 m²";
            // 
            // lblRoomNumber201
            // 
            this.lblRoomNumber201.AutoSize = true;
            this.lblRoomNumber201.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber201.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomNumber201.Location = new System.Drawing.Point(20, 20);
            this.lblRoomNumber201.Name = "lblRoomNumber201";
            this.lblRoomNumber201.Size = new System.Drawing.Size(137, 32);
            this.lblRoomNumber201.TabIndex = 0;
            this.lblRoomNumber201.Text = "Phòng 201";
            // 
            // panelRoom103
            // 
            this.panelRoom103.BackColor = System.Drawing.Color.White;
            this.panelRoom103.Controls.Add(this.btnView103);
            this.panelRoom103.Controls.Add(this.lblStatus103);
            this.panelRoom103.Controls.Add(this.lblPrice103);
            this.panelRoom103.Controls.Add(this.lblTenant103);
            this.panelRoom103.Controls.Add(this.lblArea103);
            this.panelRoom103.Controls.Add(this.lblRoomNumber103);
            this.panelRoom103.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRoom103.Location = new System.Drawing.Point(823, 33);
            this.panelRoom103.Name = "panelRoom103";
            this.panelRoom103.Size = new System.Drawing.Size(350, 224);
            this.panelRoom103.TabIndex = 2;
            this.panelRoom103.Click += new System.EventHandler(this.RoomCard_Click);
            // 
            // btnView103
            // 
            this.btnView103.BorderRadius = 10;
            this.btnView103.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView103.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView103.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView103.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView103.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnView103.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView103.ForeColor = System.Drawing.Color.White;
            this.btnView103.Location = new System.Drawing.Point(138, 173);
            this.btnView103.Name = "btnView103";
            this.btnView103.Size = new System.Drawing.Size(100, 30);
            this.btnView103.TabIndex = 7;
            this.btnView103.Text = "Xem";
            this.btnView103.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // lblStatus103
            // 
            this.lblStatus103.AutoSize = true;
            this.lblStatus103.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatus103.Location = new System.Drawing.Point(233, 20);
            this.lblStatus103.Name = "lblStatus103";
            this.lblStatus103.Size = new System.Drawing.Size(91, 23);
            this.lblStatus103.TabIndex = 5;
            this.lblStatus103.Text = "Còn trống";
            this.lblStatus103.Click += new System.EventHandler(this.lblStatus103_Click);
            // 
            // lblPrice103
            // 
            this.lblPrice103.AutoSize = true;
            this.lblPrice103.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPrice103.Location = new System.Drawing.Point(20, 114);
            this.lblPrice103.Name = "lblPrice103";
            this.lblPrice103.Size = new System.Drawing.Size(189, 28);
            this.lblPrice103.TabIndex = 3;
            this.lblPrice103.Text = "4,000,000 đ/tháng";
            // 
            // lblTenant103
            // 
            this.lblTenant103.AutoSize = true;
            this.lblTenant103.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenant103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTenant103.Location = new System.Drawing.Point(20, 90);
            this.lblTenant103.Name = "lblTenant103";
            this.lblTenant103.Size = new System.Drawing.Size(24, 23);
            this.lblTenant103.TabIndex = 2;
            this.lblTenant103.Text = "--";
            // 
            // lblArea103
            // 
            this.lblArea103.AutoSize = true;
            this.lblArea103.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblArea103.Location = new System.Drawing.Point(20, 60);
            this.lblArea103.Name = "lblArea103";
            this.lblArea103.Size = new System.Drawing.Size(54, 23);
            this.lblArea103.TabIndex = 1;
            this.lblArea103.Text = "30 m²";
            // 
            // lblRoomNumber103
            // 
            this.lblRoomNumber103.AutoSize = true;
            this.lblRoomNumber103.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomNumber103.Location = new System.Drawing.Point(20, 20);
            this.lblRoomNumber103.Name = "lblRoomNumber103";
            this.lblRoomNumber103.Size = new System.Drawing.Size(137, 32);
            this.lblRoomNumber103.TabIndex = 0;
            this.lblRoomNumber103.Text = "Phòng 103";
            // 
            // panelRoom102
            // 
            this.panelRoom102.BackColor = System.Drawing.Color.White;
            this.panelRoom102.Controls.Add(this.btnView102);
            this.panelRoom102.Controls.Add(this.lblStatus102);
            this.panelRoom102.Controls.Add(this.lblPrice102);
            this.panelRoom102.Controls.Add(this.lblTenant102);
            this.panelRoom102.Controls.Add(this.lblArea102);
            this.panelRoom102.Controls.Add(this.lblRoomNumber102);
            this.panelRoom102.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRoom102.Location = new System.Drawing.Point(441, 33);
            this.panelRoom102.Name = "panelRoom102";
            this.panelRoom102.Size = new System.Drawing.Size(350, 224);
            this.panelRoom102.TabIndex = 1;
            this.panelRoom102.Click += new System.EventHandler(this.RoomCard_Click);
            // 
            // btnView102
            // 
            this.btnView102.BorderRadius = 10;
            this.btnView102.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView102.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView102.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView102.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView102.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnView102.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView102.ForeColor = System.Drawing.Color.White;
            this.btnView102.Location = new System.Drawing.Point(126, 173);
            this.btnView102.Name = "btnView102";
            this.btnView102.Size = new System.Drawing.Size(100, 30);
            this.btnView102.TabIndex = 6;
            this.btnView102.Text = "Xem";
            this.btnView102.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // lblStatus102
            // 
            this.lblStatus102.AutoSize = true;
            this.lblStatus102.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblStatus102.Location = new System.Drawing.Point(224, 29);
            this.lblStatus102.Name = "lblStatus102";
            this.lblStatus102.Size = new System.Drawing.Size(94, 23);
            this.lblStatus102.TabIndex = 4;
            this.lblStatus102.Text = "Đang thuê";
            // 
            // lblPrice102
            // 
            this.lblPrice102.AutoSize = true;
            this.lblPrice102.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPrice102.Location = new System.Drawing.Point(20, 114);
            this.lblPrice102.Name = "lblPrice102";
            this.lblPrice102.Size = new System.Drawing.Size(189, 28);
            this.lblPrice102.TabIndex = 3;
            this.lblPrice102.Text = "3,800,000 đ/tháng";
            // 
            // lblTenant102
            // 
            this.lblTenant102.AutoSize = true;
            this.lblTenant102.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenant102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTenant102.Location = new System.Drawing.Point(20, 90);
            this.lblTenant102.Name = "lblTenant102";
            this.lblTenant102.Size = new System.Drawing.Size(86, 23);
            this.lblTenant102.TabIndex = 2;
            this.lblTenant102.Text = "Công Đức";
            // 
            // lblArea102
            // 
            this.lblArea102.AutoSize = true;
            this.lblArea102.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblArea102.Location = new System.Drawing.Point(20, 60);
            this.lblArea102.Name = "lblArea102";
            this.lblArea102.Size = new System.Drawing.Size(54, 23);
            this.lblArea102.TabIndex = 1;
            this.lblArea102.Text = "25 m²";
            // 
            // lblRoomNumber102
            // 
            this.lblRoomNumber102.AutoSize = true;
            this.lblRoomNumber102.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomNumber102.Location = new System.Drawing.Point(20, 20);
            this.lblRoomNumber102.Name = "lblRoomNumber102";
            this.lblRoomNumber102.Size = new System.Drawing.Size(137, 32);
            this.lblRoomNumber102.TabIndex = 0;
            this.lblRoomNumber102.Text = "Phòng 102";
            // 
            // panelRoom101
            // 
            this.panelRoom101.BackColor = System.Drawing.Color.White;
            this.panelRoom101.Controls.Add(this.btnView101);
            this.panelRoom101.Controls.Add(this.lblStatus101);
            this.panelRoom101.Controls.Add(this.lblPrice101);
            this.panelRoom101.Controls.Add(this.lblTenant101);
            this.panelRoom101.Controls.Add(this.lblArea101);
            this.panelRoom101.Controls.Add(this.lblRoomNumber101);
            this.panelRoom101.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRoom101.Location = new System.Drawing.Point(54, 33);
            this.panelRoom101.Name = "panelRoom101";
            this.panelRoom101.Size = new System.Drawing.Size(350, 224);
            this.panelRoom101.TabIndex = 0;
            this.panelRoom101.Click += new System.EventHandler(this.RoomCard_Click);
            // 
            // btnView101
            // 
            this.btnView101.BorderRadius = 10;
            this.btnView101.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView101.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView101.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView101.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView101.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnView101.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView101.ForeColor = System.Drawing.Color.White;
            this.btnView101.Location = new System.Drawing.Point(119, 173);
            this.btnView101.Name = "btnView101";
            this.btnView101.Size = new System.Drawing.Size(100, 30);
            this.btnView101.TabIndex = 5;
            this.btnView101.Text = "Xem";
            this.btnView101.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // lblStatus101
            // 
            this.lblStatus101.AutoSize = true;
            this.lblStatus101.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatus101.Location = new System.Drawing.Point(221, 29);
            this.lblStatus101.Name = "lblStatus101";
            this.lblStatus101.Size = new System.Drawing.Size(91, 23);
            this.lblStatus101.TabIndex = 4;
            this.lblStatus101.Text = "Còn trống";
            this.lblStatus101.Click += new System.EventHandler(this.lblStatus101_Click);
            // 
            // lblPrice101
            // 
            this.lblPrice101.AutoSize = true;
            this.lblPrice101.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPrice101.Location = new System.Drawing.Point(21, 120);
            this.lblPrice101.Name = "lblPrice101";
            this.lblPrice101.Size = new System.Drawing.Size(189, 28);
            this.lblPrice101.TabIndex = 3;
            this.lblPrice101.Text = "3,500,000 đ/tháng";
            // 
            // lblTenant101
            // 
            this.lblTenant101.AutoSize = true;
            this.lblTenant101.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenant101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTenant101.Location = new System.Drawing.Point(20, 90);
            this.lblTenant101.Name = "lblTenant101";
            this.lblTenant101.Size = new System.Drawing.Size(185, 23);
            this.lblTenant101.TabIndex = 2;
            this.lblTenant101.Text = "Nguyễn Văn Thiện Bảo";
            // 
            // lblArea101
            // 
            this.lblArea101.AutoSize = true;
            this.lblArea101.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblArea101.Location = new System.Drawing.Point(20, 60);
            this.lblArea101.Name = "lblArea101";
            this.lblArea101.Size = new System.Drawing.Size(54, 23);
            this.lblArea101.TabIndex = 1;
            this.lblArea101.Text = "25 m²";
            // 
            // lblRoomNumber101
            // 
            this.lblRoomNumber101.AutoSize = true;
            this.lblRoomNumber101.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomNumber101.Location = new System.Drawing.Point(20, 20);
            this.lblRoomNumber101.Name = "lblRoomNumber101";
            this.lblRoomNumber101.Size = new System.Drawing.Size(137, 32);
            this.lblRoomNumber101.TabIndex = 0;
            this.lblRoomNumber101.Text = "Phòng 101";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnBack);
            this.panelHeader.Controls.Add(this.lblHouseAddress);
            this.panelHeader.Controls.Add(this.lblHouseName);
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(30);
            this.panelHeader.Size = new System.Drawing.Size(1200, 224);
            this.panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BorderRadius = 10;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1003, 49);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(164, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblHouseAddress
            // 
            this.lblHouseAddress.AutoSize = true;
            this.lblHouseAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHouseAddress.Location = new System.Drawing.Point(33, 188);
            this.lblHouseAddress.Name = "lblHouseAddress";
            this.lblHouseAddress.Size = new System.Drawing.Size(234, 23);
            this.lblHouseAddress.TabIndex = 3;
            this.lblHouseAddress.Text = "19 Nguyễn Hữu Thọ, TP.HCM";
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblHouseName.Location = new System.Drawing.Point(33, 143);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(71, 28);
            this.lblHouseName.TabIndex = 2;
            this.lblHouseName.Text = "Nhà A";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDescription.Location = new System.Drawing.Point(33, 107);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(333, 23);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Xem và quản lý tất cả các phòng cho thuê";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(26, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Phòng";
            // 
            // FormRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.Name = "FormRoom";
            this.Text = "Quản lý Phòng";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelAddRoom.ResumeLayout(false);
            this.panelAddRoom.PerformLayout();
            this.panelRoom201.ResumeLayout(false);
            this.panelRoom201.PerformLayout();
            this.panelRoom103.ResumeLayout(false);
            this.panelRoom103.PerformLayout();
            this.panelRoom102.ResumeLayout(false);
            this.panelRoom102.PerformLayout();
            this.panelRoom101.ResumeLayout(false);
            this.panelRoom101.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelAddRoom;
        private Guna.UI2.WinForms.Guna2Button btnAddRoom;
        private System.Windows.Forms.Label lblAddRoom;
        private System.Windows.Forms.Panel panelRoom201;
        private System.Windows.Forms.Panel panelRoom103;
        private System.Windows.Forms.Panel panelRoom102;
        private System.Windows.Forms.Panel panelRoom101;
        private Guna.UI2.WinForms.Guna2Button btnView101;
        private Guna.UI2.WinForms.Guna2Button btnView102;
        private Guna.UI2.WinForms.Guna2Button btnView103;
        private Guna.UI2.WinForms.Guna2Button btnView201;
        private System.Windows.Forms.Label lblStatus101;
        private System.Windows.Forms.Label lblStatus102;
        private System.Windows.Forms.Label lblStatus103;
        private System.Windows.Forms.Label lblStatus201;
        private System.Windows.Forms.Label lblPrice101;
        private System.Windows.Forms.Label lblPrice102;
        private System.Windows.Forms.Label lblPrice103;
        private System.Windows.Forms.Label lblPrice201;
        private System.Windows.Forms.Label lblTenant101;
        private System.Windows.Forms.Label lblTenant102;
        private System.Windows.Forms.Label lblTenant103;
        private System.Windows.Forms.Label lblTenant201;
        private System.Windows.Forms.Label lblArea101;
        private System.Windows.Forms.Label lblArea102;
        private System.Windows.Forms.Label lblArea103;
        private System.Windows.Forms.Label lblArea201;
        private System.Windows.Forms.Label lblRoomNumber101;
        private System.Windows.Forms.Label lblRoomNumber102;
        private System.Windows.Forms.Label lblRoomNumber103;
        private System.Windows.Forms.Label lblRoomNumber201;
        private System.Windows.Forms.Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label lblHouseAddress;
        private System.Windows.Forms.Label lblHouseName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
    }
}