using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Vivienda : IEntity<int>
    {
        public int Id { get; set; }
        public string PersonaDocumento { get; set; }
        // Torre como texto: A1, A2, B1...
        public string Torre { get; set; }
        public int Piso { get; set; }
        public int Apartamento { get; set; }
        private Vivienda()
        {
            PersonaDocumento = string.Empty;
            Torre = string.Empty;
        }

        public static Vivienda Create()
        {
            return new Vivienda();
        }

        
    }
}
