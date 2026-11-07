using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Estancia : IEntity<int>
    {
        public int Id { get; set; }
        public string VehiculoPlaca { get; set; }
        // Plaza ocupada (obligatoria: la estancia se crea cuando el vehículo ya tiene plaza)
        public int IdParqueadero { get; set; }
        // Hora en que ocupa la plaza
        public DateTime FechaLlegada { get; set; }
        public DateTime? FechaSalida { get; set; }

        public bool Activa
        {
            get { return FechaSalida == null; }
        }

        // Tiempo que lleva (o duró) ocupando la plaza; si no ha salido, se mide hasta ahora
        public TimeSpan TiempoOcupado
        {
            get { return (FechaSalida ?? DateTime.Now) - FechaLlegada; }
        }

        private Estancia()
        {
            Id = 0;
            VehiculoPlaca = string.Empty;
            FechaLlegada = DateTime.Now;
        
        }

        public static Estancia Create()
        {
            return new Estancia();
        }

        
                                                    
    }

}
