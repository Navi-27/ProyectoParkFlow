using ParkFlow.Presentacion;
using ParkFlow.Tools;
namespace ParkFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = $"ParkFlow - {Sesion.UsuarioActual?.NombreUsuario} ({Sesion.UsuarioActual?.Rol})";
        }

        private void listaResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool.openForm<FrResidente>(this);
        }
    }
}
