using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.models
{
    internal class Usuario : IEntity<int>
    {
        public int Id { get; set; }
        public string PersonaDocumento { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }
        private Usuario()
        {
            Id = 0;
            PersonaDocumento = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            Rol = RolUsuario.Portero;
        }

        public static Usuario Create()
        {
            return new Usuario();
        }

    }
}
