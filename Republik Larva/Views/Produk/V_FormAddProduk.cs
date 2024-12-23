﻿using Republik_Larva.Controller;
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
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namaProduk.Text) ||
                string.IsNullOrWhiteSpace(harga.Text) ||
                string.IsNullOrWhiteSpace(stok.Text))
            {
                c_Produk.show_message_box("Pastikan semua data telah diisi!");
                return;
            }

            if (pictureBox1.Image == null)
            {
                c_Produk.show_message_box("Pastikan Anda telah memilih gambar produk!");
                return;
            }

            try
            {
                string nama = namaProduk.Text;
                int hargaProduk = int.Parse(harga.Text);
                int stokProduk = int.Parse(stok.Text);

                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Png);
                    byte[] gambar = ms.ToArray();

                    c_Produk.TambahProduk(nama, hargaProduk, stokProduk, gambar);
                }
            }
            catch (Exception ex)
            {
                c_Produk.show_message_box($"Terjadi kesalahan: {ex.Message}");
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
        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }
        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }
        private void btnSimpan_MouseEnter(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpanHover;
        }
        private void btnSimpan_MouseLeave(object sender, EventArgs e)
        {
            btnSimpan.BackgroundImage = Properties.Resources.simpan;
        }
    }
}
