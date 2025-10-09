using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThueNha
{

    public class Conn
    {
        private static Conn instance;

        public static Conn Instance
        {
            get { if (instance == null) instance = new Conn(); return instance; }
            private set { instance = value; }
        }

        private Conn() { }


        public string Connect = "Data Source=NHUYLAMNGOC;Initial Catalog=quanlythuenha;Integrated Security=True;TrustServerCertificate=True";


        public DataTable excuteQuery(string query)
        {


            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(Connect))
            {

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public int excuteNonQuery(string query)
        {
            int data = 0;


            using (SqlConnection connection = new SqlConnection(Connect))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    data = cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public object excuteScalar(string query)
        {
            object data = 0;


            using (SqlConnection connection = new SqlConnection(Connect))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    data = cmd.ExecuteScalar();
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public bool check(string query)
        {
            if (excuteNonQuery(query) > 0)
                return true;
            return false;
        }

    }
}
