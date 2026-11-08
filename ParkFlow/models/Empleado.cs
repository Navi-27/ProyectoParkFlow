using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Empleado : Persona
    {
        private Empleado() { }

        public static Empleado Create()
        {
            return new Empleado();
        }

        public override int Prioridad
        {
            get { return MovilidadReducida ? 0 : 1; }
        }
    }
}
