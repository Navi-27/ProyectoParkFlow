using System.Security.Cryptography;
using System.Text;

namespace ParkFlow.Tools
{
    internal static class Seguridad
    {
        public static string HashPassword(string clave)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(clave));
            return Convert.ToHexString(bytes);
        }
    }
}
