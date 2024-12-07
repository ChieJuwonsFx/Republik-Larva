using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Republik_Larva.Controller;
using Republik_Larva.Models;

namespace Republik_Larva.Views.Transaksi
{
    public partial class V_TambahTransaksi : UserControl
    {
        private M_Transaksi transaksiModel;
        private C_Transaksi c_Transaksi;
        public V_TambahTransaksi(C_Transaksi controller)
        {
            InitializeComponent();
            c_Transaksi = controller;
            transaksiModel = new M_Transaksi();
            LoadComboBox();
            LoadProduk();
        }

        private void LoadComboBox()
        {
            statusPembayaran.DataSource = transaksiModel.GetStatusPembayaran();
            metodePembayaran.DataSource = transaksiModel.GetMetodePembayaran();
        }

        private void LoadProduk()
        {
            M_Transaksi transaksiModel = new M_Transaksi();
            DataTable produkTable = transaksiModel.GetProduk();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(5);

            listPreview.Items.Clear();

            foreach (DataRow row in produkTable.Rows)
            {
                Panel produkPanel = new Panel
                {
                    Size = new Size(280, 75),
                    Margin = new Padding(10),
                };

                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                CheckBox checkBox = new CheckBox
                {
                    Text = $"{row["nama_produk"]} - Rp{row["harga"]}",
                    Font = new Font("Segoe UI", 12),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = row["produk_id"]
                };

                Label labelStok = new Label
                {
                    Text = $"Stok: {row["stok"]}",
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(25, 5, 10, 0)
                };

                NumericUpDown numericUpDown = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = Convert.ToInt32(row["stok"]),
                    Value = 0,
                    Font = new Font("Segoe UI", 12),
                    Size = new Size(70, 30)
                };

                numericUpDown.ValueChanged += (sender, e) =>
                {
                    checkBox.Checked = numericUpDown.Value > 0;
                    UpdatePreview(listPreview, produkTable);
                };

                checkBox.CheckedChanged += (sender, e) => UpdatePreview(listPreview, produkTable);

                flowPanel.Controls.Add(checkBox);
                flowPanel.Controls.Add(labelStok);
                flowPanel.Controls.Add(numericUpDown);
                produkPanel.Controls.Add(flowPanel);

                flowLayoutPanel1.Controls.Add(produkPanel);
            }
        }

        private void UpdatePreview(ListBox previewList, DataTable produkTable)
        {
            previewList.Items.Clear();
            int subtotal = 0;

            previewList.Items.Add("Nama Produk".PadRight(20) + "Qty".PadLeft(5) + "Harga".PadLeft(10) + "Total".PadLeft(10));
            previewList.Items.Add(new string('-', 50));

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is FlowLayoutPanel flowPanel)
                        {
                            CheckBox checkBox = flowPanel.Controls.OfType<CheckBox>().FirstOrDefault();
                            NumericUpDown numericUpDown = flowPanel.Controls.OfType<NumericUpDown>().FirstOrDefault();

                            if (checkBox != null && numericUpDown != null && checkBox.Checked)
                            {
                                int harga = 0;
                                string productName = checkBox.Text.Split('-')[0].Trim();

                                foreach (DataRow row in produkTable.Rows)
                                {
                                    if (row["nama_produk"].ToString() == productName)
                                    {
                                        harga = Convert.ToInt32(row["harga"]);
                                        break;
                                    }
                                }

                                int quantity = (int)numericUpDown.Value;
                                int totalHarga = quantity * harga;

                                subtotal += totalHarga;

                                string line = productName.PadRight(20) +
                                              quantity.ToString().PadLeft(10) +
                                              harga.ToString().PadLeft(10) +
                                              totalHarga.ToString().PadLeft(10);

                                previewList.Items.Add(line);
                            }
                        }
                    }
                }
            }

            previewList.Items.Add(new string('-', 50));
            previewList.Items.Add("Subtotal".PadRight(35) + "Rp" + subtotal.ToString().PadLeft(18));
        }
        private int CalculateTotalHarga()
        {
            int total = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is NumericUpDown numericUpDown)
                        {
                            int hargaProduk = 0;
                            total += (int)numericUpDown.Value * hargaProduk;
                        }
                    }
                }
            }
            return total;
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string NamaCustomer = namaCustomer.Text;
                string emailCustomer = email.Text;
                string statusPembayaranValue = statusPembayaran.SelectedItem?.ToString();
                string metodePembayaranValue = metodePembayaran.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(NamaCustomer) || string.IsNullOrEmpty(emailCustomer) ||
                    string.IsNullOrEmpty(statusPembayaranValue) || string.IsNullOrEmpty(metodePembayaranValue))
                {
                    c_Transaksi.show_confirm_message_box("Mohon lengkapi semua data transaksi!");
                    return;
                }

                DataTable produkTerpilih = new DataTable();
                produkTerpilih.Columns.Add("produk_id", typeof(int));
                produkTerpilih.Columns.Add("jumlah", typeof(int));
                produkTerpilih.Columns.Add("harga", typeof(int));
                produkTerpilih.Columns.Add("total_harga", typeof(int));

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is Panel panel)
                    {
                        foreach (Control subControl in panel.Controls)
                        {
                            if (subControl is FlowLayoutPanel flowPanel)
                            {
                                CheckBox checkBox = flowPanel.Controls.OfType<CheckBox>().FirstOrDefault();
                                NumericUpDown numericUpDown = flowPanel.Controls.OfType<NumericUpDown>().FirstOrDefault();

                                if (checkBox != null && numericUpDown != null && checkBox.Checked)
                                {
                                    int produkId = (int)checkBox.Tag;
                                    int jumlah = (int)numericUpDown.Value;
                                    int harga = Convert.ToInt32(checkBox.Text.Split('-')[1].Replace("Rp", "").Trim());
                                    int totalHarga = jumlah * harga;
                                    produkTerpilih.Rows.Add(produkId, jumlah, harga, totalHarga);
                                }
                            }
                        }
                    }
                }
                c_Transaksi.ProsesTransaksi(NamaCustomer, emailCustomer, statusPembayaranValue, metodePembayaranValue, produkTerpilih);
                C_Transaksi.GeneratePdfInMemory(NamaCustomer, emailCustomer, produkTerpilih, statusPembayaranValue, metodePembayaranValue);
                c_Transaksi.show_message_box("Transaksi berhasil disimpan!");
                c_Transaksi.balikTransaksi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
