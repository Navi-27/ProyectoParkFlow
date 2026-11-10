using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;

namespace ParkFlow.Presentacion
{
    internal partial class FrVehiculos : Form
    {
        private readonly Residente _residente;
        private RepositoryVehiculos? _vehiculos;
        private string? _placaSeleccionada;

        public FrVehiculos(Residente residente)
        {
            InitializeComponent();
            _residente = residente;
        }

        private void FrVehiculos_Load(object sender, EventArgs e)
        {
            Text = $"Vehículos de {_residente.Nombre} {_residente.Apellido} ({_residente.Id})";
            cmbTipo.Items.AddRange(new object[] { "CARRO", "MOTO" });
            try
            {
                _vehiculos = RepositoryVehiculos.GetInstance(new VehiculosSqlStore());
                CargarVehiculos();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudieron cargar los vehículos:", ex, "Vehículos");
                Close();
            }
        }

        private void CargarVehiculos()
        {
            if (_vehiculos == null) return;
            dgvVehiculos.AutoGenerateColumns = false;
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = _vehiculos.GetAll()
                .Where(v => v.PersonaDocumento == _residente.Id)
                .Select(v => new { v.Id, Tipo = v.Tipo(), v.Marca, v.Modelo })
                .ToList();
            dgvVehiculos.ClearSelection();
        }

        private void Limpiar()
        {
            _placaSeleccionada = null;
            FormHelper.LimpiarCampos(txtPlaca, txtMarca, txtModelo);
            cmbTipo.SelectedIndex = -1;
            txtPlaca.Enabled = true;
            cmbTipo.Enabled = true;
            btnEliminar.Enabled = false;
            dgvVehiculos.ClearSelection();
            txtPlaca.Focus();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _vehiculos == null) return;

            string placa = dgvVehiculos.Rows[e.RowIndex].Cells[colPlaca.Index].Value?.ToString() ?? "";
            Vehiculo? v = _vehiculos.GetById(placa);
            if (v == null) return;

            _placaSeleccionada = v.Id;
            txtPlaca.Text = v.Id;
            cmbTipo.SelectedItem = v.Tipo();
            txtMarca.Text = v.Marca;
            txtModelo.Text = v.Modelo;
            txtPlaca.Enabled = false;
            cmbTipo.Enabled = false;
            btnEliminar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_vehiculos == null) return;

            string placa = txtPlaca.Text.Trim().ToUpper();
            if (cmbTipo.SelectedItem == null || !Validador.Requeridos(txtPlaca, txtMarca, txtModelo))
            {
                Mensajes.Aviso("Complete todos los campos.", "Vehículos");
                return;
            }

            bool esCarro = cmbTipo.SelectedItem.ToString() == "CARRO";
            if (_placaSeleccionada == null)
            {
                if (esCarro && !Validador.EsPlacaCarro(placa))
                {
                    Mensajes.Aviso("La placa de carro debe ser 3 letras y 3 números (ej: ABC123).", "Vehículos");
                    return;
                }
                if (!esCarro && !Validador.EsPlacaMoto(placa))
                {
                    Mensajes.Aviso("La placa de moto debe ser 3 letras, 2 números y 1 letra (ej: ABC12D).", "Vehículos");
                    return;
                }
            }

            try
            {
                if (_placaSeleccionada == null)
                {
                    Vehiculo nuevo = esCarro ? Carro.Create() : Moto.Create();
                    nuevo.Id = placa;
                    nuevo.PersonaDocumento = _residente.Id;
                    nuevo.Marca = txtMarca.Text.Trim();
                    nuevo.Modelo = txtModelo.Text.Trim();
                    _vehiculos.Add(nuevo);
                }
                else
                {
                    Vehiculo? v = _vehiculos.GetById(_placaSeleccionada);
                    if (v == null) return;
                    v.Marca = txtMarca.Text.Trim();
                    v.Modelo = txtModelo.Text.Trim();
                    _vehiculos.Update(v);
                }

                _vehiculos.Commit();
                CargarVehiculos();
                Limpiar();
            }
            catch (InvalidOperationException ex)
            {
                Mensajes.Aviso(ex.Message, "Vehículos");
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo guardar:", ex, "Vehículos");
                CargarVehiculos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_vehiculos == null || _placaSeleccionada == null) return;

            if (!Mensajes.Confirmar($"¿Eliminar el vehículo {_placaSeleccionada}?", "Vehículos")) return;

            try
            {
                _vehiculos.Delete(_placaSeleccionada);
                _vehiculos.Commit();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo eliminar:", ex, "Vehículos");
            }
            CargarVehiculos();
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}