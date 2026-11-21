namespace ParkFlow.Tools
{
    internal static class FormHelper
    {
        public static void OpenForm<TForm>(Form parent) where TForm : Form, new()
        {
            TForm? form = Application.OpenForms.OfType<TForm>().FirstOrDefault();

            if (form == null || form.IsDisposed)
            {
                form = new TForm();
                form.MdiParent = parent;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
                form.BringToFront();
            }
        }

        public static void LimpiarCampos(params TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                campo.Clear();
            }
        }

        public static void SeleccionarTipoDocumento(ComboBox combo, string tipo)
        {
            combo.SelectedIndex = -1;
            foreach (object item in combo.Items)
            {
                if (item.ToString()!.StartsWith(tipo + " "))
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }
        
    }
}
