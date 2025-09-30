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

namespace registerForm
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
            registerPanel.Location = new Point((this.Width - registerPanel.Width) / 2, (this.Height - registerPanel.Height) / 2);
            
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
            
            // Thiết lập labels
            SetupLabel(titleLabel, "Đăng ký", Color.White, 18, FontStyle.Bold);
            SetupLabel(maleLabel, "Nam", Color.LightGray, 10);
            SetupLabel(femaleLabel, "Nữ", Color.LightGray, 10);
            SetupLabel(termsLabel, "Tôi đã đọc và đồng ý với", Color.LightGray, 9);
            SetupLabel(termsLinkLabel, "điều khoản", Color.LightBlue, 9);
            SetupButton(backButton, "Quay lại", Color.LightGray, 10);
            
            // Thiết lập checkbox
            maleCheckBox.BackColor = Color.FromArgb(60, 60, 60);
            femaleCheckBox.BackColor = Color.FromArgb(60, 60, 60);
            termsCheckBox.BackColor = Color.FromArgb(60, 60, 60);
            
            // Event handlers
            termsLinkLabel.Cursor = Cursors.Hand;
            termsLinkLabel.Click += TermsLinkLabel_Click;
            backButton.Click += BackButton_Click;
            registerButton.Click += RegisterButton_Click;
            
            // Checkbox events
            maleCheckBox.CheckedChanged += MaleCheckBox_CheckedChanged;
            femaleCheckBox.CheckedChanged += FemaleCheckBox_CheckedChanged;
        }

        private void SetupTextBox(TextBox textBox, string placeholder)
        {
            textBox.BackColor = Color.FromArgb(60, 60, 60);
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Microsoft Sans Serif", 12);
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;
            textBox.Multiline = true;
            textBox.Size = new Size(290, 30);
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
                fullNameTextBox.Text = "Họ tên";
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
                phoneTextBox.Text = "Số điện thoại";
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
                emailTextBox.Text = "Email";
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
                passwordTextBox.Text = "Mật khẩu";
                passwordTextBox.ForeColor = Color.Gray;
                passwordTextBox.UseSystemPasswordChar = false;
                isPasswordPlaceholder = true;
            }
        }

        private void MaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
            {
                femaleCheckBox.Checked = false;
            }
        }

        private void FemaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
            {
                maleCheckBox.Checked = false;
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

            if (!maleCheckBox.Checked && !femaleCheckBox.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            loginForm.Form1 loginForm = new loginForm.Form1();
            loginForm.Show();
            this.Close();
        }

        private void TermsLinkLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Điều khoản sử dụng:\n\n1. Bạn phải cung cấp thông tin chính xác\n2. Không được sử dụng dịch vụ cho mục đích bất hợp pháp\n3. Chúng tôi có quyền từ chối dịch vụ nếu vi phạm điều khoản", 
                "Điều khoản sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                e.Graphics.DrawRectangle(pen, fullNameTextBox.Left - 1, fullNameTextBox.Top - 1, fullNameTextBox.Width + 1, fullNameTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, phoneTextBox.Left - 1, phoneTextBox.Top - 1, phoneTextBox.Width + 1, phoneTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, emailTextBox.Left - 1, emailTextBox.Top - 1, emailTextBox.Width + 1, emailTextBox.Height + 1);
                e.Graphics.DrawRectangle(pen, passwordTextBox.Left - 1, passwordTextBox.Top - 1, passwordTextBox.Width + 1, passwordTextBox.Height + 1);
            }
        }
    }
}
