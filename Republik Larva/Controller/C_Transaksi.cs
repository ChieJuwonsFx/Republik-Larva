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

namespace Republik_Larva.Controller
{
    public class C_Transaksi : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_Transaksi view_transaksi;
        public C_Transaksi(C_MainForm controller)
        {
            C_MainForm = controller;
            view_transaksi = new V_Transaksi(this);
            C_MainForm.moveView(view_transaksi);
        }
    }
}