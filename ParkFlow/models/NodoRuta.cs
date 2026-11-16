using ParkFlow.Contracts;
using ParkFlow.Logica;

namespace ParkFlow.models
{
    // Un punto del recorrido: entrada, salida, cruce de pasillos o una plaza
    internal class NodoRuta : IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }      // ENTRADA, SALIDA, CRUCE, RAMPA o PLAZA
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public int? IdParqueo { get; set; }   // solo si el nodo es una plaza

        private NodoRuta()
        {
            Id = 0;
            Nombre = string.Empty;
            Tipo = "CRUCE";
            CoordX = 0;
            CoordY = 0;
            IdParqueo = null;
        }

        public static NodoRuta Create()
        {
            return new NodoRuta();
        }

        public Punto Posicion
        {
            get { return new Punto(CoordX, CoordY); }
        }

        public bool EsPlaza
        {
            get { return IdParqueo.HasValue; }
        }
    }
}
