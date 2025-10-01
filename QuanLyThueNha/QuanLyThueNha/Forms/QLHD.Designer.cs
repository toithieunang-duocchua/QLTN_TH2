namespace QuanLyThueNha.Forms
{
    partial class QLHD
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
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            soHD = new DataGridViewTextBoxColumn();
            ngaybd = new DataGridViewTextBoxColumn();
            ngaykt = new DataGridViewTextBoxColumn();
            tiencoc = new DataGridViewTextBoxColumn();
            trangthai = new DataGridViewTextBoxColumn();
            ngaytao = new DataGridViewTextBoxColumn();
            ngaycn = new DataGridViewTextBoxColumn();
            ghichu = new DataGridViewTextBoxColumn();
            pdf = new DataGridViewButtonColumn();
            btn_xoa = new Button();
            btn_chinhsua = new Button();
            btn_them = new Button();
            btn_sample = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_sample);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(btn_xoa);
            groupBox1.Controls.Add(btn_chinhsua);
            groupBox1.Controls.Add(btn_them);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tất cả hợp đồng";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, soHD, ngaybd, ngaykt, tiencoc, trangthai, ngaytao, ngaycn, ghichu, pdf });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(794, 386);
            dataGridView1.TabIndex = 3;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // soHD
            // 
            soHD.HeaderText = "Số hợp đồng";
            soHD.MinimumWidth = 6;
            soHD.Name = "soHD";
            soHD.Width = 125;
            // 
            // ngaybd
            // 
            ngaybd.HeaderText = "Ngày bắt đầu";
            ngaybd.MinimumWidth = 6;
            ngaybd.Name = "ngaybd";
            ngaybd.Width = 125;
            // 
            // ngaykt
            // 
            ngaykt.HeaderText = "Ngày kết thúc";
            ngaykt.MinimumWidth = 6;
            ngaykt.Name = "ngaykt";
            ngaykt.Width = 125;
            // 
            // tiencoc
            // 
            tiencoc.HeaderText = "Tiền cọc";
            tiencoc.MinimumWidth = 6;
            tiencoc.Name = "tiencoc";
            tiencoc.Width = 125;
            // 
            // trangthai
            // 
            trangthai.HeaderText = "Trạng thái";
            trangthai.MinimumWidth = 6;
            trangthai.Name = "trangthai";
            trangthai.Width = 125;
            // 
            // ngaytao
            // 
            ngaytao.HeaderText = "Ngày tạo";
            ngaytao.MinimumWidth = 6;
            ngaytao.Name = "ngaytao";
            ngaytao.Width = 125;
            // 
            // ngaycn
            // 
            ngaycn.HeaderText = "Ngày cập nhật";
            ngaycn.MinimumWidth = 6;
            ngaycn.Name = "ngaycn";
            ngaycn.Width = 125;
            // 
            // ghichu
            // 
            ghichu.HeaderText = "Ghi chú";
            ghichu.MinimumWidth = 6;
            ghichu.Name = "ghichu";
            ghichu.Width = 125;
            // 
            // pdf
            // 
            pdf.HeaderText = "Word/PDF";
            pdf.MinimumWidth = 6;
            pdf.Name = "pdf";
            pdf.Width = 125;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(648, 26);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 2;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_chinhsua
            // 
            btn_chinhsua.Location = new Point(539, 26);
            btn_chinhsua.Name = "btn_chinhsua";
            btn_chinhsua.Size = new Size(94, 29);
            btn_chinhsua.TabIndex = 1;
            btn_chinhsua.Text = "Chỉnh Sửa";
            btn_chinhsua.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(426, 26);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 0;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            btn_them.Click += btn_them_click;
            // 
            // btn_sample
            // 
            btn_sample.Location = new Point(307, 26);
            btn_sample.Name = "btn_sample";
            btn_sample.Size = new Size(94, 29);
            btn_sample.TabIndex = 4;
            btn_sample.Text = "Thêm mẫu";
            btn_sample.UseVisualStyleBackColor = true;
            // 
            // QLHD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "QLHD";
            Text = "Form1";
            Load += QLHD_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_xoa;
        private Button btn_chinhsua;
        private Button btn_them;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn soHD;
        private DataGridViewTextBoxColumn ngaybd;
        private DataGridViewTextBoxColumn ngaykt;
        private DataGridViewTextBoxColumn tiencoc;
        private DataGridViewTextBoxColumn trangthai;
        private DataGridViewTextBoxColumn ngaytao;
        private DataGridViewTextBoxColumn ngaycn;
        private DataGridViewTextBoxColumn ghichu;
        private DataGridViewButtonColumn pdf;
        private Button btn_sample;
    }
}