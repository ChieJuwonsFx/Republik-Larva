using Republik_Larva.Controller;
using System;
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
            AturKolomDataGridView();
        }

        private void AturKolomDataGridView()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.FillWeight = 100;
            }
        }
    }
}
