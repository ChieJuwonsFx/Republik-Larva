using Republik_Larva.Controllers;
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

namespace Republik_Larva.Views
{
    public partial class V_Dashboard : Form
    {
        private Route Route;

        public V_Dashboard()
        {
            InitializeComponent();
            Route = new Route(this);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_SendEmail());
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Produk());
        }
        private void btnAkun_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Akun());
        }
        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Route.NavigateTo(new V_Transaksi());
        }
    }
}
