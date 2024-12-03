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

namespace Republik_Larva.Views.Transaksi
{
    public partial class V_LihatSemua : UserControl
    {
        private C_Transaksi c_Transaksi;

        public V_LihatSemua(C_Transaksi controller)
        {
            InitializeComponent();
            c_Transaksi = controller;

            c_Transaksi.TampilkanSemuaTransaksi(dataGridView1);

            AdjustColumnWidths();
        }
        private void AdjustColumnWidths()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "ID")
                {
                    column.FillWeight = 10; // Lebar lebih kecil
                }
                else if (column.Name == "Nama")
                {
                    column.FillWeight = 30; // Lebar lebih besar
                }
                else
                {
                    column.FillWeight = 20; // Lebar standar
                }
            }
        }


    }
}
