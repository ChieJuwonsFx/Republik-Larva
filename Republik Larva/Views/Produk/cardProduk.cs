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
        internal M_Produk ProdukData;

        public cardProduk()
        {
            InitializeComponent();
        }

        public void SetProdukData(M_Produk produk)
        {
            ProdukData = produk;

            namaProduk.Text = produk.nama_produk;
            harga.Text = $"Harga: {produk.harga.ToString()}";
            stok.Text = $"Stok: {produk.stok.ToString()}";

            if (produk.gambar != null && produk.gambar.Length > 0)
            {
                imageProduk.Image = new Bitmap(new MemoryStream(produk.gambar));
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
