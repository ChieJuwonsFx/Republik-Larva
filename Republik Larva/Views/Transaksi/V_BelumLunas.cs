using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.popUp;

namespace Republik_Larva.Views.Transaksi
{
    public partial class V_BelumLunas : UserControl
    {
        private M_Transaksi transaksiModel;
        private C_Transaksi c_Transaksi;
        public V_BelumLunas(C_Transaksi controller)
        {
            InitializeComponent();
            c_Transaksi = controller;
            transaksiModel = new M_Transaksi(); 
            LoadBelumLunas();
        }
        private void LoadBelumLunas()
        {
            c_Transaksi.LoadBelumLunas(dataGridBelumLunas);
        }

        private void dataGridBelumLunas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridBelumLunas.Rows[e.RowIndex];
                int transaksiId = (int)row.Cells["transaksi_id"].Value;
                string namaCustomer = row.Cells["nama_customer"].Value.ToString();
                string emailCustomer = transaksiModel.GetEmailCustomerByTransaksiId(transaksiId);

                if (dataGridBelumLunas.Columns[e.ColumnIndex].Name == "updateLunasButton")
                {
                    bool result = c_Transaksi.show_confirm_message_box ("Apakah Anda yakin ingin mengubah status transaksi menjadi Lunas? Proses ini tidak dapat dibatalkan.");
                    if (result == true)
                    {
                        transaksiModel.UpdateStatusLunas(transaksiId);

                        DataTable produkTerpilih = transaksiModel.GetProdukTransaksi(transaksiId);
                        string statusPembayaran = "Lunas";
                        string metodePembayaran = "Transfer Bank/e-Wallet";

                        C_Transaksi.GeneratePdfPembayaranLunas(namaCustomer, emailCustomer, produkTerpilih, statusPembayaran, metodePembayaran);
                        c_Transaksi.show_message_box("Status transaksi berhasil diubah menjadi Lunas.");
                    }
                    else
                    {
                        c_Transaksi.show_message_box("Perubahan status transaksi dibatalkan.");
                    }
                }
                else if (dataGridBelumLunas.Columns[e.ColumnIndex].Name == "tagihButton")
                {
                    try
                    {
                        DataTable produkData = transaksiModel.GetProdukTransaksi(transaksiId);
                        C_Transaksi.GeneratePdfTagihan(namaCustomer, emailCustomer, produkData, "Belum Lunas", "Transfer Bank/ e-Wallet");
                        c_Transaksi.show_message_box($"{emailCustomer}");
                        c_Transaksi.show_message_box("Tagihan telah dikirim ke email customer.");
                    }
                    catch (Exception ex)
                    {
                        c_Transaksi.show_message_box("Gagal mengirim tagihan: " + ex.Message);
                    }
                }
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            c_Transaksi.balikTransaksi();
        }
        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }
        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }
    }
}
