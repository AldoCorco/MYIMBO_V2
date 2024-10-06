using BLL;
using BLL.Strategy;
using BLL.Strategy.Alquiler;
using DomainModel;
using Services.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormApp.Forms.Business
{
    public partial class FrmAlquiler : Form
    {
        private AlquilerManager alquilerManager;
        private Label lblMensaje;

        private ICalculadorAlquiler _calculadorAlquiler;

        private bool edadCumpleRequisito = false; // Variable para rastrear si la edad cumple con el requisito
        private Guid idEscribania;
        private Guid idescribania;

        public FrmAlquiler(ICalculadorAlquiler calculadorAlquiler)
        {
            InitializeComponent();
            _calculadorAlquiler = calculadorAlquiler;

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            // Crea una instancia de AlquilerManager
            alquilerManager = AlquilerManager.Instance;

            // Deshabilita los controles por defecto
            DeshabilitarControles();

            // Asocia los controladores de eventos de los CheckBox
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;

            txtEdad.KeyPress += new KeyPressEventHandler(txtEdad_KeyPress);

            // Llamar al método para obtener y mostrar todos los tipos de inmuebles
            MostrarTodosLosTiposDeInmuebles();
            ListarTodasLasEscribanias();
        }

        private void FrmAlquiler_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario inicialmente, deshabilita checkBox1 y checkBox2
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            txtEdad.Focus(); // Pone el foco en el campo de edad
        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblPresentarGarantia.Text = LanguageBLL.Traducir("Presentar Garantiad", lang);
                lblPresentarReciboSueldo.Text = LanguageBLL.Traducir("Presentar Recibo de Sueldo", lang);
                lblSeleccionarPropiedad.Text = LanguageBLL.Traducir("Seleccionar Propiedad", lang);
                //lblTipoInmueble.Text = LanguageBLL.Traducir("Tipo de Inmueble", lang);
                lblDescripcion.Text = LanguageBLL.Traducir("Descripción", lang);
                lblPrecioAlquiler.Text = LanguageBLL.Traducir("Precio Alquiler", lang);
                lblIngresarReserva.Text = LanguageBLL.Traducir("Ingresar Reserva", lang);
                lblSeleccionarEscribania.Text = LanguageBLL.Traducir("Seleccionar Escribania", lang);
                lblNombreEscribania.Text = LanguageBLL.Traducir("Nombre Escribania", lang);
                label6.Text = LanguageBLL.Traducir("Edad", lang);
                lblSeleccionarEscribania.Text = LanguageBLL.Traducir("Seleccionar Escribania", lang);
                label1.Text = LanguageBLL.Traducir("Valor Propiedad", lang);
                label2.Text = LanguageBLL.Traducir("Total Boleto", lang);
                label3.Text = LanguageBLL.Traducir("Total Impuesto", lang);
                label4.Text = LanguageBLL.Traducir("Total Propiedad", lang);

                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);
                btnContrato.Text = LanguageBLL.Traducir("Generar Contrato", lang);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidarEdad()
        {
            if (int.TryParse(txtEdad.Text, out int edad))
            {
                string mensaje = alquilerManager.VerificarEdad(edad, checkBox1.Checked, checkBox2.Checked);

                // Muestra el mensaje como una ventana de alerta
                MostrarMensaje(mensaje);

                if (mensaje == "Edad no permitida para alquilar")
                {
                    // Si la edad no es suficiente para alquilar, desactiva checkBox1 y checkBox2
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                }
                else
                {
                    // Si la edad cumple con los requisitos, activa checkBox1 y checkBox2
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                }

                // Resto del código para habilitar/deshabilitar otros controles según el mensaje obtenido
                HabilitarOtrosControles(mensaje == "Condiciones Completadas");
                //HabilitarOtrosControles();
            }
            else
            {
                MostrarMensaje("Por favor, ingrese una edad válida.");
            }
        }
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o la tecla "Enter"
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter)
            {
                // Si no es un número ni la tecla "Enter", ignora el carácter presionado
                e.Handled = true;
            }

            // Si el usuario presiona "Enter", valida la edad
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidarEdad();
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ValidarEdad(); // Valida la edad y habilita/deshabilita los CheckBox según corresponda

            // Verifica las condiciones de los CheckBox y obtiene el mensaje de validación
            bool estadoCheckBox1 = checkBox1.Checked;
            bool estadoCheckBox2 = checkBox2.Checked;

            // Lógica para habilitar o deshabilitar los controles según las condiciones
            if (estadoCheckBox1 && estadoCheckBox2)
            {
                // Habilita los controles específicos
                HabilitarOtrosControles(true);
            }
            else
            {
                // Deshabilita los controles específicos
                DeshabilitarControles();
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void DeshabilitarControles()
        {
            // Deshabilita otros controles si la edad no es suficiente
            dataGridViewPropiedades.Enabled = false;
            dataGridView2.Enabled = false;
            txtReserva.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombreEscribania.Enabled = false;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnContrato.Enabled = false;
        }

        private void HabilitarOtrosControles(bool habilitar)
        {
            // Habilita o deshabilita otros controles según el estado del parámetro "habilitar"
            dataGridViewPropiedades.Enabled = habilitar;
            dataGridView2.Enabled = habilitar;
            txtReserva.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            //textBox5.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnModificar.Enabled = habilitar;
            btnBorrar.Enabled = habilitar;
            btnLimpiarCampos.Enabled = habilitar;
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

                    // Obtiene la reserva para el tipo de inmueble actual
                    Alquiler alquiler = AlquilerManager.Instance.VerificarSiTieneReserva(tipoInmueble.IdTipoInmueble);
                    if (alquiler != null)
                    {
                        tipoInmueble.ImporteReserva = alquiler.ImporteReserva;
                    }
                    else
                    {
                        tipoInmueble.ImporteReserva = 0; // Valor por defecto si no se encuentra la reserva
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

                dataGridViewPropiedades.Columns["PrecioVenta"].Visible = false;
                dataGridViewPropiedades.Columns["PrecioAlquiler"].HeaderText = "Precio de Alquiler";
                dataGridViewPropiedades.Columns["TieneReserva"].Visible = false;
                dataGridViewPropiedades.Columns["ImporteReserva"].HeaderText = "Valor de Reserva";



                // Llamar al método para validar y habilitar el botón Contrato
                ValidarHabilitarBotonContrato();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al cargar los tipos de inmuebles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridViewPropiedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.Rows[e.RowIndex];

                // Acceder a los valores de las celdas de la fila seleccionada
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                string tipoPropiedad = selectedRow.Cells["TipoInmuebleNombre"].Value.ToString();
                string direccion = selectedRow.Cells["Direccion"].Value.ToString();
                string descripcion = selectedRow.Cells["Descripcion"].Value.ToString();

                Guid idProvincia = (Guid)selectedRow.Cells["IdProvincia"].Value;
                Guid idPartido = (Guid)selectedRow.Cells["IdPartido"].Value;
                Guid idLocalidad = (Guid)selectedRow.Cells["IdLocalidad"].Value;

                string precioVenta = selectedRow.Cells["PrecioVenta"].Value.ToString();
                string precioAlquiler = selectedRow.Cells["PrecioAlquiler"].Value.ToString();
                string importeReserva = selectedRow.Cells["ImporteReserva"].Value.ToString();

                // Cargar valores en los controles del formulario
                txtDescripcion.Text = descripcion;
                lblPrecio_Alquiler.Text = precioAlquiler;
                label5.Text = precioAlquiler;
                txtReserva.Text = importeReserva;

                // Llamar al método para validar y habilitar el botón Contrato
                ValidarHabilitarBotonContrato();
            }
        }


        private void ComboBoxTipoPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoInmueble = ComboBoxTipoPropiedad.SelectedItem.ToString();

            switch (tipoInmueble)
            {
                case "Casa":
                    _calculadorAlquiler = new CalculadorCasa();
                    break;
                case "Departamento":
                    _calculadorAlquiler = new CalculadorDepartamento();
                    break;
                case "Terreno":
                    _calculadorAlquiler = new CalculadorTerreno();
                    break;
                case "Local":
                    _calculadorAlquiler = new CalculadorLocal();
                    break;
            }

            // Obtener el valor de la propiedad desde el label
            if (decimal.TryParse(lblPrecio_Alquiler.Text, out decimal valorPropiedad))
            {
                // Llama al método para calcular y mostrar los valores
                CalcularValoresAlquiler(valorPropiedad);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor de propiedad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void MostrarTodasLasEscribanias()
        //{
        //    try
        //    {
        //        var escribanias = EscribaniaManager.Instance.ObtenerTodasLasEscribanias();

        //        // Itera sobre la lista y obtén los valores necesarios para cada escribania
        //        foreach (var escribania in escribanias)
        //        {
        //            // Obtiene los valores de la escribania actual
        //            // Asegúrate de tener las propiedades correctas en tu clase Escribania
        //            Guid idEscribania = escribania.IdEscribania;
        //            string nombreEscribania = escribania.RazonSocial;
        //            string direccion = escribania.Direccion;
        //            string telefono = escribania.Telefono;

        //            // Realiza las acciones necesarias con los valores obtenidos
        //            // Puedes asignarlos a controles en el formulario o hacer lo que sea necesario

        //            // Ejemplo: Asignar valores a controles en el formulario
        //            txtNombreEscribania.Text = nombreEscribania;
        //            //txtDireccion.Text = direccion;
        //            //txtTelefono.Text = telefono;
        //        }

        //        // Asigna la lista de escribanias al DataGridView
        //        dataGridView2.DataSource = null;
        //        dataGridView2.DataSource = escribanias;

        //        // Personaliza la apariencia del DataGridView según tus necesidades

        //        // Llamar al método para validar y habilitar botones u otras acciones si es necesario
        //        // Ejemplo: ValidarHabilitarBotonAlgo();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se produjo un error al cargar las escribanias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void ListarTodasLasEscribanias()
        {

            try
            {
                // Obtener la lista de todos los usuarios utilizando el método GetAllEscribanias
                var escribanias = EscribaniaManager.Instance.ObtenerTodasLasEscribanias();

                // Asignar la lista de usuarios al DataGridView
                dataGridView2.DataSource = null; // Primero establece el origen de datos a null
                dataGridView2.DataSource = escribanias;

                // Cambiar los nombres de las columnas programáticamente

                // Dejo oculto el campo
                dataGridView2.Columns["Idescribania"].Visible = false;

                dataGridView2.Columns["RazonSocial"].HeaderText = "Nombre Escribania (RazonSocial)";
                dataGridView2.Columns["Direccion"].HeaderText = "Dirección";
                dataGridView2.Columns["Telefono"].HeaderText = "Telefono";

                //LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada

                Guid idescribania = (Guid)selectedRow.Cells["Idescribania"].Value;

                string nombreEscribania = selectedRow.Cells["RazonSocial"].Value.ToString();
                string direccion = selectedRow.Cells["Direccion"].Value.ToString();
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();

                txtNombreEscribania.Text = nombreEscribania;
                
                //txtDireccion.Text = direccion;
                //txtTelefono.Text = telefono;

            }

        }

        private void CalcularValoresAlquiler(decimal valorPropiedad)
        {
            // Utilizar la estrategia para calcular los valores
            decimal totalBoleto = _calculadorAlquiler.CalcularTotalBoleto(valorPropiedad);
            decimal totalImpuesto = _calculadorAlquiler.CalcularTotalImpuesto(valorPropiedad);
            decimal totalDineroPropiedad = _calculadorAlquiler.CalcularTotalDineroPropiedad(valorPropiedad);

            // Redondear los valores a dos decimales
            totalBoleto = Math.Round(totalBoleto, 2);
            totalImpuesto = Math.Round(totalImpuesto, 2);
            totalDineroPropiedad = Math.Round(totalDineroPropiedad, 2);

            // Mostrar los resultados en los labels correspondientes
            lblTotalBoleto.Text = totalBoleto.ToString("C");
            lblTotalImpuesto.Text = totalImpuesto.ToString("C");
            lblTotalDineroPropiedad.Text = totalDineroPropiedad.ToString("C");
        }



        // Método para guardar la reserva y habilitar el botón btnContrato
        private void GuardarReserva()
        {
            // Código para guardar la reserva

            // Después de guardar, habilitar los controles y el botón btnContrato
            HabilitarOtrosControles(true);
            btnContrato.Enabled = true;
        }

        

        /// <summary>
        /// Guardo la reserva de la propiedad seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                // Acceder a los valores de las celdas de la fila seleccionada
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                // Obtener valores de los controles en el formulario
                int importeReserva = int.Parse(txtReserva.Text);

                // Validar que el importe de la reserva sea mayor o igual a 1500
                if (!AlquilerManager.Instance.ValidarImporteReserva(importeReserva))
                {
                    MessageBox.Show("El importe de la reserva debe ser mayor o igual a 1500.");
                    return; // Salir del método si la validación falla
                }


                // Obtener el texto de lblTotalDineroPropiedad
                string textoCompleto = lblTotalDineroPropiedad.Text;



                // Eliminar caracteres no numéricos (dejar solo dígitos y la coma decimal)
                string soloDigitos = new string(textoCompleto.Where(c => char.IsDigit(c) || c == ',').ToArray());

                // Reemplazar la coma con el punto para asegurar un formato decimal válido
                soloDigitos = soloDigitos.Replace(',', '.');

                // Intentar convertir la cadena de dígitos en un decimal
                if (decimal.TryParse(soloDigitos, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorPropiedad))
                {

                    // Crear una instancia de Alquiler con los valores obtenidos
                    DomainModel.Alquiler alquiler = new DomainModel.Alquiler
                    {
                        IdAlquiler = Guid.NewGuid(),
                        ImporteReserva = importeReserva,
                        ImporteAlquiler = valorPropiedad,
                        Garantia = "Garantias recibidas y aprobadas",
                        IdTipoInmueble = idTipoInmueble,
                        Activo = "1",
                    };


                    // Llamar al método ReservaPropiedad de AlquilerManager
                    bool exito = AlquilerManager.Instance.ReservaPropiedad(alquiler);

                    if (exito)
                    {
                        MessageBox.Show("Reserva de alquiler guardada correctamente.");

                        // Obtener el IdAlquiler generado
                        Guid idAlquilerGenerado = alquiler.IdAlquiler;

                        // Obtener el IdTipoInmueble seleccionado
                        Guid idTipoInmuebleSeleccionado = alquiler.IdTipoInmueble;

                        // Obtener el IdEscribania seleccionado
                        Guid idEscribaniaSeleccionada = ObtenerIdEscribaniaSeleccionada();

                        // Actualizar el estado del botón btnContrato
                        //ValidarHabilitarBotonContrato(idAlquilerGenerado, idTipoInmuebleSeleccionado, idEscribaniaSeleccionada);

                        // Habilitar el botón btnContrato (si no se habilitó en ValidarHabilitarBotonContrato)
                        btnContrato.Enabled = true;

                        // Llamar al método GenerarContrato con los parámetros necesarios
                        //GenerarContrato(idAlquilerGenerado, idTipoInmuebleSeleccionado, idEscribaniaSeleccionada);
                        GenerarContrato(idAlquilerGenerado, idTipoInmuebleSeleccionado, idEscribaniaSeleccionada);


                        //// Crear una instancia de la clase Inmobiliaria para registrar la operación
                        //Inmobiliaria inmobiliaria = new Inmobiliaria
                        //{
                        //    IdTipoInmueble = idTipoInmueble,
                        //    IdPropietario = null,
                        //    IdComprador = null,
                        //    IdAlquiler = idAlquilerGenerado,
                        //    IdVenta = null,
                        //    IdContrato = null,
                        //    Detalle = "Reserva alquiler registrada",
                        //    FechaOperacion = DateTime.Now,
                        //    Activo = "1"
                        //};

                        //// Llamar al método para registrar la operación en InmobiliariaManager
                        //bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionResevaAlquiler(inmobiliaria);

                        //if (operacionRegistrada)
                        //{
                        //    MessageBox.Show("Operación registrada correctamente en InmobiliariaManager.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    LimpiarCampos(); // Método para limpiar los campos del formulario
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Error al registrar la operación en InmobiliariaManager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la reserva de alquiler. Por favor, inténtelo de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("El valor de TotalDineroPropiedad no es un número válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                // Obtener el IdTipoInmueble de la reserva seleccionada
                Guid idTipoInmuebleSeleccionado = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                // Obtener el nuevo importe de reserva desde txtReserva
                int nuevoImporteReserva = int.Parse(txtReserva.Text);

                // Validar el nuevo importe de reserva
                if (!AlquilerManager.Instance.ValidarImporteReserva(nuevoImporteReserva))
                {
                    MessageBox.Show("El importe de la reserva debe ser mayor o igual a 1500.");
                    return;
                }

                // Obtener el objeto Alquiler existente para actualizar la reserva
                Alquiler alquilerExistente = AlquilerManager.Instance.BuscarReserva(idTipoInmuebleSeleccionado);

                if (alquilerExistente == null)
                {
                    MessageBox.Show("No se encontró la reserva existente. Por favor, asegúrese de que esté registrada.");
                    return;
                }

                // Actualizar el importe de reserva en el objeto Alquiler
                alquilerExistente.ImporteReserva = nuevoImporteReserva;

               

                // Actualizar la reserva llamando al método correspondiente en AlquilerManager
                bool exito = AlquilerManager.Instance.ActualizarReserva(alquilerExistente);

                if (exito)
                {
                    MessageBox.Show("Importe de reserva actualizado correctamente.");
                    MostrarTodosLosTiposDeInmuebles();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el importe de la reserva. Por favor, inténtelo de nuevo.");
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
                // Establecer el valor de txtReserva.Text en 0
                txtReserva.Text = "0";

                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                // Obtener el IdTipoInmueble de la reserva seleccionada
                Guid idTipoInmuebleSeleccionado = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                // Obtener el objeto Alquiler existente para actualizar la reserva
                Alquiler alquilerExistente = AlquilerManager.Instance.BuscarReserva(idTipoInmuebleSeleccionado);

                if (alquilerExistente == null)
                {
                    MessageBox.Show("No se encontró la reserva existente. Por favor, asegúrese de que esté registrada.");
                    return;
                }

                // Actualizar el importe de reserva en el objeto Alquiler
                alquilerExistente.ImporteReserva = 0;

                // Actualizar la reserva llamando al método correspondiente en AlquilerManager
                bool exito = AlquilerManager.Instance.ActualizarReserva(alquilerExistente);

                if (exito)
                {
                    MessageBox.Show("Importe de reserva borrado correctamente.");
                    MostrarTodosLosTiposDeInmuebles();
                }
                else
                {
                    MessageBox.Show("Error al borrar el importe de la reserva. Por favor, inténtelo de nuevo.");
                }

                // Mostrar todos los tipos de inmuebles
                MostrarTodosLosTiposDeInmuebles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar remover el valor de reserva: " + ex.Message);
            }
        }



        private void ValidarHabilitarBotonContrato()
        {
            // Obtener el valor de txtReserva
            int importeReserva;
            if (int.TryParse(txtReserva.Text, out importeReserva))
            {
                // Habilitar o deshabilitar el botón "Contrato" según la condición
                btnContrato.Enabled = importeReserva > 0;
            }
            else
            {
                // Si no se puede convertir a entero, deshabilitar el botón
                btnContrato.Enabled = false;
            }
        }

        private void GenerarContrato(Guid idAlquiler, Guid idTipoInmueble, Guid idEscribania)
        {
            // Crea una instancia de FrmContrato y pásale los parámetros
            FrmContrato frmContrato = new FrmContrato(idAlquiler, idTipoInmueble, idEscribania);

            // Muestra el formulario FrmContrato
            frmContrato.Show();

        }



        private void btnContrato_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dataGridViewPropiedades.SelectedRows.Count > 0)
                {
                    // Obtengo la fila seleccionada de la propiedad
                    DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];
                    Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                    // Obtengo la fila seleccionada de la escribania
                    //DataGridViewRow selectedRow2 = dataGridView2.SelectedRows[0];
                    //Guid idEscribania = (Guid)selectedRow2.Cells["Idescribania"].Value;

                    //if (dataGridView2.SelectedRows.Count > 0)
                    //{
                    //    // Obtengo la fila seleccionada de la escribania
                    //    DataGridViewRow selectedRow2 = dataGridView2.SelectedRows[0];
                    //    Guid idEscribania = (Guid)selectedRow2.Cells["IdEscribania"].Value;

                    //    // Ahora puedes utilizar idTipoInmueble e idEscribania para realizar la acción deseada

                    //    // Resto del código...
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Por favor, seleccione una escribanía antes de generar el contrato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    Guid idEscribania = Guid.Empty; // Variable para almacenar el id de la escribanía seleccionada

                    // Verificar si alguna fila está seleccionada en dataGridView2
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        // Obtener la fila seleccionada de la escribanía
                        DataGridViewRow selectedRow2 = dataGridView2.SelectedRows[0];
                        idEscribania = (Guid)selectedRow2.Cells["IdEscribania"].Value;

                        // Resto del código...
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione una escribanía antes de generar el contrato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Salir del método si no se selecciona una escribanía
                    }

                    // Obtengo el idAlquiler usando el método AptoContrato
                    Alquiler alquiler = AlquilerManager.Instance.AptoContrato(idTipoInmueble);

                    if (alquiler != null)
                    {
                        
                        Guid idAlquiler = alquiler.IdAlquiler;

                        // Llamo al método GenerarContrato y les paso los parametros obtenidos
                        GenerarContrato(idAlquiler, idTipoInmueble, idEscribania);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el Alquiler asociado al Tipo de Inmueble.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una propiedad antes de generar el contrato.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el contrato: " + ex.Message);
            }
        }

        //private void GenerarContrato(Guid idAlquilerGenerado, Alquiler alquiler)
        //{
        //    try
        //    {
        //        if (alquiler != null)
        //        {
        //            // Crear una instancia de FrmContrato y pasarle la instancia de Alquiler
        //            FrmContrato frmContrato = new FrmContrato(alquiler);

        //            // Muestra el formulario FrmContrato
        //            frmContrato.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se pudo obtener el contrato de alquiler asociado al ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void btnContrato_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Verificar si se ha seleccionado alguna fila en dataGridViewPropiedades
        //        if (dataGridViewPropiedades.SelectedRows.Count > 0)
        //        {
        //            // Obtener la fila seleccionada de la propiedad
        //            DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];
        //            Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

        //            // Verificar si se ha seleccionado alguna fila en dataGridView2
        //            if (dataGridView2.SelectedRows.Count > 0)
        //            {
        //                // Obtener la fila seleccionada de la escribania
        //                DataGridViewRow selectedRow2 = dataGridView2.SelectedRows[0];
        //                Guid idEscribania = (Guid)selectedRow2.Cells["Idescribania"].Value;

        //                // Obtener el alquiler asociado al tipo de inmueble
        //                Alquiler alquiler = AlquilerManager.Instance.AptoContrato(idTipoInmueble);

        //                if (alquiler != null)
        //                {
        //                    // Llamar al método GenerarContrato y pasar la instancia de Alquiler
        //                    GenerarContrato(Alquiler alquiler);

        //                }
        //                else
        //                {
        //                    MessageBox.Show("No se pudo obtener el Alquiler asociado al Tipo de Inmueble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Por favor, seleccione una escribanía antes de generar el contrato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Seleccione una propiedad antes de generar el contrato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private Guid ObtenerIdAlquilerSeleccionado()
        {
            if (dataGridViewPropiedades.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];
                if (selectedRow.Cells["IdAlquiler"].Value != null)
                {
                    return (Guid)selectedRow.Cells["IdAlquiler"].Value;
                }
            }

            throw new InvalidOperationException("No se ha seleccionado una fila válida en dataGridViewPropiedades.");
        }

        private Guid ObtenerIdEscribaniaSeleccionada()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                if (selectedRow.Cells["Idescribania"].Value != null)
                {
                    return (Guid)selectedRow.Cells["Idescribania"].Value;
                }
            }

            throw new InvalidOperationException("No se ha seleccionado una fila válida en dataGridView2.");
        }

        private Guid ObtenerIdTipoInmuebleSeleccionado()
        {
            if (dataGridViewPropiedades.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];
                if (selectedRow.Cells["IdTipoInmueble"].Value != null)
                {
                    return (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                }
            }

            throw new InvalidOperationException("No se ha seleccionado una fila válida.");
        }

        private void LimpiarCampos()
        {
            txtReserva.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombreEscribania.Text = string.Empty;


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtReserva.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombreEscribania.Text = string.Empty;
        }
    }
}
