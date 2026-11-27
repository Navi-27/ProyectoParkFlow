namespace ParkFlow.Presentacion
{
    partial class FrVisitas
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
            gbVisitante = new GroupBox();
            lblTipoDocumento = new Label();
            cmbTipoDocumento = new ComboBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            chkMovilidad = new CheckBox();
            gbVisita = new GroupBox();
            lblResidente = new Label();
            cmbResidente = new ComboBox();
            lblVivienda = new Label();
            cmbVivienda = new ComboBox();
            lblComoLlega = new Label();
            rbAPie = new RadioButton();
            rbVehiculo = new RadioButton();
            btnRegistrarIngreso = new Button();
            btnRegistrarSalida = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            dgvVisitas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDocVisitante = new DataGridViewTextBoxColumn();
            colVisitante = new DataGridViewTextBoxColumn();
            colDocVisitado = new DataGridViewTextBoxColumn();
            colVisitado = new DataGridViewTextBoxColumn();
            colVivienda = new DataGridViewTextBoxColumn();
            colIngreso = new DataGridViewTextBoxColumn();
            colSalida = new DataGridViewTextBoxColumn();
            colTiempo = new DataGridViewTextBoxColumn();
            gbVisitante.SuspendLayout();
            gbVisita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            SuspendLayout();
            // 
            // gbVisitante
            // 
            gbVisitante.Controls.Add(lblTipoDocumento);
            gbVisitante.Controls.Add(cmbTipoDocumento);
            gbVisitante.Controls.Add(lblDocumento);
            gbVisitante.Controls.Add(txtDocumento);
            gbVisitante.Controls.Add(lblNombre);
            gbVisitante.Controls.Add(txtNombre);
            gbVisitante.Controls.Add(lblApellido);
            gbVisitante.Controls.Add(txtApellido);
            gbVisitante.Controls.Add(lblTelefono);
            gbVisitante.Controls.Add(txtTelefono);
            gbVisitante.Controls.Add(chkMovilidad);
            gbVisitante.Location = new Point(20, 60);
            gbVisitante.Name = "gbVisitante";
            gbVisitante.Size = new Size(450, 235);
            gbVisitante.TabIndex = 0;
            gbVisitante.TabStop = false;
            gbVisitante.Text = "Visitante";
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(12, 32);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(140, 20);
            lblTipoDocumento.TabIndex = 0;
            lblTipoDocumento.Text = "Tipo de documento";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Items.AddRange(new object[] { "CC - Cedula De Ciudadania", "CE - Cédula de Extranjería", "TI - Tarjeta de Identidad", "PA - Pasaporte", "DNI - Documento Nacional de Identidad" });
            cmbTipoDocumento.Location = new Point(165, 28);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(272, 28);
            cmbTipoDocumento.TabIndex = 1;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 65);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(87, 20);
            lblDocumento.TabIndex = 2;
            lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(165, 61);
            txtDocumento.MaxLength = 20;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(272, 27);
            txtDocumento.TabIndex = 3;
            txtDocumento.Leave += txtDocumento_Leave;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 98);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtNombre.Location = new Point(165, 94);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(272, 27);
            txtNombre.TabIndex = 6;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(12, 131);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(72, 20);
            lblApellido.TabIndex = 7;
            lblApellido.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            txtApellido.Location = new Point(165, 127);
            txtApellido.MaxLength = 100;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(272, 27);
            txtApellido.TabIndex = 8;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(12, 164);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(67, 20);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(165, 160);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(272, 27);
            txtTelefono.TabIndex = 10;
            // 
            // chkMovilidad
            // 
            chkMovilidad.AutoSize = true;
            chkMovilidad.Location = new Point(165, 196);
            chkMovilidad.Name = "chkMovilidad";
            chkMovilidad.Size = new Size(160, 24);
            chkMovilidad.TabIndex = 11;
            chkMovilidad.Text = "Movilidad reducida";
            chkMovilidad.UseVisualStyleBackColor = true;
            // 
            // gbVisita
            // 
            gbVisita.Controls.Add(lblResidente);
            gbVisita.Controls.Add(cmbResidente);
            gbVisita.Controls.Add(lblVivienda);
            gbVisita.Controls.Add(cmbVivienda);
            gbVisita.Controls.Add(lblComoLlega);
            gbVisita.Controls.Add(rbAPie);
            gbVisita.Controls.Add(rbVehiculo);
            gbVisita.Location = new Point(20, 305);
            gbVisita.Name = "gbVisita";
            gbVisita.Size = new Size(450, 135);
            gbVisita.TabIndex = 1;
            gbVisita.TabStop = false;
            gbVisita.Text = "Visita a";
            // 
            // lblResidente
            // 
            lblResidente.AutoSize = true;
            lblResidente.Location = new Point(12, 32);
            lblResidente.Name = "lblResidente";
            lblResidente.Size = new Size(74, 20);
            lblResidente.TabIndex = 0;
            lblResidente.Text = "Residente";
            // 
            // cmbResidente
            // 
            cmbResidente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResidente.FormattingEnabled = true;
            cmbResidente.Location = new Point(165, 28);
            cmbResidente.Name = "cmbResidente";
            cmbResidente.Size = new Size(272, 28);
            cmbResidente.TabIndex = 1;
            cmbResidente.SelectedIndexChanged += cmbResidente_SelectedIndexChanged;
            // 
            // lblVivienda
            // 
            lblVivienda.AutoSize = true;
            lblVivienda.Location = new Point(12, 66);
            lblVivienda.Name = "lblVivienda";
            lblVivienda.Size = new Size(66, 20);
            lblVivienda.TabIndex = 2;
            lblVivienda.Text = "Vivienda";
            // 
            // cmbVivienda
            // 
            cmbVivienda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVivienda.FormattingEnabled = true;
            cmbVivienda.Location = new Point(165, 62);
            cmbVivienda.Name = "cmbVivienda";
            cmbVivienda.Size = new Size(272, 28);
            cmbVivienda.TabIndex = 3;
            // 
            // lblComoLlega
            // 
            lblComoLlega.AutoSize = true;
            lblComoLlega.Location = new Point(12, 102);
            lblComoLlega.Name = "lblComoLlega";
            lblComoLlega.Size = new Size(100, 20);
            lblComoLlega.TabIndex = 4;
            lblComoLlega.Text = "¿Cómo llega?";
            // 
            // rbAPie
            // 
            rbAPie.AutoSize = true;
            rbAPie.Checked = true;
            rbAPie.Location = new Point(165, 100);
            rbAPie.Name = "rbAPie";
            rbAPie.Size = new Size(65, 24);
            rbAPie.TabIndex = 5;
            rbAPie.TabStop = true;
            rbAPie.Text = "A pie";
            rbAPie.UseVisualStyleBackColor = true;

            // 
            // rbVehiculo
            // 
            rbVehiculo.AutoSize = true;
            rbVehiculo.Location = new Point(255, 100);
            rbVehiculo.Name = "rbVehiculo";
            rbVehiculo.Size = new Size(105, 24);
            rbVehiculo.TabIndex = 6;
            rbVehiculo.Text = "En vehículo";
            rbVehiculo.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarIngreso
            // 
            btnRegistrarIngreso.Image = Properties.Resources.ingreso;
            btnRegistrarIngreso.Location = new Point(20, 455);
            btnRegistrarIngreso.Name = "btnRegistrarIngreso";
            btnRegistrarIngreso.Size = new Size(220, 38);
            btnRegistrarIngreso.TabIndex = 2;
            btnRegistrarIngreso.Text = "Registrar ingreso";
            btnRegistrarIngreso.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistrarIngreso.UseVisualStyleBackColor = true;
            btnRegistrarIngreso.Click += btnRegistrarIngreso_Click;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrarSalida.Image = Properties.Resources.salida;
            btnRegistrarSalida.Location = new Point(1100, 14);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(170, 34);
            btnRegistrarSalida.TabIndex = 7;
            btnRegistrarSalida.Text = "Registrar salida";
            btnRegistrarSalida.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistrarSalida.UseVisualStyleBackColor = true;
            btnRegistrarSalida.Click += btnRegistrarSalida_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Image = Properties.Resources.limpiar;
            btnLimpiar.Location = new Point(250, 455);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(220, 38);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(490, 18);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por documento o nombre";
            txtBuscar.Size = new Size(600, 27);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvVisitas
            // 
            dgvVisitas.AllowUserToAddRows = false;
            dgvVisitas.AllowUserToDeleteRows = false;
            dgvVisitas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisitas.Columns.AddRange(new DataGridViewColumn[] { colId, colDocVisitante, colVisitante, colDocVisitado, colVisitado, colVivienda, colIngreso, colSalida, colTiempo });
            dgvVisitas.Location = new Point(490, 58);
            dgvVisitas.MultiSelect = false;
            dgvVisitas.Name = "dgvVisitas";
            dgvVisitas.ReadOnly = true;
            dgvVisitas.RowHeadersVisible = false;
            dgvVisitas.RowHeadersWidth = 51;
            dgvVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitas.Size = new Size(780, 542);
            dgvVisitas.TabIndex = 8;
            dgvVisitas.CellClick += dgvVisitas_CellClick;
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
            // colDocVisitante
            // 
            colDocVisitante.DataPropertyName = "PersonaVisitante";
            colDocVisitante.HeaderText = "Doc. visitante";
            colDocVisitante.MinimumWidth = 6;
            colDocVisitante.Name = "colDocVisitante";
            colDocVisitante.ReadOnly = true;
            // 
            // colVisitante
            // 
            colVisitante.DataPropertyName = "NombreVisitante";
            colVisitante.HeaderText = "Visitante";
            colVisitante.MinimumWidth = 6;
            colVisitante.Name = "colVisitante";
            colVisitante.ReadOnly = true;
            // 
            // colDocVisitado
            // 
            colDocVisitado.DataPropertyName = "PersonaVisitada";
            colDocVisitado.HeaderText = "Doc. residente";
            colDocVisitado.MinimumWidth = 6;
            colDocVisitado.Name = "colDocVisitado";
            colDocVisitado.ReadOnly = true;
            // 
            // colVisitado
            // 
            colVisitado.DataPropertyName = "NombreVisitado";
            colVisitado.HeaderText = "Visita a";
            colVisitado.MinimumWidth = 6;
            colVisitado.Name = "colVisitado";
            colVisitado.ReadOnly = true;
            // 
            // colVivienda
            // 
            colVivienda.DataPropertyName = "IdVivienda";
            colVivienda.HeaderText = "Vivienda";
            colVivienda.MinimumWidth = 6;
            colVivienda.Name = "colVivienda";
            colVivienda.ReadOnly = true;
            // 
            // colIngreso
            // 
            colIngreso.DataPropertyName = "FechaIngreso";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm tt";
            colIngreso.DefaultCellStyle = dataGridViewCellStyle1;
            colIngreso.HeaderText = "Fecha ingreso";
            colIngreso.MinimumWidth = 6;
            colIngreso.Name = "colIngreso";
            colIngreso.ReadOnly = true;
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
            colTiempo.DataPropertyName = "TiempoVisita";
            colTiempo.HeaderText = "Tiempo";
            colTiempo.MinimumWidth = 6;
            colTiempo.Name = "colTiempo";
            colTiempo.ReadOnly = true;
            // 
            // FrVisitas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 615);
            Controls.Add(gbVisitante);
            Controls.Add(gbVisita);
            Controls.Add(btnRegistrarIngreso);
            Controls.Add(btnRegistrarSalida);
            Controls.Add(btnLimpiar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvVisitas);
            MinimumSize = new Size(1308, 662);
            Name = "FrVisitas";
            Text = "Visitas";
            Activated += FrVisitas_Activated;
            Load += FrVisitas_Load;
            gbVisitante.ResumeLayout(false);
            gbVisitante.PerformLayout();
            gbVisita.ResumeLayout(false);
            gbVisita.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbVisitante;
        private Label lblTipoDocumento;
        private ComboBox cmbTipoDocumento;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private CheckBox chkMovilidad;
        private GroupBox gbVisita;
        private Label lblResidente;
        private ComboBox cmbResidente;
        private Label lblVivienda;
        private ComboBox cmbVivienda;
        private Label lblComoLlega;
        private RadioButton rbAPie;
        private RadioButton rbVehiculo;
        private Button btnRegistrarIngreso;
        private Button btnRegistrarSalida;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private DataGridView dgvVisitas;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocVisitante;
        private DataGridViewTextBoxColumn colVisitante;
        private DataGridViewTextBoxColumn colDocVisitado;
        private DataGridViewTextBoxColumn colVisitado;
        private DataGridViewTextBoxColumn colVivienda;
        private DataGridViewTextBoxColumn colIngreso;
        private DataGridViewTextBoxColumn colSalida;
        private DataGridViewTextBoxColumn colTiempo;
    }
}
