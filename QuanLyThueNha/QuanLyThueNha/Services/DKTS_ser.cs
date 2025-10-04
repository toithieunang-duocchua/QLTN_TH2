using Microsoft.Data.SqlClient;
using QuanLyThueNha;
using System;
using System.Data;

namespace QuanLyThueNha.Services
{
    public class DKTS_ser
    {
        public bool getInfor(string tenTN, string diaChi, int tongSoPhong, int sotang, string ghiChu)
        {
            string query = @"INSERT INTO cannha 
                     (tenTN, diaChi, sotang, tongSoPhong, ngayTao, ghiChu)
                     VALUES (@tenTN, @diaChi, @sotang, @tongSoPhong, @ngayTao, @ghiChu)";

            using (SqlConnection conn = new SqlConnection(Conn.Instance.Connect))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DateTime now = DateTime.Now;
                    cmd.Parameters.AddWithValue("@tenTN", tenTN);
                    cmd.Parameters.AddWithValue("@diaChi", diaChi);
                    cmd.Parameters.AddWithValue("@sotang", sotang);
                    cmd.Parameters.AddWithValue("@tongSoPhong", tongSoPhong);
                    cmd.Parameters.AddWithValue("@ngayTao", now);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }


        public DataTable showInfor()
        {
            string query = "SELECT * FROM cannha";
            return Conn.Instance.excuteQuery(query);
        }

        public DataTable showcannha()
        {
            string query = "SELECT id, tenTN FROM cannha"; 
            return Conn.Instance.excuteQuery(query);
        }

        public DataRow getInforByName(string tenTN)
        {
            string query = $"SELECT * FROM cannha WHERE tenTN = N'{tenTN}'";
            DataTable dt = Conn.Instance.excuteQuery(query);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }







    }
}
