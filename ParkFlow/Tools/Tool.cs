using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Tools
{
    internal class Tool
    {
        public static void openForm<TForm>(Form parent) where TForm : Form, new()
        {
            TForm? form = Application.OpenForms.OfType<TForm>().FirstOrDefault();

            if (form == null || form.IsDisposed)
            {
                form = new TForm();
                form.MdiParent = parent;
                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }
    }
}
