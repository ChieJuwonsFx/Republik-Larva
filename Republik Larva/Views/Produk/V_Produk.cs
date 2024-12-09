using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.Produk;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Republik_Larva.Views
{
    public partial class V_Produk : UserControl
    {
        private C_Produk c_Produk;
        M_Produk MProduk;
        public V_Produk(C_Produk controller)
        {
            InitializeComponent();
            c_Produk = controller;

            LoadProduk();
        }

        private void LoadProduk()
        {
            DataTable produkTable = c_Produk.GetProdukList();
            DisplayProduk(produkTable);
        }

        private void DisplayProduk(DataTable produkTable)
        {
            pnProduk.Controls.Clear();

            int xOffset = 10;
            foreach (DataRow row in produkTable.Rows)
            {
                M_Produk produk = new M_Produk
                {
                    nama_produk = row["nama_produk"].ToString(),
                    harga = Convert.ToInt32(row["harga"]),
                    stok = Convert.ToInt32(row["stok"]),
                    gambar = row["gambar"] as byte[]
                };

                cardProduk kartu = new cardProduk
                {
                    Location = new Point(xOffset, 10),
                    Size = new Size(531, 550)
                };

                kartu.SetProdukData(produk);

                pnProduk.Controls.Add(kartu);
                xOffset += kartu.Width + 10;
            }
        }

        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            c_Produk.addView();
        }
    }
}
