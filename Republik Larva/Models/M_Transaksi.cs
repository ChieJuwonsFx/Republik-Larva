using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Npgsql;

namespace Republik_Larva.Models
{
    public class M_Transaksi :DatabaseWrapper
    {
        public List<string> GetStatusPembayaran()
        {
            return new List<string> { "Lunas", "Belum Lunas" };
        }

        public List<string> GetMetodePembayaran()
        {
            return new List<string> { "Cash", "Transfer Bank", "E-Wallet" };
        }

        public DataTable GetProduk()
        {
            string query = "SELECT produk_id, nama_produk, harga, stok FROM produk WHERE stok > 0";
            return queryExecutor(query);
        }
        public void SimpanTransaksi(string statusPembayaran, string metodePembayaran, int totalHarga, int customerId, int adminId)
        {
            string query = @"
                INSERT INTO transaksi 
                (tanggal_transaksi, total_harga, admin_admin_id, customer_customer_id, status_bayar, metode_pembayaran) 
                VALUES 
                (CURRENT_DATE, @total_harga, @admin_id, @customer_id, @status_bayar, @metode_pembayaran)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@total_harga", totalHarga),
                new NpgsqlParameter("@admin_id", adminId),
                new NpgsqlParameter("@customer_id", customerId),
                new NpgsqlParameter("@status_bayar", statusPembayaran),
                new NpgsqlParameter("@metode_pembayaran", metodePembayaran)
            };

            commandExecutor(query, parameters);
        }

        public DataTable GetTransaksiById(int transaksiId)
        {
            string query = "SELECT * FROM transaksi WHERE transaksi_id = @transaksi_id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };
            return queryExecutor(query, parameters);
        }

        public void HapusTransaksi(int transaksiId)
        {
            string query = "DELETE FROM transaksi WHERE transaksi_id = @transaksi_id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };
            commandExecutor(query, parameters);
        }

        public void UpdateTransaksi(int transaksiId, string statusPembayaran, string metodePembayaran, int totalHarga)
        {
            string query = @"
                UPDATE transaksi 
                SET status_bayar = @status_bayar, 
                    metode_pembayaran = @metode_pembayaran, 
                    total_harga = @total_harga 
                WHERE transaksi_id = @transaksi_id";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@status_bayar", statusPembayaran),
                new NpgsqlParameter("@metode_pembayaran", metodePembayaran),
                new NpgsqlParameter("@total_harga", totalHarga),
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };

            commandExecutor(query, parameters);
        }
    }
}
