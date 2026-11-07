using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Registro : IEntity<int>
    {
        public int Id { get; set; }
        public string PersonaVisitante { get; set; }
        public string PersonaVisitada { get; set; }
        public int IdVivienda { get; set; }
        public DateTime FechaIngreso {  get; set; }
        public DateTime? FechaSalida {  get; set; }

        // Duración de la visita; si el visitante sigue adentro, se mide hasta ahora
        public TimeSpan TiempoVisita
        {
            get { return (FechaSalida ?? DateTime.Now) - FechaIngreso; }
        }

        private Registro()
        {
            Id = 0;
            PersonaVisitante = string.Empty;
            PersonaVisitada = string.Empty;
            IdVivienda = 0;
            FechaIngreso = DateTime.Now;

        }

        public static Registro Create()
        {
            return new Registro();
        }

    }
}
