using Microsoft.Data.SqlClient;
using QuanLyThueNha.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Services
{
    public class QLP_ser
    {
        public bool AddRoom(Phong p)
        {
            try
            {
                using(var db = new QLTNDataContext())
                {
                    var room = new Phong
                    {
                        maPhong = p.maPhong,
                        idCanNha = p.idCanNha,
                        idLoaiPhong = p.idLoaiPhong,
                        dienTich = p.dienTich,
                        soNguoiO = p.soNguoiO,
                        giaThue = p.giaThue,
                        trangThai = p.trangThai,
                        ghiChu = p.ghiChu,
                        ngayTao = DateTime.Now,
                        ngayCapNhat = p.ngayCapNhat,
                    };
                    db.Rooms.Add(room);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error adding room: " + e.Message);
                return false;
            }
        }

        public List<Phong> GetRoomsByBuilding(int idCanNha)
        {
            using (var db = new QLTNDataContext())
            {
                return db.Rooms
                         .Where(r => r.idCanNha == idCanNha)
                         .ToList();
            }
        }



        public Phong GetRoomById(int id)
        {
            using (var db = new QLTNDataContext())
            {
                return db.Rooms.FirstOrDefault(r => r.id == id);
            }
        }

        public List<object> ShowRoomInformation()
        {
            using (var db = new QLTNDataContext())
            {
                var result = from p in db.Rooms
                             join c in db.Buildings on p.idCanNha equals c.id
                             join l in db.RoomType on p.idLoaiPhong equals l.id
                             select new
                             {
                                 p.id,
                                 p.maPhong,
                                 ToaNha = c.tenTN,
                                 LoaiPhong = l.tenLoai,
                                 p.dienTich,
                                 p.soNguoiO,
                                 p.giaThue,
                                 p.trangThai,
                                 p.ngayTao,
                                 p.ghiChu
                             };

                return result.ToList<object>();
            }
        }


    }
}
