using System;
using System.Windows.Forms;
using Republik_Larva.Controller;

namespace Republik_Larva.Views
{
    public partial class V_Login : Form
    {
        private C_Login c_Login;
        private C_MainForm mainForm;
        public V_Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(V_Login_KeyDown);

            c_Login = new C_Login(this);
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
            c_Login.HandleLogin(username.Text, password.Text);
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
