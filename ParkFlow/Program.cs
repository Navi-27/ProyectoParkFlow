
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
            using (var login = new Presentacion.FrLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            Application.Run(new Form1());
        }
    }
}
