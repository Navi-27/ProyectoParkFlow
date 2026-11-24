using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.Logica;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkFlow.Presentacion
{
    internal partial class FrReportes : Form
    {
        public FrReportes()
        {
            InitializeComponent();
        }

        private RepositoryVehiculos? _vehiculos;
        private RepositoryPersonas? _personas;
        private RepositoryEstancias? _estancias;
        private RepositoryParqueaderos? _parqueaderos;
        private RepositoryZonas? _zonas;
        private RepositoryViviendas? _casas;
        private RepositoryRegistros? _registros;

        private void FrReportes_Load(object sender, EventArgs e)
        {
            try
            {
                _vehiculos = RepositoryVehiculos.GetInstance(new VehiculosSqlStore());
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                _estancias = RepositoryEstancias.GetInstance(new EstanciaSqlStore());
                _parqueaderos = RepositoryParqueaderos.GetInstance(new ParqueaderoSqlStore());
                _zonas = RepositoryZonas.GetInstance(new ZonasSqlStore());
                _casas = RepositoryViviendas.GetInstance(new ViviendaSqlStore());
                _registros = RepositoryRegistros.GetInstance(new RegistroSqlStore());
                dgvReporte.AutoGenerateColumns = true;
            }
            catch (MySqlException ex)
            {

                Mensajes.Error("No se pudieron cargar los datos de Reporte:", ex, "Reportes");
            }
            LimpiarReporte();
        }

        private void ReporteVehiculos()
        {
            if (_vehiculos == null || _personas == null || _estancias == null || _parqueaderos == null) return;

            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _vehiculos.GetAll()
                .Select(v => new
                {
                    Placa = v.Id,
                    Tipo = v.Tipo(),
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    DocDueño = v.PersonaDocumento,
                    Dueño = _personas.GetById(v.PersonaDocumento)?.Nombre + " " + _personas.GetById(v.PersonaDocumento)?.Apellido,
                    TipoDueño = _personas.GetById(v.PersonaDocumento) is Residente ? "RESIDENTE" : "VISITANTE",
                    Estado = _estancias.GetAll().Any(e => e.VehiculoPlaca == v.Id && e.Activa) ? "DENTRO" : "FUERA",
                    Plaza = _parqueaderos.GetAll().FirstOrDefault(p => p.VehiculoPlaca == v.Id)?.Codigo ?? "SIN PLAZA",

                })
                .ToList();

            dgvReporte.Columns["TipoDueño"]?.HeaderText = "Tipo de Dueño";
            dgvReporte.Columns["DocDueño"]?.HeaderText = "Doc. Dueño";
            lblTitulo1.Text = "Total de Vehículos";
            lblTitulo2.Text = "Total de Carros";
            lblTitulo3.Text = "Total de Motos";
            lblTitulo4.Text = "Dentro ahora";
            lblValor1.Text = dgvReporte.Rows.Count.ToString();
            lblValor2.Text = _vehiculos.GetAll().Count(v => v.Tipo() == "CARRO").ToString();
            lblValor3.Text = _vehiculos.GetAll().Count(v => v.Tipo() == "MOTO").ToString();
            lblValor4.Text = _estancias.GetActivas().Count().ToString();

        }

        private void ReportePlazas()
        {
            if (_parqueaderos == null || _zonas == null) return;

            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _parqueaderos.GetAll()

                .Select(p => new
                {
                    Plaza = p.Codigo,
                    Zona = _zonas.GetById(p.IdZona)?.Nombre,
                    Tipo = p.Tipo,
                    Estado = p.Libre ? "LIBRE" : "OCUPADA",
                    Vehiculo = p.VehiculoPlaca == "" ? "VACÍA" : p.VehiculoPlaca,
                    PlazaFija = p.PersonaDocumento == "" ? "VACÍA" : p.PersonaDocumento,
                })
                .ToList();

            dgvReporte.Columns["PlazaFija"]?.HeaderText = "Plaza fija de";
            lblTitulo1.Text = "Total Plazas";
            lblTitulo2.Text = "Ocupadas";
            lblTitulo3.Text = "Libres";
            lblTitulo4.Text = "Libres Visitantes";
            lblValor1.Text = dgvReporte.Rows.Count.ToString();
            lblValor2.Text = _parqueaderos.GetAll().Count(p => !p.Libre).ToString();
            lblValor3.Text = _parqueaderos.GetAll().Count(p => p.Libre).ToString();
            lblValor4.Text = _parqueaderos.GetAll().Count(p => p.Libre && p.Tipo == "VISITANTE").ToString();
        }

        private void ReporteResidentes()
        {
            if (_personas == null || _vehiculos == null || _parqueaderos == null || _casas == null) return;

            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _personas.GetAll()
                .Where(r => r is Residente)
                .Select(r => new
                {
                    Documento = r.Id,
                    Residente = r.Nombre + " " + r.Apellido,
                    Telefono = r.Telefono,
                    Correo = r.Correo,
                    Vivienda = _casas.GetByPersona(r.Id)
                    .Select(c =>
                        $"{c.Torre}-{c.Piso}-{c.Apartamento}"
                        )?
                    .FirstOrDefault() ?? "SIN VIVIENDA",
                    CantVehiculos = _vehiculos.GetAll().Count(v => v.PersonaDocumento == r.Id),
                    PlazaFija = _parqueaderos.GetAll().FirstOrDefault(p => p.PersonaDocumento == r.Id)?.Codigo ?? "SIN PLAZA",
                    MovilidadReducida = (r.MovilidadReducida) ? "SI" : "NO"
                })
                .ToList();

            dgvReporte.Columns["PlazaFija"]?.HeaderText = "Plaza fija";
            dgvReporte.Columns["CantVehiculos"]?.HeaderText = "Cantidad de Vehiculos";
            dgvReporte.Columns["MovilidadReducida"]?.HeaderText = "Movilidad Reducida";
            lblTitulo1.Text = "Total de Residentes";
            lblTitulo2.Text = "Residentes con Vehículos";
            lblTitulo3.Text = "Residentes Plaza Fija";
            lblTitulo4.Text = "Total Movilidad Reducida";
            lblValor1.Text = dgvReporte.Rows.Count.ToString();
            lblValor2.Text = _personas.GetAll()
                            .Count(p => p is Residente && _vehiculos.GetAll().Any(v => v.PersonaDocumento == p.Id))
                            .ToString();
            lblValor3.Text = _parqueaderos.GetAll().Count(p => p.PersonaDocumento != "").ToString();
            lblValor4.Text = _personas.GetAll().Count(p => p.MovilidadReducida && p is Residente).ToString();
        }

        private void ReporteVisitas()
        {
            if (_registros == null || _casas == null || _personas == null || _vehiculos == null) return;

            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _registros.GetAll()
                .GroupBy(g => g.IdVivienda)
                .Select(g => new
                {
                    Vivienda = _casas.GetAll()
                    .Where(c => c.Id == g.Key)
                    .Select(c =>
                        $"{c.Torre}-{c.Piso}-{c.Apartamento}"
                        )?
                    .FirstOrDefault(),
                    PersonaVisitada = g.First().PersonaVisitada,
                    Visitas = g.Count(),
                    TiempoPromedio = Math.Round(g.Where(r => r.FechaSalida != null)
                                        .Select(r => r.TiempoVisita.TotalHours)
                                        .DefaultIfEmpty(0)
                                        .Average(), 1) + " horas",
                    UltimaVisita = g.Max(r => r.FechaIngreso)

                })
                .ToList();

            dgvReporte.Columns["PersonaVisitada"]?.HeaderText = "Persona Visitada";
            dgvReporte.Columns["TiempoPromedio"]?.HeaderText = "Tiempo promedio Visitas";
            lblTitulo1.Text = "Total de visitas";
            lblTitulo2.Text = "Visitas Activas";
            lblTitulo3.Text = "Visitas Hoy";
            lblTitulo4.Text = "Tiempo Promedio General";
            lblValor1.Text = _registros.GetAll().Count().ToString(); 
            lblValor2.Text = _registros.GetActivas().Count().ToString();
            lblValor3.Text = _registros.GetAll().Count(r => r.FechaIngreso.Date == DateTime.Today).ToString();
            lblValor4.Text = Math.Round(_registros.GetAll()
                                .Where(r => r.FechaSalida != null)
                                .Select(r => r.TiempoVisita.TotalHours)
                                .DefaultIfEmpty(0)
                                .Average(), 1) + " horas";
        }

        private void ReportePorteria()
        {
            if (_estancias == null || _vehiculos == null || _personas == null) return;
            dgvReporte.DataSource = null;
            dgvReporte.DataSource = _estancias.GetAll()
                .GroupBy(g => g.VehiculoPlaca)
                .Select(g => new
                {
                    Placa = g.First().VehiculoPlaca,
                    Propietario = _vehiculos.GetById(g.Key)?.PersonaDocumento,
                    VecesEntro = g.Count(),
                    TiempoTotal = Math.Round(g.Sum(e => e.TiempoOcupado.TotalHours),1) + " horas",
                    TiempoPromedio = Math.Round(g.Where(e => e.FechaSalida != null)
                                         .Select(e => e.TiempoOcupado.TotalHours)
                                         .DefaultIfEmpty(0)
                                         .Average(),1) + " horas",
                    UltimaEntrada = g.Max(e => e.FechaLlegada)

                })
                .ToList();

            dgvReporte.Columns["VecesEntro"]?.HeaderText = "Veces que Entro";
            dgvReporte.Columns["TiempoTotal"]?.HeaderText = "Tiempo Total Ocupación";
            dgvReporte.Columns["TiempoPromedio"]?.HeaderText = "Promedio Tiempo Ocupado";
            dgvReporte.Columns["UltimaEntrada"]?.HeaderText = "Ultima Entrada";
            lblTitulo1.Text = "Total Movimientos Portería";
            lblTitulo2.Text = "Entradas Hoy";
            lblTitulo3.Text = "Vehículos Dentro";
            lblTitulo4.Text = "Tiempo Promedio General";
            lblValor1.Text = _estancias.GetAll().Count().ToString();
            lblValor2.Text = _estancias.GetAll().Count(e => e.FechaLlegada.Date == DateTime.Today).ToString();
            lblValor3.Text = _estancias.GetActivas().Count().ToString();
            lblValor4.Text = Math.Round(_estancias.GetAll()
                                 .Where(e => e.FechaSalida != null)
                                 .Select(e => e.TiempoOcupado.TotalHours)
                                 .DefaultIfEmpty(0)
                                 .Average(),1) + " horas";


        }

        private void LimpiarReporte()
        {
            dgvReporte.DataSource = null;
            lblValor1.Text = null;
            lblValor2.Text = null;
            lblValor3.Text = null;
            lblValor4.Text = null;
            lblTitulo1.Text = null;
            lblTitulo2.Text = null;
            lblTitulo3.Text = null;
            lblTitulo4.Text = null;

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            switch (lstReportes.Text)
            {
                case "Vehículos":
                    ReporteVehiculos();
                    break;
                case "Ocupación de plazas":
                    ReportePlazas();
                    break;
                case "Residentes":
                    ReporteResidentes();
                    break;
                case "Visitas":
                    ReporteVisitas();
                    break;
                case "Movimientos de portería":
                    ReportePorteria();
                    break; 
                default:
                    MessageBox.Show("No se puede generar el reporte debe eligir una opción ", "Reportes");
                    break;
            }
        }

        private void lstReportes_MouseClick(object sender, MouseEventArgs e)
        {
            LimpiarReporte();
        }
    }
}
