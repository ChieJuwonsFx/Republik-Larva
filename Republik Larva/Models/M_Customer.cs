using System.Data;

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
