using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using Republik_Larva.Controller;

namespace Republik_Larva.Views.popUp
{
    public partial class V_confirmMessage : Form
    {
        C_MessageBox controller;
        string message;
        public V_confirmMessage(C_MessageBox controller, string Message)
        {
            InitializeComponent();
            this.controller = controller;
            this.message = Message;
        }

        private void batal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void konfirm_Click(object sender, EventArgs e)
        {
            controller.confirmed = true;
            this.Close();
        }

        private void batal_MouseEnter(object sender, EventArgs e)
        {
            batal.BackgroundImage = Properties.Resources.batalHover;
        }

        private void batal_MouseHover(object sender, EventArgs e)
        {
            batal.Cursor = Cursors.Hand;
        }

        private void batal_MouseLeave(object sender, EventArgs e)
        {
            batal.BackgroundImage = Properties.Resources.batal;
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

        private void V_confirmMessage_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }
    }
}
