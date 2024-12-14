using Republik_Larva.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Republik_Larva.Views.popUp
{
    public partial class V_okMessage : Form
    {
        string message;
        public V_okMessage(string message)
        {
            InitializeComponent();
            this.message = message;
        }

        private void konfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void konfirm_MouseEnter(object sender, EventArgs e)
        {
            konfirm.BackgroundImage = Properties.Resources.konfirmHover;
        }

        private void konfirm_MouseHover(object sender, EventArgs e)
        {
            konfirm.Cursor = Cursors.Hand;
        }

        private void konfirm_MouseLeave(object sender, EventArgs e)
        {
            konfirm.BackgroundImage = Properties.Resources.konfirm;
        }

        private void V_okMessage_Load_1(object sender, EventArgs e)
        {
            label1.Text = message;
        }
    }
}
