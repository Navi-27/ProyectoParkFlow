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
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Escribe el usuario y la clave.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RepositoryUsuarios repo = RepositoryUsuarios.GetInstance(new UsuarioSqlStore());
                Usuario? usuario = repo.Autenticar(txtUsuario.Text.Trim(), txtClave.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o clave incorrectos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                Sesion.UsuarioActual = usuario;
                DialogResult = DialogResult.OK;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos:\n" + ex.Message, "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
