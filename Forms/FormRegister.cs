using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormRegister : ThemedForm, IAuthView
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);

        private readonly UserService userService = new UserService();

        private StyledTextBox nameTextBox;
        private StyledTextBox phoneTextBox;
        private StyledTextBox emailTextBox;
        private StyledTextBox passwordTextBox;
        private Label strengthLabel;
        private LargeRadioButton maleRadio;
        private LargeRadioButton femaleRadio;
        private CheckBox termsCheckbox;
        private Button registerButton;
        private LinkLabel backLinkLabel;
        private Label errorLabel;

        public FormRegister()
        {
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "Đăng ký - Hệ thống QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            FlowLayoutPanel flow = CreateCenteredContentPanel(
                width: 400,
                out _,
                padding: new Padding(32, 18, 32, 18),
                heightRatio: 0.96);

            Label titleLabel = new Label
            {
                Text = "Đăng ký",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(ContentWidth, 40),
                Margin = new Padding(0, 0, 0, 10)
            };
            flow.Controls.Add(titleLabel);

            nameTextBox = CreateInput("txtName");
            flow.Controls.Add(CreateFieldGroup("Họ tên", nameTextBox, ContentWidth, bottomMargin: 8));

            phoneTextBox = CreateInput("txtPhone");
            phoneTextBox.MaxLength = 10;
            phoneTextBox.TextChanged += PhoneTextBox_TextChanged;
            flow.Controls.Add(CreateFieldGroup("Số điện thoại", phoneTextBox, ContentWidth, bottomMargin: 8));

            emailTextBox = CreateInput("txtEmail");
            flow.Controls.Add(CreateFieldGroup("Email", emailTextBox, ContentWidth, bottomMargin: 8));

            passwordTextBox = CreateInput("txtPassword");
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += PasswordTextBox_TextChanged;
            flow.Controls.Add(CreateFieldGroup("Mật khẩu", passwordTextBox, ContentWidth, bottomMargin: 8));

            strengthLabel = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(ContentWidth, 0),
                ForeColor = SecondaryTextColor,
                Visible = false,
                Margin = new Padding(0, 0, 0, 8)
            };
            flow.Controls.Add(strengthLabel);

            FlowLayoutPanel genderPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 8)
            };

            maleRadio = new LargeRadioButton
            {
                Name = "rbMale",
                Text = "Nam",
                Font = new Font("Segoe UI", 12),
                GlyphSize = 22,
                Margin = new Padding(0, 0, 30, 0),
                ForeColor = Color.White,
                Checked = true
            };
            genderPanel.Controls.Add(maleRadio);

            femaleRadio = new LargeRadioButton
            {
                Name = "rbFemale",
                Text = "Nữ",
                Font = new Font("Segoe UI", 12),
                GlyphSize = 22,
                Margin = new Padding(0, 0, 0, 8),
                ForeColor = Color.White
            };
            genderPanel.Controls.Add(femaleRadio);

            flow.Controls.Add(genderPanel);

            Panel termsPanel = BuildTermsPanel();
            termsPanel.Margin = new Padding(0, 0, 0, 8);
            termsCheckbox = termsPanel.Controls[0] as CheckBox;
            flow.Controls.Add(termsPanel);

            registerButton = new Button
            {
                Name = "btnRegister",
                Text = "Đăng ký",
                Size = new Size(ContentWidth, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2),
                Margin = new Padding(0, 0, 0, 8)
            };
            StylePrimaryButton(registerButton);
            registerButton.Click += BtnRegister_Click;
            flow.Controls.Add(registerButton);
            AcceptButton = registerButton;

            backLinkLabel = new LinkLabel
            {
                Text = "Quay lại đăng nhập",
                Font = new Font("Segoe UI", 10),
                AutoSize = false,
                Size = new Size(ContentWidth, 20),
                LinkBehavior = LinkBehavior.HoverUnderline,
                LinkColor = SecondaryTextColor,
                ActiveLinkColor = Color.White,
                VisitedLinkColor = SecondaryTextColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0, 0, 0, 4)
            };
            backLinkLabel.Click += (s, e) => ShowNextForm<LoginContentForm>();
            flow.Controls.Add(backLinkLabel);

            errorLabel = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(ContentWidth, 0),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false,
                Margin = new Padding(0)
            };
            flow.Controls.Add(errorLabel);

            ActiveControl = nameTextBox;
        }

        private StyledTextBox CreateInput(string name)
        {
            StyledTextBox textBox = new StyledTextBox
            {
                Name = name,
                Font = new Font("Segoe UI", 11),
                Size = new Size(ContentWidth, 36),
                Margin = new Padding(0)
            };
            StyleInputTextBox(textBox);
            textBox.TextChanged += (s, _) => SetValidationState((TextBox)s, ValidationState.Neutral);
            return textBox;
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            string digits = Regex.Replace(phoneTextBox.Text, "[^0-9]", string.Empty);
            if (digits != phoneTextBox.Text)
            {
                int caret = phoneTextBox.SelectionStart - (phoneTextBox.Text.Length - digits.Length);
                phoneTextBox.Text = digits;
                phoneTextBox.SelectionStart = Math.Max(caret, 0);
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                strengthLabel.Visible = false;
                strengthLabel.Text = string.Empty;
                SetValidationState(passwordTextBox, ValidationState.Neutral);
                return;
            }

            int strength = CalculatePasswordStrength(password);
            if (strength <= 2)
            {
                strengthLabel.Text = "Mật khẩu yếu";
                strengthLabel.ForeColor = Color.FromArgb(255, 107, 107);
            }
            else if (strength <= 4)
            {
                strengthLabel.Text = "Mật khẩu trung bình";
                strengthLabel.ForeColor = Color.FromArgb(255, 211, 61);
            }
            else
            {
                strengthLabel.Text = "Mật khẩu mạnh";
                strengthLabel.ForeColor = Color.FromArgb(107, 207, 127);
            }

            strengthLabel.Visible = true;
        }

        private int CalculatePasswordStrength(string password)
        {
            int strength = 0;
            if (password.Length >= 8) strength++;
            if (password.Length >= 12) strength++;
            if (Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")) strength++;
            if (Regex.IsMatch(password, "[0-9]")) strength++;
            if (Regex.IsMatch(password, "[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?]")) strength++;
            return strength;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            ResetValidationStates(nameTextBox, phoneTextBox, emailTextBox, passwordTextBox);

            string name = nameTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string gender = maleRadio.Checked ? "Nam" : femaleRadio.Checked ? "Nữ" : string.Empty;
            bool acceptedTerms = termsCheckbox?.Checked ?? false;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError("Vui lòng nhập họ tên", nameTextBox);
                nameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowError("Vui lòng nhập số điện thoại", phoneTextBox);
                phoneTextBox.Focus();
                return;
            }

            if (phone.Length != 10 || !phone.StartsWith("0"))
            {
                ShowError("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0", phoneTextBox);
                phoneTextBox.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                ShowError("Email không hợp lệ", emailTextBox);
                emailTextBox.Focus();
                return;
            }

            if (CalculatePasswordStrength(password) <= 2)
            {
                ShowError("Mật khẩu phải có ít nhất 8 ký tự, gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt", passwordTextBox);
                passwordTextBox.Focus();
                return;
            }

            if (!acceptedTerms)
            {
                ShowError("Vui lòng đồng ý điều khoản sử dụng");
                return;
            }

            try
            {
                if (userService.IsPhoneRegistered(phone))
                {
                    ShowError("Số điện thoại đã được đăng ký", phoneTextBox);
                    phoneTextBox.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(email) && userService.IsEmailRegistered(email))
                {
                    ShowError("Email đã được đăng ký", emailTextBox);
                    emailTextBox.Focus();
                    return;
                }

                RegisterRequest request = new RegisterRequest
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Password = password,
                    Gender = gender,
                    TermsAccepted = acceptedTerms
                };

                userService.RegisterUser(request);

                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowNextForm<LoginContentForm>();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
        }

        private void ShowError(string message, params TextBox[] inputs)
        {
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
            errorLabel.Visible = false;
            errorLabel.Text = string.Empty;

            nameTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            maleRadio.Checked = true;
            femaleRadio.Checked = false;
            termsCheckbox.Checked = false;

            strengthLabel.Visible = false;
            strengthLabel.Text = string.Empty;

            ResetValidationStates(nameTextBox, phoneTextBox, emailTextBox, passwordTextBox);

            ActiveControl = nameTextBox;
        }

        private Panel BuildTermsPanel()
        {
            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MaximumSize = new Size(ContentWidth, 0),
                BackColor = Color.Transparent
            };

            CheckBox checkBox = new CheckBox
            {
                AutoSize = false,
                Size = new Size(24, 24),
                Location = new Point(0, 2),
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Cursor = Cursors.Hand
            };
            panel.Controls.Add(checkBox);

            FlowLayoutPanel links = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MaximumSize = new Size(ContentWidth - checkBox.Width - 10, 0),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Location = new Point(checkBox.Right + 10, 0),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            links.Controls.Add(CreateTermLabel("Tôi đã đọc và đồng ý các "));
            LinkLabel contractLink = CreateTermLink("điều khoản hợp đồng");
            contractLink.LinkClicked += (s, _) => MessageBox.Show(GetContractTermsContent(), "Điều khoản hợp đồng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            links.Controls.Add(contractLink);
            links.Controls.Add(CreateTermLabel(" và các "));
            LinkLabel softwareLink = CreateTermLink("điều khoản phần mềm sử dụng.");
            softwareLink.LinkClicked += (s, _) => MessageBox.Show(GetSoftwareTermsContent(), "Điều khoản phần mềm sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            links.Controls.Add(softwareLink);

            panel.Controls.Add(links);
            return panel;
        }

        private Label CreateTermLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9),
                ForeColor = SecondaryTextColor,
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private LinkLabel CreateTermLink(string text)
        {
            return new LinkLabel
            {
                Text = text,
                Font = new Font("Segoe UI", 9),
                LinkColor = Color.FromArgb(0, 191, 255),
                ActiveLinkColor = Color.FromArgb(30, 144, 255),
                VisitedLinkColor = Color.FromArgb(0, 191, 255),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
        }

        private string GetContractTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Phạm vi áp dụng: Áp dụng cho tất cả người dùng đăng ký và sử dụng dịch vụ.",
                "2. Quyền và nghĩa vụ: Người dùng cung cấp thông tin chính xác, bảo mật tài khoản và tuân thủ pháp luật.",
                "3. Quyền sở hữu: Nội dung, thương hiệu thuộc quyền sở hữu của công ty.",
                "4. Chính sách bảo mật: Bảo vệ thông tin cá nhân theo quy định pháp luật.",
                "5. Thanh toán: Thanh toán đầy đủ các khoản phí theo thỏa thuận.",
                "6. Chấm dứt hợp đồng: Thực hiện theo thỏa thuận hoặc quy định pháp luật.",
                "7. Giải quyết tranh chấp: Thương lượng hoặc tuân theo pháp luật Việt Nam.");
        }

        private string GetSoftwareTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Giấy phép sử dụng: Cấp phép không độc quyền theo điều khoản.",
                "2. Hạn chế sử dụng: Không sao chép, sửa đổi hoặc phân phối khi chưa được phép.",
                "3. Cập nhật phần mềm: Có thể cập nhật, nâng cấp phần mềm mà không cần báo trước.",
                "4. Trách nhiệm người dùng: Chịu trách nhiệm về việc sử dụng và dữ liệu tạo ra.",
                "5. Bảo mật: Không sử dụng phần mềm cho mục đích bất hợp pháp hoặc xâm phạm quyền lợi bên thứ ba.",
                "6. Hỗ trợ kỹ thuật: Hỗ trợ trong giờ hành chính theo quy định.",
                "7. Miễn trừ trách nhiệm: Không chịu trách nhiệm về thiệt hại gián tiếp phát sinh.");
        }
    }
}
