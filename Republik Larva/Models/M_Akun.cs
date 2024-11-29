﻿using System;
using System.Data;
using Npgsql;

namespace Republik_Larva.Models
{
    public class M_Akun : DatabaseWrapper
    {
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
                string query = "INSERT INTO admin (nama_admin, username, password) VALUES (@namaAdmin, @username, @password)";

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
    }
    public class DataAkun
    {
        public int admin_id { get; set; }
        public string nama_admin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}