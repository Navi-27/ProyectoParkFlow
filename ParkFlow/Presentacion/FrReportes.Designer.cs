namespace ParkFlow.Presentacion
{
    partial class FrReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlIzquierda = new Panel();
            lstReportes = new ListBox();
            lblReportes = new Label();
            pnlDerecha = new Panel();
            dgvReporte = new DataGridView();
            flpTarjetas = new FlowLayoutPanel();
            pnlTarjeta1 = new Panel();
            lblValor1 = new Label();
            lblTitulo1 = new Label();
            pnlTarjeta2 = new Panel();
            lblValor2 = new Label();
            lblTitulo2 = new Label();
            pnlTarjeta3 = new Panel();
            lblValor3 = new Label();
            lblTitulo3 = new Label();
            pnlTarjeta4 = new Panel();
            lblValor4 = new Label();
            lblTitulo4 = new Label();
            pnlFiltros = new Panel();
            btnGenerar = new Button();
            pnlIzquierda.SuspendLayout();
            pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            flpTarjetas.SuspendLayout();
            pnlTarjeta1.SuspendLayout();
            pnlTarjeta2.SuspendLayout();
            pnlTarjeta3.SuspendLayout();
            pnlTarjeta4.SuspendLayout();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIzquierda
            // 
            pnlIzquierda.Controls.Add(lstReportes);
            pnlIzquierda.Controls.Add(lblReportes);
            pnlIzquierda.Dock = DockStyle.Left;
            pnlIzquierda.Location = new Point(0, 0);
            pnlIzquierda.Name = "pnlIzquierda";
            pnlIzquierda.Padding = new Padding(8);
            pnlIzquierda.Size = new Size(222, 553);
            pnlIzquierda.TabIndex = 0;
            // 
            // lstReportes
            // 
            lstReportes.BorderStyle = BorderStyle.None;
            lstReportes.Dock = DockStyle.Fill;
            lstReportes.Font = new Font("Segoe UI", 10F);
            lstReportes.FormattingEnabled = true;
            lstReportes.IntegralHeight = false;
            lstReportes.Items.AddRange(new object[] { "Ocupación de plazas", "Vehículos", "Movimientos de portería", "Visitas", "Residentes", "Indicadores" });
            lstReportes.Location = new Point(8, 36);
            lstReportes.Name = "lstReportes";
            lstReportes.Size = new Size(206, 509);
            lstReportes.TabIndex = 1;
            lstReportes.MouseClick += lstReportes_MouseClick;
            // 
            // lblReportes
            // 
            lblReportes.Dock = DockStyle.Top;
            lblReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReportes.Location = new Point(8, 8);
            lblReportes.Name = "lblReportes";
            lblReportes.Size = new Size(206, 28);
            lblReportes.TabIndex = 0;
            lblReportes.Text = "Reportes";
            // 
            // pnlDerecha
            // 
            pnlDerecha.Controls.Add(dgvReporte);
            pnlDerecha.Controls.Add(flpTarjetas);
            pnlDerecha.Controls.Add(pnlFiltros);
            pnlDerecha.Dock = DockStyle.Fill;
            pnlDerecha.Location = new Point(222, 0);
            pnlDerecha.Name = "pnlDerecha";
            pnlDerecha.Padding = new Padding(0, 0, 10, 10);
            pnlDerecha.Size = new Size(910, 553);
            pnlDerecha.TabIndex = 1;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.Location = new Point(0, 136);
            dgvReporte.MultiSelect = false;
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(900, 407);
            dgvReporte.TabIndex = 2;
            // 
            // flpTarjetas
            // 
            flpTarjetas.Controls.Add(pnlTarjeta1);
            flpTarjetas.Controls.Add(pnlTarjeta2);
            flpTarjetas.Controls.Add(pnlTarjeta3);
            flpTarjetas.Controls.Add(pnlTarjeta4);
            flpTarjetas.Dock = DockStyle.Top;
            flpTarjetas.Location = new Point(0, 44);
            flpTarjetas.Name = "flpTarjetas";
            flpTarjetas.Size = new Size(900, 92);
            flpTarjetas.TabIndex = 1;
            // 
            // pnlTarjeta1
            // 
            pnlTarjeta1.BackColor = Color.White;
            pnlTarjeta1.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjeta1.Controls.Add(lblValor1);
            pnlTarjeta1.Controls.Add(lblTitulo1);
            pnlTarjeta1.Location = new Point(6, 6);
            pnlTarjeta1.Margin = new Padding(6);
            pnlTarjeta1.Name = "pnlTarjeta1";
            pnlTarjeta1.Size = new Size(205, 78);
            pnlTarjeta1.TabIndex = 0;
            // 
            // lblValor1
            // 
            lblValor1.AutoSize = true;
            lblValor1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblValor1.ForeColor = Color.FromArgb(31, 58, 95);
            lblValor1.Location = new Point(10, 28);
            lblValor1.Name = "lblValor1";
            lblValor1.Size = new Size(35, 41);
            lblValor1.TabIndex = 1;
            lblValor1.Text = "0";
            // 
            // lblTitulo1
            // 
            lblTitulo1.AutoSize = true;
            lblTitulo1.ForeColor = Color.DimGray;
            lblTitulo1.Location = new Point(10, 6);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new Size(47, 20);
            lblTitulo1.TabIndex = 0;
            lblTitulo1.Text = "Título";
            // 
            // pnlTarjeta2
            // 
            pnlTarjeta2.BackColor = Color.White;
            pnlTarjeta2.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjeta2.Controls.Add(lblValor2);
            pnlTarjeta2.Controls.Add(lblTitulo2);
            pnlTarjeta2.Location = new Point(223, 6);
            pnlTarjeta2.Margin = new Padding(6);
            pnlTarjeta2.Name = "pnlTarjeta2";
            pnlTarjeta2.Size = new Size(205, 78);
            pnlTarjeta2.TabIndex = 1;
            // 
            // lblValor2
            // 
            lblValor2.AutoSize = true;
            lblValor2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblValor2.ForeColor = Color.FromArgb(192, 80, 0);
            lblValor2.Location = new Point(10, 28);
            lblValor2.Name = "lblValor2";
            lblValor2.Size = new Size(35, 41);
            lblValor2.TabIndex = 1;
            lblValor2.Text = "0";
            // 
            // lblTitulo2
            // 
            lblTitulo2.AutoSize = true;
            lblTitulo2.ForeColor = Color.DimGray;
            lblTitulo2.Location = new Point(10, 6);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(47, 20);
            lblTitulo2.TabIndex = 0;
            lblTitulo2.Text = "Título";
            // 
            // pnlTarjeta3
            // 
            pnlTarjeta3.BackColor = Color.White;
            pnlTarjeta3.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjeta3.Controls.Add(lblValor3);
            pnlTarjeta3.Controls.Add(lblTitulo3);
            pnlTarjeta3.Location = new Point(440, 6);
            pnlTarjeta3.Margin = new Padding(6);
            pnlTarjeta3.Name = "pnlTarjeta3";
            pnlTarjeta3.Size = new Size(205, 78);
            pnlTarjeta3.TabIndex = 2;
            // 
            // lblValor3
            // 
            lblValor3.AutoSize = true;
            lblValor3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblValor3.ForeColor = Color.FromArgb(46, 125, 50);
            lblValor3.Location = new Point(10, 28);
            lblValor3.Name = "lblValor3";
            lblValor3.Size = new Size(35, 41);
            lblValor3.TabIndex = 1;
            lblValor3.Text = "0";
            // 
            // lblTitulo3
            // 
            lblTitulo3.AutoSize = true;
            lblTitulo3.ForeColor = Color.DimGray;
            lblTitulo3.Location = new Point(10, 6);
            lblTitulo3.Name = "lblTitulo3";
            lblTitulo3.Size = new Size(47, 20);
            lblTitulo3.TabIndex = 0;
            lblTitulo3.Text = "Título";
            // 
            // pnlTarjeta4
            // 
            pnlTarjeta4.BackColor = Color.White;
            pnlTarjeta4.BorderStyle = BorderStyle.FixedSingle;
            pnlTarjeta4.Controls.Add(lblValor4);
            pnlTarjeta4.Controls.Add(lblTitulo4);
            pnlTarjeta4.Location = new Point(657, 6);
            pnlTarjeta4.Margin = new Padding(6);
            pnlTarjeta4.Name = "pnlTarjeta4";
            pnlTarjeta4.Size = new Size(205, 78);
            pnlTarjeta4.TabIndex = 3;
            // 
            // lblValor4
            // 
            lblValor4.AutoSize = true;
            lblValor4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblValor4.ForeColor = Color.FromArgb(94, 53, 177);
            lblValor4.Location = new Point(10, 28);
            lblValor4.Name = "lblValor4";
            lblValor4.Size = new Size(35, 41);
            lblValor4.TabIndex = 1;
            lblValor4.Text = "0";
            // 
            // lblTitulo4
            // 
            lblTitulo4.AutoSize = true;
            lblTitulo4.ForeColor = Color.DimGray;
            lblTitulo4.Location = new Point(10, 6);
            lblTitulo4.Name = "lblTitulo4";
            lblTitulo4.Size = new Size(47, 20);
            lblTitulo4.TabIndex = 0;
            lblTitulo4.Text = "Título";
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(btnGenerar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(900, 44);
            pnlFiltros.TabIndex = 0;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(6, 7);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(100, 30);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // FrReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 553);
            Controls.Add(pnlDerecha);
            Controls.Add(pnlIzquierda);
            Name = "FrReportes";
            Text = "Reportes";
            Load += FrReportes_Load;
            pnlIzquierda.ResumeLayout(false);
            pnlDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            flpTarjetas.ResumeLayout(false);
            pnlTarjeta1.ResumeLayout(false);
            pnlTarjeta1.PerformLayout();
            pnlTarjeta2.ResumeLayout(false);
            pnlTarjeta2.PerformLayout();
            pnlTarjeta3.ResumeLayout(false);
            pnlTarjeta3.PerformLayout();
            pnlTarjeta4.ResumeLayout(false);
            pnlTarjeta4.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIzquierda;
        private ListBox lstReportes;
        private Label lblReportes;
        private Panel pnlDerecha;
        private DataGridView dgvReporte;
        private FlowLayoutPanel flpTarjetas;
        private Panel pnlTarjeta1;
        private Label lblValor1;
        private Label lblTitulo1;
        private Panel pnlTarjeta2;
        private Label lblValor2;
        private Label lblTitulo2;
        private Panel pnlTarjeta3;
        private Label lblValor3;
        private Label lblTitulo3;
        private Panel pnlTarjeta4;
        private Label lblValor4;
        private Label lblTitulo4;
        private Panel pnlFiltros;
        private Button btnGenerar;
    }
}
