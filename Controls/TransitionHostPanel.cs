using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QLTN.Controls
{
    /// <summary>
    /// Hosts embedded forms and provides a subtle cross-fade animation
    /// when switching between them to avoid the default WinForms flicker.
    /// </summary>
    internal sealed class TransitionHostPanel : Panel
    {
        private const int AnimationDuration = 200; // milliseconds
        private const int TimerInterval = 15;      // ~60 FPS

        private Form currentForm;
        private Form incomingForm;

        private Bitmap outgoingSnapshot;
        private Bitmap incomingSnapshot;

        private Timer animationTimer;
        private int elapsed;

        public TransitionHostPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            animationTimer = new Timer { Interval = TimerInterval };
            animationTimer.Tick += AnimationTimerOnTick;
        }

        /// <summary>
        /// Displays the provided form inside the host, animating from the
        /// previous instance if available.
        /// </summary>
        public void TransitionTo(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (animationTimer.Enabled)
            {
                CancelAnimation();
            }

            PrepareForm(form);

            // Capture outgoing snapshot before starting transition.
            Bitmap outgoing = CaptureSnapshot(currentForm);

            // Layout incoming form to capture a clean snapshot.
            if (!Controls.Contains(form))
            {
                Controls.Add(form);
            }

            form.Visible = true;
            form.Enabled = true;
            form.Refresh();
            Bitmap incoming = CaptureSnapshot(form);

            // Handle first load (no animation needed).
            if (outgoing == null || incoming == null)
            {
                CompleteTransitionImmediately(form);
                return;
            }

            incomingForm = form;
            incomingForm.Visible = false;
            incomingForm.Enabled = false;

            if (currentForm != null)
            {
                currentForm.Visible = false;
                currentForm.Enabled = false;
            }

            outgoingSnapshot?.Dispose();
            incomingSnapshot?.Dispose();

            outgoingSnapshot = outgoing;
            incomingSnapshot = incoming;

            elapsed = 0;
            animationTimer.Start();
        }

        /// <summary>
        /// Ensures the panel is in a consistent state if a resize occurs during animation.
        /// </summary>
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            if (animationTimer.Enabled)
            {
                CancelAnimation();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (animationTimer.Enabled && outgoingSnapshot != null && incomingSnapshot != null)
            {
                float progress = Math.Min(1f, elapsed / (float)AnimationDuration);

                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                DrawBitmapWithOpacity(e.Graphics, outgoingSnapshot, 1f - progress);
                DrawBitmapWithOpacity(e.Graphics, incomingSnapshot, progress);

                return;
            }

            base.OnPaint(e);
        }

        private void AnimationTimerOnTick(object sender, EventArgs e)
        {
            elapsed += TimerInterval;

            if (elapsed >= AnimationDuration)
            {
                animationTimer.Stop();
                FinalizeAnimation();
            }

            Invalidate();
        }

        private void FinalizeAnimation()
        {
            outgoingSnapshot?.Dispose();
            outgoingSnapshot = null;

            if (incomingSnapshot != null)
            {
                incomingSnapshot.Dispose();
                incomingSnapshot = null;
            }

            if (incomingForm != null)
            {
                if (currentForm != null)
                {
                    Controls.Remove(currentForm);
                    currentForm.Dispose();
                }

                incomingForm.Visible = true;
                incomingForm.Enabled = true;
                incomingForm.BringToFront();
                currentForm = incomingForm;
                incomingForm = null;
            }

            Invalidate();
        }

        private void CompleteTransitionImmediately(Form form)
        {
            CancelAnimation();

            if (currentForm != null && !ReferenceEquals(currentForm, form))
            {
                Controls.Remove(currentForm);
                currentForm.Dispose();
            }

            form.Visible = true;
            form.Enabled = true;
            form.BringToFront();
            currentForm = form;
        }

        private void CancelAnimation()
        {
            animationTimer.Stop();

            outgoingSnapshot?.Dispose();
            outgoingSnapshot = null;

            incomingSnapshot?.Dispose();
            incomingSnapshot = null;

            if (incomingForm != null)
            {
                incomingForm.Visible = true;
                incomingForm.Enabled = true;
                incomingForm.BringToFront();
                currentForm = incomingForm;
                incomingForm = null;
            }

            if (currentForm != null)
            {
                currentForm.Visible = true;
                currentForm.Enabled = true;
            }
        }

        private void PrepareForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
        }

        private Bitmap CaptureSnapshot(Form form)
        {
            if (form == null || form.IsDisposed || form.Width <= 0 || form.Height <= 0)
            {
                return null;
            }

            Bitmap bitmap = new Bitmap(Width, Height);
            try
            {
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, Size));
            }
            catch
            {
                bitmap.Dispose();
                return null;
            }

            return bitmap;
        }

        private static void DrawBitmapWithOpacity(Graphics graphics, Image image, float opacity)
        {
            if (graphics == null || image == null)
            {
                return;
            }

            using (ImageAttributes attributes = new ImageAttributes())
            {
                ColorMatrix matrix = new ColorMatrix
                {
                    Matrix00 = 1f,
                    Matrix11 = 1f,
                    Matrix22 = 1f,
                    Matrix33 = opacity,
                    Matrix44 = 1f
                };

                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                graphics.DrawImage(
                    image,
                    new Rectangle(Point.Empty, graphics.VisibleClipBounds.Size.ToSize()),
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer?.Dispose();
                outgoingSnapshot?.Dispose();
                incomingSnapshot?.Dispose();
                currentForm?.Dispose();
                incomingForm?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
