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
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(667, 492);
            this.panelMain.TabIndex = 0;
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
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(667, 430);
            this.panelContent.TabIndex = 0;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(90)))), ((int)(((byte)(213)))));
            this.lblTitle.Location = new System.Drawing.Point(27, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm nhà mới";
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(200, 345);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(400, 30);
            this.txtAddress.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddress.Location = new System.Drawing.Point(27, 348);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(83, 28);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtRooms
            // 
            this.txtRooms.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRooms.DefaultText = "";
            this.txtRooms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRooms.Location = new System.Drawing.Point(200, 295);
            this.txtRooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.PlaceholderText = "";
            this.txtRooms.SelectedText = "";
            this.txtRooms.Size = new System.Drawing.Size(133, 30);
            this.txtRooms.TabIndex = 9;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRooms.Location = new System.Drawing.Point(27, 299);
            this.lblRooms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(106, 28);
            this.lblRooms.TabIndex = 4;
            this.lblRooms.Text = "Số phòng:";
            // 
            // txtFloors
            // 
            this.txtFloors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFloors.DefaultText = "";
            this.txtFloors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFloors.Location = new System.Drawing.Point(200, 246);
            this.txtFloors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFloors.Name = "txtFloors";
            this.txtFloors.PlaceholderText = "";
            this.txtFloors.SelectedText = "";
            this.txtFloors.Size = new System.Drawing.Size(133, 30);
            this.txtFloors.TabIndex = 7;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFloors.Location = new System.Drawing.Point(27, 250);
            this.lblFloors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(89, 28);
            this.lblFloors.TabIndex = 3;
            this.lblFloors.Text = "Số tầng:";
            // 
            // txtArea
            // 
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DefaultText = "";
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArea.Location = new System.Drawing.Point(200, 197);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArea.Name = "txtArea";
            this.txtArea.PlaceholderText = "";
            this.txtArea.SelectedText = "";
            this.txtArea.Size = new System.Drawing.Size(133, 30);
            this.txtArea.TabIndex = 5;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblArea.Location = new System.Drawing.Point(27, 201);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(103, 28);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Diện tích:";
            // 
            // txtHouseName
            // 
            this.txtHouseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHouseName.DefaultText = "";
            this.txtHouseName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHouseName.Location = new System.Drawing.Point(200, 148);
            this.txtHouseName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHouseName.Name = "txtHouseName";
            this.txtHouseName.PlaceholderText = "";
            this.txtHouseName.SelectedText = "";
            this.txtHouseName.Size = new System.Drawing.Size(400, 30);
            this.txtHouseName.TabIndex = 3;
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHouseName.Location = new System.Drawing.Point(27, 151);
            this.lblHouseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(91, 28);
            this.lblHouseName.TabIndex = 1;
            this.lblHouseName.Text = "Tên nhà:";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblInstruction.Location = new System.Drawing.Point(27, 86);
            this.lblInstruction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(326, 28);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Vui lòng nhập thông tin nhà mới:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnReset);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 430);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(667, 62);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(400, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 37);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 6;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(533, 12);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 37);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            // 
            // FormAddHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 492);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAddHouse";
            this.Text = "Thêm nhà mới";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelButtons.ResumeLayout(false);
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
