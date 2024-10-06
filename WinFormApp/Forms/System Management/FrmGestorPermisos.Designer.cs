namespace WinFormApp.Forms.System_Management
{
    partial class FrmGestorPermisos
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
            this.lblNombredeRol = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Permisos = new System.Windows.Forms.DataGridView();
            this.txtVistaPermiso = new System.Windows.Forms.TextBox();
            this.lblVistaPermiso = new System.Windows.Forms.Label();
            this.txtPermiso = new System.Windows.Forms.TextBox();
            this.lblNombrePermiso = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.btnBorrarRol = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.dataGridView_Roles = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblListaUsuarios = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.txtRol2 = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_RolUsuario = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPermisosUsuarios = new System.Windows.Forms.DataGridView();
            this.btnBorrarPermiso = new System.Windows.Forms.Button();
            this.txtVistaPermiso2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPermiso2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permisos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Roles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RolUsuario)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosUsuarios)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(387, 98);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(98, 45);
            this.btnLimpiarCampos.TabIndex = 21;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(268, 98);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(87, 45);
            this.btnBorrar.TabIndex = 24;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(151, 98);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(96, 45);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblNombredeRol
            // 
            this.lblNombredeRol.AutoSize = true;
            this.lblNombredeRol.Location = new System.Drawing.Point(22, 30);
            this.lblNombredeRol.Name = "lblNombredeRol";
            this.lblNombredeRol.Size = new System.Drawing.Size(99, 16);
            this.lblNombredeRol.TabIndex = 25;
            this.lblNombredeRol.Text = "Nombre de Rol";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(127, 24);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(244, 22);
            this.txtRol.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_Permisos);
            this.groupBox1.Controls.Add(this.txtVistaPermiso);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.btnLimpiarCampos);
            this.groupBox1.Controls.Add(this.lblVistaPermiso);
            this.groupBox1.Controls.Add(this.txtPermiso);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.lblNombrePermiso);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 296);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos";
            // 
            // dataGridView_Permisos
            // 
            this.dataGridView_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Permisos.Location = new System.Drawing.Point(24, 164);
            this.dataGridView_Permisos.Name = "dataGridView_Permisos";
            this.dataGridView_Permisos.RowHeadersWidth = 51;
            this.dataGridView_Permisos.Size = new System.Drawing.Size(469, 100);
            this.dataGridView_Permisos.TabIndex = 34;
            this.dataGridView_Permisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Permisos_CellClick);
            this.dataGridView_Permisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Permisos_CellClick);
            // 
            // txtVistaPermiso
            // 
            this.txtVistaPermiso.Location = new System.Drawing.Point(151, 55);
            this.txtVistaPermiso.Name = "txtVistaPermiso";
            this.txtVistaPermiso.Size = new System.Drawing.Size(295, 22);
            this.txtVistaPermiso.TabIndex = 33;
            // 
            // lblVistaPermiso
            // 
            this.lblVistaPermiso.AutoSize = true;
            this.lblVistaPermiso.Location = new System.Drawing.Point(21, 61);
            this.lblVistaPermiso.Name = "lblVistaPermiso";
            this.lblVistaPermiso.Size = new System.Drawing.Size(112, 16);
            this.lblVistaPermiso.TabIndex = 32;
            this.lblVistaPermiso.Text = "Vista del Permiso";
            // 
            // txtPermiso
            // 
            this.txtPermiso.Location = new System.Drawing.Point(151, 24);
            this.txtPermiso.Name = "txtPermiso";
            this.txtPermiso.Size = new System.Drawing.Size(295, 22);
            this.txtPermiso.TabIndex = 31;
            // 
            // lblNombrePermiso
            // 
            this.lblNombrePermiso.AutoSize = true;
            this.lblNombrePermiso.Location = new System.Drawing.Point(21, 30);
            this.lblNombrePermiso.Name = "lblNombrePermiso";
            this.lblNombrePermiso.Size = new System.Drawing.Size(128, 16);
            this.lblNombrePermiso.TabIndex = 30;
            this.lblNombrePermiso.Text = "Nombre de Permiso";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(24, 98);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 45);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarRol);
            this.groupBox2.Controls.Add(this.btnBorrarRol);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btnModificarRol);
            this.groupBox2.Controls.Add(this.dataGridView_Roles);
            this.groupBox2.Controls.Add(this.lblNombredeRol);
            this.groupBox2.Controls.Add(this.txtRol);
            this.groupBox2.Location = new System.Drawing.Point(1201, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 296);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rol";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRol.Location = new System.Drawing.Point(25, 98);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(94, 45);
            this.btnAgregarRol.TabIndex = 43;
            this.btnAgregarRol.Text = "Guardar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // btnBorrarRol
            // 
            this.btnBorrarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarRol.Location = new System.Drawing.Point(256, 98);
            this.btnBorrarRol.Name = "btnBorrarRol";
            this.btnBorrarRol.Size = new System.Drawing.Size(87, 45);
            this.btnBorrarRol.TabIndex = 42;
            this.btnBorrarRol.Text = "Borrar";
            this.btnBorrarRol.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(375, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 45);
            this.button4.TabIndex = 40;
            this.button4.Text = "Limpiar Campos";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarRol.Location = new System.Drawing.Point(139, 98);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(96, 45);
            this.btnModificarRol.TabIndex = 41;
            this.btnModificarRol.Text = "Modificar";
            this.btnModificarRol.UseVisualStyleBackColor = true;
            this.btnModificarRol.Click += new System.EventHandler(this.btnModificarRol_Click);
            // 
            // dataGridView_Roles
            // 
            this.dataGridView_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Roles.Location = new System.Drawing.Point(25, 164);
            this.dataGridView_Roles.Name = "dataGridView_Roles";
            this.dataGridView_Roles.RowHeadersWidth = 51;
            this.dataGridView_Roles.Size = new System.Drawing.Size(463, 100);
            this.dataGridView_Roles.TabIndex = 35;
            this.dataGridView_Roles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Roles_CellClick);
            this.dataGridView_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Roles_CellContentClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(39, 376);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(461, 113);
            this.dataGridView3.TabIndex = 29;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // lblListaUsuarios
            // 
            this.lblListaUsuarios.AutoSize = true;
            this.lblListaUsuarios.Location = new System.Drawing.Point(12, 341);
            this.lblListaUsuarios.Name = "lblListaUsuarios";
            this.lblListaUsuarios.Size = new System.Drawing.Size(108, 16);
            this.lblListaUsuarios.TabIndex = 30;
            this.lblListaUsuarios.Text = "Listado Usuarios";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(164, 45);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(141, 22);
            this.txtUsuario.TabIndex = 32;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(22, 51);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblUsuario.TabIndex = 31;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Location = new System.Drawing.Point(22, 116);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(99, 16);
            this.lblNombreRol.TabIndex = 33;
            this.lblNombreRol.Text = "Nombre de Rol";
            // 
            // txtRol2
            // 
            this.txtRol2.Location = new System.Drawing.Point(164, 113);
            this.txtRol2.Name = "txtRol2";
            this.txtRol2.Size = new System.Drawing.Size(244, 22);
            this.txtRol2.TabIndex = 34;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(44, 151);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 35;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(164, 78);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(282, 22);
            this.txtNombreCompleto.TabIndex = 37;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Location = new System.Drawing.Point(22, 81);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(117, 16);
            this.lblNombreCompleto.TabIndex = 36;
            this.lblNombreCompleto.Text = "Nombre Completo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_RolUsuario);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.lblUsuario);
            this.groupBox3.Controls.Add(this.txtNombreCompleto);
            this.groupBox3.Controls.Add(this.txtUsuario);
            this.groupBox3.Controls.Add(this.lblNombreCompleto);
            this.groupBox3.Controls.Add(this.txtRol2);
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.lblNombreRol);
            this.groupBox3.Location = new System.Drawing.Point(1201, 354);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 382);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rol de Usuario";
            // 
            // dataGridView_RolUsuario
            // 
            this.dataGridView_RolUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RolUsuario.Location = new System.Drawing.Point(25, 211);
            this.dataGridView_RolUsuario.Name = "dataGridView_RolUsuario";
            this.dataGridView_RolUsuario.RowHeadersWidth = 51;
            this.dataGridView_RolUsuario.RowTemplate.Height = 24;
            this.dataGridView_RolUsuario.Size = new System.Drawing.Size(389, 150);
            this.dataGridView_RolUsuario.TabIndex = 40;
            this.dataGridView_RolUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RolUsuario_CellContentClick);
            this.dataGridView_RolUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RolUsuario_CellContentClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(256, 151);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 39;
            this.button5.Text = "Borrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewPermisosUsuarios);
            this.groupBox4.Controls.Add(this.btnBorrarPermiso);
            this.groupBox4.Controls.Add(this.txtVistaPermiso2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnAgregarPermiso);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtPermiso2);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(631, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(513, 390);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Permiso por Usuario";
            // 
            // dataGridViewPermisosUsuarios
            // 
            this.dataGridViewPermisosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermisosUsuarios.Location = new System.Drawing.Point(18, 231);
            this.dataGridViewPermisosUsuarios.Name = "dataGridViewPermisosUsuarios";
            this.dataGridViewPermisosUsuarios.RowHeadersWidth = 51;
            this.dataGridViewPermisosUsuarios.RowTemplate.Height = 24;
            this.dataGridViewPermisosUsuarios.Size = new System.Drawing.Size(443, 123);
            this.dataGridViewPermisosUsuarios.TabIndex = 44;
            this.dataGridViewPermisosUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPermisosUsuarios_CellContentClick);
            // 
            // btnBorrarPermiso
            // 
            this.btnBorrarPermiso.Location = new System.Drawing.Point(262, 161);
            this.btnBorrarPermiso.Name = "btnBorrarPermiso";
            this.btnBorrarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarPermiso.TabIndex = 42;
            this.btnBorrarPermiso.Text = "Borrar";
            this.btnBorrarPermiso.UseVisualStyleBackColor = true;
            this.btnBorrarPermiso.Click += new System.EventHandler(this.btnBorrarPermiso_Click);
            // 
            // txtVistaPermiso2
            // 
            this.txtVistaPermiso2.Location = new System.Drawing.Point(157, 100);
            this.txtVistaPermiso2.Name = "txtVistaPermiso2";
            this.txtVistaPermiso2.Size = new System.Drawing.Size(282, 22);
            this.txtVistaPermiso2.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Nombre de Permiso";
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(50, 161);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarPermiso.TabIndex = 40;
            this.btnAgregarPermiso.Text = "Agregar";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Usuario";
            // 
            // txtPermiso2
            // 
            this.txtPermiso2.Location = new System.Drawing.Point(157, 66);
            this.txtPermiso2.Name = "txtPermiso2";
            this.txtPermiso2.Size = new System.Drawing.Size(282, 22);
            this.txtPermiso2.TabIndex = 41;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Nombre Completo";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1778, 9);
            this.vScrollBar1.Maximum = 150;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 1031);
            this.vScrollBar1.TabIndex = 40;
            this.vScrollBar1.TabStop = true;
            this.vScrollBar1.UseWaitCursor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Location = new System.Drawing.Point(631, 467);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(524, 296);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(152, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(295, 22);
            this.textBox3.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Nombre de Permiso";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 27);
            this.button1.TabIndex = 43;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(256, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 27);
            this.button2.TabIndex = 42;
            this.button2.Text = "Borrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(139, 98);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 27);
            this.button7.TabIndex = 41;
            this.button7.Text = "Modificar";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(463, 100);
            this.dataGridView1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nombre de Rol";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 22);
            this.textBox2.TabIndex = 26;
            // 
            // FrmGestorPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1816, 744);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblListaUsuarios);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGestorPermisos";
            this.Text = "GestorPermisos";
            this.Load += new System.EventHandler(this.FrmGestorPermisos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permisos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Roles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RolUsuario)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosUsuarios)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblNombredeRol;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPermiso;
        private System.Windows.Forms.Label lblNombrePermiso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtVistaPermiso;
        private System.Windows.Forms.Label lblVistaPermiso;
        private System.Windows.Forms.DataGridView dataGridView_Permisos;
        private System.Windows.Forms.DataGridView dataGridView_Roles;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label lblListaUsuarios;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.TextBox txtRol2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBorrarRol;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnModificarRol;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView_RolUsuario;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtVistaPermiso2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPermiso2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBorrarPermiso;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.DataGridView dataGridViewPermisosUsuarios;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
    }
}