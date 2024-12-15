using MimeKit;
using Republik_Larva.Controller;
using System.Data;
using MailKit.Net.Smtp;

namespace Republik_Larva.Views
{
    public partial class V_SendEmail : UserControl
    {
        private C_SendEmail c_SendEmail;
        private string attachmentPath = null;

        public V_SendEmail(C_SendEmail c_SendEmail)
        {
            InitializeComponent();
            this.c_SendEmail = c_SendEmail;
            LoadCustomerData();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                MimeMessage email = new MimeMessage();
                email.From.Add(new MailboxAddress("Republik Larva", "insensateecho@gmail.com"));
                email.To.Add(new MailboxAddress(namaTujuan.Text, emailTujuan.Text));
                email.Subject = subject.Text;

                BodyBuilder builder = new BodyBuilder
                {
                    TextBody = pesan.Text,
                    HtmlBody = $"<p>{pesan.Text}</p><br><footer>Powered by insensateecho@gmail.com</footer>"
                };

                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    builder.Attachments.Add(attachmentPath);
                }

                email.Body = builder.ToMessageBody();

                SmtpClient smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(EnvLoader.Email, EnvLoader.Token_Email);
                smtp.Send(email);
                smtp.Disconnect(true);

                c_SendEmail.show_message_box("Email berhasil dikirim!");
                
            }
            catch (Exception ex)
            {
                c_SendEmail.show_message_box($"Gagal mengirim email: {ex.Message}");
            }
        }

        private void uploadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Pilih File",
                Filter = "All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    attachmentPath = openFileDialog.FileName;
                    namaFile.Text = $"File: {System.IO.Path.GetFileName(attachmentPath)}";
                }
                catch (Exception ex)
                {
                    c_SendEmail.show_message_box($"Gagal memuat file: {ex.Message}");
                }
            }
        }

        private void LoadCustomerData()
        {
            try
            {
                DataTable customerData = c_SendEmail.GetCustomerData();
                if (customerData != null)
                {
                    dataGridView1.DataSource = customerData;
                }
                else
                {
                    c_SendEmail.show_message_box("Data pelanggan kosong.");
                }
            }
            catch (Exception ex)
            {
                c_SendEmail.show_message_box($"Gagal memuat data pelanggan: {ex.Message}");
            }
        }

        private void DisplayCustomerData(DataTable customerTable)
        {
            dataGridView1.DataSource = customerTable;
            dataGridView1.Columns["customer_id"].HeaderText = "ID";
            dataGridView1.Columns["nama_customer"].HeaderText = "Nama Pelanggan";
            dataGridView1.Columns["email_customer"].HeaderText = "Email Pelanggan";

            dataGridView1.Columns["customer_id"].Visible = false;
        }

        private void btnSendEmail_MouseLeave(object sender, EventArgs e)
        {
            btnSendEmail.BackgroundImage = Properties.Resources.kirim;
        }

        private void btnSendEmail_MouseEnter(object sender, EventArgs e)
        {
            btnSendEmail.BackgroundImage = Properties.Resources.kirimHover;
        }

        private void V_SendEmail_Load(object sender, EventArgs e)
        {
            namaFile.Text = "Tidak ada file terpilih";
        }
    }
}
