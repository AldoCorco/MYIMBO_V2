namespace WinFormApp.Forms.Business
{
    partial class FrmPropietario
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.dateTimePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.localidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBOLocalidadDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mYIMBO_LocalidadDataSet = new WinFormApp.MYIMBO_LocalidadDataSet();
            this.localidadTableAdapter = new WinFormApp.MYIMBO_LocalidadDataSetTableAdapters.LocalidadTableAdapter();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dataGridViewPropiedades = new System.Windows.Forms.DataGridView();
            this.dataGridViewPropietario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLegajoPropietario = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBOLocalidadDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBO_LocalidadDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropietario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(549, 611);
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
            this.btnBorrar.Location = new System.Drawing.Point(401, 611);
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
            this.btnModificar.Location = new System.Drawing.Point(235, 611);
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
            this.btnGuardar.Location = new System.Drawing.Point(56, 611);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(198, 310);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 38;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(53, 313);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 37;
            this.lblNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(198, 357);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 22);
            this.txtApellido.TabIndex = 40;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(53, 360);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 16);
            this.lblApellido.TabIndex = 39;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(414, 280);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(30, 16);
            this.lblDNI.TabIndex = 43;
            this.lblDNI.Text = "DNI";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(412, 316);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(135, 16);
            this.lblFechaNacimiento.TabIndex = 45;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(553, 357);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtTelefono.TabIndex = 48;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(412, 363);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 16);
            this.lblTelefono.TabIndex = 47;
            this.lblTelefono.Text = "Telefono";
            // 
            // dateTimePickerFechaNac
            // 
            this.dateTimePickerFechaNac.Location = new System.Drawing.Point(553, 311);
            this.dateTimePickerFechaNac.Name = "dateTimePickerFechaNac";
            this.dateTimePickerFechaNac.Size = new System.Drawing.Size(263, 22);
            this.dateTimePickerFechaNac.TabIndex = 51;
            // 
            // localidadBindingSource
            // 
            this.localidadBindingSource.DataMember = "Localidad";
            this.localidadBindingSource.DataSource = this.mYIMBOLocalidadDataSetBindingSource;
            // 
            // mYIMBOLocalidadDataSetBindingSource
            // 
            this.mYIMBOLocalidadDataSetBindingSource.DataSource = this.mYIMBO_LocalidadDataSet;
            this.mYIMBOLocalidadDataSetBindingSource.Position = 0;
            // 
            // mYIMBO_LocalidadDataSet
            // 
            this.mYIMBO_LocalidadDataSet.DataSetName = "MYIMBO_LocalidadDataSet";
            this.mYIMBO_LocalidadDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // localidadTableAdapter
            // 
            this.localidadTableAdapter.ClearBeforeFill = true;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(553, 273);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(132, 22);
            this.txtDNI.TabIndex = 52;
            // 
            // dataGridViewPropiedades
            // 
            this.dataGridViewPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropiedades.Location = new System.Drawing.Point(56, 12);
            this.dataGridViewPropiedades.Name = "dataGridViewPropiedades";
            this.dataGridViewPropiedades.RowHeadersWidth = 51;
            this.dataGridViewPropiedades.RowTemplate.Height = 24;
            this.dataGridViewPropiedades.Size = new System.Drawing.Size(821, 150);
            this.dataGridViewPropiedades.TabIndex = 53;
            this.dataGridViewPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            this.dataGridViewPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            // 
            // dataGridViewPropietario
            // 
            this.dataGridViewPropietario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropietario.Location = new System.Drawing.Point(56, 408);
            this.dataGridViewPropietario.Name = "dataGridViewPropietario";
            this.dataGridViewPropietario.RowHeadersWidth = 51;
            this.dataGridViewPropietario.RowTemplate.Height = 24;
            this.dataGridViewPropietario.Size = new System.Drawing.Size(821, 150);
            this.dataGridViewPropietario.TabIndex = 54;
            this.dataGridViewPropietario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropietario_CellContentClick);
            this.dataGridViewPropietario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropietario_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Legajo Propietario";
            // 
            // txtLegajoPropietario
            // 
            this.txtLegajoPropietario.Location = new System.Drawing.Point(200, 273);
            this.txtLegajoPropietario.Name = "txtLegajoPropietario";
            this.txtLegajoPropietario.Size = new System.Drawing.Size(100, 22);
            this.txtLegajoPropietario.TabIndex = 56;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(198, 209);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 22);
            this.txtDescripcion.TabIndex = 58;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(53, 215);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 57;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(557, 209);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(171, 22);
            this.txtDireccion.TabIndex = 60;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(412, 212);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(64, 16);
            this.lblDireccion.TabIndex = 59;
            this.lblDireccion.Text = "Dirección";
            // 
            // FrmPropietario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 661);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtLegajoPropietario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPropietario);
            this.Controls.Add(this.dataGridViewPropiedades);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.dateTimePickerFechaNac);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmPropietario";
            this.Text = "Propietario";
            this.Load += new System.EventHandler(this.FrmPropietario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBOLocalidadDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYIMBO_LocalidadDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropietario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNac;
        private System.Windows.Forms.BindingSource mYIMBOLocalidadDataSetBindingSource;
        private MYIMBO_LocalidadDataSet mYIMBO_LocalidadDataSet;
        private System.Windows.Forms.BindingSource localidadBindingSource;
        private MYIMBO_LocalidadDataSetTableAdapters.LocalidadTableAdapter localidadTableAdapter;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DataGridView dataGridViewPropiedades;
        private System.Windows.Forms.DataGridView dataGridViewPropietario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLegajoPropietario;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
    }
}