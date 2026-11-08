namespace ParkFlow.Presentacion
{
    partial class FrVehiculos
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
            gbDatos = new GroupBox();
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvVehiculos = new DataGridView();
            colPlaca = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colModelo = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(lblPlaca);
            gbDatos.Controls.Add(txtPlaca);
            gbDatos.Controls.Add(lblTipo);
            gbDatos.Controls.Add(cmbTipo);
            gbDatos.Controls.Add(lblMarca);
            gbDatos.Controls.Add(txtMarca);
            gbDatos.Controls.Add(lblModelo);
            gbDatos.Controls.Add(txtModelo);
            gbDatos.Controls.Add(btnNuevo);
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(btnEliminar);
            gbDatos.Location = new Point(12, 12);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(280, 340);
            gbDatos.TabIndex = 0;
            gbDatos.TabStop = false;
            gbDatos.Text = "Vehículo";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(15, 32);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(44, 20);
            lblPlaca.TabIndex = 0;
            lblPlaca.Text = "Placa";
            // 
            // txtPlaca
            // 
            txtPlaca.CharacterCasing = CharacterCasing.Upper;
            txtPlaca.Location = new Point(15, 55);
            txtPlaca.MaxLength = 10;
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(250, 27);
            txtPlaca.TabIndex = 1;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 92);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(39, 20);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(15, 115);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(250, 28);
            cmbTipo.TabIndex = 3;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(15, 152);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(50, 20);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(15, 175);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(250, 27);
            txtMarca.TabIndex = 5;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(15, 212);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(61, 20);
            lblModelo.TabIndex = 6;
            lblModelo.Text = "Modelo";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(15, 235);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(250, 27);
            txtModelo.TabIndex = 7;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(15, 285);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(78, 34);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(101, 285);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(78, 34);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(187, 285);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(78, 34);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Columns.AddRange(new DataGridViewColumn[] { colPlaca, colTipo, colMarca, colModelo });
            dgvVehiculos.Location = new Point(305, 18);
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.RowHeadersWidth = 51;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(495, 334);
            dgvVehiculos.TabIndex = 1;
            dgvVehiculos.CellClick += dgvVehiculos_CellClick;
            // 
            // colPlaca
            // 
            colPlaca.DataPropertyName = "Id";
            colPlaca.HeaderText = "Placa";
            colPlaca.MinimumWidth = 6;
            colPlaca.Name = "colPlaca";
            colPlaca.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colMarca
            // 
            colMarca.DataPropertyName = "Marca";
            colMarca.HeaderText = "Marca";
            colMarca.MinimumWidth = 6;
            colMarca.Name = "colMarca";
            colMarca.ReadOnly = true;
            // 
            // colModelo
            // 
            colModelo.DataPropertyName = "Modelo";
            colModelo.HeaderText = "Modelo";
            colModelo.MinimumWidth = 6;
            colModelo.Name = "colModelo";
            colModelo.ReadOnly = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Location = new Point(700, 364);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 34);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrVehiculos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(812, 410);
            Controls.Add(gbDatos);
            Controls.Add(dgvVehiculos);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrVehiculos";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehículos";
            Load += FrVehiculos_Load;
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDatos;
        private Label lblPlaca;
        private TextBox txtPlaca;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblModelo;
        private TextBox txtModelo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dgvVehiculos;
        private DataGridViewTextBoxColumn colPlaca;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colModelo;
        private Button btnCerrar;
    }
}
