using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Views;
using Republik_Larva.Models;
using NpgsqlTypes;
using System.Numerics;
using Republik_Larva.Controller;
using Republik_Larva.Views.Akun;
using Republik_Larva.Views.Transaksi;
using System.Data;
using System.Windows.Forms;
using iText.Layout.Element;
using iText.Layout.Properties;
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
using MimeKit;

namespace Republik_Larva.Controller
{
    public class C_Transaksi : C_MessageBox
    {
        C_MainForm C_MainForm;
        private C_MessageBox c_MessageBox;
        V_Transaksi view_transaksi;
        V_TambahTransaksi tambah_transaksi;
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
        public void ProsesTransaksi(string NamaCustomer, string email, string statusPembayaran, string metodePembayaran,
                                    DataTable produkTerpilih)
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
            email.From.Add(new MailboxAddress("Republik Larva", "insensateecho@gmail.com"));
            email.To.Add(new MailboxAddress("Admin", "insensateecho@gmail.com"));

            email.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                smtpClient.Authenticate("insensateecho@gmail.com", "xlixlbfcdcmdgnyo");
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
                MessageBox.Show("Terjadi kesalahan saat memuat data transaksi: " + ex.Message);
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

    }
}