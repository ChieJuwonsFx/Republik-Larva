using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controller;

namespace Republik_Larva.Views
{
    public partial class V_Akun : UserControl
    {
        C_Akun c_Akun;
        public V_Akun(C_Akun controller)
        {
            InitializeComponent();
            c_Akun = controller;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
