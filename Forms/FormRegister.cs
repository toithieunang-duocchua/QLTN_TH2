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
        private const int ContentWidth = 360;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly UserService userService = new UserService();

        public FormRegister()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "\u0110\u0103ng k\u00FD - H\u1EC7 th\u1ED1ng QLTN";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            SetupControls();
        }

        private void SetupControls()
        {
            Panel mainPanel = CreateSurfacePanel(new Size(440, 560));
            mainPanel.Anchor = AnchorStyles.None;
            Controls.Add(mainPanel);
            AttachCentering(mainPanel);

            int currentY = 36;
            int contentLeft = CenterContentX(mainPanel.Width, ContentWidth);

            mainPanel.Controls.Add(new Label
            {
                Text = "\u0110\u0103ng k\u00FD",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(mainPanel.Width, 40),
                Location = new Point(0, currentY),
                TextAlign = ContentAlignment.MiddleCenter
            });

            currentY += 60;

            TextBox nameTextBox = AddTextField(mainPanel, "H\u1ECD t\u00EAn", "txtName", ref currentY);

            TextBox phoneTextBox = AddTextField(mainPanel, "S\u1ED1 \u0111i\u1EC7n tho\u1EA1i", "txtPhone", ref currentY, textBox =>
            {
                textBox.MaxLength = 10;
                textBox.TextChanged += (s, e) =>
                {
                    TextBox tb = (TextBox)s;
                    string digitsOnly = Regex.Replace(tb.Text, @"[^\d]", "");
                    if (digitsOnly != tb.Text)
                    {
                        int caret = tb.SelectionStart - (tb.Text.Length - digitsOnly.Length);
                        tb.Text = digitsOnly;
                        tb.SelectionStart = Math.Max(caret, 0);
                    }
                    SetValidationState(tb, ValidationState.Neutral);
                };
            });

            TextBox emailTextBox = AddTextField(mainPanel, "Email", "txtEmail", ref currentY);

            TextBox passwordTextBox = AddTextField(mainPanel, "M\u1EADt kh\u1EA9u", "txtPassword", ref currentY, textBox =>
            {
                textBox.UseSystemPasswordChar = true;
                textBox.TextChanged += PasswordTextBox_TextChanged;
            });

            Label strengthLabel = new Label
            {
                Name = "lblStrength",
                Size = new Size(ContentWidth, 14),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), passwordTextBox.Bottom + 4),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(180, 180, 180),
                TextAlign = ContentAlignment.MiddleLeft
            };
            mainPanel.Controls.Add(strengthLabel);

            currentY = strengthLabel.Bottom + 12;

            FlowLayoutPanel genderPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            LargeRadioButton maleRadio = new LargeRadioButton
            {
                Name = "rbMale",
                Text = "Nam",
                Font = new Font("Segoe UI", 12),
                GlyphSize = 22,
                Margin = new Padding(0, 0, 30, 0),
                ForeColor = Color.White
            };
            genderPanel.Controls.Add(maleRadio);

            LargeRadioButton femaleRadio = new LargeRadioButton
            {
                Name = "rbFemale",
                Text = "N\u1EEF",
                Font = new Font("Segoe UI", 12),
                GlyphSize = 22,
                Margin = new Padding(0),
                ForeColor = Color.White
            };
            genderPanel.Controls.Add(femaleRadio);

            genderPanel.PerformLayout();
            genderPanel.Location = new Point(contentLeft, currentY);
            mainPanel.Controls.Add(genderPanel);

            currentY = genderPanel.Bottom + 12;

            Panel termsPanel = BuildTermsPanel();
            termsPanel.Location = new Point(contentLeft, currentY);
            mainPanel.Controls.Add(termsPanel);

            currentY = termsPanel.Bottom + 12;

            Button registerButton = new Button
            {
                Name = "btnRegister",
                Text = "\u0110\u0103ng k\u00FD",
                Size = new Size(ContentWidth, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(registerButton);
            registerButton.Location = new Point(contentLeft, currentY);
            registerButton.Click += BtnRegister_Click;
            mainPanel.Controls.Add(registerButton);
            AcceptButton = registerButton;

            currentY = registerButton.Bottom + 12;

            LinkLabel backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", currentY, mainPanel.Width);
            backLink.Click += (s, e) =>
            {
                ShowNextForm<LoginContentForm>();
            };
            mainPanel.Controls.Add(backLink);

            currentY = backLink.Bottom + 12;

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

            ActiveControl = nameTextBox;
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

        private TextBox AddTextField(Panel parent, string labelText, string controlName, ref int currentY, Action<TextBox> configure = null)
        {
            Label label = CreateCenteredLabel(labelText, parent.Width, currentY);
            parent.Controls.Add(label);

            StyledTextBox textBox = new StyledTextBox
            {
                Name = controlName,
                Font = new Font("Segoe UI", 11),
                Size = new Size(ContentWidth, 36)
            };
            StyleInputTextBox(textBox);
            textBox.Location = new Point(CenterContentX(parent.Width, textBox.Width), currentY + 20);

            configure?.Invoke(textBox);
            textBox.TextChanged += (s, e) => SetValidationState((TextBox)s, ValidationState.Neutral);

            parent.Controls.Add(textBox);
            currentY = textBox.Bottom + 10;
            return textBox;
        }

        private Panel BuildTermsPanel()
        {
            const int maxWidth = ContentWidth;
            const int spacing = 10;

            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MaximumSize = new Size(maxWidth, 0),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            CheckBox checkBox = new CheckBox
            {
                Name = "chkTerms",
                AutoSize = false,
                Size = new Size(28, 28),
                Location = new Point(0, 2),
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Cursor = Cursors.Hand
            };
            panel.Controls.Add(checkBox);

            int textWidth = maxWidth - checkBox.Width - spacing;

            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Location = new Point(checkBox.Right + spacing, 0),
                AutoSize = true,
                MaximumSize = new Size(textWidth, 0),
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            flow.Controls.Add(CreateTermsLabel("T\u00F4i \u0111\u00E3 \u0111\u1ECDc v\u00E0 \u0111\u1ED3ng \u00FD c\u00E1c "));

            LinkLabel contractLink = CreateTermsLink("\u0111i\u1EC1u kho\u1EA3n h\u1EE3p \u0111\u1ED3ng");
            contractLink.LinkClicked += (s, e) =>
                MessageBox.Show(GetContractTermsContent(), "\u0110i\u1EC1u kho\u1EA3n h\u1EE3p \u0111\u1ED3ng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flow.Controls.Add(contractLink);

            flow.Controls.Add(CreateTermsLabel(" v\u00E0 c\u00E1c "));

            LinkLabel softwareLink = CreateTermsLink("\u0111i\u1EC1u kho\u1EA3n ph\u1EA7n m\u1EC1m s\u1EED d\u1EE5ng.");
            softwareLink.LinkClicked += (s, e) =>
                MessageBox.Show(GetSoftwareTermsContent(), "\u0110i\u1EC1u kho\u1EA3n ph\u1EA7n m\u1EC1m s\u1EED d\u1EE5ng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flow.Controls.Add(softwareLink);

            panel.Controls.Add(flow);
            panel.PerformLayout();

            return panel;
        }

        private Label CreateTermsLabel(string text)
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

        private LinkLabel CreateTermsLink(string text)
        {
            LinkLabel link = new LinkLabel
            {
                Text = text,
                Font = new Font("Segoe UI", 9, FontStyle.Underline),
                LinkColor = Color.FromArgb(0, 191, 255),
                VisitedLinkColor = Color.FromArgb(0, 191, 255),
                ActiveLinkColor = Color.FromArgb(30, 144, 255),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            link.MouseEnter += (s, e) => link.LinkColor = Color.FromArgb(30, 144, 255);
            link.MouseLeave += (s, e) => link.LinkColor = Color.FromArgb(0, 191, 255);
            return link;
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

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            TextBox nameTextBox = Controls.Find("txtName", true)[0] as TextBox;
            TextBox phoneTextBox = Controls.Find("txtPhone", true)[0] as TextBox;
            TextBox emailTextBox = Controls.Find("txtEmail", true)[0] as TextBox;
            TextBox passwordTextBox = Controls.Find("txtPassword", true)[0] as TextBox;
            RadioButton maleRadio = Controls.Find("rbMale", true)[0] as RadioButton;
            RadioButton femaleRadio = Controls.Find("rbFemale", true)[0] as RadioButton;
            CheckBox termsCheckbox = Controls.Find("chkTerms", true)[0] as CheckBox;
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;

            string name = nameTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string gender = maleRadio.Checked ? "Nam" : femaleRadio.Checked ? "N\u1EEF" : string.Empty;
            bool termsAccepted = termsCheckbox.Checked;

            errorLabel.Visible = false;
            ResetValidationStates(nameTextBox, phoneTextBox, emailTextBox, passwordTextBox);

            if (string.IsNullOrEmpty(name))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp h\u1ECD t\u00EAn", nameTextBox);
                nameTextBox.Focus();
                return;
            }

            if (name.Length < 2)
            {
                ShowError("H\u1ECD t\u00EAn ph\u1EA3i c\u00F3 \u00EDt nh\u1EA5t 2 k\u00FD t\u1EF1", nameTextBox);
                nameTextBox.Focus();
                return;
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z\u00C0-\u1EF9\s]+$"))
            {
                ShowError("H\u1ECD t\u00EAn ch\u1EC9 \u0111\u01B0\u1EE3c ch\u1EE9a ch\u1EEF c\u00E1i", nameTextBox);
                nameTextBox.Focus();
                return;
            }
            SetValidationState(nameTextBox, ValidationState.Success);

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

            if (string.IsNullOrEmpty(email))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp email", emailTextBox);
                emailTextBox.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                ShowError("Email kh\u00F4ng h\u1EE3p l\u1EC7", emailTextBox);
                emailTextBox.Focus();
                return;
            }
            SetValidationState(emailTextBox, ValidationState.Success);

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u1EADt kh\u1EA9u", passwordTextBox);
                passwordTextBox.Focus();
                return;
            }

            if (password.Length < 8 ||
                !Regex.IsMatch(password, @"[A-Z]") ||
                !Regex.IsMatch(password, @"[a-z]") ||
                !Regex.IsMatch(password, @"[0-9]") ||
                !Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            {
                ShowError("M\u1EADt kh\u1EA9u ph\u1EA3i c\u00F3 \u00EDt nh\u1EA5t 8 k\u00FD t\u1EF1, bao g\u1ED3m ch\u1EEF hoa, ch\u1EEF th\u01B0\u1EDDng, ch\u1EEF s\u1ED1 v\u00E0 k\u00FD t\u1EF1 \u0111\u1EB7c bi\u1EC7t", passwordTextBox);
                passwordTextBox.Focus();
                return;
            }
            SetValidationState(passwordTextBox, ValidationState.Success);

            if (string.IsNullOrEmpty(gender))
            {
                ShowError("Vui l\u00F2ng ch\u1ECDn gi\u1EDBi t\u00EDnh");
                return;
            }

            if (!termsAccepted)
            {
                ShowError("Vui l\u00F2ng \u0111\u1ED3ng \u00FD v\u1EDBi c\u00E1c \u0111i\u1EC1u kho\u1EA3n");
                return;
            }

            try
            {
                if (userService.IsPhoneRegistered(phone))
                {
                    ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i \u0111\u00E3 \u0111\u01B0\u1EE3c \u0111\u0103ng k\u00FD", phoneTextBox);
                    SetValidationState(phoneTextBox, ValidationState.Error);
                    return;
                }

                if (userService.IsEmailRegistered(email))
                {
                    ShowError("Email \u0111\u00E3 \u0111\u01B0\u1EE3c \u0111\u0103ng k\u00FD", emailTextBox);
                    SetValidationState(emailTextBox, ValidationState.Error);
                    return;
                }

                SetValidationState(phoneTextBox, ValidationState.Success);

                RegisterRequest request = new RegisterRequest
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Password = password,
                    Gender = gender,
                    TermsAccepted = termsAccepted
                };

                userService.RegisterUser(request);

                MessageBox.Show("\u0110\u0103ng k\u00FD th\u00E0nh c\u00F4ng! Vui l\u00F2ng \u0111\u0103ng nh\u1EADp.", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ShowNextForm<LoginContentForm>();
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i: {ex.Message}", nameTextBox, phoneTextBox, emailTextBox, passwordTextBox);
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
            TextBox nameTextBox = FindControlRecursive<TextBox>("txtName");
            TextBox phoneTextBox = FindControlRecursive<TextBox>("txtPhone");
            TextBox emailTextBox = FindControlRecursive<TextBox>("txtEmail");
            TextBox passwordTextBox = FindControlRecursive<TextBox>("txtPassword");
            Label errorLabel = FindControlRecursive<Label>("lblError");
            Label strengthLabel = FindControlRecursive<Label>("lblStrength");
            LargeRadioButton maleRadio = FindControlRecursive<LargeRadioButton>("rbMale");
            LargeRadioButton femaleRadio = FindControlRecursive<LargeRadioButton>("rbFemale");
            CheckBox termsCheckbox = FindControlRecursive<CheckBox>("chkTerms");
            Button registerButton = FindControlRecursive<Button>("btnRegister");

            if (errorLabel != null)
            {
                errorLabel.Visible = false;
                errorLabel.Text = string.Empty;
            }

            if (strengthLabel != null)
            {
                strengthLabel.Text = string.Empty;
            }

            if (nameTextBox != null)
            {
                nameTextBox.Text = string.Empty;
            }

            if (phoneTextBox != null)
            {
                phoneTextBox.Text = string.Empty;
            }

            if (emailTextBox != null)
            {
                emailTextBox.Text = string.Empty;
            }

            if (passwordTextBox != null)
            {
                passwordTextBox.Text = string.Empty;
            }

            ResetValidationStates(nameTextBox, phoneTextBox, emailTextBox, passwordTextBox);

            if (maleRadio != null)
            {
                maleRadio.Checked = true;
            }

            if (femaleRadio != null)
            {
                femaleRadio.Checked = false;
            }

            if (termsCheckbox != null)
            {
                termsCheckbox.Checked = false;
            }

            if (registerButton != null)
            {
                AcceptButton = registerButton;
            }

            if (nameTextBox != null)
            {
                ActiveControl = nameTextBox;
                nameTextBox.Focus();
            }
        }

        private static string GetContractTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Ph\u1EA1m vi \u00E1p d\u1EE5ng: C\u00E1c \u0111i\u1EC1u kho\u1EA3n n\u00E0y \u00E1p d\u1EE5ng cho t\u1EA5t c\u1EA3 ng\u01B0\u1EDDi d\u00F9ng \u0111\u0103ng k\u00FD v\u00E0 s\u1EED d\u1EE5ng d\u1ECBch v\u1EE5.",
                "2. Quy\u1EC1n v\u00E0 ngh\u0129a v\u1EE5: Ng\u01B0\u1EDDi d\u00F9ng cung c\u1EA5p th\u00F4ng tin ch\u00EDnh x\u00E1c, b\u1EA3o m\u1EADt t\u00E0i kho\u1EA3n v\u00E0 tu\u00E2n th\u1EE7 ph\u00E1p lu\u1EADt.",
                "3. Quy\u1EC1n s\u1EDF h\u1EEFu: M\u1ECDi n\u1ED9i dung, th\u01B0\u01A1ng hi\u1EC7u thu\u1ED9c quy\u1EC1n s\u1EDF h\u1EEFu c\u1EE7a c\u00F4ng ty.",
                "4. Ch\u00EDnh s\u00E1ch b\u1EA3o m\u1EADt: B\u1EA3o v\u1EC7 th\u00F4ng tin c\u00E1 nh\u00E2n theo quy \u0111\u1ECBnh ph\u00E1p lu\u1EADt v\u1EC1 b\u1EA3o v\u1EC7 d\u1EEF li\u1EC7u.",
                "5. Thanh to\u00E1n: Thanh to\u00E1n \u0111\u1EA7y \u0111\u1EE7 c\u00E1c kho\u1EA3n ph\u00ED d\u1ECBch v\u1EE5 theo th\u1ECFa thu\u1EADn.",
                "6. Ch\u1EA5m d\u1EE9t h\u1EE3p \u0111\u1ED3ng: Th\u1EF1c hi\u1EC7n theo th\u1ECFa thu\u1EADn ho\u1EB7c quy \u0111\u1ECBnh ph\u00E1p lu\u1EADt.",
                "7. Gi\u1EA3i quy\u1EBFt tranh ch\u1EA5p: Th\u01B0\u01A1ng l\u01B0\u1EE3ng ho\u1EB7c tu\u00E2n theo ph\u00E1p lu\u1EADt Vi\u1EC7t Nam.");
        }

        private static string GetSoftwareTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Gi\u1EA5y ph\u00E9p s\u1EED d\u1EE5ng: C\u1EA5p ph\u00E9p kh\u00F4ng \u0111\u1ED9c quy\u1EC1n cho ng\u01B0\u1EDDi d\u00F9ng theo c\u00E1c \u0111i\u1EC1u kho\u1EA3n.",
                "2. H\u1EA1n ch\u1EBF s\u1EED d\u1EE5ng: Kh\u00F4ng sao ch\u00E9p, s\u1EEDa \u0111\u1ED5i ho\u1EB7c ph\u00E2n ph\u1ED1i khi ch\u01B0a \u0111\u01B0\u1EE3c cho ph\u00E9p.",
                "3. C\u1EADp nh\u1EADt ph\u1EA7n m\u1EC1m: C\u00F3 th\u1EC3 c\u1EADp nh\u1EADt, n\u00E2ng c\u1EA5p ph\u1EA7n m\u1EC1m m\u00E0 kh\u00F4ng c\u1EA7n b\u00E1o tr\u01B0\u1EDBc.",
                "4. Tr\u00E1ch nhi\u1EC7m ng\u01B0\u1EDDi d\u00F9ng: Ch\u1ECBu tr\u00E1ch nhi\u1EC7m v\u1EC1 vi\u1EC7c s\u1EED d\u1EE5ng v\u00E0 d\u1EEF li\u1EC7u t\u1EA1o ra.",
                "5. B\u1EA3o m\u1EADt: Kh\u00F4ng s\u1EED d\u1EE5ng ph\u1EA7n m\u1EC1m cho m\u1EE5c \u0111\u00EDch b\u1EA5t h\u1EE3p ph\u00E1p ho\u1EB7c x\u00E2m ph\u1EA1m quy\u1EC1n l\u1EE3i c\u1EE7a b\u00EAn th\u1EE9 ba.",
                "6. H\u1ED7 tr\u1EE3 k\u1EF9 thu\u1EADt: H\u1ED7 tr\u1EE3 trong gi\u1EDD h\u00E0nh ch\u00EDnh theo quy \u0111\u1ECBnh.",
                "7. Mi\u1EC5n tr\u1EEB tr\u00E1ch nhi\u1EC7m: Kh\u00F4ng ch\u1ECBu tr\u00E1ch nhi\u1EC7m v\u1EC1 thi\u1EC7t h\u1EA1i gi\u00E1n ti\u1EBFp ph\u00E1t sinh.");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
        // 
        // FormRegister
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1024, 576);
        this.Name = "FormRegister";
        this.Text = "\u0110\u0103ng k\u00fd";
        this.ResumeLayout(false);

        }
    }
}



