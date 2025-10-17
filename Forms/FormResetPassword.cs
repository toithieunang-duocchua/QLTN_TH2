using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Database;

namespace QLTN.Forms
{
    public partial class FormResetPassword : ThemedForm, IAuthView
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly string userEmail;

        public FormResetPassword(string email)
        {
            userEmail = email;
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u - H\u1EC7 th\u1ED1ng QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            Panel mainPanel = CreateSurfacePanel(new Size(420, 420));
            mainPanel.Anchor = AnchorStyles.None;
            Controls.Add(mainPanel);
            AttachCentering(mainPanel);

            int currentY = 36;

            mainPanel.Controls.Add(new Label
            {
                Text = "\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(mainPanel.Width, 40),
                Location = new Point(0, currentY),
                TextAlign = ContentAlignment.MiddleCenter
            });

            currentY += 60;

            mainPanel.Controls.Add(CreateCenteredLabel("M\u1EADt kh\u1EA9u m\u1EDBi", mainPanel.Width, currentY));

            TextBox newPasswordTextBox = CreatePasswordTextBox("txtNewPassword");
            newPasswordTextBox.Location = new Point(CenterContentX(mainPanel.Width, newPasswordTextBox.Width), currentY + 24);
            newPasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            mainPanel.Controls.Add(newPasswordTextBox);

            Label strengthLabel = new Label
            {
                Name = "lblStrength",
                Size = new Size(ContentWidth, 18),
                Location = new Point(newPasswordTextBox.Left, newPasswordTextBox.Bottom + 6),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(180, 180, 180)
            };
            mainPanel.Controls.Add(strengthLabel);

            currentY = strengthLabel.Bottom + 20;

            mainPanel.Controls.Add(CreateCenteredLabel("X\u00E1c nh\u1EADn m\u1EADt kh\u1EA9u m\u1EDBi", mainPanel.Width, currentY));

            TextBox confirmPasswordTextBox = CreatePasswordTextBox("txtConfirmPassword");
            confirmPasswordTextBox.Location = new Point(CenterContentX(mainPanel.Width, confirmPasswordTextBox.Width), currentY + 24);
            mainPanel.Controls.Add(confirmPasswordTextBox);

            currentY = confirmPasswordTextBox.Bottom + 28;

            Label errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 40),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            mainPanel.Controls.Add(errorLabel);

            currentY = errorLabel.Bottom + 16;

            Button completeButton = new Button
            {
                Name = "btnComplete",
                Text = "Ho\u00E0n t\u1EA5t",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(completeButton);
            completeButton.Location = new Point(CenterContentX(mainPanel.Width, completeButton.Width), currentY);
            completeButton.Click += BtnComplete_Click;
            mainPanel.Controls.Add(completeButton);
            AcceptButton = completeButton;

            currentY = completeButton.Bottom + 20;

            LinkLabel backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", currentY, mainPanel.Width);
            backLink.Click += (s, e) => ShowNextForm<LoginContentForm>();
            mainPanel.Controls.Add(backLink);

            ActiveControl = newPasswordTextBox;
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

        private TextBox CreatePasswordTextBox(string controlName)
        {
            StyledTextBox textBox = new StyledTextBox
            {
                Name = controlName,
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                UseSystemPasswordChar = true
            };
            StyleInputTextBox(textBox);
            textBox.TextChanged += (s, e) => SetValidationState((TextBox)s, ValidationState.Neutral);
            return textBox;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox passwordTextBox = sender as TextBox;
            Label strengthLabel = Controls.Find("lblStrength", true)[0] as Label;

            string password = passwordTextBox.Text;
            if (string.IsNullOrEmpty(password))
            {
                strengthLabel.Text = string.Empty;
                strengthLabel.ForeColor = Color.FromArgb(180, 180, 180);
                return;
            }

            int strength = CalculatePasswordStrength(password);
            if (strength <= 2)
            {
                strengthLabel.Text = "M\u1EADt kh\u1EA9u y\u1EBFu";
                strengthLabel.ForeColor = Color.FromArgb(255, 107, 107);
            }
            else if (strength <= 4)
            {
                strengthLabel.Text = "M\u1EADt kh\u1EA9u trung b\u00ECnh";
                strengthLabel.ForeColor = Color.FromArgb(255, 211, 61);
            }
            else
            {
                strengthLabel.Text = "M\u1EADt kh\u1EA9u m\u1EA1nh";
                strengthLabel.ForeColor = Color.FromArgb(107, 207, 127);
            }
        }

        private int CalculatePasswordStrength(string password)
        {
            int strength = 0;
            if (password.Length >= 8) strength++;
            if (password.Length >= 12) strength++;
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]")) strength++;
            if (Regex.IsMatch(password, @"[0-9]")) strength++;
            if (Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]")) strength++;
            return strength;
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            TextBox newPasswordTextBox = Controls.Find("txtNewPassword", true)[0] as TextBox;
            TextBox confirmPasswordTextBox = Controls.Find("txtConfirmPassword", true)[0] as TextBox;
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;

            string newPassword = newPasswordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            errorLabel.Visible = false;
            ResetValidationStates(newPasswordTextBox, confirmPasswordTextBox);

            if (string.IsNullOrEmpty(newPassword))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u1EADt kh\u1EA9u m\u1EDBi", newPasswordTextBox);
                newPasswordTextBox.Focus();
                return;
            }

            if (newPassword.Length < 8 ||
                !Regex.IsMatch(newPassword, @"[A-Z]") ||
                !Regex.IsMatch(newPassword, @"[a-z]") ||
                !Regex.IsMatch(newPassword, @"[0-9]") ||
                !Regex.IsMatch(newPassword, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            {
                ShowError("M\u1EADt kh\u1EA9u m\u1EDBi ph\u1EA3i \u0111\u1EE7 m\u1EA1nh (>=8 k\u00FD t\u1EF1, c\u00F3 ch\u1EEF hoa, ch\u1EEF th\u01B0\u1EDDng, ch\u1EEF s\u1ED1 v\u00E0 k\u00FD t\u1EF1 \u0111\u1EB7c bi\u1EC7t)", newPasswordTextBox);
                newPasswordTextBox.Focus();
                return;
            }
            SetValidationState(newPasswordTextBox, ValidationState.Success);

            if (string.IsNullOrEmpty(confirmPassword))
            {
                ShowError("Vui l\u00F2ng x\u00E1c nh\u1EADn m\u1EADt kh\u1EA9u m\u1EDBi", confirmPasswordTextBox);
                confirmPasswordTextBox.Focus();
                return;
            }

            if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ShowError("M\u1EADt kh\u1EA9u x\u00E1c nh\u1EADn kh\u00F4ng kh\u1EDBp", newPasswordTextBox, confirmPasswordTextBox);
                confirmPasswordTextBox.Focus();
                return;
            }
            SetValidationState(confirmPasswordTextBox, ValidationState.Success);

            try
            {
                UpdatePassword(userEmail, newPassword);

                MessageBox.Show("\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u th\u00E0nh c\u00F4ng! Vui l\u00F2ng \u0111\u0103ng nh\u1EADp l\u1EA1i.", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ShowNextForm<LoginContentForm>();
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i: {ex.Message}", newPasswordTextBox, confirmPasswordTextBox);
            }
        }

        private void UpdatePassword(string email, string newPassword)
        {
            const string query = "UPDATE nguoidung SET matKhau = @Password WHERE email = @Email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Password", newPassword),
                new SqlParameter("@Email", email)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
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

        private void ShowNextForm<TForm>() where TForm : Form, new()
        {
            AuthNavigationManager.Navigate<TForm>(this);
        }

        private void ShowNextForm(Form form)
        {
            AuthNavigationManager.Navigate(form, this);
        }

        void IAuthView.PrepareForDisplay()
        {
            TextBox newPasswordTextBox = FindControlRecursive<TextBox>("txtNewPassword");
            TextBox confirmPasswordTextBox = FindControlRecursive<TextBox>("txtConfirmPassword");
            Label errorLabel = FindControlRecursive<Label>("lblError");
            Label strengthLabel = FindControlRecursive<Label>("lblStrength");
            Button completeButton = FindControlRecursive<Button>("btnComplete");

            if (errorLabel != null)
            {
                errorLabel.Visible = false;
                errorLabel.Text = string.Empty;
            }

            if (strengthLabel != null)
            {
                strengthLabel.Text = string.Empty;
            }

            if (newPasswordTextBox != null)
            {
                newPasswordTextBox.Text = string.Empty;
            }

            if (confirmPasswordTextBox != null)
            {
                confirmPasswordTextBox.Text = string.Empty;
            }

            ResetValidationStates(newPasswordTextBox, confirmPasswordTextBox);

            if (completeButton != null)
            {
                AcceptButton = completeButton;
            }

            if (newPasswordTextBox != null)
            {
                ActiveControl = newPasswordTextBox;
                newPasswordTextBox.Focus();
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // FormResetPassword
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormResetPassword";
            Text = "\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u";
            ResumeLayout(false);
        }
    }
}
