using BLL;
using BLL.Strategy.Venta;
using DomainModel;
using Services.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;


namespace WinFormApp.Forms.Business
{
    public partial class FrmVenta : Form
    {

        private ICalculadorVenta _calculadorVenta;
        private Guid idTipoInmueble;
        private Guid idVenta;
        private Guid idPropietario;
        private Guid idcliente;

        private Guid cliente;

        public Guid IdPropietario { get; private set; }

        public FrmVenta()
        {
            InitializeComponent();

            // Bloquear todos los controles al inicio
            BloquearControles();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            checkBox3.CheckedChanged += CheckBox_CheckedChanged;
            checkBox4.CheckedChanged += CheckBox_CheckedChanged;

            MostrarTodosLosTiposDeInmuebles();
            VentasRegistradas();
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
            bool estadoCheckBox3 = checkBox3.Checked;
            bool estadoCheckBox4 = checkBox4.Checked;

            string mensaje = VentaManager.Instance.VerificarCondicionesVenta(estadoCheckBox1, estadoCheckBox2, estadoCheckBox3, estadoCheckBox4);

            if (mensaje == "Requisitos de documentación completados")
            {
                HabilitarControles();
            }
            else
            {
                VentaManager.Instance.MostrarAlerta(mensaje);
            }
        }

        private void BloquearControles()
        {
            // Bloquear aquí todos los controles al inicio

            // Por ejemplo, bloquear la grilla
            dataGridViewPropiedades.Enabled = false;

            // Bloquear botones
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
        }

        private void HabilitarControles()
        {
            // Habilitar aquí los controles que desees después de verificar las condiciones
            dataGridViewPropiedades.Enabled = true;

            // Habilitar botones
            btnGuardar.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            btnLimpiarCampos.Enabled = true;


        }


        private void FrmVenta_Load(object sender, EventArgs e)
        {

        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblPrecioVenta.Text = LanguageBLL.Traducir("Tipo de Inmueble", lang);
                lblDescripcion.Text = LanguageBLL.Traducir("Descripción", lang);

                groupBox2.Text = LanguageBLL.Traducir("Propietario", lang);
                lblNombre2.Text = LanguageBLL.Traducir("Nombre", lang);
                lblApellido2.Text = LanguageBLL.Traducir("Apellido", lang);
                lblDNI2.Text = LanguageBLL.Traducir("DNI", lang);

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

        private void VentasRegistradas() 
        {

            // Obtener todas las ventas registradas
            var ventas = VentaManager.Instance.ObtenerTodasLasVentas();

            //Obtener los datos de los propietarios
            var propietarios = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(idTipoInmueble);


            //Cambia los nombres de las columnas programáticamente...
            // Asigna la lista de tipos de inmuebles al DataGridView
            dataGridViewVentasPublicada.DataSource = null; // Primero establece el origen de datos a null
            dataGridViewVentasPublicada.DataSource = ventas;


            // Deja oculto el campo
            dataGridViewVentasPublicada.Columns["IdVenta"].Visible = false;
            dataGridViewVentasPublicada.Columns["IdTipoInmueble"].Visible = false;
            dataGridViewVentasPublicada.Columns["IdPropietario"].Visible = false;
            dataGridViewVentasPublicada.Columns["Activo"].Visible = false;
            

            dataGridViewPropiedades.Columns["PrecioVenta"].HeaderText = "Precio de Venta";


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
                        //tipoInmueble.PrecioAlquiler = tasacion.ImporteAlquiler;
                    }
                    else
                    {
                        tipoInmueble.PrecioVenta = 0; // Valor por defecto si no se encuentra la tasación
                        /*tipoInmueble.PrecioAlquiler = 0;*/ // Valor por defecto si no se encuentra la tasación
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
                dataGridViewPropiedades.Columns["PrecioAlquiler"].Visible = false;
                dataGridViewPropiedades.Columns["TieneReserva"].Visible = false;
                dataGridViewPropiedades.Columns["ImporteReserva"].Visible = false;
                //LimpiarCampos();
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
                

                // Cargar valores en los controles del formulario
                //txtDireccion.Text = direccion;
                txtDescripcion.Text = descripcion;


                txtPrecioVenta.Text = precioventa;
                label5.Text = precioventa;

                // Cargar nombres de provincia, partido y localidad en los ComboBox correspondientes
                Provincia provincia = ProvinciaManager.Instance.ObtenerProvinciaPorId(idProvincia);

                Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(idTipoInmueble);

                // Verificar si se encontró el propietario
                if (propietario != null)
                {
                    // Asignar los datos del propietario a los campos correspondientes en el formulario
                    txtNombreVendedor.Text = propietario.Nombre;
                    txtApellidoVendedor.Text = propietario.Apellido;
                    txtDNIVendedor.Text = propietario.DNI.ToString();
                }
                else
                {
                    // Si no se encuentra el propietario, mostrar el nombre de la inmobiliaria
                    txtNombreVendedor.Text = "Contultar Inmobiliaria";
                    // Limpiar los otros campos del propietario
                    txtApellidoVendedor.Clear();
                    txtDNIVendedor.Clear();
                }



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

            //Es el valor de la comisión
            lblTotalBoleto.Text = totalBoleto.ToString("C");
            
            lblTotalImpuesto.Text = totalImpuesto.ToString("C");
            lblTotalDineroPropiedad.Text = totalDineroPropiedad.ToString("C");
        }


        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener la fila seleccionada
        //        DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

        //        // Acceder a los valores de las celdas de la fila seleccionada
        //        Guid IdTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
        //        string precioVenta = selectedRow.Cells["PrecioVenta"].Value.ToString();
        //        //Guid IdPropietario = (Guid)selectedRow.Cells["IdPropietario"].Value;

        //        string TipoInmuebleNombre = (string)selectedRow.Cells["TipoInmuebleNombre"].Value;
        //        string Descripcion = (string)selectedRow.Cells["Descripcion"].Value;
        //        string Direccion = (string)selectedRow.Cells["Direccion"].Value;

        //        txtPrecioVenta.Text = precioVenta;

        //        // Obtener el valor de la comisión
        //        string textoCompleto = lblTotalBoleto.Text;

        //        // Eliminar caracteres no numéricos (dejar solo dígitos y la coma decimal)
        //        string soloDigitos = new string(textoCompleto.Where(c => char.IsDigit(c) || c == ',').ToArray());

        //        // Reemplazar la coma con el punto para asegurar un formato decimal válido
        //        soloDigitos = soloDigitos.Replace(',', '.');

        //        // Obtener el idpropietario usando el método BuscarPropietarioPorPropiedad de PropietarioManager
        //        Propietario propietarios = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(IdTipoInmueble);


        //        // Convertir a decimal
        //        if (decimal.TryParse(soloDigitos, out decimal comisionDecimal))
        //        {
        //            // Verificar si ya existe una venta creada
        //            Venta ventaExistente = VentaManager.Instance.ExixteVentaCreada(IdTipoInmueble);

        //            if (ventaExistente != null)
        //            {
        //                // Ya existe una venta creada, realizar la lógica necesaria (puede ser mostrar un mensaje)
        //                MessageBox.Show("Ya existe una venta creada para este tipo de inmueble.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                // Crear una instancia de la clase Venta
        //                Venta nuevaVenta = new Venta
        //                {
        //                    Importe = (int)decimal.Parse(precioVenta), // Convertir decimal a int,
        //                    Comision = comisionDecimal, // Utilizar el valor decimal
        //                    Activo = "1",
        //                    IdTipoInmueble = IdTipoInmueble,
        //                    IdPropietario = propietario.IdPropietario,
        //                    TipoInmuebleNombre = TipoInmuebleNombre,
        //                    Descripcion= Descripcion,
        //                    Direccion= Direccion,

        //                };

        //                // Llamar al método para guardar la venta en VentaManager
        //                bool ventaGuardada = VentaManager.Instance.GuardarVenta(nuevaVenta);

        //                // Verificar si la venta se guardó correctamente
        //                if (ventaGuardada)
        //                {
        //                    // Obtener el IdVenta
        //                    Venta IdVenta = VentaManager.Instance.ObtenerIdVenta(IdTipoInmueble);

        //                    // Obtener el propietario usando el método BuscarPropietarioPorPropiedad de PropietarioManager
        //                    Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(IdTipoInmueble);


        //                    // Obtengo el idAlquiler usando el método AptoContrato
        //                    Alquiler alquiler = AlquilerManager.Instance.AptoContrato(IdTipoInmueble);

        //                    // Obtengo el idCliente
        //                    Cliente cliente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);


        //                    // Obtengo el idComprador 
        //                    Compra comprador = ComprarManager.Instance.BuscarComprador(IdTipoInmueble);

        //                    Contrato contrato = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);

        //                    // Crear una instancia de la clase Inmobiliaria para registrar la operación
        //                    Inmobiliaria inmobiliaria = new Inmobiliaria
        //                    {
        //                        IdTipoInmueble = IdTipoInmueble,
        //                        IdPropietario = null,
        //                        //IdComprador = comprador != null ? comprador.IdComprador : Guid.Empty,
        //                        IdComprador = null,
        //                        IdAlquiler = alquiler != null ? alquiler.IdAlquiler : Guid.Empty, // Asegurarse de manejar el caso en que no se obtenga el alquiler
        //                        IdVenta = IdVenta.IdVenta,
        //                        IdContrato = null,
        //                        Detalle = "Venta registrada",
        //                        FechaOperacion = DateTime.Now,
        //                        Activo = "1",
        //                    };

        //                    // Llamar al método para registrar la operación en InmobiliariaManager
        //                    bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionVenta(inmobiliaria);

        //                    if (operacionRegistrada)
        //                    {
        //                        //MessageBox.Show("Venta guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        MessageBox.Show("Error al registrar la operación en InmobiliariaManager", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Venta guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        //MessageBox.Show("Error al registrar la operación en InmobiliariaManager", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                        VentasRegistradas();
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Error al guardar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al obtener el valor de la comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewPropiedades.SelectedRows[0];

                // Acceder a los valores de las celdas de la fila seleccionada
                Guid IdTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;
                string precioVenta = selectedRow.Cells["PrecioVenta"].Value.ToString();
                string TipoInmuebleNombre = (string)selectedRow.Cells["TipoInmuebleNombre"].Value;
                string Descripcion = (string)selectedRow.Cells["Descripcion"].Value;
                string Direccion = (string)selectedRow.Cells["Direccion"].Value;

                // Obtener el valor de la comisión
                string textoCompleto = lblTotalBoleto.Text;

                // Eliminar caracteres no numéricos (dejar solo dígitos y la coma decimal)
                string soloDigitos = new string(textoCompleto.Where(c => char.IsDigit(c) || c == ',').ToArray());

                // Reemplazar la coma con el punto para asegurar un formato decimal válido
                soloDigitos = soloDigitos.Replace(',', '.');

                // Obtener el propietario usando el método BuscarPropietarioPorPropiedad de PropietarioManager
                Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(IdTipoInmueble);

                // Convertir a decimal
                if (decimal.TryParse(soloDigitos, out decimal comisionDecimal))
                {
                    // Crear una instancia de la clase Venta
                    Venta nuevaVenta = new Venta
                    {
                        Importe = (int)decimal.Parse(precioVenta), // Convertir decimal a int
                        Comision = comisionDecimal,
                        Activo = "1",
                        IdTipoInmueble = IdTipoInmueble,
                        IdPropietario = propietario != null ? propietario.IdPropietario : Guid.Empty,
                        TipoInmuebleNombre = TipoInmuebleNombre,
                        Descripcion = Descripcion,
                        Direccion = Direccion
                    };

                    // Verificar si el IdPropietario es nulo y el nombre del vendedor es específico
                    if (PropietarioManager.Instance.BuscarPropietarioPorPropiedad(IdTipoInmueble) == null &&
                        txtNombreVendedor.Text == "Contultar Inmobiliaria MYIMBO")
                    {
                        MessageBox.Show("Propiedad sin Propietario asignado, asignar Propiedad a un Propietario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Cancela el registro de la venta
                    }

                    // Llamar al método para guardar la venta en VentaManager
                    bool ventaGuardada = VentaManager.Instance.GuardarVenta(nuevaVenta);

                    // Verificar si la venta se guardó correctamente
                    if (ventaGuardada)
                    {
                        MessageBox.Show("Venta guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Obtener el IdVenta
                        Venta IdVenta = VentaManager.Instance.ObtenerIdVenta(IdTipoInmueble);

                        // Obtener el idAlquiler usando el método AptoContrato
                        Alquiler alquiler = AlquilerManager.Instance.AptoContrato(IdTipoInmueble);

                        // Obtener el idCliente
                        Cliente cliente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);

                        // Obtener el idComprador
                        Compra comprador = ComprarManager.Instance.BuscarComprador(IdTipoInmueble);

                        //// Crear una instancia de la clase Inmobiliaria para registrar la operación
                        //Inmobiliaria inmobiliaria = new Inmobiliaria
                        //{
                        //    IdTipoInmueble = IdTipoInmueble,
                        //    IdPropietario = null,
                        //    IdComprador = null,
                        //    IdAlquiler = alquiler != null ? alquiler.IdAlquiler : Guid.Empty, // Asegurarse de manejar el caso en que no se obtenga el alquiler
                        //    IdVenta = IdVenta.IdVenta,
                        //    IdContrato = null,
                        //    Detalle = "Venta registrada",
                        //    FechaOperacion = DateTime.Now,
                        //    Activo = "1"
                        //};

                        //// Llamar al método para registrar la operación en InmobiliariaManager
                        //bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionVenta(inmobiliaria);

                        //if (operacionRegistrada)
                        //{
                        //    MessageBox.Show("Operación registrada correctamente en Inmobiliaria", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    VentasRegistradas();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Error al registrar la operación en Inmobiliaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el valor de la comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe borrar la venta y solicitar una nueva tasación");
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el dataGridViewVentasPublicada
                if (dataGridViewVentasPublicada.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow selectedRow = dataGridViewVentasPublicada.SelectedRows[0];

                    // Obtener el IdVenta de la fila seleccionada
                    Guid idVenta = (Guid)selectedRow.Cells["IdVenta"].Value;
                    decimal importe = (int)selectedRow.Cells["Importe"].Value;
                    decimal comision = (decimal)selectedRow.Cells["Comision"].Value;

                    Guid idTipoInmueble = (Guid)selectedRow.Cells["IdTipoInmueble"].Value;

                    Guid idPropietario = (Guid)selectedRow.Cells["IdPropietario"].Value;

                    string nombreInmueble = selectedRow.Cells["TipoInmuebleNombre"].Value.ToString();
                    string descripcion = selectedRow.Cells["Descripcion"].Value.ToString();
                    string direccion = selectedRow.Cells["Direccion"].Value.ToString();

                    // Crear una instancia de la clase Venta
                    Venta actualizarVenta = new Venta
                    {
                        IdVenta = idVenta,
                        Importe = (int)importe,
                        Comision = comision,
                        Activo = "0",
                        IdTipoInmueble = idTipoInmueble,
                        IdPropietario = idPropietario,
                        TipoInmuebleNombre = nombreInmueble,
                        Descripcion = descripcion,
                        Direccion = direccion
                    };

                    // Actualizar el valor del campo Activo a 0 en la base de datos
                    bool actualizacionExitosa = VentaManager.Instance.ModificarVenta(actualizarVenta);

                    // Verificar si la actualización fue exitosa
                    if (actualizacionExitosa)
                    {
                        MessageBox.Show("Venta borrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar la vista de las ventas registradas
                        VentasRegistradas();

                        // Crear una instancia de la clase Inmobiliaria para registrar la operación
                        Inmobiliaria inmobiliaria = new Inmobiliaria
                        {
                            IdTipoInmueble = idTipoInmueble,
                            IdPropietario = idPropietario,
                            IdComprador = null,
                            IdAlquiler = null,
                            IdVenta = idVenta,
                            IdContrato = null,
                            Detalle = "Registro de Compra borrado",
                            FechaOperacion = DateTime.Now,
                            Activo = "0",
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

                    }
                    else
                    {
                        MessageBox.Show("Error al modificar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una venta para modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la modificación de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewVentasPublicada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            txtPrecioVenta.Text= string.Empty;

            txtNombreVendedor.Text= string.Empty;
            txtApellidoVendedor.Text= string.Empty;
            txtDNIVendedor.Text= string.Empty;

            ComboBoxTipoPropiedad.Text= string.Empty;
            lblTotalBoleto.Text= string.Empty;
            label5.Text= string.Empty;
            lblTotalImpuesto.Text= string.Empty;
            lblTotalDineroPropiedad.Text = string.Empty;

            checkBox1.Text = string.Empty;
            checkBox2.Text = string.Empty;
            checkBox3.Text = string.Empty;
            checkBox4.Text = string.Empty;


        }
    }
}
