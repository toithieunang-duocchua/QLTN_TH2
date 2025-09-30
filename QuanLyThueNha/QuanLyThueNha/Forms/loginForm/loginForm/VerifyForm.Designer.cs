namespace loginForm
{
    partial class VerifyForm
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
            this.verifyPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.resendButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.instructionLabel3 = new System.Windows.Forms.Label();
            this.instructionLabel2 = new System.Windows.Forms.Label();
            this.instructionLabel1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.verifyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // verifyPanel
            // 
            this.verifyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.verifyPanel.Controls.Add(this.backButton);
            this.verifyPanel.Controls.Add(this.resendButton);
            this.verifyPanel.Controls.Add(this.verifyButton);
            this.verifyPanel.Controls.Add(this.codeTextBox);
            this.verifyPanel.Controls.Add(this.instructionLabel3);
            this.verifyPanel.Controls.Add(this.instructionLabel2);
            this.verifyPanel.Controls.Add(this.instructionLabel1);
            this.verifyPanel.Controls.Add(this.titleLabel);
            this.verifyPanel.Location = new System.Drawing.Point(0, 0);
            this.verifyPanel.Name = "verifyPanel";
            this.verifyPanel.Size = new System.Drawing.Size(400, 450);
            this.verifyPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(160, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(80, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Xác minh";
            // 
            // instructionLabel1
            // 
            this.instructionLabel1.AutoSize = true;
            this.instructionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel1.ForeColor = System.Drawing.Color.White;
            this.instructionLabel1.Location = new System.Drawing.Point(30, 60);
            this.instructionLabel1.Name = "instructionLabel1";
            this.instructionLabel1.Size = new System.Drawing.Size(340, 17);
            this.instructionLabel1.TabIndex = 1;
            this.instructionLabel1.Text = "Chúng tôi đã gửi mã xác nhận qua email của bạn.";
            // 
            // instructionLabel2
            // 
            this.instructionLabel2.AutoSize = true;
            this.instructionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel2.ForeColor = System.Drawing.Color.White;
            this.instructionLabel2.Location = new System.Drawing.Point(30, 85);
            this.instructionLabel2.Name = "instructionLabel2";
            this.instructionLabel2.Size = new System.Drawing.Size(340, 17);
            this.instructionLabel2.TabIndex = 2;
            this.instructionLabel2.Text = "Vui lòng kiểm tra và nhập vào phần xác minh bên dưới.";
            // 
            // instructionLabel3
            // 
            this.instructionLabel3.AutoSize = true;
            this.instructionLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel3.ForeColor = System.Drawing.Color.Red;
            this.instructionLabel3.Location = new System.Drawing.Point(30, 110);
            this.instructionLabel3.Name = "instructionLabel3";
            this.instructionLabel3.Size = new System.Drawing.Size(340, 17);
            this.instructionLabel3.TabIndex = 3;
            this.instructionLabel3.Text = "Lưu ý: Mã chỉ có hiệu lực trong vòng 5 phút.";
            // 
            // codeTextBox
            // 
            this.codeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.ForeColor = System.Drawing.Color.Gray;
            this.codeTextBox.Location = new System.Drawing.Point(30, 150);
            this.codeTextBox.Multiline = true;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(340, 30);
            this.codeTextBox.TabIndex = 4;
            this.codeTextBox.Text = "Mã xác minh";
            this.codeTextBox.Enter += new System.EventHandler(this.codeTextBox_Enter);
            this.codeTextBox.Leave += new System.EventHandler(this.codeTextBox_Leave);
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.verifyButton.FlatAppearance.BorderSize = 0;
            this.verifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.ForeColor = System.Drawing.Color.White;
            this.verifyButton.Location = new System.Drawing.Point(30, 200);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(340, 40);
            this.verifyButton.TabIndex = 5;
            this.verifyButton.Text = "Xác minh";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // resendButton
            // 
            this.resendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.resendButton.FlatAppearance.BorderSize = 0;
            this.resendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resendButton.ForeColor = System.Drawing.Color.LightGray;
            this.resendButton.Location = new System.Drawing.Point(30, 260);
            this.resendButton.Name = "resendButton";
            this.resendButton.Size = new System.Drawing.Size(340, 35);
            this.resendButton.TabIndex = 6;
            this.resendButton.Text = "Gửi lại mã xác minh";
            this.resendButton.UseVisualStyleBackColor = false;
            this.resendButton.Click += new System.EventHandler(this.ResendButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.LightGray;
            this.backButton.Location = new System.Drawing.Point(30, 310);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(340, 35);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Quay lại";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // VerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.verifyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.verifyPanel.ResumeLayout(false);
            this.verifyPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel verifyPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label instructionLabel1;
        private System.Windows.Forms.Label instructionLabel2;
        private System.Windows.Forms.Label instructionLabel3;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button resendButton;
        private System.Windows.Forms.Button backButton;
    }
}
