using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Republik_Larva.Models;
using Republik_Larva.Views;

namespace Republik_Larva.Controller
{
    public class C_SendEmail : C_MessageBox
    {
        C_MainForm C_MainForm;
        V_SendEmail V_SendEmail;
        M_Akun m_Akun;
        public C_SendEmail(C_MainForm controller)
        {
            C_MainForm = controller;
            V_SendEmail = new V_SendEmail(this);
            controller.moveView(V_SendEmail);
        }
        public void resetEmail()
        {
            V_SendEmail = new V_SendEmail(this);
            C_MainForm.moveView(V_SendEmail);
        }
        public DataTable GetCustomerData()
        {
            try
            {
                DataTable customerData = M_Customer.All();
                if (customerData == null || customerData.Rows.Count == 0)
                {
                    Console.WriteLine("Tidak ada data pelanggan yang ditemukan.");
                }
                return customerData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat mengambil data customer: {ex.Message}");
                throw;
            }
        }
    }
}
