namespace loginForm
{
    partial class ForgotPasswordForm
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
            this.forgotPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.tryAnotherButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.forgotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // forgotPanel
            // 
            this.forgotPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.forgotPanel.Controls.Add(this.backButton);
            this.forgotPanel.Controls.Add(this.tryAnotherButton);
            this.forgotPanel.Controls.Add(this.nextButton);
            this.forgotPanel.Controls.Add(this.emailTextBox);
            this.forgotPanel.Controls.Add(this.titleLabel);
            this.forgotPanel.Location = new System.Drawing.Point(0, 0);
            this.forgotPanel.Name = "forgotPanel";
            this.forgotPanel.Size = new System.Drawing.Size(350, 300);
            this.forgotPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(100, 30);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Quên mật khẩu";
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.emailTextBox.Location = new System.Drawing.Point(30, 80);
            this.emailTextBox.Multiline = false;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(290, 50);
            this.emailTextBox.TabIndex = 1;
            this.emailTextBox.Text = "Nhập email của bạn";
            this.emailTextBox.Enter += new System.EventHandler(this.emailTextBox_Enter);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(30, 150);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(290, 40);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Tiếp theo";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // tryAnotherButton
            // 
            this.tryAnotherButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tryAnotherButton.FlatAppearance.BorderSize = 0;
            this.tryAnotherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tryAnotherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tryAnotherButton.ForeColor = System.Drawing.Color.LightGray;
            this.tryAnotherButton.Location = new System.Drawing.Point(30, 210);
            this.tryAnotherButton.Name = "tryAnotherButton";
            this.tryAnotherButton.Size = new System.Drawing.Size(290, 35);
            this.tryAnotherButton.TabIndex = 3;
            this.tryAnotherButton.Text = "Thử cách khác";
            this.tryAnotherButton.UseVisualStyleBackColor = false;
            this.tryAnotherButton.Click += new System.EventHandler(this.TryAnotherButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.LightGray;
            this.backButton.Location = new System.Drawing.Point(30, 260);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(290, 35);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Quay lại";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.forgotPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.forgotPanel.ResumeLayout(false);
            this.forgotPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel forgotPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button tryAnotherButton;
        private System.Windows.Forms.Button backButton;
    }
}