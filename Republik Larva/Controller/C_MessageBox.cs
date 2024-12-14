using Republik_Larva.Views.popUp;

namespace Republik_Larva.Controller
{
    public class C_MessageBox 
    {
        public bool confirmed;
        public void show_message_box(string message)
        {
            V_okMessage message_Box = new V_okMessage(message);
            message_Box.ShowDialog();
        }
        public bool show_confirm_message_box(string message)
        {
            V_confirmMessage messagebox = new V_confirmMessage(this, message);
            messagebox.ShowDialog();
            if (confirmed)
            {
                confirmed = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
