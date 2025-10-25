using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace QLTN.Forms
{
    public partial class FormAddTenant : Form
    {
        public FormAddTenant()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set BackColor to prevent transparent background error
            this.BackColor = Color.FromArgb(248, 249, 250);
            
            // Load room data into combo box
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            // Add sample room data
            cmbRoom.Items.Add("A101");
            cmbRoom.Items.Add("A102");
            cmbRoom.Items.Add("A201");
            cmbRoom.Items.Add("A202");
            cmbRoom.Items.Add("B101");
            cmbRoom.Items.Add("B102");
            cmbRoom.Items.Add("B203");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD/CMND/Hộ chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Gmail!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoom.Focus();
                return;
            }

            if (dtpStartDate.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Focus();
                return;
            }

            if (dtpEndDate.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày kết thúc hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return;
            }

            // Save tenant data (placeholder)
            MessageBox.Show("Đã lưu thông tin người thuê thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Navigate back to FormTenant
            NavigateBackToTenantForm();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // Clear all fields
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtID.Text = "";
            txtEmail.Text = "";
            cmbRoom.SelectedIndex = -1;
            cmbFingerprintStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(12);
            txtNotes.Text = "";
        }

        private void NavigateBackToTenantForm()
        {
            // Navigate back to tenant management
            FormMainSystem mainForm = Application.OpenForms.OfType<FormMainSystem>().FirstOrDefault();
            if (mainForm != null)
            {
                FormTenant formTenant = new FormTenant();
                formTenant.TopLevel = false;
                formTenant.FormBorderStyle = FormBorderStyle.None;
                formTenant.Dock = DockStyle.Fill;

                mainForm.LoadFormIntoMainPanel(formTenant);
            }
        }

        private void lblNotes_Click(object sender, EventArgs e)
        {

        }
    }
}