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
    public class C_Dashboard : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_Utama view_utama;
        public C_Dashboard(C_MainForm controller)
        {
            C_MainForm = controller;
            view_utama = new V_Utama();
            C_MainForm.moveView(view_utama);
        }
    }
}