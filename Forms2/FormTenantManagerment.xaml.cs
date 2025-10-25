using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLTN.Forms
{
    /// <summary>
    /// Interaction logic for FormTenantManagerment.xaml
    /// </summary>
    public partial class FormTenantManagerment : UserControl
    {
        public List<NguoiThue> NguoiThueList { get; set; }

        public FormTenantManagerment()
        {
            InitializeComponent();
            //=========Test=========
            NguoiThueList = new List<NguoiThue>
            {
                new NguoiThue { Ten="Nguyễn Văn An", Phong="101", SDT="0901234567", TrangThai="Chưa đủ", HopDong="Còn hiệu lực" },
                new NguoiThue { Ten="Trần Thị Bình", Phong="103", SDT="0987654321", TrangThai="Đầy đủ", HopDong="Sắp hết hạn" },
                new NguoiThue { Ten="Phạm Văn C", Phong="105", SDT="0912345678", TrangThai="Chưa lấy", HopDong="Hết hạn" },
                new NguoiThue { Ten="Lê Thị D", Phong="108", SDT="0981122334", TrangThai="Đầy đủ", HopDong="Còn hiệu lực" }
            };

            foreach (var nt in NguoiThueList)
            {
                //  Màu theo trạng thái vân tay
                switch (nt.TrangThai)
                {
                    case "Đầy đủ":
                        nt.MauTrangThai = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DFF6E3"));
                        break;
                    case "Chưa đủ":
                        nt.MauTrangThai = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3CD"));
                        break;
                    case "Chưa lấy":
                        nt.MauTrangThai = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F8D7DA"));
                        break;
                    default:
                        nt.MauTrangThai = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EDEDED"));
                        break;
                }

                //  Màu theo hợp đồng
                switch (nt.HopDong)
                {
                    case "Còn hiệu lực":
                        nt.MauHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8FFF0"));
                        nt.MauChuHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#22B14C"));
                        break;
                    case "Sắp hết hạn":
                        nt.MauHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3CD"));
                        nt.MauChuHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C99700"));
                        break;
                    case "Hết hạn":
                        nt.MauHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F8D7DA"));
                        nt.MauChuHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0392B"));
                        break;
                    default:
                        nt.MauHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EDEDED"));
                        nt.MauChuHopDong = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#666"));
                        break;
                }
            }

            DataContext = this;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sua");
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xóa");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("thêm:");
        }
        private void SearchBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Placeholder.Visibility = string.IsNullOrEmpty(SearchBox.Text) ? Visibility.Visible : Visibility.Hidden;

        }
        //=========Test=========

        public class NguoiThue
        {
            public string Ten { get; set; }
            public string Phong { get; set; }
            public string SDT { get; set; }
            public string TrangThai { get; set; }
            public Brush MauTrangThai { get; set; }

            public string HopDong { get; set; }
            public Brush MauHopDong { get; set; }
            public Brush MauChuHopDong { get; set; }
        }
    }
}
