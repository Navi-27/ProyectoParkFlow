using ParkFlow.models;

namespace ParkFlow.Logica
{ 
    internal class AsignadorPlazas
    {
        private readonly Grafo _grafo = new Grafo();
        private readonly Dictionary<int, NodoRuta> _nodos = new Dictionary<int, NodoRuta>();
        private readonly Dictionary<int, NodoRuta> _nodoPorPlaza = new Dictionary<int, NodoRuta>();
        private readonly List<Tramo> _tramos = new List<Tramo>();
        private readonly ResultadoDijkstra? _rutas;

        public NodoRuta? Entrada { get; }

        public AsignadorPlazas(IEnumerable<NodoRuta> nodos, IEnumerable<AristaRuta> aristas)
        {
            foreach (NodoRuta nodo in nodos)
            {
                _nodos[nodo.Id] = nodo;
                _grafo.AgregarNodo(nodo.Id);
                if (nodo.IdParqueo.HasValue)
                {
                    _nodoPorPlaza[nodo.IdParqueo.Value] = nodo;
                }
            }

            foreach (AristaRuta arista in aristas)
            {
                if (!_nodos.TryGetValue(arista.NodoOrigen, out NodoRuta? origen)) continue;
                if (!_nodos.TryGetValue(arista.NodoDestino, out NodoRuta? destino)) continue;

                double peso = Geometria.Distancia(origen.Posicion, destino.Posicion);
                _grafo.AgregarArista(origen.Id, destino.Id, peso, arista.Bidireccional);
                _tramos.Add(new Tramo(origen, destino, peso, arista.Distancia));
            }

            Entrada = _nodos.Values.FirstOrDefault(n => n.Tipo == "ENTRADA");
            if (Entrada != null)
            {
                _rutas = Dijkstra.Calcular(_grafo, Entrada.Id);
            }
        }

        public bool TieneGrafo
        {
            get { return _rutas != null; }
        }

        public Grafo Grafo
        {
            get { return _grafo; }
        }

        public IEnumerable<NodoRuta> Nodos
        {
            get { return _nodos.Values; }
        }

        public IEnumerable<Tramo> Tramos
        {
            get { return _tramos; }
        }

        public double DistanciaHasta(Parqueadero plaza)
        {
            if (_rutas == null || !_nodoPorPlaza.TryGetValue(plaza.Id, out NodoRuta? nodo))
            {
                return double.PositiveInfinity;
            }
            return _rutas.DistanciaA(nodo.Id);
        }

        public Asignacion RutaHasta(Parqueadero plaza)
        {
            if (_rutas == null || !_nodoPorPlaza.TryGetValue(plaza.Id, out NodoRuta? nodo) || !_rutas.EsAlcanzable(nodo.Id))
            {
                return Asignacion.SinRuta(plaza);
            }

            List<NodoRuta> ruta = _rutas.CaminoHasta(nodo.Id).Select(id => _nodos[id]).ToList();
            return new Asignacion(plaza, _rutas.DistanciaA(nodo.Id), ruta);
        }

        public Asignacion? Asignar(Persona? dueno, IEnumerable<Parqueadero> plazas)
        {
            if (dueno == null) return null;

            List<Parqueadero> libres = plazas.Where(p => p.Libre).ToList();

            Parqueadero? plaza = MasCercana(libres.Where(p => p.PersonaDocumento == dueno.Id));

            if (plaza == null && dueno.MovilidadReducida)
            {
                plaza = MasCercana(libres.Where(p => p.Tipo == "MOVILIDAD_REDUCIDA" && string.IsNullOrEmpty(p.PersonaDocumento)));
            }

            if (plaza == null)
            {
                plaza = dueno is Residente
                    ? MasCercana(libres.Where(p => p.Tipo == "RESIDENTE" && string.IsNullOrEmpty(p.PersonaDocumento)))
                    : MasCercana(libres.Where(p => p.Tipo == "VISITANTE"));
            }

            return plaza == null ? null : RutaHasta(plaza);
        }

        private Parqueadero? MasCercana(IEnumerable<Parqueadero> candidatas)
        {
            Parqueadero? mejor = null;
            double mejorDistancia = double.PositiveInfinity;

            foreach (Parqueadero p in candidatas)
            {
                double d = DistanciaHasta(p);
                if (mejor == null || d < mejorDistancia
                    || (d == mejorDistancia && string.CompareOrdinal(p.Codigo, mejor.Codigo) < 0))
                {
                    mejor = p;
                    mejorDistancia = d;
                }
            }
            return mejor;
        }
    }

    internal class Asignacion
    {
        public Parqueadero Plaza { get; }
        public double Distancia { get; }
        public List<NodoRuta> Ruta { get; }

        public Asignacion(Parqueadero plaza, double distancia, List<NodoRuta> ruta)
        {
            Plaza = plaza;
            Distancia = distancia;
            Ruta = ruta;
        }

        public static Asignacion SinRuta(Parqueadero plaza)
        {
            return new Asignacion(plaza, double.PositiveInfinity, new List<NodoRuta>());
        }

        public bool TieneRuta
        {
            get { return Ruta.Count > 0; }
        }

        public string RutaTexto
        {
            get { return TieneRuta ? string.Join(" → ", Ruta.Select(n => n.Nombre)) : "Sin ruta en el grafo"; }
        }

        public string PlazaTexto
        {
            get { return TieneRuta ? $"{Plaza.Codigo} ({Distancia:0.00} m)" : Plaza.Codigo; }
        }
    }

    internal class Tramo
    {
        public NodoRuta Origen { get; }
        public NodoRuta Destino { get; }
        public double Peso { get; }
        public double DistanciaGuardada { get; }

        public Tramo(NodoRuta origen, NodoRuta destino, double peso, double distanciaGuardada)
        {
            Origen = origen;
            Destino = destino;
            Peso = peso;
            DistanciaGuardada = distanciaGuardada;
        }
    }
}
