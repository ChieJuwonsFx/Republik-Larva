using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Models;

namespace Republik_Larva.Views.Transaksi
{
    public partial class V_TambahTransaksi1 : UserControl
    {
        C_Transaksi c_Transaksi;
        public V_TambahTransaksi1(C_Transaksi controller)
        {
            InitializeComponent();
            LoadProduk();
        }

        private void LoadProduk()
        {
            try
            {
                // Ambil data produk dari database
                DataTable produkTable = M_Produk.All();

                int yPosition = 10; // Posisi awal Y untuk kontrol
                foreach (DataRow row in produkTable.Rows)
                {
                    // Membuat RadioButton
                    RadioButton radioButton = new RadioButton
                    {
                        Text = row["nama_produk"].ToString(),
                        Location = new Point(10, yPosition),
                        AutoSize = true,
                        Tag = row["produk_id"] // Simpan ID produk di Tag
                    };

                    // Membuat NumericUpDown
                    NumericUpDown numericUpDown = new NumericUpDown
                    {
                        Location = new Point(200, yPosition),
                        Width = 50,
                        Minimum = 0,
                        Maximum = Convert.ToInt32(row["stok"])
                    };

                    // Tambahkan kontrol ke panel
                    panelProduk.Controls.Add(radioButton);
                    panelProduk.Controls.Add(numericUpDown);

                    // Update posisi untuk kontrol berikutnya
                    yPosition += 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading produk: " + ex.Message);
            }
        }
    }
}
