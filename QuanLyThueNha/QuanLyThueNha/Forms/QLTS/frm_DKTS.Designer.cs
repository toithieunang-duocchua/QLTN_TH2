namespace QuanLyThueNha.Forms
{
    partial class frm_DKTS
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
            label1 = new Label();
            diachi = new Label();
            soluongphong = new Label();
            ghichu = new Label();
            sotang = new Label();
            groupBox1 = new GroupBox();
            btn_xacnhan = new Button();
            Note = new RichTextBox();
            textTN = new TextBox();
            labelTN = new Label();
            textslp = new TextBox();
            textst = new TextBox();
            textdc = new TextBox();
            label7 = new Label();
            scrollPanel = new Panel();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            
            groupBox1.SuspendLayout();
            scrollPanel.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // diachi
            // 
            diachi.AutoSize = true;
            diachi.Location = new Point(406, 41);
            diachi.Name = "diachi";
            diachi.Size = new Size(58, 20);
            diachi.TabIndex = 1;
            diachi.Text = "Địa chỉ:";
            // 
            // soluongphong
            // 
            soluongphong.AutoSize = true;
            soluongphong.Location = new Point(406, 78);
            soluongphong.Name = "soluongphong";
            soluongphong.Size = new Size(123, 20);
            soluongphong.TabIndex = 2;
            soluongphong.Text = "Số lượng phòng: ";
            // 
            // ghichu
            // 
            ghichu.AutoSize = true;
            ghichu.Location = new Point(40, 110);
            ghichu.Name = "ghichu";
            ghichu.Size = new Size(65, 20);
            ghichu.TabIndex = 3;
            ghichu.Text = "Ghi chú: ";
            // 
            // sotang
            // 
            sotang.AutoSize = true;
            sotang.Location = new Point(40, 74);
            sotang.Name = "sotang";
            sotang.Size = new Size(63, 20);
            sotang.TabIndex = 4;
            sotang.Text = "Số tầng:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_xacnhan);
            groupBox1.Controls.Add(Note);
            groupBox1.Controls.Add(textTN);
            groupBox1.Controls.Add(labelTN);
            groupBox1.Controls.Add(textslp);
            groupBox1.Controls.Add(textst);
            groupBox1.Controls.Add(ghichu);
            groupBox1.Controls.Add(diachi);
            groupBox1.Controls.Add(textdc);
            groupBox1.Controls.Add(sotang);
            groupBox1.Controls.Add(soluongphong);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(788, 294);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin căn nhà";
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.Location = new Point(629, 259);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(94, 29);
            btn_xacnhan.TabIndex = 11;
            btn_xacnhan.Text = "Xác nhận";
            btn_xacnhan.UseVisualStyleBackColor = true;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // Note
            // 
            Note.Location = new Point(65, 133);
            Note.Name = "Note";
            Note.Size = new Size(658, 112);
            Note.TabIndex = 8;
            Note.Text = "";
            // 
            // textTN
            // 
            textTN.Location = new Point(119, 38);
            textTN.Name = "textTN";
            textTN.Size = new Size(233, 27);
            textTN.TabIndex = 10;
            // 
            // labelTN
            // 
            labelTN.AutoSize = true;
            labelTN.Location = new Point(39, 41);
            labelTN.Name = "labelTN";
            labelTN.Size = new Size(64, 20);
            labelTN.TabIndex = 9;
            labelTN.Text = "Tòa nhà:";
            // 
            // textslp
            // 
            textslp.Location = new Point(535, 74);
            textslp.Name = "textslp";
            textslp.Size = new Size(188, 27);
            textslp.TabIndex = 8;
            textslp.KeyPress += textslp_KeyPress;
            // 
            // textst
            // 
            textst.Location = new Point(119, 71);
            textst.Name = "textst";
            textst.Size = new Size(233, 27);
            textst.TabIndex = 7;
            textst.KeyPress += textst_KeyPress;
            // 
            // textdc
            // 
            textdc.Location = new Point(474, 34);
            textdc.Name = "textdc";
            textdc.Size = new Size(249, 27);
            textdc.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(339, 215);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 7;
            // 
            // scrollPanel
            // 
            scrollPanel.AutoScroll = true;
            scrollPanel.Controls.Add(groupBox2);
            scrollPanel.Controls.Add(groupBox1);
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.Location = new Point(0, 0);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(788, 501);
            scrollPanel.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 294);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(788, 207);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách tòa nhà";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(782, 181);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // 
            // frm_DKTS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(788, 501);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(scrollPanel);
            Name = "frm_DKTS";
            Text = "Đăng ký thông tin tài sản";
            this.Load += new System.EventHandler(this.frm_DKTS_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            scrollPanel.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label diachi;
        private Label soluongphong;
        private Label ghichu;
        private Label label5;
        private GroupBox groupBox1;
        private TextBox textdc;
        private Label label7;
        private TextBox textslp;
        private TextBox textst;
        private Label sotang;
        private TextBox textTN;
        private Label labelTN;
        private RichTextBox Note;
        private Button btn_xacnhan;
        private Panel scrollPanel;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;

    }
}