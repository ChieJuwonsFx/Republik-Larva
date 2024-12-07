using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using System.IO;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MimeKit.Text;
using iText.IO.Image;
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

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string NamaCustomer = namaCustomer.Text;
                string emailCustomer = email.Text;
                string statusPembayaranValue = statusPembayaran.SelectedItem.ToString();
                string metodePembayaranValue = metodePembayaran.SelectedItem.ToString();

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
                GeneratePdfInMemory(NamaCustomer, emailCustomer, produkTerpilih, statusPembayaranValue, metodePembayaranValue);
                c_Transaksi.balikTransaksi();
            }
            catch (Exception ex)
            {
                c_Transaksi.show_confirm_message_box("Terjadi kesalahan: " + ex.Message);
            }
        }
        public static void GeneratePdfInMemory(string namaCustomer, string emailCustomer, DataTable produkTerpilih, string statusPembayaran, string metodePembayaran)
        {
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                document.Add(new Paragraph("Republik Larva").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph("Jl. Medan Merdeka No. 123, Jakarta").SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph("Telp: 081238038207| Email: insensateecho@gmail.com").SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph("\n")); 

                document.Add(new Paragraph("INVOICE").SetFontSize(18).SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph($"No. Invoice: INV-{DateTime.Now.Ticks}").SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph($"Tanggal: {DateTime.Now:dd MMMM yyyy}").SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph("\n")); 

                document.Add(new Paragraph($"Nama Customer: {namaCustomer}"));
                document.Add(new Paragraph($"Email: {emailCustomer}"));
                document.Add(new Paragraph($"Metode Pembayaran: {metodePembayaran}"));
                document.Add(new Paragraph($"Status Pembayaran: {statusPembayaran}"));
                document.Add(new Paragraph("\n"));

                Table table = new Table(4).UseAllAvailableWidth();
                table.AddHeaderCell("Item");
                table.AddHeaderCell("Jumlah");
                table.AddHeaderCell("Harga");
                table.AddHeaderCell("Total");

                int totalAmount = 0;
                foreach (DataRow row in produkTerpilih.Rows)
                {
                    string itemName = row["produk_id"].ToString();  
                    int jumlah = (int)row["jumlah"];
                    int harga = (int)row["harga"];
                    int totalHarga = (int)row["total_harga"];

                    totalAmount += totalHarga;

                    table.AddCell(itemName);
                    table.AddCell(jumlah.ToString());
                    table.AddCell($"Rp {harga}");
                    table.AddCell($"Rp {totalHarga}");
                }

                document.Add(table);
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph($"Total Pembayaran: Rp {totalAmount}").SetTextAlignment(TextAlignment.RIGHT));
                document.Add(new Paragraph("\n"));
                document.Close();

                byte[] pdfBytes = memoryStream.ToArray();

                SendEmailWithAttachment(pdfBytes, namaCustomer, emailCustomer, statusPembayaran);
        }

        public static void SendEmailWithAttachment(byte[] fileBytes, string namaCustomer, string emailCustomer, string statusPembayaran)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress("Republik Larva", "insensateecho@gmail.com"));
            email.To.Add(new MailboxAddress(namaCustomer, emailCustomer));

            string subject = statusPembayaran.ToLower() == "lunas" ? "Terima kasih atas Pembelian Anda!" : "Pembelian Anda Belum Lunas, Segera Lunasi!";

            email.Subject = subject;

            string bodyText = statusPembayaran.ToLower() == "lunas" ?
                $"Terima kasih telah melakukan pembayaran. Berikut adalah invoice untuk transaksi Anda." :
                $"Transaksi Anda belum lunas. Mohon segera lakukan pembayaran untuk menyelesaikan transaksi Anda.";

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                TextBody = bodyText
            };

            bodyBuilder.Attachments.Add("GeneratedInvoice.pdf", fileBytes, new MimeKit.ContentType("application", "pdf"));
            email.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            smtpClient.Authenticate("insensateecho@gmail.com", "xlixlbfcdcmdgnyo");
            smtpClient.Send(email);
            smtpClient.Disconnect(true);
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
                c_Transaksi.ProsesTransaksi(
                    NamaCustomer,
                    emailCustomer,
                    statusPembayaranValue,
                    metodePembayaranValue,
                    produkTerpilih
                );
                GeneratePdfInMemory(NamaCustomer, emailCustomer, produkTerpilih, statusPembayaranValue, metodePembayaranValue);
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
