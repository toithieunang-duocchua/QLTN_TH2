namespace QuanLyThueNha.Forms
{
    partial class frm_QLP
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
            sophong = new TextBox();
            label6 = new Label();
            label5 = new Label();
            ghichu = new RichTextBox();
            sotang = new TextBox();
            diachi = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            toanha = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            loaiphong = new ComboBox();
            label14 = new Label();
            txtNote = new RichTextBox();
            luu = new Button();
            giathue = new TextBox();
            nguoio = new TextBox();
            dientich = new TextBox();
            maphong = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            dataGridView2 = new DataGridView();
            btn_In = new Button();
            btn_them = new Button();
            dataGridView1 = new DataGridView();
            trangthai = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(sophong);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(ghichu);
            groupBox1.Controls.Add(sotang);
            groupBox1.Controls.Add(diachi);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(toanha);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tòa nhà";
            // 
            // sophong
            // 
            sophong.Location = new Point(150, 119);
            sophong.Name = "sophong";
            sophong.Size = new Size(188, 27);
            sophong.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 122);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 9;
            label6.Text = "Số lượng phòng:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 63);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 8;
            label5.Text = "Ghi chú: ";
            // 
            // ghichu
            // 
            ghichu.Location = new Point(369, 86);
            ghichu.Name = "ghichu";
            ghichu.Size = new Size(391, 60);
            ghichu.TabIndex = 7;
            ghichu.Text = "";
            // 
            // sotang
            // 
            sotang.Location = new Point(90, 75);
            sotang.Name = "sotang";
            sotang.Size = new Size(248, 27);
            sotang.TabIndex = 6;
            // 
            // diachi
            // 
            diachi.Location = new Point(443, 22);
            diachi.Name = "diachi";
            diachi.Size = new Size(298, 27);
            diachi.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 78);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 4;
            label4.Text = "Số tầng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(341, 33);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(369, 29);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 2;
            label2.Text = "Địa chỉ:";
            // 
            // toanha
            // 
            toanha.DisplayMember = "tenTN";
            toanha.FormattingEnabled = true;
            toanha.Location = new Point(90, 30);
            toanha.Name = "toanha";
            toanha.Size = new Size(245, 28);
            toanha.TabIndex = 1;
            toanha.ValueMember = "id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 33);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Tòa nhà: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(trangthai);
            groupBox2.Controls.Add(loaiphong);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtNote);
            groupBox2.Controls.Add(luu);
            groupBox2.Controls.Add(giathue);
            groupBox2.Controls.Add(nguoio);
            groupBox2.Controls.Add(dientich);
            groupBox2.Controls.Add(maphong);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 157);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(800, 257);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin phòng";
            groupBox2.Visible = false;
            // 
            // loaiphong
            // 
            loaiphong.DisplayMember = "loaiphong";
            loaiphong.FormattingEnabled = true;
            loaiphong.Location = new Point(611, 33);
            loaiphong.Name = "loaiphong";
            loaiphong.Size = new Size(149, 28);
            loaiphong.TabIndex = 11;
            loaiphong.ValueMember = "id";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(518, 40);
            label14.Name = "label14";
            label14.Size = new Size(87, 20);
            label14.TabIndex = 16;
            label14.Text = "Loại phòng:";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(16, 152);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(772, 64);
            txtNote.TabIndex = 11;
            txtNote.Text = "";
            // 
            // luu
            // 
            luu.Location = new Point(647, 222);
            luu.Name = "luu";
            luu.Size = new Size(94, 29);
            luu.TabIndex = 3;
            luu.Text = "Lưu";
            luu.UseVisualStyleBackColor = true;
            luu.Click += luu_Click;
            // 
            // giathue
            // 
            giathue.Location = new Point(341, 70);
            giathue.Name = "giathue";
            giathue.Size = new Size(153, 27);
            giathue.TabIndex = 14;
            // 
            // nguoio
            // 
            nguoio.Location = new Point(107, 70);
            nguoio.Name = "nguoio";
            nguoio.Size = new Size(141, 27);
            nguoio.TabIndex = 13;
            // 
            // dientich
            // 
            dientich.Location = new Point(341, 37);
            dientich.Name = "dientich";
            dientich.Size = new Size(103, 27);
            dientich.TabIndex = 12;
            // 
            // maphong
            // 
            maphong.Location = new Point(98, 33);
            maphong.Name = "maphong";
            maphong.Size = new Size(150, 27);
            maphong.TabIndex = 11;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(518, 77);
            label13.Name = "label13";
            label13.Size = new Size(82, 20);
            label13.TabIndex = 6;
            label13.Text = "Trạng thái: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 77);
            label12.Name = "label12";
            label12.Size = new Size(85, 20);
            label12.TabIndex = 5;
            label12.Text = "Số người ở:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 113);
            label11.Name = "label11";
            label11.Size = new Size(61, 20);
            label11.TabIndex = 4;
            label11.Text = "Ghi chú:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(267, 77);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 3;
            label10.Text = "Giá thuê: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(267, 44);
            label9.Name = "label9";
            label9.Size = new Size(71, 20);
            label9.TabIndex = 2;
            label9.Text = "Diện tích:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(458, 40);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 1;
            label8.Text = "/m3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 40);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 0;
            label7.Text = "Mã phòng:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView2);
            groupBox3.Controls.Add(btn_In);
            groupBox3.Controls.Add(btn_them);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 414);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(800, 317);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách phòng";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(16, 53);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(772, 242);
            dataGridView2.TabIndex = 18;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // btn_In
            // 
            btn_In.Location = new Point(647, 18);
            btn_In.Name = "btn_In";
            btn_In.Size = new Size(94, 29);
            btn_In.TabIndex = 16;
            btn_In.Text = "In";
            btn_In.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(518, 18);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 17;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            btn_them.Click += btn_them_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(794, 261);
            dataGridView1.TabIndex = 0;
            // 
            // trangthai
            // 
            trangthai.DisplayMember = "loaiphong";
            trangthai.FormattingEnabled = true;
            trangthai.Location = new Point(611, 77);
            trangthai.Name = "trangthai";
            trangthai.Size = new Size(149, 28);
            trangthai.TabIndex = 17;
            trangthai.ValueMember = "id";
            // 
            // frm_QLP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 833);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frm_QLP";
            Text = "Quản lý danh sách phòng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox sotang;
        private TextBox diachi;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox toanha;
        private Label label5;
        private RichTextBox ghichu;
        private TextBox sophong;
        private Label label6;
        private GroupBox groupBox2;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox dientich;
        private TextBox maphong;
        private Label label13;
        private Label label12;
        private TextBox giathue;
        private TextBox nguoio;
        private Button luu;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private Button btn_In;
        private Button btn_them;
        private RichTextBox txtNote;
        private DataGridView dataGridView2;
        private Label label14;
        private TextBox textBox1;
        private ComboBox loaiphong;
        private ComboBox trangthai;
    }
}