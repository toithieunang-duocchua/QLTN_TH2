using System.Drawing;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Entry point shell that keeps the themed background fixed while
    /// swapping authentication flows (login, register, verify, ...).
    /// </summary>
    public partial class LoginForm : ThemedForm
    {
        private TransitionHostPanel contentPanel;
        private static readonly Size TargetFormSize = new Size(1024, 576);

        public LoginForm()
        {
            InitializeComponent();
            SetupShell();
        }

        private void SetupShell()
        {
            Text = "H\u1EC7 th\u1ED1ng QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            contentPanel = new TransitionHostPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            Controls.Add(contentPanel);

            AuthNavigationManager.Initialize(contentPanel);
            AuthNavigationManager.Navigate(new LoginContentForm());
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "LoginForm";
            Text = "H\u1EC7 th\u1ED1ng QLTN";
            ResumeLayout(false);
        }
    }
}
