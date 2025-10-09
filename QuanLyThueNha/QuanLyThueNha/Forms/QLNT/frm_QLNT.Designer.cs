namespace QuanLyThueNha.Forms
{
    partial class frm_QLNT
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
            groupBox1 = new GroupBox();
            diachi = new TextBox();
            label9 = new Label();
            ngaythue = new DateTimePicker();
            label8 = new Label();
            gtinh = new ComboBox();
            label6 = new Label();
            mphong = new ComboBox();
            toanha = new ComboBox();
            xoa = new Button();
            them = new Button();
            chinhsua = new Button();
            label7 = new Label();
            label5 = new Label();
            ngaysinh = new DateTimePicker();
            sodienthoai = new TextBox();
            cangcuoc = new TextBox();
            hoten = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(diachi);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(ngaythue);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(gtinh);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(mphong);
            groupBox1.Controls.Add(toanha);
            groupBox1.Controls.Add(xoa);
            groupBox1.Controls.Add(them);
            groupBox1.Controls.Add(chinhsua);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(ngaysinh);
            groupBox1.Controls.Add(sodienthoai);
            groupBox1.Controls.Add(cangcuoc);
            groupBox1.Controls.Add(hoten);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 241);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin người thuê";
            // 
            // diachi
            // 
            diachi.Location = new Point(129, 167);
            diachi.Name = "diachi";
            diachi.Size = new Size(245, 27);
            diachi.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 170);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 22;
            label9.Text = "Địa chỉ:";
            // 
            // ngaythue
            // 
            ngaythue.Location = new Point(529, 136);
            ngaythue.Name = "ngaythue";
            ngaythue.Size = new Size(245, 27);
            ngaythue.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(396, 141);
            label8.Name = "label8";
            label8.Size = new Size(80, 20);
            label8.TabIndex = 20;
            label8.Text = "Ngày thuê:";
            // 
            // gtinh
            // 
            gtinh.FormattingEnabled = true;
            gtinh.Location = new Point(129, 133);
            gtinh.Name = "gtinh";
            gtinh.Size = new Size(243, 28);
            gtinh.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 136);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 18;
            label6.Text = "Giới tính:";
            // 
            // mphong
            // 
            mphong.FormattingEnabled = true;
            mphong.Location = new Point(529, 99);
            mphong.Name = "mphong";
            mphong.Size = new Size(245, 28);
            mphong.TabIndex = 17;
            // 
            // toanha
            // 
            toanha.FormattingEnabled = true;
            toanha.Location = new Point(129, 99);
            toanha.Name = "toanha";
            toanha.Size = new Size(243, 28);
            toanha.TabIndex = 16;
            toanha.SelectedIndexChanged += toanha_SelectedIndexChanged;
            // 
            // xoa
            // 
            xoa.Location = new Point(684, 196);
            xoa.Name = "xoa";
            xoa.Size = new Size(94, 29);
            xoa.TabIndex = 15;
            xoa.Text = "Xóa";
            xoa.UseVisualStyleBackColor = true;
            xoa.Click += xoa_Click;
            // 
            // them
            // 
            them.Location = new Point(435, 196);
            them.Name = "them";
            them.Size = new Size(94, 29);
            them.TabIndex = 14;
            them.Text = "Thêm";
            them.UseVisualStyleBackColor = true;
            them.Click += them_Click;
            // 
            // chinhsua
            // 
            chinhsua.Location = new Point(563, 196);
            chinhsua.Name = "chinhsua";
            chinhsua.Size = new Size(94, 29);
            chinhsua.TabIndex = 13;
            chinhsua.Text = "Chỉnh sửa";
            chinhsua.UseVisualStyleBackColor = true;
            chinhsua.Click += chinhsua_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(396, 107);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 10;
            label7.Text = "Mã phòng: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 102);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 8;
            label5.Text = "Tòa nhà:";
            // 
            // ngaysinh
            // 
            ngaysinh.Location = new Point(529, 66);
            ngaysinh.Name = "ngaysinh";
            ngaysinh.Size = new Size(245, 27);
            ngaysinh.TabIndex = 7;
            // 
            // sodienthoai
            // 
            sodienthoai.Location = new Point(129, 66);
            sodienthoai.Name = "sodienthoai";
            sodienthoai.Size = new Size(245, 27);
            sodienthoai.TabIndex = 6;
            // 
            // cangcuoc
            // 
            cangcuoc.Location = new Point(529, 33);
            cangcuoc.Name = "cangcuoc";
            cangcuoc.Size = new Size(245, 27);
            cangcuoc.TabIndex = 5;
            // 
            // hoten
            // 
            hoten.Location = new Point(129, 33);
            hoten.Name = "hoten";
            hoten.Size = new Size(245, 27);
            hoten.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(396, 71);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(396, 36);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 2;
            label3.Text = "CMND/CCCD:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 71);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 241);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(843, 277);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách người thuê";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(767, 245);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // frm_QLNT
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(843, 522);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frm_QLNT";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
        //test


        #endregion

        private GroupBox groupBox1;
        private DateTimePicker ngaysinh;
        private TextBox sodienthoai;
        private TextBox cangcuoc;
        private TextBox hoten;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox comboBox2;
        private Label label7;
        private Label label5;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button chinhsua;
        private Button them;
        private Button xoa;
        private ComboBox maphong;
        private ComboBox toanha;
        private ComboBox mphong;
        private ComboBox gtinh;
        private Label label6;
        private DateTimePicker ngaythue;
        private Label label8;
        private TextBox diachi;
        private Label label9;
    }
}