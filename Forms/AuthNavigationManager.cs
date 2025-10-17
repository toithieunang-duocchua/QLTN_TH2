using System;
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

        public static bool HasHost => hostPanel != null && !hostPanel.IsDisposed;

        public static void Initialize(Panel panel)
        {
            hostPanel = panel ?? throw new ArgumentNullException(nameof(panel));
            transitionPanel = panel as TransitionHostPanel;
            hostPanel.Controls.Clear();
        }

        public static void Navigate(Form nextForm, Form previousForm = null)
        {
            if (nextForm == null)
            {
                throw new ArgumentNullException(nameof(nextForm));
            }

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
                currentForm = nextForm;
                return;
            }
            if (formToRemove != null && !formToRemove.IsDisposed)
            {
                if (hostPanel.Controls.Contains(formToRemove))
                {
                    hostPanel.Controls.Remove(formToRemove);
                }

                formToRemove.Hide();
            }

            currentForm = nextForm;
            nextForm.TopLevel = false;
            nextForm.FormBorderStyle = FormBorderStyle.None;
            nextForm.Dock = DockStyle.Fill;

            hostPanel.Controls.Clear();
            hostPanel.Controls.Add(nextForm);
            nextForm.Show();

            if (formToRemove != null && !ReferenceEquals(formToRemove, nextForm))
            {
                formToRemove.Dispose();
            }
        }
    }
}
