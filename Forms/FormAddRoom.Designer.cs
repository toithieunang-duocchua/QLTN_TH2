namespace QLTN.Forms
{
    partial class FormAddRoom
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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelFurniture = new System.Windows.Forms.Panel();
            this.chkNoFurniture = new System.Windows.Forms.CheckBox();
            this.chkChair = new System.Windows.Forms.CheckBox();
            this.chkWardrobe = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.chkWashingMachine = new System.Windows.Forms.CheckBox();
            this.chkAirConditioner = new System.Windows.Forms.CheckBox();
            this.chkRefrigerator = new System.Windows.Forms.CheckBox();
            this.lblFurniture = new System.Windows.Forms.Label();
            this.txtRentPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRentPrice = new System.Windows.Forms.Label();
            this.txtArea = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtRoomCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelFurniture.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.lblNotes);
            this.panelMain.Controls.Add(this.cmbStatus);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.panelFurniture);
            this.panelMain.Controls.Add(this.lblFurniture);
            this.panelMain.Controls.Add(this.txtRentPrice);
            this.panelMain.Controls.Add(this.lblRentPrice);
            this.panelMain.Controls.Add(this.txtArea);
            this.panelMain.Controls.Add(this.lblArea);
            this.panelMain.Controls.Add(this.txtRoomCode);
            this.panelMain.Controls.Add(this.lblRoomCode);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(735, 814);
            this.panelMain.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(306, 762);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu ";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BorderRadius = 10;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(159, 644);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "Nhập ghi chú...";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(400, 98);
            this.txtNotes.TabIndex = 6;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNotes.Location = new System.Drawing.Point(166, 611);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(113, 23);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Ghi chú riêng";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 10;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang thuê",
            "Bảo trì"});
            this.cmbStatus.Location = new System.Drawing.Point(159, 560);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(400, 36);
            this.cmbStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStatus.Location = new System.Drawing.Point(166, 531);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái";
            // 
            // panelFurniture
            // 
            this.panelFurniture.Controls.Add(this.chkNoFurniture);
            this.panelFurniture.Controls.Add(this.chkChair);
            this.panelFurniture.Controls.Add(this.chkWardrobe);
            this.panelFurniture.Controls.Add(this.chkTable);
            this.panelFurniture.Controls.Add(this.chkWashingMachine);
            this.panelFurniture.Controls.Add(this.chkAirConditioner);
            this.panelFurniture.Controls.Add(this.chkRefrigerator);
            this.panelFurniture.Location = new System.Drawing.Point(159, 395);
            this.panelFurniture.Name = "panelFurniture";
            this.panelFurniture.Size = new System.Drawing.Size(400, 120);
            this.panelFurniture.TabIndex = 0;
            // 
            // chkNoFurniture
            // 
            this.chkNoFurniture.AutoSize = true;
            this.chkNoFurniture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoFurniture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkNoFurniture.Location = new System.Drawing.Point(0, 60);
            this.chkNoFurniture.Name = "chkNoFurniture";
            this.chkNoFurniture.Size = new System.Drawing.Size(149, 24);
            this.chkNoFurniture.TabIndex = 0;
            this.chkNoFurniture.Text = "Không có nội thất";
            this.chkNoFurniture.UseVisualStyleBackColor = true;
            // 
            // chkChair
            // 
            this.chkChair.AutoSize = true;
            this.chkChair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkChair.Location = new System.Drawing.Point(310, 30);
            this.chkChair.Name = "chkChair";
            this.chkChair.Size = new System.Drawing.Size(57, 24);
            this.chkChair.TabIndex = 0;
            this.chkChair.Text = "Ghế";
            this.chkChair.UseVisualStyleBackColor = true;
            // 
            // chkWardrobe
            // 
            this.chkWardrobe.AutoSize = true;
            this.chkWardrobe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWardrobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkWardrobe.Location = new System.Drawing.Point(147, 30);
            this.chkWardrobe.Name = "chkWardrobe";
            this.chkWardrobe.Size = new System.Drawing.Size(105, 24);
            this.chkWardrobe.TabIndex = 0;
            this.chkWardrobe.Text = "Tủ áo quần";
            this.chkWardrobe.UseVisualStyleBackColor = true;
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkTable.Location = new System.Drawing.Point(310, 0);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(56, 24);
            this.chkTable.TabIndex = 0;
            this.chkTable.Text = "Bàn";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // chkWashingMachine
            // 
            this.chkWashingMachine.AutoSize = true;
            this.chkWashingMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWashingMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkWashingMachine.Location = new System.Drawing.Point(147, 0);
            this.chkWashingMachine.Name = "chkWashingMachine";
            this.chkWashingMachine.Size = new System.Drawing.Size(89, 24);
            this.chkWashingMachine.TabIndex = 0;
            this.chkWashingMachine.Text = "Máy giặt";
            this.chkWashingMachine.UseVisualStyleBackColor = true;
            // 
            // chkAirConditioner
            // 
            this.chkAirConditioner.AutoSize = true;
            this.chkAirConditioner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAirConditioner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAirConditioner.Location = new System.Drawing.Point(0, 30);
            this.chkAirConditioner.Name = "chkAirConditioner";
            this.chkAirConditioner.Size = new System.Drawing.Size(91, 24);
            this.chkAirConditioner.TabIndex = 0;
            this.chkAirConditioner.Text = "Máy lạnh";
            this.chkAirConditioner.UseVisualStyleBackColor = true;
            // 
            // chkRefrigerator
            // 
            this.chkRefrigerator.AutoSize = true;
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
            this.lblFurniture.Location = new System.Drawing.Point(165, 356);
            this.lblFurniture.Name = "lblFurniture";
            this.lblFurniture.Size = new System.Drawing.Size(73, 23);
            this.lblFurniture.TabIndex = 0;
            this.lblFurniture.Text = "Nội thất";
            // 
            // txtRentPrice
            // 
            this.txtRentPrice.BorderRadius = 10;
            this.txtRentPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRentPrice.DefaultText = "";
            this.txtRentPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRentPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRentPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRentPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Location = new System.Drawing.Point(159, 292);
            this.txtRentPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRentPrice.Name = "txtRentPrice";
            this.txtRentPrice.PlaceholderText = "VD: 3700000";
            this.txtRentPrice.SelectedText = "";
            this.txtRentPrice.Size = new System.Drawing.Size(400, 36);
            this.txtRentPrice.TabIndex = 3;
            // 
            // lblRentPrice
            // 
            this.lblRentPrice.AutoSize = true;
            this.lblRentPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRentPrice.Location = new System.Drawing.Point(155, 255);
            this.lblRentPrice.Name = "lblRentPrice";
            this.lblRentPrice.Size = new System.Drawing.Size(178, 23);
            this.lblRentPrice.TabIndex = 0;
            this.lblRentPrice.Text = "Giá thuê (VNĐ/tháng)";
            // 
            // txtArea
            // 
            this.txtArea.BorderRadius = 10;
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DefaultText = "";
            this.txtArea.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtArea.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtArea.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArea.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Location = new System.Drawing.Point(159, 202);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArea.Name = "txtArea";
            this.txtArea.PlaceholderText = "VD: 25";
            this.txtArea.SelectedText = "";
            this.txtArea.Size = new System.Drawing.Size(400, 36);
            this.txtArea.TabIndex = 2;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblArea.Location = new System.Drawing.Point(155, 166);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(114, 23);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Diện tích (m²)";
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.BorderRadius = 10;
            this.txtRoomCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomCode.DefaultText = "";
            this.txtRoomCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoomCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Location = new System.Drawing.Point(159, 108);
            this.txtRoomCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.PlaceholderText = "VD: 101";
            this.txtRoomCode.SelectedText = "";
            this.txtRoomCode.Size = new System.Drawing.Size(400, 36);
            this.txtRoomCode.TabIndex = 1;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoomCode.Location = new System.Drawing.Point(161, 67);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(89, 23);
            this.lblRoomCode.TabIndex = 0;
            this.lblRoomCode.Text = "Mã phòng";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTitle.Location = new System.Drawing.Point(233, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm Phòng Mới";
            // 
            // FormAddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 814);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Phòng Mới";
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
        private System.Windows.Forms.Label lblArea;
        private Guna.UI2.WinForms.Guna2TextBox txtArea;
        private System.Windows.Forms.Label lblRentPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtRentPrice;
        private System.Windows.Forms.Label lblFurniture;
        private System.Windows.Forms.Panel panelFurniture;
        private System.Windows.Forms.CheckBox chkRefrigerator;
        private System.Windows.Forms.CheckBox chkAirConditioner;
        private System.Windows.Forms.CheckBox chkWashingMachine;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.CheckBox chkWardrobe;
        private System.Windows.Forms.CheckBox chkChair;
        private System.Windows.Forms.CheckBox chkNoFurniture;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label lblNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}