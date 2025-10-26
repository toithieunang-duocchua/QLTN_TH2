using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.panelFurniture = new Guna.UI2.WinForms.Guna2Panel();
            this.chkNoFurniture = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkChair = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkWardrobe = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkTable = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkWashingMachine = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAirConditioner = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkRefrigerator = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblFurniture = new System.Windows.Forms.Label();
            this.txtRentPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRentPrice = new System.Windows.Forms.Label();
            this.txtArea = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtRoomCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelFurniture.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40, 37, 40, 37);
            this.panelMain.Size = new System.Drawing.Size(1600, 862);
            this.panelMain.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.txtNotes);
            this.panelRight.Controls.Add(this.lblNotes);
            this.panelRight.Controls.Add(this.cmbStatus);
            this.panelRight.Controls.Add(this.lblStatus);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(800, 37);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelRight.Size = new System.Drawing.Size(760, 702);
            this.panelRight.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.BorderRadius = 8;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "Nhập ghi chú...";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(32, 270);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(5);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(707, 246);
            this.txtNotes.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNotes.Location = new System.Drawing.Point(27, 221);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(89, 28);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 8;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Items.AddRange(new object[] {
            "Còn trống",
            "Đang thuê",
            "Bảo trì"});
            this.cmbStatus.Location = new System.Drawing.Point(24, 57);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(705, 36);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStatus.Location = new System.Drawing.Point(31, 12);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 28);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.panelFurniture);
            this.panelLeft.Controls.Add(this.txtRentPrice);
            this.panelLeft.Controls.Add(this.lblRentPrice);
            this.panelLeft.Controls.Add(this.txtArea);
            this.panelLeft.Controls.Add(this.lblArea);
            this.panelLeft.Controls.Add(this.txtRoomCode);
            this.panelLeft.Controls.Add(this.lblRoomCode);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(40, 37);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelLeft.Size = new System.Drawing.Size(760, 702);
            this.panelLeft.TabIndex = 2;
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
            this.panelFurniture.Controls.Add(this.lblFurniture);
            this.panelFurniture.Location = new System.Drawing.Point(4, 209);
            this.panelFurniture.Margin = new System.Windows.Forms.Padding(4);
            this.panelFurniture.Name = "panelFurniture";
            this.panelFurniture.Size = new System.Drawing.Size(707, 295);
            this.panelFurniture.TabIndex = 5;
            // 
            // chkNoFurniture
            // 
            this.chkNoFurniture.AutoSize = true;
            this.chkNoFurniture.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkNoFurniture.CheckedState.BorderRadius = 0;
            this.chkNoFurniture.CheckedState.BorderThickness = 0;
            this.chkNoFurniture.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkNoFurniture.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkNoFurniture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkNoFurniture.Location = new System.Drawing.Point(27, 202);
            this.chkNoFurniture.Margin = new System.Windows.Forms.Padding(4);
            this.chkNoFurniture.Name = "chkNoFurniture";
            this.chkNoFurniture.Size = new System.Drawing.Size(170, 27);
            this.chkNoFurniture.TabIndex = 7;
            this.chkNoFurniture.Text = "Không có nội thất";
            this.chkNoFurniture.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkNoFurniture.UncheckedState.BorderRadius = 0;
            this.chkNoFurniture.UncheckedState.BorderThickness = 1;
            this.chkNoFurniture.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkChair
            // 
            this.chkChair.AutoSize = true;
            this.chkChair.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkChair.CheckedState.BorderRadius = 0;
            this.chkChair.CheckedState.BorderThickness = 0;
            this.chkChair.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkChair.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkChair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkChair.Location = new System.Drawing.Point(373, 49);
            this.chkChair.Margin = new System.Windows.Forms.Padding(4);
            this.chkChair.Name = "chkChair";
            this.chkChair.Size = new System.Drawing.Size(63, 27);
            this.chkChair.TabIndex = 6;
            this.chkChair.Text = "Ghế";
            this.chkChair.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkChair.UncheckedState.BorderRadius = 0;
            this.chkChair.UncheckedState.BorderThickness = 1;
            this.chkChair.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkWardrobe
            // 
            this.chkWardrobe.AutoSize = true;
            this.chkWardrobe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWardrobe.CheckedState.BorderRadius = 0;
            this.chkWardrobe.CheckedState.BorderThickness = 0;
            this.chkWardrobe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWardrobe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkWardrobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkWardrobe.Location = new System.Drawing.Point(373, 148);
            this.chkWardrobe.Margin = new System.Windows.Forms.Padding(4);
            this.chkWardrobe.Name = "chkWardrobe";
            this.chkWardrobe.Size = new System.Drawing.Size(119, 27);
            this.chkWardrobe.TabIndex = 4;
            this.chkWardrobe.Text = "Tủ áo quần";
            this.chkWardrobe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkWardrobe.UncheckedState.BorderRadius = 0;
            this.chkWardrobe.UncheckedState.BorderThickness = 1;
            this.chkWardrobe.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkTable.CheckedState.BorderRadius = 0;
            this.chkTable.CheckedState.BorderThickness = 0;
            this.chkTable.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkTable.Location = new System.Drawing.Point(373, 98);
            this.chkTable.Margin = new System.Windows.Forms.Padding(4);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(61, 27);
            this.chkTable.TabIndex = 5;
            this.chkTable.Text = "Bàn";
            this.chkTable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkTable.UncheckedState.BorderRadius = 0;
            this.chkTable.UncheckedState.BorderThickness = 1;
            this.chkTable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkWashingMachine
            // 
            this.chkWashingMachine.AutoSize = true;
            this.chkWashingMachine.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWashingMachine.CheckedState.BorderRadius = 0;
            this.chkWashingMachine.CheckedState.BorderThickness = 0;
            this.chkWashingMachine.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkWashingMachine.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkWashingMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkWashingMachine.Location = new System.Drawing.Point(27, 98);
            this.chkWashingMachine.Margin = new System.Windows.Forms.Padding(4);
            this.chkWashingMachine.Name = "chkWashingMachine";
            this.chkWashingMachine.Size = new System.Drawing.Size(98, 27);
            this.chkWashingMachine.TabIndex = 2;
            this.chkWashingMachine.Text = "Máy giặt";
            this.chkWashingMachine.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkWashingMachine.UncheckedState.BorderRadius = 0;
            this.chkWashingMachine.UncheckedState.BorderThickness = 1;
            this.chkWashingMachine.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkAirConditioner
            // 
            this.chkAirConditioner.AutoSize = true;
            this.chkAirConditioner.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAirConditioner.CheckedState.BorderRadius = 0;
            this.chkAirConditioner.CheckedState.BorderThickness = 0;
            this.chkAirConditioner.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkAirConditioner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkAirConditioner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkAirConditioner.Location = new System.Drawing.Point(27, 148);
            this.chkAirConditioner.Margin = new System.Windows.Forms.Padding(4);
            this.chkAirConditioner.Name = "chkAirConditioner";
            this.chkAirConditioner.Size = new System.Drawing.Size(102, 27);
            this.chkAirConditioner.TabIndex = 3;
            this.chkAirConditioner.Text = "Máy lạnh";
            this.chkAirConditioner.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAirConditioner.UncheckedState.BorderRadius = 0;
            this.chkAirConditioner.UncheckedState.BorderThickness = 1;
            this.chkAirConditioner.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkRefrigerator
            // 
            this.chkRefrigerator.AutoSize = true;
            this.chkRefrigerator.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRefrigerator.CheckedState.BorderRadius = 0;
            this.chkRefrigerator.CheckedState.BorderThickness = 0;
            this.chkRefrigerator.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRefrigerator.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkRefrigerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.chkRefrigerator.Location = new System.Drawing.Point(27, 49);
            this.chkRefrigerator.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefrigerator.Name = "chkRefrigerator";
            this.chkRefrigerator.Size = new System.Drawing.Size(89, 27);
            this.chkRefrigerator.TabIndex = 1;
            this.chkRefrigerator.Text = "Tủ lạnh";
            this.chkRefrigerator.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkRefrigerator.UncheckedState.BorderRadius = 0;
            this.chkRefrigerator.UncheckedState.BorderThickness = 1;
            this.chkRefrigerator.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // lblFurniture
            // 
            this.lblFurniture.AutoSize = true;
            this.lblFurniture.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFurniture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFurniture.Location = new System.Drawing.Point(27, 12);
            this.lblFurniture.Margin = new System.Windows.Forms.Padding(4);
            this.lblFurniture.Name = "lblFurniture";
            this.lblFurniture.Size = new System.Drawing.Size(96, 28);
            this.lblFurniture.TabIndex = 0;
            this.lblFurniture.Text = "Nội thất:";
            // 
            // txtRentPrice
            // 
            this.txtRentPrice.BorderRadius = 8;
            this.txtRentPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRentPrice.DefaultText = "";
            this.txtRentPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRentPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRentPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRentPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRentPrice.ForeColor = System.Drawing.Color.Black;
            this.txtRentPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRentPrice.Location = new System.Drawing.Point(24, 148);
            this.txtRentPrice.Margin = new System.Windows.Forms.Padding(5);
            this.txtRentPrice.Name = "txtRentPrice";
            this.txtRentPrice.PlaceholderText = "";
            this.txtRentPrice.SelectedText = "";
            this.txtRentPrice.Size = new System.Drawing.Size(701, 44);
            this.txtRentPrice.TabIndex = 4;
            // 
            // lblRentPrice
            // 
            this.lblRentPrice.AutoSize = true;
            this.lblRentPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRentPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRentPrice.Location = new System.Drawing.Point(27, 111);
            this.lblRentPrice.Margin = new System.Windows.Forms.Padding(4);
            this.lblRentPrice.Name = "lblRentPrice";
            this.lblRentPrice.Size = new System.Drawing.Size(225, 28);
            this.lblRentPrice.TabIndex = 3;
            this.lblRentPrice.Text = "Giá thuê (VND/tháng):";
            // 
            // txtArea
            // 
            this.txtArea.BorderRadius = 8;
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DefaultText = "";
            this.txtArea.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtArea.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtArea.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArea.ForeColor = System.Drawing.Color.Black;
            this.txtArea.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArea.Location = new System.Drawing.Point(27, 148);
            this.txtArea.Margin = new System.Windows.Forms.Padding(5);
            this.txtArea.Name = "txtArea";
            this.txtArea.PlaceholderText = "";
            this.txtArea.SelectedText = "";
            this.txtArea.Size = new System.Drawing.Size(707, 44);
            this.txtArea.TabIndex = 2;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblArea.Location = new System.Drawing.Point(27, 111);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(149, 28);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Diện tích (m²):";
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.BorderRadius = 8;
            this.txtRoomCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomCode.DefaultText = "";
            this.txtRoomCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomCode.ForeColor = System.Drawing.Color.Black;
            this.txtRoomCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomCode.Location = new System.Drawing.Point(27, 49);
            this.txtRoomCode.Margin = new System.Windows.Forms.Padding(5);
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.PlaceholderText = "";
            this.txtRoomCode.SelectedText = "";
            this.txtRoomCode.Size = new System.Drawing.Size(707, 44);
            this.txtRoomCode.TabIndex = 0;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoomCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRoomCode.Location = new System.Drawing.Point(27, 12);
            this.lblRoomCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(113, 28);
            this.lblRoomCode.TabIndex = 0;
            this.lblRoomCode.Text = "Mã phòng:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnBack);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(40, 739);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1520, 86);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(573, 18);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 49);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(389, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 49);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 10;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(205, 18);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 49);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Quay lại";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTitle.Location = new System.Drawing.Point(484, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(289, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm phòng mới";
            // 
            // FormAddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAddRoom";
            this.Text = "Thêm phòng mới";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelFurniture.ResumeLayout(false);
            this.panelFurniture.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelFurniture;
        private Guna.UI2.WinForms.Guna2CheckBox chkNoFurniture;
        private Guna.UI2.WinForms.Guna2CheckBox chkChair;
        private Guna.UI2.WinForms.Guna2CheckBox chkWardrobe;
        private Guna.UI2.WinForms.Guna2CheckBox chkTable;
        private Guna.UI2.WinForms.Guna2CheckBox chkWashingMachine;
        private Guna.UI2.WinForms.Guna2CheckBox chkAirConditioner;
        private Guna.UI2.WinForms.Guna2CheckBox chkRefrigerator;
        private System.Windows.Forms.Label lblFurniture;
        private Guna.UI2.WinForms.Guna2TextBox txtRentPrice;
        private System.Windows.Forms.Label lblRentPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtArea;
        private System.Windows.Forms.Label lblArea;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomCode;
        private System.Windows.Forms.Label lblRoomCode;
        private Guna.UI2.WinForms.Guna2Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label lblTitle;
    }
}
