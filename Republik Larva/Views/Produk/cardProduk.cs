using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Views;
using Republik_Larva.Models;

namespace Republik_Larva.Views.Produk
{
    public partial class cardProduk : UserControl
    {
        internal MProduk ProdukData;

        public cardProduk()
        {
            InitializeComponent();
        }

        public void SetProdukData(MProduk produk)
        {
            ProdukData = produk;

            namaProduk.Text = produk.nama_produk ?? "Produk Tidak Diketahui";
            harga.Text = $"Harga: {produk.harga.ToString() ?? "0"}";
            stok.Text = $"Stok: {produk.stok.ToString() ?? "Tidak Ada"}";

            if (produk.gambar != null && produk.gambar.Length > 0)
            {
                using (var ms = new MemoryStream(produk.gambar))
                {
                    imageProduk.Image = Image.FromStream(ms);
                }
            }
            else
            {
                imageProduk.Image = Properties.Resources.bg; 
            }
        }


        private void btnEditProduk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Edit produk: {ProdukData.nama_produk}");
        }

        private void imageProduk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Detail produk: {ProdukData.nama_produk}");
        }
    }
}
