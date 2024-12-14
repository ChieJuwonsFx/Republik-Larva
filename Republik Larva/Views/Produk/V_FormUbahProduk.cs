using Republik_Larva.Controller;
using Republik_Larva.Models;
using System.Drawing.Imaging;

namespace Republik_Larva.Views.Produk
{
    public partial class V_FormUbahProduk : UserControl
    {
        private C_Produk c_Produk;
        private int produkId; 

        public V_FormUbahProduk(C_Produk controller, int produkId)
        {
            InitializeComponent();
            c_Produk = controller;
            this.produkId = produkId;

            M_Produk produkData = M_Produk.getProdukById(produkId);
            if (produkData != null)
            {
                SetProdukData(produkData.nama_produk, produkData.harga, produkData.stok, produkData.gambar);
            }
            else
            {
                c_Produk.show_message_box("Produk tidak ditemukan.");
            }
        }

        public void SetProdukData(string nama, int Harga, int Stok, byte[] gambar)
        {
            namaProduk.Text = nama;
            harga.Text = Harga.ToString();
            stok.Text = Stok.ToString();

            if (gambar != null && gambar.Length > 0)
            {
                pictureBox1.Image = new Bitmap(new System.IO.MemoryStream(gambar));
            }
            else
            {
                pictureBox1.Image = Properties.Resources.AllAdmin;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string namaProdukBaru = namaProduk.Text.Trim();
            int hargaBaru = int.TryParse(harga.Text.Trim(), out var hargaProduk) ? hargaProduk : 0;
            int stokBaru = int.TryParse(stok.Text.Trim(), out var stokProduk) ? stokProduk : 0;

            byte[] gambarProduk = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    gambarProduk = ms.ToArray();
                }
            }

            c_Produk.UbahProduk(produkId, namaProdukBaru, hargaBaru, stokBaru, gambarProduk);
        }

        private void uploadGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Pilih Gambar",
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBox1.Image = Image.FromFile(selectedFileName);
                }
                catch (Exception ex)
                {
                    c_Produk.show_message_box($"Gagal memuat gambar: {ex.Message}");
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            c_Produk.balikProduk();
        }

        private void btnSimpan_MouseEnter(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpanHover;
        }

        private void btnSimpan_MouseLeave(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpan;
        }

        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }

        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }
    }
}
