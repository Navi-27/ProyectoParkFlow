using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;

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
                MessageBox.Show("No se pudieron cargar los vehículos:\n" + ex.Message, "Vehículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
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

            string placa = txtPlaca.Text.Trim();
            if (placa == "" || cmbTipo.SelectedItem == null || txtMarca.Text.Trim() == "" || txtModelo.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos.", "Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_placaSeleccionada == null)
                {
                    Vehiculo nuevo = cmbTipo.SelectedItem.ToString() == "CARRO" ? Carro.Create() : Moto.Create();
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
                MessageBox.Show(ex.Message, "Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo guardar:\n" + ex.Message, "Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarVehiculos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_vehiculos == null || _placaSeleccionada == null) return;

            if (MessageBox.Show($"¿Eliminar el vehículo {_placaSeleccionada}?", "Vehículos",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _vehiculos.Delete(_placaSeleccionada);
                _vehiculos.Commit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo eliminar:\n" + ex.Message, "Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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