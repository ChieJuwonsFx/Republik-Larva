using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Views;
using Republik_Larva.Models;
using NpgsqlTypes;
using System.Numerics;
using Republik_Larva.Controller;
using System.Windows.Forms;
using System.Data;

namespace Republik_Larva.Controller
{
    public class C_Produk : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_Produk view_produk;
        M_Produk M_Produk = new M_Produk();
        public C_Produk(C_MainForm controller)
        {
            C_MainForm = controller;
            view_produk = new V_Produk(this);
            C_MainForm.moveView(view_produk);
        }
        public DataTable GetProdukList()
        {
            return M_Produk.All();
        }
    }
}
