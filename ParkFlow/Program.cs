
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;

namespace ParkFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
