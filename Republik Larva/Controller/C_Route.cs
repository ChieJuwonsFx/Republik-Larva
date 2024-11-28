using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Controller;
using System.Windows.Forms;

namespace Republik_Larva.Controller
{
    public class C_Route
    {
        public Form currentForm;
        public C_Route(Form CurrentForm)
        {
            currentForm = CurrentForm;
        }


        /// <param name="targetForm">Form tujuan</param>
        public void NavigateTo(Form targetForm)
        {
            targetForm.Show();
            currentForm.Hide();
        }
        public void ExitApplication()
        {
            Application.Exit();
        }
    }
}

