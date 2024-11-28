using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controller;
using Republik_Larva.Models;
using static Republik_Larva.Models.M_Login;

namespace Republik_Larva.Views
{
    public partial class V_Login : Form
    {
        public V_Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(V_Login_KeyDown);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = Properties.Resources.loginHover;
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.Cursor = Cursors.Hand;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = Properties.Resources.loginClick;
            C_MessageBox c_MessageBox = new C_MessageBox();
            M_Login logincontext = new M_Login();
            dataLogin login = logincontext.Validate(username.Text, password.Text);
            V_MainForm dashboard = new V_MainForm();
            if (login != null)
            {
                c_MessageBox.show_message_box("Login berhasil!");
                this.Hide();
                dashboard.Show();
            }
            else if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                c_MessageBox.show_message_box("Username & Password tidak boleh kosong!");
            }
            else
            {
                c_MessageBox.show_message_box("Username atau Password salah. Masukkan dengan benar!");
            }
        }

        public void ClearTextBox()
        {
            username.Text = "";
            password.Text = "";
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        // Event handler untuk KeyDown pada form
        private void V_Login_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick(); 
                e.Handled = true; 
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
