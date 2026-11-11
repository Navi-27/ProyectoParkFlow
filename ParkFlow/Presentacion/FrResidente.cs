using MySqlConnector;
using ParkFlow.Infraestructure;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;
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

        private readonly Image _iconoOjo = Properties.Resources.ojo;
        private RepositoryPersonas? _personas;
        private string? _documentoSeleccionado;

        private void FrResidente_Load(object sender, EventArgs e)
        {
            try
            {
                _personas = RepositoryPersonas.GetInstance(new PersonaSqlStore());
                CargarResidentes();
                Limpiar();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo cargar la lista de residentes:", ex, "Residentes");
            }
        }

        private void CargarResidentes()
        {
            if (_personas == null) return;

            string texto = txtBuscar.Text.Trim();

            dgvResidentes.AutoGenerateColumns = false;
            dgvResidentes.DataSource = null;
            dgvResidentes.DataSource = _personas.GetAll()
                .OfType<Residente>()
                .Where(r => r.Id.Contains(texto)
                         || r.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                         || r.Apellido.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .OrderBy(r => r.Apellido)
                .ToList();
            dgvResidentes.ClearSelection();
        }

        private void Limpiar()
        {
            cmbTipoDocumento.SelectedIndex = -1;
            _documentoSeleccionado = null;
            FormHelper.LimpiarCampos(txtDocumento, txtNombre, txtApellido, txtTelefono, txtCorreo);
            chkMovilidad.Checked = false;
            txtDocumento.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvResidentes.ClearSelection();
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


        private void dgvResidentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colVehiculos.Index)
            {
                dgvResidentes.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Ver vehículos";
            }
        }

        private void dgvResidentes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVehiculos.Index || e.Graphics == null) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            int x = e.CellBounds.Left + (e.CellBounds.Width - _iconoOjo.Width) / 2;
            int y = e.CellBounds.Top + (e.CellBounds.Height - _iconoOjo.Height) / 2;
            e.Graphics.DrawImage(_iconoOjo, x, y, _iconoOjo.Width, _iconoOjo.Height);

            e.Handled = true;
        }

        private void dgvResidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvResidentes.Rows[e.RowIndex].DataBoundItem is Residente r)
            {
                _documentoSeleccionado = r.Id;
                txtDocumento.Text = r.Id;
                txtNombre.Text = r.Nombre;
                txtApellido.Text = r.Apellido;
                txtTelefono.Text = r.Telefono;
                txtCorreo.Text = r.Correo;
                chkMovilidad.Checked = r.MovilidadReducida;

                cmbTipoDocumento.SelectedIndex = -1;
                foreach (object item in cmbTipoDocumento.Items)
                {
                    if (item.ToString()!.StartsWith(r.TipoDocumento + " "))
                    {
                        cmbTipoDocumento.SelectedItem = item;
                        break;
                    }
                }

                txtDocumento.Enabled = false;
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_personas == null) return;

            if (!DatosValidos()) return;

            try
            {
                Residente nuevo = Residente.Create();
                nuevo.TipoDocumento = cmbTipoDocumento.SelectedItem!.ToString()!.Split('-')[0].Trim();
                nuevo.Id = txtDocumento.Text.Trim();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Apellido = txtApellido.Text.Trim();
                nuevo.Telefono = txtTelefono.Text.Trim();
                nuevo.Correo = txtCorreo.Text.Trim();
                nuevo.MovilidadReducida = chkMovilidad.Checked;

                _personas.Add(nuevo);
                _personas.Commit();

                CargarResidentes();
                Limpiar();
            }
            catch (InvalidOperationException ex)
            {
                Mensajes.Aviso(ex.Message, "Residentes");
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo guardar:", ex, "Residentes");
                CargarResidentes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_personas == null || _documentoSeleccionado == null) return;
            if (!Mensajes.Confirmar($"¿Eliminar al Residente {_documentoSeleccionado}?", "Residentes")) return;

            try
            {
                _personas.Delete(_documentoSeleccionado);
                _personas.Commit();
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo eliminar:", ex, "Residentes");
            }
            CargarResidentes();
            Limpiar();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_personas == null || _documentoSeleccionado == null) return;

            if (!DatosValidos()) return;

            try
            {
                Residente? nuevo = _personas.GetById(_documentoSeleccionado) as Residente;
                if(nuevo ==  null) return;
                nuevo.TipoDocumento = cmbTipoDocumento.SelectedItem!.ToString()!.Split('-')[0].Trim();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Apellido = txtApellido.Text.Trim();
                nuevo.Telefono = txtTelefono.Text.Trim();
                nuevo.Correo = txtCorreo.Text.Trim();
                nuevo.MovilidadReducida = chkMovilidad.Checked;

                _personas.Update(nuevo);
                _personas.Commit();

                CargarResidentes();
                Limpiar();
            }
            catch (InvalidOperationException ex)
            {
                Mensajes.Aviso(ex.Message, "Residentes");
            }
            catch (MySqlException ex)
            {
                Mensajes.Error("No se pudo guardar:", ex, "Residentes");
                CargarResidentes();
            }
        }

        private bool DatosValidos()
        {
            if (cmbTipoDocumento.SelectedItem == null || !Validador.Requeridos(txtDocumento, txtNombre, txtApellido, txtTelefono))
            {
                Mensajes.Aviso("Complete tipo de documento, documento, nombre, apellidos y teléfono.", "Residentes");
                return false;
            }
            string tipo = cmbTipoDocumento.SelectedItem.ToString()!.Split('-')[0].Trim();
            if (tipo != "PA" && !Validador.EsSoloNumeros(txtDocumento.Text.Trim()))
            {
                Mensajes.Aviso("El documento solo debe tener números (excepto pasaporte).", "Residentes");
                return false;
            }
            if (!Validador.EsTelefono(txtTelefono.Text.Trim()))
            {
                Mensajes.Aviso("El teléfono debe tener entre 7 y 10 números.", "Residentes");
                return false;
            }
            string correo = txtCorreo.Text.Trim();
            if (correo != "" && !Validador.EsCorreo(correo))
            {
                Mensajes.Aviso("El correo no tiene un formato válido.", "Residentes");
                return false;
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarResidentes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarResidentes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        
    }
}
