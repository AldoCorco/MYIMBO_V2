namespace WinFormApp.Forms.Business
{
    partial class FrmAlquiler
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
            this.lblSeleccionarPropiedad = new System.Windows.Forms.Label();
            this.lblIngresarReserva = new System.Windows.Forms.Label();
            this.lblSeleccionarEscribania = new System.Windows.Forms.Label();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblPresentarGarantia = new System.Windows.Forms.Label();
            this.lblPresentarReciboSueldo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dataGridViewPropiedades = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrecioAlquiler = new System.Windows.Forms.Label();
            this.lblNombreEscribania = new System.Windows.Forms.Label();
            this.txtNombreEscribania = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTipoPropiedad = new System.Windows.Forms.Label();
            this.ComboBoxTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPrecio_Alquiler = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalBoleto = new System.Windows.Forms.Label();
            this.lblTotalImpuesto = new System.Windows.Forms.Label();
            this.lblTotalDineroPropiedad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.btnContrato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSeleccionarPropiedad
            // 
            this.lblSeleccionarPropiedad.AutoSize = true;
            this.lblSeleccionarPropiedad.Location = new System.Drawing.Point(70, 121);
            this.lblSeleccionarPropiedad.Name = "lblSeleccionarPropiedad";
            this.lblSeleccionarPropiedad.Size = new System.Drawing.Size(146, 16);
            this.lblSeleccionarPropiedad.TabIndex = 0;
            this.lblSeleccionarPropiedad.Text = "Seleccionar Propiedad";
            // 
            // lblIngresarReserva
            // 
            this.lblIngresarReserva.AutoSize = true;
            this.lblIngresarReserva.Location = new System.Drawing.Point(70, 407);
            this.lblIngresarReserva.Name = "lblIngresarReserva";
            this.lblIngresarReserva.Size = new System.Drawing.Size(111, 16);
            this.lblIngresarReserva.TabIndex = 1;
            this.lblIngresarReserva.Text = "Ingresar Reserva";
            // 
            // lblSeleccionarEscribania
            // 
            this.lblSeleccionarEscribania.AutoSize = true;
            this.lblSeleccionarEscribania.Location = new System.Drawing.Point(622, 121);
            this.lblSeleccionarEscribania.Name = "lblSeleccionarEscribania";
            this.lblSeleccionarEscribania.Size = new System.Drawing.Size(146, 16);
            this.lblSeleccionarEscribania.TabIndex = 2;
            this.lblSeleccionarEscribania.Text = "Seleccionar Escribania";
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(247, 514);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(100, 45);
            this.btnLimpiarCampos.TabIndex = 26;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(73, 514);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 45);
            this.btnBorrar.TabIndex = 25;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(247, 445);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 45);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(73, 445);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblPresentarGarantia
            // 
            this.lblPresentarGarantia.AutoSize = true;
            this.lblPresentarGarantia.Location = new System.Drawing.Point(70, 13);
            this.lblPresentarGarantia.Name = "lblPresentarGarantia";
            this.lblPresentarGarantia.Size = new System.Drawing.Size(119, 16);
            this.lblPresentarGarantia.TabIndex = 27;
            this.lblPresentarGarantia.Text = "Presentar Garantia";
            // 
            // lblPresentarReciboSueldo
            // 
            this.lblPresentarReciboSueldo.AutoSize = true;
            this.lblPresentarReciboSueldo.Location = new System.Drawing.Point(70, 44);
            this.lblPresentarReciboSueldo.Name = "lblPresentarReciboSueldo";
            this.lblPresentarReciboSueldo.Size = new System.Drawing.Size(177, 16);
            this.lblPresentarReciboSueldo.TabIndex = 28;
            this.lblPresentarReciboSueldo.Text = "Presentar Recibo de Sueldo";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(260, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(260, 43);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPropiedades
            // 
            this.dataGridViewPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropiedades.Location = new System.Drawing.Point(70, 151);
            this.dataGridViewPropiedades.Name = "dataGridViewPropiedades";
            this.dataGridViewPropiedades.RowHeadersWidth = 51;
            this.dataGridViewPropiedades.RowTemplate.Height = 24;
            this.dataGridViewPropiedades.Size = new System.Drawing.Size(449, 150);
            this.dataGridViewPropiedades.TabIndex = 32;
            this.dataGridViewPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            this.dataGridViewPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(625, 151);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(430, 128);
            this.dataGridView2.TabIndex = 33;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // txtReserva
            // 
            this.txtReserva.Location = new System.Drawing.Point(194, 401);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(100, 22);
            this.txtReserva.TabIndex = 36;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(70, 329);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 40;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(194, 323);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(246, 22);
            this.txtDescripcion.TabIndex = 41;
            // 
            // lblPrecioAlquiler
            // 
            this.lblPrecioAlquiler.AutoSize = true;
            this.lblPrecioAlquiler.Location = new System.Drawing.Point(70, 367);
            this.lblPrecioAlquiler.Name = "lblPrecioAlquiler";
            this.lblPrecioAlquiler.Size = new System.Drawing.Size(94, 16);
            this.lblPrecioAlquiler.TabIndex = 42;
            this.lblPrecioAlquiler.Text = "Precio Alquiler";
            // 
            // lblNombreEscribania
            // 
            this.lblNombreEscribania.AutoSize = true;
            this.lblNombreEscribania.Location = new System.Drawing.Point(622, 308);
            this.lblNombreEscribania.Name = "lblNombreEscribania";
            this.lblNombreEscribania.Size = new System.Drawing.Size(123, 16);
            this.lblNombreEscribania.TabIndex = 44;
            this.lblNombreEscribania.Text = "Nombre Escribania";
            // 
            // txtNombreEscribania
            // 
            this.txtNombreEscribania.Location = new System.Drawing.Point(771, 302);
            this.txtNombreEscribania.Name = "txtNombreEscribania";
            this.txtNombreEscribania.Size = new System.Drawing.Size(184, 22);
            this.txtNombreEscribania.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Valor Propiedad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Total Boleto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Total Impuesto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "Total Propiedad";
            // 
            // lblTipoPropiedad
            // 
            this.lblTipoPropiedad.AutoSize = true;
            this.lblTipoPropiedad.Location = new System.Drawing.Point(622, 361);
            this.lblTipoPropiedad.Name = "lblTipoPropiedad";
            this.lblTipoPropiedad.Size = new System.Drawing.Size(121, 16);
            this.lblTipoPropiedad.TabIndex = 51;
            this.lblTipoPropiedad.Text = "Tipo de Propiedad";
            // 
            // ComboBoxTipoPropiedad
            // 
            this.ComboBoxTipoPropiedad.FormattingEnabled = true;
            this.ComboBoxTipoPropiedad.Items.AddRange(new object[] {
            "Casa",
            "Departamento",
            "Terreno",
            "Local"});
            this.ComboBoxTipoPropiedad.Location = new System.Drawing.Point(771, 352);
            this.ComboBoxTipoPropiedad.Name = "ComboBoxTipoPropiedad";
            this.ComboBoxTipoPropiedad.Size = new System.Drawing.Size(184, 24);
            this.ComboBoxTipoPropiedad.TabIndex = 52;
            this.ComboBoxTipoPropiedad.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            this.ComboBoxTipoPropiedad.SelectedValueChanged += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            // 
            // lblPrecio_Alquiler
            // 
            this.lblPrecio_Alquiler.AutoSize = true;
            this.lblPrecio_Alquiler.Location = new System.Drawing.Point(191, 361);
            this.lblPrecio_Alquiler.Name = "lblPrecio_Alquiler";
            this.lblPrecio_Alquiler.Size = new System.Drawing.Size(14, 16);
            this.lblPrecio_Alquiler.TabIndex = 53;
            this.lblPrecio_Alquiler.Text = "$";
            this.lblPrecio_Alquiler.Click += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "$";
            // 
            // lblTotalBoleto
            // 
            this.lblTotalBoleto.AutoSize = true;
            this.lblTotalBoleto.Location = new System.Drawing.Point(755, 458);
            this.lblTotalBoleto.Name = "lblTotalBoleto";
            this.lblTotalBoleto.Size = new System.Drawing.Size(10, 16);
            this.lblTotalBoleto.TabIndex = 55;
            this.lblTotalBoleto.Text = ":";
            // 
            // lblTotalImpuesto
            // 
            this.lblTotalImpuesto.AutoSize = true;
            this.lblTotalImpuesto.Location = new System.Drawing.Point(755, 499);
            this.lblTotalImpuesto.Name = "lblTotalImpuesto";
            this.lblTotalImpuesto.Size = new System.Drawing.Size(10, 16);
            this.lblTotalImpuesto.TabIndex = 56;
            this.lblTotalImpuesto.Text = ":";
            // 
            // lblTotalDineroPropiedad
            // 
            this.lblTotalDineroPropiedad.AutoSize = true;
            this.lblTotalDineroPropiedad.Location = new System.Drawing.Point(755, 539);
            this.lblTotalDineroPropiedad.Name = "lblTotalDineroPropiedad";
            this.lblTotalDineroPropiedad.Size = new System.Drawing.Size(10, 16);
            this.lblTotalDineroPropiedad.TabIndex = 57;
            this.lblTotalDineroPropiedad.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Edad";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(473, 13);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 22);
            this.txtEdad.TabIndex = 59;
            // 
            // btnContrato
            // 
            this.btnContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContrato.Location = new System.Drawing.Point(395, 390);
            this.btnContrato.Name = "btnContrato";
            this.btnContrato.Size = new System.Drawing.Size(124, 45);
            this.btnContrato.TabIndex = 60;
            this.btnContrato.Text = "Generar Contrato";
            this.btnContrato.UseVisualStyleBackColor = true;
            this.btnContrato.Click += new System.EventHandler(this.btnContrato_Click);
            // 
            // FrmAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 571);
            this.Controls.Add(this.btnContrato);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalDineroPropiedad);
            this.Controls.Add(this.lblTotalImpuesto);
            this.Controls.Add(this.lblTotalBoleto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPrecio_Alquiler);
            this.Controls.Add(this.ComboBoxTipoPropiedad);
            this.Controls.Add(this.lblTipoPropiedad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreEscribania);
            this.Controls.Add(this.lblNombreEscribania);
            this.Controls.Add(this.lblPrecioAlquiler);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtReserva);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridViewPropiedades);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblPresentarReciboSueldo);
            this.Controls.Add(this.lblPresentarGarantia);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblSeleccionarEscribania);
            this.Controls.Add(this.lblIngresarReserva);
            this.Controls.Add(this.lblSeleccionarPropiedad);
            this.Name = "FrmAlquiler";
            this.Text = "Alquiler";
            this.Load += new System.EventHandler(this.FrmAlquiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionarPropiedad;
        private System.Windows.Forms.Label lblIngresarReserva;
        private System.Windows.Forms.Label lblSeleccionarEscribania;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblPresentarGarantia;
        private System.Windows.Forms.Label lblPresentarReciboSueldo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridView dataGridViewPropiedades;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtReserva;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecioAlquiler;
        private System.Windows.Forms.Label lblNombreEscribania;
        private System.Windows.Forms.TextBox txtNombreEscribania;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoPropiedad;
        private System.Windows.Forms.ComboBox ComboBoxTipoPropiedad;
        private System.Windows.Forms.Label lblPrecio_Alquiler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalBoleto;
        private System.Windows.Forms.Label lblTotalImpuesto;
        private System.Windows.Forms.Label lblTotalDineroPropiedad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Button btnContrato;
    }
}