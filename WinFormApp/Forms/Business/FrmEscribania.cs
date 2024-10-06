using BLL;
using DomainModel;
using Services.BLL;
using Services.DomainModel;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormApp.Forms.Business
{
    public partial class FrmEscribania : Form
    {
        public FrmEscribania()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);
        }

        private void FrmEscribania_Load(object sender, EventArgs e)
        {
            ListarTodasLasEscribanias();
        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblNombreEscribania.Text = LanguageBLL.Traducir("Nombre Escribania", lang);
                lblDireccion.Text = LanguageBLL.Traducir("Dirección", lang);
                lblTelefono.Text = LanguageBLL.Traducir("Telefono", lang);
                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtén los datos del formulario
            string razonSocial = txtNombreEscribania.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            // Crea una nueva instancia de la clase Escribania con los datos del formulario
            Escribania nuevaEscribania = new Escribania
            {
                IdEscribania = Guid.NewGuid(), // Genera un nuevo ID para la escribanía
                RazonSocial = razonSocial,
                Direccion = direccion,
                Telefono = telefono
            };

            // Intenta agregar la nueva escribanía utilizando el TipoInmuebleManager
            bool exito = EscribaniaManager.Instance.AgregarEscribania(nuevaEscribania);

            if (exito)
            {
                MessageBox.Show("Escribanía agregada correctamente.");
                LimpiarCampos(); // Método para limpiar los campos del formulario
                // Después de actualiza, recarga la lista si es necesario
                ListarTodasLasEscribanias();
            }
            else
            {
                MessageBox.Show("Error al agregar la escribanía. Por favor, inténtelo de nuevo.");
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario después de agregar una escribanía
            txtNombreEscribania.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        public void ListarTodasLasEscribanias()
        {

            try
            {
                // Obtener la lista de todos los usuarios utilizando el método GetAllEscribanias
                var escribanias = EscribaniaManager.Instance.ObtenerTodasLasEscribanias();

                // Asignar la lista de usuarios al DataGridView
                dataGridView1.DataSource = null; // Primero establece el origen de datos a null
                dataGridView1.DataSource = escribanias;

                // Cambiar los nombres de las columnas programáticamente

                // Dejo oculto el campo
                dataGridView1.Columns["Idescribania"].Visible = false;

                dataGridView1.Columns["RazonSocial"].HeaderText = "Nombre Escribania (RazonSocial)";
                dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
                dataGridView1.Columns["Telefono"].HeaderText = "Telefono";


                LimpiarCampos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada

                Guid idescribania = (Guid)selectedRow.Cells["Idescribania"].Value;
                string nombreEscribania = selectedRow.Cells["RazonSocial"].Value.ToString();
                string direccion = selectedRow.Cells["Direccion"].Value.ToString();
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();

                txtNombreEscribania.Text = nombreEscribania;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;

            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener el IdUsuario de la fila seleccionada
                    Guid idescribania = (Guid)dataGridView1.SelectedRows[0].Cells["Idescribania"].Value;

                    // Obtener los valores actualizados de los TextBox y CheckBox
                    string nuevonombreEscribania = txtNombreEscribania.Text;
                    string nuevoDireccion = txtDireccion.Text;
                    string nuevoTelefono = txtTelefono.Text;

                    EscribaniaManager.Instance.EliminarEscribania(idescribania);

                }

                // Después de actualiza, recarga la lista si es necesario
                ListarTodasLasEscribanias();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener el Idescribania de la fila seleccionada
                    Guid idescribania = (Guid)dataGridView1.SelectedRows[0].Cells["Idescribania"].Value;

                    // Obtener los valores actualizados de los TextBox y CheckBox
                    string nuevoEscribania = txtNombreEscribania.Text;
                    string nuevoDireccion = txtDireccion.Text;
                    string nuevoTelefono = txtTelefono.Text;



                    // Crear un objeto Usuario con los valores actualizados
                    Escribania escribanias = new Escribania
                    {
                        IdEscribania = idescribania,
                        RazonSocial = nuevoEscribania,
                        Direccion = nuevoDireccion,
                        Telefono = nuevoTelefono

                    };

                    // Llamar al método en UsuarioManager para actualizar el usuario
                    bool actualizacionExitosa = EscribaniaManager.Instance.ActualizarEscribania(escribanias);

                    if (actualizacionExitosa)
                    {
                        // Obtener la lista actualizada de usuarios
                        //var escribaniasActualizadas = UsuarioManager.Instance.ListarTodos();
                        var escribaniasActualizadas = EscribaniaManager.Instance.ObtenerTodasLasEscribanias();

                        // Asignar la lista como fuente de datos del DataGridView
                        dataGridView1.DataSource = escribaniasActualizadas;

                        // Volver a enlazar la fuente de datos del DataGridView
                        ListarTodasLasEscribanias();

                        MessageBox.Show("Registro actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la Escribania.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al modificar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {

        }
    }
}
