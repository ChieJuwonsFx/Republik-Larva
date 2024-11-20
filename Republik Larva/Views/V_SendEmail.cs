using MailKit.Net.Smtp;
using MimeKit;
using Republik_Larva.Controller;
using Republik_Larva.Controllers;

namespace Republik_Larva.Views
{
    public partial class V_SendEmail : Form
    {
        private Route Route;

        public V_SendEmail()
        {
            InitializeComponent();
            Route = new Route(this);
        }
        private void sendEmail_Load(object sender, EventArgs e)
        {

        }

        private void txtPesanEmail_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSubject_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtEmailTujuan_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNamaTujuan_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_sendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                MimeMessage email = new MimeMessage();
                email.From.Add(new MailboxAddress("Republik Larva", "insensateecho@gmail.com"));
                email.To.Add(new MailboxAddress(txtNamaTujuan.Text, txtEmailTujuan.Text));
                email.Subject = txtSubject.Text;

                BodyBuilder builder = new BodyBuilder
                {
                    TextBody = txtPesanEmail.Text,
                    HtmlBody = $"<p>{txtPesanEmail.Text}</p><br><footer>Powered by insensateecho@gmail.com</footer>"
                };

                email.Body = builder.ToMessageBody();

                SmtpClient smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                smtp.Authenticate("insensateecho@gmail.com", "xlixlbfcdcmdgnyo"); // Ganti dengan password aplikasi
                smtp.Send(email);
                smtp.Disconnect(true);

                MessageBox.Show("Email berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengirim email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Dashboard());
        }
        private void btnProduk_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Produk());
        }
        private void btnAkun_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Akun());
        }
        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Transaksi());
        }
    }
}
