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
    public partial class FrmPropiedades : Form
    {
        private ComboBox comboBox_Provincia;
        private ComboBox comboBox_Partido;
        private ComboBox comboBox_Localidad;
        
        private Provincia provinciaSeleccionada;
        private Partido partidoSeleccionado;
        private Localidad localidadSeleccionada;

        private Guid idProvinciaSeleccionada; // Variable para almacenar el Guid de la provincia seleccionada
        private Guid idPartidoSeleccionado;
        private Guid idLocalidadSeleccionada;

        public FrmPropiedades()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            comboBoxProvincia.SelectedIndexChanged += comboBoxProvincia_SelectedIndexChanged;
            comboBoxPartido.SelectedIndexChanged += comboBoxPartido_SelectedIndexChanged;
            comboBoxLocalidad.SelectedIndexChanged += comboBoxLocalidad_SelectedIndexChanged;

            // Llamar al método para obtener y mostrar todos los tipos de inmuebles
            MostrarTodosLosTiposDeInmuebles();

            // Vincula el evento checkBox1_CheckedChanged al control CheckBox1
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // Bloquear todos los campos y botones al inicializar el formulario
            BloquearCampos();
        }

        private void FrmPropiedades_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mYIMBODataSet4.ProvinciaSelectAll'
            this.provinciaSelectAllTableAdapter.Fill(this.mYIMBODataSet4.ProvinciaSelectAll);

            // TODO: esta línea de código carga datos en la tabla 'mYIMBODataSet1.Provincia'
            //this.provinciaTableAdapter1.Fill(this.mYIMBODataSet1.Provincia);
            // TODO: esta línea de código carga datos en la tabla 'mYIMBODataSet.Provincia'
            this.provinciaTableAdapter.Fill(this.mYIMBODataSet.Provincia);

            // TODO: esta línea de código carga datos en la tabla 'mYIMBODataSet2.Partido'
            this.partidoTableAdapter.Fill(this.mYIMBODataSet2.Partido);

            // TODO: esta línea de código carga datos en la tabla 'mYIMBODataSet3.Localidad'
            // Puede moverla o quitarla según sea necesario.
            this.localidadTableAdapter.Fill(this.mYIMBODataSet3.Localidad);

            LimpiarCampos();


        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblTipoPropiedad.Text = LanguageBLL.Traducir("Tipo de Propiedad", lang);
                lblDireccion.Text = LanguageBLL.Traducir("Dirección", lang);
                lblDescripcion.Text = LanguageBLL.Traducir("Descripción", lang);
                lblProvincia.Text = LanguageBLL.Traducir("Provincia", lang);
                lblPartido.Text = LanguageBLL.Traducir("Partido", lang);
                lblLocalidad.Text = LanguageBLL.Traducir("Localidad", lang);
                lblTasarPropiedad.Text = LanguageBLL.Traducir("Tasar Propiedad", lang);
                lblPrecioVenta.Text = LanguageBLL.Traducir("Precio de Venta", lang);
                lblPrecioAlquiler.Text = LanguageBLL.Traducir("Precio de Alquiler", lang);

                groupBox1.Text = LanguageBLL.Traducir("Tasación", lang);

                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);
                btnAgregar.Text = LanguageBLL.Traducir("Agregar", lang);
                btnActualizar.Text = LanguageBLL.Traducir("Actualizar", lang);
                btnEliminar.Text = LanguageBLL.Traducir("Eliminar", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Llenar el ComboBox con datos de la base de datos
            this.provinciaTableAdapter.Fill(this.mYIMBODataSet.Provincia);

            //Verifica si hay un elemento seleccionado en el ComboBox
            if (comboBoxProvincia.SelectedItem != null && comboBoxProvincia.SelectedItem is DataRowView)
            {
                //Obtén la fila seleccionada del BindingSource
                DataRowView provinciaSeleccionada = (DataRowView)comboBoxProvincia.SelectedItem;

                //Obtiene el idprovincia de la fila seleccionada
                if (provinciaSeleccionada.Row["idprovincia"] != DBNull.Value)
                {
                    idProvinciaSeleccionada = (Guid)provinciaSeleccionada.Row["idprovincia"];

                    //Puedes usar idProvinciaSeleccionada como sea necesario en tu aplicación
                    //MessageBox.Show($"Guid de la provincia seleccionada: {idProvinciaSeleccionada}");
                }
            }
        }



        private void comboBoxPartido_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Verifica si hay un elemento seleccionado en el ComboBox
            if (comboBoxPartido.SelectedItem != null && comboBoxPartido.SelectedItem is DataRowView)
            {
                //Obtén la fila seleccionada del BindingSource
                DataRowView partidoSeleccionado = (DataRowView)comboBoxPartido.SelectedItem;

                //Obtiene el idprovincia de la fila seleccionada
                if (partidoSeleccionado.Row["idpartido"] != DBNull.Value)
                {
                    idPartidoSeleccionado = (Guid)partidoSeleccionado.Row["idpartido"];

                    //Puedes usar idProvinciaSeleccionada como sea necesario en tu aplicación
                    //MessageBox.Show($"Guid de la provincia seleccionada: {idProvinciaSeleccionada}");
                }
            }
        }




        private void comboBoxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verifica si hay un elemento seleccionado en el ComboBox
            if (comboBoxLocalidad.SelectedItem != null && comboBoxLocalidad.SelectedItem is DataRowView)
            {
                //Obtén la fila seleccionada del BindingSource
                DataRowView localidadSeleccionada = (DataRowView)comboBoxLocalidad.SelectedItem;

                //Obtiene el idprovincia de la fila seleccionada
                if (localidadSeleccionada.Row["idlocalidad"] != DBNull.Value)
                {
                    idLocalidadSeleccionada = (Guid)localidadSeleccionada.Row["idlocalidad"];

                    //Puedes usar idProvinciaSeleccionada como sea necesario en tu aplicación
                    //MessageBox.Show($"Guid de la provincia seleccionada: {idProvinciaSeleccionada}");
                }
            }
        }


        private void BloquearCampos()
        {
            txtPrecioVenta.Enabled = false;
            txtPrecioAlquiler.Enabled = false;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            txtPrecioVenta.Enabled = true;
            txtPrecioAlquiler.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Si checkBox1 está marcado, habilita los campos y botones
                DesbloquearCampos();
            }
            else
            {
                // Si checkBox1 está desmarcado, bloquea los campos y botones
                BloquearCampos();
            }
        }

        private void LimpiarCampos()
        {
            ComboBoxTipoPropiedad.SelectedItem = null;
            txtDireccion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            comboBoxProvincia.SelectedItem = null;
            comboBoxPartido.SelectedItem = null;
            comboBoxLocalidad.SelectedItem = null;

            txtPrecioAlquiler.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
        }

        //private void LimpiarCampos()
        //{
        //    //Limpiar los valores de los TextBox y el CheckBox
        //    txtDireccion.Clear();
        //    txtDescripcion.Clear();

        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los campos del formulario
            string tipoPropiedad = ComboBoxTipoPropiedad.SelectedItem?.ToString();
            string direccion = txtDireccion.Text;
            string descripcion = txtDescripcion.Text;
            Guid IdProvincia = idProvinciaSeleccionada;
            Guid IdPartido = idPartidoSeleccionado;
            Guid IdLocalidad = idLocalidadSeleccionada;

            // Verifica que las selecciones de tipo de propiedad, dirección y descripción no estén vacías
            if (!string.IsNullOrEmpty(tipoPropiedad) && !string.IsNullOrEmpty(direccion) && !string.IsNullOrEmpty(descripcion))
            {
                // Crea una nueva instancia de la clase TipoInmueble con los datos del formulario
                TipoInmueble tipoInmueble = new TipoInmueble
                {
                    TipoInmuebleNombre = tipoPropiedad,
                    Direccion = direccion,
                    Descripcion = descripcion,
                    IdProvincia = IdProvincia,
                    IdPartido = IdPartido,
                    IdLocalidad = IdLocalidad
                };

                // Intenta agregar el nuevo tipo de inmueble utilizando el TipoInmuebleManager
                bool exito = TipoInmuebleManager.Instance.AgregarTipoInmueble(tipoInmueble);

                if (exito)
                {
                    MessageBox.Show("Tipo de propiedad agregado correctamente.");
                    LimpiarCampos(); // Método para limpiar los campos del formulario, si es necesario
                    MostrarTodosLosTiposDeInmuebles(); // Recarga la grilla
                }
                else
                {
                    MessageBox.Show("Error al agregar el tipo de propiedad. Por favor, inténtelo de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios. Tipo de Propiedad-Dirección-Descripcion");
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Llenar el ComboBox de Provincia y manejar la selección
                comboBoxProvincia_SelectedIndexChanged(sender, e);

                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridViewPropiedades.SelectedRows.Count > 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                    // Accede a los valores de las celdas de la fila seleccionada
                    Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                    string nuevoTipoPropiedad = ComboBoxTipoPropiedad.Text;
                    string nuevaDireccion = txtDireccion.Text;
                    string nuevaDescripcion = txtDescripcion.Text;

                    // Llamada a los métodos de selección para actualizar las variables de partido y localidad
                    comboBoxPartido_SelectedIndexChanged(sender, e);
                    comboBoxLocalidad_SelectedIndexChanged(sender, e);

                    // Crear una instancia de TipoInmueble con los nuevos valores
                    TipoInmueble tipoInmuebleActualizado = new TipoInmueble
                    {
                        IdTipoInmueble = idTipoInmueble,
                        TipoInmuebleNombre = nuevoTipoPropiedad,
                        Direccion = nuevaDireccion,
                        Descripcion = nuevaDescripcion,
                        IdProvincia = idProvinciaSeleccionada,
                        IdPartido = idPartidoSeleccionado,
                        IdLocalidad = idLocalidadSeleccionada
                    };

                    // Llamada al método de servicio para actualizar el tipo de inmueble
                    bool exito = TipoInmuebleManager.Instance.ActualizarTipoInmueble(tipoInmuebleActualizado);

                    if (exito)
                    {
                        MessageBox.Show("Tipo de propiedad actualizado correctamente.");
                        LimpiarCampos(); // Método para limpiar los campos del formulario, si es necesario
                        MostrarTodosLosTiposDeInmuebles(); // Recarga la grilla
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el tipo de propiedad. Por favor, inténtelo de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridViewPropiedades.SelectedRows.Count > 0)
                {
                    // Obtener el IdTipoInmueble de la fila seleccionada en la DataGridView
                    Guid idTipoInmueble = (Guid)dataGridViewPropiedades.SelectedRows[0].Cells["IdTipoInmueble"].Value;

                    // Preguntar al usuario si realmente desea eliminar la propiedad
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta propiedad?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Eliminar la tasación asociada
                        bool exitoTasacion = TasacionManager.Instance.EliminarTasacion(idTipoInmueble);

                        if (exitoTasacion)
                        {
                            // Eliminar el tipo de inmueble
                            bool exitoTipoInmueble = TipoInmuebleManager.Instance.EliminarTipoInmueble(idTipoInmueble);

                            if (exitoTipoInmueble)
                            {
                                MessageBox.Show("Propiedad eliminada correctamente.");
                                MostrarTodosLosTiposDeInmuebles(); // Recargar la grilla
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar la propiedad. Por favor, inténtelo de nuevo.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la tasación asociada. Por favor, inténtelo de nuevo.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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



                //Cambia los nombres de las columnas programáticamente...
                // Asigna la lista de tipos de inmuebles al DataGridView
                dataGridViewPropiedades.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewPropiedades.DataSource = tiposDeInmuebles;

                // Cambia los nombres de las columnas programáticamente

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
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al cargar los tipos de inmuebles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        
        private void dataGridViewPropiedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                    string precioalquiler = selectedRow.Cells["PrecioAlquiler"].Value.ToString();

                    // Cargar valores en los controles del formulario
                    ComboBoxTipoPropiedad.SelectedItem = tipoPropiedad;
                    txtDireccion.Text = direccion;
                    txtDescripcion.Text = descripcion;

                    // Cargar nombres de provincia, partido y localidad en los ComboBox correspondientes

                    // Obtener y cargar Provincia
                    Provincia provincia = ProvinciaManager.Instance.ObtenerProvinciaPorId(idProvincia);
                    comboBoxProvincia.SelectedValue = idProvincia;

                    // Obtener y cargar Partido
                    //Partido partido = (Partido)PartidoManager.Instance.ObtenerPartidosPorId(idPartido);
                    Partido partido = PartidoManager.Instance.ObtenerPartidosPorId(idPartido);
                    comboBoxPartido.SelectedValue = idPartido;

                    // Obtener y cargar Localidad
                    Localidad localidad = LocalidadManager.Instance.ObtenerLocalidadPorId(idLocalidad);
                    comboBoxLocalidad.SelectedValue = idLocalidad;

                    txtPrecioVenta.Text = precioventa;
                    txtPrecioAlquiler.Text = precioalquiler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Agregar Tasación
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verifica si checkBox1 está marcado antes de permitir la acción
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Por favor, marque la casilla antes de agregar.");
                return; // No permite la acción si checkBox1 no está marcado
            }

            // Intenta convertir los valores de texto a enteros
            if (int.TryParse(txtPrecioVenta.Text, out int precioVenta) && int.TryParse(txtPrecioAlquiler.Text, out int precioAlquiler))
            {
                // Obtiene el IdTipoInmueble de la fila seleccionada en el DataGridView
                Guid idTipoInmueble = (Guid)dataGridViewPropiedades.SelectedRows[0].Cells["IdTipoInmueble"].Value;

                // Crea una nueva instancia de Tasacion
                Tasacion tasacion = new Tasacion
                {
                    IdTasacion = Guid.NewGuid(), // Genera un nuevo Id de Tasacion
                    ImporteVenta = precioVenta,
                    ImporteAlquiler = precioAlquiler,
                    Fecha = DateTime.Now, // Establece la fecha actual como fecha de la tasación
                    IdTipoInmueble = idTipoInmueble
                };

                // Intenta agregar la tasación utilizando el TasacionManager
                bool exito = TasacionManager.Instance.AgregarTasacion(tasacion);

                if (exito)
                {
                    MessageBox.Show("Tasación agregada correctamente.");
                    // Recarga la grilla de propiedades después de agregar la tasación
                    MostrarTodosLosTiposDeInmuebles();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar la tasación. Por favor, inténtelo de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para precio de venta y precio de alquiler.");
            }


        }

        //Actualizar Tasación
        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        //Borrar Tasación
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }

}
