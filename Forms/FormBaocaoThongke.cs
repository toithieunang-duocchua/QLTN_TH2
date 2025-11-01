using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLTN.Forms
{
    public partial class FormBaocaoThongke : Form
    {
        public FormBaocaoThongke()
        {
            InitializeComponent();
            this.Load += FormBaocaoThongke_Load;
        }

        private void FormBaocaoThongke_Load(object sender, EventArgs e)
        {
            SeedDemoData();
        }

        private void SeedDemoData()
        {
            // Summary cards
            card2Value.Text = "24"; // Tổng BĐS
            card3Value.Text = "18"; // HĐ đang hoạt động
            card4Value.Text = "245M"; // Doanh thu tháng
            card1Value.Text = "3"; // Sắp hết hạn

            // Revenue by month (12 months demo)
            revenueChart.Series[0].Points.Clear();
            string[] months = { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            int[] values = { 120, 180, 150, 230, 170, 260, 200, 230, 210, 240, 250, 270 };
            for (int i = 0; i < months.Length; i++)
            {
                revenueChart.Series[0].Points.AddXY(months[i], values[i]);
            }
            revenueChart.ChartAreas[0].AxisX.Interval = 1;
            revenueChart.ChartAreas[0].AxisY.Title = "Triệu VNĐ";

            // Occupancy donut chart
            occupancyChart.Series[0].Points.Clear();
            occupancyChart.Series[0].Points.AddXY("Đang cho thuê", 70);
            occupancyChart.Series[0].Points.AddXY("Đang trống", 25);
            occupancyChart.Series[0].Points.AddXY("Bảo trì", 5);
            occupancyChart.Series[0].Label = "#VALX\n#PERCENT";

            // Expiring contracts table
            DataTable expiring = new DataTable();
            expiring.Columns.Add("Mã hợp đồng");
            expiring.Columns.Add("Tên phòng");
            expiring.Columns.Add("Ngày hết hạn");
            expiring.Columns.Add("Trạng thái");
            expiring.Rows.Add("HD-2023-045", "Phòng A1-101", DateTime.Today.AddDays(15).ToString("dd/MM/yyyy"), "Sắp hết hạn");
            expiring.Rows.Add("HD-2023-078", "Phòng B2-305", DateTime.Today.AddDays(23).ToString("dd/MM/yyyy"), "Sắp hết hạn");
            gridExpiring.DataSource = expiring;

            // Vacant properties table
            DataTable vacant = new DataTable();
            vacant.Columns.Add("Mã phòng");
            vacant.Columns.Add("Tên phòng");
            vacant.Columns.Add("Loại");
            vacant.Columns.Add("Giá thuê");
            vacant.Rows.Add("P-023", "Phòng C3-203", "Căn hộ", "12.000.000đ");
            vacant.Rows.Add("P-045", "Phòng D1-402", "Nhà phố", "25.000.000đ");
            gridVacant.DataSource = vacant;
        }
    }
}
