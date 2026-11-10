using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;
using System;
using System.Windows.Forms;

namespace ParkFlow.Presentacion
{
    internal partial class FrLogin : Form
    {
        public FrLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!Validador.Requeridos(txtUsuario, txtClave))
            {
                Mensajes.Aviso("Escribe el usuario y la clave.", "Login");
                return;
            }

            try
            {
                RepositoryUsuarios repo = RepositoryUsuarios.GetInstance(new UsuarioSqlStore());
                Usuario? usuario = repo.Autenticar(txtUsuario.Text.Trim(), txtClave.Text);

                if (usuario == null)
                {
                    Mensajes.Aviso("Usuario o clave incorrectos.", "Login");
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                Sesion.UsuarioActual = usuario;
                DialogResult = DialogResult.OK;
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo conectar a la base de datos:", ex, "Login");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
