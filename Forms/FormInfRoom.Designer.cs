namespace QLTN.Forms
{
    partial class FormInfRoom
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
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtRentPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRentPrice = new System.Windows.Forms.Label();
            this.txtArea = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.panelFurniture = new System.Windows.Forms.Panel();
            this.chkChair = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.chkWardrobe = new System.Windows.Forms.CheckBox();
            this.chkAirConditioner = new System.Windows.Forms.CheckBox();
            this.chkWashingMachine = new System.Windows.Forms.CheckBox();
            this.chkRefrigerator = new System.Windows.Forms.CheckBox();
            this.lblFurniture = new System.Windows.Forms.Label();
            this.txtRoomCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.checkNone = new System.Windows.Forms.CheckBox();
            this.panelMain.SuspendLayout();
            this.panelFurniture.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnEdit);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.lblNotes);
            this.panelMain.Controls.Add(this.cmbStatus);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.txtRentPrice);
            this.panelMain.Controls.Add(this.lblRentPrice);
            this.panelMain.Controls.Add(this.txtArea);
            this.panelMain.Controls.Add(this.lblArea);
            this.panelMain.Controls.Add(this.panelFurniture);
            this.panelMain.Controls.Add(this.lblFurniture);
            this.panelMain.Controls.Add(this.txtRoomCode);
            this.panelMain.Controls.Add(this.lblRoomCode);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(717, 767);
            this.panelMain.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(305, 703);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa ";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BorderRadius = 10;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(154, 576);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(400, 98);
            this.txtNotes.TabIndex = 5;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNotes.Location = new System.Drawing.Point(163, 546);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(69, 23);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Ghi chú";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 10;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang thuê",
            "Bảo trì"});
            this.cmbStatus.Location = new System.Drawing.Point(154, 498);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(400, 36);
            this.cmbStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStatus.Location = new System.Drawing.Point(163, 469);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái";
            // 
            // txtRentPrice
            // 
            this.txtRentPrice.BorderRadius = 10;
            this.txtRentPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRentPrice.DefaultText = "";
            this.txtRentPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRentPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtRentPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRentPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Location = new System.Drawing.Point(154, 424);
            this.txtRentPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRentPrice.Name = "txtRentPrice";
            this.txtRentPrice.PlaceholderText = "";
            this.txtRentPrice.ReadOnly = true;
            this.txtRentPrice.SelectedText = "";
            this.txtRentPrice.Size = new System.Drawing.Size(400, 36);
            this.txtRentPrice.TabIndex = 4;
            // 
            // lblRentPrice
            // 
            this.lblRentPrice.AutoSize = true;
            this.lblRentPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRentPrice.Location = new System.Drawing.Point(159, 395);
            this.lblRentPrice.Name = "lblRentPrice";
            this.lblRentPrice.Size = new System.Drawing.Size(178, 23);
            this.lblRentPrice.TabIndex = 0;
            this.lblRentPrice.Text = "Giá thuê (VNĐ/tháng)";
            this.lblRentPrice.Click += new System.EventHandler(this.lblRentPrice_Click);
            // 
            // txtArea
            // 
            this.txtArea.BorderRadius = 10;
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DefaultText = "";
            this.txtArea.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtArea.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtArea.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArea.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Location = new System.Drawing.Point(154, 348);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArea.Name = "txtArea";
            this.txtArea.PlaceholderText = "";
            this.txtArea.ReadOnly = true;
            this.txtArea.SelectedText = "";
            this.txtArea.Size = new System.Drawing.Size(400, 36);
            this.txtArea.TabIndex = 3;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblArea.Location = new System.Drawing.Point(159, 319);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(114, 23);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Diện tích (m²)";
            // 
            // panelFurniture
            // 
            this.panelFurniture.Controls.Add(this.checkNone);
            this.panelFurniture.Controls.Add(this.chkChair);
            this.panelFurniture.Controls.Add(this.chkTable);
            this.panelFurniture.Controls.Add(this.chkWardrobe);
            this.panelFurniture.Controls.Add(this.chkAirConditioner);
            this.panelFurniture.Controls.Add(this.chkWashingMachine);
            this.panelFurniture.Controls.Add(this.chkRefrigerator);
            this.panelFurniture.Location = new System.Drawing.Point(154, 185);
            this.panelFurniture.Name = "panelFurniture";
            this.panelFurniture.Size = new System.Drawing.Size(427, 114);
            this.panelFurniture.TabIndex = 0;
            // 
            // chkChair
            // 
            this.chkChair.AutoSize = true;
            this.chkChair.Enabled = false;
            this.chkChair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkChair.Location = new System.Drawing.Point(128, 40);
            this.chkChair.Name = "chkChair";
            this.chkChair.Size = new System.Drawing.Size(57, 24);
            this.chkChair.TabIndex = 0;
            this.chkChair.Text = "Ghế";
            this.chkChair.UseVisualStyleBackColor = true;
            this.chkChair.CheckedChanged += new System.EventHandler(this.chkChair_CheckedChanged);
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Checked = true;
            this.chkTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTable.Enabled = false;
            this.chkTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkTable.Location = new System.Drawing.Point(287, 0);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(56, 24);
            this.chkTable.TabIndex = 0;
            this.chkTable.Text = "Bàn";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // chkWardrobe
            // 
            this.chkWardrobe.AutoSize = true;
            this.chkWardrobe.Checked = true;
            this.chkWardrobe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWardrobe.Enabled = false;
            this.chkWardrobe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWardrobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkWardrobe.Location = new System.Drawing.Point(287, 40);
            this.chkWardrobe.Name = "chkWardrobe";
            this.chkWardrobe.Size = new System.Drawing.Size(105, 24);
            this.chkWardrobe.TabIndex = 0;
            this.chkWardrobe.Text = "Tủ áo quần";
            this.chkWardrobe.UseVisualStyleBackColor = true;
            // 
            // chkAirConditioner
            // 
            this.chkAirConditioner.AutoSize = true;
            this.chkAirConditioner.Checked = true;
            this.chkAirConditioner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAirConditioner.Enabled = false;
            this.chkAirConditioner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAirConditioner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAirConditioner.Location = new System.Drawing.Point(128, 0);
            this.chkAirConditioner.Name = "chkAirConditioner";
            this.chkAirConditioner.Size = new System.Drawing.Size(91, 24);
            this.chkAirConditioner.TabIndex = 0;
            this.chkAirConditioner.Text = "Máy lạnh";
            this.chkAirConditioner.UseVisualStyleBackColor = true;
            // 
            // chkWashingMachine
            // 
            this.chkWashingMachine.AutoSize = true;
            this.chkWashingMachine.Enabled = false;
            this.chkWashingMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWashingMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkWashingMachine.Location = new System.Drawing.Point(0, 40);
            this.chkWashingMachine.Name = "chkWashingMachine";
            this.chkWashingMachine.Size = new System.Drawing.Size(89, 24);
            this.chkWashingMachine.TabIndex = 0;
            this.chkWashingMachine.Text = "Máy giặt";
            this.chkWashingMachine.UseVisualStyleBackColor = true;
            // 
            // chkRefrigerator
            // 
            this.chkRefrigerator.AutoSize = true;
            this.chkRefrigerator.Checked = true;
            this.chkRefrigerator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefrigerator.Enabled = false;
            this.chkRefrigerator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRefrigerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkRefrigerator.Location = new System.Drawing.Point(0, 0);
            this.chkRefrigerator.Name = "chkRefrigerator";
            this.chkRefrigerator.Size = new System.Drawing.Size(79, 24);
            this.chkRefrigerator.TabIndex = 0;
            this.chkRefrigerator.Text = "Tủ lạnh";
            this.chkRefrigerator.UseVisualStyleBackColor = true;
            // 
            // lblFurniture
            // 
            this.lblFurniture.AutoSize = true;
            this.lblFurniture.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFurniture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFurniture.Location = new System.Drawing.Point(159, 159);
            this.lblFurniture.Name = "lblFurniture";
            this.lblFurniture.Size = new System.Drawing.Size(73, 23);
            this.lblFurniture.TabIndex = 0;
            this.lblFurniture.Text = "Nội thất";
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.BorderRadius = 10;
            this.txtRoomCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomCode.DefaultText = "";
            this.txtRoomCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtRoomCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoomCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Location = new System.Drawing.Point(154, 100);
            this.txtRoomCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.PlaceholderText = "";
            this.txtRoomCode.ReadOnly = true;
            this.txtRoomCode.SelectedText = "";
            this.txtRoomCode.Size = new System.Drawing.Size(400, 36);
            this.txtRoomCode.TabIndex = 1;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomCode.Location = new System.Drawing.Point(159, 73);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(89, 23);
            this.lblRoomCode.TabIndex = 0;
            this.lblRoomCode.Text = "Mã phòng";
            this.lblRoomCode.Click += new System.EventHandler(this.lblRoomCode_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTitle.Location = new System.Drawing.Point(238, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin phòng";
            // 
            // checkNone
            // 
            this.checkNone.AutoSize = true;
            this.checkNone.Enabled = false;
            this.checkNone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.checkNone.Location = new System.Drawing.Point(0, 80);
            this.checkNone.Name = "checkNone";
            this.checkNone.Size = new System.Drawing.Size(153, 24);
            this.checkNone.TabIndex = 1;
            this.checkNone.Text = "Không có nội thất ";
            this.checkNone.UseVisualStyleBackColor = true;
            // 
            // FormInfRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 767);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInfRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin phòng";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFurniture.ResumeLayout(false);
            this.panelFurniture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoomCode;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomCode;
        private System.Windows.Forms.Label lblFurniture;
        private System.Windows.Forms.Panel panelFurniture;
        private System.Windows.Forms.CheckBox chkRefrigerator;
        private System.Windows.Forms.CheckBox chkAirConditioner;
        private System.Windows.Forms.CheckBox chkWashingMachine;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.CheckBox chkWardrobe;
        private System.Windows.Forms.CheckBox chkChair;
        private System.Windows.Forms.Label lblArea;
        private Guna.UI2.WinForms.Guna2TextBox txtArea;
        private System.Windows.Forms.Label lblRentPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtRentPrice;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private System.Windows.Forms.CheckBox checkNone;
    }
}