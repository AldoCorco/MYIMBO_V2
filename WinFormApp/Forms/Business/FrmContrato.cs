using BLL;
using CrystalDecisions.ReportAppServer.DataDefModel;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace WinFormApp.Forms.Business
{
    public partial class FrmContrato : Form
    {
        private Guid idTipoInmueble;
        private Guid idEscribania;
        private Guid IdCliente;
        private Guid? idPropietario;

        public Guid IdTipoInmueble { get; set; }
        public Guid IdEscribania { get; set; }
        public Guid IdAlquiler { get; set; }
        public Alquiler Alquiler { get; }
        public TipoInmueble TipoInmueble { get; }
        public Escribania Escribania { get; }

        public FrmContrato(Guid idAlquiler, Guid idTipoInmueble, Guid idEscribania)

        {
            InitializeComponent();

            // Registra este formulario para escuchar el cambio de idioma;
            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

            // Asignar los valores recibidos a las propiedades del formulario
            IdTipoInmueble = idTipoInmueble;
            IdEscribania = idEscribania;
            IdAlquiler = idAlquiler;
  

            CargarDatosCliente();
            CargarDatosContrato();

        }

        public FrmContrato(Alquiler alquiler, TipoInmueble tipoInmueble, Escribania escribania)
        {
            Alquiler = alquiler;
            TipoInmueble = tipoInmueble;
            Escribania = escribania;
        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblNombre.Text = LanguageBLL.Traducir("Nombre", lang);
                lblApellido.Text = LanguageBLL.Traducir("Apellido", lang);
                lblLegajoInquilino.Text = LanguageBLL.Traducir("Legajo Inquilino", lang);
                lblFechaNacimiento.Text = LanguageBLL.Traducir("Fecha de Nacimiento", lang);
                lblTelefono.Text = LanguageBLL.Traducir("Telefono", lang);
                lblFechaInicioContrato.Text = LanguageBLL.Traducir("Fecha de Inicio del Contrato", lang);
                lblFechaFinContrato.Text = LanguageBLL.Traducir("Fecha de Fin del Contrato", lang);
                btnGuardarContrato.Text = LanguageBLL.Traducir("Guardar Contrato", lang);
                btnModificarContrato.Text = LanguageBLL.Traducir("Modificar Contrato", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);

                groupBox2.Text = LanguageBLL.Traducir("Propietario", lang);
                lblNombre2.Text = LanguageBLL.Traducir("Nombre", lang);
                lblApellido2.Text = LanguageBLL.Traducir("Apellido", lang);
                lblDNI2.Text = LanguageBLL.Traducir("DNI", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosCliente()
        {
            try
            {
                //IdCliente
                //IdTipoInmueble
                // Obtener los datos del cliente desde ClienteManager (suponiendo que haya un método para obtener los datos del cliente)
                Cliente cliente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble); // Aquí debes proporcionar el ID del cliente

                if (cliente != null)
                {
                    // Mostrar los datos del cliente en los campos correspondientes del formulario
                    txtLegajoInquilino.Text = cliente.LegajoInquilino.ToString();
                    txtNombreInquilino.Text = cliente.Nombre;
                    txtApellidoInquilino.Text = cliente.Apellido;
                    txtDNI_Inquilino.Text = cliente.DNI.ToString();
                    txtTelefono.Text = cliente.Telefono;
                    dateTimePickerFechNac.Value = cliente.FechaNacimiento;
                }
                else
                {
                    // Dejar los campos de texto vacíos
                    txtLegajoInquilino.Text = string.Empty;
                    txtNombreInquilino.Text = string.Empty;
                    txtApellidoInquilino.Text = string.Empty;
                    txtDNI_Inquilino.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    // Establecer las fechas en la fecha actual
                    dateTimePickerFechNac.Value = DateTime.Today;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosContrato()
        {
            try
            {
                Contrato contrato = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);
                if (contrato != null)
                {
                    // Mostrar los datos del cliente en los campos correspondientes del formulario
                    dateTimePickerInicioContrato.Value = contrato.FechaInicio;
                    dateTimePickerFinContrato.Value = contrato.FechaFin;

                }
                else
                {
                    // Establecer las fechas en la fecha actual
                    dateTimePickerInicioContrato.Value = DateTime.Today;
                    dateTimePickerFinContrato.Value = DateTime.Today;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmContrato_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener el idTipoInmueble seleccionado (deberías tenerlo definido en tu formulario)
                Guid idTipoInmueble = IdTipoInmueble;


                // Obtener el propietario asociado al idTipoInmueble
                Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(idTipoInmueble);

                // Verificar si se encontró el propietario
                if (propietario != null)
                {
                    // Asignar los datos del propietario a los campos correspondientes en el formulario
                    txtNombrePropietario.Text = propietario.Nombre;
                    txtApellidoPropietario.Text = propietario.Apellido;
                    txtDNIPropietario.Text = propietario.DNI.ToString();
                }
                else
                {
                    // Si no se encuentra el propietario, mostrar el nombre de la inmobiliaria
                    txtNombrePropietario.Text = "Inmobiliaria MYIMBO";
                    // Limpiar los otros campos del propietario
                    txtApellidoPropietario.Clear();
                    txtDNIPropietario.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del propietario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGuardarContrato_Click(object sender, EventArgs e)
        {
            // Obtén los datos del formulario
            int legajoInquilino = int.Parse(txtLegajoInquilino.Text);
            string nombreInquilino = txtNombreInquilino.Text;
            string apellifoInquilino = txtApellidoInquilino.Text;
            int dniIquilino = int.Parse(txtDNI_Inquilino.Text);
            string telefono = txtTelefono.Text;
            DateTime fechaNac = dateTimePickerFechNac.Value;

            // Crea una nueva instancia de la clase Cliente con los datos del formulario
            Cliente nuevoCliente = new Cliente
            {
                IdCliente = Guid.NewGuid(), // Genera un nuevo ID para el cliente
                LegajoInquilino = legajoInquilino,
                Nombre = nombreInquilino,
                Apellido = apellifoInquilino,
                DNI = dniIquilino,
                FechaNacimiento = fechaNac,
                Telefono = telefono,
                IdTipoInmueble = IdTipoInmueble,
            };

            // Intenta agregar el nuevo cliente utilizando el ClienteManager
            bool exitoCliente = ClienteManager.Instance.AgregarCliente(nuevoCliente);

            if (!exitoCliente)
            {
                MessageBox.Show("Error al agregar el cliente. Por favor, inténtelo de nuevo.");
                return;
            }

            DateTime fechaInicioContrato = dateTimePickerInicioContrato.Value;
            DateTime fechaFinContrato = dateTimePickerFinContrato.Value;

            //Contrato contrato = ContratoManager.Instance.BuscarContrato(idTipoInmueble);
            Cliente cliente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);

            Contrato nuevoContrato = new Contrato
            {
                IdContrato = Guid.NewGuid(),
                FechaInicio = fechaInicioContrato,
                FechaFin = fechaFinContrato,
                IdEscribania = IdEscribania,
                IdTipoInmueble = IdTipoInmueble,
                IdAlquiler = IdAlquiler,
                IdCliente = cliente.IdCliente,
            };

            // Intenta agregar el nuevo contrato utilizando el ContratoManager
            bool exitoContrato = ContratoManager.Instance.AgregarContrato(nuevoContrato);

            if (exitoContrato)
            {
                MessageBox.Show("Contrato agregada correctamente.");
                //LimpiarCampos(); // Método para limpiar los campos del formulario
                // Después de actualiza, recarga la lista si es necesario
                //ListarTodasLasEscribanias();
            }
            else
            {
                MessageBox.Show("Error al agregar el contrato. Por favor, inténtelo de nuevo.");
            }

            // Obtener el contrato asociado al idTipoInmueble

            Propietario propietario = PropietarioManager.Instance.BuscarPropietarioPorPropiedad(IdTipoInmueble);

            Contrato contrato = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);

            //// Crear una instancia de la clase Inmobiliaria para registrar la operación
            //Inmobiliaria inmobiliaria = new Inmobiliaria
            //{
            //    IdTipoInmueble = nuevoContrato.IdTipoInmueble,
            //    IdPropietario = propietario.IdPropietario,
            //    IdComprador = null,
            //    IdAlquiler = nuevoContrato.IdAlquiler,
            //    IdVenta = null,
            //    IdContrato = null,
            //    Detalle = "Contrato de alquiler registrado",
            //    FechaOperacion = DateTime.Now,
            //    Activo = "1"
            //};

            //// Llamar al método para registrar la operación en InmobiliariaManager
            //bool operacionRegistrada = InmobiliariaManager.Instance.RegistrarOperacionResevaAlquiler(inmobiliaria);

            //if (operacionRegistrada)
            //{
            //    MessageBox.Show("Operación Contrato de Alquiler registrada en Inmobiliaria.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //LimpiarCampos(); // Método para limpiar los campos del formulario
            //}
            //else
            //{
            //    MessageBox.Show("Error el registrar la operación en Inmobiliaria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void LimpiarCampos()
        {
            txtLegajoInquilino.Text = string.Empty;
            txtNombreInquilino.Text = string.Empty;
            txtApellidoInquilino.Text = string.Empty;
            txtDNI_Inquilino.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            dateTimePickerFechNac.Value = DateTime.Now; // fecha actual

            dateTimePickerInicioContrato.Value = DateTime.Now; // fecha actual
            dateTimePickerFinContrato.Value = DateTime.Now; // fecha actual

        }

        //private void btnModificarContrato_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtén los datos del formulario
        //        int legajoInquilino = int.Parse(txtLegajoInquilino.Text);
        //        string nombreInquilino = txtNombreInquilino.Text;
        //        string apellidoInquilino = txtApellidoInquilino.Text;
        //        int dniInquilino = int.Parse(txtDNI_Inquilino.Text);
        //        string telefono = txtTelefono.Text;
        //        DateTime fechaNacimiento = dateTimePickerFechNac.Value;

        //        // Buscar el contrato existente
        //        Contrato contratoExistente = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);


        //        if (contratoExistente == null)
        //        {
        //            MessageBox.Show("No se encontró el contrato existente. Por favor, asegúrese de que el contrato esté registrado.");
        //            return;
        //        }

        //        // Actualiza los datos del cliente existente
        //        Cliente clienteExistente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);

        //        if (clienteExistente == null)
        //        {
        //            MessageBox.Show("No se encontró el cliente existente asociado al contrato. Por favor, asegúrese de que el cliente esté registrado.");
        //            return;
        //        }

        //        clienteExistente.LegajoInquilino = legajoInquilino;
        //        clienteExistente.Nombre = nombreInquilino;
        //        clienteExistente.Apellido = apellidoInquilino;
        //        clienteExistente.DNI = dniInquilino;
        //        clienteExistente.FechaNacimiento = fechaNacimiento;
        //        clienteExistente.Telefono = telefono;

        //        // Intenta actualizar el cliente utilizando el ClienteManager
        //        bool exitoCliente = ClienteManager.Instance.ModificarCliente(clienteExistente);

        //        if (!exitoCliente)
        //        {
        //            MessageBox.Show("Error al actualizar el cliente. Por favor, inténtelo de nuevo.");
        //            return;
        //        }

        //        // Obtén los datos del contrato del formulario
        //        DateTime fechaInicioContrato = dateTimePickerInicioContrato.Value;
        //        DateTime fechaFinContrato = dateTimePickerFinContrato.Value;

        //        contratoExistente.FechaInicio = fechaInicioContrato;
        //        contratoExistente.FechaFin = fechaFinContrato;

        //        // Intenta actualizar el contrato utilizando el ContratoManager
        //        bool exitoContrato = ContratoManager.Instance.ModificarContrato(contratoExistente);

        //        if (exitoContrato)
        //        {
        //            MessageBox.Show("Contrato actualizado correctamente.");

        //            //Recargo los datos
        //            //CargarDatosCliente();
        //            //CargarDatosContrato();


        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al actualizar el contrato. Por favor, inténtelo de nuevo.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al procesar la modificación del contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //----
        //private void btnModificarContrato_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtén los datos del formulario
        //        int legajoInquilino = int.Parse(txtLegajoInquilino.Text);
        //        string nombreInquilino = txtNombreInquilino.Text;
        //        string apellidoInquilino = txtApellidoInquilino.Text;
        //        int dniInquilino = int.Parse(txtDNI_Inquilino.Text);
        //        string telefono = txtTelefono.Text;
        //        DateTime fechaNacimiento = dateTimePickerFechNac.Value;

        //        // Buscar el contrato existente
        //        Contrato contratoExistente = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);

        //        if (contratoExistente == null)
        //        {
        //            MessageBox.Show("No se encontró el contrato existente. Por favor, asegúrese de que el contrato esté registrado.");
        //            return;
        //        }

        //        // Verificar si el IdCliente está configurado correctamente en el contrato
        //        if (contratoExistente.IdCliente == null)
        //        {
        //            MessageBox.Show("El contrato existente no tiene un cliente asociado. Por favor, asegúrese de que el cliente esté asignado correctamente.");
        //            return;
        //        }

        //        // Buscar los datos del cliente existente asociado al contrato
        //        Cliente clienteExistente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);

        //        if (clienteExistente == null)
        //        {
        //            MessageBox.Show("No se encontró el cliente existente asociado al contrato. Por favor, asegúrese de que el cliente esté registrado.");
        //            return;
        //        }

        //        // Actualizar los datos del cliente existente
        //        clienteExistente.LegajoInquilino = legajoInquilino;
        //        clienteExistente.Nombre = nombreInquilino;
        //        clienteExistente.Apellido = apellidoInquilino;
        //        clienteExistente.DNI = dniInquilino;
        //        clienteExistente.FechaNacimiento = fechaNacimiento;
        //        clienteExistente.Telefono = telefono;

        //        // Intenta actualizar el cliente utilizando el ClienteManager
        //        bool exitoCliente = ClienteManager.Instance.ModificarCliente(clienteExistente);

        //        if (!exitoCliente)
        //        {
        //            MessageBox.Show("Error al actualizar el cliente. Por favor, inténtelo de nuevo.");
        //            return;
        //        }

        //        // Obtén los datos del contrato del formulario
        //        DateTime fechaInicioContrato = dateTimePickerInicioContrato.Value;
        //        DateTime fechaFinContrato = dateTimePickerFinContrato.Value;

        //        contratoExistente.FechaInicio = fechaInicioContrato;
        //        contratoExistente.FechaFin = fechaFinContrato;

        //        // Intenta actualizar el contrato utilizando el ContratoManager
        //        bool exitoContrato = ContratoManager.Instance.ModificarContrato(contratoExistente);

        //        if (exitoContrato)
        //        {
        //            MessageBox.Show("Contrato actualizado correctamente.");

        //            // Recargar los datos si es necesario
        //            // CargarDatosCliente();
        //            // CargarDatosContrato();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al actualizar el contrato. Por favor, inténtelo de nuevo.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al procesar la modificación del contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //--

        private void btnModificarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén los datos del formulario
                int legajoInquilino = int.Parse(txtLegajoInquilino.Text);
                string nombreInquilino = txtNombreInquilino.Text;
                string apellidoInquilino = txtApellidoInquilino.Text;
                int dniInquilino = int.Parse(txtDNI_Inquilino.Text);
                string telefono = txtTelefono.Text;
                DateTime fechaNacimiento = dateTimePickerFechNac.Value;

                // Buscar el contrato existente asociado al IdTipoInmueble
                Contrato contratoExistente = ContratoManager.Instance.BuscarContrato(IdTipoInmueble);

                if (contratoExistente == null)
                {
                    MessageBox.Show("No se encontró el contrato existente. Por favor, asegúrese de que el contrato esté registrado.");
                    return;
                }

                // Verificar si el IdCliente está configurado correctamente en el contrato
                if (contratoExistente.IdCliente == null)
                {
                    MessageBox.Show("El contrato existente no tiene un cliente asociado. Por favor, asegúrese de que el cliente esté asignado correctamente.");
                    return;
                }

                // Buscar el cliente existente asociado al IdTipoInmueble
                Cliente clienteExistente = ClienteManager.Instance.ObtenerCliente(IdTipoInmueble);

                if (clienteExistente == null)
                {
                    MessageBox.Show("No se encontró el cliente existente asociado al contrato. Por favor, asegúrese de que el cliente esté registrado.");
                    return;
                }

                // Actualizar los datos del cliente existente
                clienteExistente.LegajoInquilino = legajoInquilino;
                clienteExistente.Nombre = nombreInquilino;
                clienteExistente.Apellido = apellidoInquilino;
                clienteExistente.DNI = dniInquilino;
                clienteExistente.FechaNacimiento = fechaNacimiento;
                clienteExistente.Telefono = telefono;

                // Intenta actualizar el cliente utilizando el ClienteManager
                bool exitoCliente = ClienteManager.Instance.ModificarCliente(clienteExistente);

                if (!exitoCliente)
                {
                    MessageBox.Show("Error al actualizar el cliente. Por favor, inténtelo de nuevo.");
                    return;
                }

                // Obtén los datos del contrato del formulario
                DateTime fechaInicioContrato = dateTimePickerInicioContrato.Value;
                DateTime fechaFinContrato = dateTimePickerFinContrato.Value;

                contratoExistente.FechaInicio = fechaInicioContrato;
                contratoExistente.FechaFin = fechaFinContrato;

                // Intenta actualizar el contrato utilizando el ContratoManager
                bool exitoContrato = ContratoManager.Instance.ModificarContrato(contratoExistente);

                if (exitoContrato)
                {
                    MessageBox.Show("Contrato actualizado correctamente.");

                    // Recargar los datos si es necesario
                    // CargarDatosCliente();
                    // CargarDatosContrato();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el contrato. Por favor, inténtelo de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la modificación del contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLegajoInquilino.Text = string.Empty;
            txtNombreInquilino.Text = string.Empty;
            txtApellidoInquilino.Text = string.Empty;
            txtDNI_Inquilino.Text = string.Empty;
            txtTelefono.Text = string.Empty;

            dateTimePickerFechNac.Value = DateTime.Now; // fecha actual
            dateTimePickerInicioContrato.Value = DateTime.Now; // fecha actual
            dateTimePickerFinContrato.Value = DateTime.Now; // fecha actual
        }



        //private void btnImprimirContrato_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener los datos del cliente
        //        string legajoInquilino = txtLegajoInquilino.Text;
        //        string nombreInquilino = txtNombreInquilino.Text;
        //        string apellidoInquilino = txtApellidoInquilino.Text;
        //        string dniInquilino = txtDNI_Inquilino.Text;
        //        string telefono = txtTelefono.Text;
        //        string fechaNacimiento = dateTimePickerFechNac.Value.ToShortDateString();

        //        // Obtener los datos del contrato
        //        string fechaInicioContrato = dateTimePickerInicioContrato.Value.ToShortDateString();
        //        string fechaFinContrato = dateTimePickerFinContrato.Value.ToShortDateString();

        //        // Obtener los datos del propietario (si están disponibles en los campos correspondientes)
        //        string nombrePropietario = txtNombrePropietario.Text;
        //        string apellidoPropietario = txtApellidoPropietario.Text;
        //        string dniPropietario = txtDNIPropietario.Text;

        //        //Obtener direccion
        //        TipoInmueble propiedad = TipoInmuebleManager.Instance.ObtenerTipoInmueblePorId(IdTipoInmueble);
        //        String descripcion = propiedad.Descripcion;
        //        String tipoinmueble = propiedad.TipoInmuebleNombre;
        //        string direccion = propiedad.Direccion;

        //        // Ruta donde se guardará el archivo PDF
        //        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ContratoAlquiler.pdf");

        //        // Crear el documento PDF
        //        Document doc = new Document();
        //        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
        //        doc.Open();

        //        // Configurar el formato y el estilo del texto
        //        iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
        //        Paragraph paragraph = new Paragraph();

        //        // Agregar los datos del contrato al documento
        //        paragraph.Add(new Chunk("Contrato de Alquiler\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
        //        paragraph.Add(new Chunk("=================================\n", font));
        //        paragraph.Add(new Chunk("---------------------------------\n", font));
        //        paragraph.Add(new Chunk($"Legajo Inquilino: {legajoInquilino}\n", font));
        //        paragraph.Add(new Chunk($"Nombre Inquilino: {nombreInquilino}\n", font));
        //        paragraph.Add(new Chunk($"Apellido Inquilino: {apellidoInquilino}\n", font));
        //        paragraph.Add(new Chunk($"DNI Inquilino: {dniInquilino}\n", font));
        //        paragraph.Add(new Chunk($"Teléfono: {telefono}\n", font));
        //        paragraph.Add(new Chunk($"Fecha de Nacimiento: {fechaNacimiento}\n", font));
        //        paragraph.Add(new Chunk("", font));
        //        paragraph.Add(new Chunk($"Descripcion: {descripcion}\n", font));
        //        paragraph.Add(new Chunk($"Dirección: {direccion}\n", font));
        //        paragraph.Add(new Chunk("", font));
        //        paragraph.Add(new Chunk("---------------------------------\n", font));
        //        paragraph.Add(new Chunk($"Fecha de Inicio del Contrato: {fechaInicioContrato}\n", font));
        //        paragraph.Add(new Chunk($"Fecha de Fin del Contrato: {fechaFinContrato}\n", font));
        //        paragraph.Add(new Chunk("---------------------------------\n", font));
        //        paragraph.Add(new Chunk("=================================\n", font));

        //        // Si los datos del propietario están disponibles, agregarlos al contrato
        //        if (!string.IsNullOrEmpty(nombrePropietario) && !string.IsNullOrEmpty(apellidoPropietario) && !string.IsNullOrEmpty(dniPropietario))
        //        {
        //            paragraph.Add(new Chunk("=================================\n", font));
        //            paragraph.Add(new Chunk("---------------------------------\n", font));
        //            paragraph.Add(new Chunk("Datos del Propietario:\n", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk($"Nombre: {nombrePropietario}\n", font));
        //            paragraph.Add(new Chunk($"Apellido: {apellidoPropietario}\n", font));
        //            paragraph.Add(new Chunk($"DNI: {dniPropietario}\n", font));
        //            paragraph.Add(new Chunk("---------------------------------\n", font));
        //            paragraph.Add(new Chunk("=================================\n", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk("", font));
        //        }

        //        paragraph.Add(new Chunk($"Firma Propietario: ___________________", font));
        //        paragraph.Add(new Chunk("", font));
        //        paragraph.Add(new Chunk("", font));
        //        paragraph.Add(new Chunk($"Firma Inquilino:   ___________________", font));

        //        // Agregar el párrafo al documento
        //        doc.Add(paragraph);

        //        // Cerrar el documento
        //        doc.Close();

        //        // Mostrar un mensaje de éxito
        //        MessageBox.Show("Contrato generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        // Abrir el archivo PDF generado
        //        System.Diagnostics.Process.Start(filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnImprimirContrato_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener los datos del cliente
        //        string legajoInquilino = txtLegajoInquilino.Text;
        //        string nombreInquilino = txtNombreInquilino.Text;
        //        string apellidoInquilino = txtApellidoInquilino.Text;
        //        string dniInquilino = txtDNI_Inquilino.Text;
        //        string telefono = txtTelefono.Text;
        //        string fechaNacimiento = dateTimePickerFechNac.Value.ToShortDateString();

        //        // Obtener los datos del contrato
        //        string fechaInicioContrato = dateTimePickerInicioContrato.Value.ToShortDateString();
        //        string fechaFinContrato = dateTimePickerFinContrato.Value.ToShortDateString();

        //        // Obtener los datos del propietario (si están disponibles en los campos correspondientes)
        //        string nombrePropietario = txtNombrePropietario.Text;
        //        string apellidoPropietario = txtApellidoPropietario.Text;
        //        string dniPropietario = txtDNIPropietario.Text;

        //        //Obtener direccion
        //        TipoInmueble propiedad = TipoInmuebleManager.Instance.ObtenerTipoInmueblePorId(IdTipoInmueble);
        //        String descripcion = propiedad.Descripcion;
        //        String tipoinmueble = propiedad.TipoInmuebleNombre;
        //        string direccion = propiedad.Direccion;

        //        // Crear un MemoryStream para almacenar el PDF en la memoria
        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            // Crear el documento PDF
        //            Document doc = new Document();
        //            PdfWriter.GetInstance(doc, memoryStream);
        //            doc.Open();

        //            // Configurar el formato y el estilo del texto
        //            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
        //            Paragraph paragraph = new Paragraph();

        //            // Agregar los datos del contrato al documento
        //            paragraph.Add(new Chunk("Contrato de Alquiler\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
        //            paragraph.Add(new Chunk("=================================\n", font));
        //            paragraph.Add(new Chunk("---------------------------------\n", font));
        //            paragraph.Add(new Chunk($"Legajo Inquilino: {legajoInquilino}\n", font));
        //            paragraph.Add(new Chunk($"Nombre Inquilino: {nombreInquilino}\n", font));
        //            paragraph.Add(new Chunk($"Apellido Inquilino: {apellidoInquilino}\n", font));
        //            paragraph.Add(new Chunk($"DNI Inquilino: {dniInquilino}\n", font));
        //            paragraph.Add(new Chunk($"Teléfono: {telefono}\n", font));
        //            paragraph.Add(new Chunk($"Fecha de Nacimiento: {fechaNacimiento}\n", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk($"Descripcion: {descripcion}\n", font));
        //            paragraph.Add(new Chunk($"Dirección: {direccion}\n", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk("---------------------------------\n", font));
        //            paragraph.Add(new Chunk($"Fecha de Inicio del Contrato: {fechaInicioContrato}\n", font));
        //            paragraph.Add(new Chunk($"Fecha de Fin del Contrato: {fechaFinContrato}\n", font));
        //            paragraph.Add(new Chunk("---------------------------------\n", font));
        //            paragraph.Add(new Chunk("=================================\n", font));

        //            // Si los datos del propietario están disponibles, agregarlos al contrato
        //            if (!string.IsNullOrEmpty(nombrePropietario) && !string.IsNullOrEmpty(apellidoPropietario) && !string.IsNullOrEmpty(dniPropietario))
        //            {
        //                paragraph.Add(new Chunk("=================================\n", font));
        //                paragraph.Add(new Chunk("---------------------------------\n", font));
        //                paragraph.Add(new Chunk("Datos del Propietario:\n", font));
        //                paragraph.Add(new Chunk("", font));
        //                paragraph.Add(new Chunk($"Nombre: {nombrePropietario}\n", font));
        //                paragraph.Add(new Chunk($"Apellido: {apellidoPropietario}\n", font));
        //                paragraph.Add(new Chunk($"DNI: {dniPropietario}\n", font));
        //                paragraph.Add(new Chunk("---------------------------------\n", font));
        //                paragraph.Add(new Chunk("=================================\n", font));
        //                paragraph.Add(new Chunk("", font));
        //                paragraph.Add(new Chunk("", font));
        //            }

        //            paragraph.Add(new Chunk($"Firma Propietario: ___________________", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk("", font));
        //            paragraph.Add(new Chunk($"Firma Inquilino:   ___________________", font));

        //            // Agregar el párrafo al documento
        //            doc.Add(paragraph);

        //            // Cerrar el documento
        //            doc.Close();

        //            // Convertir el MemoryStream en un array de bytes
        //            byte[] pdfBytes = memoryStream.ToArray();

        //            // Mostrar un mensaje de éxito
        //            MessageBox.Show("Contrato generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Abrir el archivo PDF generado
        //            using (MemoryStream ms = new MemoryStream(pdfBytes))
        //            {


        //                try
        //                {
        //                    var PdfDocument = new PdfDocumentViewer();
        //                    PdfDocument.Load(ms);
        //                    PdfDocument.ShowDialog();
        //                }
        //                finally
        //                {

        //                    dbLayer.Dispose();
        //                }

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnImprimirContrato_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del cliente
                string legajoInquilino = txtLegajoInquilino.Text;
                string nombreInquilino = txtNombreInquilino.Text;
                string apellidoInquilino = txtApellidoInquilino.Text;
                string dniInquilino = txtDNI_Inquilino.Text;
                string telefono = txtTelefono.Text;
                string fechaNacimiento = dateTimePickerFechNac.Value.ToShortDateString();

                // Obtener los datos del contrato
                string fechaInicioContrato = dateTimePickerInicioContrato.Value.ToShortDateString();
                string fechaFinContrato = dateTimePickerFinContrato.Value.ToShortDateString();

                // Obtener los datos del propietario (si están disponibles en los campos correspondientes)
                string nombrePropietario = txtNombrePropietario.Text;
                string apellidoPropietario = txtApellidoPropietario.Text;
                string dniPropietario = txtDNIPropietario.Text;

                //Obtener direccion
                TipoInmueble propiedad = TipoInmuebleManager.Instance.ObtenerTipoInmueblePorId(IdTipoInmueble);
                String descripcion = propiedad.Descripcion;
                String tipoinmueble = propiedad.TipoInmuebleNombre;
                string direccion = propiedad.Direccion;

                // Crear un MemoryStream para almacenar el PDF en la memoria
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Crear el documento PDF
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, memoryStream);
                    doc.Open();

                    // Configurar el formato y el estilo del texto
                    iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                    Paragraph paragraph = new Paragraph();

                    // Agregar los datos del contrato al documento
                    paragraph.Add(new Chunk("Contrato de Alquiler\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
                    paragraph.Add(new Chunk("=================================\n", font));
                    paragraph.Add(new Chunk("---------------------------------\n", font));
                    paragraph.Add(new Chunk($"Legajo Inquilino: {legajoInquilino}\n", font));
                    paragraph.Add(new Chunk($"Nombre Inquilino: {nombreInquilino}\n", font));
                    paragraph.Add(new Chunk($"Apellido Inquilino: {apellidoInquilino}\n", font));
                    paragraph.Add(new Chunk($"DNI Inquilino: {dniInquilino}\n", font));
                    paragraph.Add(new Chunk($"Teléfono: {telefono}\n", font));
                    paragraph.Add(new Chunk($"Fecha de Nacimiento: {fechaNacimiento}\n", font));
                    paragraph.Add(new Chunk("", font));
                    paragraph.Add(new Chunk($"Descripcion: {descripcion}\n", font));
                    paragraph.Add(new Chunk($"Dirección: {direccion}\n", font));
                    paragraph.Add(new Chunk("", font));
                    paragraph.Add(new Chunk("---------------------------------\n", font));
                    paragraph.Add(new Chunk($"Fecha de Inicio del Contrato: {fechaInicioContrato}\n", font));
                    paragraph.Add(new Chunk($"Fecha de Fin del Contrato: {fechaFinContrato}\n", font));
                    paragraph.Add(new Chunk("---------------------------------\n", font));
                    paragraph.Add(new Chunk("=================================\n", font));

                    // Si los datos del propietario están disponibles, agregarlos al contrato
                    if (!string.IsNullOrEmpty(nombrePropietario) && !string.IsNullOrEmpty(apellidoPropietario) && !string.IsNullOrEmpty(dniPropietario))
                    {
                        paragraph.Add(new Chunk("=================================\n", font));
                        paragraph.Add(new Chunk("---------------------------------\n", font));
                        paragraph.Add(new Chunk("Datos del Propietario:\n", font));
                        paragraph.Add(new Chunk("", font));
                        paragraph.Add(new Chunk($"Nombre: {nombrePropietario}\n", font));
                        paragraph.Add(new Chunk($"Apellido: {apellidoPropietario}\n", font));
                        paragraph.Add(new Chunk($"DNI: {dniPropietario}\n", font));
                        paragraph.Add(new Chunk("---------------------------------\n", font));
                        paragraph.Add(new Chunk("=================================\n", font));
                        paragraph.Add(new Chunk("", font));
                        paragraph.Add(new Chunk("", font));
                    }

                    paragraph.Add(new Chunk($"Firma Propietario: ___________________", font));
                    paragraph.Add(new Chunk("", font));
                    paragraph.Add(new Chunk("", font));
                    paragraph.Add(new Chunk($"Firma Inquilino:   ___________________", font));

                    // Agregar el párrafo al documento
                    doc.Add(paragraph);

                    // Cerrar el documento
                    doc.Close();

                    // Convertir el MemoryStream en un array de bytes
                    byte[] pdfBytes = memoryStream.ToArray();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Contrato generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Crear un archivo temporal para el PDF
                    string tempFilePath = Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, pdfBytes);

                    // Abrir el archivo PDF en el navegador web predeterminado
                    System.Diagnostics.Process.Start(tempFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el contrato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
