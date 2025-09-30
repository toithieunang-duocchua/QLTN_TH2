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

namespace loginForm
{
    public partial class ForgotPasswordForm : Form
    {
        private bool isEmailPlaceholder = true;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Thiết lập form
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            
            // Thiết lập panel với độ trong suốt
            forgotPanel.BackColor = Color.FromArgb(120, 50, 50, 50);
            forgotPanel.Size = new Size(350, 300);
            // Căn giữa panel
            CenterPanel();
            
            // Tạo background gradient
            CreateBackground();
            
            // Thiết lập textbox
            SetupTextBox(emailTextBox, "Email của bạn");
            
            // Thiết lập button
            nextButton.BackColor = Color.FromArgb(220, 53, 69);
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.FlatAppearance.BorderSize = 0;
            nextButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            nextButton.ForeColor = Color.White;
            
            // Thêm hiệu ứng hover cho next button
            AddHoverEffect(nextButton);
            
            // Thiết lập labels
            SetupLabel(titleLabel, "Quên mật khẩu", Color.White, 18, FontStyle.Bold);
            SetupButton(tryAnotherButton, "Thử cách khác", Color.LightGray, 10);
            SetupButton(backButton, "Quay lại", Color.LightGray, 10);
            
            // Event handlers
            nextButton.Click += NextButton_Click;
            tryAnotherButton.Click += TryAnotherButton_Click;
            backButton.Click += BackButton_Click;
            
            // Form events
            this.Load += ForgotPasswordForm_Load;
            this.Resize += ForgotPasswordForm_Resize;
        }

        private void SetupTextBox(TextBox textBox, string placeholder)
        {
            textBox.BackColor = Color.FromArgb(60, 60, 60);
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Microsoft Sans Serif", 12);
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;
            textBox.Multiline = false;
            textBox.Size = new Size(290, 30);
            textBox.TextAlign = HorizontalAlignment.Left;
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
            
            // Thêm hiệu ứng hover
            AddHoverEffect(button);
        }
        
        private void AddHoverEffect(Button button)
        {
            button.MouseEnter += (sender, e) => {
                button.Size = new Size(button.Width + 4, button.Height + 4);
                button.Location = new Point(button.Location.X - 2, button.Location.Y - 2);
            };
            
            button.MouseLeave += (sender, e) => {
                button.Size = new Size(button.Width - 4, button.Height - 4);
                button.Location = new Point(button.Location.X + 2, button.Location.Y + 2);
            };
        }

        private void CenterPanel()
        {
            // Đảm bảo form đã được khởi tạo hoàn toàn
            if (this.Width > 0 && this.Height > 0 && forgotPanel.Width > 0 && forgotPanel.Height > 0)
            {
                // Căn giữa panel theo màn hình
                int x = (this.ClientSize.Width - forgotPanel.Width) / 2;
                int y = (this.ClientSize.Height - forgotPanel.Height) / 2;
                forgotPanel.Location = new Point(x, y);
            }
        }

        private void CreateBackground()
        {
            // Tạo background gradient đẹp và đơn giản
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
                
                // Thêm các ngôi sao nhỏ
                Random rand = new Random();
                for (int i = 0; i < 80; i++)
                {
                    int x = rand.Next(0, this.Width);
                    int y = rand.Next(0, this.Height);
                    int size = rand.Next(1, 2);
                    
                    using (SolidBrush starBrush = new SolidBrush(Color.FromArgb(150, 255, 255, 255)))
                    {
                        g.FillEllipse(starBrush, x, y, size, size);
                    }
                }
            }
            
            this.BackgroundImage = background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (isEmailPlaceholder)
            {
                emailTextBox.Text = "";
                emailTextBox.ForeColor = Color.White;
                isEmailPlaceholder = false;
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
            emailTextBox.Text = "Nhập email của bạn";
            emailTextBox.ForeColor = Color.Gray;
                isEmailPlaceholder = true;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            string email = isEmailPlaceholder ? "" : emailTextBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form xác minh
            VerifyForm verifyForm = new VerifyForm(email);
            verifyForm.Show();
            this.Hide();
        }

        private void TryAnotherButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Các cách khác:\n\n1. Liên hệ hỗ trợ qua hotline\n2. Đăng nhập bằng số điện thoại\n3. Tạo tài khoản mới", 
                "Thử cách khác", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel sau khi form load xong
            CenterPanel();
        }

        private void ForgotPasswordForm_Resize(object sender, EventArgs e)
        {
            // Tự động căn giữa panel khi form thay đổi kích thước
            CenterPanel();
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
            
            // Vẽ border cho textbox trong panel
            using (Pen pen = new Pen(Color.FromArgb(80, 80, 80), 1))
            {
                // Tính toán vị trí tương đối với panel
                int emailX = forgotPanel.Left + emailTextBox.Left - 1;
                int emailY = forgotPanel.Top + emailTextBox.Top - 1;
                
                e.Graphics.DrawRectangle(pen, emailX, emailY, emailTextBox.Width + 1, emailTextBox.Height + 1);
            }
        }
    }
}