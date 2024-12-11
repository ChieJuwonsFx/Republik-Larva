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
        C_Produk c_Produk;

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
        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Properties.Resources.editProdukHover;
        }
        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Properties.Resources.editProduk;
        }
        private void btnHapus_MouseEnter(object sender, EventArgs e)
        {
            btnHapus.BackgroundImage = Properties.Resources.hapusProdukHover;
        }
        private void btnHapus_MouseLeave(object sender, EventArgs e)
        {
            btnHapus.BackgroundImage = Properties.Resources.hapusProduk;
        }


    }
}
