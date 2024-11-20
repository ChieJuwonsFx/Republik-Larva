using Republik_Larva.Views;

namespace Republik_Larva
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mengatur konfigurasi aplikasi (misalnya, DPI atau font default)
            ApplicationConfiguration.Initialize();

            // Menjalankan Form sendEmail sebagai form utama
            Application.Run(new sendEmail());
        }
    }
}
