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
    public partial class RegisterForm : Form
    {
        private bool isFullNamePlaceholder = true;
        private bool isPhonePlaceholder = true;
        private bool isEmailPlaceholder = true;
        private bool isPasswordPlaceholder = true;

        public RegisterForm()
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
            
            // Thiết lập panel register với độ trong suốt
            registerPanel.BackColor = Color.FromArgb(120, 50, 50, 50);
            registerPanel.Size = new Size(350, 500);
            // Căn giữa panel
            CenterPanel();
            
            // Tạo background gradient
            CreateBackground();
            
            // Thiết lập textbox
            SetupTextBox(fullNameTextBox, "Họ tên");
            SetupTextBox(phoneTextBox, "Số điện thoại");
            SetupTextBox(emailTextBox, "Email");
            SetupTextBox(passwordTextBox, "Mật khẩu");
            
            // Thiết lập button
            registerButton.BackColor = Color.FromArgb(220, 53, 69);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            registerButton.ForeColor = Color.White;
            
            // Thêm hiệu ứng hover cho register button
            AddHoverEffect(registerButton);
            
            // Thiết lập labels
            SetupLabel(titleLabel, "Đăng ký", Color.White, 18, FontStyle.Bold);
            SetupButton(backButton, "Quay lại", Color.LightGray, 10);
            SetupCheckBox(termsCheckBox, "Tôi đã đọc và đồng ý với điều khoản");
            
            // Event handlers
            registerButton.Click += RegisterButton_Click;
            backButton.Click += BackButton_Click;
            
            // Form events
            this.Load += RegisterForm_Load;
            this.Resize += RegisterForm_Resize;
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
        
        private void SetupCheckBox(CheckBox checkBox, string text)
        {
            checkBox.Text = text;
            checkBox.ForeColor = Color.LightGray;
            checkBox.Font = new Font("Microsoft Sans Serif", 10);
            checkBox.BackColor = Color.FromArgb(60, 60, 60);
            checkBox.FlatStyle = FlatStyle.Flat;
            checkBox.AutoSize = true;
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
            if (this.Width > 0 && this.Height > 0 && registerPanel.Width > 0 && registerPanel.Height > 0)
            {
                // Căn giữa panel theo màn hình
                int x = (this.ClientSize.Width - registerPanel.Width) / 2;
                int y = (this.ClientSize.Height - registerPanel.Height) / 2;
                registerPanel.Location = new Point(x, y);
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

        private void fullNameTextBox_Enter(object sender, EventArgs e)
        {
            if (isFullNamePlaceholder)
            {
                fullNameTextBox.Text = "";
                fullNameTextBox.ForeColor = Color.White;
                isFullNamePlaceholder = false;
            }
        }

        private void fullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
            fullNameTextBox.Text = "Nhập họ tên";
            fullNameTextBox.ForeColor = Color.Gray;
                isFullNamePlaceholder = true;
            }
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
            emailTextBox.Text = "Nhập email";
            emailTextBox.ForeColor = Color.Gray;
                isEmailPlaceholder = true;
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string fullName = isFullNamePlaceholder ? "" : fullNameTextBox.Text;
            string phone = isPhonePlaceholder ? "" : phoneTextBox.Text;
            string email = isEmailPlaceholder ? "" : emailTextBox.Text;
            string password = isPasswordPlaceholder ? "" : passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || 
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!termsCheckBox.Checked)
            {
                MessageBox.Show("Vui lòng đồng ý với điều khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý đăng ký ở đây
            MessageBox.Show($"Đăng ký thành công!\nHọ tên: {fullName}\nSố điện thoại: {phone}\nEmail: {email}", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel sau khi form load xong
            CenterPanel();
        }

        private void RegisterForm_Resize(object sender, EventArgs e)
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
                int fullNameX = registerPanel.Left + fullNameTextBox.Left - 1;
                int fullNameY = registerPanel.Top + fullNameTextBox.Top - 1;
                int phoneX = registerPanel.Left + phoneTextBox.Left - 1;
                int phoneY = registerPanel.Top + phoneTextBox.Top - 1;
                int emailX = registerPanel.Left + emailTextBox.Left - 1;
                int emailY = registerPanel.Top + emailTextBox.Top - 1;
                int passwordX = registerPanel.Left + passwordTextBox.Left - 1;
                int passwordY = registerPanel.Top + passwordTextBox.Top - 1;
                
                e.Graphics.DrawRectangle(pen, fullNameX, fullNameY, fullNameTextBox.Width + 1, fullNameTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, phoneX, phoneY, phoneTextBox.Width + 1, phoneTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, emailX, emailY, emailTextBox.Width + 1, emailTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, passwordX, passwordY, passwordTextBox.Width + 1, passwordTextBox.Height + 1);
            }
        }
    }
}