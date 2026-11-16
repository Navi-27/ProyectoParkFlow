using ParkFlow.DynamicStructure;

namespace ParkFlow.Logica
{
    // Un tramo que sale de un nodo: a dónde llega y cuánto mide
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

    // Grafo del parqueadero como lista de adyacencia.
    // Cada nodo guarda sus vecinos en una Lista<T> propia (lista doblemente enlazada).
    // Memoria: O(V + E). Una matriz de adyacencia ocuparía O(V²) y estaría casi vacía.
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

        // O(1)
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

        // O(1): se agrega al final de la lista enlazada de cada nodo
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

        // O(grado del nodo)
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
