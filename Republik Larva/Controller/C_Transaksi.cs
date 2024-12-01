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
using Republik_Larva.Views.Akun;
using Republik_Larva.Views.Transaksi;
using System.Data;
using System.Windows.Forms;

namespace Republik_Larva.Controller
{
    public class C_Transaksi : C_MessageBox
    {
        C_MainForm C_MainForm;
        private C_MessageBox c_MessageBox;
        V_Transaksi view_transaksi;
        V_TambahTransaksi tambah_transaksi;
        M_Transaksi M_Produk = new M_Transaksi();
        public C_Transaksi(C_MainForm controller)
        {
            C_MainForm = controller;
            c_MessageBox = new C_MessageBox();

            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
        }
        public void balikTransaksi()
        {
            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
        }
        public void tambahTransaksiView()
        {
            tambah_transaksi = new V_TambahTransaksi(this);
            C_MainForm.moveView(tambah_transaksi);
        }
    }
}