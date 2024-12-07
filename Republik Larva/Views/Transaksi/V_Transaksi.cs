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

namespace Republik_Larva.Views
{
    public partial class V_Transaksi : UserControl
    {
        private C_Transaksi c_Transaksi; 
        public V_Transaksi(C_Transaksi c_Transaksi)
        {
            InitializeComponent();
            this.c_Transaksi = c_Transaksi;
            c_Transaksi.TampilkanTransaksiSebulan(dataGridView1);
            AturKolomDataGridView();
        }
        public void UpdateDashboard(int JumlahTransaksi, int TotalPenghasilan, int TotalMaggotTerjual)
        {
            jumlahTransaksi.Text = JumlahTransaksi.ToString();
            totalPenghasilan.Text = "Rp " + TotalPenghasilan.ToString("N0");
            jumlahMaggot.Text = TotalMaggotTerjual.ToString();
        }
        private void AturKolomDataGridView()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.FillWeight = 100;
            }
        }

        private void btnTambahTransaksi_Click(object sender, EventArgs e)
        {
            c_Transaksi.tambahTransaksiView();
        }
        private void btnTambahTransaksi_MouseEnter(object sender, EventArgs e)
        {
            btnTambahTransaksi.BackgroundImage = Properties.Resources.tambahTransaksiHover;
        }
        private void btnTambahTransaksi_MouseLeave(object sender, EventArgs e)
        {
            btnTambahTransaksi.BackgroundImage = Properties.Resources.tambahTransaksi;
        }
        private void btnBatalkan_Click(object sender, EventArgs e)
        {
            c_Transaksi.batalkanTransaksiView();
        }
        private void btnBatalkan_MouseEnter(object sender, EventArgs e)
        {
            btnBatalkan.BackgroundImage = Properties.Resources.btnBatalkanTransaksi;
        }
        private void btnBatalkan_MouseLeave(object sender, EventArgs e)
        {
            btnBatalkan.BackgroundImage = Properties.Resources.btnBatalkanTransaksiHover;
        }

        private void btnBelumBayar_Click(object sender, EventArgs e)
        {

        }

        private void btnLihatSemua_Click(object sender, EventArgs e)
        {
            c_Transaksi.semuaTransaksiView();
        }
        private void btnLihatSemua_MouseEnter(object sender, EventArgs e)
        {
            btnLihatSemua.BackgroundImage = Properties.Resources.lihatSemuaTransaksiHover;
        }
        private void btnLihatSemua_MouseLeave(object sender, EventArgs e)
        {
            btnLihatSemua.BackgroundImage = Properties.Resources.lihatSemuaTransaksi;
        }
    }
}
