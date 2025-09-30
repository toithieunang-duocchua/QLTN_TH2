namespace registerForm
{
    partial class RegisterForm
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
            this.registerPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.termsLinkLabel = new System.Windows.Forms.Label();
            this.termsLabel = new System.Windows.Forms.Label();
            this.termsCheckBox = new System.Windows.Forms.CheckBox();
            this.femaleCheckBox = new System.Windows.Forms.CheckBox();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.femaleLabel = new System.Windows.Forms.Label();
            this.maleLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.registerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerPanel
            // 
            this.registerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.registerPanel.Controls.Add(this.backButton);
            this.registerPanel.Controls.Add(this.termsLinkLabel);
            this.registerPanel.Controls.Add(this.termsLabel);
            this.registerPanel.Controls.Add(this.termsCheckBox);
            this.registerPanel.Controls.Add(this.femaleCheckBox);
            this.registerPanel.Controls.Add(this.maleCheckBox);
            this.registerPanel.Controls.Add(this.femaleLabel);
            this.registerPanel.Controls.Add(this.maleLabel);
            this.registerPanel.Controls.Add(this.registerButton);
            this.registerPanel.Controls.Add(this.passwordTextBox);
            this.registerPanel.Controls.Add(this.emailTextBox);
            this.registerPanel.Controls.Add(this.phoneTextBox);
            this.registerPanel.Controls.Add(this.fullNameTextBox);
            this.registerPanel.Controls.Add(this.titleLabel);
            this.registerPanel.Location = new System.Drawing.Point(225, 50);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(350, 500);
            this.registerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(130, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(90, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Đăng ký";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.fullNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fullNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.fullNameTextBox.Location = new System.Drawing.Point(30, 70);
            this.fullNameTextBox.Multiline = true;
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(290, 30);
            this.fullNameTextBox.TabIndex = 1;
            this.fullNameTextBox.Text = "Họ tên";
            this.fullNameTextBox.Enter += new System.EventHandler(this.fullNameTextBox_Enter);
            this.fullNameTextBox.Leave += new System.EventHandler(this.fullNameTextBox_Leave);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.phoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.ForeColor = System.Drawing.Color.Gray;
            this.phoneTextBox.Location = new System.Drawing.Point(30, 120);
            this.phoneTextBox.Multiline = true;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(290, 30);
            this.phoneTextBox.TabIndex = 2;
            this.phoneTextBox.Text = "Số điện thoại";
            this.phoneTextBox.Enter += new System.EventHandler(this.phoneTextBox_Enter);
            this.phoneTextBox.Leave += new System.EventHandler(this.phoneTextBox_Leave);
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.emailTextBox.Location = new System.Drawing.Point(30, 170);
            this.emailTextBox.Multiline = true;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(290, 30);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.Text = "Email";
            this.emailTextBox.Enter += new System.EventHandler(this.emailTextBox_Enter);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordTextBox.Location = new System.Drawing.Point(30, 220);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(290, 30);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.Text = "Mật khẩu";
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // maleLabel
            // 
            this.maleLabel.AutoSize = true;
            this.maleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.maleLabel.Location = new System.Drawing.Point(50, 270);
            this.maleLabel.Name = "maleLabel";
            this.maleLabel.Size = new System.Drawing.Size(30, 17);
            this.maleLabel.TabIndex = 5;
            this.maleLabel.Text = "Nam";
            // 
            // femaleLabel
            // 
            this.femaleLabel.AutoSize = true;
            this.femaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.femaleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.femaleLabel.Location = new System.Drawing.Point(200, 270);
            this.femaleLabel.Name = "femaleLabel";
            this.femaleLabel.Size = new System.Drawing.Size(25, 17);
            this.femaleLabel.TabIndex = 6;
            this.femaleLabel.Text = "Nữ";
            // 
            // maleCheckBox
            // 
            this.maleCheckBox.AutoSize = true;
            this.maleCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.maleCheckBox.ForeColor = System.Drawing.Color.White;
            this.maleCheckBox.Location = new System.Drawing.Point(30, 270);
            this.maleCheckBox.Name = "maleCheckBox";
            this.maleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.maleCheckBox.TabIndex = 7;
            this.maleCheckBox.UseVisualStyleBackColor = false;
            this.maleCheckBox.CheckedChanged += new System.EventHandler(this.MaleCheckBox_CheckedChanged);
            // 
            // femaleCheckBox
            // 
            this.femaleCheckBox.AutoSize = true;
            this.femaleCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.femaleCheckBox.ForeColor = System.Drawing.Color.White;
            this.femaleCheckBox.Location = new System.Drawing.Point(180, 270);
            this.femaleCheckBox.Name = "femaleCheckBox";
            this.femaleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.femaleCheckBox.TabIndex = 8;
            this.femaleCheckBox.UseVisualStyleBackColor = false;
            this.femaleCheckBox.CheckedChanged += new System.EventHandler(this.FemaleCheckBox_CheckedChanged);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.registerButton.FlatAppearance.BorderSize = 0;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.Location = new System.Drawing.Point(30, 310);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(290, 40);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "Đăng ký";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // termsCheckBox
            // 
            this.termsCheckBox.AutoSize = true;
            this.termsCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.termsCheckBox.ForeColor = System.Drawing.Color.White;
            this.termsCheckBox.Location = new System.Drawing.Point(30, 370);
            this.termsCheckBox.Name = "termsCheckBox";
            this.termsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.termsCheckBox.TabIndex = 10;
            this.termsCheckBox.UseVisualStyleBackColor = false;
            // 
            // termsLabel
            // 
            this.termsLabel.AutoSize = true;
            this.termsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termsLabel.ForeColor = System.Drawing.Color.LightGray;
            this.termsLabel.Location = new System.Drawing.Point(50, 370);
            this.termsLabel.Name = "termsLabel";
            this.termsLabel.Size = new System.Drawing.Size(150, 15);
            this.termsLabel.TabIndex = 11;
            this.termsLabel.Text = "Tôi đã đọc và đồng ý với";
            // 
            // termsLinkLabel
            // 
            this.termsLinkLabel.AutoSize = true;
            this.termsLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.termsLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termsLinkLabel.ForeColor = System.Drawing.Color.LightBlue;
            this.termsLinkLabel.Location = new System.Drawing.Point(200, 370);
            this.termsLinkLabel.Name = "termsLinkLabel";
            this.termsLinkLabel.Size = new System.Drawing.Size(60, 15);
            this.termsLinkLabel.TabIndex = 12;
            this.termsLinkLabel.Text = "điều khoản";
            this.termsLinkLabel.Click += new System.EventHandler(this.TermsLinkLabel_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.LightGray;
            this.backButton.Location = new System.Drawing.Point(30, 420);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(290, 35);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Quay lại";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.registerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label maleLabel;
        private System.Windows.Forms.Label femaleLabel;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.CheckBox femaleCheckBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.CheckBox termsCheckBox;
        private System.Windows.Forms.Label termsLabel;
        private System.Windows.Forms.Label termsLinkLabel;
        private System.Windows.Forms.Button backButton;
    }
}
