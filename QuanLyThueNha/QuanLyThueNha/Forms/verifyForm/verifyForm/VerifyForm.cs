using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace verifyForm
{
    public partial class VerifyForm : Form
    {
        private bool isCodePlaceholder = true;
        private string userEmail;

        public VerifyForm(string email)
        {
            InitializeComponent();
            userEmail = email;
            SetupForm();
        }

        private void SetupForm()
        {
            // Thiết lập form
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            
            // Thiết lập panel với độ trong suốt
            verifyPanel.BackColor = Color.FromArgb(120, 50, 50, 50);
            verifyPanel.Size = new Size(400, 450);
            verifyPanel.Location = new Point((this.Width - verifyPanel.Width) / 2, (this.Height - verifyPanel.Height) / 2);
            
            // Tạo background gradient
            CreateBackground();
            
            // Thiết lập textbox
            SetupTextBox(codeTextBox, "Mã xác minh");
            
            // Thiết lập button
            verifyButton.BackColor = Color.FromArgb(220, 53, 69);
            verifyButton.FlatStyle = FlatStyle.Flat;
            verifyButton.FlatAppearance.BorderSize = 0;
            verifyButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            verifyButton.ForeColor = Color.White;
            
            // Thiết lập labels
            SetupLabel(titleLabel, "Xác minh", Color.White, 18, FontStyle.Bold);
            SetupLabel(instructionLabel1, "Chúng tôi đã gửi mã xác nhận qua email của bạn.", Color.White, 10);
            SetupLabel(instructionLabel2, "Vui lòng kiểm tra và nhập vào phần xác minh bên dưới.", Color.White, 10);
            SetupLabel(instructionLabel3, "Lưu ý: Mã chỉ có hiệu lực trong vòng 5 phút.", Color.Red, 10);
            SetupButton(resendButton, "Gửi lại mã xác minh", Color.LightGray, 10);
            SetupButton(backButton, "Quay lại", Color.LightGray, 10);
            
            // Event handlers
            verifyButton.Click += VerifyButton_Click;
            resendButton.Click += ResendButton_Click;
            backButton.Click += BackButton_Click;
        }

        private void SetupTextBox(TextBox textBox, string placeholder)
        {
            textBox.BackColor = Color.FromArgb(60, 60, 60);
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Microsoft Sans Serif", 12);
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;
            textBox.Multiline = true;
            textBox.Size = new System.Drawing.Size(340, 30);
        }

        private void SetupLabel(Label label, string text, Color color, int fontSize, FontStyle style = FontStyle.Regular)
        {
            label.Text = text;
            label.ForeColor = color;
            label.Font = new Font("Microsoft Sans Serif", fontSize, style);
            label.AutoSize = true;
        }

        private void SetupButton(Button button, string text, Color color, int fontSize)
        {
            button.Text = text;
            button.ForeColor = color;
            button.Font = new Font("Microsoft Sans Serif", fontSize);
            button.BackColor = Color.FromArgb(60, 60, 60);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void CreateBackground()
        {
            // Tạo background gradient đẹp
            Bitmap background = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(background))
            {
                // Gradient từ đen đến xanh đậm
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0), 
                    new Point(0, this.Height),
                    Color.FromArgb(20, 20, 40),
                    Color.FromArgb(5, 5, 15)))
                {
                    g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                }
                
                // Thêm các ngôi sao
                Random rand = new Random();
                for (int i = 0; i < 100; i++)
                {
                    int x = rand.Next(0, this.Width);
                    int y = rand.Next(0, this.Height);
                    int size = rand.Next(1, 3);
                    
                    using (SolidBrush starBrush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                    {
                        g.FillEllipse(starBrush, x, y, size, size);
                    }
                }
                
                // Thêm dải Milky Way
                using (LinearGradientBrush milkyWayBrush = new LinearGradientBrush(
                    new Point(0, this.Height / 3),
                    new Point(this.Width, this.Height / 3),
                    Color.FromArgb(50, 100, 80, 60),
                    Color.FromArgb(30, 120, 100, 80)))
                {
                    g.FillRectangle(milkyWayBrush, 0, this.Height / 3, this.Width, this.Height / 4);
                }
            }
            
            this.BackgroundImage = background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void codeTextBox_Enter(object sender, EventArgs e)
        {
            if (isCodePlaceholder)
            {
                codeTextBox.Text = "";
                codeTextBox.ForeColor = Color.White;
                isCodePlaceholder = false;
            }
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeTextBox.Text))
            {
                codeTextBox.Text = "Mã xác minh";
                codeTextBox.ForeColor = Color.Gray;
                isCodePlaceholder = true;
            }
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            string code = isCodePlaceholder ? "" : codeTextBox.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Vui lòng nhập mã xác minh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code.Length != 6)
            {
                MessageBox.Show("Mã xác minh phải có 6 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã xác minh (ví dụ: mã đúng là 123456)
            if (code == "123456")
            {
                MessageBox.Show("Xác minh thành công!\nBạn có thể đặt lại mật khẩu mới.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Mở form đặt lại mật khẩu hoặc quay về login
                loginForm.Form1 loginForm = new loginForm.Form1();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác minh không đúng!\nVui lòng kiểm tra lại.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResendButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Đã gửi lại mã xác minh đến email: {userEmail}\nMã mới: 123456", 
                "Gửi lại mã", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            forgotPasswordForm.ForgotPasswordForm forgotForm = new forgotPasswordForm.ForgotPasswordForm();
            forgotForm.Show();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Vẽ border cho textbox
            using (Pen pen = new Pen(Color.FromArgb(80, 80, 80), 1))
            {
                e.Graphics.DrawRectangle(pen, codeTextBox.Left - 1, codeTextBox.Top - 1, codeTextBox.Width + 1, codeTextBox.Height + 1);
            }
        }
    }
}
