using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Database;

namespace QLTN.Forms
{
    public partial class FormRegister : Form
    {
        private const int ContentWidth = 320;
        private static readonly Color PanelColor = Color.FromArgb(217, 50, 50, 50);
        private static readonly Size TargetFormSize = new Size(1280, 768);
        private static readonly Color InputBackColor = Color.FromArgb(PanelColor.R, PanelColor.G, PanelColor.B);

        public FormRegister()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
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
            BackColor = Color.Black;
            BackgroundImage = null;
            BackgroundImageLayout = ImageLayout.None;

            SetupControls();
        }

        private void SetupControls()
        {
            Panel mainPanel = new Panel
            {
                Size = new Size(520, 540),
                BackColor = PanelColor
            };

            mainPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddRoundedRectanglePath(mainPanel.ClientRectangle, 8);
                    using (SolidBrush brush = new SolidBrush(PanelColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            };

            mainPanel.Anchor = AnchorStyles.None;
            Controls.Add(mainPanel);
            CenterPanel(mainPanel);
            Resize += (s, e) => CenterPanel(mainPanel);

            int currentY = 35;
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

            currentY += 50;

            TextBox nameTextBox = CreateTextBox("txtName");
            nameTextBox.Size = new Size(ContentWidth, 36);
            nameTextBox.Location = new Point(CenterContentX(mainPanel.Width, nameTextBox.Width), currentY);
            mainPanel.Controls.Add(nameTextBox);
            mainPanel.Controls.Add(CreateCenteredLabel("H\u1ECD t\u00EAn", mainPanel.Width, currentY - 25));

            currentY += 50;

            TextBox phoneTextBox = CreateTextBox("txtPhone");
            phoneTextBox.Size = new Size(ContentWidth, 36);
            phoneTextBox.Location = new Point(CenterContentX(mainPanel.Width, phoneTextBox.Width), currentY);
            phoneTextBox.MaxLength = 10;
            phoneTextBox.TextChanged += (s, e) =>
            {
                string digitsOnly = Regex.Replace(phoneTextBox.Text, @"[^\d]", "");
                if (digitsOnly != phoneTextBox.Text)
                {
                    int caret = phoneTextBox.SelectionStart - (phoneTextBox.Text.Length - digitsOnly.Length);
                    phoneTextBox.Text = digitsOnly;
                    phoneTextBox.SelectionStart = Math.Max(caret, 0);
                }
            };
            mainPanel.Controls.Add(phoneTextBox);
            mainPanel.Controls.Add(CreateCenteredLabel("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i", mainPanel.Width, currentY - 25));

            currentY += 50;

            TextBox emailTextBox = CreateTextBox("txtEmail");
            emailTextBox.Size = new Size(ContentWidth, 36);
            emailTextBox.Location = new Point(CenterContentX(mainPanel.Width, emailTextBox.Width), currentY);
            mainPanel.Controls.Add(emailTextBox);
            mainPanel.Controls.Add(CreateCenteredLabel("Email", mainPanel.Width, currentY - 25));

            currentY += 60;

            TextBox passwordTextBox = CreateTextBox("txtPassword");
            passwordTextBox.Size = new Size(ContentWidth, 36);
            passwordTextBox.Location = new Point(CenterContentX(mainPanel.Width, passwordTextBox.Width), currentY);
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += PasswordTextBox_TextChanged;
            mainPanel.Controls.Add(passwordTextBox);
            mainPanel.Controls.Add(CreateCenteredLabel("M\u1EADt kh\u1EA9u", mainPanel.Width, currentY - 25));

            Label strengthLabel = new Label
            {
                Name = "lblStrength",
                Size = new Size(ContentWidth, 20),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY + 40),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(180, 180, 180)
            };
            mainPanel.Controls.Add(strengthLabel);

            currentY += 60;

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
                Margin = new Padding(0, 0, 30, 0)
            };
            genderPanel.Controls.Add(maleRadio);

            LargeRadioButton femaleRadio = new LargeRadioButton
            {
                Name = "rbFemale",
                Text = "N\u1EEF",
                Font = new Font("Segoe UI", 12),
                GlyphSize = 22,
                Margin = new Padding(0)
            };
            genderPanel.Controls.Add(femaleRadio);

            genderPanel.PerformLayout();
            genderPanel.Location = new Point(contentLeft, currentY);
            mainPanel.Controls.Add(genderPanel);

            currentY += genderPanel.Height + 25;

            Panel termsPanel = BuildTermsPanel();
            termsPanel.Location = new Point(contentLeft, currentY);
            mainPanel.Controls.Add(termsPanel);

            currentY += termsPanel.Height + 15;

            Button registerButton = new Button
            {
                Name = "btnRegister",
                Text = "\u0110\u0103ng k\u00FD",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 51, 51),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.Location = new Point(CenterContentX(mainPanel.Width, registerButton.Width), currentY);
            registerButton.Click += BtnRegister_Click;
            mainPanel.Controls.Add(registerButton);

            currentY += 50;

            LinkLabel backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", currentY, mainPanel.Width);
            backLink.Click += (s, e) =>
            {
                ShowNextForm(new FormLogin());
            };
            mainPanel.Controls.Add(backLink);

            currentY += 30;

            Label errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 40),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleLeft,
                Visible = false
            };
            mainPanel.Controls.Add(errorLabel);

            ActiveControl = nameTextBox;
        }

        private static TextBox CreateTextBox(string name)
        {
            return new TextBox
            {
                Name = name,
                Font = new Font("Segoe UI", 11),
                BackColor = InputBackColor,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(ContentWidth, 36)
            };
        }

        private static Label CreateCenteredLabel(string text, int parentWidth, int y)
        {
            int width = Math.Min(ContentWidth, parentWidth);
            int left = CenterContentX(parentWidth, width);
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(200, 200, 200),
                Size = new Size(width, 20),
                Location = new Point(left, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private static LinkLabel CreateLinkLabel(string text, int y, int parentWidth)
        {
            int width = Math.Min(ContentWidth, parentWidth);
            return new LinkLabel
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                LinkColor = Color.FromArgb(0, 191, 255),
                VisitedLinkColor = Color.FromArgb(0, 191, 255),
                ActiveLinkColor = Color.FromArgb(30, 144, 255),
                AutoSize = false,
                Size = new Size(width, 20),
                Location = new Point(CenterContentX(parentWidth, width), y),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private static int CenterContentX(int parentWidth, int contentWidth)
        {
            return Math.Max((parentWidth - contentWidth) / 2, 0);
        }

        private static Panel BuildTermsPanel()
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
                Size = new Size(22, 22),
                Location = new Point(0, 2),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
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

        private static Label CreateTermsLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private static LinkLabel CreateTermsLink(string text)
        {
            return new LinkLabel
            {
                Text = text,
                Font = new Font("Segoe UI", 9, FontStyle.Underline),
                LinkColor = Color.FromArgb(0, 191, 255),
                VisitedLinkColor = Color.FromArgb(0, 191, 255),
                ActiveLinkColor = Color.FromArgb(30, 144, 255),
                AutoSize = true
            };
        }

        private static void CenterControlHorizontally(Control parent, Control control)
        {
            control.Location = new Point((parent.Width - control.Width) / 2, control.Location.Y);
        }

        private void CenterPanel(Control panel)
        {
            if (panel?.Parent == null)
            {
                return;
            }

            int x = Math.Max((panel.Parent.ClientSize.Width - panel.Width) / 2, 0);
            int y = Math.Max((panel.Parent.ClientSize.Height - panel.Height) / 2, 0);
            panel.Location = new Point(x, y);
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

            if (string.IsNullOrEmpty(name))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp h\u1ECD t\u00EAn");
                return;
            }

            if (name.Length < 2)
            {
                ShowError("H\u1ECD t\u00EAn ph\u1EA3i c\u00F3 \u00EDt nh\u1EA5t 2 k\u00FD t\u1EF1");
                return;
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z\u00C0-\u1EF9\s]+$"))
            {
                ShowError("H\u1ECD t\u00EAn ch\u1EC9 \u0111\u01B0\u1EE3c ch\u1EE9a ch\u1EEF c\u00E1i");
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp s\u1ED1 \u0111i\u1EC7n tho\u1EA1i");
                return;
            }

            if (phone.Length != 10 || !phone.StartsWith("0"))
            {
                ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i ph\u1EA3i c\u00F3 10 ch\u1EEF s\u1ED1 v\u00E0 b\u1EAFt \u0111\u1EA7u b\u1EB1ng s\u1ED1 0");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp email");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                ShowError("Email kh\u00F4ng h\u1EE3p l\u1EC7");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u1EADt kh\u1EA9u");
                return;
            }

            if (password.Length < 8 ||
                !Regex.IsMatch(password, @"[A-Z]") ||
                !Regex.IsMatch(password, @"[a-z]") ||
                !Regex.IsMatch(password, @"[0-9]") ||
                !Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            {
                ShowError("M\u1EADt kh\u1EA9u ph\u1EA3i c\u00F3 \u00EDt nh\u1EA5t 8 k\u00FD t\u1EF1, bao g\u1ED3m ch\u1EEF hoa, ch\u1EEF th\u01B0\u1EDDng, ch\u1EEF s\u1ED1 v\u00E0 k\u00FD t\u1EF1 \u0111\u1EB7c bi\u1EC7t");
                return;
            }

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
                if (IsPhoneExists(phone))
                {
                    ShowError("S\u1ED1 \u0111i\u1EC7n tho\u1EA1i \u0111\u00E3 \u0111\u01B0\u1EE3c \u0111\u0103ng k\u00FD");
                    return;
                }

                if (IsEmailExists(email))
                {
                    ShowError("Email \u0111\u00E3 \u0111\u01B0\u1EE3c \u0111\u0103ng k\u00FD");
                    return;
                }

                RegisterUser(name, phone, email, password, gender);

                MessageBox.Show("\u0110\u0103ng k\u00FD th\u00E0nh c\u00F4ng! Vui l\u00F2ng \u0111\u0103ng nh\u1EADp.", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ShowNextForm(new FormLogin());
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i: {ex.Message}");
            }
        }

        private bool IsPhoneExists(string phone)
        {
            const string query = "SELECT COUNT(*) FROM nguoidung WHERE soDienThoai = @Phone";
            SqlParameter[] parameters = { new SqlParameter("@Phone", phone) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        private bool IsEmailExists(string email)
        {
            const string query = "SELECT COUNT(*) FROM nguoidung WHERE email = @Email";
            SqlParameter[] parameters = { new SqlParameter("@Email", email) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        private void RegisterUser(string name, string phone, string email, string password, string gender)
        {
            const string query = @"INSERT INTO nguoidung (hoTen, soDienThoai, email, matKhau, gioiTinh, trangThai) 
                                   VALUES (@Name, @Phone, @Email, @Password, @Gender, 1)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Gender", gender)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        private void ShowError(string message)
        {
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;
            errorLabel.Text = message;
            errorLabel.Visible = true;
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

        private static string GetContractTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Pháº¡m vi Ã¡p dá»¥ng: Ãp dá»¥ng cho toÃ n bá»™ ngÆ°á»i dÃ¹ng há»‡ thá»‘ng.",
                "2. Quyá»n vÃ  nghÄ©a vá»¥: NgÆ°á»i dÃ¹ng cung cáº¥p thÃ´ng tin chÃ­nh xÃ¡c vÃ  báº£o máº­t tÃ i khoáº£n.",
                "3. Quyá»n sá»Ÿ há»¯u trÃ­ tuá»‡: Ná»™i dung thuá»™c quyá»n sá»Ÿ há»¯u cá»§a cÃ´ng ty.",
                "4. ChÃ­nh sÃ¡ch báº£o máº­t: ThÃ´ng tin cÃ¡ nhÃ¢n Ä‘Æ°á»£c báº£o vá»‡ theo quy Ä‘á»‹nh phÃ¡p luáº­t.",
                "5. Thanh toÃ¡n: Thanh toÃ¡n Ä‘áº§y Ä‘á»§ cÃ¡c khoáº£n phÃ­ theo quy Ä‘á»‹nh.",
                "6. Cháº¥m dá»©t há»£p Ä‘á»“ng: Theo thá»a thuáº­n hoáº·c quy Ä‘á»‹nh phÃ¡p luáº­t.",
                "7. Giáº£i quyáº¿t tranh cháº¥p: Thá»±c hiá»‡n theo phÃ¡p luáº­t Viá»‡t Nam.");
        }

        private static string GetSoftwareTermsContent()
        {
            return string.Join(Environment.NewLine,
                "1. Giáº¥y phÃ©p sá»­ dá»¥ng: Cáº¥p phÃ©p khÃ´ng Ä‘á»™c quyá»n cho ngÆ°á»i dÃ¹ng.",
                "2. Háº¡n cháº¿ sá»­ dá»¥ng: KhÃ´ng sao chÃ©p, sá»­a Ä‘á»•i hoáº·c phÃ¢n phá»‘i trÃ¡i phÃ©p.",
                "3. Cáº­p nháº­t pháº§n má»m: CÃ³ thá»ƒ cáº­p nháº­t mÃ  khÃ´ng cáº§n thÃ´ng bÃ¡o.",
                "4. TrÃ¡ch nhiá»‡m: NgÆ°á»i dÃ¹ng chá»‹u trÃ¡ch nhiá»‡m vá» dá»¯ liá»‡u táº¡o ra.",
                "5. Báº£o máº­t: KhÃ´ng sá»­ dá»¥ng pháº§n má»m vÃ o má»¥c Ä‘Ã­ch vi pháº¡m phÃ¡p luáº­t.",
                "6. Há»— trá»£ ká»¹ thuáº­t: Há»— trá»£ trong giá» hÃ nh chÃ­nh theo quy Ä‘á»‹nh.",
                "7. Miá»…n trá»« trÃ¡ch nhiá»‡m: KhÃ´ng chá»‹u trÃ¡ch nhiá»‡m vá» thiá»‡t háº¡i giÃ¡n tiáº¿p.");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            
            this.Name = "FormRegister";
            this.Text = "\u0110\u0103ng k\u00fd";
            this.ResumeLayout(false);

        }
    }
}

