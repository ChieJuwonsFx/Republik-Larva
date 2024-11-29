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
        private C_Produk _controller;
        M_Produk MProduk;
        public V_Produk(C_Produk controller)
        {
            InitializeComponent();
            _controller = controller;

            LoadProduk();
        }

        private void LoadProduk()
        {
            DataTable produkTable = _controller.GetProdukList();
            DisplayProduk(produkTable);
        }

        private void DisplayProduk(DataTable produkTable)
        {
            pnProduk.Controls.Clear();

            int yOffset = 10;
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
                    Location = new Point(10, yOffset),
                    Size = new Size(430, 550)
                };

                kartu.SetProdukData(produk);

                pnProduk.Controls.Add(kartu);

                yOffset += kartu.Height + 10;
            }
        }
    }
}
