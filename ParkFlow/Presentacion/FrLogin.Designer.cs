namespace ParkFlow.Presentacion
{
    partial class FrLogin
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
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Login";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 75);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            txtUsuario.Location = new Point(30, 98);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 27);
            txtUsuario.TabIndex = 2;
            //
            // lblClave
            //
            lblClave.AutoSize = true;
            lblClave.Location = new Point(30, 138);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(45, 20);
            lblClave.TabIndex = 3;
            lblClave.Text = "Clave";
            //
            // txtClave
            //
            txtClave.Location = new Point(30, 161);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(300, 27);
            txtClave.TabIndex = 4;
            txtClave.UseSystemPasswordChar = true;
            //
            // btnIngresar
            //
            btnIngresar.Location = new Point(30, 212);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(140, 36);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(190, 212);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(140, 36);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // FrLogin
            //
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new Size(360, 275);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ParkFlow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnIngresar;
        private Button btnSalir;
    }
}
