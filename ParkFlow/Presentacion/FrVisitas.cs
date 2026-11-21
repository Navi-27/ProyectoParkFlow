using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.Logica;
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
        private RepositoryVehiculos? _vehiculos;
        private RepositoryParqueaderos? _parqueaderos;
        private RepositoryEstancias? _estancias;
        private RepositoryViviendas? _viviendas;
        private RepositoryRegistros? _registros;
        private int? _idVisitaSeleccionada;
        private AsignadorPlazas? _asignador;

        private void FrVisitas_Load(object sender, EventArgs e)
        {
            try
            {
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                _vehiculos = RepositoryVehiculos.GetInstance(new VehiculosSqlStore());
                _parqueaderos = RepositoryParqueaderos.GetInstance(new ParqueaderoSqlStore());
                _estancias = RepositoryEstancias.GetInstance(new EstanciaSqlStore());
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
            CargarRutas();
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
                    NombreVisitante = _personas.GetById(r.PersonaVisitante)?.Nombre + " " + _personas.GetById(r.PersonaVisitante)?.Apellido,
                    r.PersonaVisitada,
                    NombreVisitado = _personas.GetById(r.PersonaVisitada)?.Nombre + " " + _personas.GetById(r.PersonaVisitada)?.Apellido,
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

        private void CargarRutas()
        {
            try
            {
                RepositoryNodos nodos = RepositoryNodos.GetInstance(new NodoRutaSqlStore());
                RepositoryAristas aristas = RepositoryAristas.GetInstance(new AristaRutaSqlStore());
                _asignador = new AsignadorPlazas(nodos.GetAll(), aristas.GetAll());
            }
            catch (MySqlException ex)
            {
                _asignador = null;
                Mensajes.Error("No se pudo cargar el grafo de rutas; las plazas se asignarán sin ruta:", ex, "Visitas");
            }
        }

        private void MostrarVisitante(Persona persona)
        {
            txtDocumento.Text = persona.Id;
            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
            txtTelefono.Text = persona.Telefono;
            chkMovilidad.Checked = persona.MovilidadReducida;
            FormHelper.SeleccionarTipoDocumento(cmbTipoDocumento, persona.TipoDocumento);
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
                MostrarVisitante(persona);
            }

            cmbResidente.SelectedValue = visita.PersonaVisitada;
            cmbVivienda.SelectedValue = visita.IdVivienda;

            btnRegistrarSalida.Enabled = visita.FechaSalida == null;

        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            if (_personas == null || _registros == null || _vehiculos == null || _parqueaderos == null || _estancias == null) return;

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
            string tipoDocumento = cmbTipoDocumento.SelectedItem!.ToString()!.Split('-')[0].Trim();

            if (tipoDocumento != "PA" && !Validador.EsSoloNumeros(documento))
            {
                Mensajes.Aviso("El documento solo debe tener números (excepto pasaporte).", "Visitas");
                return;
            }

            if (!Validador.EsTelefono(txtTelefono.Text.Trim()))
            {
                Mensajes.Aviso("El teléfono debe tener entre 7 y 10 números.", "Visitas");
                return;
            }

            Persona? existente = _personas.GetById(documento);
            if (existente != null && existente is not Visitante)
            {
                Mensajes.Aviso("Ese documento pertenece a un residente. No se puede registrar como visitante.", "Visitas");
                return;
            }

            if (_registros.GetActivas().Any(r => r.PersonaVisitante == documento))
            {
                Mensajes.Aviso("Este visitante ya está adentro. Registre primero su salida.", "Visitas");
                return;
            }

            try
            {
                if (existente == null)
                {
                    Visitante nuevo = Visitante.Create();
                    nuevo.TipoDocumento = tipoDocumento;
                    nuevo.Id = documento;
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

                if (rbVehiculo.Checked)
                {
                    Persona? visitante = _personas.GetById(documento);

                    if (visitante != null && !_vehiculos.GetAll().Any(v => v.PersonaDocumento == documento))
                    {
                        Mensajes.Aviso("El visitante no tiene vehículos registrados. Registre su vehículo.", "Visitas");
                        using var fr = new FrVehiculos(visitante);
                        fr.ShowDialog(this);
                    }

                    Vehiculo? carro = _vehiculos.GetAll()
                        .Where(v => v.PersonaDocumento == documento)
                        .FirstOrDefault(v => !_estancias.GetActivas().Any(es => es.VehiculoPlaca == v.Id));

                    
                    Parqueadero? plaza = _asignador?.Asignar(visitante, _parqueaderos.GetAll())?.Plaza;

                    if (carro == null)
                    {
                        Mensajes.Aviso("La visita se registró, pero el vehículo no ingresó: no tiene vehículo registrado o ya está dentro.", "Visitas");
                    }
                    else if (plaza == null)
                    {
                        Mensajes.Aviso("La visita se registró, pero no hay plazas de visitante disponibles para el vehículo.", "Visitas");
                    }
                    else
                    {
                        Estancia estancia = Estancia.Create();
                        estancia.VehiculoPlaca = carro.Id;
                        estancia.IdParqueadero = plaza.Id;
                        _estancias.Add(estancia);
                        _estancias.Commit();

                        try
                        {
                            plaza.VehiculoPlaca = carro.Id;
                            _parqueaderos.Update(plaza);
                            _parqueaderos.Commit();
                        }
                        catch (MySqlException)
                        {
                            _estancias.Delete(estancia.Id);
                            _estancias.Commit();
                            throw;
                        }

                        Mensajes.Aviso($"El vehículo {carro.Id} ingresó a la plaza {plaza.Codigo}.", "Visitas");
                    }
                }

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

                if (_vehiculos != null && _estancias != null && _parqueaderos != null)
                {
                    List<string> placas = _vehiculos.GetAll()
                        .Where(v => v.PersonaDocumento == visita.PersonaVisitante)
                        .Select(v => v.Id)
                        .ToList();

                    Estancia? estancia = _estancias.GetActivas().FirstOrDefault(es => placas.Contains(es.VehiculoPlaca));
                    if (estancia != null)
                    {
                        estancia.FechaSalida = DateTime.Now;
                        _estancias.Update(estancia);
                        _estancias.Commit();

                        Parqueadero? plaza = _parqueaderos.GetById(estancia.IdParqueadero);
                        if (plaza != null)
                        {
                            try
                            {
                                plaza.VehiculoPlaca = "";
                                _parqueaderos.Update(plaza);
                                _parqueaderos.Commit();
                            }
                            catch (MySqlException)
                            {
                                estancia.FechaSalida = null;
                                _estancias.Update(estancia);
                                _estancias.Commit();
                                throw;
                            }
                        }
                    }
                }

                CargarVisitas();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo registrar la salida:", ex, "Visitas");
                CargarVisitas();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (_personas == null) return;

            string documento = txtDocumento.Text.Trim();
            if (documento == "") return;

            if (_personas.GetById(documento) is not Visitante visitante) return;

            MostrarVisitante(visitante);
        }

        private void Limpiar()
        {
            _idVisitaSeleccionada = null;
            cmbTipoDocumento.SelectedIndex = -1;
            FormHelper.LimpiarCampos(txtDocumento, txtNombre, txtApellido, txtTelefono);
            chkMovilidad.Checked = false;
            cmbResidente.SelectedIndex = -1;
            rbAPie.Checked = true;
            dgvVisitas.ClearSelection();
            txtDocumento.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

       
       
    }
}
