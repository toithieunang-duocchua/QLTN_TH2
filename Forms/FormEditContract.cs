using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN.Forms
{
    public partial class FormEditContract : Form
    {
        private bool isEditMode = false;
        private string currentContractCode;

        public FormEditContract()
        {
            InitializeComponent();
            SetupInitialState();
        }

        private void SetupInitialState()
        {
            // Ban đầu tất cả các trường đều không cho phép chỉnh sửa
            SetControlReadOnly(true);
            
            // Setup event handlers
            guna2Button1.Click += BtnEdit_Click;
            guna2Button2.Click += BtnCancel_Click;
            guna2Button3.Click += BtnSave_Click;
            
            // Ban đầu nút Save và Cancel bị ẩn
            guna2Button3.Visible = false;
        }

        private void SetControlReadOnly(bool readOnly)
        {
            guna2TextBox1.ReadOnly = readOnly;
            guna2TextBox2.ReadOnly = readOnly;
            guna2TextBox3.ReadOnly = readOnly;
            guna2TextBox4.ReadOnly = readOnly;
            guna2TextBox5.ReadOnly = readOnly;
            guna2TextBox6.ReadOnly = readOnly;
            guna2TextBox7.ReadOnly = readOnly;
            guna2TextBox8.ReadOnly = readOnly;
            guna2ComboBox1.Enabled = !readOnly;
            guna2DateTimePicker1.Enabled = !readOnly;
            guna2DateTimePicker2.Enabled = !readOnly;
            guna2DateTimePicker3.Enabled = !readOnly;

            // Thay đổi màu nền để hiển thị trạng thái read-only
            Color backColor = readOnly ? Color.FromArgb(240, 240, 240) : Color.White;
            guna2TextBox1.FillColor = backColor;
            guna2TextBox2.FillColor = backColor;
            guna2TextBox3.FillColor = backColor;
            guna2TextBox4.FillColor = backColor;
            guna2TextBox5.FillColor = backColor;
            guna2TextBox6.FillColor = backColor;
            guna2TextBox7.FillColor = backColor;
            guna2TextBox8.FillColor = backColor;
        }

        public void LoadContractData(string contractCode, string customer, string startDate, string endDate, string room, string status)
        {
            currentContractCode = contractCode;
            
            // Load thông tin hợp đồng
            guna2TextBox1.Text = contractCode;
            guna2ComboBox1.Text = room;
            
            // Parse dates
            if (DateTime.TryParse(startDate, out DateTime start))
            {
                guna2DateTimePicker3.Value = start;
            }
            if (DateTime.TryParse(endDate, out DateTime end))
            {
                guna2DateTimePicker2.Value = end;
            }
            
            // Load thông tin người thuê
            guna2TextBox4.Text = customer;
            // guna2TextBox5 sẽ là CCCD người thuê - cần lấy từ database thực tế
            
            // Load thông tin người cho thuê (cần lấy từ database)
            // guna2TextBox6.Text = landlordName;
            // guna2TextBox7.Text = landlordCCCD;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt chế độ chỉnh sửa
            isEditMode = true;
            SetControlReadOnly(false);
            
            // Ẩn nút Sửa, hiện nút Lưu và Hủy
            guna2Button1.Visible = false;
            guna2Button2.Text = "Hủy";
            guna2Button2.BackColor = Color.FromArgb(239, 68, 68);
            guna2Button3.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate data
            if (ValidateData())
            {
                try
                {
                    // TODO: Save contract data to database
                    MessageBox.Show("Lưu hợp đồng thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Thoát khỏi chế độ chỉnh sửa
                    isEditMode = false;
                    SetControlReadOnly(true);
                    
                    // Ẩn nút Lưu, hiện nút Sửa
                    guna2Button1.Visible = true;
                    guna2Button2.Text = "Quay lại";
                    guna2Button2.BackColor = Color.FromArgb(149, 165, 166);
                    guna2Button3.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu hợp đồng: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Hủy chỉnh sửa - quay lại trạng thái ban đầu
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy thay đổi?", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Reload data - có thể reload từ database
                    // LoadContractData(currentContractCode, ...);
                    
                    isEditMode = false;
                    SetControlReadOnly(true);
                    
                    // Hiện lại nút Sửa, ẩn nút Lưu
                    guna2Button1.Visible = true;
                    guna2Button2.Text = "Quay lại";
                    guna2Button2.BackColor = Color.FromArgb(149, 165, 166);
                    guna2Button3.Visible = false;
                }
            }
            else
            {
                // Quay lại form trước (form Contract)
                FormMainSystem mainForm = null;
                Control current = this;
                
                // Tìm FormMainSystem trong control tree
                while (current != null)
                {
                    if (current is FormMainSystem)
                    {
                        mainForm = current as FormMainSystem;
                        break;
                    }
                    current = current.Parent;
                }
                
                if (mainForm != null)
                {
                    // Load lại FormContract
                    var formContract = new FormContract();
                    mainForm.LoadFormIntoMainPanel(formContract);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2ComboBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người thuê!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (guna2DateTimePicker3.Value >= guna2DateTimePicker2.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void labelNgaykihd_Click(object sender, EventArgs e)
        {
            // Event handler placeholder
        }

        private void FormEditContract_Load(object sender, EventArgs e)
        {

        }
    }
}
