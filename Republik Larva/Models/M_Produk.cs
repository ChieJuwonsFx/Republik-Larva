using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Republik_Larva.Models
{
    public class M_Produk : DatabaseWrapper
    {
        private static string table = "produk";

        public static DataTable All()
        {
            string query = @"
                SELECT produk_id, nama_produk, harga, stok, gambar
                FROM produk
                WHERE isAvailable = TRUE";

            DataTable dataProduk = queryExecutor(query);
            return dataProduk;
        }

        public static M_Produk getProdukById(int id)
        {
            string query = @"
            SELECT produk_id, nama_produk, harga, stok, gambar
            FROM produk
            WHERE produk_id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = id }
            };

            DataTable dataProduk = queryExecutor(query, parameters);
            if (dataProduk.Rows.Count > 0)
            {
                DataRow row = dataProduk.Rows[0];
                M_Produk produk = new M_Produk
                {
                    produk_id = Convert.ToInt32(row["produk_id"]),
                    nama_produk = row["nama_produk"].ToString(),
                    harga = Convert.ToInt32(row["harga"]),
                    stok = Convert.ToInt32(row["stok"]),
                    gambar = row["gambar"] as byte[],
                    isAvailable = true
                };
                return produk;
            }
            return null; 
        }

        public static void AddProduk(M_Produk produkBaru)
        {
            string query = $"INSERT INTO {table} (nama_produk, harga, stok, gambar, isAvailable) VALUES(@nama, @harga, @stok, @gambar, @isAvailable)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", produkBaru.nama_produk),
                new NpgsqlParameter("@harga", produkBaru.harga),
                new NpgsqlParameter("@stok", produkBaru.stok),
                new NpgsqlParameter("@gambar", produkBaru.gambar ?? (object)DBNull.Value),
                new NpgsqlParameter("@isAvailable", true) 
            };
            commandExecutor(query, parameters);
        }

        public static void UpdateProduk(int id, string nama_produk, int harga, int stok, byte[] gambar)
        {
            string query = $"UPDATE {table} SET nama_produk = @nama, harga = @harga, stok = @stok, gambar = @gambar WHERE produk_id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", nama_produk),
                new NpgsqlParameter("@harga", harga),
                new NpgsqlParameter("@stok", stok),
                new NpgsqlParameter("@gambar", gambar ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", id)
            };

            commandExecutor(query, parameters);
        }

        public bool HapusProduk(int id)
        {
            try
            {
                string query = "UPDATE produk SET isAvailable = FALSE WHERE produk_id = @id";

                NpgsqlParameter[] parameters = {
                    new NpgsqlParameter("@id", id)
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
        [Key]
        public int produk_id { get; set; }
        [Required]
        public string nama_produk { get; set; }
        [Required]
        public int harga { get; set; }
        [Required]
        public int stok { get; set; }
        public byte[] gambar { get; set; }
        public bool isAvailable { get; set; }
    }
}
