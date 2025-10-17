using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLTN.Controls;

namespace QLTN.Forms
{
    /// <summary>
    /// Coordinates navigation between authentication-related forms so they can be hosted
    /// inside a fixed container without spawning additional top-level windows.
    /// </summary>
    internal static class AuthNavigationManager
    {
        private static Panel hostPanel;
        private static TransitionHostPanel transitionPanel;
        private static Form currentForm;
        private static readonly Dictionary<Type, Form> FormCache = new Dictionary<Type, Form>();

        public static bool HasHost => hostPanel != null && !hostPanel.IsDisposed;

        public static void Initialize(Panel panel)
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
            {
                throw new ArgumentNullException(nameof(nextForm));
            }

            PrepareFormForDisplay(nextForm);

            if (hostPanel == null || hostPanel.IsDisposed)
            {
                if (previousForm != null)
                {
                    if (previousForm.WindowState == FormWindowState.Maximized)
                    {
                        nextForm.WindowState = FormWindowState.Maximized;
                    }

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
                {
                    formToRemove.Hide();
                }

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
                {
                    return (TForm)cachedForm;
                }

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
                {
                    form.Dispose();
                }
            }

            FormCache.Clear();
        }

        private static void PrepareFormForDisplay(Form form)
        {
            if (form is IAuthView authView)
            {
                authView.PrepareForDisplay();
            }
        }
    }
}
