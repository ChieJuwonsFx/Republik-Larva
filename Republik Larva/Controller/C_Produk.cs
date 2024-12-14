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
using Republik_Larva.Views.Produk;
using Republik_Larva.Views.Akun;

namespace Republik_Larva.Controller
{
    public class C_Produk : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_Produk view_produk;
        V_FormAddProduk view_add;
        V_FormUbahProduk view_ubah;
        M_Produk M_Produk = new M_Produk();
        private int idProduk;
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
        public void balikProduk()
        {
            view_produk = new V_Produk(this);
            C_MainForm.moveView(view_produk);
        }
        public void addView()
        {
            view_add = new V_FormAddProduk(this);
            C_MainForm.moveView(view_add);
        }
        public void editProdukView(int produkId)
        {
            if (produkId <= 0)
            {
                show_message_box($"ID Produk tidak valid.");
                return;
            }
            M_Produk produkData = M_Produk.getProdukById(produkId);  
            if (produkData == null)
            {
                show_message_box("Produk tidak ditemukan.");
            }
            else
            {
                view_ubah = new V_FormUbahProduk(this, produkData); 
                C_MainForm.moveView(view_ubah);
            }
        }
    }
}
