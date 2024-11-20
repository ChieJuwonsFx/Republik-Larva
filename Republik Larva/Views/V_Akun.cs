using Republik_Larva.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controllers;

namespace Republik_Larva.Views
{
    public partial class V_Akun : Form
    {
        private Route Route;
        public V_Akun()
        {
            InitializeComponent();
            Route = new Route(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Route.ExitApplication();
        }
    }
}
