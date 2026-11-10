namespace ParkFlow.Tools
{
    internal static class Mensajes
    {
        public static void Aviso(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string texto, Exception ex, string titulo)
        {
            MessageBox.Show($"{texto}\n{ex.Message}", titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string texto, string titulo)
        {
            return MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
