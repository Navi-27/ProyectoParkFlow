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
            tlpBotones = new TableLayoutPanel();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
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
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitResidentes);
            splitContainer1.Size = new Size(1709, 884);
            splitContainer1.Panel1MinSize = 620;
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
            groupBox1.Size = new Size(851, 857);
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
            tlpCentro.Size = new Size(845, 829);
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
            tlpCampos.Controls.Add(comboBox1, 1, 1);
            tlpCampos.Controls.Add(label2, 0, 2);
            tlpCampos.Controls.Add(textBox1, 1, 2);
            tlpCampos.Controls.Add(label3, 0, 3);
            tlpCampos.Controls.Add(textBox2, 1, 3);
            tlpCampos.Controls.Add(label4, 0, 4);
            tlpCampos.Controls.Add(textBox3, 1, 4);
            tlpCampos.Controls.Add(label5, 0, 5);
            tlpCampos.Controls.Add(textBox4, 1, 5);
            tlpCampos.Controls.Add(label6, 0, 6);
            tlpCampos.Controls.Add(textBox5, 1, 6);
            tlpCampos.Controls.Add(checkBox1, 1, 7);
            tlpCampos.Controls.Add(tlpBotones, 0, 8);
            tlpCampos.Location = new Point(129, 200);
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
            tlpCampos.SetColumnSpan(tlpBuscar, 2);
            tlpCampos.SetColumnSpan(tlpBotones, 2);
            tlpCampos.Size = new Size(586, 430);
            tlpCampos.TabIndex = 0;
            // 
            // tlpBuscar
            // 
            tlpBuscar.AutoSize = true;
            tlpBuscar.ColumnCount = 2;
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle());
            tlpBuscar.Controls.Add(txtBuscar, 0, 0);
            tlpBuscar.Controls.Add(btnBuscar, 1, 0);
            tlpBuscar.Dock = DockStyle.Fill;
            tlpBuscar.Margin = new Padding(0, 0, 0, 24);
            tlpBuscar.Name = "tlpBuscar";
            tlpBuscar.RowCount = 1;
            tlpBuscar.RowStyles.Add(new RowStyle());
            tlpBuscar.Size = new Size(586, 46);
            tlpBuscar.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Margin = new Padding(3, 6, 3, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar residente por documento o nombre";
            txtBuscar.Size = new Size(470, 27);
            txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = true;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Margin = new Padding(6, 3, 3, 3);
            btnBuscar.MinimumSize = new Size(100, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 40);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // tlpBotones
            // 
            tlpBotones.AutoSize = true;
            tlpBotones.ColumnCount = 4;
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBotones.Controls.Add(btnAgregar, 0, 0);
            tlpBotones.Controls.Add(btnActualizar, 1, 0);
            tlpBotones.Controls.Add(btnEliminar, 2, 0);
            tlpBotones.Controls.Add(btnLimpiar, 3, 0);
            tlpBotones.Dock = DockStyle.Fill;
            tlpBotones.Margin = new Padding(0, 24, 0, 0);
            tlpBotones.Name = "tlpBotones";
            tlpBotones.RowCount = 1;
            tlpBotones.RowStyles.Add(new RowStyle());
            tlpBotones.Size = new Size(586, 46);
            tlpBotones.TabIndex = 14;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
            btnAgregar.Margin = new Padding(3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 40);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Margin = new Padding(3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(140, 40);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.Margin = new Padding(3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(140, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
            btnLimpiar.Margin = new Padding(3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 40);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.CheckAlign = ContentAlignment.MiddleRight;
            checkBox1.Margin = new Padding(3, 6, 3, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(164, 24);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Movilidad Reducida";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "CC - Cedula De Ciudadania", "CE - Cédula de Extranjería", "TI - Tarjeta de Identidad", "PA - Pasaporte", "DNI - Documento Nacional de Identidad" });
            comboBox1.Margin = new Padding(3, 6, 3, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(374, 28);
            comboBox1.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Margin = new Padding(3, 6, 3, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(374, 27);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Margin = new Padding(3, 6, 3, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(374, 27);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Margin = new Padding(3, 6, 3, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(374, 27);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Margin = new Padding(3, 6, 3, 6);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(374, 27);
            textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox5.Margin = new Padding(3, 6, 3, 6);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(374, 27);
            textBox5.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Margin = new Padding(3, 6, 3, 6);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "Tipo De Documento";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Margin = new Padding(3, 6, 3, 6);
            label2.Name = "label2";
            label2.TabIndex = 1;
            label2.Text = "Documento";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Margin = new Padding(3, 6, 3, 6);
            label3.Name = "label3";
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Margin = new Padding(3, 6, 3, 6);
            label4.Name = "label4";
            label4.TabIndex = 3;
            label4.Text = "Apellidos";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Margin = new Padding(3, 6, 3, 6);
            label5.Name = "label5";
            label5.TabIndex = 4;
            label5.Text = "Telefono";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Margin = new Padding(3, 6, 3, 6);
            label6.Name = "label6";
            label6.TabIndex = 5;
            label6.Text = "Correo";
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
            splitResidentes.Size = new Size(853, 857);
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
            dgvResidentes.Size = new Size(853, 857);
            dgvResidentes.TabIndex = 0;
            dgvResidentes.CellContentClick += dgvResidentes_CellContentClick;
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
            colVehiculos.HeaderText = "Vehiculos";
            colVehiculos.MinimumWidth = 6;
            colVehiculos.Name = "colVehiculos";
            colVehiculos.ReadOnly = true;
            colVehiculos.Text = "Ver Vehiculos";
            colVehiculos.UseColumnTextForButtonValue = true;
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
            splitContainer1.Panel1.PerformLayout();
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
            PerformLayout();
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
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
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