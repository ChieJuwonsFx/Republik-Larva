using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Republik_Larva.Controllers
{
    public class Route
    {
        private Form currentForm;

        // Konstruktor untuk inisialisasi form saat ini
        public Route(Form CurrentForm)
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

