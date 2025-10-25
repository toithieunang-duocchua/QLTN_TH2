using System;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormVerification : ThemedForm
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly string userEmail;
        private readonly EmailVerificationService verificationService = new EmailVerificationService();
        private Panel _mainPanel;
        private Label _titleLabel;
        private Label _instructionLabel;
        private Label _noteLabel;
        private Label _codeLabel;
        private StyledTextBox _codeTextBox;
        private Button _verifyButton;
        private LinkLabel _resendLink;
        private LinkLabel _backLink;
        private Label _errorLabel;

        public FormVerification(string email)
        {
            userEmail = email;
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "Đăng nhập - Xác minh";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            _mainPanel = CreateSurfacePanel(new Size(400, 380));
            _mainPanel.Anchor = AnchorStyles.None;
            _mainPanel.MinimumSize = new Size(400, 0);
            _mainPanel.MaximumSize = new Size(400, int.MaxValue);
            Controls.Add(_mainPanel);
            AttachCentering(_mainPanel);

            _titleLabel = new Label
            {
                Text = "Xác minh",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(_mainPanel.Width, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_titleLabel);

            _instructionLabel = new Label
            {
                Text = "Chúng tôi đã gửi mã xác thực đến email của bạn.\nVui lòng kiểm tra và nhập mã bên dưới.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Size = new Size(ContentWidth, 0),
                MaximumSize = new Size(ContentWidth, 0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_instructionLabel);

            _noteLabel = new Label
            {
                Text = "Lưu ý: Mã chỉ có hiệu lực trong vòng 5 phút.",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 107, 107),
                Size = new Size(ContentWidth, 0),
                MaximumSize = new Size(ContentWidth, 0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _mainPanel.Controls.Add(_noteLabel);

            _codeLabel = CreateCenteredLabel("Mã xác minh", _mainPanel.Width, 0);
            _mainPanel.Controls.Add(_codeLabel);

            _codeTextBox = new StyledTextBox
            {
                Name = "txtCode",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                MaxLength = 6,
                TextAlign = HorizontalAlignment.Center
            };
            StyleInputTextBox(_codeTextBox);
            _codeTextBox.TextChanged += CodeTextBox_TextChanged;
            _mainPanel.Controls.Add(_codeTextBox);

            _verifyButton = new Button
            {
                Name = "btnVerify",
                Text = "Xác minh",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(_verifyButton);
            _verifyButton.Click += BtnVerify_Click;
            _mainPanel.Controls.Add(_verifyButton);
            AcceptButton = _verifyButton;

            _resendLink = CreateLinkLabel("Gửi lại mã xác minh", 0, _mainPanel.Width);
            _resendLink.Name = "lnkResend";
            _resendLink.Click += ResendLink_Click;
            _mainPanel.Controls.Add(_resendLink);

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

            ActiveControl = _codeTextBox;
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

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_codeTextBox == null)
            {
                return;
            }

            string digitsOnly = Regex.Replace(_codeTextBox.Text, @"[^\d]", string.Empty);
            if (digitsOnly != _codeTextBox.Text)
            {
                int caret = _codeTextBox.SelectionStart - (_codeTextBox.Text.Length - digitsOnly.Length);
                _codeTextBox.Text = digitsOnly;
                _codeTextBox.SelectionStart = Math.Max(caret, 0);
            }

            SetValidationState(_codeTextBox, ValidationState.Neutral);
            ClearErrorDisplay();
        }

        private async void BtnVerify_Click(object sender, EventArgs e)
        {
            if (_codeTextBox == null)
            {
                return;
            }

            string code = _codeTextBox.Text?.Trim() ?? string.Empty;

            ClearErrorDisplay();
            ResetValidationStates(_codeTextBox);

            if (string.IsNullOrEmpty(code))
            {
                ShowError("Vui lòng nhập mã xác minh", _codeTextBox);
                _codeTextBox.Focus();
                return;
            }

            if (code.Length != 6)
            {
                ShowError("Mã xác minh phải có 6 chữ số", _codeTextBox);
                _codeTextBox.Focus();
                return;
            }

            Cursor previousCursor = Cursor;

            try
            {
                if (_verifyButton != null)
                {
                    _verifyButton.Enabled = false;
                }

                Cursor = Cursors.WaitCursor;

                EmailVerificationService.VerificationStatus status =
                    await verificationService.VerifyCodeAsync(userEmail, code);

                switch (status)
                {
                    case EmailVerificationService.VerificationStatus.Success:
                        SetValidationState(_codeTextBox, ValidationState.Success);
                        MessageBox.Show("Xác minh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowNextForm(new FormResetPassword(userEmail));
                        break;
                    case EmailVerificationService.VerificationStatus.NotRequested:
                        ShowError("Không tìm thấy yêu cầu xác thực. Vui lòng gửi lại mã.", _codeTextBox);
                        _codeTextBox.Focus();
                        break;
                    case EmailVerificationService.VerificationStatus.Expired:
                        ShowError("Mã xác minh đã hết hạn. Vui lòng gửi lại mã.", _codeTextBox);
                        _codeTextBox.Focus();
                        break;
                    default:
                        ShowError("Mã xác minh không chính xác", _codeTextBox);
                        _codeTextBox.Focus();
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message, _codeTextBox);
                _codeTextBox.Focus();
            }
            catch (Exception ex)
            {
                ShowError($"Không thể xác minh mã: {ex.Message}", _codeTextBox);
                _codeTextBox.Focus();
            }
            finally
            {
                Cursor = previousCursor;
                if (_verifyButton != null)
                {
                    _verifyButton.Enabled = true;
                }
            }
        }

        private async void ResendLink_Click(object sender, EventArgs e)
        {
            if (_codeTextBox != null)
            {
                _codeTextBox.Text = string.Empty;
                ResetValidationStates(_codeTextBox);
            }

            ClearErrorDisplay();

            Cursor previousCursor = Cursor;

            try
            {
                if (_resendLink != null)
                {
                    _resendLink.Enabled = false;
                }
                Cursor = Cursors.WaitCursor;

                await verificationService.ResendCodeAsync(userEmail);

                MessageBox.Show("Mã xác minh mới đã được gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ConfigurationErrorsException ex)
            {
                ShowError($"Cấu hình email chưa đầy đủ: {ex.Message}", _codeTextBox);
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message, _codeTextBox);
            }
            catch (Exception ex)
            {
                ShowError($"Không thể gửi mã xác thực: {ex.Message}", _codeTextBox);
            }
            finally
            {
                Cursor = previousCursor;
                if (_resendLink != null)
                {
                    _resendLink.Enabled = true;
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

            const int panelTopPadding = 36;
            const int titleSpacing = 48;
            const int instructionSpacing = 14;
            const int noteSpacing = 18;
            const int labelToInputSpacing = 6;
            const int buttonSpacing = 22;
            const int linkSpacing = 14;
            const int errorSpacingVisible = 18;
            const int errorSpacingHidden = 10;
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

            if (_instructionLabel != null)
            {
                _instructionLabel.Left = centerX;
                _instructionLabel.Width = ContentWidth;
                _instructionLabel.Top = currentY;
                _instructionLabel.Height = MeasureLabelHeight(_instructionLabel, _instructionLabel.Text);
                currentY = _instructionLabel.Bottom + instructionSpacing;
            }

            if (_noteLabel != null)
            {
                _noteLabel.Left = centerX;
                _noteLabel.Width = ContentWidth;
                _noteLabel.Top = currentY;
                _noteLabel.Height = MeasureLabelHeight(_noteLabel, _noteLabel.Text);
                currentY = _noteLabel.Bottom + noteSpacing;
            }

            if (_codeLabel != null)
            {
                _codeLabel.Left = centerX;
                _codeLabel.Width = ContentWidth;
                _codeLabel.Top = currentY;
                currentY = _codeLabel.Bottom + labelToInputSpacing;
            }

            if (_codeTextBox != null)
            {
                _codeTextBox.Left = centerX;
                _codeTextBox.Top = currentY;
                currentY = _codeTextBox.Bottom + buttonSpacing;
            }

            if (_verifyButton != null)
            {
                _verifyButton.Left = centerX;
                _verifyButton.Top = currentY;
                currentY = _verifyButton.Bottom + linkSpacing;
            }

            if (_resendLink != null)
            {
                _resendLink.Left = CenterContentX(_mainPanel.Width, _resendLink.Width);
                _resendLink.Top = currentY;
                currentY = _resendLink.Bottom + linkSpacing;
            }

            if (_backLink != null)
            {
                _backLink.Left = CenterContentX(_mainPanel.Width, _backLink.Width);
                _backLink.Top = currentY;
                currentY = _backLink.Bottom + linkSpacing;
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

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // FormVerification
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 576);
            Name = "FormVerification";
            Text = "Xác minh";
            ResumeLayout(false);
        }
    }
}
