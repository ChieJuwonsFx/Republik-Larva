using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace Republik_Larva.Models
{
    public class M_Transaksi : DatabaseWrapper
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

        public int SimpanTransaksi(string statusPembayaran, string metodePembayaran, int totalHarga, int customerId, int adminId)
        {
            int transaksiId = 0;
            string query = @"
                INSERT INTO transaksi 
                (tanggal_transaksi, total_harga, admin_admin_id, customer_customer_id, status_bayar, metode_pembayaran) 
                VALUES (CURRENT_DATE, @total_harga, @admin_id, @customer_id, @status_bayar, @metode_pembayaran) 
                RETURNING transaksi_id";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@total_harga", totalHarga),
                new NpgsqlParameter("@admin_id", adminId),
                new NpgsqlParameter("@customer_id", customerId),
                new NpgsqlParameter("@status_bayar", statusPembayaran),
                new NpgsqlParameter("@metode_pembayaran", metodePembayaran)
            };

            DataTable result = queryExecutor(query, parameters);
            if (result.Rows.Count > 0)
            {
                transaksiId = Convert.ToInt32(result.Rows[0][0]);
            }

            return transaksiId;
        }

        public void SimpanDetailTransaksi(int transaksiId, int produkId, int jumlah, int totalHarga)
        {
            string query = @"
                INSERT INTO detail_transaksi 
                (transaksi_transaksi_id, produk_id_produk, jumlah, total_harga) 
                VALUES (@transaksi_id, @produk_id, @jumlah, @total_harga)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId),
                new NpgsqlParameter("@produk_id", produkId),
                new NpgsqlParameter("@jumlah", jumlah),
                new NpgsqlParameter("@total_harga", totalHarga)
            };

            commandExecutor(query, parameters);
        }

        public int TambahAtauAmbilCustomer(string NamaCustomer, string email)
        {
            int customerId;
            string queryCheck = "SELECT customer_id FROM customer WHERE email = @email or nama_customer = @nama_customer";
            string queryInsert = @"
                INSERT INTO customer (nama_customer, email) 
                VALUES (@nama_customer, @email) 
                RETURNING customer_id";

            NpgsqlParameter[] parametersCheck = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@email", email),
                new NpgsqlParameter("@nama_customer", NamaCustomer)
            };

            DataTable result = queryExecutor(queryCheck, parametersCheck);
            if (result.Rows.Count > 0)
            {
                customerId = Convert.ToInt32(result.Rows[0][0]);
            }
            else
            {
                NpgsqlParameter[] parametersInsert = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@nama_customer", NamaCustomer),
                    new NpgsqlParameter("@email", email)
                };

                DataTable insertResult = queryExecutor(queryInsert, parametersInsert);
                customerId = Convert.ToInt32(insertResult.Rows[0][0]);
            }

            return customerId;
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
