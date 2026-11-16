namespace ParkFlow.Presentacion
{
    partial class FrMapa
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
            lblResumen = new Label();
            btnActualizar = new Button();
            pbMapa = new PictureBox();
            lblDetalle = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMapa).BeginInit();
            SuspendLayout();
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResumen.Location = new Point(12, 15);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(0, 28);
            lblResumen.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(990, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(148, 34);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // pbMapa
            // 
            pbMapa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbMapa.BackColor = Color.White;
            pbMapa.BorderStyle = BorderStyle.FixedSingle;
            pbMapa.Cursor = Cursors.Hand;
            pbMapa.Location = new Point(12, 56);
            pbMapa.Name = "pbMapa";
            pbMapa.Size = new Size(1126, 494);
            pbMapa.TabIndex = 2;
            pbMapa.TabStop = false;
            pbMapa.Paint += pbMapa_Paint;
            pbMapa.MouseClick += pbMapa_MouseClick;
            pbMapa.Resize += pbMapa_Resize;
            // 
            // lblDetalle
            // 
            lblDetalle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetalle.Location = new Point(12, 556);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(1126, 34);
            lblDetalle.TabIndex = 3;
            lblDetalle.Text = "Haga clic en una plaza para ver su detalle.";
            lblDetalle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrMapa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 600);
            Controls.Add(lblResumen);
            Controls.Add(btnActualizar);
            Controls.Add(pbMapa);
            Controls.Add(lblDetalle);
            MinimumSize = new Size(1018, 647);
            Name = "FrMapa";
            Text = "Mapa de plazas";
            Activated += FrMapa_Activated;
            Load += FrMapa_Load;
            ((System.ComponentModel.ISupportInitialize)pbMapa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResumen;
        private Button btnActualizar;
        private PictureBox pbMapa;
        private Label lblDetalle;
    }
}
