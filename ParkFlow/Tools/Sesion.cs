using ParkFlow.models;

namespace ParkFlow.Tools
{
    internal static class Sesion
    {
        public static Usuario? UsuarioActual { get; set; }

        public static bool HayUsuario => UsuarioActual != null;

        public static bool EsAdmin => UsuarioActual?.Rol == RolUsuario.Admin;

        public static void Cerrar()
        {
            UsuarioActual = null;
        }
    }
}
