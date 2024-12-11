using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Republik_Larva.Models
{
    public class M_Customer : DatabaseWrapper
    {
        public static DataTable All()
        {
            string query = @"
            SELECT nama_customer, email
            FROM customer";

            DataTable dataCustomer = queryExecutor(query);
            return dataCustomer;
        }
    }
}
