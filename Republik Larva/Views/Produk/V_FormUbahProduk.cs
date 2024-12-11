using Republik_Larva.Controller;
using Republik_Larva.Models;
using System.Data;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Republik_Larva.Controller;
using Republik_Larva.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Republik_Larva.Views.Produk
{
    public partial class V_FormUbahProduk : UserControl
    {
        private C_Produk c_Produk;
        private M_Produk produkData;

        public V_FormUbahProduk(C_Produk controller, M_Produk dataProduk)
        {
            InitializeComponent();
            c_Produk = controller;
            produkData = dataProduk;

            if (produkData != null)
            {
                namaProduk.Text = produkData.nama_produk;
                harga.Text = produkData.harga.ToString();
                stok.Text = produkData.stok.ToString();

                if (produkData.gambar != null && produkData.gambar.Length > 0)
                {
                    pictureBox1.Image = new Bitmap(new System.IO.MemoryStream(produkData.gambar));
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.AllAdmin; 
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string namaProdukBaru = namaProduk.Text.Trim();
            int hargaBaru = int.TryParse(harga.Text.Trim(), out var hargaProduk) ? hargaProduk : 0;
            int stokBaru = int.TryParse(stok.Text.Trim(), out var stokProduk) ? stokProduk : 0;

            if (produkData != null)
            {
                byte[] gambarProduk = produkData.gambar;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, ImageFormat.Jpeg); 
                        gambarProduk = ms.ToArray(); 
                    }
                }

                produkData.nama_produk = namaProdukBaru;
                produkData.harga = hargaBaru;
                produkData.stok = stokBaru;
                produkData.gambar = gambarProduk;

                M_Produk.UpdateProduk(produkData.produk_id, produkData.nama_produk, produkData.harga, produkData.stok, produkData.gambar);

                c_Produk.show_message_box("Produk berhasil diperbarui.");
                c_Produk.balikProduk(); 
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