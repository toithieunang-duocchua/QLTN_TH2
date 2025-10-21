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
        private Panel _mainPanel;
        private Label _titleLabel;
        private Label _newPasswordLabel;
        private Label _confirmPasswordLabel;
        private StyledTextBox _newPasswordTextBox;
        private StyledTextBox _confirmPasswordTextBox;
        private Label _strengthLabel;
        private Label _errorLabel;
        private Button _completeButton;
        private LinkLabel _backLink;

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

            _mainPanel = CreateSurfacePanel(new Size(420, 420));
            _mainPanel.Anchor = AnchorStyles.None;
            _mainPanel.MinimumSize = new Size(420, 0);
            _mainPanel.MaximumSize = new Size(420, int.MaxValue);
            Controls.Add(_mainPanel);
            AttachCentering(_mainPanel);

            _titleLabel = new Label
            {
                Name = "lblTitle",
                Text = "\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(_mainPanel.Width, 40),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_titleLabel);

            _newPasswordLabel = CreateCenteredLabel("M\u1EADt kh\u1EA9u m\u1EDBi", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_newPasswordLabel);

            _newPasswordTextBox = CreatePasswordTextBox("txtNewPassword");
            _newPasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            _newPasswordTextBox.TextChanged += PasswordFields_TextChanged;
            _mainPanel.Controls.Add(_newPasswordTextBox);

            _strengthLabel = new Label
            {
                Name = "lblStrength",
                AutoSize = false,
                Size = new Size(ContentWidth, 0),
                MaximumSize = new Size(ContentWidth, 0),
                Location = Point.Empty,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(180, 180, 180),
                Visible = false
            };
            _mainPanel.Controls.Add(_strengthLabel);

            _confirmPasswordLabel = CreateCenteredLabel("X\u00E1c nh\u1EADn m\u1EADt kh\u1EA9u m\u1EDBi", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_confirmPasswordLabel);

            _confirmPasswordTextBox = CreatePasswordTextBox("txtConfirmPassword");
            _confirmPasswordTextBox.TextChanged += PasswordFields_TextChanged;
            _mainPanel.Controls.Add(_confirmPasswordTextBox);

            _errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 0),
                Location = Point.Empty,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.TopCenter,
                Visible = false
            };
            _mainPanel.Controls.Add(_errorLabel);

            _completeButton = new Button
            {
                Name = "btnComplete",
                Text = "Ho\u00E0n t\u1EA5t",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(_completeButton);
            _completeButton.Click += BtnComplete_Click;
            _mainPanel.Controls.Add(_completeButton);
            AcceptButton = _completeButton;

            _backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", 0, _mainPanel.Width);
            _backLink.Click += (s, e) => ShowNextForm<LoginContentForm>();
            _mainPanel.Controls.Add(_backLink);

            ReflowLayout();

            ActiveControl = _newPasswordTextBox;
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

        private StyledTextBox CreatePasswordTextBox(string controlName)
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

        private void PasswordFields_TextChanged(object sender, EventArgs e)
        {
            ClearErrorDisplay();
        }

        private void ReflowLayout()
        {
            if (_mainPanel == null)
            {
                return;
            }

            const int panelTopPadding = 36;
            const int titleSpacing = 60;
            const int labelToInputSpacing = 8;
            const int inputToHelperSpacing = 6;
            const int helperSpacingVisible = 6;
            const int helperSpacingHidden = 18;
            const int inputsSpacing = 20;
            const int errorSpacingVisible = 16;
            const int errorSpacingHidden = 12;
            const int buttonSpacing = 20;
            const int bottomPadding = 32;

            int centerX = CenterContentX(_mainPanel.Width, ContentWidth);
            int currentY = panelTopPadding;

            if (_titleLabel != null)
            {
                _titleLabel.Left = 0;
                _titleLabel.Width = _mainPanel.Width;
                _titleLabel.Top = currentY;
                currentY += _titleLabel.Height + titleSpacing;
            }

            if (_newPasswordLabel != null)
            {
                _newPasswordLabel.Left = centerX;
                _newPasswordLabel.Top = currentY;
                _newPasswordLabel.Width = ContentWidth;
                currentY = _newPasswordLabel.Bottom + labelToInputSpacing;
            }

            if (_newPasswordTextBox != null)
            {
                _newPasswordTextBox.Left = centerX;
                _newPasswordTextBox.Top = currentY;
                currentY = _newPasswordTextBox.Bottom + inputToHelperSpacing;
            }

            if (_strengthLabel != null)
            {
                _strengthLabel.Left = centerX;
                _strengthLabel.Width = ContentWidth;
                _strengthLabel.Top = currentY;

                if (_strengthLabel.Visible && _strengthLabel.Height > 0)
                {
                    currentY = _strengthLabel.Bottom + helperSpacingVisible;
                }
                else
                {
                    currentY += helperSpacingHidden;
                }
            }
            else
            {
                currentY += helperSpacingHidden;
            }

            if (_confirmPasswordLabel != null)
            {
                _confirmPasswordLabel.Left = centerX;
                _confirmPasswordLabel.Top = currentY;
                _confirmPasswordLabel.Width = ContentWidth;
                currentY = _confirmPasswordLabel.Bottom + labelToInputSpacing;
            }

            if (_confirmPasswordTextBox != null)
            {
                _confirmPasswordTextBox.Left = centerX;
                _confirmPasswordTextBox.Top = currentY;
                currentY = _confirmPasswordTextBox.Bottom + inputsSpacing;
            }

            if (_errorLabel != null)
            {
                _errorLabel.Left = centerX;
                _errorLabel.Width = ContentWidth;
                _errorLabel.Top = currentY;

                if (_errorLabel.Visible && _errorLabel.Height > 0)
                {
                    currentY = _errorLabel.Bottom + errorSpacingVisible;
                }
                else
                {
                    currentY += errorSpacingHidden;
                }
            }

            if (_completeButton != null)
            {
                _completeButton.Left = centerX;
                _completeButton.Top = currentY;
                currentY = _completeButton.Bottom + buttonSpacing;
            }

            if (_backLink != null)
            {
                _backLink.Left = CenterContentX(_mainPanel.Width, _backLink.Width);
                _backLink.Top = currentY;
                currentY = _backLink.Bottom + bottomPadding;
            }

            _mainPanel.Height = currentY;
            CenterControl(_mainPanel);
        }

        private void ClearErrorDisplay()
        {
            if (_errorLabel == null)
            {
                return;
            }

            if (!_errorLabel.Visible && string.IsNullOrEmpty(_errorLabel.Text))
            {
                return;
            }

            _errorLabel.Visible = false;
            _errorLabel.Text = string.Empty;
            _errorLabel.Height = 0;

            ReflowLayout();
        }

        private int MeasureLabelHeight(Label label, string message)
        {
            if (label == null || string.IsNullOrEmpty(message))
            {
                return 0;
            }

            Size proposedSize = new Size(ContentWidth, int.MaxValue);
            Size measuredSize = TextRenderer.MeasureText(
                message,
                label.Font,
                proposedSize,
                TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);

            return Math.Max(measuredSize.Height, label.Font.Height);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_strengthLabel == null)
            {
                return;
            }

            TextBox passwordTextBox = sender as TextBox;
            if (passwordTextBox == null)
            {
                return;
            }

            string password = passwordTextBox.Text;
            if (string.IsNullOrEmpty(password))
            {
                _strengthLabel.Text = string.Empty;
                _strengthLabel.ForeColor = Color.FromArgb(180, 180, 180);
                _strengthLabel.Visible = false;
                _strengthLabel.Height = 0;
                ReflowLayout();
                return;
            }

            int strength = CalculatePasswordStrength(password);
            if (strength <= 2)
            {
                _strengthLabel.Text = "M\u1EADt kh\u1EA9u y\u1EBFu";
                _strengthLabel.ForeColor = Color.FromArgb(255, 107, 107);
            }
            else if (strength <= 4)
            {
                _strengthLabel.Text = "M\u1EADt kh\u1EA9u trung b\u00ECnh";
                _strengthLabel.ForeColor = Color.FromArgb(255, 211, 61);
            }
            else
            {
                _strengthLabel.Text = "M\u1EADt kh\u1EA9u m\u1EA1nh";
                _strengthLabel.ForeColor = Color.FromArgb(107, 207, 127);
            }

            _strengthLabel.Visible = true;
            _strengthLabel.Height = MeasureLabelHeight(_strengthLabel, _strengthLabel.Text);
            ReflowLayout();
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

        private bool IsStrongPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return password.Length >= 8 &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]");
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (_newPasswordTextBox == null || _confirmPasswordTextBox == null)
            {
                return;
            }

            string newPassword = _newPasswordTextBox.Text;
            string confirmPassword = _confirmPasswordTextBox.Text;

            ClearErrorDisplay();
            ResetValidationStates(_newPasswordTextBox, _confirmPasswordTextBox);

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u1EADt kh\u1EA9u m\u1EDBi", _newPasswordTextBox);
                _newPasswordTextBox.Focus();
                return;
            }

            if (!IsStrongPassword(newPassword))
            {
                ShowError("M\u1EADt kh\u1EA9u m\u1EDBi ph\u1EA3i \u0111\u1EE7 m\u1EA1nh (>=8 k\u00FD t\u1EF1, c\u00F3 ch\u1EEF hoa, ch\u1EEF th\u01B0\u1EDDng, ch\u1EEF s\u1ED1 v\u00E0 k\u00FD t\u1EF1 \u0111\u1EB7c bi\u1EC7t)", _newPasswordTextBox);
                _newPasswordTextBox.Focus();
                return;
            }
            SetValidationState(_newPasswordTextBox, ValidationState.Success);

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowError("Vui l\u00F2ng x\u00E1c nh\u1EADn m\u1EADt kh\u1EA9u m\u1EDBi", _confirmPasswordTextBox);
                _confirmPasswordTextBox.Focus();
                return;
            }

            if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ShowError("M\u1EADt kh\u1EA9u x\u00E1c nh\u1EADn kh\u00F4ng kh\u1EDBp", _newPasswordTextBox, _confirmPasswordTextBox);
                _confirmPasswordTextBox.Focus();
                return;
            }
            SetValidationState(_confirmPasswordTextBox, ValidationState.Success);

            try
            {
                UpdatePassword(userEmail, newPassword);

                MessageBox.Show("\u0110\u1EB7t l\u1EA1i m\u1EADt kh\u1EA9u th\u00E0nh c\u00F4ng! Vui l\u00F2ng \u0111\u0103ng nh\u1EADp l\u1EA1i.", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ShowNextForm<LoginContentForm>();
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i: {ex.Message}", _newPasswordTextBox, _confirmPasswordTextBox);
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
            if (_errorLabel != null)
            {
                _errorLabel.Text = message;
                _errorLabel.Visible = true;
                _errorLabel.Height = MeasureLabelHeight(_errorLabel, message);
                ReflowLayout();
            }

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
            ClearErrorDisplay();

            if (_strengthLabel != null)
            {
                _strengthLabel.Text = string.Empty;
                _strengthLabel.ForeColor = Color.FromArgb(180, 180, 180);
                _strengthLabel.Visible = false;
                _strengthLabel.Height = 0;
            }

            if (_newPasswordTextBox != null)
            {
                _newPasswordTextBox.Text = string.Empty;
            }

            if (_confirmPasswordTextBox != null)
            {
                _confirmPasswordTextBox.Text = string.Empty;
            }

            ResetValidationStates(_newPasswordTextBox, _confirmPasswordTextBox);

            if (_completeButton != null)
            {
                AcceptButton = _completeButton;
            }

            if (_newPasswordTextBox != null)
            {
                ActiveControl = _newPasswordTextBox;
                _newPasswordTextBox.Focus();
            }

            ReflowLayout();
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
