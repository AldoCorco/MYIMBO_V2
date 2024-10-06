namespace WinFormApp.Forms.Business
{
    partial class FrmPropiedades
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
            this.components = new System.ComponentModel.Container();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblPartido = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblPrecioAlquiler = new System.Windows.Forms.Label();
            this.lblTasarPropiedad = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridViewPropiedades = new System.Windows.Forms.DataGridView();
            this.ComboBoxTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.lblTipoPropiedad = new System.Windows.Forms.Label();
            this.comboBoxProvincia = new System.Windows.Forms.ComboBox();
            this.provinciaSelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBODataSet4 = new WinFormApp.MYIMBODataSet4();
            this.provinciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBODataSet = new WinFormApp.MYIMBODataSet();
            this.comboBoxPartido = new System.Windows.Forms.ComboBox();
            this.partidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBODataSet2 = new WinFormApp.MYIMBODataSet2();
            this.comboBoxLocalidad = new System.Windows.Forms.ComboBox();
            this.localidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBODataSet3 = new WinFormApp.MYIMBODataSet3();
            this.provinciaTableAdapter = new WinFormApp.MYIMBODataSetTableAdapters.ProvinciaTableAdapter();
            this.mYIMBODataSet1 = new WinFormApp.MYIMBODataSet1();
            this.provinciaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.provinciaTableAdapter1 = new WinFormApp.MYIMBODataSet1TableAdapters.ProvinciaTableAdapter();
            this.partidoTableAdapter = new WinFormApp.MYIMBODataSet2TableAdapters.PartidoTableAdapter();
            this.localidadTableAdapter = new WinFormApp.MYIMBODataSet3TableAdapters.LocalidadTableAdapter();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioAlquiler = new System.Windows.Forms.TextBox();
            this.provinciaSelectAllTableAdapter = new WinFormApp.MYIMBODataSet4TableAdapters.ProvinciaSelectAllTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaSelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(417, 378);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(100, 45);
            this.btnLimpiarCampos.TabIndex = 34;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(298, 378);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 45);
            this.btnBorrar.TabIndex = 33;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(168, 378);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 45);
            this.btnModificar.TabIndex = 32;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(43, 378);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(157, 64);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(171, 22);
            this.txtDireccion.TabIndex = 38;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(12, 67);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(64, 16);
            this.lblDireccion.TabIndex = 37;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(157, 106);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 22);
            this.txtDescripcion.TabIndex = 40;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 112);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 39;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(388, 25);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(63, 16);
            this.lblProvincia.TabIndex = 41;
            this.lblProvincia.Text = "Provincia";
            // 
            // lblPartido
            // 
            this.lblPartido.AutoSize = true;
            this.lblPartido.Location = new System.Drawing.Point(388, 67);
            this.lblPartido.Name = "lblPartido";
            this.lblPartido.Size = new System.Drawing.Size(50, 16);
            this.lblPartido.TabIndex = 42;
            this.lblPartido.Text = "Partido";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(384, 112);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(67, 16);
            this.lblLocalidad.TabIndex = 43;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(34, 89);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(103, 16);
            this.lblPrecioVenta.TabIndex = 44;
            this.lblPrecioVenta.Text = "Precio de Venta";
            // 
            // lblPrecioAlquiler
            // 
            this.lblPrecioAlquiler.AutoSize = true;
            this.lblPrecioAlquiler.Location = new System.Drawing.Point(34, 133);
            this.lblPrecioAlquiler.Name = "lblPrecioAlquiler";
            this.lblPrecioAlquiler.Size = new System.Drawing.Size(113, 16);
            this.lblPrecioAlquiler.TabIndex = 45;
            this.lblPrecioAlquiler.Text = "Precio de Alquiler";
            // 
            // lblTasarPropiedad
            // 
            this.lblTasarPropiedad.AutoSize = true;
            this.lblTasarPropiedad.Location = new System.Drawing.Point(34, 50);
            this.lblTasarPropiedad.Name = "lblTasarPropiedad";
            this.lblTasarPropiedad.Size = new System.Drawing.Size(110, 16);
            this.lblTasarPropiedad.TabIndex = 46;
            this.lblTasarPropiedad.Text = "Tasar Propiedad";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(179, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPropiedades
            // 
            this.dataGridViewPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropiedades.Location = new System.Drawing.Point(12, 175);
            this.dataGridViewPropiedades.Name = "dataGridViewPropiedades";
            this.dataGridViewPropiedades.RowHeadersWidth = 51;
            this.dataGridViewPropiedades.RowTemplate.Height = 24;
            this.dataGridViewPropiedades.Size = new System.Drawing.Size(546, 150);
            this.dataGridViewPropiedades.TabIndex = 48;
            this.dataGridViewPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            this.dataGridViewPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            // 
            // ComboBoxTipoPropiedad
            // 
            this.ComboBoxTipoPropiedad.FormattingEnabled = true;
            this.ComboBoxTipoPropiedad.Items.AddRange(new object[] {
            "Casa",
            "Departamento",
            "Terreno",
            "Local"});
            this.ComboBoxTipoPropiedad.Location = new System.Drawing.Point(157, 17);
            this.ComboBoxTipoPropiedad.Name = "ComboBoxTipoPropiedad";
            this.ComboBoxTipoPropiedad.Size = new System.Drawing.Size(171, 24);
            this.ComboBoxTipoPropiedad.TabIndex = 54;
            // 
            // lblTipoPropiedad
            // 
            this.lblTipoPropiedad.AutoSize = true;
            this.lblTipoPropiedad.Location = new System.Drawing.Point(12, 25);
            this.lblTipoPropiedad.Name = "lblTipoPropiedad";
            this.lblTipoPropiedad.Size = new System.Drawing.Size(121, 16);
            this.lblTipoPropiedad.TabIndex = 53;
            this.lblTipoPropiedad.Text = "Tipo de Propiedad";
            // 
            // comboBoxProvincia
            // 
            this.comboBoxProvincia.DataSource = this.provinciaSelectAllBindingSource;
            this.comboBoxProvincia.DisplayMember = "nom_provincia";
            this.comboBoxProvincia.FormattingEnabled = true;
            this.comboBoxProvincia.Location = new System.Drawing.Point(489, 17);
            this.comboBoxProvincia.Name = "comboBoxProvincia";
            this.comboBoxProvincia.Size = new System.Drawing.Size(167, 24);
            this.comboBoxProvincia.TabIndex = 55;
            this.comboBoxProvincia.ValueMember = "idprovincia";
            this.comboBoxProvincia.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvincia_SelectedIndexChanged);
            // 
            // provinciaSelectAllBindingSource
            // 
            this.provinciaSelectAllBindingSource.DataMember = "ProvinciaSelectAll";
            this.provinciaSelectAllBindingSource.DataSource = this.mYIMBODataSet4;
            // 
            // mYIMBODataSet4
            // 
            this.mYIMBODataSet4.DataSetName = "MYIMBODataSet4";
            this.mYIMBODataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // provinciaBindingSource
            // 
            this.provinciaBindingSource.DataMember = "Provincia";
            this.provinciaBindingSource.DataSource = this.mYIMBODataSet;
            // 
            // mYIMBODataSet
            // 
            this.mYIMBODataSet.DataSetName = "MYIMBODataSet";
            this.mYIMBODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxPartido
            // 
            this.comboBoxPartido.DataSource = this.partidoBindingSource;
            this.comboBoxPartido.DisplayMember = "nom_partido";
            this.comboBoxPartido.FormattingEnabled = true;
            this.comboBoxPartido.Location = new System.Drawing.Point(489, 59);
            this.comboBoxPartido.Name = "comboBoxPartido";
            this.comboBoxPartido.Size = new System.Drawing.Size(167, 24);
            this.comboBoxPartido.TabIndex = 56;
            this.comboBoxPartido.ValueMember = "idpartido";
            this.comboBoxPartido.SelectedIndexChanged += new System.EventHandler(this.comboBoxPartido_SelectedIndexChanged);
            // 
            // partidoBindingSource
            // 
            this.partidoBindingSource.DataMember = "Partido";
            this.partidoBindingSource.DataSource = this.mYIMBODataSet2;
            // 
            // mYIMBODataSet2
            // 
            this.mYIMBODataSet2.DataSetName = "MYIMBODataSet2";
            this.mYIMBODataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxLocalidad
            // 
            this.comboBoxLocalidad.DataSource = this.localidadBindingSource;
            this.comboBoxLocalidad.DisplayMember = "nom_localidad";
            this.comboBoxLocalidad.FormattingEnabled = true;
            this.comboBoxLocalidad.Location = new System.Drawing.Point(489, 109);
            this.comboBoxLocalidad.Name = "comboBoxLocalidad";
            this.comboBoxLocalidad.Size = new System.Drawing.Size(167, 24);
            this.comboBoxLocalidad.TabIndex = 57;
            this.comboBoxLocalidad.ValueMember = "idlocalidad";
            this.comboBoxLocalidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocalidad_SelectedIndexChanged);
            // 
            // localidadBindingSource
            // 
            this.localidadBindingSource.DataMember = "Localidad";
            this.localidadBindingSource.DataSource = this.mYIMBODataSet3;
            // 
            // mYIMBODataSet3
            // 
            this.mYIMBODataSet3.DataSetName = "MYIMBODataSet3";
            this.mYIMBODataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // provinciaTableAdapter
            // 
            this.provinciaTableAdapter.ClearBeforeFill = true;
            // 
            // mYIMBODataSet1
            // 
            this.mYIMBODataSet1.DataSetName = "MYIMBODataSet1";
            this.mYIMBODataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // provinciaBindingSource1
            // 
            this.provinciaBindingSource1.DataMember = "Provincia";
            this.provinciaBindingSource1.DataSource = this.mYIMBODataSet1;
            // 
            // provinciaTableAdapter1
            // 
            this.provinciaTableAdapter1.ClearBeforeFill = true;
            // 
            // partidoTableAdapter
            // 
            this.partidoTableAdapter.ClearBeforeFill = true;
            // 
            // localidadTableAdapter
            // 
            this.localidadTableAdapter.ClearBeforeFill = true;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(179, 86);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(117, 22);
            this.txtPrecioVenta.TabIndex = 58;
            // 
            // txtPrecioAlquiler
            // 
            this.txtPrecioAlquiler.Location = new System.Drawing.Point(179, 130);
            this.txtPrecioAlquiler.Name = "txtPrecioAlquiler";
            this.txtPrecioAlquiler.Size = new System.Drawing.Size(117, 22);
            this.txtPrecioAlquiler.TabIndex = 59;
            // 
            // provinciaSelectAllTableAdapter
            // 
            this.provinciaSelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.lblTasarPropiedad);
            this.groupBox1.Controls.Add(this.txtPrecioAlquiler);
            this.groupBox1.Controls.Add(this.lblPrecioVenta);
            this.groupBox1.Controls.Add(this.txtPrecioVenta);
            this.groupBox1.Controls.Add(this.lblPrecioAlquiler);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(604, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 250);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tasación";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(260, 184);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 23);
            this.btnEliminar.TabIndex = 62;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(136, 184);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(97, 23);
            this.btnActualizar.TabIndex = 61;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(18, 184);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 23);
            this.btnAgregar.TabIndex = 60;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxLocalidad);
            this.Controls.Add(this.comboBoxPartido);
            this.Controls.Add(this.comboBoxProvincia);
            this.Controls.Add(this.ComboBoxTipoPropiedad);
            this.Controls.Add(this.lblTipoPropiedad);
            this.Controls.Add(this.dataGridViewPropiedades);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblPartido);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmPropiedades";
            this.Text = "Propiedades";
            this.Load += new System.EventHandler(this.FrmPropiedades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaSelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBODataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Label lblPartido;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblPrecioAlquiler;
        private System.Windows.Forms.Label lblTasarPropiedad;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridViewPropiedades;
        private System.Windows.Forms.ComboBox ComboBoxTipoPropiedad;
        private System.Windows.Forms.Label lblTipoPropiedad;
        private System.Windows.Forms.ComboBox comboBoxProvincia;
        private System.Windows.Forms.ComboBox comboBoxPartido;
        private System.Windows.Forms.ComboBox comboBoxLocalidad;
        private MYIMBODataSet mYIMBODataSet;
        private System.Windows.Forms.BindingSource provinciaBindingSource;
        private MYIMBODataSetTableAdapters.ProvinciaTableAdapter provinciaTableAdapter;
        private MYIMBODataSet1 mYIMBODataSet1;
        private System.Windows.Forms.BindingSource provinciaBindingSource1;
        private MYIMBODataSet1TableAdapters.ProvinciaTableAdapter provinciaTableAdapter1;
        private MYIMBODataSet2 mYIMBODataSet2;
        private System.Windows.Forms.BindingSource partidoBindingSource;
        private MYIMBODataSet2TableAdapters.PartidoTableAdapter partidoTableAdapter;
        private MYIMBODataSet3 mYIMBODataSet3;
        private System.Windows.Forms.BindingSource localidadBindingSource;
        private MYIMBODataSet3TableAdapters.LocalidadTableAdapter localidadTableAdapter;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioAlquiler;
        private MYIMBODataSet4 mYIMBODataSet4;
        private System.Windows.Forms.BindingSource provinciaSelectAllBindingSource;
        private MYIMBODataSet4TableAdapters.ProvinciaSelectAllTableAdapter provinciaSelectAllTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
    }
}