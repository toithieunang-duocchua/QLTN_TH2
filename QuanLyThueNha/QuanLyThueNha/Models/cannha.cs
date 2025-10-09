using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Models
{
    public class Cannha
    {
        public int id { get; set; }
        public string tenTN { get; set; }
        public string diaChi { get; set; }
        public int sotang { get; set; }
        public int tongSoPhong { get; set; }
        public DateTime ngaytao { get; set; }
        public DateTime? ngaycapnhat { get; set; }
        public string? ghichu { get; set; } 

    }

}
