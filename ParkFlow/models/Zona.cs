using ParkFlow.Contracts;
using ParkFlow.Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Zona : IEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }

        // Vértices del borde de la zona, en orden (tabla zona_vertice)
        public List<Punto> Vertices { get; set; }

        private Zona()
        {
            Id = 0;
            Nombre = string.Empty;
            Ancho = 0;
            Largo = 0;
            Vertices = new List<Punto>();
        }

        public static Zona Create()
        {
            return new Zona();
        }

        // Integral doble de la zona rectangular: ancho × largo
        public double Area
        {
            get { return Geometria.AreaRectangulo(Ancho, Largo); }
        }

        public bool TieneVertices
        {
            get { return Vertices.Count >= 3; }
        }

        // Si la zona tiene vértices se usa el teorema de Green; si no, ancho × largo
        public double AreaReal
        {
            get { return TieneVertices ? Geometria.AreaPoligono(Vertices) : Area; }
        }

        public int CapacidadEstimada
        {
            get { return Geometria.Capacidad(AreaReal); }
        }
    }
}
