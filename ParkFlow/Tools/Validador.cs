using System.Text.RegularExpressions;

namespace ParkFlow.Tools
{
    internal static class Validador
    {
        public static bool Requeridos(params TextBox[] campos)
        {
            return campos.All(c => !string.IsNullOrWhiteSpace(c.Text));
        }

        public static bool EsSoloNumeros(string texto)
        {
            return texto.Length > 0 && texto.All(char.IsDigit);
        }

        public static bool EsCorreo(string texto)
        {
            return Regex.IsMatch(texto, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool EsTelefono(string texto)
        {
            return EsSoloNumeros(texto) && texto.Length >= 7 && texto.Length <= 10;
        }

        public static bool EsPlacaCarro(string placa)
        {
            return Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{3}$");
        }

        public static bool EsPlacaMoto(string placa)
        {
            return Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{2}[A-Z]$");
        }
    }
}
