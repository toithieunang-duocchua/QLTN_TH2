using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLTN.Forms
{
    partial class FormHouseManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Guna2Button btnAddHouse;
        private Label lblSubtitle;
        private Guna2Panel panelContent;
        private Guna2Panel panelHouseList;
        private FlowLayoutPanel flowLayoutHouses;
        private Label lblEmptyState;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddHouse = new Guna.UI2.WinForms.Guna2Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.panelHouseList = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutHouses = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmptyState = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelHouseList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(128, 90, 213);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnAddHouse);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 110);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(36, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(222, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý nhà";
            // 
            // btnAddHouse
            // 
            this.btnAddHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHouse.BorderRadius = 10;
            this.btnAddHouse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddHouse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddHouse.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnAddHouse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnAddHouse.FillColor = System.Drawing.Color.FromArgb(180, 150, 255);
            this.btnAddHouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddHouse.ForeColor = System.Drawing.Color.White;
            this.btnAddHouse.Location = new System.Drawing.Point(829, 30);
            this.btnAddHouse.Name = "btnAddHouse";
            this.btnAddHouse.Size = new System.Drawing.Size(140, 50);
            this.btnAddHouse.TabIndex = 2;
            this.btnAddHouse.Text = "+ Thêm nhà";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(40, 74);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(256, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Quản lý danh sách căn nhà hiện có";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.panelHouseList);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 110);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1000, 540);
            this.panelContent.TabIndex = 1;
            // 
            // panelHouseList
            // 
            this.panelHouseList.BackColor = System.Drawing.Color.White;
            this.panelHouseList.BorderColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.panelHouseList.BorderThickness = 1;
            this.panelHouseList.Controls.Add(this.flowLayoutHouses);
            this.panelHouseList.Controls.Add(this.lblEmptyState);
            this.panelHouseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHouseList.Location = new System.Drawing.Point(30, 30);
            this.panelHouseList.Name = "panelHouseList";
            this.panelHouseList.Padding = new System.Windows.Forms.Padding(10);
            this.panelHouseList.ShadowDecoration.Parent = this.panelHouseList;
            this.panelHouseList.Size = new System.Drawing.Size(940, 480);
            this.panelHouseList.TabIndex = 0;
            // 
            // flowLayoutHouses
            // 
            this.flowLayoutHouses.AutoScroll = true;
            this.flowLayoutHouses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutHouses.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutHouses.Name = "flowLayoutHouses";
            this.flowLayoutHouses.Size = new System.Drawing.Size(920, 460);
            this.flowLayoutHouses.TabIndex = 0;
            // 
            // lblEmptyState
            // 
            this.lblEmptyState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblEmptyState.Location = new System.Drawing.Point(10, 10);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(920, 460);
            this.lblEmptyState.TabIndex = 1;
            this.lblEmptyState.Text = "Chưa có căn nhà nào.";
            this.lblEmptyState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyState.Visible = false;
            // 
            // FormHouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(840, 560);
            this.Name = "FormHouseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelHouseList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
