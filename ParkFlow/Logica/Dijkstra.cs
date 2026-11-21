namespace ParkFlow.Logica
{
    internal static class Dijkstra
    {
        public static ResultadoDijkstra Calcular(Grafo grafo, int origen)
        {
            Dictionary<int, double> distancias = new Dictionary<int, double>();
            Dictionary<int, int> previos = new Dictionary<int, int>();

            foreach (int nodo in grafo.Nodos)
            {
                distancias[nodo] = double.PositiveInfinity;
            }

            if (!grafo.ContieneNodo(origen))
            {
                return new ResultadoDijkstra(origen, distancias, previos);
            }

            distancias[origen] = 0;
            MinHeap<int> cola = new MinHeap<int>(grafo.CantidadNodos + 1);
            cola.Insertar(origen, 0);

            while (!cola.EstaVacia)
            {
                (int u, double distanciaU) = cola.ExtraerMinimo();

                if (distanciaU > distancias[u]) continue;

                foreach (AristaGrafo arista in grafo.Vecinos(u))
                {
                    double nueva = distanciaU + arista.Peso;
                    if (nueva < distancias[arista.Destino])
                    {
                        distancias[arista.Destino] = nueva;
                        previos[arista.Destino] = u;
                        cola.Insertar(arista.Destino, nueva);
                    }
                }
            }

            return new ResultadoDijkstra(origen, distancias, previos);
        }
    }

    internal class ResultadoDijkstra
    {
        private readonly Dictionary<int, double> _distancias;
        private readonly Dictionary<int, int> _previos;

        public int Origen { get; }

        public ResultadoDijkstra(int origen, Dictionary<int, double> distancias, Dictionary<int, int> previos)
        {
            Origen = origen;
            _distancias = distancias;
            _previos = previos;
        }

        public double DistanciaA(int nodo)
        {
            return _distancias.TryGetValue(nodo, out double d) ? d : double.PositiveInfinity;
        }

        public bool EsAlcanzable(int nodo)
        {
            return !double.IsPositiveInfinity(DistanciaA(nodo));
        }

        public List<int> CaminoHasta(int destino)
        {
            List<int> camino = new List<int>();
            if (!EsAlcanzable(destino)) return camino;

            Stack<int> pila = new Stack<int>();
            int actual = destino;
            pila.Push(actual);
            while (actual != Origen)
            {
                actual = _previos[actual];
                pila.Push(actual);
            }

            while (pila.Count > 0)
            {
                camino.Add(pila.Pop());
            }
            return camino;
        }
    }
}
