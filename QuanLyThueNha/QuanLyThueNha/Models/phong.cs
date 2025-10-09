using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Models
{
    public class Phong
    {
        public int id { get; set; }
        public string maPhong { get; set; } = "";
        public int idCanNha { get; set; }
        public int idLoaiPhong { get; set; }
        public double? dienTich { get; set; }
        public int? soNguoiO { get; set; }
        public decimal giaThue { get; set; }
        public string trangThai { get; set; } = "";
        public string? ghiChu { get; set; }
        public DateTime ngayTao { get; set; }
        public DateTime? ngayCapNhat { get; set; }
    }

}
