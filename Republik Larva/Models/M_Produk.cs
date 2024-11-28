using Npgsql;
using System;
using Republik_Larva.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Republik_Larva.Models
{
    public class MProduk : DatabaseWrapper
    {
        private static string table = "produk";

        public static DataTable All()
        {
            string query = @"
                SELECT produk_id, nama_produk, harga, stok, gambar
                FROM produk";

            DataTable dataProduk = queryExecutor(query);
            return dataProduk;
        }

        public static DataTable getProdukById(int id)
        {
            string query = @"
                SELECT * 
                FROM produk
                WHERE produk_id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = id }
            };

            DataTable dataProduk = queryExecutor(query, parameters);
            return dataProduk;
        }

        public static void AddProduk(MProduk produkBaru)
        {
            string query = $"INSERT INTO {table} (nama_produk, harga, stok, gambar) VALUES(@nama, @harga, @stok, @gambar)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", produkBaru.nama_produk),
                new NpgsqlParameter("@harga", produkBaru.harga),
                new NpgsqlParameter("@stok", produkBaru.stok),
                new NpgsqlParameter("@gambar", produkBaru.gambar ?? (object)DBNull.Value) 
            };

            commandExecutor(query, parameters);
        }

        public static void UpdateProduk(MProduk produk)
        {
            string query = $"UPDATE {table} SET nama_produk = @nama, harga = @harga, stok = @stok, gambar = @gambar WHERE produk_id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", produk.nama_produk),
                new NpgsqlParameter("@harga", produk.harga),
                new NpgsqlParameter("@stok", produk.stok),
                new NpgsqlParameter("@gambar", produk.gambar ?? (object)DBNull.Value),
                new NpgsqlParameter("@id", produk.produk_id)
            };

            commandExecutor(query, parameters);
        }

        public static void DeleteProduk(int id)
        {
            string query = $"DELETE FROM {table} WHERE produk_id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", id)
            };

            commandExecutor(query, parameters);
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
    }
}
