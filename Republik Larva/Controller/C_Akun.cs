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
using System.Diagnostics.Metrics;

namespace Republik_Larva.Controller
{
    public class C_Akun : C_MessageBox
    {
        C_MainForm C_MainForm;
        C_Route route;
        V_Akun view_akun;
        public C_Akun(C_MainForm controller)
        {
            C_MainForm = controller;
            view_akun = new V_Akun(this);
            controller.moveView(view_akun);
        }
        public void logout()
        {
            if (show_confirm_message_box("Apakah Anda Yakin  ?"))
            {
                route.NavigateTo(new V_Login());
            }
        }
    }
}
