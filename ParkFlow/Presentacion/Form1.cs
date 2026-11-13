using ParkFlow.Presentacion;
using ParkFlow.Tools;
namespace ParkFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MostrarUsuario();
        }

        private void MostrarUsuario()
        {
            Text = $"ParkFlow - {Sesion.UsuarioActual?.NombreUsuario} ({Sesion.UsuarioActual?.Rol})";
        }

        private void listaResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.OpenForm<FrResidente>(this);
        }

        private void porteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.OpenForm<FrPorteria>(this);
        }

        private void visitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.OpenForm<FrVisitas>(this);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Mensajes.Confirmar("¿Desea cerrar sesión?", "ParkFlow")) return;

            foreach (Form hijo in MdiChildren)
            {
                hijo.Close();
            }

            Sesion.Cerrar();
            Hide();

            using (FrLogin login = new FrLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    Close();
                    return;
                }
            }

            MostrarUsuario();
            Show();
        }
    }
}
