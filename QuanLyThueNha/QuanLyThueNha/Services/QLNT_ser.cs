using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyThueNha.Models;

namespace QuanLyThueNha.Services
{
    public class QLNT_ser
    {
        public bool AddTenant(nguoithue nt)
        {
            try
            {
                using (var db = new QLTNDataContext())
                {
                    nt.ngayTao = DateTime.Now;
                    db.Tenants.Add(nt);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<nguoithue> GetTenants()
        {
            using (var db = new QLTNDataContext())
            {
                return db.Tenants.ToList();
            }
        }

        public List<Phong> GetRoomsByBuilding(int idCanNha)
        {
            using (var db = new QLTNDataContext())
            {
                return db.Rooms
                         .Where(p => p.idCanNha == idCanNha)
                         .Select(p => new Phong
                         {
                             id = p.id,
                             maPhong = p.maPhong
                         })
                         .ToList();
            }
        }
        public bool DeleteTenant(int id)
        {
            try
            {
                using (var db = new QLTNDataContext())
                {
                    var tenant = db.Tenants.Find(id);
                    if (tenant != null)
                    {
                        db.Tenants.Remove(tenant);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTenant(nguoithue nt)
        {
            try
            {
                using (var db = new QLTNDataContext())
                {
                    var existingTenant = db.Tenants.FirstOrDefault(t => t.id == nt.id);
                    if (existingTenant == null)
                        return false;

                    existingTenant.hoTen = nt.hoTen;
                    existingTenant.soCCCD = nt.soCCCD;
                    existingTenant.soDienThoai = nt.soDienThoai;
                    existingTenant.email = nt.email;
                    existingTenant.diaChiThuongTru = nt.diaChiThuongTru;
                    existingTenant.gioiTinh = nt.gioiTinh;
                    existingTenant.ngaySinh = nt.ngaySinh;
                    existingTenant.ghiChu = nt.ghiChu;
                    existingTenant.ngayCapNhat = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật người thuê: " + ex.Message);
                return false;
            }
        }

    }
}
