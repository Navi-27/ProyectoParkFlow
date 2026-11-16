using ParkFlow.Contracts;

namespace ParkFlow.models
{
    // Un tramo de pasillo que une dos nodos del recorrido
    internal class AristaRuta : IEntity<int>
    {
        public int Id { get; set; }
        public int NodoOrigen { get; set; }
        public int NodoDestino { get; set; }

        // Lo que hay guardado en la base. El programa no lo usa para las rutas:
        // el peso se calcula en C# con Geometria.Distancia() a partir de las coordenadas.
        public double Distancia { get; set; }
        public bool Bidireccional { get; set; }

        private AristaRuta()
        {
            Id = 0;
            NodoOrigen = 0;
            NodoDestino = 0;
            Distancia = 0;
            Bidireccional = true;
        }

        public static AristaRuta Create()
        {
            return new AristaRuta();
        }
    }
}
