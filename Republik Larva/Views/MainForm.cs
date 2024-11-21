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
    public partial class MainForm : Form
    {
        C_MainForm Controller;
        public MainForm(C_MainForm controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        public void panelUtama_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
