using System.Windows.Forms;
using Republik_Larva.Views;

namespace Republik_Larva.Controller
{
    public class C_MainForm
    {
        private MainForm mainForm;
        public C_MainForm(MainForm form)
        {
            mainForm = form;
        }

        public void moveView(Form form)
        {
            mainForm.panelUtama.Controls.Clear();
            mainForm.panelUtama.Controls.Add(form);
        }

    }
}
