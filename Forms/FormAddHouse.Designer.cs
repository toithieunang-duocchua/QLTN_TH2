using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    partial class FormAddHouse
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtRooms = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRooms = new System.Windows.Forms.Label();
            this.txtFloors = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFloors = new System.Windows.Forms.Label();
            this.txtArea = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtHouseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHouseName = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(500, 400);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnReset);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "Lưu";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Location = new System.Drawing.Point(300, 10);
            // (tuỳ chọn) một vài thiết lập Guna cho đẹp
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(76, 132, 255);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Text = "Reset";
            this.btnReset.Size = new System.Drawing.Size(80, 30);
            this.btnReset.Location = new System.Drawing.Point(400, 10);
            this.btnReset.BorderRadius = 6;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Controls.Add(this.txtAddress);
            this.panelContent.Controls.Add(this.lblAddress);
            this.panelContent.Controls.Add(this.txtRooms);
            this.panelContent.Controls.Add(this.lblRooms);
            this.panelContent.Controls.Add(this.txtFloors);
            this.panelContent.Controls.Add(this.lblFloors);
            this.panelContent.Controls.Add(this.txtArea);
            this.panelContent.Controls.Add(this.lblArea);
            this.panelContent.Controls.Add(this.txtHouseName);
            this.panelContent.Controls.Add(this.lblHouseName);
            this.panelContent.Controls.Add(this.lblInstruction);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(500, 350);
            this.panelContent.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(90)))), ((int)(((byte)(213)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm nhà mới";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 280);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 24);
            this.txtAddress.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddress.Location = new System.Drawing.Point(20, 283);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(80, 28);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtRooms
            // 
            this.txtRooms.Location = new System.Drawing.Point(150, 240);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Size = new System.Drawing.Size(100, 24);
            this.txtRooms.TabIndex = 9;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRooms.Location = new System.Drawing.Point(20, 243);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(100, 28);
            this.lblRooms.TabIndex = 4;
            this.lblRooms.Text = "Số phòng:";
            // 
            // txtFloors
            // 
            this.txtFloors.Location = new System.Drawing.Point(150, 200);
            this.txtFloors.Name = "txtFloors";
            this.txtFloors.Size = new System.Drawing.Size(100, 24);
            this.txtFloors.TabIndex = 7;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFloors.Location = new System.Drawing.Point(20, 203);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(80, 28);
            this.lblFloors.TabIndex = 3;
            this.lblFloors.Text = "Số tầng:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(150, 160);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(100, 24);
            this.txtArea.TabIndex = 5;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblArea.Location = new System.Drawing.Point(20, 163);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(90, 28);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Diện tích:";
            // 
            // txtHouseName
            // 
            this.txtHouseName.Location = new System.Drawing.Point(150, 120);
            this.txtHouseName.Name = "txtHouseName";
            this.txtHouseName.Size = new System.Drawing.Size(300, 24);
            this.txtHouseName.TabIndex = 3;
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHouseName.Location = new System.Drawing.Point(20, 123);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(80, 28);
            this.lblHouseName.TabIndex = 1;
            this.lblHouseName.Text = "Tên nhà:";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblInstruction.Location = new System.Drawing.Point(20, 70);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(300, 28);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Vui lòng nhập thông tin nhà mới:";
            // 
            // FormAddHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panelMain);
            this.Name = "FormAddHouse";
            this.Text = "Thêm nhà mới";
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panelMain;
        private Guna2Panel panelButtons;
        private Guna2Button btnSave;
        private Guna2Button btnReset;
        private Guna2Panel panelContent;
        private Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private Guna2TextBox txtRooms;
        private System.Windows.Forms.Label lblRooms;
        private Guna2TextBox txtFloors;
        private System.Windows.Forms.Label lblFloors;
        private Guna2TextBox txtArea;
        private System.Windows.Forms.Label lblArea;
        private Guna2TextBox txtHouseName;
        private System.Windows.Forms.Label lblHouseName;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblTitle;
    }
}
