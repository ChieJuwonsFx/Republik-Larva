using Republik_Larva.Models;
using System;
using System.Windows.Forms;

namespace Republik_Larva.Views.Akun
{
    public partial class cardAdmin : UserControl
    {
        public cardAdmin()
        {
            InitializeComponent();
        }

        public void SetAkunData(M_Akun admin)
        {
            namaAdmin.Text = admin.nama_admin;
            username.Text = admin.username;
            adminId.Text = $"{admin.admin_id}";
        }

        private void btnHapus_MouseEnter(object sender, EventArgs e)
        {
            btnHapus.BackgroundImage = Properties.Resources.hapusAdminHover;
        }

        private void btnHapus_MouseLeave(object sender, EventArgs e)
        {
            btnHapus.BackgroundImage = Properties.Resources.hapusAdmin;
        }
    }
}
