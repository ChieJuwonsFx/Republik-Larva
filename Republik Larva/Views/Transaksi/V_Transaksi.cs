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

namespace Republik_Larva.Views
{
    public partial class V_Transaksi : UserControl
    {
        C_Transaksi c_Transaksi;
        public V_Transaksi(C_Transaksi c_Transaksi)
        {
            InitializeComponent();
        }
    }
}
