namespace WinFormApp.Forms.Business
{
    partial class FrmCompra
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
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblSeleccionarPropiedad = new System.Windows.Forms.Label();
            this.blbDNI = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.lblCertificadodomicilio = new System.Windows.Forms.Label();
            this.dataGridViewPropiedades = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLegajoComprador = new System.Windows.Forms.TextBox();
            this.lblLegajoComprador = new System.Windows.Forms.Label();
            this.dateTimePickerFechaNacComprador = new System.Windows.Forms.DateTimePicker();
            this.txtTelefonoComprador = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtDNIComprador = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtApellidoComprador = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombreComprador = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDNIVendedor = new System.Windows.Forms.TextBox();
            this.lblDNI2 = new System.Windows.Forms.Label();
            this.txtApellidoVendedor = new System.Windows.Forms.TextBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.txtNombreVendedor = new System.Windows.Forms.TextBox();
            this.lblNombre2 = new System.Windows.Forms.Label();
            this.lblTotalDineroPropiedad = new System.Windows.Forms.Label();
            this.lblTotalDineroImpuesto = new System.Windows.Forms.Label();
            this.lblTotalDineroComision = new System.Windows.Forms.Label();
            this.lblValorDineroPropiedad = new System.Windows.Forms.Label();
            this.ComboBoxTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.lblTipoPropiedad = new System.Windows.Forms.Label();
            this.lblTotalPropiedad = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblTotalComision = new System.Windows.Forms.Label();
            this.lblValorPropiedad = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.dataGridViewCompraPropiedades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBoletoCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompraPropiedades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(424, 564);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(100, 45);
            this.btnLimpiarCampos.TabIndex = 30;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(289, 564);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 45);
            this.btnBorrar.TabIndex = 29;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(165, 564);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 45);
            this.btnModificar.TabIndex = 28;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(37, 564);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblSeleccionarPropiedad
            // 
            this.lblSeleccionarPropiedad.AutoSize = true;
            this.lblSeleccionarPropiedad.Location = new System.Drawing.Point(34, 93);
            this.lblSeleccionarPropiedad.Name = "lblSeleccionarPropiedad";
            this.lblSeleccionarPropiedad.Size = new System.Drawing.Size(146, 16);
            this.lblSeleccionarPropiedad.TabIndex = 31;
            this.lblSeleccionarPropiedad.Text = "Seleccionar Propiedad";
            // 
            // blbDNI
            // 
            this.blbDNI.AutoSize = true;
            this.blbDNI.Location = new System.Drawing.Point(35, 28);
            this.blbDNI.Name = "blbDNI";
            this.blbDNI.Size = new System.Drawing.Size(30, 16);
            this.blbDNI.TabIndex = 32;
            this.blbDNI.Text = "DNI";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(188, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(187, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 35;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // lblCertificadodomicilio
            // 
            this.lblCertificadodomicilio.AutoSize = true;
            this.lblCertificadodomicilio.Location = new System.Drawing.Point(34, 53);
            this.lblCertificadodomicilio.Name = "lblCertificadodomicilio";
            this.lblCertificadodomicilio.Size = new System.Drawing.Size(147, 16);
            this.lblCertificadodomicilio.TabIndex = 34;
            this.lblCertificadodomicilio.Text = "Certificado de domicilio";
            // 
            // dataGridViewPropiedades
            // 
            this.dataGridViewPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropiedades.Location = new System.Drawing.Point(37, 123);
            this.dataGridViewPropiedades.Name = "dataGridViewPropiedades";
            this.dataGridViewPropiedades.RowHeadersWidth = 51;
            this.dataGridViewPropiedades.RowTemplate.Height = 24;
            this.dataGridViewPropiedades.Size = new System.Drawing.Size(546, 150);
            this.dataGridViewPropiedades.TabIndex = 61;
            this.dataGridViewPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            this.dataGridViewPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLegajoComprador);
            this.groupBox1.Controls.Add(this.lblLegajoComprador);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaNacComprador);
            this.groupBox1.Controls.Add(this.txtTelefonoComprador);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.lblFechaNacimiento);
            this.groupBox1.Controls.Add(this.txtDNIComprador);
            this.groupBox1.Controls.Add(this.lblDNI);
            this.groupBox1.Controls.Add(this.txtApellidoComprador);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtNombreComprador);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(37, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 207);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comprador";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtLegajoComprador
            // 
            this.txtLegajoComprador.Location = new System.Drawing.Point(142, 46);
            this.txtLegajoComprador.Name = "txtLegajoComprador";
            this.txtLegajoComprador.Size = new System.Drawing.Size(100, 22);
            this.txtLegajoComprador.TabIndex = 69;
            // 
            // lblLegajoComprador
            // 
            this.lblLegajoComprador.AutoSize = true;
            this.lblLegajoComprador.Location = new System.Drawing.Point(7, 53);
            this.lblLegajoComprador.Name = "lblLegajoComprador";
            this.lblLegajoComprador.Size = new System.Drawing.Size(120, 16);
            this.lblLegajoComprador.TabIndex = 68;
            this.lblLegajoComprador.Text = "Legajo Comprador";
            // 
            // dateTimePickerFechaNacComprador
            // 
            this.dateTimePickerFechaNacComprador.Location = new System.Drawing.Point(434, 83);
            this.dateTimePickerFechaNacComprador.Name = "dateTimePickerFechaNacComprador";
            this.dateTimePickerFechaNacComprador.Size = new System.Drawing.Size(269, 22);
            this.dateTimePickerFechaNacComprador.TabIndex = 67;
            // 
            // txtTelefonoComprador
            // 
            this.txtTelefonoComprador.Location = new System.Drawing.Point(434, 119);
            this.txtTelefonoComprador.Name = "txtTelefonoComprador";
            this.txtTelefonoComprador.Size = new System.Drawing.Size(100, 22);
            this.txtTelefonoComprador.TabIndex = 64;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(282, 125);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 16);
            this.lblTelefono.TabIndex = 63;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(282, 89);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(135, 16);
            this.lblFechaNacimiento.TabIndex = 62;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // txtDNIComprador
            // 
            this.txtDNIComprador.Location = new System.Drawing.Point(434, 45);
            this.txtDNIComprador.Name = "txtDNIComprador";
            this.txtDNIComprador.Size = new System.Drawing.Size(100, 22);
            this.txtDNIComprador.TabIndex = 61;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(282, 52);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(30, 16);
            this.lblDNI.TabIndex = 60;
            this.lblDNI.Text = "DNI";
            // 
            // txtApellidoComprador
            // 
            this.txtApellidoComprador.Location = new System.Drawing.Point(141, 116);
            this.txtApellidoComprador.Name = "txtApellidoComprador";
            this.txtApellidoComprador.Size = new System.Drawing.Size(100, 22);
            this.txtApellidoComprador.TabIndex = 59;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 123);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 16);
            this.lblApellido.TabIndex = 58;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombreComprador
            // 
            this.txtNombreComprador.Location = new System.Drawing.Point(141, 80);
            this.txtNombreComprador.Name = "txtNombreComprador";
            this.txtNombreComprador.Size = new System.Drawing.Size(100, 22);
            this.txtNombreComprador.TabIndex = 57;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 87);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 56;
            this.lblNombre.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDNIVendedor);
            this.groupBox2.Controls.Add(this.lblDNI2);
            this.groupBox2.Controls.Add(this.txtApellidoVendedor);
            this.groupBox2.Controls.Add(this.lblApellido2);
            this.groupBox2.Controls.Add(this.txtNombreVendedor);
            this.groupBox2.Controls.Add(this.lblNombre2);
            this.groupBox2.Location = new System.Drawing.Point(617, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 150);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendedor";
            // 
            // txtDNIVendedor
            // 
            this.txtDNIVendedor.Location = new System.Drawing.Point(158, 100);
            this.txtDNIVendedor.Name = "txtDNIVendedor";
            this.txtDNIVendedor.Size = new System.Drawing.Size(167, 22);
            this.txtDNIVendedor.TabIndex = 67;
            // 
            // lblDNI2
            // 
            this.lblDNI2.AutoSize = true;
            this.lblDNI2.Location = new System.Drawing.Point(23, 107);
            this.lblDNI2.Name = "lblDNI2";
            this.lblDNI2.Size = new System.Drawing.Size(30, 16);
            this.lblDNI2.TabIndex = 66;
            this.lblDNI2.Text = "DNI";
            // 
            // txtApellidoVendedor
            // 
            this.txtApellidoVendedor.Location = new System.Drawing.Point(158, 63);
            this.txtApellidoVendedor.Name = "txtApellidoVendedor";
            this.txtApellidoVendedor.Size = new System.Drawing.Size(167, 22);
            this.txtApellidoVendedor.TabIndex = 65;
            // 
            // lblApellido2
            // 
            this.lblApellido2.AutoSize = true;
            this.lblApellido2.Location = new System.Drawing.Point(23, 70);
            this.lblApellido2.Name = "lblApellido2";
            this.lblApellido2.Size = new System.Drawing.Size(57, 16);
            this.lblApellido2.TabIndex = 64;
            this.lblApellido2.Text = "Apellido";
            // 
            // txtNombreVendedor
            // 
            this.txtNombreVendedor.Location = new System.Drawing.Point(158, 27);
            this.txtNombreVendedor.Name = "txtNombreVendedor";
            this.txtNombreVendedor.Size = new System.Drawing.Size(167, 22);
            this.txtNombreVendedor.TabIndex = 63;
            // 
            // lblNombre2
            // 
            this.lblNombre2.AutoSize = true;
            this.lblNombre2.Location = new System.Drawing.Point(23, 34);
            this.lblNombre2.Name = "lblNombre2";
            this.lblNombre2.Size = new System.Drawing.Size(56, 16);
            this.lblNombre2.TabIndex = 62;
            this.lblNombre2.Text = "Nombre";
            // 
            // lblTotalDineroPropiedad
            // 
            this.lblTotalDineroPropiedad.AutoSize = true;
            this.lblTotalDineroPropiedad.Location = new System.Drawing.Point(922, 514);
            this.lblTotalDineroPropiedad.Name = "lblTotalDineroPropiedad";
            this.lblTotalDineroPropiedad.Size = new System.Drawing.Size(10, 16);
            this.lblTotalDineroPropiedad.TabIndex = 77;
            this.lblTotalDineroPropiedad.Text = ":";
            // 
            // lblTotalDineroImpuesto
            // 
            this.lblTotalDineroImpuesto.AutoSize = true;
            this.lblTotalDineroImpuesto.Location = new System.Drawing.Point(922, 474);
            this.lblTotalDineroImpuesto.Name = "lblTotalDineroImpuesto";
            this.lblTotalDineroImpuesto.Size = new System.Drawing.Size(10, 16);
            this.lblTotalDineroImpuesto.TabIndex = 76;
            this.lblTotalDineroImpuesto.Text = ":";
            // 
            // lblTotalDineroComision
            // 
            this.lblTotalDineroComision.AutoSize = true;
            this.lblTotalDineroComision.Location = new System.Drawing.Point(922, 433);
            this.lblTotalDineroComision.Name = "lblTotalDineroComision";
            this.lblTotalDineroComision.Size = new System.Drawing.Size(10, 16);
            this.lblTotalDineroComision.TabIndex = 75;
            this.lblTotalDineroComision.Text = ":";
            // 
            // lblValorDineroPropiedad
            // 
            this.lblValorDineroPropiedad.AutoSize = true;
            this.lblValorDineroPropiedad.Location = new System.Drawing.Point(922, 392);
            this.lblValorDineroPropiedad.Name = "lblValorDineroPropiedad";
            this.lblValorDineroPropiedad.Size = new System.Drawing.Size(14, 16);
            this.lblValorDineroPropiedad.TabIndex = 74;
            this.lblValorDineroPropiedad.Text = "$";
            // 
            // ComboBoxTipoPropiedad
            // 
            this.ComboBoxTipoPropiedad.FormattingEnabled = true;
            this.ComboBoxTipoPropiedad.Items.AddRange(new object[] {
            "Casa",
            "Departamento",
            "Terreno",
            "Local"});
            this.ComboBoxTipoPropiedad.Location = new System.Drawing.Point(938, 327);
            this.ComboBoxTipoPropiedad.Name = "ComboBoxTipoPropiedad";
            this.ComboBoxTipoPropiedad.Size = new System.Drawing.Size(184, 24);
            this.ComboBoxTipoPropiedad.TabIndex = 73;
            this.ComboBoxTipoPropiedad.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            this.ComboBoxTipoPropiedad.SelectedValueChanged += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            // 
            // lblTipoPropiedad
            // 
            this.lblTipoPropiedad.AutoSize = true;
            this.lblTipoPropiedad.Location = new System.Drawing.Point(789, 336);
            this.lblTipoPropiedad.Name = "lblTipoPropiedad";
            this.lblTipoPropiedad.Size = new System.Drawing.Size(121, 16);
            this.lblTipoPropiedad.TabIndex = 72;
            this.lblTipoPropiedad.Text = "Tipo de Propiedad";
            // 
            // lblTotalPropiedad
            // 
            this.lblTotalPropiedad.AutoSize = true;
            this.lblTotalPropiedad.Location = new System.Drawing.Point(789, 514);
            this.lblTotalPropiedad.Name = "lblTotalPropiedad";
            this.lblTotalPropiedad.Size = new System.Drawing.Size(105, 16);
            this.lblTotalPropiedad.TabIndex = 71;
            this.lblTotalPropiedad.Text = "Total Propiedad";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Location = new System.Drawing.Point(789, 474);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(96, 16);
            this.lblImpuesto.TabIndex = 70;
            this.lblImpuesto.Text = "Total Impuesto";
            // 
            // lblTotalComision
            // 
            this.lblTotalComision.AutoSize = true;
            this.lblTotalComision.Location = new System.Drawing.Point(789, 433);
            this.lblTotalComision.Name = "lblTotalComision";
            this.lblTotalComision.Size = new System.Drawing.Size(97, 16);
            this.lblTotalComision.TabIndex = 69;
            this.lblTotalComision.Text = "Total Comisión";
            // 
            // lblValorPropiedad
            // 
            this.lblValorPropiedad.AutoSize = true;
            this.lblValorPropiedad.Location = new System.Drawing.Point(789, 392);
            this.lblValorPropiedad.Name = "lblValorPropiedad";
            this.lblValorPropiedad.Size = new System.Drawing.Size(106, 16);
            this.lblValorPropiedad.TabIndex = 68;
            this.lblValorPropiedad.Text = "Valor Propiedad";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(178, 291);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(171, 22);
            this.txtPrecioVenta.TabIndex = 79;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(35, 294);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(103, 16);
            this.lblPrecioVenta.TabIndex = 78;
            this.lblPrecioVenta.Text = "Precio de Venta";
            // 
            // dataGridViewCompraPropiedades
            // 
            this.dataGridViewCompraPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompraPropiedades.Location = new System.Drawing.Point(38, 665);
            this.dataGridViewCompraPropiedades.Name = "dataGridViewCompraPropiedades";
            this.dataGridViewCompraPropiedades.RowHeadersWidth = 51;
            this.dataGridViewCompraPropiedades.RowTemplate.Height = 24;
            this.dataGridViewCompraPropiedades.Size = new System.Drawing.Size(533, 150);
            this.dataGridViewCompraPropiedades.TabIndex = 80;
            this.dataGridViewCompraPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompraPropiedades_CellContentClick);
            this.dataGridViewCompraPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompraPropiedades_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Listado Compradores";
            // 
            // btnBoletoCompra
            // 
            this.btnBoletoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoletoCompra.Location = new System.Drawing.Point(667, 665);
            this.btnBoletoCompra.Name = "btnBoletoCompra";
            this.btnBoletoCompra.Size = new System.Drawing.Size(100, 45);
            this.btnBoletoCompra.TabIndex = 82;
            this.btnBoletoCompra.Text = "Boleto de Compra";
            this.btnBoletoCompra.UseVisualStyleBackColor = true;
            this.btnBoletoCompra.Click += new System.EventHandler(this.btnBoletoCompra_Click);
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(150, 100);
            this.ClientSize = new System.Drawing.Size(1205, 888);
            this.Controls.Add(this.btnBoletoCompra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCompraPropiedades);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblTotalDineroPropiedad);
            this.Controls.Add(this.lblTotalDineroImpuesto);
            this.Controls.Add(this.lblTotalDineroComision);
            this.Controls.Add(this.lblValorDineroPropiedad);
            this.Controls.Add(this.ComboBoxTipoPropiedad);
            this.Controls.Add(this.lblTipoPropiedad);
            this.Controls.Add(this.lblTotalPropiedad);
            this.Controls.Add(this.lblImpuesto);
            this.Controls.Add(this.lblTotalComision);
            this.Controls.Add(this.lblValorPropiedad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewPropiedades);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.lblCertificadodomicilio);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.blbDNI);
            this.Controls.Add(this.lblSeleccionarPropiedad);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmCompra";
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompraPropiedades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblSeleccionarPropiedad;
        private System.Windows.Forms.Label blbDNI;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label lblCertificadodomicilio;
        private System.Windows.Forms.DataGridView dataGridViewPropiedades;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacComprador;
        private System.Windows.Forms.TextBox txtTelefonoComprador;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.TextBox txtDNIComprador;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtApellidoComprador;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombreComprador;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDNIVendedor;
        private System.Windows.Forms.Label lblDNI2;
        private System.Windows.Forms.TextBox txtApellidoVendedor;
        private System.Windows.Forms.Label lblApellido2;
        private System.Windows.Forms.TextBox txtNombreVendedor;
        private System.Windows.Forms.Label lblNombre2;
        private System.Windows.Forms.TextBox txtLegajoComprador;
        private System.Windows.Forms.Label lblLegajoComprador;
        private System.Windows.Forms.Label lblTotalDineroPropiedad;
        private System.Windows.Forms.Label lblTotalDineroImpuesto;
        private System.Windows.Forms.Label lblTotalDineroComision;
        private System.Windows.Forms.Label lblValorDineroPropiedad;
        private System.Windows.Forms.ComboBox ComboBoxTipoPropiedad;
        private System.Windows.Forms.Label lblTipoPropiedad;
        private System.Windows.Forms.Label lblTotalPropiedad;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblTotalComision;
        private System.Windows.Forms.Label lblValorPropiedad;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.DataGridView dataGridViewCompraPropiedades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBoletoCompra;
    }
}