using Republik_Larva.Controller;
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
            // To customize application configuration such as set high DPI settings or default font,

            EnvLoader.LoadEnvironmentVariables();
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new V_Login());
        }
    }
}