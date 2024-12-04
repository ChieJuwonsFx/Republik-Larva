using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Views;
using Republik_Larva.Models;
using NpgsqlTypes;
using System.Numerics;
using Republik_Larva.Controller;
using Republik_Larva.Views.Akun;
using Republik_Larva.Views.Transaksi;
using System.Data;
using System.Windows.Forms;

namespace Republik_Larva.Controller
{
    public class C_Transaksi : C_MessageBox
    {
        C_MainForm C_MainForm;
        private C_MessageBox c_MessageBox;
        V_Transaksi view_transaksi;
        V_TambahTransaksi tambah_transaksi;
        M_Transaksi transaksiModel;
        M_Transaksi M_Produk = new M_Transaksi();
        V_LihatSemua view_semua;
        private int idAdmin;

        public C_Transaksi(C_MainForm controller, int id_admin)
        {
            C_MainForm = controller;
            c_MessageBox = new C_MessageBox();

            transaksiModel = new M_Transaksi();
            this.idAdmin = id_admin;

            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
            UpdateTransaksiBulanIni();
        }
        public void balikTransaksi()
        {
            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
            UpdateTransaksiBulanIni();
        }
        public void semuaTransaksiView()
        {
            view_semua = new V_LihatSemua(this);
            C_MainForm.moveView(view_semua);
        }
        public void tambahTransaksiView()
        {
            tambah_transaksi = new V_TambahTransaksi(this);
            C_MainForm.moveView(tambah_transaksi);
        }
        public void ProsesTransaksi(string NamaCustomer, string email, string statusPembayaran, string metodePembayaran,
                                    DataTable produkTerpilih)
        {
            try
            {
                if (transaksiModel == null)
                    throw new Exception("Model transaksi belum diinisialisasi.");

                if (produkTerpilih == null || produkTerpilih.Rows.Count == 0)
                    throw new Exception("Tidak ada produk yang dipilih.");

                int customerId = transaksiModel.TambahAtauAmbilCustomer(NamaCustomer, email);

                int totalHarga = 0;
                foreach (DataRow row in produkTerpilih.Rows)
                {
                    int jumlah = Convert.ToInt32(row["jumlah"]);
                    int harga = Convert.ToInt32(row["harga"]);
                    totalHarga += jumlah * harga;
                }

                int transaksiId = transaksiModel.SimpanTransaksi(statusPembayaran, metodePembayaran, totalHarga, customerId, idAdmin);

                foreach (DataRow row in produkTerpilih.Rows)
                {
                    int produkId = Convert.ToInt32(row["produk_id"]);
                    int jumlah = Convert.ToInt32(row["jumlah"]);
                    int totalHargaItem = Convert.ToInt32(row["total_harga"]);
                    transaksiModel.SimpanDetailTransaksi(transaksiId, produkId, jumlah, totalHargaItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses transaksi: " + ex.Message);
            }
        }
        public void UpdateTransaksiBulanIni()
        {
            int jumlahTransaksi = transaksiModel.GetJumlahTransaksiBulanIni();
            int totalPenghasilan = transaksiModel.GetTotalPenghasilanBulanIni();
            int totalMaggotTerjual = transaksiModel.GetTotalProdukMaggotTerjualBulanIni();

            view_transaksi.UpdateDashboard(jumlahTransaksi, totalPenghasilan, totalMaggotTerjual);
        }
        public void TampilkanSemuaTransaksi(DataGridView gridView)
        {
            try
            {
                DataTable data = transaksiModel.GetSemuaTransaksi();
                gridView.DataSource = data;

                gridView.Columns["transaksi_id"].HeaderText = "ID Transaksi";
                gridView.Columns["tanggal_transaksi"].HeaderText = "Tanggal";
                gridView.Columns["total_harga"].HeaderText = "Total Harga";
                gridView.Columns["metode_pembayaran"].HeaderText = "Metode Pembayaran";
                gridView.Columns["status_bayar"].HeaderText = "Status Pembayaran";
                gridView.Columns["nama_customer"].HeaderText = "Nama Customer";
                gridView.Columns["nama_admin"].HeaderText = "Nama Admin";
                gridView.Columns["produk"].HeaderText = "Produk (Jumlah)";
            }
            catch (Exception ex)
            {
                show_message_box("Terjadi kesalahan saat memuat data transaksi: ");
            }
        }
        public void TampilkanTransaksiSebulan(DataGridView gridView)
        {
            try
            {
                DataTable data = transaksiModel.GetTransaksiSebulan();
                gridView.DataSource = data;

                gridView.Columns["transaksi_id"].HeaderText = "ID Transaksi";
                gridView.Columns["tanggal_transaksi"].HeaderText = "Tanggal";
                gridView.Columns["total_harga"].HeaderText = "Total Harga";
                gridView.Columns["metode_pembayaran"].HeaderText = "Metode Pembayaran";
                gridView.Columns["status_bayar"].HeaderText = "Status Pembayaran";
                gridView.Columns["nama_customer"].HeaderText = "Nama Customer";
                gridView.Columns["nama_admin"].HeaderText = "Nama Admin";
                gridView.Columns["produk"].HeaderText = "Produk (Jumlah)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data transaksi: " + ex.Message);
            }
        }
    }
}