using System.Windows.Forms;
using Republik_Larva.Views;
using Republik_Larva.Models;

namespace Republik_Larva.Controller
{
    public class C_MainForm : C_MessageBox
    {
        public V_MainForm mainForm;
        public string menu_focus = typeof(V_Dashboard).Name;
        public C_MainForm(V_MainForm main_form)
        {
            this.mainForm = main_form;
            moveView(new V_Utama());
        }

        public void moveView(UserControl view)
        {
            mainForm.panelUtama.Controls.Clear();
            mainForm.panelUtama.Controls.Add(view);
        }
        public void resetButton()
        {
            mainForm.btnDashboard.BackgroundImage = null;
            mainForm.btnTransaksi.BackgroundImage = null;
            mainForm.btnSendEmail.BackgroundImage = null;
            mainForm.btnProduk.BackgroundImage = null;
            mainForm.btnAkun.BackgroundImage = null;
        }

    }
}
