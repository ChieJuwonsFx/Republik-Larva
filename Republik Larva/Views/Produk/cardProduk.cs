using Republik_Larva.Controller;

namespace Republik_Larva.Views.Produk
{
    public partial class cardProduk : UserControl
    {
        private C_Produk c_Produk; 
        private int produkId;

        public cardProduk(C_Produk controller)
        {
            InitializeComponent();
            c_Produk = controller;
        }

        public void SetProdukData(int id, string nama, int Harga, int Stok, byte[] gambar)
        {
            produkId = id; 
            namaProduk.Text = nama;
            harga.Text = $"Harga: {Harga}";
            stok.Text = $"Stok: {Stok}";

            if (gambar != null && gambar.Length > 0)
            {
                imageProduk.Image = new Bitmap(new MemoryStream(gambar));
            }
            else
            {
                imageProduk.Image = Properties.Resources.bg; 
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            c_Produk.editProdukView(produkId);
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
            c_Produk.HapusProduk(produkId);
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
