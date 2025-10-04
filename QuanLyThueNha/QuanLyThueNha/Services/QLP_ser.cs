using Microsoft.Data.SqlClient;
using QuanLyThueNha.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha.Services
{
    public class QLP_ser
    {
        public bool getInforRoom(string maPhong, int idCanNha, int idLoaiPhong, float dienTich, decimal giaThue, string trangThai, string ghiChu, int soNguoiO)
        {
            string query = @"INSERT INTO phong (maPhong, idCanNha, idLoaiPhong, dienTich, giaThue, trangThai, ghiChu, ngayTao, soNguoiO) VALUES (@maPhong, @idCanNha, @idLoaiPhong, @dienTich, @giaThue, @trangThai, @ghiChu, @ngayTao, @soNguoiO)";


            using (SqlConnection conn = new SqlConnection(Conn.Instance.Connect))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhong", maPhong);
                    cmd.Parameters.AddWithValue("@idCanNha", idCanNha);
                    cmd.Parameters.AddWithValue("@idLoaiPhong", idLoaiPhong);
                    cmd.Parameters.AddWithValue("@dienTich", dienTich);
                    cmd.Parameters.AddWithValue("@giaThue", giaThue);
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu ?? "");
                    cmd.Parameters.AddWithValue("@ngayTao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@soNguoiO", soNguoiO);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



        public DataTable showInfor()
        {
            string query = @"
                SELECT 
                    p.id,
                    p.maPhong,
                    c.tenTN AS ToaNha,
                    l.tenLoai AS LoaiPhong,
                    p.dienTich,
                    p.soNguoiO,
                    p.giaThue,
                    p.trangThai,
                    p.ngayTao,
                    p.ghiChu
                FROM phong p
                JOIN cannha c ON p.idCanNha = c.id
                JOIN loaiphong l ON p.idLoaiPhong = l.id;
            ";
            return Conn.Instance.excuteQuery(query);
        }


    }
}
