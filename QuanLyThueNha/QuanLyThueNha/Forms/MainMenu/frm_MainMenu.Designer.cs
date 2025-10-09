namespace QuanLyThueNha.Forms
{
    partial class frm_MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MainMenu));
            panel1 = new Panel();
            btn_user = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            labelPage = new Label();
            logo = new PictureBox();
            panel3 = new Panel();
            tssubmenu = new Panel();
            btnsubqQL = new Button();
            btnsubDK = new Button();
            btn_ngthue = new Button();
            btn_hopdong = new Button();
            btn_taichinh = new Button();
            btn_thanhtoan = new Button();
            btn_btsc = new Button();
            btn_bctk = new Button();
            btn_bm = new Button();
            panel2 = new Panel();
            btn_logout = new Button();
            btn_helper = new Button();
            btn_taisan = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            tssubmenu.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_user);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(labelPage);
            panel1.Controls.Add(logo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1016, 68);
            panel1.TabIndex = 0;
            // 
            // btn_user
            // 
            btn_user.Location = new Point(868, 17);
            btn_user.Name = "btn_user";
            btn_user.Size = new Size(94, 29);
            btn_user.TabIndex = 5;
            btn_user.Text = "User";
            btn_user.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(458, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(240, 27);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(719, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Location = new Point(223, 22);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(73, 20);
            labelPage.TabIndex = 2;
            labelPage.Text = "Trang chủ";
            // 
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(3, 0);
            logo.Name = "logo";
            logo.Size = new Size(205, 65);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 2;
            logo.TabStop = false;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(208, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(808, 508);
            panel3.TabIndex = 2;
            // 
            // tssubmenu
            // 
            tssubmenu.Controls.Add(btnsubqQL);
            tssubmenu.Controls.Add(btnsubDK);
            tssubmenu.Dock = DockStyle.Top;
            tssubmenu.Location = new Point(0, 41);
            tssubmenu.Name = "tssubmenu";
            tssubmenu.Size = new Size(208, 83);
            tssubmenu.TabIndex = 0;
            tssubmenu.Visible = false;
            // 
            // btnsubqQL
            // 
            btnsubqQL.Dock = DockStyle.Top;
            btnsubqQL.Location = new Point(0, 41);
            btnsubqQL.Name = "btnsubqQL";
            btnsubqQL.Size = new Size(208, 41);
            btnsubqQL.TabIndex = 4;
            btnsubqQL.Text = "Quản lý phòng";
            btnsubqQL.UseVisualStyleBackColor = true;
            btnsubqQL.Click += btnsubqQL_Click;
            // 
            // btnsubDK
            // 
            btnsubDK.Dock = DockStyle.Top;
            btnsubDK.Location = new Point(0, 0);
            btnsubDK.Name = "btnsubDK";
            btnsubDK.Size = new Size(208, 41);
            btnsubDK.TabIndex = 3;
            btnsubDK.Text = "Đăng ký tài sản";
            btnsubDK.UseVisualStyleBackColor = true;
            btnsubDK.Click += btnsubDK_Click;
            // 
            // btn_ngthue
            // 
            btn_ngthue.Dock = DockStyle.Top;
            btn_ngthue.Location = new Point(0, 124);
            btn_ngthue.Name = "btn_ngthue";
            btn_ngthue.Size = new Size(208, 41);
            btn_ngthue.TabIndex = 3;
            btn_ngthue.Text = "Quản lý người thuê";
            btn_ngthue.UseVisualStyleBackColor = true;
            btn_ngthue.Click += btn_ngthue_Click;
            // 
            // btn_hopdong
            // 
            btn_hopdong.Dock = DockStyle.Top;
            btn_hopdong.Location = new Point(0, 165);
            btn_hopdong.Name = "btn_hopdong";
            btn_hopdong.Size = new Size(208, 41);
            btn_hopdong.TabIndex = 4;
            btn_hopdong.Text = "Quản lý hợp đồng";
            btn_hopdong.UseVisualStyleBackColor = true;
            btn_hopdong.Click += btn_hopdong_Click;
            // 
            // btn_taichinh
            // 
            btn_taichinh.Dock = DockStyle.Top;
            btn_taichinh.Location = new Point(0, 206);
            btn_taichinh.Name = "btn_taichinh";
            btn_taichinh.Size = new Size(208, 41);
            btn_taichinh.TabIndex = 5;
            btn_taichinh.Text = "Quản lý tài chính";
            btn_taichinh.UseVisualStyleBackColor = true;
            // 
            // btn_thanhtoan
            // 
            btn_thanhtoan.Dock = DockStyle.Top;
            btn_thanhtoan.Location = new Point(0, 247);
            btn_thanhtoan.Name = "btn_thanhtoan";
            btn_thanhtoan.Size = new Size(208, 41);
            btn_thanhtoan.TabIndex = 6;
            btn_thanhtoan.Text = "Quản lý thanh toán";
            btn_thanhtoan.UseVisualStyleBackColor = true;
            // 
            // btn_btsc
            // 
            btn_btsc.Dock = DockStyle.Top;
            btn_btsc.Location = new Point(0, 288);
            btn_btsc.Name = "btn_btsc";
            btn_btsc.Size = new Size(208, 41);
            btn_btsc.TabIndex = 7;
            btn_btsc.Text = "Bảo trì và sự cố";
            btn_btsc.UseVisualStyleBackColor = true;
            // 
            // btn_bctk
            // 
            btn_bctk.Dock = DockStyle.Top;
            btn_bctk.Location = new Point(0, 329);
            btn_bctk.Name = "btn_bctk";
            btn_bctk.Size = new Size(208, 41);
            btn_bctk.TabIndex = 8;
            btn_bctk.Text = "Báo cáo và thống kê";
            btn_bctk.UseVisualStyleBackColor = true;
            // 
            // btn_bm
            // 
            btn_bm.Dock = DockStyle.Top;
            btn_bm.Location = new Point(0, 370);
            btn_bm.Name = "btn_bm";
            btn_bm.Size = new Size(208, 41);
            btn_bm.TabIndex = 9;
            btn_bm.Text = "Bảo mật";
            btn_bm.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(btn_logout);
            panel2.Controls.Add(btn_helper);
            panel2.Controls.Add(btn_bm);
            panel2.Controls.Add(btn_bctk);
            panel2.Controls.Add(btn_btsc);
            panel2.Controls.Add(btn_thanhtoan);
            panel2.Controls.Add(btn_taichinh);
            panel2.Controls.Add(btn_hopdong);
            panel2.Controls.Add(btn_ngthue);
            panel2.Controls.Add(tssubmenu);
            panel2.Controls.Add(btn_taisan);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 508);
            panel2.TabIndex = 1;
            // 
            // btn_logout
            // 
            btn_logout.Dock = DockStyle.Top;
            btn_logout.Location = new Point(0, 452);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(208, 41);
            btn_logout.TabIndex = 11;
            btn_logout.Text = "Đăng xuất";
            btn_logout.UseVisualStyleBackColor = true;
            // 
            // btn_helper
            // 
            btn_helper.Dock = DockStyle.Top;
            btn_helper.Location = new Point(0, 411);
            btn_helper.Name = "btn_helper";
            btn_helper.Size = new Size(208, 41);
            btn_helper.TabIndex = 10;
            btn_helper.Text = "Trợ giúp";
            btn_helper.UseVisualStyleBackColor = true;
            // 
            // btn_taisan
            // 
            btn_taisan.Dock = DockStyle.Top;
            btn_taisan.Location = new Point(0, 0);
            btn_taisan.Name = "btn_taisan";
            btn_taisan.Size = new Size(208, 41);
            btn_taisan.TabIndex = 2;
            btn_taisan.Text = "Quản lý tài sản";
            btn_taisan.UseVisualStyleBackColor = true;
            btn_taisan.Click += btn_taisan_Click;
            // 
            // frm_MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1016, 576);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frm_MainMenu";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            tssubmenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox logo;
        private Panel panel3;
        private TextBox txtSearch;
        private Button btn_search;
        private Label labelPage;
        private Button btn_user;
        private Button btnSearch;
        private Panel tssubmenu;
        private Button btnsubqQL;
        private Button btnsubDK;
        private Button btn_ngthue;
        private Button btn_hopdong;
        private Button btn_taichinh;
        private Button btn_thanhtoan;
        private Button btn_btsc;
        private Button btn_bctk;
        private Button btn_bm;
        private Panel panel2;
        private Button btn_taisan;
        private Button btn_helper;
        private Button btn_logout;
    }
}