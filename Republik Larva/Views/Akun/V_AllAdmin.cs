using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.Akun;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Republik_Larva.Views
{
    public partial class V_AllAdmin : UserControl
    {
        private C_Akun _controller;
        M_Akun MAkun;
        public V_AllAdmin(C_Akun controller)
        {
            InitializeComponent();
            _controller = controller;

            LoadAdmin();
        }

        private void LoadAdmin()
        {
            DataTable adminTable = _controller.GetAkunList();
            DisplayAdmin(adminTable);
        }

        private void DisplayAdmin(DataTable adminTable)
        {
            pnAdmin.Controls.Clear();
            int xOffset = 10;
            foreach (DataRow row in adminTable.Rows)
            {
                DataAkun akun = new DataAkun
                {
                    admin_id = Convert.ToInt32(row["admin_id"]),
                    nama_admin = row["nama_admin"].ToString(),
                    username = row["username"].ToString()
                };

                cardAdmin kartu = new cardAdmin
                {
                    Location = new Point(xOffset, 10),
                    Size = new Size(430, 550)
                };
                kartu.SetAkunData(akun);

                kartu.btnHapus.Click += (sender, e) =>
                {
                    bool result = _controller.show_confirm_message_box($"Anda yakin ingin menghapus admin {akun.nama_admin}?");

                    if (result == true)
                    {
                        M_Akun modelAkun = new M_Akun();

                        bool berhasilDihapus = modelAkun.HapusAdmin(akun.admin_id);
                        if (berhasilDihapus)
                        {
                            pnAdmin.Controls.Remove(kartu);
                            kartu.Dispose();

                            _controller.show_message_box("Admin berhasil dihapus.");
                        }
                        else
                        {
                            _controller.show_message_box("Gagal menghapus admin. Karena admin pernah melayani transaksi");
                        }
                    }
                };
                pnAdmin.Controls.Add(kartu);
                xOffset += kartu.Width + 10;
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            _controller.balikAkun();
        }
        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }
        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }
    }
}
