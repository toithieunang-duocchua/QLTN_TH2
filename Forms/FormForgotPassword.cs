using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTN.Controls;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormForgotPassword : ThemedForm
    {
        private const int ContentWidth = 320;
        private static readonly Size TargetFormSize = new Size(1024, 576);
        private readonly UserService userService = new UserService();

        public FormForgotPassword()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Text = "Qu\u00EAn m\u1EADt kh\u1EA9u - H\u1EC7 th\u1ED1ng QLTN";
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
                Text = "Qu\u00EAn m\u1EADt kh\u1EA9u",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(mainPanel.Width, 40),
                Location = new Point(0, currentY),
                TextAlign = ContentAlignment.MiddleCenter
            });

            currentY += 60;

            Label instructionsLabel = new Label
            {
                Text = "Nh\u1EADp email c\u1EE7a b\u1EA1n \u0111\u1EC3 nh\u1EADn m\u00E3 x\u00E1c minh.",
                Font = new Font("Segoe UI", 11),
                ForeColor = SecondaryTextColor,
                Size = new Size(ContentWidth, 40),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(instructionsLabel);

            currentY += 60;

            Label emailLabel = CreateCenteredLabel("Email c\u1EE7a b\u1EA1n", mainPanel.Width, currentY - 20);
            mainPanel.Controls.Add(emailLabel);

            StyledTextBox emailTextBox = new StyledTextBox
            {
                Name = "txtEmail",
                Size = new Size(ContentWidth, 36),
                Font = new Font("Segoe UI", 12)
            };
            StyleInputTextBox(emailTextBox);
            emailTextBox.Location = new Point(CenterContentX(mainPanel.Width, emailTextBox.Width), currentY);
            emailTextBox.TextChanged += (s, e) => SetValidationState(emailTextBox, ValidationState.Neutral);
            mainPanel.Controls.Add(emailTextBox);

            currentY += 60;

            Button nextButton = new Button
            {
                Name = "btnNext",
                Text = "Ti\u1EBFp theo",
                Size = new Size(ContentWidth, 42),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Padding = new Padding(0, 2, 0, 2)
            };
            StylePrimaryButton(nextButton);
            nextButton.Location = new Point(CenterContentX(mainPanel.Width, nextButton.Width), currentY);
            nextButton.Click += BtnNext_Click;
            mainPanel.Controls.Add(nextButton);
            AcceptButton = nextButton;

            currentY += 55;

            LinkLabel backLink = CreateLinkLabel("Quay l\u1EA1i \u0111\u0103ng nh\u1EADp", currentY, mainPanel.Width);
            backLink.Click += (s, e) => ShowNextForm(new LoginContentForm());
            mainPanel.Controls.Add(backLink);

            currentY += 35;

            Label errorLabel = new Label
            {
                Name = "lblError",
                Size = new Size(ContentWidth, 48),
                Location = new Point(CenterContentX(mainPanel.Width, ContentWidth), currentY),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(255, 107, 107),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            mainPanel.Controls.Add(errorLabel);

            ActiveControl = emailTextBox;
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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            TextBox emailTextBox = Controls.Find("txtEmail", true)[0] as TextBox;
            Label errorLabel = Controls.Find("lblError", true)[0] as Label;

            string email = emailTextBox.Text.Trim();
            errorLabel.Visible = false;
            ResetValidationStates(emailTextBox);

            if (string.IsNullOrEmpty(email))
            {
                ShowError("Vui l\u00F2ng nh\u1EADp email c\u1EE7a b\u1EA1n", emailTextBox);
                emailTextBox.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Email kh\u00F4ng h\u1EE3p l\u1EC7", emailTextBox);
                emailTextBox.Focus();
                return;
            }

            try
            {
                if (!userService.IsEmailRegistered(email))
                {
                    ShowError("Email kh\u00F4ng t\u1ED3n t\u1EA1i trong h\u1EC7 th\u1ED1ng", emailTextBox);
                    SetValidationState(emailTextBox, ValidationState.Error);
                    emailTextBox.Focus();
                    return;
                }

                SetValidationState(emailTextBox, ValidationState.Success);

                MessageBox.Show("M\u00E3 x\u00E1c th\u1EF1c \u0111\u00E3 \u0111\u01B0\u1EE3c g\u1EEDi \u0111\u1EBFn email c\u1EE7a b\u1EA1n!", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowNextForm(new FormVerification(email));
            }
            catch (Exception ex)
            {
                ShowError($"L\u1ED7i: {ex.Message}", emailTextBox);
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
            AuthNavigationManager.Navigate(form, this);
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
            Text = "Qu\u00EAn m\u1EADt kh\u1EA9u";
            ResumeLayout(false);
        }
    }
}
