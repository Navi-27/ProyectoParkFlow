using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ParkFlow.Presentacion
{
    public partial class FrResidente : Form
    {
        public FrResidente()
        {
            InitializeComponent();
        }

        private RepositoryPersonas? _personas;

        private void FrResidente_Load(object sender, EventArgs e)
        {
            try
            {
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                CargarResidentes();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se pudo cargar la lista de residentes:\n" + ex.Message, "Residentes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarResidentes()
        {
            if (_personas == null) return;

            dgvResidentes.AutoGenerateColumns = false;
            dgvResidentes.DataSource = null;
            dgvResidentes.DataSource = _personas.GetAll()
                .OfType<Residente>()
                .OrderBy(r => r.Apellido)
                .ToList();
        }

        private void dgvResidentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVehiculos.Index) return;

            if (dgvResidentes.Rows[e.RowIndex].DataBoundItem is Residente residente)
            {
                using var fr = new FrVehiculos(residente);
                fr.ShowDialog(this);
            }
        }
    }
}
