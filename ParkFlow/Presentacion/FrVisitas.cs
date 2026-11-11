using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;

namespace ParkFlow.Presentacion
{
    internal partial class FrVisitas : Form
    {
        public FrVisitas()
        {
            InitializeComponent();
        }

        private RepositoryPersonas? _personas;
        private RepositoryViviendas? _viviendas;
        private RepositoryRegistros? _registros;
        private int? _idVisitaSeleccionada;

        private void FrVisitas_Load(object sender, EventArgs e)
        {
            try
            {
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                _viviendas = RepositoryViviendas.GetInstance(new ViviendaSqlStore());
                _registros = RepositoryRegistros.GetInstance(new RegistroSqlStore());

                CargarResidentes();
                CargarVisitas();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudieron cargar los datos de visitas:", ex, "Visitas");
            }
        }

        private void CargarVisitas()
        {
            if (_registros == null || _personas == null) return;

            string texto = txtBuscar.Text.Trim();

            dgvVisitas.AutoGenerateColumns = false;
            dgvVisitas.DataSource = null;
            dgvVisitas.DataSource = _registros.GetAll()
                .Where(r => r.PersonaVisitante.Contains(texto) || r.PersonaVisitada.Contains(texto))
                .OrderByDescending(r => r.FechaIngreso)
                .Select(r => new
                {
                    r.Id,
                    r.PersonaVisitante,
                    NombreVisitante = _personas.GetById(r.PersonaVisitante)?.Nombre,
                    r.PersonaVisitada,
                    NombreVisitado = _personas.GetById(r.PersonaVisitada)?.Nombre,
                    r.IdVivienda,
                    r.FechaIngreso,
                    r.FechaSalida,
                    r.TiempoVisita
                })
                .ToList();
            dgvVisitas.ClearSelection();
        }

        private void CargarResidentes()
        {
            if (_personas == null) return;

            cmbResidente.DisplayMember = "Nombre";
            cmbResidente.ValueMember = "Id";
            cmbResidente.DataSource = _personas.GetAll()
                .OfType<Residente>()
                .OrderBy(r => r.Nombre)
                .ToList();
            cmbResidente.SelectedIndex = -1;
        }

        private void CargarViviendas()
        {
            if (_viviendas == null) return;

            if (cmbResidente.SelectedValue is not string documento)
            {
                cmbVivienda.DataSource = null;
                return;
            }

            cmbVivienda.DisplayMember = "Texto";
            cmbVivienda.ValueMember = "Id";
            cmbVivienda.DataSource = _viviendas.GetByPersona(documento)
                .Select(v => new { v.Id, Texto = $"Torre {v.Torre} - Piso {v.Piso} - Apto {v.Apartamento}" })
                .ToList();
            cmbVivienda.SelectedIndex = -1;

        }

        private void cmbResidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarViviendas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVisitas();
        }

        private void dgvVisitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _registros == null || _personas == null) return;

            int id = (int)dgvVisitas.Rows[e.RowIndex].Cells[colId.Index].Value;
            Registro? visita = _registros.GetById(id);

            if (visita == null) return;

            _idVisitaSeleccionada = visita.Id;

            Persona? persona = _personas.GetById(visita.PersonaVisitante);
            if (persona != null)
            {
                txtDocumento.Text = persona.Id;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtTelefono.Text = persona.Telefono;
                chkMovilidad.Checked = persona.MovilidadReducida;

                cmbTipoDocumento.SelectedIndex = -1;
                foreach (object item in cmbTipoDocumento.Items)
                {
                    if (item.ToString()!.StartsWith(persona.TipoDocumento + " "))
                    {
                        cmbTipoDocumento.SelectedItem = item;
                        break;
                    }
                }
            }

            cmbResidente.SelectedValue = visita.PersonaVisitada;
            cmbVivienda.SelectedValue = visita.IdVivienda;

            btnRegistrarSalida.Enabled = visita.FechaSalida == null;

        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            if (_personas == null || _registros == null) return;

            if (cmbTipoDocumento.SelectedItem == null
                || !Validador.Requeridos(txtDocumento, txtNombre, txtApellido, txtTelefono))
            {
                Mensajes.Aviso("Complete los datos del visitante.", "Visitas");
                return;
            }

            if (cmbResidente.SelectedValue is not string documentoResidente || cmbVivienda.SelectedValue == null)
            {
                Mensajes.Aviso("Elija el residente y la vivienda.", "Visitas");
                return;
            }

            string documento = txtDocumento.Text.Trim();

            if (_registros.GetActivas().Any(r => r.PersonaVisitante == documento))
            {
                Mensajes.Aviso("Este visitante ya está adentro. Registre primero su salida.", "Visitas");
                return;
            }

            try
            {
                if (_personas.GetById(documento) == null)
                {
                    Visitante? nuevo = Visitante.Create();
                    nuevo.TipoDocumento = cmbTipoDocumento.SelectedItem!.ToString()!.Split('-')[0].Trim();
                    nuevo.Id = txtDocumento.Text.Trim();
                    nuevo.Nombre = txtNombre.Text.Trim();
                    nuevo.Apellido = txtApellido.Text.Trim();
                    nuevo.Telefono = txtTelefono.Text.Trim();
                    nuevo.MovilidadReducida = chkMovilidad.Checked;
                    _personas.Add(nuevo);
                    _personas.Commit();
                }

                Registro visita = Registro.Create();
                visita.PersonaVisitante = documento;
                visita.PersonaVisitada = documentoResidente;
                visita.IdVivienda = (int)cmbVivienda.SelectedValue;
                _registros.Add(visita);
                _registros.Commit();

                CargarVisitas();
                Limpiar();
            }
            catch (InvalidOperationException ex)
            {
                Mensajes.Aviso(ex.Message, "Visitas");
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo registrar el ingreso:", ex, "Visitas");
                CargarVisitas();
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (_registros == null || _idVisitaSeleccionada == null)
            {
                Mensajes.Aviso("Seleccione una visita en la tabla.", "Visitas");
                return;
            }

            Registro? visita = _registros.GetById(_idVisitaSeleccionada.Value);
            if (visita == null) return;

            if (visita.FechaSalida != null)
            {
                Mensajes.Aviso("Esta visita ya tiene salida.", "Visitas");
                return;
            }

            if (!Mensajes.Confirmar("¿Registrar la salida de esta visita?", "Visitas")) return;

            try
            {
                visita.FechaSalida = DateTime.Now;
                _registros.Update(visita);
                _registros.Commit();
                CargarVisitas();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo registrar la salida:", ex, "Visitas");
                CargarVisitas();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _idVisitaSeleccionada = null;
            cmbTipoDocumento.SelectedIndex = -1;
            FormHelper.LimpiarCampos(txtDocumento, txtNombre, txtApellido, txtTelefono);
            chkMovilidad.Checked = false;
            cmbResidente.SelectedIndex = -1;
            btnRegistrarSalida.Enabled = false;
            dgvVisitas.ClearSelection();
            txtDocumento.Focus();
        }
    }
}
