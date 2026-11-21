namespace ParkFlow.Logica
{
    internal class MinHeap<T>
    {
        private T[] _valores;
        private double[] _prioridades;
        private int _count;

        public MinHeap(int capacidadInicial = 16)
        {
            if (capacidadInicial < 1) capacidadInicial = 1;
            _valores = new T[capacidadInicial];
            _prioridades = new double[capacidadInicial];
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public bool EstaVacia
        {
            get { return _count == 0; }
        }

        public void Insertar(T valor, double prioridad)
        {
            if (_count == _valores.Length)
            {
                Crecer();
            }

            _valores[_count] = valor;
            _prioridades[_count] = prioridad;
            int i = _count;
            _count++;

            while (i > 0)
            {
                int padre = (i - 1) / 2;
                if (_prioridades[padre] <= _prioridades[i]) break;
                Intercambiar(i, padre);
                i = padre;
            }
        }

        public (T Valor, double Prioridad) VerMinimo()
        {
            if (EstaVacia) throw new InvalidOperationException("La cola de prioridad está vacía.");
            return (_valores[0], _prioridades[0]);
        }

        public (T Valor, double Prioridad) ExtraerMinimo()
        {
            if (EstaVacia) throw new InvalidOperationException("La cola de prioridad está vacía.");

            (T Valor, double Prioridad) minimo = (_valores[0], _prioridades[0]);

            _count--;
            _valores[0] = _valores[_count];
            _prioridades[0] = _prioridades[_count];
            _valores[_count] = default!;

            int i = 0;
            while (true)
            {
                int izquierdo = 2 * i + 1;
                int derecho = izquierdo + 1;
                int menor = i;

                if (izquierdo < _count && _prioridades[izquierdo] < _prioridades[menor]) menor = izquierdo;
                if (derecho < _count && _prioridades[derecho] < _prioridades[menor]) menor = derecho;
                if (menor == i) break;

                Intercambiar(i, menor);
                i = menor;
            }

            return minimo;
        }

        private void Intercambiar(int a, int b)
        {
            (_valores[a], _valores[b]) = (_valores[b], _valores[a]);
            (_prioridades[a], _prioridades[b]) = (_prioridades[b], _prioridades[a]);
        }

        private void Crecer()
        {
            int nuevaCapacidad = _valores.Length * 2;
            T[] valores = new T[nuevaCapacidad];
            double[] prioridades = new double[nuevaCapacidad];
            Array.Copy(_valores, valores, _count);
            Array.Copy(_prioridades, prioridades, _count);
            _valores = valores;
            _prioridades = prioridades;
        }
    }
}
