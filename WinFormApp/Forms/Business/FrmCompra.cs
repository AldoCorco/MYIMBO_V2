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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using BLL.Strategy.Venta;
using System.Web.UI.WebControls;
using System.Globalization;
using CrystalDecisions.ReportAppServer.DataDefModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.Services.Description;

namespace WinFormApp.Forms.Business
{
    public partial class FrmCompra : Form
    {
        private ICalculadorVenta _calculadorVenta;
        private Guid idPropietario;
        private string legajoComprador;
        private object dateFechaNacimiento;
        private Guid idTipoInmuebleSeleccionado;
        private Guid idTipoInmueble;


        public FrmCompra()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            // Inicializar controles bloqueados
            BloquearControles();

            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;

            MostrarTodosLosTiposDeInmuebles();
            CargarCompradores();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Lógica para manejar cambios en los CheckBox
            ActualizarEstadoControles();
        }

        private void ActualizarEstadoControles()
        {
            bool estadoCheckBox1 = checkBox1.Checked;
            bool estadoCheckBox2 = checkBox2.Checked;


            string mensaje = ComprarManager.Instance.VerificarCondicionesCompra(estadoCheckBox1, estadoCheckBox2);

            if (mensaje == "Requisitos de documentación completados")
            {
                HabilitarControles();
            }
            else
            {
                ComprarManager.Instance.MostrarAlerta(mensaje);
            }
        }

        private void BloquearControles()
        {
            // Bloquear aquí los controles que desees al inicializar el formulario
            // Por ejemplo, deshabilitar la grilla
            dataGridViewPropiedades.Enabled = false;

            // Deshabilitar botones
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnBoletoCompra.Enabled = false;
        }

        private void HabilitarControles()
        {
            // Habilitar aquí los controles que desees después de verificar las condiciones

            // Por ejemplo, habilitar la grilla
            dataGridViewPropiedades.Enabled = true;

            // Habilitar botones
            btnGuardar.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            btnLimpiarCampos.Enabled = true;
            btnBoletoCompra.Enabled = true;
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
           
        }



        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                blbDNI.Text = LanguageBLL.Traducir("DNI", lang);
                lblSeleccionarPropiedad.Text = LanguageBLL.Traducir("Certificado de domicilio", lang);
                lblCertificadodomicilio.Text = LanguageBLL.Traducir("Seleccionar Propiedad", lang);

                groupBox1.Text = LanguageBLL.Traducir("Comprador", lang);
                lblLegajoComprador.Text = LanguageBLL.Traducir("Legajo Comprador", lang);
                lblNombre.Text = LanguageBLL.Traducir("Nombre", lang);
                lblApellido.Text = LanguageBLL.Traducir("Apellido", lang);
                lblDNI.Text = LanguageBLL.Traducir("DNI", lang);
                lblFechaNacimiento.Text = LanguageBLL.Traducir("Fecha de Nacimiento", lang);
                lblTelefono.Text = LanguageBLL.Traducir("Telefono", lang);

                groupBox2.Text = LanguageBLL.Traducir("Vendedor", lang);
                lblNombre2.Text = LanguageBLL.Traducir("Nombre", lang);
                lblApellido2.Text = LanguageBLL.Traducir("Apellido", lang);
                lblDNI2.Text = LanguageBLL.Traducir("DNI", lang);

                lblTipoPropiedad.Text = LanguageBLL.Traducir("Tipo de Propiedad", lang);
                lblValorPropiedad.Text = LanguageBLL.Traducir("Valor Propiedad", lang);
                lblTotalComision.Text = LanguageBLL.Traducir("Total Comisión", lang);
                lblImpuesto.Text = LanguageBLL.Traducir("Total Impuesto", lang);
                lblTotalPropiedad.Text = LanguageBLL.Traducir("Total Propiedad", lang);

                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);
                btnBoletoCompra.Text = LanguageBLL.Traducir("Boleto de Compra", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
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
                        
                    }
                    else
                    {
                        tipoInmueble.PrecioVenta = 0; // Valor por defecto si no se encuentra la tasación
                        
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

                dataGridViewPropiedades.Columns["PrecioAlquiler"].Visible = false;
                dataGridViewPropiedades.Columns["TieneReserva"].Visible = false;
                //dataGridViewPropiedades.Columns["ImporteReseva"].Visible = false;

                dataGridViewPropiedades.Columns["TipoInmuebleNombre"].HeaderText = "Tipo de Propiedad";
                dataGridViewPropiedades.Columns["Direccion"].HeaderText = "Dirección";
                dataGridViewPropiedades.Columns["Descripcion"].HeaderText = "Descripción";
                dataGridViewPropiedades.Columns["NombreProvincia"].HeaderText = "Provincia";
                dataGridViewPropiedades.Columns["NombrePartido"].HeaderText = "Partido";
                dataGridViewPropiedades.Columns["NombreLocalidad"].HeaderText = "Localidad";

                dataGridViewPropiedades.Columns["PrecioVenta"].HeaderText = "Precio de Venta";

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
                dataGridViewCompraPropiedades.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewCompraPropiedades.DataSource = propietarios;

                // Ocultar la columna IdPropietario si es necesario
                dataGridViewCompraPropiedades.Columns["IdPropietario"].Visible = false;


                dataGridViewCompraPropiedades.Columns["LegajoPropietario"].HeaderText = "Legajo Propietario";
                dataGridViewCompraPropiedades.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewCompraPropiedades.Columns["Apellido"].HeaderText = "Apellido";
                dataGridViewCompraPropiedades.Columns["DNI"].HeaderText = "DNI";
                dataGridViewCompraPropiedades.Columns["FechaNacimiento"].HeaderText = "FechaNacimiento";
                dataGridViewCompraPropiedades.Columns["Telefono"].HeaderText = "Telefono";
                dataGridViewCompraPropiedades.Columns["Importe"].HeaderText = "Importe";
                dataGridViewCompraPropiedades.Columns["Comision"].HeaderText = "Comision";
                dataGridViewCompraPropiedades.Columns["Impuesto"].HeaderText = "Impuesto";
                dataGridViewCompraPropiedades.Columns["TotalPropiedad"].HeaderText = "TotalPropiedad";

                dataGridViewCompraPropiedades.Columns["IdTipoInmueble"].Visible = false;
                //dataGridViewPropietarios.Columns["Importe"].Visible = false;
                //dataGridViewPropietarios.Columns["Comision"].Visible = false;
                //dataGridViewPropietarios.Columns["Impuesto"].Visible = false;
                //dataGridViewPropietarios.Columns["TotalPropiedad"].Visible = false;
                dataGridViewCompraPropiedades.Columns["Activo"].Visible = false;
                // Limpiar los campos del formulario después de cargar los propietarios
                //LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los propietarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Cargar nombres de provincia, partido y localidad en los ComboBox correspondientes
                Provincia provincia = ProvinciaManager.Instance.ObtenerProvinciaPorId(idProvincia);

                // Obtener el propietario por el idTipoInmueble
                Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(idTipoInmueble);

                if (propietario != null)
                {
                    // Asignar el nombre del propietario al TextBox correspondiente
                    txtNombreVendedor.Text = propietario.Nombre;
                    txtApellidoVendedor.Text = propietario.Apellido;
                    txtDNIVendedor.Text = propietario.DNI.ToString();

                    // Obtener el IdPropietario y guardarlo en la variable
                    idPropietario = propietario.IdPropietario;
                }
                else
                {
                    // Si no se encuentra el propietario, puedes mostrar un mensaje o asignar un valor predeterminado
                    txtNombreVendedor.Text = "Propietario no encontrado";
                    txtApellidoVendedor.Text = string.Empty;
                    txtDNIVendedor.Text = string.Empty;

                    idPropietario = Guid.Empty;
                }

                txtPrecioVenta.Text = precioventa;
                lblValorDineroPropiedad.Text = precioventa;

            }
        }


        private void ComboBoxTipoPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoInmueble = ComboBoxTipoPropiedad.SelectedItem.ToString();

            switch (tipoInmueble)
            {
                case "Casa":
                    _calculadorVenta = new CalculadorCasa();
                    break;
                case "Departamento":
                    _calculadorVenta = new CalculadorDepartamento();
                    break;
                case "Terreno":
                    _calculadorVenta = new CalculadorTerreno();
                    break;
                case "Local":
                    _calculadorVenta = new CalculadorLocal();
                    break;
            }

            // Obtener el valor de la propiedad desde el label
            if (decimal.TryParse(txtPrecioVenta.Text, out decimal valorPropiedad))
            {
                // Llama al método para calcular y mostrar los valores
                CalcularValoresVenta(valorPropiedad);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor de propiedad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularValoresVenta(decimal valorPropiedad)
        {
            // Utilizar la estrategia para calcular los valores
            decimal totalBoleto = _calculadorVenta.CalcularTotalBoleto(valorPropiedad);
            decimal totalImpuesto = _calculadorVenta.CalcularTotalImpuesto(valorPropiedad);
            decimal totalDineroPropiedad = _calculadorVenta.CalcularTotalDineroPropiedad(valorPropiedad);

            // Redondear los valores a dos decimales
            totalBoleto = Math.Round(totalBoleto, 2);
            totalImpuesto = Math.Round(totalImpuesto, 2);
            totalDineroPropiedad = Math.Round(totalDineroPropiedad, 2);

            // Mostrar los resultados en los labels correspondientes
            lblTotalDineroComision.Text = totalBoleto.ToString("C");
            lblTotalDineroImpuesto.Text = totalImpuesto.ToString("C");
            lblTotalDineroPropiedad.Text = totalDineroPropiedad.ToString("C");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un tipo de propiedad en el ComboBox
                if (ComboBoxTipoPropiedad.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de propiedad para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detener el flujo del método ya que no se ha seleccionado ninguna opción
                }

                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                // Acceder a los valores de las celdas de la fila seleccionada
                Guid IdTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                string precioVenta = selectedRow.Cells["PrecioVenta"].Value.ToString();

                txtPrecioVenta.Text = precioVenta;

                

                // Obtener el valor de la comisión
                decimal comisionDecimal = decimal.Parse(lblTotalDineroComision.Text, NumberStyles.Currency);

                //Obtener el valor del impuesto
                decimal totalImpuesto = decimal.Parse(lblTotalDineroImpuesto.Text, NumberStyles.Currency);

                //Obtener el valor de total de la propiedad
                decimal totalDineroPropiedad = decimal.Parse(lblTotalDineroPropiedad.Text, NumberStyles.Currency);


                //// Verificar si ya existe una compra creada
                //if (ComprarManager.Instance.ExisteCompraCreada(IdTipoInmueble))
                //{
                //    // Ya existe una compra creada, mostrar un mensaje
                //    MessageBox.Show("Ya existe una compra creada para este tipo de inmueble.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                int legajoComprador = int.Parse(txtLegajoComprador.Text);             
                string nombreComprador = txtNombreComprador.Text;
                string apellidoComprador = txtApellidoComprador.Text;
                int dniComprador = int.Parse(txtDNIComprador.Text);                
                DateTime fechaNacComprador = dateTimePickerFechaNacComprador.Value;
                string telefonoComprador = txtTelefonoComprador.Text;

                // Crear una instancia de la clase Compra
                Compra nuevaCompra = new Compra
                {
                    //IdComprador = Guid.NewGuid(), // Genera un nuevo Id
                    LegajoComprador = legajoComprador,
                    Nombre = nombreComprador,
                    Apellido = apellidoComprador,
                    DNI = dniComprador,
                    FechaNacimiento = fechaNacComprador,
                    Telefono = telefonoComprador,
                    IdTipoInmueble = IdTipoInmueble,
                    Importe = (int)decimal.Parse(precioVenta),
                    Comision = comisionDecimal,
                    Impuesto = totalImpuesto,
                    TotalPropiedad = totalDineroPropiedad,
                    Activo = "1",
                    // Asignar otros valores de la compra si es necesario
                };

                // Llamar al método para guardar la compra en CompraManager
                bool compraGuardada = ComprarManager.Instance.GuardarCompra(nuevaCompra);

                // Verificar si la compra se guardó correctamente
                if (compraGuardada)
                {
                    // Obtengo el idComprador 
                    //Compra comprador = ComprarManager.Instance.BuscarComprador(IdTipoInmueble);
                    Compra comprador = ComprarManager.Instance.BuscarComprador(IdTipoInmueble);

                    // Crear una instancia de la clase Inmobiliaria para registrar la operación
                    Inmobiliaria inmobiliaria = new Inmobiliaria
                    {
                        IdTipoInmueble = IdTipoInmueble,
                        IdPropietario = null,
                        //IdComprador = nuevaCompra.IdComprador, // Obtener el Id de la compra guardada
                        IdComprador = comprador.IdComprador,
                        IdAlquiler = null,
                        IdVenta = null,
                        IdContrato = null,
                        Detalle = "Compra registrada",
                        FechaOperacion = DateTime.Now,
                        Activo = "1",
                                               

                    };

                    // Llamar al método para registrar la operación en InmobiliariaManager
                    bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionCompra(inmobiliaria);

                    if (operacionRegistrada)
                    {
                        MessageBox.Show("Compra guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); // Método para limpiar los campos del formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar la operación en InmobiliariaManager", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridViewCompraPropiedades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewCompraPropiedades.SelectedRows[0];

                // Obtener los valores de la fila seleccionada
                Guid idComprador = (Guid)selectedRow.Cells["IdComprador"].Value;
                //Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                

                // Obtener el nuevo idTipoInmueble
                Guid nuevoIdTipoInmueble = ObtenerIdTipoInmuebleSeleccionado();

                // Cargar los valores de comprador
                int nuevolegajoComprador = int.Parse(txtLegajoComprador.Text);
                string nuevonombreComprador = txtNombreComprador.Text;
                string nuevoapellidoComprador = txtApellidoComprador.Text;
                int nuevodniComprador = int.Parse(txtDNIComprador.Text);
                DateTime nuevofechaNacComprador = dateTimePickerFechaNacComprador.Value;
                string nuevotelefonoComprador = txtTelefonoComprador.Text;

                //string nuevoimporte = txtPrecioVenta.Text;

                int nuevoimporte = int.Parse(txtPrecioVenta.Text);

                // Obtener el valor de la comisión
                decimal nuevocomisionDecimal = decimal.Parse(lblTotalDineroComision.Text, NumberStyles.Currency);

                //Obtener el valor del impuesto
                decimal nuevototalImpuesto = decimal.Parse(lblTotalDineroImpuesto.Text, NumberStyles.Currency);

                //Obtener el valor de total de la propiedad
                decimal nuevototalDineroPropiedad = decimal.Parse(lblTotalDineroPropiedad.Text, NumberStyles.Currency);

                // Obtener el IdTipoInmueble del propietario seleccionado
                //Guid idComprador = (Guid)dataGridViewCompraPropiedades.SelectedRows[0].Cells["IdComprador"].Value;

                // Crear el objeto Compra con los valores de los controles
                Compra compradorPropiedades = new Compra
                {
                    // Asignar propiedades según los valores obtenidos
                    IdComprador = idComprador,
                    LegajoComprador = nuevolegajoComprador,
                    Nombre = nuevonombreComprador,
                    Apellido = nuevoapellidoComprador,
                    DNI = nuevodniComprador,
                    FechaNacimiento = nuevofechaNacComprador,
                    Telefono = nuevotelefonoComprador,
                    Importe = nuevoimporte,
                    Comision = nuevocomisionDecimal,
                    Impuesto = nuevototalImpuesto,
                    TotalPropiedad = nuevototalDineroPropiedad,
                    Activo = "1",
                    IdTipoInmueble = nuevoIdTipoInmueble,
                };

                // Llamar al método en CompraManager para actualizar el comprador
                bool actualizacionExitosa = ComprarManager.Instance.ModificarCompra(compradorPropiedades);

                if (actualizacionExitosa)
                {
                    MessageBox.Show("Compra actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Crear una instancia de la clase Inmobiliaria para registrar la operación
                    Inmobiliaria inmobiliaria = new Inmobiliaria
                    {
                        IdTipoInmueble = nuevoIdTipoInmueble,
                        IdPropietario = null,
                        IdComprador = idComprador,
                        IdAlquiler = null,
                        IdVenta = null,
                        IdContrato = null,
                        Detalle = "Registro de Compra modificado",
                        FechaOperacion = DateTime.Now,
                        Activo = "1",
                    };


                    // Llamar al método para registrar la operación en InmobiliariaManager
                    bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionCompra(inmobiliaria);

                    if (operacionRegistrada)
                    {
                        MessageBox.Show("Operación actualizada correctamente en Inmobiliaria", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la operación en Inmobiliaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    // Recargar la grilla de compradores
                    CargarCompradores();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Guid ObtenerIdTipoInmuebleSeleccionado()
        {
            foreach (DataGridViewRow row in dataGridViewPropiedades.Rows)
            {
                if (row.Selected)
                {
                    return (Guid)row.Cells["IdTipoInmueble"].Value;
                }
            }
            return Guid.Empty; // Retornar un valor predeterminado si no se encuentra ninguna fila seleccionada
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridViewCompraPropiedades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewCompraPropiedades.SelectedRows[0];

                // Obtener los valores de la fila seleccionada
                Guid idComprador = (Guid)selectedRow.Cells["IdComprador"].Value; 
                int legajoComprador = (int)selectedRow.Cells["LegajoComprador"].Value;
                string nombreComprador = selectedRow.Cells["Nombre"].Value.ToString();
                string apellidoComprador = selectedRow.Cells["Apellido"].Value.ToString();
                int dniComprador = (int)selectedRow.Cells["DNI"].Value;
                DateTime fechaNacComprador = (DateTime)selectedRow.Cells["FechaNacimiento"].Value;
                string telefonoComprador = selectedRow.Cells["Telefono"].Value.ToString();
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                decimal importe = (int)selectedRow.Cells["Importe"].Value;
                decimal comision = (decimal)selectedRow.Cells["Comision"].Value;
                decimal impuesto = (decimal)selectedRow.Cells["Impuesto"].Value;
                decimal totalpropiedad = (decimal)selectedRow.Cells["TotalPropiedad"].Value;

                // Crear el objeto Compra con los valores de los controles
                Compra compradorPropiedades = new Compra
                {
                    // Asignar propiedades según los valores obtenidos
                    IdComprador = idComprador,
                    LegajoComprador = legajoComprador,
                    Nombre = nombreComprador,
                    Apellido = apellidoComprador,
                    DNI = dniComprador,
                    FechaNacimiento = fechaNacComprador,
                    IdTipoInmueble = idTipoInmueble,
                    Telefono = telefonoComprador,
                    Importe = (int)importe,
                    Comision = comision,
                    Impuesto = impuesto,
                    TotalPropiedad = totalpropiedad,
                    Activo = "0",
                    
                };

                // Llamar al método en CompraManager para actualizar el comprador
                bool actualizacionExitosa = ComprarManager.Instance.ModificarCompra(compradorPropiedades);

                if (actualizacionExitosa)
                {
                    MessageBox.Show("Compra borrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Crear una instancia de la clase Inmobiliaria para registrar la operación
                    Inmobiliaria inmobiliaria = new Inmobiliaria
                    {
                        IdTipoInmueble = idTipoInmueble,
                        IdPropietario = null,
                        IdComprador = idComprador,
                        IdAlquiler = null,
                        IdVenta = null,
                        IdContrato = null,
                        Detalle = "Registro de Compra borrado",
                        FechaOperacion = DateTime.Now,
                        Activo = "0",
                    };


                    // Llamar al método para registrar la operación en InmobiliariaManager
                    bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionCompra(inmobiliaria);

                    if (operacionRegistrada)
                    {
                        MessageBox.Show("Operación borrada correctamente en Inmobiliaria", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar la operación en Inmobiliaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    // Recargar la grilla de compradores
                    CargarCompradores();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtLegajoComprador.Text = string.Empty;
            txtDNIComprador.Text = string.Empty;
            txtNombreComprador.Text = string.Empty;
            txtApellidoComprador.Text = string.Empty;
            txtTelefonoComprador.Text = string.Empty;
            dateTimePickerFechaNacComprador.Value = DateTime.Now; // fecha actual

            txtPrecioVenta.Text = string.Empty;
            ComboBoxTipoPropiedad.Text = string.Empty;


            lblValorDineroPropiedad.Text += string.Empty;
            lblTotalDineroComision.Text = string.Empty;
            lblTotalDineroImpuesto.Text = string.Empty;
            lblTotalDineroPropiedad.Text = string.Empty;

        }

       
        private void CargarCompradores()
        {
            try
            {
                // Obtener la lista de propietarios desde el PropietarioManager
                var propietarios = ComprarManager.Instance.ObtenerCompradores();
                

                // Asignar la lista de propietarios al DataGridView
                dataGridViewCompraPropiedades.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewCompraPropiedades.DataSource = propietarios;

                // Ocultar la columna IdPropietario si es necesario
                dataGridViewCompraPropiedades.Columns["IdComprador"].Visible = false;


                dataGridViewCompraPropiedades.Columns["LegajoComprador"].HeaderText = "Legajo Comprador";
                dataGridViewCompraPropiedades.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewCompraPropiedades.Columns["Apellido"].HeaderText = "Apellido";
                dataGridViewCompraPropiedades.Columns["DNI"].HeaderText = "DNI";
                dataGridViewCompraPropiedades.Columns["FechaNacimiento"].HeaderText = "FechaNacimiento";
                dataGridViewCompraPropiedades.Columns["Telefono"].HeaderText = "Telefono";

                dataGridViewCompraPropiedades.Columns["IdTipoInmueble"].Visible = false;
                dataGridViewCompraPropiedades.Columns["Activo"].Visible = false;

                // Limpiar los campos del formulario después de cargar los propietarios
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los propietarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCompraPropiedades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewCompraPropiedades.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idComprador = (Guid)selectedRow.Cells["IdComprador"].Value;
                int legajoComprador = (int)selectedRow.Cells["LegajoComprador"].Value;
                string nombre = selectedRow.Cells["Nombre"].Value.ToString();
                string apellido = selectedRow.Cells["Apellido"].Value.ToString();
                int dni = (int)selectedRow.Cells["Dni"].Value;
                DateTime fechaNacimiento = (DateTime)selectedRow.Cells["FechaNacimiento"].Value;
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();
                Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                txtLegajoComprador.Text = legajoComprador.ToString();
                txtNombreComprador.Text = nombre;
                txtApellidoComprador.Text = apellido;
                txtDNIComprador.Text = dni.ToString();
                dateTimePickerFechaNacComprador.Value = fechaNacimiento;
                txtTelefonoComprador.Text = telefono;

                // Llamar al método para cargar los datos en FrmPropietario
                //CargarDatosCompradores(idComprador, legajoComprador, nombre, apellido, dni, fechaNacimiento, telefono, idTipoInmueble);
            }
        }

        private void btnBoletoCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridViewCompraPropiedades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para generar el boleto de compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewCompraPropiedades.SelectedRows[0];

                // Obtener los valores de la fila seleccionada
                string nombre = selectedRow.Cells["Nombre"].Value.ToString();
                string apellido = selectedRow.Cells["Apellido"].Value.ToString();
                string dni = selectedRow.Cells["DNI"].Value.ToString();
                string fechaNacimiento = selectedRow.Cells["FechaNacimiento"].Value.ToString();
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();
                string importe = selectedRow.Cells["Importe"].Value.ToString();
                string comision = selectedRow.Cells["Comision"].Value.ToString();
                string impuesto = selectedRow.Cells["Impuesto"].Value.ToString();
                string totalPropiedad = selectedRow.Cells["TotalPropiedad"].Value.ToString();

                // Crear el documento PDF
                Document doc = new Document();
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BoletoCompra.pdf");
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                doc.Open();

                // Agregar contenido al PDF
                Paragraph title = new Paragraph("Boleto de Compra\n\n");
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // Agregar los campos al PDF
                doc.Add(new Paragraph("Nombre del comprador: " + nombre));
                doc.Add(new Paragraph("Apellido: " + apellido));
                doc.Add(new Paragraph("DNI: " + dni));
                doc.Add(new Paragraph("Fecha de Nacimiento: " + fechaNacimiento));
                doc.Add(new Paragraph("Teléfono: " + telefono));
                doc.Add(new Paragraph("Importe: " + importe));
                doc.Add(new Paragraph("Comisión: " + comision));
                doc.Add(new Paragraph("Impuesto: " + impuesto));
                doc.Add(new Paragraph("Total de la Propiedad: " + totalPropiedad));

                doc.Close();

                // Abrir el archivo PDF
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el boleto de compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
