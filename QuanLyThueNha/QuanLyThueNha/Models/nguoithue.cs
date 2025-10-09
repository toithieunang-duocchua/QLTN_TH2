using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Models
{
    public class nguoithue
    {
        public int id { get; set; }
        public string hoTen { get; set; }
        public string? soCCCD { get; set; }
        public string soDienThoai { get; set; }
        public string? email { get; set; }
        public string? diaChiThuongTru { get; set; }
        public string gioiTinh { get; set; }
        public DateTime? ngaySinh { get; set; }
        public DateTime ngayTao { get; set; }
        public string? ghiChu { get; set; }
        public DateTime ngayCapNhat { get; set; }
    }
}
