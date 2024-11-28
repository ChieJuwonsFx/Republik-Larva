using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Views;


namespace Republik_Larva.Models
{
    internal class M_Login : DatabaseWrapper
    {
        public dataLogin Validate(string username, string password)
        {
            dataLogin login = null;
            string query = "SELECT * FROM admin WHERE username = @username AND password = @password";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@username", username),
                new NpgsqlParameter("@password", password)
            };

            DataTable resultTable = queryExecutor(query, parameters);

            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.Rows[0];
                login = new dataLogin
                {
                    username = row["username"].ToString(),
                    password = row["password"].ToString()
                };
            }

            return login;
        }
        internal class dataLogin
        {
            public string username { get; set; }
            public string password { get; set; }
        }

    }
}