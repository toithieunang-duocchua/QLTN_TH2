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
    public partial class Form1 : Form
    {
        private bool isPhonePlaceholder = true;
        private bool isPasswordPlaceholder = true;

        public Form1()
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
            
            // Thiết lập panel login với độ trong suốt
            loginPanel.BackColor = Color.FromArgb(120, 50, 50, 50);
            loginPanel.Size = new Size(300, 400);
            // Căn giữa panel
            CenterPanel();
            
            // Tạo background gradient
            CreateBackground();
            
            // Thiết lập textbox
            SetupTextBox(phoneTextBox, "Số điện thoại");
            SetupTextBox(passwordTextBox, "Mật khẩu");
            
            // Đảm bảo TextBox được render đúng cách
            phoneTextBox.Refresh();
            passwordTextBox.Refresh();
            
            // Thiết lập button
            loginButton.BackColor = Color.FromArgb(220, 53, 69);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            
            // Thêm hiệu ứng hover cho login button
            AddHoverEffect(loginButton);
            
            // Thiết lập labels
            SetupLabel(titleLabel, "Đăng nhập", Color.White, 18, FontStyle.Bold);
            
            // Thiết lập buttons
            SetupButton(forgotPasswordLabel, "Bạn quên mật khẩu?", Color.LightGray, 10);
            SetupButton(createAccountLabel, "Tạo tài khoản", Color.LightGray, 10);
            
            // Thêm event handlers cho hover effects
            createAccountLabel.MouseEnter += CreateAccountLabel_MouseEnter;
            createAccountLabel.MouseLeave += CreateAccountLabel_MouseLeave;
            forgotPasswordLabel.MouseEnter += ForgotPasswordLabel_MouseEnter;
            forgotPasswordLabel.MouseLeave += ForgotPasswordLabel_MouseLeave;
        }

        private void SetupTextBox(TextBox textBox, string placeholder)
        {
            textBox.BackColor = Color.FromArgb(60, 60, 60);
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Microsoft Sans Serif", 12);
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;
            textBox.Multiline = false;
            textBox.Size = new Size(240, 30);
            textBox.TextAlign = HorizontalAlignment.Left;
            textBox.UseSystemPasswordChar = false;
            textBox.TabStop = true;
            textBox.Cursor = Cursors.IBeam;
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

        private void phoneTextBox_Enter(object sender, EventArgs e)
        {
            if (isPhonePlaceholder)
            {
                phoneTextBox.Text = "";
                phoneTextBox.ForeColor = Color.White;
                isPhonePlaceholder = false;
            }
        }

        private void phoneTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
            phoneTextBox.Text = "Nhập số điện thoại";
            phoneTextBox.ForeColor = Color.Gray;
                isPhonePlaceholder = true;
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (isPasswordPlaceholder)
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.White;
                passwordTextBox.UseSystemPasswordChar = true;
                isPasswordPlaceholder = false;
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
            passwordTextBox.Text = "Nhập mật khẩu";
            passwordTextBox.ForeColor = Color.Gray;
                passwordTextBox.UseSystemPasswordChar = false;
                isPasswordPlaceholder = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string phone = isPhonePlaceholder ? "" : phoneTextBox.Text;
            string password = isPasswordPlaceholder ? "" : passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý đăng nhập ở đây
            MessageBox.Show($"Đăng nhập với số điện thoại: {phone}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createAccountLabel_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký
            RegisterForm registerFormInstance = new RegisterForm();
            registerFormInstance.Show();
            this.Hide();
        }

        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            // Mở form quên mật khẩu
            ForgotPasswordForm forgotFormInstance = new ForgotPasswordForm();
            forgotFormInstance.Show();
            this.Hide();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Đảm bảo form được hiển thị đúng cách
            this.TopMost = false;
            this.BringToFront();
            
            // Căn giữa panel sau khi form load xong
            this.Resize += Form1_Resize;
            CenterPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Tự động căn giữa panel khi form thay đổi kích thước
            CenterPanel();
        }

        private void CreateAccountLabel_MouseEnter(object sender, EventArgs e)
        {
            createAccountLabel.ForeColor = Color.White;
        }

        private void CreateAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            createAccountLabel.ForeColor = Color.LightGray;
        }

        private void ForgotPasswordLabel_MouseEnter(object sender, EventArgs e)
        {
            forgotPasswordLabel.ForeColor = Color.White;
        }

        private void ForgotPasswordLabel_MouseLeave(object sender, EventArgs e)
        {
            forgotPasswordLabel.ForeColor = Color.LightGray;
        }

        private void CenterPanel()
        {
            // Đảm bảo form đã được khởi tạo hoàn toàn
            if (this.Width > 0 && this.Height > 0 && loginPanel.Width > 0 && loginPanel.Height > 0)
            {
                // Căn giữa panel theo màn hình
                int x = (this.ClientSize.Width - loginPanel.Width) / 2;
                int y = (this.ClientSize.Height - loginPanel.Height) / 2;
                loginPanel.Location = new Point(x, y);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Vẽ border cho textbox trong panel
            using (Pen pen = new Pen(Color.FromArgb(80, 80, 80), 1))
            {
                // Tính toán vị trí tương đối với panel
                int phoneX = loginPanel.Left + phoneTextBox.Left - 1;
                int phoneY = loginPanel.Top + phoneTextBox.Top - 1;
                int passwordX = loginPanel.Left + passwordTextBox.Left - 1;
                int passwordY = loginPanel.Top + passwordTextBox.Top - 1;
                
                e.Graphics.DrawRectangle(pen, phoneX, phoneY, phoneTextBox.Width + 1, phoneTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, passwordX, passwordY, passwordTextBox.Width + 1, passwordTextBox.Height + 1);
            }
        }
    }
}
