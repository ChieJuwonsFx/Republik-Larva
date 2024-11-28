using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Views;

namespace Republik_Larva.Controller
{
    public class C_SendEmail : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_SendEmail V_SendEmail;
        public C_SendEmail(C_MainForm controller)
        {
            C_MainForm = controller;
            V_SendEmail = new V_SendEmail(this);
            controller.moveView(V_SendEmail);
        }
    }
}
