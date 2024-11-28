using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Views;
using Republik_Larva.Controller;

namespace Republik_Larva.Views
{
    public partial class V_Dashboard : Form
    {
        private C_Route Route;

        public V_Dashboard()
        {
            InitializeComponent();
            Route = new C_Route(this);
        }

        //C_Dashboard Controller;
        //public V_Dashboard(C_Dashboard c_Dashboard)
        //{
        //    InitializeComponent();
        //    Controller = c_Dashboard;
        //}


        private void btnEmail_Click(object sender, EventArgs e)
        {
            //Route.NavigateTo(new V_SendEmail1());
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            //Route.NavigateTo(new V_Produk());
        }
        private void btnAkun_Click(object sender, EventArgs e)
        {
            //Route.NavigateTo(new V_Akun());
        }
        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            //Route.NavigateTo(new V_Transaksi());
        }
    }
}
