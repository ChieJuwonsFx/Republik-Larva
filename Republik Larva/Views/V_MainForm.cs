using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Republik_Larva.Controller;

namespace Republik_Larva.Views
{
    public partial class V_MainForm : Form
    {
        C_MainForm mainForm;
        C_Route Route;
        public V_MainForm()
        {
            InitializeComponent();
            mainForm = new C_MainForm(this);
        }

        public void panelUtama_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            mainForm.menu_focus = typeof(V_SendEmail).Name;
            mainForm.resetButton();
            btnSendEmail.BackgroundImage = Properties.Resources.sendEmailFokus;
            C_SendEmail controller_email = new C_SendEmail(mainForm);
        }

        private void btnAkun_Click(object sender, EventArgs e)
        {
            mainForm.menu_focus = typeof(V_Akun).Name;
            mainForm.resetButton();
            btnAkun.BackgroundImage = Properties.Resources.kelolaAkunFokus;
            C_Akun controller_akun = new C_Akun(mainForm);
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            mainForm.menu_focus = typeof(V_Produk).Name;
            mainForm.resetButton();
            btnProduk.BackgroundImage = Properties.Resources.kelolaProdukFokus;
            C_Produk controller_produk = new C_Produk(mainForm);
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            mainForm.menu_focus = typeof(V_Transaksi).Name;
            mainForm.resetButton();
            btnTransaksi.BackgroundImage = Properties.Resources.transaksiFokus;
            C_Transaksi controller_transaksi = new C_Transaksi(mainForm);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainForm.menu_focus = typeof(V_Utama).Name;
            mainForm.resetButton();
            btnDashboard.BackgroundImage = Properties.Resources.dashboardFokus;
            C_Dashboard controller_transaksi = new C_Dashboard(mainForm);
        }
        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {
            btnDashboard.Cursor = Cursors.Hand;
        }
        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Utama).Name)
            {
                btnDashboard.BackgroundImage = null;
            };
        }
        private void btnDashboard_MouseEnter(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Utama).Name)
            {
                btnDashboard.BackgroundImage = Properties.Resources.dashboardHover;
            };
        }
        private void btnTransaksi_MouseHover(object sender, EventArgs e)
        {
            btnTransaksi.Cursor = Cursors.Hand;
        }
        private void btnTransaksi_MouseLeave(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Transaksi).Name)
            {
                btnTransaksi.BackgroundImage = null;
            };
        }
        private void btnTransaksi_MouseEnter(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Transaksi).Name)
            {
                btnTransaksi.BackgroundImage = Properties.Resources.transaksiHover;
            };
        }
        private void btnProduk_MouseHover(object sender, EventArgs e)
        {
            btnProduk.Cursor = Cursors.Hand;
        }
        private void btnProduk_MouseLeave(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Produk).Name)
            {
                btnProduk.BackgroundImage = null;
            };
        }
        private void btnProduk_MouseEnter(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Produk).Name)
            {
                btnProduk.BackgroundImage = Properties.Resources.kelolaProdukHover;
            };
        }
        private void btnSendEmail_MouseHover(object sender, EventArgs e)
        {
            btnSendEmail.Cursor = Cursors.Hand;
        }
        private void btnSendEmail_MouseLeave(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_SendEmail).Name)
            {
                btnSendEmail.BackgroundImage = null;
            };
        }
        private void btnSendEmail_MouseEnter(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_SendEmail).Name)
            {
                btnSendEmail.BackgroundImage = Properties.Resources.sendEmailHover;
            };
        }
        private void btnAkun_MouseHover(object sender, EventArgs e)
        {
            btnAkun.Cursor = Cursors.Hand;
        }
        private void btnAkun_MouseLeave(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Akun).Name)
            {
                btnAkun.BackgroundImage = null;
            };
        }
        private void btnAkun_MouseEnter(object sender, EventArgs e)
        {
            if (mainForm.menu_focus != typeof(V_Akun).Name)
            {
                btnAkun.BackgroundImage = Properties.Resources.kelolaAkunHover;
            };
        }
    }

}
