namespace ParkFlow.Presentacion
{
    partial class FrPorteria
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tlpContadores = new TableLayoutPanel();
            pnlLibres = new Panel();
            lblLibres = new Label();
            lblLibresTitulo = new Label();
            pnlOcupadas = new Panel();
            lblOcupadas = new Label();
            lblOcupadasTitulo = new Label();
            pnlOcupacion = new Panel();
            lblOcupacion = new Label();
            lblOcupacionTitulo = new Label();
            gbVehiculo = new GroupBox();
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            lblPropietario = new Label();
            txtPropietario = new TextBox();
            lblPlaza = new Label();
            txtPlaza = new TextBox();
            btnRegistrarIngreso = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            btnRegistrarSalida = new Button();
            lblVehiculosDentro = new Label();
            dgvDentro = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colPlaca = new DataGridViewTextBoxColumn();
            colPropietario = new DataGridViewTextBoxColumn();
            colNombrePropietario = new DataGridViewTextBoxColumn();
            colPlaza = new DataGridViewTextBoxColumn();
            colLlegada = new DataGridViewTextBoxColumn();
            colSalida = new DataGridViewTextBoxColumn();
            colTiempo = new DataGridViewTextBoxColumn();
            tlpContadores.SuspendLayout();
            pnlLibres.SuspendLayout();
            pnlOcupadas.SuspendLayout();
            pnlOcupacion.SuspendLayout();
            gbVehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDentro).BeginInit();
            SuspendLayout();
            // 
            // tlpContadores
            // 
            tlpContadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpContadores.ColumnCount = 3;
            tlpContadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpContadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpContadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpContadores.Controls.Add(pnlLibres, 0, 0);
            tlpContadores.Controls.Add(pnlOcupadas, 1, 0);
            tlpContadores.Controls.Add(pnlOcupacion, 2, 0);
            tlpContadores.Location = new Point(12, 12);
            tlpContadores.Name = "tlpContadores";
            tlpContadores.RowCount = 1;
            tlpContadores.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpContadores.Size = new Size(1126, 72);
            tlpContadores.TabIndex = 0;
            // 
            // pnlLibres
            // 
            pnlLibres.BackColor = Color.FromArgb(240, 240, 240);
            pnlLibres.BorderStyle = BorderStyle.FixedSingle;
            pnlLibres.Controls.Add(lblLibres);
            pnlLibres.Controls.Add(lblLibresTitulo);
            pnlLibres.Dock = DockStyle.Fill;
            pnlLibres.Location = new Point(3, 3);
            pnlLibres.Name = "pnlLibres";
            pnlLibres.Size = new Size(369, 66);
            pnlLibres.TabIndex = 0;
            // 
            // lblLibres
            // 
            lblLibres.AutoSize = true;
            lblLibres.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLibres.Location = new Point(10, 28);
            lblLibres.Name = "lblLibres";
            lblLibres.Size = new Size(33, 37);
            lblLibres.TabIndex = 1;
            lblLibres.Text = "0";
            // 
            // lblLibresTitulo
            // 
            lblLibresTitulo.AutoSize = true;
            lblLibresTitulo.ForeColor = Color.DimGray;
            lblLibresTitulo.Location = new Point(10, 6);
            lblLibresTitulo.Name = "lblLibresTitulo";
            lblLibresTitulo.Size = new Size(90, 20);
            lblLibresTitulo.TabIndex = 0;
            lblLibresTitulo.Text = "Plazas libres";
            // 
            // pnlOcupadas
            // 
            pnlOcupadas.BackColor = Color.FromArgb(240, 240, 240);
            pnlOcupadas.BorderStyle = BorderStyle.FixedSingle;
            pnlOcupadas.Controls.Add(lblOcupadas);
            pnlOcupadas.Controls.Add(lblOcupadasTitulo);
            pnlOcupadas.Dock = DockStyle.Fill;
            pnlOcupadas.Location = new Point(378, 3);
            pnlOcupadas.Name = "pnlOcupadas";
            pnlOcupadas.Size = new Size(369, 66);
            pnlOcupadas.TabIndex = 1;
            // 
            // lblOcupadas
            // 
            lblOcupadas.AutoSize = true;
            lblOcupadas.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOcupadas.Location = new Point(10, 28);
            lblOcupadas.Name = "lblOcupadas";
            lblOcupadas.Size = new Size(33, 37);
            lblOcupadas.TabIndex = 1;
            lblOcupadas.Text = "0";
            // 
            // lblOcupadasTitulo
            // 
            lblOcupadasTitulo.AutoSize = true;
            lblOcupadasTitulo.ForeColor = Color.DimGray;
            lblOcupadasTitulo.Location = new Point(10, 6);
            lblOcupadasTitulo.Name = "lblOcupadasTitulo";
            lblOcupadasTitulo.Size = new Size(75, 20);
            lblOcupadasTitulo.TabIndex = 0;
            lblOcupadasTitulo.Text = "Ocupadas";
            // 
            // pnlOcupacion
            // 
            pnlOcupacion.BackColor = Color.FromArgb(240, 240, 240);
            pnlOcupacion.BorderStyle = BorderStyle.FixedSingle;
            pnlOcupacion.Controls.Add(lblOcupacion);
            pnlOcupacion.Controls.Add(lblOcupacionTitulo);
            pnlOcupacion.Dock = DockStyle.Fill;
            pnlOcupacion.Location = new Point(753, 3);
            pnlOcupacion.Name = "pnlOcupacion";
            pnlOcupacion.Size = new Size(370, 66);
            pnlOcupacion.TabIndex = 2;
            // 
            // lblOcupacion
            // 
            lblOcupacion.AutoSize = true;
            lblOcupacion.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOcupacion.Location = new Point(10, 28);
            lblOcupacion.Name = "lblOcupacion";
            lblOcupacion.Size = new Size(63, 37);
            lblOcupacion.TabIndex = 1;
            lblOcupacion.Text = "0 %";
            // 
            // lblOcupacionTitulo
            // 
            lblOcupacionTitulo.AutoSize = true;
            lblOcupacionTitulo.ForeColor = Color.DimGray;
            lblOcupacionTitulo.Location = new Point(10, 6);
            lblOcupacionTitulo.Name = "lblOcupacionTitulo";
            lblOcupacionTitulo.Size = new Size(80, 20);
            lblOcupacionTitulo.TabIndex = 0;
            lblOcupacionTitulo.Text = "Ocupación";
            // 
            // gbVehiculo
            // 
            gbVehiculo.Controls.Add(lblPlaca);
            gbVehiculo.Controls.Add(txtPlaca);
            gbVehiculo.Controls.Add(lblPropietario);
            gbVehiculo.Controls.Add(txtPropietario);
            gbVehiculo.Controls.Add(lblPlaza);
            gbVehiculo.Controls.Add(txtPlaza);
            gbVehiculo.Location = new Point(12, 96);
            gbVehiculo.Name = "gbVehiculo";
            gbVehiculo.Size = new Size(280, 212);
            gbVehiculo.TabIndex = 1;
            gbVehiculo.TabStop = false;
            gbVehiculo.Text = "Vehículo";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(12, 26);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(44, 20);
            lblPlaca.TabIndex = 0;
            lblPlaca.Text = "Placa";
            // 
            // txtPlaca
            // 
            txtPlaca.CharacterCasing = CharacterCasing.Upper;
            txtPlaca.Location = new Point(12, 49);
            txtPlaca.MaxLength = 6;
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(254, 27);
            txtPlaca.TabIndex = 1;
            txtPlaca.Leave += txtPlaca_Leave;
            // 
            // lblPropietario
            // 
            lblPropietario.AutoSize = true;
            lblPropietario.Location = new Point(12, 86);
            lblPropietario.Name = "lblPropietario";
            lblPropietario.Size = new Size(83, 20);
            lblPropietario.TabIndex = 2;
            lblPropietario.Text = "Propietario";
            // 
            // txtPropietario
            // 
            txtPropietario.Location = new Point(12, 109);
            txtPropietario.Name = "txtPropietario";
            txtPropietario.ReadOnly = true;
            txtPropietario.Size = new Size(254, 27);
            txtPropietario.TabIndex = 3;
            txtPropietario.TabStop = false;
            // 
            // lblPlaza
            // 
            lblPlaza.AutoSize = true;
            lblPlaza.Location = new Point(12, 146);
            lblPlaza.Name = "lblPlaza";
            lblPlaza.Size = new Size(108, 20);
            lblPlaza.TabIndex = 4;
            lblPlaza.Text = "Plaza asignada";
            // 
            // txtPlaza
            // 
            txtPlaza.Location = new Point(12, 169);
            txtPlaza.Name = "txtPlaza";
            txtPlaza.ReadOnly = true;
            txtPlaza.Size = new Size(254, 27);
            txtPlaza.TabIndex = 5;
            txtPlaza.TabStop = false;
            // 
            // btnRegistrarIngreso
            // 
            btnRegistrarIngreso.Image = Properties.Resources.ingreso;
            btnRegistrarIngreso.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistrarIngreso.Location = new Point(12, 318);
            btnRegistrarIngreso.Name = "btnRegistrarIngreso";
            btnRegistrarIngreso.Size = new Size(280, 36);
            btnRegistrarIngreso.TabIndex = 2;
            btnRegistrarIngreso.Text = "Registrar ingreso";
            btnRegistrarIngreso.UseVisualStyleBackColor = true;
            btnRegistrarIngreso.Click += btnRegistrarIngreso_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Image = Properties.Resources.limpiar;
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(12, 360);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(280, 36);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            txtBuscar.Location = new Point(310, 104);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por placa";
            txtBuscar.Size = new Size(640, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrarSalida.Image = Properties.Resources.salida;
            btnRegistrarSalida.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistrarSalida.Location = new Point(960, 100);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(178, 34);
            btnRegistrarSalida.TabIndex = 5;
            btnRegistrarSalida.Text = "Registrar salida";
            btnRegistrarSalida.UseVisualStyleBackColor = true;
            btnRegistrarSalida.Click += btnRegistrarSalida_Click;
            // 
            // lblVehiculosDentro
            // 
            lblVehiculosDentro.AutoSize = true;
            lblVehiculosDentro.Location = new Point(310, 140);
            lblVehiculosDentro.Name = "lblVehiculosDentro";
            lblVehiculosDentro.Size = new Size(151, 20);
            lblVehiculosDentro.TabIndex = 6;
            lblVehiculosDentro.Text = "Historial de vehículos";
            // 
            // dgvDentro
            // 
            dgvDentro.AllowUserToAddRows = false;
            dgvDentro.AllowUserToDeleteRows = false;
            dgvDentro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDentro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDentro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDentro.Columns.AddRange(new DataGridViewColumn[] { colId, colPlaca, colPropietario, colNombrePropietario, colPlaza, colLlegada, colSalida, colTiempo });
            dgvDentro.Location = new Point(310, 163);
            dgvDentro.MultiSelect = false;
            dgvDentro.Name = "dgvDentro";
            dgvDentro.ReadOnly = true;
            dgvDentro.RowHeadersVisible = false;
            dgvDentro.RowHeadersWidth = 51;
            dgvDentro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDentro.Size = new Size(828, 425);
            dgvDentro.TabIndex = 7;
            dgvDentro.CellClick += dgvDentro_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "N°";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colPlaca
            // 
            colPlaca.DataPropertyName = "VehiculoPlaca";
            colPlaca.HeaderText = "Placa";
            colPlaca.MinimumWidth = 6;
            colPlaca.Name = "colPlaca";
            colPlaca.ReadOnly = true;
            // 
            // colPropietario
            // 
            colPropietario.DataPropertyName = "DocPropietario";
            colPropietario.HeaderText = "Doc. propietario";
            colPropietario.MinimumWidth = 6;
            colPropietario.Name = "colPropietario";
            colPropietario.ReadOnly = true;
            // 
            // colNombrePropietario
            // 
            colNombrePropietario.DataPropertyName = "NombrePropietario";
            colNombrePropietario.HeaderText = "Propietario";
            colNombrePropietario.MinimumWidth = 6;
            colNombrePropietario.Name = "colNombrePropietario";
            colNombrePropietario.ReadOnly = true;
            // 
            // colPlaza
            // 
            colPlaza.DataPropertyName = "Plaza";
            colPlaza.HeaderText = "Plaza";
            colPlaza.MinimumWidth = 6;
            colPlaza.Name = "colPlaza";
            colPlaza.ReadOnly = true;
            // 
            // colLlegada
            // 
            colLlegada.DataPropertyName = "FechaLlegada";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm tt";
            colLlegada.DefaultCellStyle = dataGridViewCellStyle1;
            colLlegada.HeaderText = "Fecha llegada";
            colLlegada.MinimumWidth = 6;
            colLlegada.Name = "colLlegada";
            colLlegada.ReadOnly = true;
            // 
            // colSalida
            // 
            colSalida.DataPropertyName = "FechaSalida";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm tt";
            colSalida.DefaultCellStyle = dataGridViewCellStyle2;
            colSalida.HeaderText = "Fecha salida";
            colSalida.MinimumWidth = 6;
            colSalida.Name = "colSalida";
            colSalida.ReadOnly = true;
            // 
            // colTiempo
            // 
            colTiempo.DataPropertyName = "TiempoOcupado";
            colTiempo.HeaderText = "Tiempo";
            colTiempo.MinimumWidth = 6;
            colTiempo.Name = "colTiempo";
            colTiempo.ReadOnly = true;
            // 
            // FrPorteria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 600);
            Controls.Add(tlpContadores);
            Controls.Add(gbVehiculo);
            Controls.Add(btnRegistrarIngreso);
            Controls.Add(btnLimpiar);
            Controls.Add(txtBuscar);
            Controls.Add(btnRegistrarSalida);
            Controls.Add(lblVehiculosDentro);
            Controls.Add(dgvDentro);
            MinimumSize = new Size(1018, 647);
            Name = "FrPorteria";
            Text = "Portería";
            Load += FrPorteria_Load;
            tlpContadores.ResumeLayout(false);
            pnlLibres.ResumeLayout(false);
            pnlLibres.PerformLayout();
            pnlOcupadas.ResumeLayout(false);
            pnlOcupadas.PerformLayout();
            pnlOcupacion.ResumeLayout(false);
            pnlOcupacion.PerformLayout();
            gbVehiculo.ResumeLayout(false);
            gbVehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDentro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tlpContadores;
        private Panel pnlLibres;
        private Label lblLibres;
        private Label lblLibresTitulo;
        private Panel pnlOcupadas;
        private Label lblOcupadas;
        private Label lblOcupadasTitulo;
        private Panel pnlOcupacion;
        private Label lblOcupacion;
        private Label lblOcupacionTitulo;
        private GroupBox gbVehiculo;
        private Label lblPlaca;
        private TextBox txtPlaca;
        private Label lblPropietario;
        private TextBox txtPropietario;
        private Label lblPlaza;
        private TextBox txtPlaza;
        private Button btnRegistrarIngreso;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private Button btnRegistrarSalida;
        private Label lblVehiculosDentro;
        private DataGridView dgvDentro;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colPlaca;
        private DataGridViewTextBoxColumn colPropietario;
        private DataGridViewTextBoxColumn colNombrePropietario;
        private DataGridViewTextBoxColumn colPlaza;
        private DataGridViewTextBoxColumn colLlegada;
        private DataGridViewTextBoxColumn colSalida;
        private DataGridViewTextBoxColumn colTiempo;
    }
}
