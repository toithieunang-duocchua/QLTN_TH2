using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    partial class FormEditHousePopup
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
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
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
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            // Tuỳ chọn thẩm mỹ
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(76, 132, 255);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(400, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.BorderRadius = 6;
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
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 0);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chỉnh sửa thông tin nhà";
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtAddress.Location = new System.Drawing.Point(150, 200);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(300, 36);
            this.txtAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblAddress.Location = new System.Drawing.Point(20, 210);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 0);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtRooms
            // 
            this.txtRooms.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRooms.DefaultText = "";
            this.txtRooms.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtRooms.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtRooms.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtRooms.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtRooms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtRooms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRooms.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtRooms.Location = new System.Drawing.Point(150, 280);
            this.txtRooms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.PasswordChar = '\0';
            this.txtRooms.PlaceholderText = "";
            this.txtRooms.SelectedText = "";
            this.txtRooms.Size = new System.Drawing.Size(300, 36);
            this.txtRooms.TabIndex = 4;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRooms.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblRooms.Location = new System.Drawing.Point(20, 290);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(0, 0);
            this.lblRooms.TabIndex = 1;
            this.lblRooms.Text = "Số phòng:";
            // 
            // txtFloors
            // 
            this.txtFloors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFloors.DefaultText = "";
            this.txtFloors.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtFloors.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtFloors.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFloors.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtFloors.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFloors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFloors.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtFloors.Location = new System.Drawing.Point(150, 240);
            this.txtFloors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFloors.Name = "txtFloors";
            this.txtFloors.PasswordChar = '\0';
            this.txtFloors.PlaceholderText = "";
            this.txtFloors.SelectedText = "";
            this.txtFloors.Size = new System.Drawing.Size(300, 36);
            this.txtFloors.TabIndex = 3;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFloors.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblFloors.Location = new System.Drawing.Point(20, 250);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(0, 0);
            this.lblFloors.TabIndex = 1;
            this.lblFloors.Text = "Số tầng:";
            // 
            // txtArea
            // 
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DefaultText = "";
            this.txtArea.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtArea.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtArea.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtArea.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtArea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArea.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtArea.Location = new System.Drawing.Point(150, 160);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArea.Name = "txtArea";
            this.txtArea.PasswordChar = '\0';
            this.txtArea.PlaceholderText = "";
            this.txtArea.SelectedText = "";
            this.txtArea.Size = new System.Drawing.Size(300, 36);
            this.txtArea.TabIndex = 1;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblArea.Location = new System.Drawing.Point(20, 170);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(0, 0);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Diện tích:";
            // 
            // txtHouseName
            // 
            this.txtHouseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHouseName.DefaultText = "";
            this.txtHouseName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtHouseName.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtHouseName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtHouseName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtHouseName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtHouseName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHouseName.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtHouseName.Location = new System.Drawing.Point(150, 120);
            this.txtHouseName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHouseName.Name = "txtHouseName";
            this.txtHouseName.PasswordChar = '\0';
            this.txtHouseName.PlaceholderText = "";
            this.txtHouseName.SelectedText = "";
            this.txtHouseName.Size = new System.Drawing.Size(300, 36);
            this.txtHouseName.TabIndex = 0;
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHouseName.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblHouseName.Location = new System.Drawing.Point(20, 130);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(0, 0);
            this.lblHouseName.TabIndex = 1;
            this.lblHouseName.Text = "Tên nhà:";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblInstruction.Location = new System.Drawing.Point(20, 60);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(0, 0);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Vui lòng nhập thông tin nhà mới:";
            // 
            // FormEditHousePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panelMain);
            this.Name = "FormEditHousePopup";
            this.Text = "Chỉnh sửa thông tin nhà";
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel panelMain;
        private Guna2Panel panelButtons;
        private Guna2Button btnSave;
        private Guna2Button btnClose;
        private Guna2Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
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
    }
}
