﻿using System;
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
                VALUES (CURRENT_TIMESTAMP, @total_harga, @admin_id, @customer_id, @status_bayar, @metode_pembayaran) 
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
            string queryCheck = "SELECT customer_id FROM customer WHERE nama_customer = @nama_customer";
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

        public int GetStokProduk(int produkId)
        {
            string query = "SELECT stok FROM produk WHERE produk_id = @produk_id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@produk_id", produkId)
            };

            DataTable result = queryExecutor(query, parameters);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0]["stok"]) : 0;
        }

        public void KurangiStokProduk(int produkId, int jumlah)
        {
            string query = "UPDATE produk SET stok = stok - @jumlah WHERE produk_id = @produk_id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@produk_id", produkId),
                new NpgsqlParameter("@jumlah", jumlah)
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
        public DataTable GetTransaksiCustomer(int transaksiId)
        {
            string query = @"SELECT 
                t.transaksi_id,
                t.tanggal_transaksi,
                t.total_harga,
                t.metode_pembayaran,
                t.status_bayar,
                c.nama_customer,
                c.email
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            ORDER BY t.tanggal_transaksi DESC;
            ";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };
            return queryExecutor(query, parameters);
        }

        public int GetJumlahTransaksiBulanIni()
        {
            string query = "SELECT COUNT(*) FROM transaksi WHERE EXTRACT(MONTH FROM tanggal_transaksi) = EXTRACT(MONTH FROM CURRENT_DATE)";
            DataTable result = queryExecutor(query);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0][0]) : 0;
        }
        public int GetTotalPenghasilanBulanIni()
        {
            string query = "SELECT SUM(total_harga) FROM transaksi WHERE EXTRACT(MONTH FROM tanggal_transaksi) = EXTRACT(MONTH FROM CURRENT_DATE)";
            DataTable result = queryExecutor(query);
            return result.Rows.Count > 0 && !DBNull.Value.Equals(result.Rows[0][0]) ? Convert.ToInt32(result.Rows[0][0]) : 0;
        }
        public int GetTotalProdukMaggotTerjualBulanIni()
        {
            string query = @"
            SELECT SUM(detail_transaksi.jumlah)
            FROM detail_transaksi
            JOIN produk ON detail_transaksi.produk_id_produk = produk.produk_id
            JOIN transaksi ON detail_transaksi.transaksi_transaksi_id = transaksi.transaksi_id
            WHERE produk.nama_produk = 'Maggot'
              AND EXTRACT(MONTH FROM transaksi.tanggal_transaksi) = EXTRACT(MONTH FROM CURRENT_DATE)";
            DataTable result = queryExecutor(query);
            return result.Rows.Count > 0 && !DBNull.Value.Equals(result.Rows[0][0]) ? Convert.ToInt32(result.Rows[0][0]) : 0;
        }
        public DataTable GetSemuaTransaksi()
        {
            string query = @"
            SELECT 
                t.transaksi_id,
                t.tanggal_transaksi,
                t.total_harga,
                t.metode_pembayaran,
                t.status_bayar,
                c.nama_customer,
                a.nama_admin,
                STRING_AGG(CONCAT(d.nama_produk, ' (', d.jumlah, ')'), ', ') AS produk
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            JOIN admin a ON t.admin_admin_id = a.admin_id
            JOIN (
                SELECT 
                    dt.transaksi_transaksi_id,
                    p.nama_produk,
                    dt.jumlah
                FROM detail_transaksi dt
                JOIN produk p ON dt.produk_id_produk = p.produk_id
            ) d ON t.transaksi_id = d.transaksi_transaksi_id
            GROUP BY t.transaksi_id, c.nama_customer, a.nama_admin
            ORDER BY t.tanggal_transaksi DESC";
            return queryExecutor(query);
        }

        public DataTable GetTransaksiSebulan()
        {
            string query = @"
            SELECT 
                t.transaksi_id,
                t.tanggal_transaksi,
                t.total_harga,
                t.metode_pembayaran,
                t.status_bayar,
                c.nama_customer,
                a.nama_admin,
                STRING_AGG(CONCAT(d.nama_produk, ' (', d.jumlah, ')'), ', ') AS produk
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            JOIN admin a ON t.admin_admin_id = a.admin_id
            JOIN (
                SELECT 
                    dt.transaksi_transaksi_id,
                    p.nama_produk,
                    dt.jumlah
                FROM detail_transaksi dt
                JOIN produk p ON dt.produk_id_produk = p.produk_id
            ) d ON t.transaksi_id = d.transaksi_transaksi_id
            WHERE EXTRACT(MONTH FROM t.tanggal_transaksi) = EXTRACT(MONTH FROM CURRENT_DATE)
            GROUP BY t.transaksi_id, c.nama_customer, a.nama_admin
            ORDER BY t.tanggal_transaksi DESC";
            return queryExecutor(query);
        }

        public DataTable GetBatalTransaksi()
        {
            string query = @"
            SELECT 
                t.transaksi_id,
                t.tanggal_transaksi,
                t.total_harga,
                t.metode_pembayaran,
                t.status_bayar,
                c.nama_customer,
                a.nama_admin,
                STRING_AGG(CONCAT(d.nama_produk, ' (', d.jumlah, ')'), ', ') AS produk
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            JOIN admin a ON t.admin_admin_id = a.admin_id
            JOIN (
                SELECT 
                    dt.transaksi_transaksi_id,
                    p.nama_produk,
                    dt.jumlah
                FROM detail_transaksi dt
                JOIN produk p ON dt.produk_id_produk = p.produk_id
            ) d ON t.transaksi_id = d.transaksi_transaksi_id
            WHERE t.tanggal_transaksi >= CURRENT_TIMESTAMP - INTERVAL '30 minutes'
            GROUP BY t.transaksi_id, c.nama_customer, a.nama_admin
            ORDER BY t.tanggal_transaksi DESC";
            return queryExecutor(query);
        }
        public DataTable GetBelumBayar()
        {
            string query = @"
            SELECT 
                t.transaksi_id,
                t.tanggal_transaksi,
                t.total_harga,
                t.metode_pembayaran,
                t.status_bayar,
                c.nama_customer,
                a.nama_admin,
                STRING_AGG(CONCAT(d.nama_produk, ' (', d.jumlah, ')'), ', ') AS produk
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            JOIN admin a ON t.admin_admin_id = a.admin_id
            JOIN (
                SELECT 
                    dt.transaksi_transaksi_id,
                    p.nama_produk,
                    dt.jumlah
                FROM detail_transaksi dt
                JOIN produk p ON dt.produk_id_produk = p.produk_id
            ) d ON t.transaksi_id = d.transaksi_transaksi_id
            WHERE t.status_bayar = 'Belum Lunas' 
            GROUP BY t.transaksi_id, c.nama_customer, a.nama_admin
            ORDER BY t.tanggal_transaksi DESC";

            return queryExecutor(query);
        }
        public string GetEmailCustomerByTransaksiId(int transaksiId)
        {
            string query = @"
            SELECT c.email
            FROM transaksi t
            JOIN customer c ON t.customer_customer_id = c.customer_id
            WHERE t.transaksi_id = @transaksi_id";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };

            try
            {
                DataTable result = queryExecutor(query, parameters);
                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["email"].ToString(); 
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }



        public DataTable GetProdukTransaksi(int transaksiId)
        {
            string query = @"
            SELECT 
                p.produk_id,
                p.nama_produk,
                dt.jumlah,
                dt.total_harga,
                p.harga
            FROM detail_transaksi dt
            JOIN produk p ON dt.produk_id_produk = p.produk_id
            WHERE dt.transaksi_transaksi_id = @transaksi_id";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };

            return queryExecutor(query, parameters);
        }


        public DateTime GetWaktuTransaksi(int transaksiId)
        {
            string query = "SELECT tanggal_transaksi FROM transaksi WHERE transaksi_id = @transaksi_id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", transaksiId)
            };
            DataTable result = queryExecutor(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToDateTime(result.Rows[0]["tanggal_transaksi"]);
            }
            else
            {
                throw new Exception("Transaksi tidak ditemukan.");
            }
        }
        public void HapusTransaksi(int transaksiId)
        {
            DateTime waktuTransaksi = GetWaktuTransaksi(transaksiId);
            TimeSpan selisihWaktu = DateTime.Now - waktuTransaksi;

            if (selisihWaktu.TotalMinutes < 10)
            {
                string queryDetail = "SELECT produk_id_produk, jumlah FROM detail_transaksi WHERE transaksi_transaksi_id = @transaksi_id";
                NpgsqlParameter[] parametersDetail = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@transaksi_id", transaksiId)
                };
                DataTable detailTransaksi = queryExecutor(queryDetail, parametersDetail);

                foreach (DataRow row in detailTransaksi.Rows)
                {
                    int produkId = Convert.ToInt32(row["produk_id_produk"]);
                    int jumlah = Convert.ToInt32(row["jumlah"]);

                    string queryUpdateStok = "UPDATE produk SET stok = stok + @jumlah WHERE produk_id = @produk_id";
                    NpgsqlParameter[] parametersUpdateStok = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("@produk_id", produkId),
                        new NpgsqlParameter("@jumlah", jumlah)
                    };
                    commandExecutor(queryUpdateStok, parametersUpdateStok);
                }

                commandExecutor("DELETE FROM detail_transaksi WHERE transaksi_transaksi_id = @transaksi_id", parametersDetail);

                string query = "DELETE FROM transaksi WHERE transaksi_id = @transaksi_id";
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@transaksi_id", transaksiId)
                };
                commandExecutor(query, parameters);
            }
            else
            {
                throw new Exception("Transaksi sudah lebih dari 10 menit, tidak dapat dihapus.");
            }
        }
        public void UpdateStatusLunas(int transaksiId)
        {
            string query = @"
            UPDATE transaksi 
            SET status_bayar = 'Lunas' 
            WHERE transaksi_id = @transaksi_id";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@transaksi_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = transaksiId }
            };

            commandExecutor(query, parameters);
        }

    }
}
