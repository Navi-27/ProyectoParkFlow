using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.Persistence;
using ParkFlow.Tools;
using ParkFlow.models;

namespace ParkFlow.Presentacion
{
    internal partial class FrPorteria : Form
    {
        public FrPorteria()
        {
            InitializeComponent();
        }

        private RepositoryVehiculos? _vehiculos;
        private RepositoryPersonas? _personas;
        private RepositoryParqueaderos? _parqueaderos;
        private RepositoryEstancias? _estancias;
        private int? _idEstanciaSeleccionada;

        private void FrPorteria_Load(object sender, EventArgs e)
        {
            try
            {
                _vehiculos = RepositoryVehiculos.GetInstance(new VehiculosSqlStore());
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                _parqueaderos = RepositoryParqueaderos.GetInstance(new ParqueaderoSqlStore());
                _estancias = RepositoryEstancias.GetInstance(new EstanciaSqlStore());

                CargarContadores();
                CargarVehiculos();
            }
            catch (MySqlException ex)
            {

                Mensajes.Error("No se pudieron cargar los datos de portería:", ex, "Portería");
            }
        }

        private void CargarVehiculos()
        {
            if (_estancias == null || _vehiculos == null || _personas == null || _parqueaderos == null) return;

            string texto = txtBuscar.Text.Trim();

            dgvDentro.AutoGenerateColumns = false;
            dgvDentro.DataSource = null;
            dgvDentro.DataSource = _estancias.GetAll()
                .Where(e => e.VehiculoPlaca.Contains(texto))
                .OrderByDescending(e => e.FechaLlegada)
                .Select(e => new
                {
                    e.Id,
                    e.VehiculoPlaca,
                    DocPropietario = _vehiculos.GetById(e.VehiculoPlaca)?.PersonaDocumento,
                    NombrePropietario = _personas.GetById(_vehiculos.GetById(e.VehiculoPlaca)?.PersonaDocumento ?? "")?.Nombre,
                    Plaza = _parqueaderos.GetById(e.IdParqueadero)?.Codigo,
                    e.FechaLlegada,
                    e.TiempoOcupado,
                    e.FechaSalida,
                })
                .ToList();
            dgvDentro.ClearSelection();

        }

        private void CargarContadores()
        {
            if (_parqueaderos == null) return;

            int total = _parqueaderos.GetAll().Count();
            int libres = _parqueaderos.GetLibres().Count();
            int ocupadas = total - libres;
            double porcentaje = total == 0 ? 0 : ocupadas * 100.0 / total;

            lblLibres.Text = libres.ToString();
            lblOcupadas.Text = ocupadas.ToString();
            lblOcupacion.Text = $"{porcentaje:0} %";

        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            if (_personas == null || _vehiculos == null || _estancias == null) return;

            string placa = txtPlaca.Text.Trim();
            if (placa == "")
            {
                Mensajes.Aviso("Escriba la placa del vehículo.", "Portería");
                return;
            }

            Vehiculo? vehiculo = _vehiculos.GetById(placa);
            if (vehiculo == null)
            {
                Mensajes.Aviso("Ese vehículo no está registrado.", "Portería");
                return;
            }

            if (_estancias.GetActivas().Any(es => es.VehiculoPlaca == placa))
            {
                Mensajes.Aviso("Este vehículo ya está dentro. Registre primero su salida.", "Portería");
                return;
            }

            Parqueadero? plaza = _parqueaderos.GetLibres().FirstOrDefault(p => p.PersonaDocumento == vehiculo.PersonaDocumento)
                    ?? _parqueaderos.GetLibres().FirstOrDefault(p => p.Tipo == "VISITANTE");
            if (plaza == null)
            {
                Mensajes.Aviso("No hay plazas disponibles.", "Portería");
                return;
            }

            try
            {
                Estancia estancia = Estancia.Create();
                estancia.VehiculoPlaca = placa;
                estancia.IdParqueadero = plaza.Id;
                _estancias.Add(estancia);
                _estancias.Commit();

                plaza.VehiculoPlaca = placa;
                _parqueaderos.Update(plaza);
                _parqueaderos.Commit();

                CargarVehiculos();
                CargarContadores();
            }
            catch (InvalidOperationException ex)
            {
                Mensajes.Aviso(ex.Message, "Portería");
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo registrar el ingreso:", ex, "Portería");
                CargarVehiculos();
                CargarContadores();
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            if (_personas == null || _vehiculos == null || _parqueaderos == null) return;

            string placa = txtPlaca.Text.Trim();
            if (placa == null) return;

            Vehiculo? vehiculo = _vehiculos.GetById(placa);
            if (vehiculo == null)
            {
                txtPropietario.Clear();
                txtPlaza.Clear();
                return;
            }

            txtPropietario.Text = _personas.GetById(vehiculo.PersonaDocumento)?.Nombre;
            Parqueadero? plaza = _parqueaderos.GetLibres().FirstOrDefault(p => p.PersonaDocumento == vehiculo.PersonaDocumento)
                    ?? _parqueaderos.GetLibres().FirstOrDefault(p => p.Tipo == "VISITANTE");

            txtPlaza.Text = plaza?.Codigo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _idEstanciaSeleccionada = null;
            FormHelper.LimpiarCampos(txtPlaca, txtPropietario, txtPlaza);
            dgvDentro.ClearSelection();
            txtPlaca.Focus();
        }

        private void dgvDentro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _idEstanciaSeleccionada = (int)dgvDentro.Rows[e.RowIndex].Cells[colId.Index].Value;
            txtPlaca.Text = dgvDentro.Rows[e.RowIndex].Cells[colPlaca.Index].Value?.ToString();
            txtPropietario.Text = dgvDentro.Rows[e.RowIndex].Cells[colNombrePropietario.Index].Value?.ToString();
            txtPlaza.Text = dgvDentro.Rows[e.RowIndex].Cells[colPlaza.Index].Value?.ToString();
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (_estancias == null || _parqueaderos == null || _idEstanciaSeleccionada == null)
            {
                Mensajes.Aviso("Seleccione un vehículo en la tabla", "Portería");
                return;
            }

            Estancia? estancia = _estancias.GetById(_idEstanciaSeleccionada.Value);

            if (estancia == null) return;

            if(estancia.FechaSalida != null)
            {
                Mensajes.Aviso("Este vehiculo ya salio", "Portería");
                return;
            }

            if (!Mensajes.Confirmar($"¿Registrar la salida de {estancia.VehiculoPlaca}?", "Portería")) return;

            try
            {
                estancia.FechaSalida = DateTime.Now;
                _estancias.Update(estancia);
                _estancias.Commit();

                Parqueadero? plaza = _parqueaderos.GetById(estancia.IdParqueadero);
                if(plaza != null)
                {
                    plaza.VehiculoPlaca = "";
                    _parqueaderos.Update(plaza);
                    _parqueaderos.Commit();
                }

                CargarVehiculos();
                CargarContadores();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo registrar la salida:", ex, "Portería");
            }
        }
    }
}
