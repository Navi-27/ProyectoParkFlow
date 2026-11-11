namespace ParkFlow.Presentacion
{
    partial class FrResidente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrResidente));
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tlpCentro = new TableLayoutPanel();
            tlpCampos = new TableLayoutPanel();
            tlpBuscar = new TableLayoutPanel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            label1 = new Label();
            cmbTipoDocumento = new ComboBox();
            label2 = new Label();
            txtDocumento = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label4 = new Label();
            txtApellido = new TextBox();
            label5 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtCorreo = new TextBox();
            chkMovilidad = new CheckBox();
            tlpBotones = new TableLayoutPanel();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            splitResidentes = new SplitContainer();
            dgvResidentes = new DataGridView();
            colDocumento = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colMovilidad = new DataGridViewCheckBoxColumn();
            colVehiculos = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tlpCentro.SuspendLayout();
            tlpCampos.SuspendLayout();
            tlpBuscar.SuspendLayout();
            tlpBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitResidentes).BeginInit();
            splitResidentes.Panel1.SuspendLayout();
            splitResidentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResidentes).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1MinSize = 620;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitResidentes);
            splitContainer1.Size = new Size(1709, 884);
            splitContainer1.SplitterDistance = 851;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tlpCentro);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(851, 884);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestión de Residentes";
            // 
            // tlpCentro
            // 
            tlpCentro.ColumnCount = 3;
            tlpCentro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tlpCentro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84F));
            tlpCentro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tlpCentro.Controls.Add(tlpCampos, 1, 1);
            tlpCentro.Dock = DockStyle.Fill;
            tlpCentro.Location = new Point(3, 24);
            tlpCentro.Name = "tlpCentro";
            tlpCentro.RowCount = 3;
            tlpCentro.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCentro.RowStyles.Add(new RowStyle());
            tlpCentro.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCentro.Size = new Size(845, 856);
            tlpCentro.TabIndex = 0;
            // 
            // tlpCampos
            // 
            tlpCampos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpCampos.AutoSize = true;
            tlpCampos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpCampos.ColumnCount = 2;
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpCampos.Controls.Add(tlpBuscar, 0, 0);
            tlpCampos.Controls.Add(label1, 0, 1);
            tlpCampos.Controls.Add(cmbTipoDocumento, 1, 1);
            tlpCampos.Controls.Add(label2, 0, 2);
            tlpCampos.Controls.Add(txtDocumento, 1, 2);
            tlpCampos.Controls.Add(label3, 0, 3);
            tlpCampos.Controls.Add(txtNombre, 1, 3);
            tlpCampos.Controls.Add(label4, 0, 4);
            tlpCampos.Controls.Add(txtApellido, 1, 4);
            tlpCampos.Controls.Add(label5, 0, 5);
            tlpCampos.Controls.Add(txtTelefono, 1, 5);
            tlpCampos.Controls.Add(label6, 0, 6);
            tlpCampos.Controls.Add(txtCorreo, 1, 6);
            tlpCampos.Controls.Add(chkMovilidad, 1, 7);
            tlpCampos.Controls.Add(tlpBotones, 0, 8);
            tlpCampos.Location = new Point(70, 216);
            tlpCampos.Name = "tlpCampos";
            tlpCampos.RowCount = 9;
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.RowStyles.Add(new RowStyle());
            tlpCampos.Size = new Size(703, 423);
            tlpCampos.TabIndex = 0;
            // 
            // tlpBuscar
            // 
            tlpBuscar.AutoSize = true;
            tlpBuscar.ColumnCount = 2;
            tlpCampos.SetColumnSpan(tlpBuscar, 2);
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle());
            tlpBuscar.Controls.Add(txtBuscar, 0, 0);
            tlpBuscar.Controls.Add(btnBuscar, 1, 0);
            tlpBuscar.Dock = DockStyle.Fill;
            tlpBuscar.Location = new Point(0, 0);
            tlpBuscar.Margin = new Padding(0, 0, 0, 24);
            tlpBuscar.Name = "tlpBuscar";
            tlpBuscar.RowCount = 1;
            tlpBuscar.RowStyles.Add(new RowStyle());
            tlpBuscar.Size = new Size(703, 46);
            tlpBuscar.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(3, 9);
            txtBuscar.Margin = new Padding(3, 6, 3, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar residente por documento o nombre";
            txtBuscar.Size = new Size(588, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = true;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(600, 3);
            btnBuscar.Margin = new Padding(6, 3, 3, 3);
            btnBuscar.MinimumSize = new Size(100, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 40);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 80);
            label1.Margin = new Padding(3, 6, 3, 6);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 0;
            label1.Text = "Tipo De Documento";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Items.AddRange(new object[] { "CC - Cedula De Ciudadania", "CE - Cédula de Extranjería", "TI - Tarjeta de Identidad", "PA - Pasaporte", "DNI - Documento Nacional de Identidad" });
            cmbTipoDocumento.Location = new Point(249, 76);
            cmbTipoDocumento.Margin = new Padding(3, 6, 3, 6);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(451, 28);
            cmbTipoDocumento.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 119);
            label2.Margin = new Padding(3, 6, 3, 6);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDocumento.Location = new Point(249, 116);
            txtDocumento.Margin = new Padding(3, 6, 3, 6);
            txtDocumento.MaxLength = 20;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(451, 27);
            txtDocumento.TabIndex = 8;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 158);
            label3.Margin = new Padding(3, 6, 3, 6);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtNombre.Location = new Point(249, 155);
            txtNombre.Margin = new Padding(3, 6, 3, 6);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(451, 27);
            txtNombre.TabIndex = 9;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 197);
            label4.Margin = new Padding(3, 6, 3, 6);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellido.CharacterCasing = CharacterCasing.Upper;
            txtApellido.Location = new Point(249, 194);
            txtApellido.Margin = new Padding(3, 6, 3, 6);
            txtApellido.MaxLength = 100;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(451, 27);
            txtApellido.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 236);
            label5.Margin = new Padding(3, 6, 3, 6);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 4;
            label5.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Location = new Point(249, 233);
            txtTelefono.Margin = new Padding(3, 6, 3, 6);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(451, 27);
            txtTelefono.TabIndex = 11;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 275);
            label6.Margin = new Padding(3, 6, 3, 6);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 5;
            label6.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.Location = new Point(249, 272);
            txtCorreo.Margin = new Padding(3, 6, 3, 6);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(451, 27);
            txtCorreo.TabIndex = 12;
            // 
            // chkMovilidad
            // 
            chkMovilidad.Anchor = AnchorStyles.Left;
            chkMovilidad.AutoSize = true;
            chkMovilidad.CheckAlign = ContentAlignment.MiddleRight;
            chkMovilidad.Location = new Point(249, 311);
            chkMovilidad.Margin = new Padding(3, 6, 3, 6);
            chkMovilidad.Name = "chkMovilidad";
            chkMovilidad.Size = new Size(164, 24);
            chkMovilidad.TabIndex = 13;
            chkMovilidad.Text = "Movilidad Reducida";
            chkMovilidad.UseVisualStyleBackColor = true;
            // 
            // tlpBotones
            // 
            tlpBotones.AutoSize = true;
            tlpBotones.ColumnCount = 4;
            tlpCampos.SetColumnSpan(tlpBotones, 2);
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.Controls.Add(btnAgregar, 0, 0);
            tlpBotones.Controls.Add(btnActualizar, 1, 0);
            tlpBotones.Controls.Add(btnEliminar, 2, 0);
            tlpBotones.Controls.Add(btnLimpiar, 3, 0);
            tlpBotones.Dock = DockStyle.Fill;
            tlpBotones.Location = new Point(0, 365);
            tlpBotones.Margin = new Padding(0, 24, 0, 0);
            tlpBotones.Name = "tlpBotones";
            tlpBotones.RowCount = 1;
            tlpBotones.RowStyles.Add(new RowStyle());
            tlpBotones.Size = new Size(703, 58);
            tlpBotones.TabIndex = 14;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
            btnAgregar.Location = new Point(3, 9);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(169, 40);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(178, 9);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(169, 40);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.Location = new Point(353, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(169, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
            btnLimpiar.Location = new Point(528, 9);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(172, 40);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // splitResidentes
            // 
            splitResidentes.Dock = DockStyle.Fill;
            splitResidentes.Location = new Point(0, 0);
            splitResidentes.Name = "splitResidentes";
            splitResidentes.Orientation = Orientation.Horizontal;
            // 
            // splitResidentes.Panel1
            // 
            splitResidentes.Panel1.Controls.Add(dgvResidentes);
            splitResidentes.Panel2Collapsed = true;
            splitResidentes.Size = new Size(853, 884);
            splitResidentes.SplitterDistance = 544;
            splitResidentes.TabIndex = 0;
            // 
            // dgvResidentes
            // 
            dgvResidentes.AllowUserToAddRows = false;
            dgvResidentes.AllowUserToDeleteRows = false;
            dgvResidentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResidentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResidentes.Columns.AddRange(new DataGridViewColumn[] { colDocumento, colNombre, colApellido, colTelefono, colCorreo, colMovilidad, colVehiculos });
            dgvResidentes.Dock = DockStyle.Fill;
            dgvResidentes.Location = new Point(0, 0);
            dgvResidentes.MultiSelect = false;
            dgvResidentes.Name = "dgvResidentes";
            dgvResidentes.ReadOnly = true;
            dgvResidentes.RowHeadersVisible = false;
            dgvResidentes.RowHeadersWidth = 51;
            dgvResidentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResidentes.Size = new Size(853, 884);
            dgvResidentes.TabIndex = 0;
            dgvResidentes.CellClick += dgvResidentes_CellClick;
            dgvResidentes.CellContentClick += dgvResidentes_CellContentClick;
            dgvResidentes.CellFormatting += dgvResidentes_CellFormatting;
            dgvResidentes.CellPainting += dgvResidentes_CellPainting;
            // 
            // colDocumento
            // 
            colDocumento.DataPropertyName = "Id";
            colDocumento.HeaderText = "Documento";
            colDocumento.MinimumWidth = 6;
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 6;
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.HeaderText = "Telefono";
            colTelefono.MinimumWidth = 6;
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colCorreo
            // 
            colCorreo.DataPropertyName = "Correo";
            colCorreo.HeaderText = "Correo";
            colCorreo.MinimumWidth = 6;
            colCorreo.Name = "colCorreo";
            colCorreo.ReadOnly = true;
            // 
            // colMovilidad
            // 
            colMovilidad.DataPropertyName = "MovilidadReducida";
            colMovilidad.HeaderText = "Mov. Reducida";
            colMovilidad.MinimumWidth = 6;
            colMovilidad.Name = "colMovilidad";
            colMovilidad.ReadOnly = true;
            // 
            // colVehiculos
            // 
            colVehiculos.HeaderText = "Vehículos";
            colVehiculos.MinimumWidth = 6;
            colVehiculos.Name = "colVehiculos";
            colVehiculos.ReadOnly = true;
            // 
            // FrResidente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1709, 884);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrResidente";
            Text = "FrResidente";
            WindowState = FormWindowState.Maximized;
            Load += FrResidente_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tlpCentro.ResumeLayout(false);
            tlpCentro.PerformLayout();
            tlpCampos.ResumeLayout(false);
            tlpCampos.PerformLayout();
            tlpBuscar.ResumeLayout(false);
            tlpBuscar.PerformLayout();
            tlpBotones.ResumeLayout(false);
            splitResidentes.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitResidentes).EndInit();
            splitResidentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResidentes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TableLayoutPanel tlpCentro;
        private TableLayoutPanel tlpCampos;
        private TableLayoutPanel tlpBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private TableLayoutPanel tlpBotones;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label6;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtDocumento;
        private ComboBox cmbTipoDocumento;
        private CheckBox chkMovilidad;
        private SplitContainer splitResidentes;
        private DataGridView dgvResidentes;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colCorreo;
        private DataGridViewCheckBoxColumn colMovilidad;
        private DataGridViewButtonColumn colVehiculos;
    }
}