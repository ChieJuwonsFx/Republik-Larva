using Republik_Larva.Controller;
using Republik_Larva.Models;
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
    public partial class V_BatalkanTransaksi : UserControl
    {
        private C_Transaksi c_Transaksi;
        M_Transaksi m_Transaksi;
        public V_BatalkanTransaksi(C_Transaksi controller)
        {
            InitializeComponent();
            c_Transaksi = controller;
            LoadDataTransaksi();
        }

        private void LoadDataTransaksi()
        {
            c_Transaksi.LoadBatalkanTransaksi(dataGridTransaksi);
        }


        private void dataGridTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridTransaksi.Columns["Delete"].Index)
            {
                try
                {
                    bool result = c_Transaksi.show_confirm_message_box("Apakah Anda yakin ingin membatalkan transaksi? Proses ini tidak dapat dibatalkan.");
                    if (result == true)
                    {
                        int transaksiId = Convert.ToInt32(dataGridTransaksi.Rows[e.RowIndex].Cells["transaksi_id"].Value);
                        c_Transaksi.HapusTransaksiDenganBatasWaktu(transaksiId);
                        LoadDataTransaksi();
                    }
                    else
                    {
                        c_Transaksi.show_message_box("Perubahan status transaksi dibatalkan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            c_Transaksi.balikTransaksi();
        }
        private void btnKembali_MouseLeave(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembali;
        }
        private void btnKembali_MouseEnter(object sender, EventArgs e)
        {
            btnKembali.BackgroundImage = Properties.Resources.kembaliHover;
        }
    }
}

