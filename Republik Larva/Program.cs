using Republik_Larva.Views;

namespace Republik_Larva
{
    internal static class Program
    {
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new V_Dashboard());
        }
    }
}
