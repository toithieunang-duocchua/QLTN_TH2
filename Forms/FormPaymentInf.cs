using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormPaymentInf : Form
    {
        public FormPaymentInf()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            this.Load += FormPaymentInf_Load;
            this.Resize += FormPaymentInf_Resize;
        }

        private void FormPaymentInf_Load(object sender, EventArgs e)
        {
            pictureBox1.Tag = labelUpload1;
            pictureBox2.Tag = labelUpload2;
            this.pictureBox2.Tag = labelUpload2;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;
            
            ArrangePanels();
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic == null) return;

            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(open.FileName);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.BringToFront();
                    if (pic.Tag is Label lbl)
                        lbl.Visible = false;
                }
            }
        }


        private void FormPaymentInf_Resize(object sender, EventArgs e)
        {
            ArrangePanels();
        }

        private void ArrangePanels()
        {
            if (flowLayoutPanel1 == null || flowLayoutPanel1.Controls.Count == 0)
                return;

            int spacing = 15;
            int numCols = (this.ClientSize.Width > 950) ? 2 : 1;
            int panelWidth = 573;
            int panelHeight = 359;

            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                ctrl.Margin = new Padding(spacing / 2); 
                ctrl.Width = panelWidth;
                ctrl.Height = panelHeight;
            }

            int totalWidth = (panelWidth * numCols) + (spacing * (numCols - 1));
            int availableWidth = flowLayoutPanel1.DisplayRectangle.Width;

            int leftPadding = Math.Max((availableWidth - totalWidth) / 2, spacing);
            int rightPadding = leftPadding;

            flowLayoutPanel1.Padding = new Padding(leftPadding, spacing, rightPadding, spacing);

            flowLayoutPanel1.ResumeLayout();
        }

    }
}
