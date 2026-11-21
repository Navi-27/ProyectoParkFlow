using ParkFlow.DynamicStructure;

namespace ParkFlow.Logica
{
    internal class AristaGrafo
    {
        public int Destino { get; }
        public double Peso { get; }

        public AristaGrafo(int destino, double peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }

    internal class Grafo
    {
        private readonly Dictionary<int, Lista<AristaGrafo>> _adyacencia = new Dictionary<int, Lista<AristaGrafo>>();

        public int CantidadNodos
        {
            get { return _adyacencia.Count; }
        }

        public int CantidadAristas { get; private set; }

        public IEnumerable<int> Nodos
        {
            get { return _adyacencia.Keys; }
        }

        public void AgregarNodo(int id)
        {
            if (!_adyacencia.ContainsKey(id))
            {
                _adyacencia[id] = new Lista<AristaGrafo>();
            }
        }

        public bool ContieneNodo(int id)
        {
            return _adyacencia.ContainsKey(id);
        }

        public void AgregarArista(int origen, int destino, double peso, bool bidireccional = true)
        {
            if (peso < 0)
            {
                throw new ArgumentException("Dijkstra no admite distancias negativas.", nameof(peso));
            }

            AgregarNodo(origen);
            AgregarNodo(destino);

            _adyacencia[origen].Add(new AristaGrafo(destino, peso));
            if (bidireccional)
            {
                _adyacencia[destino].Add(new AristaGrafo(origen, peso));
            }
            CantidadAristas++;
        }

        public IEnumerable<AristaGrafo> Vecinos(int id)
        {
            if (_adyacencia.TryGetValue(id, out Lista<AristaGrafo>? vecinos))
            {
                return vecinos;
            }
            return Enumerable.Empty<AristaGrafo>();
        }
    }
}
