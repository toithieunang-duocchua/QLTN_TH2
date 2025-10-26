using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using QLTN.Models;
using QLTN.Services;

namespace QLTN.Forms
{
    public partial class FormTenant : Form
    {
        private readonly TenantService tenantService = new TenantService();
        private readonly BindingSource tenantBindingSource = new BindingSource();
        private readonly Dictionary<string, string> fingerprintCache = new Dictionary<string, string>();
        private readonly Dictionary<string, string> contractCache = new Dictionary<string, string>();
        private List<Tenant> tenants = new List<Tenant>();
        private bool suppressFilterEvent;

        public FormTenant()
        {
            InitializeComponent();
            ConfigureGrid();
            dataGridViewTenants.DataSource = tenantBindingSource;
            Load += FormTenant_Load;
        }

        private void FormTenant_Load(object sender, EventArgs e)
        {
            LoadTenantData();
        }

        private void ConfigureGrid()
        {
            dataGridViewTenants.AutoGenerateColumns = false;

            TenantNameColumn.DataPropertyName = nameof(Tenant.FullName);
            RoomColumn.DataPropertyName = nameof(Tenant.RoomCode);
            PhoneColumn.DataPropertyName = nameof(Tenant.PhoneNumber);
            FingerprintColumn.DataPropertyName = nameof(Tenant.FingerprintStatus);
            ContractColumn.DataPropertyName = nameof(Tenant.ContractStatus);

            dataGridViewTenants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
            dataGridViewTenants.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridViewTenants.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridViewTenants.DefaultCellStyle.ForeColor = Color.FromArgb(55, 55, 65);
            dataGridViewTenants.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 235, 255);
            dataGridViewTenants.DefaultCellStyle.SelectionForeColor = Color.FromArgb(55, 55, 65);
            dataGridViewTenants.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dataGridViewTenants.EnableHeadersVisualStyles = false;
        }

        private void LoadTenantData()
        {
            try
            {
                tenants = new List<Tenant>(tenantService.GetTenantSummaries());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"KhÃ´ng thá»ƒ táº£i danh sÃ¡ch ngÆ°á»i thuÃª.\nChi tiáº¿t: {ex.Message}",
                    "Lá»—i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateRoomFilter();
            ApplyFilters();
        }

        private void PopulateRoomFilter()
        {
            suppressFilterEvent = true;
            cmbRoomFilter.Items.Clear();
            cmbRoomFilter.Items.Add("Táº¥t cáº£ phÃ²ng");

            IEnumerable<string> rooms = tenants
                .Select(t => t.RoomCode)
                .Where(code => !string.IsNullOrWhiteSpace(code))
                .Distinct()
                .OrderBy(code => code);

            foreach (string room in rooms)
            {
                cmbRoomFilter.Items.Add(room);
            }

            if (cmbRoomFilter.Items.Count > 0)
            {
                cmbRoomFilter.SelectedIndex = 0;
            }

            suppressFilterEvent = false;
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();
            string selectedRoom = cmbRoomFilter.SelectedItem as string ?? string.Empty;
            bool allRooms = string.IsNullOrEmpty(selectedRoom) || selectedRoom.Equals("Táº¥t cáº£ phÃ²ng", StringComparison.OrdinalIgnoreCase);

            IEnumerable<Tenant> filtered = tenants.Where(t =>
            {
                bool matchRoom = allRooms || string.Equals(t.RoomCode, selectedRoom, StringComparison.OrdinalIgnoreCase);
                if (!matchRoom)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(keyword))
                {
                    return true;
                }

                return (!string.IsNullOrEmpty(t.FullName) && t.FullName.ToLowerInvariant().Contains(keyword))
                       || (!string.IsNullOrEmpty(t.RoomCode) && t.RoomCode.ToLowerInvariant().Contains(keyword))
                       || (!string.IsNullOrEmpty(t.PhoneNumber) && t.PhoneNumber.ToLowerInvariant().Contains(keyword));
            }).ToList();

            tenantBindingSource.DataSource = filtered.ToList();
            tenantBindingSource.ResetBindings(false);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbRoomFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressFilterEvent)
            {
                return;
            }

            ApplyFilters();
        }

        private void BtnAddTenant_Click(object sender, EventArgs e)
        {
            using (FormAddTenant addTenant = new FormAddTenant())
            {
                if (addTenant.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTenantData();
                }
            }
        }

        private void DataGridViewTenants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Tenant tenant = tenantBindingSource[e.RowIndex] as Tenant;
            if (tenant == null)
            {
                return;
            }

            string contractInfo = tenant.ContractStart.HasValue && tenant.ContractEnd.HasValue
                ? $"{tenant.ContractStart:dd/MM/yyyy} - {tenant.ContractEnd:dd/MM/yyyy}"
                : "ChÆ°a cáº­p nháº­t";

            MessageBox.Show(
                $"Há» tÃªn: {tenant.FullName}\n" +
                $"Äiá»‡n thoáº¡i: {tenant.PhoneNumber}\n" +
                $"Email: {tenant.Email}\n" +
                $"PhÃ²ng: {tenant.RoomCode}\n" +
                $"Há»£p Ä‘á»“ng: {tenant.ContractNumber}\n" +
                $"Thá»i háº¡n: {contractInfo}",
                "ThÃ´ng tin ngÆ°á»i thuÃª",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void DataGridViewTenants_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Tenant tenant = tenantBindingSource[e.RowIndex] as Tenant;
            if (tenant == null)
            {
                return;
            }

            DataGridViewColumn column = dataGridViewTenants.Columns[e.ColumnIndex];

            if (column == FingerprintColumn)
            {
                string label = NormalizeFingerprintStatus(tenant);
                e.Value = label;
                e.FormattingApplied = true;
            }
            else if (column == ContractColumn)
            {
                string label = NormalizeContractStatus(tenant);
                e.Value = label;
                e.FormattingApplied = true;
            }
        }

        private void DataGridViewTenants_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewColumn column = dataGridViewTenants.Columns[e.ColumnIndex];
            if (column != FingerprintColumn && column != ContractColumn)
            {
                return;
            }

            string text = Convert.ToString(e.FormattedValue) ?? string.Empty;
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            Color background = column == FingerprintColumn
                ? GetFingerprintColor(text)
                : GetContractColor(text);

            Color foreground = Color.White;

            PaintStatusChip(e, text, background, foreground);
        }

        private void PaintStatusChip(DataGridViewCellPaintingEventArgs e, string text, Color background, Color foreground)
        {
            e.PaintBackground(e.ClipBounds, true);

            Rectangle bounds = e.CellBounds;
            bounds.Inflate(-10, -14);

            using (GraphicsPath path = CreateRoundedRectangle(bounds, 18))
            using (SolidBrush backBrush = new SolidBrush(background))
            using (SolidBrush textBrush = new SolidBrush(foreground))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(backBrush, path);
                e.Graphics.DrawString(text, new Font("Segoe UI Semibold", 9F, FontStyle.Bold), textBrush, bounds, format);
            }

            e.Handled = true;
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

                private string NormalizeFingerprintStatus(Tenant tenant)
        {
            string raw = tenant.FingerprintStatus;
            if (!string.IsNullOrWhiteSpace(raw))
            {
                raw = raw.Trim();
                if (fingerprintCache.TryGetValue(raw, out string cached))
                {
                    return cached;
                }
            }

            string label;
            if (string.IsNullOrWhiteSpace(raw))
            {
                label = "Chưa lấy (0/?)";
            }
            else
            {
                string normalized = raw.ToLowerInvariant();
                if (normalized.Contains("hoan") || normalized.Contains("đã lấy") || normalized.Contains("da lay"))
                {
                    label = "Hoàn tất (2/2)";
                }
                else if (normalized.Contains("chua du") || normalized.Contains("đang lấy") || normalized.Contains("dang lay"))
                {
                    label = "Chưa đủ (1/2)";
                }
                else
                {
                    label = raw;
                }
            }

            fingerprintCache[raw ?? string.Empty] = label;
            return label;
        }

        private string NormalizeContractStatus(Tenant tenant)
        {
            string raw = tenant.ContractStatus;
            if (!string.IsNullOrWhiteSpace(raw))
            {
                raw = raw.Trim();
                if (contractCache.TryGetValue(raw, out string cached))
                {
                    return cached;
                }
            }

            string label;
            if (string.IsNullOrWhiteSpace(raw))
            {
                label = "Chưa có";
            }
            else
            {
                string normalized = raw.ToLowerInvariant();
                if (normalized.Contains("dang hieu") || normalized.Contains("đang thuê") || normalized.Contains("dang thue"))
                {
                    label = "Còn hiệu lực";
                }
                else if (normalized.Contains("sap") || normalized.Contains("sắp"))
                {
                    label = "Sắp hết hạn";
                }
                else if (normalized.Contains("het") || normalized.Contains("hết"))
                {
                    label = "Hết hạn";
                }
                else
                {
                    label = raw;
                }
            }

            contractCache[raw ?? string.Empty] = label;
            return label;
        }
private static Color GetFingerprintColor(string label)
        {
            string normalized = label.ToLowerInvariant();
            if (normalized.Contains("hoÃ n") || normalized.Contains("hoan"))
            {
                return Color.FromArgb(76, 175, 80);
            }

            if (normalized.Contains("Ä‘á»§") || normalized.Contains("du"))
            {
                return Color.FromArgb(242, 153, 74);
            }

            return Color.FromArgb(231, 76, 60);
        }

        private static Color GetContractColor(string label)
        {
            string normalized = label.ToLowerInvariant();
            if (normalized.Contains("cÃ²n") || normalized.Contains("con"))
            {
                return Color.FromArgb(46, 204, 113);
            }

            if (normalized.Contains("sáº¯p") || normalized.Contains("sap"))
            {
                return Color.FromArgb(243, 156, 18);
            }

            if (normalized.Contains("háº¿t") || normalized.Contains("het"))
            {
                return Color.FromArgb(231, 76, 60);
            }

            return Color.FromArgb(99, 110, 114);
        }
    }
}


