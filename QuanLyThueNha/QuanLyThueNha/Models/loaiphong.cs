using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Models
{
    public class loaiphong
    {
        public int id {  get; set; }
        public string tenLoai {  get; set; }
        public string moTa {  get; set; }
        public DateTime ngayTao { get; set; }
        public DateTime ngayCapNhat { get; set; }
    }
}
