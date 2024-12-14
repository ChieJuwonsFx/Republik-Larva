using Republik_Larva.Models;
using Republik_Larva.Views;

namespace Republik_Larva.Controller
{
    public class C_Login : C_MessageBox
    {
        private V_Login view;
        private M_Akun model;
        private C_MainForm mainForm;

        public C_Login(V_Login loginView)
        {
            view = loginView;
            model = new M_Akun();
        }
        public void HandleLogin(string username, string password)
        {
            M_Akun login = model.Validate(username, password);
            V_MainForm dashboard = new V_MainForm();

            if (login != null)
            {
                dashboard.LoggedInAdminId = login.admin_id;

                show_message_box("Login berhasil!");
                view.Hide();
                dashboard.Show();
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                show_message_box("Username & Password tidak boleh kosong!");
            }
            else
            {
                show_message_box("Username atau Password salah. Masukkan dengan benar!");
            }
        }
    }
}
