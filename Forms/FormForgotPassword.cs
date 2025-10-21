using System;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormForgotPassword : ThemedForm, IAuthView
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly UserService userService = new UserService();
        private readonly EmailVerificationService verificationService = new EmailVerificationService();
        private Panel _mainPanel;
        private Label _titleLabel;
        private Label _instructionsLabel;
        private Label _emailLabel;
        private StyledTextBox _emailTextBox;
        private Button _nextButton;
        private LinkLabel _backLink;
        private Label _errorLabel;

        public FormForgotPassword()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "Quên mật khẩu - Hệ thống QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            _mainPanel = CreateSurfacePanel(new Size(420, 320));
            _mainPanel.Anchor = AnchorStyles.None;
            _mainPanel.MinimumSize = new Size(420, 0);
            _mainPanel.MaximumSize = new Size(420, int.MaxValue);
            Controls.Add(_mainPanel);
            AttachCentering(_mainPanel);

            _titleLabel = new Label
            {
                Text = "Quên mật khẩu",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(_mainPanel.Width, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_titleLabel);

            _instructionsLabel = new Label
            {
                Text = "Nhập email của bạn để nhận mã xác minh.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Size = new Size(ContentWidth, 0),
                MaximumSize = new Size(ContentWidth, 0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_instructionsLabel);

            _emailLabel = CreateCenteredLabel("Email của bạn", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_emailLabel);

            _emailTextBox = new StyledTextBox
            {
                Name = "txtEmail",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12)
            };
            StyleInputTextBox(_emailTextBox);
            _emailTextBox.TextChanged += (s, e) =>
            {
                SetValidationState(_emailTextBox, ValidationState.Neutral);
                ClearErrorDisplay();
            };
            _mainPanel.Controls.Add(_emailTextBox);

            _nextButton = new Button
            {
                Name = "btnNext",
                Text = "Tiếp theo",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(_nextButton);
            _nextButton.Click += BtnNext_Click;
            _mainPanel.Controls.Add(_nextButton);
            AcceptButton = _nextButton;

            _backLink = CreateLinkLabel("Quay lại đăng nhập", 0, _mainPanel.Width);
            _backLink.Click += (s, e) => ShowNextForm<LoginContentForm>();
            _mainPanel.Controls.Add(_backLink);

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

            ActiveControl = _emailTextBox;
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

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            if (_emailTextBox == null)
            {
                return;
            }

            string email = _emailTextBox.Text?.Trim() ?? string.Empty;

            ClearErrorDisplay();
            ResetValidationStates(_emailTextBox);

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError("Vui lòng nhập email của bạn", _emailTextBox);
                _emailTextBox.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Email không hợp lệ", _emailTextBox);
                _emailTextBox.Focus();
                return;
            }

            Cursor previousCursor = Cursor;

            try
            {
                if (!userService.IsEmailRegistered(email))
                {
                    ShowError("Email không tồn tại trong hệ thống", _emailTextBox);
                    SetValidationState(_emailTextBox, ValidationState.Error);
                    _emailTextBox.Focus();
                    return;
                }

                if (_nextButton != null)
                {
                    _nextButton.Enabled = false;
                }
                Cursor = Cursors.WaitCursor;

                await verificationService.SendVerificationCodeAsync(email);

                SetValidationState(_emailTextBox, ValidationState.Success);

                MessageBox.Show("Mã xác thực đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowNextForm(new FormVerification(email));
            }
            catch (ConfigurationErrorsException ex)
            {
                ShowError($"Cấu hình email chưa đầy đủ: {ex.Message}", _emailTextBox);
                SetValidationState(_emailTextBox, ValidationState.Neutral);
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message, _emailTextBox);
                SetValidationState(_emailTextBox, ValidationState.Neutral);
            }
            catch (Exception ex)
            {
                ShowError($"Không thể gửi mã xác thực: {ex.Message}", _emailTextBox);
                SetValidationState(_emailTextBox, ValidationState.Neutral);
            }
            finally
            {
                Cursor = previousCursor;
                if (_nextButton != null)
                {
                    _nextButton.Enabled = true;
                }
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

            const int panelTopPadding = 32;
            const int titleSpacing = 56;
            const int labelToInputSpacing = 8;
            const int inputSpacing = 24;
            const int errorSpacingVisible = 18;
            const int errorSpacingHidden = 12;
            const int buttonSpacing = 20;
            const int bottomPadding = 28;

            int currentY = panelTopPadding;
            int centerX = CenterContentX(_mainPanel.Width, ContentWidth);

            if (_titleLabel != null)
            {
                _titleLabel.Left = 0;
                _titleLabel.Width = _mainPanel.Width;
                _titleLabel.Top = currentY;
                currentY += _titleLabel.Height + titleSpacing;
            }

            if (_instructionsLabel != null)
            {
                _instructionsLabel.Left = centerX;
                _instructionsLabel.Width = ContentWidth;
                _instructionsLabel.Top = currentY;
                _instructionsLabel.Height = MeasureLabelHeight(_instructionsLabel, _instructionsLabel.Text);
                currentY = _instructionsLabel.Bottom + inputSpacing;
            }

            if (_emailLabel != null)
            {
                _emailLabel.Left = centerX;
                _emailLabel.Top = currentY;
                _emailLabel.Width = ContentWidth;
                currentY = _emailLabel.Bottom + labelToInputSpacing;
            }

            if (_emailTextBox != null)
            {
                _emailTextBox.Left = centerX;
                _emailTextBox.Top = currentY;
                currentY = _emailTextBox.Bottom + inputSpacing;
            }

            if (_nextButton != null)
            {
                _nextButton.Left = centerX;
                _nextButton.Top = currentY;
                currentY = _nextButton.Bottom + buttonSpacing;
            }

            if (_backLink != null)
            {
                _backLink.Left = CenterContentX(_mainPanel.Width, _backLink.Width);
                _backLink.Top = currentY;
                currentY = _backLink.Bottom + buttonSpacing;
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
            AuthNavigationManager.Navigate(form, this);
        }

        void IAuthView.PrepareForDisplay()
        {
            ClearErrorDisplay();

            if (_emailTextBox != null)
            {
                _emailTextBox.Text = string.Empty;
                ResetValidationStates(_emailTextBox);
            }

            if (_nextButton != null)
            {
                AcceptButton = _nextButton;
            }

            if (_emailTextBox != null)
            {
                ActiveControl = _emailTextBox;
                _emailTextBox.Focus();
            }

            ReflowLayout();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // FormForgotPassword
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormForgotPassword";
            Text = "Quên mật khẩu";
            ResumeLayout(false);
        }
    }
}
