using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Models;
using Republik_Larva.Controller;

namespace Republik_Larva.Views.Produk
{  
    public partial class V_FormAddProduk : UserControl
    {
        private C_Produk c_Produk;
        public V_FormAddProduk()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            c_Produk.balikProduk();
        }
    }
}
