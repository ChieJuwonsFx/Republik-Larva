using System;
using System.Data;
using Npgsql;

namespace Republik_Larva.Models
{
    public class M_Akun : DatabaseWrapper
    {
        private static string table = "admin";

        public static DataTable All()
        {
            string query = @"
            SELECT admin_id, nama_admin, username
            FROM admin
            WHERE isActive = true";  

            DataTable dataAdmin = queryExecutor(query);
            return dataAdmin;
        }
        public DataAkun Validate(string username, string password)
        {
            DataAkun login = null;
            string query = "SELECT * FROM admin WHERE username = @username AND password = @password";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@username", username),
                new NpgsqlParameter("@password", password)
            };

            DataTable resultTable = queryExecutor(query, parameters);

            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.Rows[0];
                login = new DataAkun
                {
                    admin_id = Convert.ToInt32(row["admin_id"]),
                    nama_admin = row["nama_admin"].ToString(),
                    username = row["username"].ToString(),
                    password = row["password"].ToString()
                };
            }
            return login;
        }

        public DataAkun GetDataById(int id)
        {
            DataAkun akun = null;
            string query = "SELECT * FROM admin WHERE admin_id = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id", id)
            };

            DataTable resultTable = queryExecutor(query, parameters);

            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.Rows[0];
                akun = new DataAkun
                {
                    admin_id = Convert.ToInt32(row["admin_id"]),
                    nama_admin = row["nama_admin"].ToString(),
                    username = row["username"].ToString(),
                    password = row["password"].ToString()
                };
            }
            return akun;
        }
        public bool TambahAdmin(string namaAdmin, string username, string password)
        {
            try
            {
                string query = "INSERT INTO admin (nama_admin, username, password, isActive) VALUES (@namaAdmin, @username, @password, true)";

                NpgsqlParameter[] parameters = {
                    new NpgsqlParameter("@namaAdmin", namaAdmin),
                    new NpgsqlParameter("@username", username),
                    new NpgsqlParameter("@password", password)
                };

                queryExecutor(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool UpdateAdmin(int id, string namaAdmin, string password)
        {
            try
            {
                string query = "UPDATE admin SET nama_admin = @namaAdmin, password = @password WHERE admin_id = @id";

                List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@namaAdmin", namaAdmin),
                    new NpgsqlParameter("@password", password),
                    new NpgsqlParameter("@id", id)
                };

                queryExecutor(query, parameters.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating admin: " + ex.Message); 
                return false;
            }
        }
        public bool HapusAdmin(int adminId)
        {
            try
            {
                string query = "UPDATE admin SET isActive = false WHERE admin_id = @id";

                NpgsqlParameter[] parameters = {
                    new NpgsqlParameter("@id", adminId)
                };

                queryExecutor(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting admin: " + ex.Message);
                return false;
            }
        }
    }

    public class DataAkun
    {
        public int admin_id { get; set; }
        public string nama_admin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string isActive { get; set; }
    }
}
