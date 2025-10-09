namespace QuanLyThueNha.Forms
{
    partial class QLNT
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
            btn_chinhsua = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            label7 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            sdt = new DataGridViewTextBoxColumn();
            CCCD = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            ngaysinh = new DataGridViewTextBoxColumn();
            gioitinh = new DataGridViewTextBoxColumn();
            dcTT = new DataGridViewTextBoxColumn();
            ngaytao = new DataGridViewTextBoxColumn();
            ngaycapnhat = new DataGridViewTextBoxColumn();
            ghichu = new DataGridViewTextBoxColumn();
            hopdong = new DataGridViewLinkColumn();
            btn_ = new Button();
            btn_xoa = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_xoa);
            groupBox1.Controls.Add(btn_);
            groupBox1.Controls.Add(btn_chinhsua);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 212);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin người thuê";
            // 
            // btn_chinhsua
            // 
            btn_chinhsua.Location = new Point(563, 158);
            btn_chinhsua.Name = "btn_chinhsua";
            btn_chinhsua.Size = new Size(94, 29);
            btn_chinhsua.TabIndex = 13;
            btn_chinhsua.Text = "Chỉnh sửa";
            btn_chinhsua.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(528, 107);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(250, 27);
            textBox5.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(127, 107);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(245, 27);
            textBox4.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(396, 110);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 10;
            label7.Text = "Số phòng: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 110);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 8;
            label5.Text = "Tòa nhà:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(528, 67);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(127, 66);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(245, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(528, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(245, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 27);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(396, 71);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày thuê:";
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
            groupBox2.Location = new Point(0, 212);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(843, 277);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách người thuê";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, name, sdt, CCCD, email, ngaysinh, gioitinh, dcTT, ngaytao, ngaycapnhat, ghichu, hopdong });
            dataGridView1.Location = new Point(21, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(767, 245);
            dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // name
            // 
            name.HeaderText = "Họ tên";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // sdt
            // 
            sdt.HeaderText = "SĐT";
            sdt.MinimumWidth = 6;
            sdt.Name = "sdt";
            sdt.Width = 125;
            // 
            // CCCD
            // 
            CCCD.HeaderText = "CCCD";
            CCCD.MinimumWidth = 6;
            CCCD.Name = "CCCD";
            CCCD.Width = 125;
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Width = 125;
            // 
            // ngaysinh
            // 
            ngaysinh.HeaderText = "Ngày sinh";
            ngaysinh.MinimumWidth = 6;
            ngaysinh.Name = "ngaysinh";
            ngaysinh.Width = 125;
            // 
            // gioitinh
            // 
            gioitinh.HeaderText = "Giới tính";
            gioitinh.MinimumWidth = 6;
            gioitinh.Name = "gioitinh";
            gioitinh.Width = 125;
            // 
            // dcTT
            // 
            dcTT.HeaderText = "Địa chỉ thường trú";
            dcTT.MinimumWidth = 6;
            dcTT.Name = "dcTT";
            dcTT.Width = 125;
            // 
            // ngaytao
            // 
            ngaytao.HeaderText = "Ngày tạo";
            ngaytao.MinimumWidth = 6;
            ngaytao.Name = "ngaytao";
            ngaytao.Width = 125;
            // 
            // ngaycapnhat
            // 
            ngaycapnhat.HeaderText = "Ngày cập nhật";
            ngaycapnhat.MinimumWidth = 6;
            ngaycapnhat.Name = "ngaycapnhat";
            ngaycapnhat.Width = 125;
            // 
            // ghichu
            // 
            ghichu.HeaderText = "Ghi chú";
            ghichu.MinimumWidth = 6;
            ghichu.Name = "ghichu";
            ghichu.Width = 125;
            // 
            // hopdong
            // 
            hopdong.HeaderText = "Hợp đồng";
            hopdong.MinimumWidth = 6;
            hopdong.Name = "hopdong";
            hopdong.Width = 125;
            // 
            // btn_
            // 
            btn_.Location = new Point(435, 158);
            btn_.Name = "btn_";
            btn_.Size = new Size(94, 29);
            btn_.TabIndex = 14;
            btn_.Text = "Thêm";
            btn_.UseVisualStyleBackColor = true;
            btn_.Click += btn__Click;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(684, 158);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 15;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // QLNT
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(843, 522);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "QLNT";
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
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label7;
        private Label label5;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button btn_chinhsua;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn sdt;
        private DataGridViewTextBoxColumn CCCD;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn ngaysinh;
        private DataGridViewTextBoxColumn gioitinh;
        private DataGridViewTextBoxColumn dcTT;
        private DataGridViewTextBoxColumn ngaytao;
        private DataGridViewTextBoxColumn ngaycapnhat;
        private DataGridViewTextBoxColumn ghichu;
        private DataGridViewLinkColumn hopdong;
        private Button btn_;
        private Button btn_xoa;
    }
}