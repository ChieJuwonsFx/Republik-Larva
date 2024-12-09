using Republik_Larva.Controller;
using Republik_Larva.Models;
using System.Drawing.Imaging;

namespace Republik_Larva.Views.Produk
{
    public partial class V_FormAddProduk : UserControl
    {
        private C_Produk c_Produk;

        public V_FormAddProduk(C_Produk controller)
        {
            InitializeComponent();
            c_Produk = controller;

            // Pastikan SizeMode PictureBox diatur
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namaProduk.Text) ||
                string.IsNullOrWhiteSpace(harga.Text) ||
                string.IsNullOrWhiteSpace(stok.Text))
            {
                MessageBox.Show("Pastikan semua data telah diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Pastikan Anda telah memilih gambar produk!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Png); 
                    byte[] gambarByte = ms.ToArray();

                    M_Produk produkBaru = new M_Produk
                    {
                        nama_produk = namaProduk.Text,
                        harga = int.Parse(harga.Text),
                        stok = int.Parse(stok.Text),
                        gambar = gambarByte
                    };

                    M_Produk.AddProduk(produkBaru);

                    namaProduk.Clear();
                    harga.Clear();
                    stok.Clear();
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    if (pictureBox1.Image != null)
                    {
                        MessageBox.Show("Gambar berhasil dimuat ke PictureBox!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAmbilGambar_Click(object sender, EventArgs e)
        {

        }
    }
}
