using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormLogin : ThemedForm
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly UserService userService = new UserService();

        public FormLogin()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "\u0110\u0103ng nh\u1EADp - H\u1EC7 th\u1ED1ng QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            Panel mainPanel = CreateSurfacePanel(new Size(420, 420));
            mainPanel.Anchor = AnchorStyles.None;
            Controls.Add(mainPanel);
            AttachCentering(mainPanel);

            int currentY = 40;

            mainPanel.Controls.Add(new Label
            {
                Text = "\u0110\u0103ng nh\u1EADp",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(mainPanel.Width, 40),
                Location = new Point(0, currentY),
                TextAlign = ContentAlignment.MiddleCenter
            });

            currentY += 70;

            Label phoneLabel = CreateCenteredLabel("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i", mainPanel.Width, currentY);
            mainPanel.Controls.Add(phoneLabel);

            StyledTextBox phoneTextBox = new StyledTextBox
            {
                Name = "txtPhone",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                MaxLength = 10
            };
            StyleInputTextBox(phoneTextBox);
            phoneTextBox.Location = new Point(CenterContentX(mainPanel.Width, phoneTextBox.Width), currentY + 28);
            phoneTextBox.TextChanged += (s, e) =>
            {
                string digitsOnly = Regex.Replace(phoneTextBox.Text, @"[^\d]", "");
                if (digitsOnly != phoneTextBox.Text)
                {
                    int caret = phoneTextBox.SelectionStart - (phoneTextBox.Text.Length - digitsOnly.Length);
                    phoneTextBox.Text = digitsOnly;
                    phoneTextBox.SelectionStart = Math.Max(caret, 0);
                }
                SetValidationState(phoneTextBox, ValidationState.Neutral);
            };
            mainPanel.Controls.Add(phoneTextBox);

            currentY = phoneTextBox.Bottom + 30;

            Label passwordLabel = CreateCenteredLabel("M\u1EADt kh\u1EA9u", mainPanel.Width, currentY);
            mainPanel.Controls.Add(passwordLabel);

            StyledTextBox passwordTextBox = new StyledTextBox
            {
                Name = "txtPassword",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                UseSystemPasswordChar = true
            };
            StyleInputTextBox(passwordTextBox);
            passwordTextBox.Location = new Point(CenterContentX(mainPanel.Width, passwordTextBox.Width), currentY + 28);
            passwordTextBox.TextChanged += (s, e) => SetValidationState(passwordTextBox, ValidationState.Neutral);
            mainPanel.Controls.Add(passwordTextBox);

            currentY = passwordTextBox.Bottom + 30;

            Button loginButton = new Button
            {
                Name = "btnLogin",
                Text = "\u0110\u0103ng nh\u1EADp",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(loginButton);
            loginButton.Location = new Point(CenterContentX(mainPanel.Width, loginButton.Width), currentY);
            loginButton.Click += BtnLogin_Click;
            mainPanel.Controls.Add(loginButton);
            AcceptButton = loginButton;

            currentY = loginButton.Bottom + 30;

            LinkLabel forgotPasswordLink = CreateLinkLabel("B\u1EA1n qu\u00EAn m\u1EADt kh\u1EA9u?", currentY, mainPanel.Width);
            forgotPasswordLink.Click += (s, e) =>
            {
                ShowNextForm(new FormForgotPassword());
            };
            mainPanel.Controls.Add(forgotPasswordLink);

            currentY += 35;

            LinkLabel registerLink = CreateLinkLabel("T\u1EA1o t\u00E0i kho\u1EA3n", currentY, mainPanel.Width);
            registerLink.Click += (s, e) =>
            {
                ShowNextForm(new FormRegister());
            };
            mainPanel.Controls.Add(registerLink);

            currentY += 35;

            Label errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 36),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            mainPanel.Controls.Add(errorLabel);

            ActiveControl = phoneTextBox;
        }

        private Label CreateCenteredLabel(string text, int parentWidth, int y)
        {
            int width = Math.Min(ContentWidth, parentWidth);
            int left = CenterContentX(parentWidth, width);
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                ForeColor = SecondaryTextColor,
                Size = new Size(width, 20),
                Location = new Point(left, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private LinkLabel CreateLinkLabel(string text, int y, int parentWidth)
        {
            int width = Math.Min(ContentWidth, parentWidth);
            LinkLabel link = new LinkLabel
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                AutoSize = false,
                Size = new Size(width, 20),
                Location = new Point(CenterContentX(parentWidth, width), y),
                TextAlign = ContentAlignment.MiddleCenter
            };
            StyleMutedLink(link);
            return link;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            TextBox phoneTextBox = Controls.Find("txtPhone", true)[0] as TextBox;
            TextBox passwordTextBox = Controls.Find("txtPassword", true)[0] as TextBox;
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;

            string phone = phoneTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            errorLabel.Visible = false;
            ResetValidationStates(phoneTextBox, passwordTextBox);

            if (string.IsNullOrEmpty(phone))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp s\u1ED1 \u0111i\u1EC7n tho\u1EA1i", phoneTextBox);
                phoneTextBox.Focus();
                return;
            }

            if (!phone.StartsWith("0") || phone.Length != 10)
            {
                ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i ph\u1EA3i c\u00F3 10 ch\u1EEF s\u1ED1 v\u00E0 b\u1EAFt \u0111\u1EA7u b\u1EB1ng s\u1ED1 0", phoneTextBox);
                phoneTextBox.Focus();
                return;
            }

            if (!userService.IsPhoneRegistered(phone))
            {
                ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i ch\u01B0a \u0111\u01B0\u1EE3c \u0111\u0103ng k\u00FD", phoneTextBox);
                phoneTextBox.Focus();
                return;
            }

            SetValidationState(phoneTextBox, ValidationState.Success);

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u1EADt kh\u1EA9u", passwordTextBox);
                passwordTextBox.Focus();
                return;
            }

            try
            {
                LoginRequest request = new LoginRequest
                {
                    Phone = phone,
                    Password = password
                };

                if (userService.Authenticate(request))
                {
                    MessageBox.Show("\u0110\u0103ng nh\u1EADp th\u00E0nh c\u00F4ng!", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetValidationState(passwordTextBox, ValidationState.Success);
                    ShowNextForm(new FormMainSystem());
                }
                else
                {
                    ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i ho\u1EB7c m\u1EADt kh\u1EA9u kh\u00F4ng ch\u00EDnh x\u00E1c", phoneTextBox, passwordTextBox);
                }
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i x\u00E1c th\u1EF1c: {ex.Message}", phoneTextBox, passwordTextBox);
            }
        }

        private void ShowError(string message, params TextBox[] inputs)
        {
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;
            errorLabel.Text = message;
            errorLabel.Visible = true;

            if (inputs == null)
            {
                return;
            }

            foreach (TextBox input in inputs)
            {
                SetValidationState(input, ValidationState.Error);
            }
        }

        private void ShowNextForm(Form form)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }

            form.Show();
            Hide();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormLogin";
            Text = "\u0110\u0103ng nh\u1EADp";
            ResumeLayout(false);
        }
    }
}
