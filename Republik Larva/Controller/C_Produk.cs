using Republik_Larva.Views;
using Republik_Larva.Models;
using System.Data;
using Republik_Larva.Views.Produk;

namespace Republik_Larva.Controller
{
    public class C_Produk : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_Produk view_produk;
        V_FormAddProduk view_add;
        V_FormUbahProduk view_ubah;
        M_Produk M_Produk = new M_Produk();
        public C_Produk(C_MainForm controller)
        {
            C_MainForm = controller;
            view_produk = new V_Produk(this);
            C_MainForm.moveView(view_produk);
        }
        public DataTable GetProdukList()
        {
            return M_Produk.All();
        }
        public void balikProduk()
        {
            view_produk = new V_Produk(this);
            C_MainForm.moveView(view_produk);
        }
        public void addView()
        {
            view_add = new V_FormAddProduk(this);
            C_MainForm.moveView(view_add);
        }
        public void editProdukView(int produkId)
        {
            if (produkId <= 0)
            {
                show_message_box($"ID Produk tidak valid.");
                return;
            }
            M_Produk produkData = M_Produk.getProdukById(produkId);  
            if (produkData == null)
            {
                show_message_box("Produk tidak ditemukan.");
            }
            else
            {
                view_ubah = new V_FormUbahProduk(this, produkId); 
                C_MainForm.moveView(view_ubah);
            }
        }
        public void HapusProduk(int produkId)
        {
            bool konfirmasi = show_confirm_message_box("Apakah Anda yakin ingin menghapus produk ini?");
            if (konfirmasi)
            {
                
                bool berhasil = M_Produk.HapusProduk(produkId);
                if (berhasil)
                {
                    show_message_box($"{produkId}");
                    show_message_box("Produk berhasil dihapus.");
                    balikProduk();
                }
                else
                {
                    show_message_box("Gagal menghapus produk.");
                }
            }
        }
        public void TambahProduk(string nama, int harga, int stok, byte[] gambar)
        {
            try
            {
                if (harga <= 0 || stok < 0)
                {
                    show_message_box("Harga dan stok harus bernilai positif!");
                    return;
                }

                M_Produk produkBaru = new M_Produk
                {
                    nama_produk = nama,
                    harga = harga,
                    stok = stok,
                    gambar = gambar
                };

                M_Produk.AddProduk(produkBaru);

                show_message_box("Data produk berhasil ditambahkan");
                balikProduk();
            }
            catch (Exception ex)
            {
                show_message_box($"Terjadi kesalahan saat menambah produk: {ex.Message}");
            }
        }
        public void UbahProduk(int produkId, string nama, int harga, int stok, byte[] gambar)
        {
            try
            {
                if (harga <= 0 || stok < 0)
                {
                    show_message_box("Harga dan stok harus bernilai positif!");
                    return;
                }

                M_Produk.UpdateProduk(produkId, nama, harga, stok, gambar);
                show_message_box("Produk berhasil diperbarui.");
                balikProduk();
            }
            catch (Exception ex)
            {
                show_message_box($"Terjadi kesalahan saat memperbarui produk: {ex.Message}");
            }
        }

    }
}
