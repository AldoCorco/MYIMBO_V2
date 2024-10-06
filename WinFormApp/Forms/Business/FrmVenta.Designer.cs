namespace WinFormApp.Forms.Business
{
    partial class FrmVenta
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.dataGridViewPropiedades = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.lblTotalDineroPropiedad = new System.Windows.Forms.Label();
            this.lblTotalImpuesto = new System.Windows.Forms.Label();
            this.lblTotalBoleto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.lblTipoPropiedad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDNIVendedor = new System.Windows.Forms.TextBox();
            this.lblDNI2 = new System.Windows.Forms.Label();
            this.txtApellidoVendedor = new System.Windows.Forms.TextBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.txtNombreVendedor = new System.Windows.Forms.TextBox();
            this.lblNombre2 = new System.Windows.Forms.Label();
            this.dataGridViewVentasPublicada = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentasPublicada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(687, 605);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(100, 45);
            this.btnLimpiarCampos.TabIndex = 38;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(539, 605);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 45);
            this.btnBorrar.TabIndex = 37;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(373, 605);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 45);
            this.btnModificar.TabIndex = 36;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(194, 605);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 45);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(51, 93);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 41;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(51, 132);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(103, 16);
            this.lblPrecioVenta.TabIndex = 40;
            this.lblPrecioVenta.Text = "Precio de Venta";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(194, 90);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 22);
            this.txtDescripcion.TabIndex = 43;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(194, 129);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(171, 22);
            this.txtPrecioVenta.TabIndex = 42;
            // 
            // dataGridViewPropiedades
            // 
            this.dataGridViewPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPropiedades.Location = new System.Drawing.Point(54, 168);
            this.dataGridViewPropiedades.Name = "dataGridViewPropiedades";
            this.dataGridViewPropiedades.RowHeadersWidth = 51;
            this.dataGridViewPropiedades.RowTemplate.Height = 24;
            this.dataGridViewPropiedades.Size = new System.Drawing.Size(546, 150);
            this.dataGridViewPropiedades.TabIndex = 49;
            this.dataGridViewPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            this.dataGridViewPropiedades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPropiedades_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Título de propiedad original";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(242, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "DNI";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(242, 36);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 53;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Certificado Castral";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 16);
            this.label4.TabIndex = 54;
            this.label4.Text = "Comprobantes de impuestos";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(569, 9);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 56;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(569, 35);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 57;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // lblTotalDineroPropiedad
            // 
            this.lblTotalDineroPropiedad.AutoSize = true;
            this.lblTotalDineroPropiedad.Location = new System.Drawing.Point(782, 296);
            this.lblTotalDineroPropiedad.Name = "lblTotalDineroPropiedad";
            this.lblTotalDineroPropiedad.Size = new System.Drawing.Size(10, 16);
            this.lblTotalDineroPropiedad.TabIndex = 67;
            this.lblTotalDineroPropiedad.Text = ":";
            // 
            // lblTotalImpuesto
            // 
            this.lblTotalImpuesto.AutoSize = true;
            this.lblTotalImpuesto.Location = new System.Drawing.Point(782, 256);
            this.lblTotalImpuesto.Name = "lblTotalImpuesto";
            this.lblTotalImpuesto.Size = new System.Drawing.Size(10, 16);
            this.lblTotalImpuesto.TabIndex = 66;
            this.lblTotalImpuesto.Text = ":";
            // 
            // lblTotalBoleto
            // 
            this.lblTotalBoleto.AutoSize = true;
            this.lblTotalBoleto.Location = new System.Drawing.Point(782, 215);
            this.lblTotalBoleto.Name = "lblTotalBoleto";
            this.lblTotalBoleto.Size = new System.Drawing.Size(10, 16);
            this.lblTotalBoleto.TabIndex = 65;
            this.lblTotalBoleto.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(782, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 64;
            this.label5.Text = "$";
            // 
            // ComboBoxTipoPropiedad
            // 
            this.ComboBoxTipoPropiedad.FormattingEnabled = true;
            this.ComboBoxTipoPropiedad.Items.AddRange(new object[] {
            "Casa",
            "Departamento",
            "Terreno",
            "Local"});
            this.ComboBoxTipoPropiedad.Location = new System.Drawing.Point(798, 109);
            this.ComboBoxTipoPropiedad.Name = "ComboBoxTipoPropiedad";
            this.ComboBoxTipoPropiedad.Size = new System.Drawing.Size(184, 24);
            this.ComboBoxTipoPropiedad.TabIndex = 63;
            this.ComboBoxTipoPropiedad.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTipoPropiedad_SelectedIndexChanged);
            // 
            // lblTipoPropiedad
            // 
            this.lblTipoPropiedad.AutoSize = true;
            this.lblTipoPropiedad.Location = new System.Drawing.Point(649, 118);
            this.lblTipoPropiedad.Name = "lblTipoPropiedad";
            this.lblTipoPropiedad.Size = new System.Drawing.Size(121, 16);
            this.lblTipoPropiedad.TabIndex = 62;
            this.lblTipoPropiedad.Text = "Tipo de Propiedad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 61;
            this.label6.Text = "Total Propiedad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(649, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Total Impuesto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(649, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 59;
            this.label8.Text = "Total Comisión";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(649, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 58;
            this.label9.Text = "Valor Propiedad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDNIVendedor);
            this.groupBox2.Controls.Add(this.lblDNI2);
            this.groupBox2.Controls.Add(this.txtApellidoVendedor);
            this.groupBox2.Controls.Add(this.lblApellido2);
            this.groupBox2.Controls.Add(this.txtNombreVendedor);
            this.groupBox2.Controls.Add(this.lblNombre2);
            this.groupBox2.Location = new System.Drawing.Point(54, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 150);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propietario";
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
            // dataGridViewVentasPublicada
            // 
            this.dataGridViewVentasPublicada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVentasPublicada.Location = new System.Drawing.Point(611, 405);
            this.dataGridViewVentasPublicada.Name = "dataGridViewVentasPublicada";
            this.dataGridViewVentasPublicada.RowHeadersWidth = 51;
            this.dataGridViewVentasPublicada.RowTemplate.Height = 24;
            this.dataGridViewVentasPublicada.Size = new System.Drawing.Size(377, 150);
            this.dataGridViewVentasPublicada.TabIndex = 69;
            this.dataGridViewVentasPublicada.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVentasPublicada_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(608, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 16);
            this.label10.TabIndex = 70;
            this.label10.Text = "Ventas Registradas";
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 662);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewVentasPublicada);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTotalDineroPropiedad);
            this.Controls.Add(this.lblTotalImpuesto);
            this.Controls.Add(this.lblTotalBoleto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboBoxTipoPropiedad);
            this.Controls.Add(this.lblTipoPropiedad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPropiedades);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPropiedades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentasPublicada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.DataGridView dataGridViewPropiedades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label lblTotalDineroPropiedad;
        private System.Windows.Forms.Label lblTotalImpuesto;
        private System.Windows.Forms.Label lblTotalBoleto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxTipoPropiedad;
        private System.Windows.Forms.Label lblTipoPropiedad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDNIVendedor;
        private System.Windows.Forms.Label lblDNI2;
        private System.Windows.Forms.TextBox txtApellidoVendedor;
        private System.Windows.Forms.Label lblApellido2;
        private System.Windows.Forms.TextBox txtNombreVendedor;
        private System.Windows.Forms.Label lblNombre2;
        private System.Windows.Forms.DataGridView dataGridViewVentasPublicada;
        private System.Windows.Forms.Label label10;
    }
}