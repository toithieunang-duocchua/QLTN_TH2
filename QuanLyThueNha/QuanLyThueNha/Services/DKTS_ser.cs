using QuanLyThueNha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThueNha.Services
{
    public class DKTS_ser
    {
        public bool AddBuilding(Cannha building)
        {
            try
            {
                using (var db = new QLTNDataContext())
                {
                    if (db.Buildings.Any(b => b.tenTN == building.tenTN))
                    {
                        MessageBox.Show("Tên tòa nhà đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    building.ngaytao = DateTime.Now;
                    building.ghichu = building.ghichu ?? "";

                    db.Buildings.Add(building);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string msg = "Error adding building: " + ex.Message;
                if (ex.InnerException != null)
                    msg += "\nInner: " + ex.InnerException.Message;
                MessageBox.Show(msg, "Lỗi khi thêm tòa nhà", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public List<Cannha> GetAllBuildings()
        {
            using (var db = new QLTNDataContext())
            {
                return db.Buildings.ToList();
            }
        }

        public List<Cannha> GetBuildingNames()
        {
            using (var db = new QLTNDataContext())
            {
                return db.Buildings
                         .Select(b => new Cannha { id = b.id, tenTN = b.tenTN })
                         .ToList();
            }
        }

        public Cannha GetBuildingById(int id)
        {
            using (var db = new QLTNDataContext())
            {
                return db.Buildings.FirstOrDefault(b => b.id == id);
            }
        }

        public Cannha GetBuildingByName(string name)
        {
            using (var db = new QLTNDataContext())
            {
                return db.Buildings.FirstOrDefault(b => b.tenTN == name);
            }
        }
    }
}
