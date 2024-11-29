using System;
using System.Windows.Forms;
using Republik_Larva.Models;
using Republik_Larva.Views;

namespace Republik_Larva.Controller
{
    public class C_Login
    {
        private V_Login view;
        private M_Akun model;

        public C_Login(V_Login loginView)
        {
            view = loginView;
            model = new M_Akun();
        }

        public void HandleLogin(string username, string password)
        {
            DataAkun login = model.Validate(username, password);
            C_MessageBox c_MessageBox = new C_MessageBox();
            V_MainForm dashboard = new V_MainForm();

            if (login != null)
            {
                dashboard.LoggedInAdminId = login.admin_id;

                c_MessageBox.show_message_box("Login berhasil!");
                view.Hide();
                dashboard.Show();
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                c_MessageBox.show_message_box("Username & Password tidak boleh kosong!");
            }
            else
            {
                c_MessageBox.show_message_box("Username atau Password salah. Masukkan dengan benar!");
            }
        }
    }
}
