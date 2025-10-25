using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class LoginContentForm : ThemedForm, IAuthView
    {
        /// <summary>
        /// Event được gọi khi login thành công
        /// </summary>
        public static event Action<User> OnLoginSuccess;
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly UserService userService = new UserService();
        private Panel _mainPanel;
        private Label _titleLabel;
        private Label _phoneLabel;
        private StyledTextBox _phoneTextBox;
        private Label _passwordLabel;
        private StyledTextBox _passwordTextBox;
        private Button _loginButton;
        private LinkLabel _forgotPasswordLink;
        private LinkLabel _registerLink;
        private Label _errorLabel;

        public LoginContentForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "Đăng nhập - Hệ thống QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            _mainPanel = CreateSurfacePanel(new Size(420, 400));
            _mainPanel.Anchor = AnchorStyles.None;
            _mainPanel.MinimumSize = new Size(420, 0);
            _mainPanel.MaximumSize = new Size(420, int.MaxValue);
            Controls.Add(_mainPanel);
            AttachCentering(_mainPanel);

            _titleLabel = new Label
            {
                Text = "Đăng nhập",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(_mainPanel.Width, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_titleLabel);

            _phoneLabel = CreateCenteredLabel("Số điện thoại", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_phoneLabel);

            _phoneTextBox = new StyledTextBox
            {
                Name = "txtPhone",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                MaxLength = 10
            };
            StyleInputTextBox(_phoneTextBox);
            _phoneTextBox.TextChanged += PhoneTextBox_TextChanged;
            _mainPanel.Controls.Add(_phoneTextBox);

            _passwordLabel = CreateCenteredLabel("Mật khẩu", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_passwordLabel);

            _passwordTextBox = new StyledTextBox
            {
                Name = "txtPassword",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                UseSystemPasswordChar = true
            };
            StyleInputTextBox(_passwordTextBox);
            _passwordTextBox.TextChanged += (s, e) =>
            {
                SetValidationState(_passwordTextBox, ValidationState.Neutral);
                ClearErrorDisplay();
            };
            _mainPanel.Controls.Add(_passwordTextBox);

            _loginButton = new Button
            {
                Name = "btnLogin",
                Text = "Đăng nhập",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(_loginButton);
            _loginButton.Click += BtnLogin_Click;
            _mainPanel.Controls.Add(_loginButton);
            AcceptButton = _loginButton;

            _forgotPasswordLink = CreateLinkLabel("Bạn quên mật khẩu?", 0, _mainPanel.Width);
            _forgotPasswordLink.Click += (s, e) => ShowNextForm<FormForgotPassword>();
            _mainPanel.Controls.Add(_forgotPasswordLink);

            _registerLink = CreateLinkLabel("Tạo tài khoản", 0, _mainPanel.Width);
            _registerLink.Click += (s, e) => ShowNextForm<FormRegister>();
            _mainPanel.Controls.Add(_registerLink);

            _errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 0),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            _mainPanel.Controls.Add(_errorLabel);

            ReflowLayout();

            ActiveControl = _phoneTextBox;
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

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_phoneTextBox == null)
            {
                return;
            }

            string digitsOnly = Regex.Replace(_phoneTextBox.Text, @"[^\d]", string.Empty);
            if (digitsOnly != _phoneTextBox.Text)
            {
                int caret = _phoneTextBox.SelectionStart - (_phoneTextBox.Text.Length - digitsOnly.Length);
                _phoneTextBox.Text = digitsOnly;
                _phoneTextBox.SelectionStart = Math.Max(caret, 0);
            }

            SetValidationState(_phoneTextBox, ValidationState.Neutral);
            ClearErrorDisplay();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_phoneTextBox == null || _passwordTextBox == null)
            {
                return;
            }

            string phone = _phoneTextBox.Text?.Trim() ?? string.Empty;
            string password = _passwordTextBox.Text ?? string.Empty;

            ClearErrorDisplay();
            ResetValidationStates(_phoneTextBox, _passwordTextBox);

            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowError("Vui lòng nhập số điện thoại", _phoneTextBox);
                _phoneTextBox.Focus();
                return;
            }

            if (phone.Length != 10)
            {
                ShowError("Số điện thoại phải có 10 chữ số", _phoneTextBox);
                _phoneTextBox.Focus();
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                ShowError("Số điện thoại chỉ bao gồm chữ số", _phoneTextBox);
                _phoneTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Vui lòng nhập mật khẩu", _passwordTextBox);
                _passwordTextBox.Focus();
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
                    // Lấy thông tin user từ database
                    User user = userService.GetUserByPhone(phone);
                    if (user != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetValidationState(_passwordTextBox, ValidationState.Success);
                        
                        // Gọi event để thông báo login thành công
                        OnLoginSuccess?.Invoke(user);
                    }
                    else
                    {
                        ShowError("Không thể lấy thông tin người dùng", _phoneTextBox, _passwordTextBox);
                    }
                }
                else
                {
                    ShowError("Số điện thoại hoặc mật khẩu không chính xác", _phoneTextBox, _passwordTextBox);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi xác thực: {ex.Message}", _phoneTextBox, _passwordTextBox);
            }
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

        private void ReflowLayout()
        {
            if (_mainPanel == null)
            {
                return;
            }

            const int panelTopPadding = 36;
            const int titleSpacing = 60;
            const int labelToInputSpacing = 10;
            const int sectionSpacing = 26;
            const int buttonSpacing = 24;
            const int linkSpacing = 16;
            const int errorSpacingVisible = 18;
            const int errorSpacingHidden = 12;
            const int bottomPadding = 30;

            int currentY = panelTopPadding;
            int centerX = CenterContentX(_mainPanel.Width, ContentWidth);

            if (_titleLabel != null)
            {
                _titleLabel.Left = 0;
                _titleLabel.Width = _mainPanel.Width;
                _titleLabel.Top = currentY;
                currentY += _titleLabel.Height + titleSpacing;
            }

            if (_phoneLabel != null)
            {
                _phoneLabel.Left = centerX;
                _phoneLabel.Width = ContentWidth;
                _phoneLabel.Top = currentY;
                currentY = _phoneLabel.Bottom + labelToInputSpacing;
            }

            if (_phoneTextBox != null)
            {
                _phoneTextBox.Left = centerX;
                _phoneTextBox.Top = currentY;
                currentY = _phoneTextBox.Bottom + sectionSpacing;
            }

            if (_passwordLabel != null)
            {
                _passwordLabel.Left = centerX;
                _passwordLabel.Width = ContentWidth;
                _passwordLabel.Top = currentY;
                currentY = _passwordLabel.Bottom + labelToInputSpacing;
            }

            if (_passwordTextBox != null)
            {
                _passwordTextBox.Left = centerX;
                _passwordTextBox.Top = currentY;
                currentY = _passwordTextBox.Bottom + buttonSpacing;
            }

            if (_loginButton != null)
            {
                _loginButton.Left = centerX;
                _loginButton.Top = currentY;
                currentY = _loginButton.Bottom + linkSpacing;
            }

            if (_forgotPasswordLink != null)
            {
                _forgotPasswordLink.Left = CenterContentX(_mainPanel.Width, _forgotPasswordLink.Width);
                _forgotPasswordLink.Top = currentY;
                currentY = _forgotPasswordLink.Bottom + linkSpacing;
            }

            if (_registerLink != null)
            {
                _registerLink.Left = CenterContentX(_mainPanel.Width, _registerLink.Width);
                _registerLink.Top = currentY;
                currentY = _registerLink.Bottom + linkSpacing;
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

            currentY += bottomPadding;

            _mainPanel.Height = currentY;
            CenterControl(_mainPanel);
        }

        private static int MeasureLabelHeight(Label label, string message)
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

        private void ShowNextForm<TForm>() where TForm : Form, new()
        {
            AuthNavigationManager.Navigate<TForm>(this);
        }

        private void ShowNextForm(Form form)
        {
            if (form == null)
            {
                return;
            }

            if (form is FormMainSystem)
            {
                // Navigate the main system into the current host panel so there is no separate top-level window
                AuthNavigationManager.Navigate<FormMainSystem>(this);
                return;
            }

            AuthNavigationManager.Navigate(form, this);
        }

        void IAuthView.PrepareForDisplay()
        {
            ClearErrorDisplay();

            if (_phoneTextBox != null)
            {
                _phoneTextBox.Text = string.Empty;
            }

            if (_passwordTextBox != null)
            {
                _passwordTextBox.Text = string.Empty;
            }

            ResetValidationStates(_phoneTextBox, _passwordTextBox);

            if (_loginButton != null)
            {
                AcceptButton = _loginButton;
            }

            if (_phoneTextBox != null)
            {
                ActiveControl = _phoneTextBox;
                _phoneTextBox.Focus();
            }

            ReflowLayout();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // LoginContentForm
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "LoginContentForm";
            Text = "Đăng nhập";
            ResumeLayout(false);
        }
    }
}
