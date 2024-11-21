using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Models;

namespace Republik_Larva.Views
{
    public partial class V_Produk : Form
    {
        public V_Produk()
        {
            InitializeComponent();
            this.Load += ProdukForm_load;
        }

        private void ProdukForm_load(object sender, EventArgs e)
        {
            LoadDataProduk();
        }


        private void LoadDataProduk()
        {
            try
            {
                dataGridProduk.AllowUserToAddRows = false;

                DataTable ProdukData = M_Produk.All();
                if (ProdukData == null || ProdukData.Rows.Count == 0)
                {
                    MessageBox.Show("Error: Gagal mengambil data produk atau tidak ada data.");
                    return;
                }

                dataGridProduk.Columns.Clear();

                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn();
                nomorColumn.HeaderText = "No";
                nomorColumn.Name = "nomor";
                dataGridProduk.Columns.Add(nomorColumn);

                // Menyambungkan data ke DataGridView
                dataGridProduk.DataSource = ProdukData;

                // Ubah "id" menjadi "produk_id"
                if (dataGridProduk.Columns["produk_id"] != null) dataGridProduk.Columns["produk_id"].Visible = false;
                if (dataGridProduk.Columns["nama_produk"] != null)
                    dataGridProduk.Columns["nama_produk"].HeaderText = "Nama";
                if (dataGridProduk.Columns["harga"] != null)
                    dataGridProduk.Columns["harga"].HeaderText = "Harga";
                if (dataGridProduk.Columns["stok"] != null)
                    dataGridProduk.Columns["stok"].HeaderText = "Jumlah Stok";

                // Mengisi nomor urut
                for (int i = 0; i < dataGridProduk.Rows.Count; i++)
                {
                    dataGridProduk.Rows[i].Cells["nomor"].Value = (i + 1).ToString();
                }

                // Menambahkan kolom untuk update dan delete
                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "Update",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridProduk.Columns.Add(updateButtonColumn);

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridProduk.Columns.Add(deleteButtonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dalam LoadDataProduk: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void dataGridProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridProduk.Columns["Update"].Index)
            {
                try
                {
                    // Ganti "id" dengan "produk_id"
                    int produkId = Convert.ToInt32(dataGridProduk.Rows[e.RowIndex].Cells["produk_id"].Value);

                    DataTable produkData = M_Produk.getProdukById(produkId);

                    if (produkData.Rows.Count > 0)
                    {
                        DataRow row = produkData.Rows[0];
                        M_Produk produk = new M_Produk
                        {
                            produk_id = (int)row["produk_id"],
                            nama_produk = row["nama_produk"].ToString(),
                            harga = row["harga"].ToString(),
                            stok = row["stok"].ToString()
                        };

                        //this.Hide();
                        //AddProdukForm addProdukForm = new AddProdukForm();
                        //addProdukForm.PopulateForm(produk);
                        //if (addProdukForm.ShowDialog() == DialogResult.OK)
                        //{
                        //    LoadDataProduk();
                        //}
                        //this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (e.ColumnIndex == dataGridProduk.Columns["Delete"].Index)
            {
                int produkId = Convert.ToInt32(dataGridProduk.Rows[e.RowIndex].Cells["produk_id"].Value);
                M_Produk.DeleteProduk(produkId);
                LoadDataProduk();
            }
        }
    }
}
