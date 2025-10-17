using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    public partial class FormVerification : ThemedForm
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly string userEmail;

        public FormVerification(string email)
        {
            userEmail = email;
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "\u0110\u0103ng nh\u1EADp - X\u00E1c minh";
            Size = TargetFormSize;
            MinimumSize = TargetFormSize;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            Panel mainPanel = CreateSurfacePanel(new Size(420, 440));
            mainPanel.Anchor = AnchorStyles.None;
            Controls.Add(mainPanel);
            AttachCentering(mainPanel);

            int currentY = 36;

            mainPanel.Controls.Add(new Label
            {
                Text = "X\u00E1c minh",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(mainPanel.Width, 40),
                Location = new Point(0, currentY),
                TextAlign = ContentAlignment.MiddleCenter
            });

            currentY += 60;

            Label instructionLabel = new Label
            {
                Text = "Ch\u00FAng t\u00F4i \u0111\u00E3 g\u1EEDi m\u00E3 x\u00E1c th\u1EF1c \u0111\u1EBFn email c\u1EE7a b\u1EA1n.\nVui l\u00F2ng ki\u1EC3m tra v\u00E0 nh\u1EADp m\u00E3 b\u00EAn d\u01B0\u1EDBi.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Size = new Size(ContentWidth, 48),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(instructionLabel);

            currentY = instructionLabel.Bottom + 20;

            Label noteLabel = new Label
            {
                Text = "L\u01B0u \u00FD: M\u00E3 ch\u1EC9 c\u00F3 hi\u1EC7u l\u1EF1c trong v\u00F2ng 5 ph\u00FAt.",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 107, 107),
                Size = new Size(ContentWidth, 18),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(noteLabel);

            currentY = noteLabel.Bottom + 24;

            mainPanel.Controls.Add(CreateCenteredLabel("M\u00E3 x\u00E1c minh", mainPanel.Width, currentY));

            StyledTextBox codeTextBox = new StyledTextBox
            {
                Name = "txtCode",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12),
                MaxLength = 6,
                TextAlign = HorizontalAlignment.Center
            };
            StyleInputTextBox(codeTextBox);
            codeTextBox.Location = new Point(CenterContentX(mainPanel.Width, codeTextBox.Width), currentY + 22);
            codeTextBox.TextChanged += (s, e) =>
            {
                string digitsOnly = Regex.Replace(codeTextBox.Text, @"[^\d]", "");
                if (digitsOnly != codeTextBox.Text)
                {
                    int caret = codeTextBox.SelectionStart - (codeTextBox.Text.Length - digitsOnly.Length);
                    codeTextBox.Text = digitsOnly;
                    codeTextBox.SelectionStart = Math.Max(caret, 0);
                }
                SetValidationState(codeTextBox, ValidationState.Neutral);
            };
            mainPanel.Controls.Add(codeTextBox);

            currentY = codeTextBox.Bottom + 24;

            Button verifyButton = new Button
            {
                Name = "btnVerify",
                Text = "X\u00E1c minh",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(verifyButton);
            verifyButton.Location = new Point(CenterContentX(mainPanel.Width, verifyButton.Width), currentY);
            verifyButton.Click += BtnVerify_Click;
            mainPanel.Controls.Add(verifyButton);
            AcceptButton = verifyButton;

            currentY = verifyButton.Bottom + 20;

            LinkLabel resendLink = CreateLinkLabel("G\u1EEDi l\u1EA1i m\u00E3 x\u00E1c minh", currentY, mainPanel.Width);
            resendLink.Click += (s, e) => ResendCode();
            mainPanel.Controls.Add(resendLink);

            currentY = resendLink.Bottom + 12;

            LinkLabel backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", currentY, mainPanel.Width);
            backLink.Click += (s, e) => ShowNextForm<LoginContentForm>();
            mainPanel.Controls.Add(backLink);

            currentY = backLink.Bottom + 16;

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

            ActiveControl = codeTextBox;
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

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            TextBox codeTextBox = Controls.Find("txtCode", true)[0] as TextBox;
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;

            string code = codeTextBox.Text.Trim();
            errorLabel.Visible = false;
            ResetValidationStates(codeTextBox);

            if (string.IsNullOrEmpty(code))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp m\u00E3 x\u00E1c minh", codeTextBox);
                codeTextBox.Focus();
                return;
            }

            if (code.Length != 6)
            {
                ShowError("M\u00E3 x\u00E1c minh ph\u1EA3i c\u00F3 6 ch\u1EEF s\u1ED1", codeTextBox);
                codeTextBox.Focus();
                return;
            }

            if (code != "123456")
            {
                ShowError("M\u00E3 x\u00E1c minh kh\u00F4ng ch\u00EDnh x\u00E1c", codeTextBox);
                codeTextBox.Focus();
                return;
            }

            SetValidationState(codeTextBox, ValidationState.Success);

            MessageBox.Show("X\u00E1c minh th\u00E0nh c\u00F4ng!", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowNextForm(new FormResetPassword(userEmail));
        }

        private void ResendCode()
        {
            MessageBox.Show("M\u00E3 x\u00E1c minh m\u1EDBi \u0111\u00E3 \u0111\u01B0\u1EE3c g\u1EEDi!", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Text = "X\u00E1c minh";
            ResumeLayout(false);
        }
    }
}
