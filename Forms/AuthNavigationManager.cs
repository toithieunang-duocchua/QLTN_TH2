using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Coordinates navigation between authentication-related forms so they can be hosted
    /// inside a fixed container without spawning additional top-level windows.
    /// </summary>
    internal static class AuthNavigationManager
    {
        private static System.Windows.Forms.Panel hostPanel; // explicitly WinForms Panel
        private static TransitionHostPanel transitionPanel;
        private static Form currentForm;
        private static readonly Dictionary<Type, Form> FormCache = new Dictionary<Type, Form>();

        public static bool HasHost => hostPanel != null && !hostPanel.IsDisposed;

        public static void Initialize(System.Windows.Forms.Panel panel)
        {
            hostPanel = panel ?? throw new ArgumentNullException(nameof(panel));
            transitionPanel = panel as TransitionHostPanel;
            hostPanel.Controls.Clear();
            ClearCachedForms();
            currentForm = null;
        }

        public static void Navigate<TForm>(Form previousForm = null) where TForm : Form, new()
        {
            TForm nextForm = GetOrCreateForm<TForm>();
            Navigate(nextForm, previousForm);
        }

        public static void Navigate(Form nextForm, Form previousForm = null)
        {
            if (nextForm == null)
                throw new ArgumentNullException(nameof(nextForm));

            PrepareFormForDisplay(nextForm);

            if (hostPanel == null || hostPanel.IsDisposed)
            {
                if (previousForm != null)
                {
                    if (previousForm.WindowState == FormWindowState.Maximized)
                        nextForm.WindowState = FormWindowState.Maximized;

                    nextForm.Show(previousForm);
                    previousForm.Hide();
                }
                else
                {
                    nextForm.Show();
                }

                currentForm = nextForm;
                return;
            }

            Form formToRemove = previousForm ?? currentForm;

            if (transitionPanel != null)
            {
                transitionPanel.TransitionTo(nextForm);
                if (formToRemove != null && !ReferenceEquals(formToRemove, nextForm))
                    formToRemove.Hide();

                currentForm = nextForm;
                return;
            }

            if (formToRemove != null && !formToRemove.IsDisposed && hostPanel.Controls.Contains(formToRemove))
            {
                hostPanel.Controls.Remove(formToRemove);
                formToRemove.Hide();
            }

            currentForm = nextForm;
            nextForm.TopLevel = false;
            nextForm.FormBorderStyle = FormBorderStyle.None;
            nextForm.Dock = DockStyle.Fill;

            if (nextForm.Parent != hostPanel)
            {
                nextForm.Parent?.Controls.Remove(nextForm);
                hostPanel.Controls.Add(nextForm);
            }

            nextForm.Show();
        }

        private static TForm GetOrCreateForm<TForm>() where TForm : Form, new()
        {
            Type key = typeof(TForm);
            if (FormCache.TryGetValue(key, out Form cachedForm))
            {
                if (cachedForm != null && !cachedForm.IsDisposed)
                    return (TForm)cachedForm;

                FormCache.Remove(key);
            }

            TForm form = new TForm();
            FormCache[key] = form;
            return form;
        }

        private static void ClearCachedForms()
        {
            foreach (KeyValuePair<Type, Form> entry in FormCache)
            {
                Form form = entry.Value;
                if (form != null && !form.IsDisposed)
                    form.Dispose();
            }

            FormCache.Clear();
        }

        private static void PrepareFormForDisplay(Form form)
        {
            if (form is IAuthView authView)
                authView.PrepareForDisplay();
        }

        public static void LoadWpfControl<TControl>() where TControl : class
        {
            // For now, just show a message instead of WPF control
            if (hostPanel != null && !hostPanel.IsDisposed)
            {
                hostPanel.Controls.Clear();
                Label lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = "WPF Control sẽ được tích hợp sau khi hoàn thiện",
                    Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                hostPanel.Controls.Add(lbl);
            }
        }

        public static void LoadWinForm<TForm>() where TForm : Form, new()
        {
            if (hostPanel == null || hostPanel.IsDisposed)
                throw new InvalidOperationException("Host panel is not initialized.");

            // Xóa nội dung cũ trong panel
            hostPanel.Controls.Clear();

            // Tạo instance form mới
            TForm form = new TForm();

            // Thiết lập form để có thể nhúng vào panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Thêm form vào panel và hiển thị
            hostPanel.Controls.Add(form);
            form.Show();
        }

    }
}