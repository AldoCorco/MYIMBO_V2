using BLL;
using DomainModel;
using Services.BLL;
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

namespace WinFormApp.Forms.Business
{
    public partial class FrmPropietario : Form
    {
        public FrmPropietario()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            // Llamar al método para obtener y mostrar todos los tipos de inmuebles
            MostrarTodosLosTiposDeInmuebles();

            CargarPropietarios();
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mYIMBO_LocalidadDataSet.Localidad' Puede moverla o quitarla según sea necesario.
            this.localidadTableAdapter.Fill(this.mYIMBO_LocalidadDataSet.Localidad);

        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                //lblNumeroLegajo.Text = LanguageBLL.Traducir("Numero de Legajo", lang);
                lblDescripcion.Text = LanguageBLL.Traducir("Descripción", lang);
                lblDireccion.Text = LanguageBLL.Traducir("Dirección", lang);
                lblNombre.Text = LanguageBLL.Traducir("Nombre", lang);

                
                lblDNI.Text = LanguageBLL.Traducir("DNI", lang);
                lblFechaNacimiento.Text = LanguageBLL.Traducir("Fecha de Nacimiento", lang);
                lblTelefono.Text = LanguageBLL.Traducir("Telefono", lang);

                lblApellido.Text = LanguageBLL.Traducir("Apellido", lang);
                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ObtenerNombresUbicacion(TipoInmueble tipoInmueble)
        {
            Provincia provinciaSeleccionada = ProvinciaManager.Instance.ObtenerProvinciaPorId(tipoInmueble.IdProvincia);
            tipoInmueble.NombreProvincia = provinciaSeleccionada?.NombreProvincia ?? "Desconocido";

            Partido partidoSeleccionado = PartidoManager.Instance.ObtenerNombrePartidoPorId(tipoInmueble.IdPartido);
            tipoInmueble.NombrePartido = partidoSeleccionado?.NombrePartido ?? "Desconocido";

            Localidad localidadSeleccionada = LocalidadManager.Instance.ObtenerNombrelocalidadPorId(tipoInmueble.IdLocalidad);
            tipoInmueble.NombreLocalidad = localidadSeleccionada?.NombreLocalidad ?? "Desconocido";
        }

        private void MostrarTodosLosTiposDeInmuebles()
        {
            try
            {
                var tiposDeInmuebles = TipoInmuebleManager.Instance.ObtenerTodosLosTiposDeInmuebles();

                // Itera sobre la lista y obtén el nombre de la provincia, partido y localidad para cada tipo de inmueble
                foreach (var tipoInmueble in tiposDeInmuebles)
                {
                    ObtenerNombresUbicacion(tipoInmueble);

                    // Obtiene la tasación para el tipo de inmueble actual
                    Tasacion tasacion = TasacionManager.Instance.ObtenerTasacionPorId(tipoInmueble.IdTipoInmueble);
                    if (tasacion != null)
                    {
                        tipoInmueble.PrecioVenta = tasacion.ImporteVenta;
                        tipoInmueble.PrecioAlquiler = tasacion.ImporteAlquiler;
                    }
                    else
                    {
                        tipoInmueble.PrecioVenta = 0; // Valor por defecto si no se encuentra la tasación
                        tipoInmueble.PrecioAlquiler = 0; // Valor por defecto si no se encuentra la tasación
                    }
                }

                // Asigna la lista de tipos de inmuebles al DataGridView
                dataGridViewPropiedades.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewPropiedades.DataSource = tiposDeInmuebles;

                // Deja oculto el campo
                dataGridViewPropiedades.Columns["IdTipoInmueble"].Visible = false;
                dataGridViewPropiedades.Columns["IdProvincia"].Visible = false;
                dataGridViewPropiedades.Columns["IdPartido"].Visible = false;
                dataGridViewPropiedades.Columns["IdLocalidad"].Visible = false;

                dataGridViewPropiedades.Columns["TipoInmuebleNombre"].HeaderText = "Tipo de Propiedad";
                dataGridViewPropiedades.Columns["Direccion"].HeaderText = "Dirección";
                dataGridViewPropiedades.Columns["Descripcion"].HeaderText = "Descripción";
                dataGridViewPropiedades.Columns["NombreProvincia"].HeaderText = "Provincia";
                dataGridViewPropiedades.Columns["NombrePartido"].HeaderText = "Partido";
                dataGridViewPropiedades.Columns["NombreLocalidad"].HeaderText = "Localidad";

                dataGridViewPropiedades.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
                dataGridViewPropiedades.Columns["PrecioAlquiler"].HeaderText = "Precio de Alquiler";
                //LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al cargar los tipos de inmuebles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CargarPropietarios()
        {
            try
            {
                // Obtener la lista de propietarios desde el PropietarioManager
                var propietarios = PropietarioManager.Instance.ObtenerTodosLosPropietarios();

                // Asignar la lista de propietarios al DataGridView
                dataGridViewPropietario.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewPropietario.DataSource = propietarios;

                // Ocultar la columna IdPropietario si es necesario
                dataGridViewPropietario.Columns["IdPropietario"].Visible = false;


                dataGridViewPropietario.Columns["LegajoPropietario"].HeaderText = "Legajo Propietario";
                dataGridViewPropietario.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewPropietario.Columns["Apellido"].HeaderText = "Apellido";
                dataGridViewPropietario.Columns["DNI"].HeaderText = "DNI";
                dataGridViewPropietario.Columns["FechaNacimiento"].HeaderText = "FechaNacimiento";
                dataGridViewPropietario.Columns["Telefono"].HeaderText = "Telefono";

                dataGridViewPropietario.Columns["IdTipoInmueble"].Visible = false;
                // Limpiar los campos del formulario después de cargar los propietarios
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los propietarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtLegajoPropietario.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            dateTimePickerFechaNac.Value = DateTime.Now; // O la fecha predeterminada que desees
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay una fila seleccionada en el dataGridViewPropiedades
                if (dataGridViewPropiedades.SelectedRows.Count > 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                    // Obtiene los valores de las celdas de la fila seleccionada
                    Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                    int legajoPropietario = int.Parse(txtLegajoPropietario.Text);
                    int dni = int.Parse(txtDNI.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string telefono = txtTelefono.Text;
                    DateTime fechaNac = dateTimePickerFechaNac.Value;

                    // Crea una instancia de Propietario con los valores obtenidos
                    Propietario propietario = new Propietario
                    {
                        IdPropietario = Guid.NewGuid(), // Genera un nuevo Id
                        LegajoPropietario = legajoPropietario,
                        DNI = dni,
                        Nombre = nombre,
                        Apellido = apellido,
                        Telefono = telefono,
                        FechaNacimiento = fechaNac,
                        IdTipoInmueble = idTipoInmueble
                    };

                    // Llama al método AgregarPropietario de PropietarioManager
                    bool exito = PropietarioManager.Instance.AgregarPropietario(propietario);

                    if (exito)
                    {
                        // Crear un log exitoso
                        string logMessage = $"Se agregó correctamente el propietario: {propietario.Nombre}";
                        Log logSuccess = new Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logMessage,
                            Severity = Severity.Info,
                            Fecha_txr = DateTime.Now
                        };

                        MessageBox.Show("Propietario agregado correctamente.");
                        LimpiarCampos(); // Método para limpiar los campos del formulario

                        // Actualiza el DataGridView con los propietarios actualizados
                        CargarPropietarios();
                    }
                    else
                    {
                        // Crear un log de error
                        string logErrorMessage = "Error al agregar el propietario. Por favor, inténtelo de nuevo.";
                        Log logError = new Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logErrorMessage,
                            Severity = Severity.Error,
                            Fecha_txr = DateTime.Now
                        };

                        MessageBox.Show(logErrorMessage);
                        MessageBox.Show("Error al agregar el propietario. Por favor, inténtelo de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una propiedad en la lista antes de agregar un propietario.");
                }
            }
            catch (Exception ex)
            {
                // Crear un log de error crítico
                string logCriticalErrorMessage = $"Error crítico al procesar la operación: {ex.Message}";
                Log logCriticalError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logCriticalErrorMessage,
                    Severity = Severity.CriticalError,
                    Fecha_txr = DateTime.Now
                };

                MessageBox.Show(logCriticalErrorMessage, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dataGridViewPropietario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewPropietario.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idPropietario = (Guid)selectedRow.Cells["IdPropietario"].Value;
                int legajoPropietario = (int)selectedRow.Cells["LegajoPropietario"].Value;
                string nombre = selectedRow.Cells["Nombre"].Value.ToString();
                string apellido = selectedRow.Cells["Apellido"].Value.ToString();
                int dni = (int)selectedRow.Cells["Dni"].Value;
                DateTime fechaNacimiento = (DateTime)selectedRow.Cells["FechaNacimiento"].Value;
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                

                // Llamar al método para cargar los datos en FrmPropietario
                CargarDatosEnFrmPropietario(idPropietario, legajoPropietario, nombre, apellido, dni, fechaNacimiento, telefono, idTipoInmueble);
            }
        }

        private void CargarDatosEnFrmPropietario(Guid idPropietario, int legajoPropietario, string nombre, string apellido, int dni, DateTime fechaNacimiento, string telefono, Guid idTipoInmueble)
        {
            // Asignar valores a los controles de FrmPropietario
            //txtIdPropietario.Text = idPropietario.ToString();
            txtLegajoPropietario.Text = legajoPropietario.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtDNI.Text = dni.ToString();
            dateTimePickerFechaNac.Value = fechaNacimiento;
            txtTelefono.Text = telefono;


            // Obtener dirección y descripción usando TipoInmuebleManager
            TipoInmueble tipoInmueble = TipoInmuebleManager.Instance.ObtenerTipoInmueblePorId(idTipoInmueble);

            // Asignar valores a los controles adicionales
            txtDireccion.Text = tipoInmueble.Direccion;
            txtDescripcion.Text = tipoInmueble.Descripcion;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridViewPropietario.SelectedRows.Count > 0)
                {
                    // Obtener el IdPropietario de la fila seleccionada
                    Guid idPropietario = (Guid)dataGridViewPropietario.SelectedRows[0].Cells["IdPropietario"].Value;

                    // Obtener los valores actualizados de los TextBox y DateTimePicker
                    int nuevoLegajoPropietario = int.Parse(txtLegajoPropietario.Text);
                    string nuevoNombre = txtNombre.Text;
                    string nuevoApellido = txtApellido.Text;
                    int nuevoDNI = int.Parse(txtDNI.Text);
                    DateTime nuevaFechaNac = dateTimePickerFechaNac.Value;
                    string nuevoTelefono = txtTelefono.Text;

                    // Obtener el IdTipoInmueble del propietario seleccionado
                    Guid idTipoInmueble = (Guid)dataGridViewPropietario.SelectedRows[0].Cells["IdTipoInmueble"].Value;

                    // Crear un objeto Propietario con los valores actualizados
                    Propietario propietario = new Propietario
                    {
                        IdPropietario = idPropietario,
                        LegajoPropietario = nuevoLegajoPropietario,
                        Nombre = nuevoNombre,
                        Apellido = nuevoApellido,
                        DNI = nuevoDNI,
                        FechaNacimiento = nuevaFechaNac,
                        Telefono = nuevoTelefono,
                        IdTipoInmueble = idTipoInmueble
                    };

                    // Llamar al método en PropietarioManager para actualizar el propietario
                    bool actualizacionExitosa = PropietarioManager.Instance.ModificarPropietario(propietario);

                    if (actualizacionExitosa)
                    {
                        // Crear un mensaje de log exitoso
                        string logMessage = $"Se actualizó correctamente el propietario: {propietario.Nombre}";
                        Log logSuccess = new Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logMessage,
                            Severity = Severity.Info,
                            Fecha_txr = DateTime.Now
                        };

                        MessageBox.Show("Propietario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los campos del formulario después de la modificación
                        LimpiarCampos();
                    }
                    else
                    {
                        // Crear un mensaje de log de error
                        string logErrorMessage = "Error al actualizar el propietario. Por favor, inténtelo de nuevo.";
                        Log logError = new Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logErrorMessage,
                            Severity = Severity.Error,
                            Fecha_txr = DateTime.Now
                        };


                        MessageBox.Show(logErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Crear un mensaje de log de error crítico
                string logCriticalErrorMessage = $"Error crítico al modificar el propietario: {ex.Message}";
                Log logCriticalError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logCriticalErrorMessage,
                    Severity = Severity.CriticalError,
                    Fecha_txr = DateTime.Now
                };

                MessageBox.Show(logCriticalErrorMessage, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridViewPropietario.SelectedRows.Count > 0)
                {
                    // Obtener el IdPropietario de la fila seleccionada
                    Guid idPropietario = (Guid)dataGridViewPropietario.SelectedRows[0].Cells["IdPropietario"].Value;

                    // Confirmar si realmente desea borrar el propietario
                    DialogResult resultado = MessageBox.Show("¿Está seguro de que desea borrar este propietario?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Llamar al método en PropietarioManager para borrar el propietario
                        bool borradoExitoso = PropietarioManager.Instance.BorrarPropietario(idPropietario);

                        if (borradoExitoso)
                        {
                            MessageBox.Show("Propietario borrado exitosamente.");
                            // Actualizar el DataGridView con los propietarios actualizados
                            CargarPropietarios();
                        }
                        else
                        {
                            MessageBox.Show("Error el Propietario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para borrar.");
                }
            }
            catch (Exception ex)
            {
                // Crear un mensaje de log de error crítico
                string logCriticalErrorMessage = $"Error crítico al intentar borrar el propietario: {ex.Message}";
                Log logCriticalError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logCriticalErrorMessage,
                    Severity = Severity.CriticalError,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error crítico utilizando el logger
                //PropietarioManager.Instance.Logger.Store(logCriticalError);

                MessageBox.Show(logCriticalErrorMessage, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewPropiedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                string tipoPropiedad = selectedRow.Cells["TipoInmuebleNombre"].Value.ToString();
                string direccion = selectedRow.Cells["Direccion"].Value.ToString();
                string descripcion = selectedRow.Cells["Descripcion"].Value.ToString();

                Guid idProvincia = (Guid)selectedRow.Cells["IdProvincia"].Value;
                Guid idPartido = (Guid)selectedRow.Cells["IdPartido"].Value;
                Guid idLocalidad = (Guid)selectedRow.Cells["IdLocalidad"].Value;

                string precioventa = selectedRow.Cells["PrecioVenta"].Value.ToString();
               

                txtDescripcion.Text = descripcion;
                txtDireccion.Text = direccion;
            }
        }
    }
}
