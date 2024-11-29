using MimeKit;
using MailKit;
using Republik_Larva.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using System.Windows.Forms;
using Republik_Larva.Controller;

namespace Republik_Larva.Views
{
    public partial class V_SendEmail : UserControl
    {
        C_SendEmail c_SendEmail;
        public V_SendEmail(C_SendEmail c_SendEmail)
        {
            InitializeComponent();
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

                email.Body = builder.ToMessageBody();

                SmtpClient smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                smtp.Authenticate("insensateecho@gmail.com", "xlixlbfcdcmdgnyo");
                smtp.Send(email);
                smtp.Disconnect(true);

                MessageBox.Show("Email berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengirim email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void namaTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void subject_TextChanged(object sender, EventArgs e)
        {

        }

        private void pesan_TextChanged(object sender, EventArgs e)
        {

        }

        private void V_SendEmail_Load(object sender, EventArgs e)
        {

        }
    }
}
