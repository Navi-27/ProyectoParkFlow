namespace ParkFlow
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            listaResidentesToolStripMenuItem = new ToolStripMenuItem();
            porteriaToolStripMenuItem = new ToolStripMenuItem();
            visitasToolStripMenuItem = new ToolStripMenuItem();
            mapaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { listaResidentesToolStripMenuItem, porteriaToolStripMenuItem, visitasToolStripMenuItem, mapaToolStripMenuItem, cerrarSesionToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 34);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // listaResidentesToolStripMenuItem
            // 
            listaResidentesToolStripMenuItem.Name = "listaResidentesToolStripMenuItem";
            listaResidentesToolStripMenuItem.Size = new Size(128, 28);
            listaResidentesToolStripMenuItem.Text = "Lista Residentes";
            listaResidentesToolStripMenuItem.Click += listaResidentesToolStripMenuItem_Click;
            // 
            // porteriaToolStripMenuItem
            // 
            porteriaToolStripMenuItem.Name = "porteriaToolStripMenuItem";
            porteriaToolStripMenuItem.Size = new Size(74, 28);
            porteriaToolStripMenuItem.Text = "Portería";
            porteriaToolStripMenuItem.Click += porteriaToolStripMenuItem_Click;
            // 
            // visitasToolStripMenuItem
            // 
            visitasToolStripMenuItem.Name = "visitasToolStripMenuItem";
            visitasToolStripMenuItem.Size = new Size(65, 28);
            visitasToolStripMenuItem.Text = "Visitas";
            visitasToolStripMenuItem.Click += visitasToolStripMenuItem_Click;
            // 
            // mapaToolStripMenuItem
            // 
            mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            mapaToolStripMenuItem.Size = new Size(128, 28);
            mapaToolStripMenuItem.Text = "Mapa de plazas";
            mapaToolStripMenuItem.Click += mapaToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            cerrarSesionToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cerrarSesionToolStripMenuItem.Image = Properties.Resources.apagar;
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(38, 28);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesionToolStripMenuItem.ToolTipText = "Cerrar sesión";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(82, 28);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem listaResidentesToolStripMenuItem;
        private ToolStripMenuItem porteriaToolStripMenuItem;
        private ToolStripMenuItem visitasToolStripMenuItem;
        private ToolStripMenuItem mapaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
    }
}
