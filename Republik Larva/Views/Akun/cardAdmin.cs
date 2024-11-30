using Republik_Larva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Republik_Larva.Views.Akun
{
    public partial class cardAdmin : UserControl
    {
        private DataAkun adminData;
        public cardAdmin()
        {
            InitializeComponent();
        }
        public void SetAkunData(DataAkun admin)
        {
            adminData = admin;

            namaAdmin.Text = admin.nama_admin;
            username.Text = admin.username;
            adminId.Text = $"{admin.admin_id}";
        }
        public void btnHapus_Click(object sender, EventArgs e)
        {

        }
    }
}
