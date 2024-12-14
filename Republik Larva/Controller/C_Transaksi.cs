using Republik_Larva.Views;
using Republik_Larva.Models;
using Republik_Larva.Views.Transaksi;
using System.Data;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using MailKit.Net.Smtp;
using MimeKit;
using iText.Kernel.Colors;

namespace Republik_Larva.Controller
{
    public class C_Transaksi : C_MessageBox
    {
        C_MainForm C_MainForm;
        private C_MessageBox c_MessageBox;
        V_Transaksi view_transaksi;
        V_TambahTransaksi tambah_transaksi;
        V_BatalkanTransaksi batal_transaksi;
        V_BelumLunas belum_lunas;
        M_Transaksi transaksiModel;
        M_Transaksi M_Produk = new M_Transaksi();
        V_LihatSemua view_semua;
        private int idAdmin;

        public C_Transaksi(C_MainForm controller, int id_admin)
        {
            C_MainForm = controller;
            c_MessageBox = new C_MessageBox();

            transaksiModel = new M_Transaksi();
            this.idAdmin = id_admin;

            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
            UpdateTransaksiBulanIni();
        }
        public void balikTransaksi()
        {
            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
            UpdateTransaksiBulanIni();
        }
        public void semuaTransaksiView()
        {
            view_semua = new V_LihatSemua(this);
            C_MainForm.moveView(view_semua);
        }
        public void tambahTransaksiView()
        {
            tambah_transaksi = new V_TambahTransaksi(this);
            C_MainForm.moveView(tambah_transaksi);
        }
        public void batalkanTransaksiView()
        {
            batal_transaksi = new V_BatalkanTransaksi(this);
            C_MainForm.moveView(batal_transaksi);
        }
        public void belumLunasView()
        {
            belum_lunas = new V_BelumLunas(this);
            C_MainForm.moveView(belum_lunas);
        }

        public DataTable GetSelectedProduk(FlowLayoutPanel flowLayoutPanel)
        {
            DataTable selectedProduk = new DataTable();
            selectedProduk.Columns.Add("produk_id", typeof(int));
            selectedProduk.Columns.Add("nama_produk", typeof(string));
            selectedProduk.Columns.Add("harga", typeof(int));
            selectedProduk.Columns.Add("quantity", typeof(int));

            foreach (Control control in flowLayoutPanel.Controls)
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
                                DataRow row = selectedProduk.NewRow();
                                row["produk_id"] = checkBox.Tag;
                                row["nama_produk"] = checkBox.Text.Split('-')[0].Trim();
                                row["harga"] = Convert.ToInt32(checkBox.Text.Split('-')[1].Trim().Replace("Rp", "").Trim());
                                row["quantity"] = (int)numericUpDown.Value;

                                selectedProduk.Rows.Add(row);
                            }
                        }
                    }
                }
            }

            return selectedProduk;
        }


        public List<string> GetStatusPembayaran()
        {
            return new List<string> { "Lunas", "Belum Lunas" };
        }

        public List<string> GetMetodePembayaran()
        {
            return new List<string> { "Cash", "Transfer Bank", "E-Wallet" };
        }

        public DataTable GetProduk()
        {
            return transaksiModel.GetProduk();
        }
        public void TampilkanTransaksiSebulan(DataGridView gridView)
        {
            try
            {
                DataTable data = transaksiModel.GetTransaksiSebulan();
                gridView.DataSource = data;

                gridView.Columns["transaksi_id"].HeaderText = "ID Transaksi";
                gridView.Columns["tanggal_transaksi"].HeaderText = "Tanggal";
                gridView.Columns["total_harga"].HeaderText = "Total Harga";
                gridView.Columns["metode_pembayaran"].HeaderText = "Metode Pembayaran";
                gridView.Columns["status_bayar"].HeaderText = "Status Pembayaran";
                gridView.Columns["nama_customer"].HeaderText = "Nama Customer";
                gridView.Columns["nama_admin"].HeaderText = "Nama Admin";
                gridView.Columns["produk"].HeaderText = "Produk (Jumlah)";
            }
            catch (Exception ex)
            {
                show_message_box("Terjadi kesalahan saat memuat data transaksi: " + ex.Message);
            }
        }

        public void TampilkanSemuaTransaksi(DataGridView gridView)
        {
            try
            {
                DataTable data = transaksiModel.GetSemuaTransaksi();
                gridView.DataSource = data;

                gridView.Columns["transaksi_id"].HeaderText = "ID Transaksi";
                gridView.Columns["tanggal_transaksi"].HeaderText = "Tanggal";
                gridView.Columns["total_harga"].HeaderText = "Total Harga";
                gridView.Columns["metode_pembayaran"].HeaderText = "Metode Pembayaran";
                gridView.Columns["status_bayar"].HeaderText = "Status Pembayaran";
                gridView.Columns["nama_customer"].HeaderText = "Nama Customer";
                gridView.Columns["nama_admin"].HeaderText = "Nama Admin";
                gridView.Columns["produk"].HeaderText = "Produk (Jumlah)";
            }
            catch (Exception ex)
            {
                show_message_box("Terjadi kesalahan saat memuat data transaksi: ");
            }
        }

        //BelumLunas 

        public void LoadBelumLunas(DataGridView dataGrid)
        {
            try
            {
                DataTable data = transaksiModel.GetBelumBayar();
                dataGrid.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        public string GetEmailCustomerByTransaksiId(int transaksiId)
        {
            try
            {
                return transaksiModel.GetEmailCustomerByTransaksiId(transaksiId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan email customer: " + ex.Message);
                return string.Empty;
            }
        }

        public void UpdateStatusLunas(int transaksiId)
        {
            try
            {
                transaksiModel.UpdateStatusLunas(transaksiId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah status transaksi: " + ex.Message);
            }
        }
        public DataTable GetProdukTransaksi(int transaksiId)
        {
            try
            {
                return transaksiModel.GetProdukTransaksi(transaksiId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendapatkan data produk: " + ex.Message);
                return null;
            }
        }
        public void LoadBelumBayar(DataGridView dataGridBelumLunas)
        {
            try
            {
                dataGridBelumLunas.AllowUserToAddRows = false;

                DataTable transaksiData = transaksiModel.GetBelumBayar();
                if (transaksiData == null || transaksiData.Rows.Count == 0)
                {
                    show_message_box("Error: Gagal mengambil data transaksi atau tidak ada data.");
                    return;
                }

                dataGridBelumLunas.Columns.Clear();

                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn();
                nomorColumn.HeaderText = "No";
                nomorColumn.Name = "nomor";
                dataGridBelumLunas.Columns.Add(nomorColumn);

                dataGridBelumLunas.DataSource = transaksiData;

                if (dataGridBelumLunas.Columns["transaksi_id"] != null)
                    dataGridBelumLunas.Columns["transaksi_id"].Visible = false;

                if (dataGridBelumLunas.Columns["waktu_transaksi"] != null)
                    dataGridBelumLunas.Columns["waktu_transaksi"].HeaderText = "Waktu Transaksi";

                if (dataGridBelumLunas.Columns["total_harga"] != null)
                    dataGridBelumLunas.Columns["total_harga"].HeaderText = "Total Harga";

                for (int i = 0; i < dataGridBelumLunas.Rows.Count; i++)
                {
                    dataGridBelumLunas.Rows[i].Cells["nomor"].Value = (i + 1).ToString();
                }

                DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                {
                    Name = "updateLunasButton",
                    Text = "Update Lunas",
                    UseColumnTextForButtonValue = true
                };
                dataGridBelumLunas.Columns.Add(updateColumn);

                DataGridViewButtonColumn tagihColumn = new DataGridViewButtonColumn
                {
                    Name = "tagihButton",
                    Text = "Kirim Tagihan",
                    UseColumnTextForButtonValue = true
                };
                dataGridBelumLunas.Columns.Add(tagihColumn);

                dataGridBelumLunas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                show_message_box($"Error dalam LoadDataTransaksi: {ex.Message}\n{ex.StackTrace}");
            }
        }
        public static void GeneratePdfPembayaranLunas(string namaCustomer, string emailCustomer, DataTable produkTerpilih, string statusPembayaran, string metodePembayaran)
        {
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);

            pdf.AddNewPage();
            Document document = new Document(pdf);

            Paragraph watermark = new Paragraph("LUNAS")
                .SetFontSize(50)
                .SetFontColor(new DeviceRgb(0, 128, 0))
                .SetOpacity(0.3f)
                .SetTextAlignment(TextAlignment.CENTER);

            iText.Kernel.Geom.Rectangle pageSize = pdf.GetFirstPage().GetPageSize();
            Canvas canvas = new Canvas(pdf.GetFirstPage(), pageSize);
            canvas.Add(watermark.SetFixedPosition(pageSize.GetWidth() / 4, pageSize.GetHeight() / 2, 500));

            document.Add(new Paragraph("Republik Larva").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Jl. Medan Merdeka No. 123, Jakarta").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Telp: 081238038207| Email: insensateecho@gmail.com").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("INVOICE PEMBAYARAN LUNAS").SetFontSize(18).SetTextAlignment(TextAlignment.CENTER));
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
                int produkId = (int)row["produk_id"];
                string itemName = GetProductNameById(produkId);
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

            SendEmailWithAttachmentPembayaranLunas(pdfBytes, namaCustomer, emailCustomer);
        }

        public static void SendEmailWithAttachmentPembayaranLunas(byte[] fileBytes, string namaCustomer, string emailCustomer)
        {
            try
            {
                MimeMessage email = new MimeMessage();
                email.From.Add(new MailboxAddress(EnvLoader.Nama_Email, EnvLoader.Email));
                email.To.Add(new MailboxAddress(namaCustomer, emailCustomer));

                email.Subject = "Pembayaran Anda Telah Lunas";

                string bodyText = $"Halo {namaCustomer},\n\n" +
                                  $"Kami dengan senang hati memberitahukan Anda bahwa pembayaran untuk transaksi Anda telah berhasil dilunasi. Terlampir adalah rincian invoice pembayaran yang telah dilunasi.\n\n" +
                                  "Terima kasih atas pembayaran Anda, dan jika ada pertanyaan lebih lanjut, jangan ragu untuk menghubungi kami.\n\n" +
                                  "Tim Republik Larva";

                BodyBuilder bodyBuilder = new BodyBuilder
                {
                    TextBody = bodyText
                };

                bodyBuilder.Attachments.Add("InvoicePembatalan.pdf", fileBytes, new MimeKit.ContentType("application", "pdf"));
                email.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    smtpClient.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
                    smtpClient.Send(email);
                    smtpClient.Disconnect(true);
                }

                Console.WriteLine("Email berhasil dikirim.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal mengirim email: {ex.Message}");
            }
        }
        public static void GeneratePdfTagihan(string namaCustomer, string emailCustomer, DataTable produkTerpilih, string statusPembayaran, string metodePembayaran)
        {
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);

            pdf.AddNewPage();
            Document document = new Document(pdf);

            document.Add(new Paragraph("Republik Larva").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Jl. Medan Merdeka No. 123, Jakarta").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Telp: 081238038207 | Email: insensateecho@gmail.com").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("TAGIHAN PEMBAYARAN").SetFontSize(18).SetTextAlignment(TextAlignment.CENTER));
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
                int produkId = (int)row["produk_id"];
                string itemName = GetProductNameById(produkId);
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
            document.Add(new Paragraph($"Total Tagihan: Rp {totalAmount}").SetTextAlignment(TextAlignment.RIGHT));
            document.Add(new Paragraph("\n"));
            document.Close();

            byte[] pdfBytes = memoryStream.ToArray();

            SendEmailWithAttachmentTagihan(pdfBytes, namaCustomer, emailCustomer);
        }

        public static void SendEmailWithAttachmentTagihan(byte[] fileBytes, string namaCustomer, string emailCustomer)
        {
            try
            {
                MimeMessage email = new MimeMessage();
                email.From.Add(new MailboxAddress(EnvLoader.Nama_Email, EnvLoader.Email));
                email.To.Add(new MailboxAddress(namaCustomer, emailCustomer));

                email.Subject = "Tagihan Pembayaran Anda";

                string bodyText = $"Halo {namaCustomer},\n\n" +
                                  $"Kami ingin mengingatkan bahwa Anda memiliki tagihan pembayaran yang belum diselesaikan terkait transaksi Anda di Republik Larva.\n\n" +
                                  $"Detail tagihan:\n" +
                                  $"- Status Pembayaran: Belum Lunas\n" +
                                  $"- Total Tagihan: Mohon lihat detail dalam PDF terlampir.\n\n" +
                                  "Kami sarankan Anda untuk segera menyelesaikan pembayaran agar transaksi Anda dapat diproses lebih lanjut. " +
                                  "Jika ada pertanyaan atau kendala, jangan ragu untuk menghubungi kami di email ini atau melalui WhatsApp di 081238038207.\n\n" +
                                  "Terima kasih atas perhatian Anda.\n\n" +
                                  "Hormat kami,\nTim Republik Larva";

                BodyBuilder bodyBuilder = new BodyBuilder
                {
                    TextBody = bodyText
                };

                bodyBuilder.Attachments.Add($"Invoice_{DateTime.Now.Ticks}.pdf", fileBytes, new MimeKit.ContentType("application", "pdf"));
                email.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    smtpClient.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
                    smtpClient.Send(email);
                    smtpClient.Disconnect(true);
                }

                Console.WriteLine("Email tagihan berhasil dikirim.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal mengirim email tagihan: {ex.Message}");
            }
        }



        //Batalkan
        public void LoadBatalkanTransaksi(DataGridView dataGridTransaksi)
        {
            try
            {
                dataGridTransaksi.AllowUserToAddRows = false;

                DataTable transaksiData = transaksiModel.GetBatalTransaksi();
                if (transaksiData == null || transaksiData.Rows.Count == 0)
                {
                    show_message_box("Error: Gagal mengambil data transaksi atau tidak ada data.");
                    return;
                }

                dataGridTransaksi.Columns.Clear();

                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn();
                nomorColumn.HeaderText = "No";
                nomorColumn.Name = "nomor";
                dataGridTransaksi.Columns.Add(nomorColumn);

                dataGridTransaksi.DataSource = transaksiData;

                if (dataGridTransaksi.Columns["transaksi_id"] != null)
                    dataGridTransaksi.Columns["transaksi_id"].Visible = false;

                if (dataGridTransaksi.Columns["waktu_transaksi"] != null)
                    dataGridTransaksi.Columns["waktu_transaksi"].HeaderText = "Waktu Transaksi";

                if (dataGridTransaksi.Columns["total_harga"] != null)
                    dataGridTransaksi.Columns["total_harga"].HeaderText = "Total Harga";

                for (int i = 0; i < dataGridTransaksi.Rows.Count; i++)
                {
                    dataGridTransaksi.Rows[i].Cells["nomor"].Value = (i + 1).ToString();
                }

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Hapus",
                    Text = "Hapus",
                    UseColumnTextForButtonValue = true
                };
                dataGridTransaksi.Columns.Add(deleteButtonColumn);

                dataGridTransaksi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                show_message_box($"Error dalam LoadDataTransaksi: {ex.Message}\n{ex.StackTrace}");
            }
        }
        public static void GeneratePdfPembatalan(string namaCustomer, string emailCustomer, DataTable produkTerpilih, string statusPembayaran, string metodePembayaran)
        {
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);

            pdf.AddNewPage();
            Document document = new Document(pdf);

            Paragraph watermark = new Paragraph("BATALKAN")
                .SetFontSize(50)
                .SetFontColor(new DeviceRgb(255, 0, 0))
                .SetOpacity(0.3f)
                .SetTextAlignment(TextAlignment.CENTER);

            iText.Kernel.Geom.Rectangle pageSize = pdf.GetFirstPage().GetPageSize();
            Canvas canvas = new Canvas(pdf.GetFirstPage(), pageSize);
            canvas.Add(watermark.SetFixedPosition(pageSize.GetWidth() / 4, pageSize.GetHeight() / 2, 500));

            document.Add(new Paragraph("Republik Larva").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Jl. Medan Merdeka No. 123, Jakarta").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("Telp: 081238038207| Email: insensateecho@gmail.com").SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("INVOICE PEMBATALAN").SetFontSize(18).SetTextAlignment(TextAlignment.CENTER));
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
                int produkId = (int)row["produk_id"];
                string itemName = GetProductNameById(produkId);
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

            SendEmailWithAttachmentPembatalan(pdfBytes, namaCustomer, emailCustomer);
        }

        public static void SendEmailWithAttachmentPembatalan(byte[] fileBytes, string namaCustomer, string emailCustomer)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(EnvLoader.Nama_Email, EnvLoader.Email));
            email.To.Add(new MailboxAddress(namaCustomer, emailCustomer));

            email.Subject = "Transaksi Anda Telah Dibatalkan";

            string bodyText = $"Halo {namaCustomer},\n\n" +
                              $"Transaksi Anda telah dibatalkan. Terlampir adalah rincian invoice pembatalan.\n\n" +
                              "Terima kasih, dan jika ada pertanyaan lebih lanjut, hubungi kami.\n\n" +
                              "Tim Republik Larva";

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                TextBody = bodyText
            };

            bodyBuilder.Attachments.Add("InvoicePembatalan.pdf", fileBytes, new MimeKit.ContentType("application", "pdf"));
            email.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            smtpClient.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
            smtpClient.Send(email);
            smtpClient.Disconnect(true);
        }
        public void HapusTransaksiDenganBatasWaktu(int transaksiId)
        {
            try
            {
                DataTable transaksiData = transaksiModel.GetTransaksiCustomer(transaksiId);
                if (transaksiData.Rows.Count == 0)
                {
                    show_message_box("Transaksi tidak ditemukan.");
                    return;
                }

                string namaCustomer = transaksiData.Rows[0]["nama_customer"].ToString();
                string emailCustomer = transaksiData.Rows[0]["email"].ToString();
                string statusPembayaran = transaksiData.Rows[0]["status_bayar"].ToString();
                string metodePembayaran = transaksiData.Rows[0]["metode_pembayaran"].ToString();

                DataTable produkTerpilih = transaksiModel.GetProdukTransaksi(transaksiId);
                transaksiModel.HapusTransaksi(transaksiId);
                GeneratePdfPembatalan(namaCustomer, emailCustomer, produkTerpilih, statusPembayaran, metodePembayaran);
                show_message_box("Transaksi berhasil dihapus.");
            }
            catch (Exception ex)
            {
                show_message_box("Gagal menghapus transaksi: " + ex.Message);
            }
        }


        //TambahTransaksi
        public void ProsesTransaksi(string NamaCustomer, string email, string statusPembayaran, string metodePembayaran,DataTable produkTerpilih)
        {
            try
            {
                if (transaksiModel == null)
                    throw new Exception("Model transaksi belum diinisialisasi.");

                if (produkTerpilih == null || produkTerpilih.Rows.Count == 0)
                    throw new Exception("Tidak ada produk yang dipilih.");

                int customerId = transaksiModel.TambahAtauAmbilCustomer(NamaCustomer, email);

                int totalHarga = 0;

                foreach (DataRow row in produkTerpilih.Rows)
                {
                    int produkId = Convert.ToInt32(row["produk_id"]);
                    int jumlah = Convert.ToInt32(row["jumlah"]);

                    int stok = transaksiModel.GetStokProduk(produkId);
                    if (stok < jumlah)
                    {
                        throw new Exception("Stok produk " + row["nama_produk"].ToString() + " tidak cukup.");
                    }

                    if (stok == 10)
                    {
                        SendEmailStokTersisa(produkId, stok);
                    }
                    if (stok == 0)
                    {
                        SendEmailStokHabis(produkId);
                    }

                    int harga = Convert.ToInt32(row["harga"]);
                    totalHarga += jumlah * harga;
                }

                int transaksiId = transaksiModel.SimpanTransaksi(statusPembayaran, metodePembayaran, totalHarga, customerId, idAdmin);

                foreach (DataRow row in produkTerpilih.Rows)
                {
                    int produkId = Convert.ToInt32(row["produk_id"]);
                    int jumlah = Convert.ToInt32(row["jumlah"]);
                    int totalHargaItem = Convert.ToInt32(row["total_harga"]);

                    transaksiModel.SimpanDetailTransaksi(transaksiId, produkId, jumlah, totalHargaItem);
                    transaksiModel.KurangiStokProduk(produkId, jumlah);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses transaksi: " + ex.Message);
            }
        }

        private void SendEmailStokTersisa(int produkId, int stok)
        {
            string namaProduk = GetProductNameById(produkId);
            string subject = $"Stok {namaProduk} Tersisa 10 kg";
            string body = $"Stok produk {namaProduk} tersisa hanya 10 kg. Segera lakukan restok sebelum habis!";
            SendEmail(subject, body);
        }
        private void SendEmailStokHabis(int produkId)
        {
            string namaProduk = GetProductNameById(produkId);
            string subject = $"Stok {namaProduk} Habis";
            string body = $"Stok produk {namaProduk} telah habis. Segera lakukan restok!";
            SendEmail(subject, body);
        }
        private void SendEmail(string subject, string body)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(EnvLoader.Nama_Email, EnvLoader.Email));
            email.To.Add(new MailboxAddress("Admin", EnvLoader.Email));

            email.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                smtpClient.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
                smtpClient.Send(email);
                smtpClient.Disconnect(true);
            }
        }
        public void UpdateTransaksiBulanIni()
        {
            int jumlahTransaksi = transaksiModel.GetJumlahTransaksiBulanIni();
            int totalPenghasilan = transaksiModel.GetTotalPenghasilanBulanIni();
            int totalMaggotTerjual = transaksiModel.GetTotalProdukMaggotTerjualBulanIni();

            view_transaksi.UpdateDashboard(jumlahTransaksi, totalPenghasilan, totalMaggotTerjual);
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
                int produkId = (int)row["produk_id"];
                string itemName = GetProductNameById(produkId);
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
        public static string GetProductNameById(int produkId)
        {
            M_Transaksi transaksiModel = new M_Transaksi();
            DataTable produkTable = transaksiModel.GetProduk();

            foreach (DataRow row in produkTable.Rows)
            {
                if ((int)row["produk_id"] == produkId)
                {
                    return row["nama_produk"].ToString();
                }
            }
            return string.Empty;
        }

        public static void SendEmailWithAttachment(byte[] fileBytes, string namaCustomer, string emailCustomer, string statusPembayaran)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(EnvLoader.Nama_Email, EnvLoader.Email));
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
            smtpClient.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
            smtpClient.Send(email);
            smtpClient.Disconnect(true);
        }

    }
}