using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.Persistence;
using ParkFlow.Tools;
using ParkFlow.models;
using System.Drawing.Drawing2D;

namespace ParkFlow.Presentacion
{
    internal partial class FrMapa : Form
    {
        // Medidas reales de una plaza de carro, en metros
        private const double AnchoPlaza = 2.5;
        private const double LargoPlaza = 5.0;

        private RepositoryParqueaderos? _parqueaderos;
        private RepositoryZonas? _zonas;
        private RepositoryPersonas? _personas;

        private readonly List<(RectangleF Area, Parqueadero Plaza)> _dibujadas = new List<(RectangleF, Parqueadero)>();
        private Parqueadero? _seleccionada;
        private bool _datosCargados;

        public FrMapa()
        {
            InitializeComponent();
        }

        private async void FrMapa_Load(object sender, EventArgs e)
        {
            lblResumen.Text = "Cargando plazas...";
            UseWaitCursor = true;

            try
            {
                // La lectura de la base se hace en segundo plano para no congelar la pantalla
                await Task.Run(() =>
                {
                    _parqueaderos = RepositoryParqueaderos.GetInstance(new ParqueaderoSqlStore());
                    _zonas = RepositoryZonas.GetInstance(new ZonasSqlStore());
                    _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                });

                _datosCargados = true;
                Actualizar();
            }
            catch (MySqlException ex)
            {
                lblResumen.Text = "No se pudieron cargar las plazas.";
                Mensajes.Error("No se pudieron cargar las plazas:", ex, "Mapa de plazas");
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        // Al volver desde Portería o Visitas se ve qué plazas se ocuparon o liberaron
        private void FrMapa_Activated(object sender, EventArgs e)
        {
            if (_datosCargados) Actualizar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_datosCargados) Actualizar();
        }

        private void Actualizar()
        {
            if (_parqueaderos == null) return;

            List<Parqueadero> plazas = _parqueaderos.GetAll().ToList();
            int libres = plazas.Count(p => p.Libre);
            int ocupadas = plazas.Count - libres;
            double porcentaje = plazas.Count == 0 ? 0 : ocupadas * 100.0 / plazas.Count;

            lblResumen.Text = $"Libres: {libres}     Ocupadas: {ocupadas}     Ocupación: {porcentaje:0} %";

            if (_seleccionada != null)
            {
                _seleccionada = plazas.FirstOrDefault(p => p.Id == _seleccionada.Id);
                MostrarDetalle();
            }
            pbMapa.Invalidate();
        }

        private void pbMapa_Resize(object sender, EventArgs e)
        {
            pbMapa.Invalidate();
        }

        private void pbMapa_MouseClick(object sender, MouseEventArgs e)
        {
            _seleccionada = null;
            foreach ((RectangleF area, Parqueadero plaza) in _dibujadas)
            {
                if (area.Contains(e.Location))
                {
                    _seleccionada = plaza;
                    break;
                }
            }
            MostrarDetalle();
            pbMapa.Invalidate();
        }

        private void MostrarDetalle()
        {
            if (_seleccionada == null)
            {
                lblDetalle.Text = "Haga clic en una plaza para ver su detalle.";
                return;
            }

            Parqueadero p = _seleccionada;
            string estado = p.Libre ? "Libre" : $"Ocupada por {p.VehiculoPlaca}";
            string zona = _zonas?.GetById(p.IdZona)?.Nombre ?? "";
            string detalle = $"{p.Codigo}   ·   {zona}   ·   {NombreTipo(p.Tipo)}   ·   {estado}";

            if (!string.IsNullOrEmpty(p.PersonaDocumento))
            {
                Persona? dueno = _personas?.GetById(p.PersonaDocumento);
                string nombre = dueno == null ? p.PersonaDocumento : $"{dueno.Nombre} {dueno.Apellido}";
                detalle += $"   ·   Plaza fija de {nombre}";
            }
            lblDetalle.Text = detalle;
        }

        private static string NombreTipo(string tipo)
        {
            switch (tipo)
            {
                case "RESIDENTE": return "Residente";
                case "VISITANTE": return "Visitante";
                case "MOVILIDAD_REDUCIDA": return "Movilidad reducida";
                default: return tipo;
            }
        }

        // Nombre corto para que quepa dentro de la plaza dibujada
        private static string NombreCorto(string tipo)
        {
            return tipo == "MOVILIDAD_REDUCIDA" ? "Mov. red." : NombreTipo(tipo);
        }

        // Dibuja cada plaza en su posición (coord_x, coord_y) con su tamaño real de 2,5 m × 5 m
        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            _dibujadas.Clear();

            List<Parqueadero> plazas = _parqueaderos?.GetAll().ToList() ?? new List<Parqueadero>();
            if (plazas.Count == 0)
            {
                g.DrawString("No hay plazas registradas.", Font, Brushes.DimGray, 12, 12);
                return;
            }

            const double bordeZona = 1.0;   // metros de margen alrededor de cada zona
            const int margen = 40;
            const int altoLeyenda = 34;

            double minX = plazas.Min(p => p.CoordX) - AnchoPlaza / 2 - bordeZona;
            double maxX = plazas.Max(p => p.CoordX) + AnchoPlaza / 2 + bordeZona;
            double minY = plazas.Min(p => p.CoordY) - LargoPlaza / 2 - bordeZona;
            double maxY = plazas.Max(p => p.CoordY) + LargoPlaza / 2 + bordeZona;

            int ancho = pbMapa.ClientSize.Width;
            int alto = pbMapa.ClientSize.Height;
            double escala = Math.Min((ancho - 2 * margen) / (maxX - minX),
                                     (alto - 2 * margen - altoLeyenda) / (maxY - minY));
            if (escala <= 0) return;

            double sobranteX = (ancho - 2 * margen - (maxX - minX) * escala) / 2;
            double sobranteY = (alto - 2 * margen - altoLeyenda - (maxY - minY) * escala) / 2;

            // En el plano y crece hacia arriba; en la pantalla crece hacia abajo
            RectangleF APantalla(double x1, double y1, double x2, double y2)
            {
                float izquierda = (float)(margen + sobranteX + (x1 - minX) * escala);
                float arriba = (float)(altoLeyenda + margen + sobranteY + (maxY - y2) * escala);
                return new RectangleF(izquierda, arriba, (float)((x2 - x1) * escala), (float)((y2 - y1) * escala));
            }

            using Font fuenteZona = new Font("Segoe UI", 10F, FontStyle.Bold);
            using Font fuenteCodigo = new Font("Segoe UI", 10F, FontStyle.Bold);
            using Font fuenteTexto = new Font("Segoe UI", 8F);
            using Pen lapizZona = new Pen(Color.FromArgb(170, 170, 170), 1.5F) { DashStyle = DashStyle.Dash };
            using Pen lapizSeleccion = new Pen(Color.FromArgb(30, 90, 200), 4);
            using SolidBrush brochaLibre = new SolidBrush(Color.FromArgb(120, 200, 140));
            using SolidBrush brochaOcupada = new SolidBrush(Color.FromArgb(230, 120, 110));
            using SolidBrush brochaMovilidad = new SolidBrush(Color.FromArgb(40, 90, 170));
            using StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center };

            // Zonas: un recuadro punteado alrededor de sus plazas, con el nombre encima
            foreach (IGrouping<int, Parqueadero> grupo in plazas.GroupBy(p => p.IdZona))
            {
                RectangleF r = APantalla(
                    grupo.Min(p => p.CoordX) - AnchoPlaza / 2 - bordeZona / 2,
                    grupo.Min(p => p.CoordY) - LargoPlaza / 2 - bordeZona / 2,
                    grupo.Max(p => p.CoordX) + AnchoPlaza / 2 + bordeZona / 2,
                    grupo.Max(p => p.CoordY) + LargoPlaza / 2 + bordeZona / 2);
                g.DrawRectangle(lapizZona, r.X, r.Y, r.Width, r.Height);

                string nombreZona = _zonas?.GetById(grupo.Key)?.Nombre ?? $"Zona {grupo.Key}";
                g.DrawString(nombreZona, fuenteZona, Brushes.DimGray, r.X, r.Y - 22);
            }

            // Plazas
            foreach (Parqueadero p in plazas)
            {
                RectangleF r = APantalla(p.CoordX - AnchoPlaza / 2, p.CoordY - LargoPlaza / 2,
                                         p.CoordX + AnchoPlaza / 2, p.CoordY + LargoPlaza / 2);
                _dibujadas.Add((r, p));

                g.FillRectangle(p.Libre ? brochaLibre : brochaOcupada, r);
                g.DrawRectangle(Pens.DimGray, r.X, r.Y, r.Width, r.Height);

                // Franja azul arriba para las plazas de movilidad reducida
                if (p.Tipo == "MOVILIDAD_REDUCIDA")
                {
                    g.FillRectangle(brochaMovilidad, r.X + 1, r.Y + 1, r.Width - 1, Math.Min(10, r.Height / 6));
                }

                float centroX = r.X + r.Width / 2;
                float y = r.Y + r.Height / 2 - 26;
                g.DrawString(p.Codigo, fuenteCodigo, Brushes.Black, centroX, y, centrado);
                g.DrawString(NombreCorto(p.Tipo), fuenteTexto, Brushes.Black, centroX, y + 20, centrado);
                g.DrawString(p.Libre ? "Libre" : p.VehiculoPlaca, fuenteTexto, Brushes.Black, centroX, y + 36, centrado);

                if (_seleccionada != null && _seleccionada.Id == p.Id)
                {
                    g.DrawRectangle(lapizSeleccion, r.X - 2, r.Y - 2, r.Width + 4, r.Height + 4);
                }
            }

            DibujarLeyenda(g, fuenteTexto, brochaLibre, brochaOcupada, brochaMovilidad);
        }

        private static void DibujarLeyenda(Graphics g, Font fuente, Brush libre, Brush ocupada, Brush movilidad)
        {
            float x = 12;
            const float y = 12;

            void Item(Brush color, string texto)
            {
                g.FillRectangle(color, x, y, 16, 16);
                g.DrawRectangle(Pens.DimGray, x, y, 16, 16);
                g.DrawString(texto, fuente, Brushes.Black, x + 22, y);
                x += 22 + g.MeasureString(texto, fuente).Width + 24;
            }

            Item(libre, "Libre");
            Item(ocupada, "Ocupada");
            Item(movilidad, "Movilidad reducida");
        }
    }
}
