namespace WinFormApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoAlquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPropiedadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propietarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resgistrarEscribaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.administraciónDelSistemaToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.idiomaToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarSesiónToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.sesiónToolStripMenuItem.Tag = "Menu";
            this.sesiónToolStripMenuItem.Text = "Sesión";
            // 
            // cambiarSesiónToolStripMenuItem
            // 
            this.cambiarSesiónToolStripMenuItem.Name = "cambiarSesiónToolStripMenuItem";
            this.cambiarSesiónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cambiarSesiónToolStripMenuItem.Tag = "SubMenu";
            this.cambiarSesiónToolStripMenuItem.Text = "Cambiar Sesión";
            this.cambiarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cambiarSesiónToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cerrarSesiónToolStripMenuItem.Tag = "SubMenu";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // administraciónDelSistemaToolStripMenuItem
            // 
            this.administraciónDelSistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeUsuariosToolStripMenuItem,
            this.gestiónDePermisosToolStripMenuItem,
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem});
            this.administraciónDelSistemaToolStripMenuItem.Name = "administraciónDelSistemaToolStripMenuItem";
            this.administraciónDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.administraciónDelSistemaToolStripMenuItem.Tag = "Menu";
            this.administraciónDelSistemaToolStripMenuItem.Text = "Administración del Sistema";
            this.administraciónDelSistemaToolStripMenuItem.Visible = false;
            // 
            // gestiónDeUsuariosToolStripMenuItem
            // 
            this.gestiónDeUsuariosToolStripMenuItem.Name = "gestiónDeUsuariosToolStripMenuItem";
            this.gestiónDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.gestiónDeUsuariosToolStripMenuItem.Tag = "SubMenu";
            this.gestiónDeUsuariosToolStripMenuItem.Text = "Gestión De Usuarios";
            this.gestiónDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuariosToolStripMenuItem_Click);
            // 
            // gestiónDePermisosToolStripMenuItem
            // 
            this.gestiónDePermisosToolStripMenuItem.Name = "gestiónDePermisosToolStripMenuItem";
            this.gestiónDePermisosToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.gestiónDePermisosToolStripMenuItem.Tag = "SubMenu";
            this.gestiónDePermisosToolStripMenuItem.Text = "Gestión de Permisos";
            this.gestiónDePermisosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDePermisosToolStripMenuItem_Click);
            // 
            // copiaDeSeguridadYRestaurarDBToolStripMenuItem
            // 
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem.Name = "copiaDeSeguridadYRestaurarDBToolStripMenuItem";
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem.Size = new System.Drawing.Size(319, 26);
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem.Tag = "SubMenu";
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem.Text = "Copia de seguridad y restaurar DB";
            this.copiaDeSeguridadYRestaurarDBToolStripMenuItem.Click += new System.EventHandler(this.copiaDeSeguridadYRestaurarDBToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alquilerToolStripMenuItem,
            this.compraToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.registrarPropiedadToolStripMenuItem,
            this.resgistrarEscribaniaToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.operacionesToolStripMenuItem.Tag = "Menu";
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            this.operacionesToolStripMenuItem.Visible = false;
            // 
            // alquilerToolStripMenuItem
            // 
            this.alquilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagoAlquilerToolStripMenuItem});
            this.alquilerToolStripMenuItem.Name = "alquilerToolStripMenuItem";
            this.alquilerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.alquilerToolStripMenuItem.Tag = "SubMenu";
            this.alquilerToolStripMenuItem.Text = "Alquiler";
            this.alquilerToolStripMenuItem.Click += new System.EventHandler(this.alquilerToolStripMenuItem_Click);
            // 
            // pagoAlquilerToolStripMenuItem
            // 
            this.pagoAlquilerToolStripMenuItem.Name = "pagoAlquilerToolStripMenuItem";
            this.pagoAlquilerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pagoAlquilerToolStripMenuItem.Tag = "SubMenu";
            this.pagoAlquilerToolStripMenuItem.Text = "Pago Alquiler";
            this.pagoAlquilerToolStripMenuItem.Click += new System.EventHandler(this.pagoAlquilerToolStripMenuItem_Click);
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abonarCompraToolStripMenuItem});
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.compraToolStripMenuItem.Tag = "SubMenu";
            this.compraToolStripMenuItem.Text = "Compra";
            this.compraToolStripMenuItem.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // abonarCompraToolStripMenuItem
            // 
            this.abonarCompraToolStripMenuItem.Name = "abonarCompraToolStripMenuItem";
            this.abonarCompraToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.abonarCompraToolStripMenuItem.Tag = "SubMenu";
            this.abonarCompraToolStripMenuItem.Text = "Abonar Compra";
            this.abonarCompraToolStripMenuItem.Click += new System.EventHandler(this.abonarCompraToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // registrarPropiedadToolStripMenuItem
            // 
            this.registrarPropiedadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propietarioToolStripMenuItem1});
            this.registrarPropiedadToolStripMenuItem.Name = "registrarPropiedadToolStripMenuItem";
            this.registrarPropiedadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.registrarPropiedadToolStripMenuItem.Tag = "SubMenu";
            this.registrarPropiedadToolStripMenuItem.Text = "Registrar Propiedad";
            this.registrarPropiedadToolStripMenuItem.Click += new System.EventHandler(this.registrarPropiedadToolStripMenuItem_Click);
            // 
            // propietarioToolStripMenuItem1
            // 
            this.propietarioToolStripMenuItem1.Name = "propietarioToolStripMenuItem1";
            this.propietarioToolStripMenuItem1.Size = new System.Drawing.Size(166, 26);
            this.propietarioToolStripMenuItem1.Tag = "SubMenu";
            this.propietarioToolStripMenuItem1.Text = "Propietario";
            this.propietarioToolStripMenuItem1.Click += new System.EventHandler(this.propietarioToolStripMenuItem1_Click);
            // 
            // resgistrarEscribaniaToolStripMenuItem
            // 
            this.resgistrarEscribaniaToolStripMenuItem.Name = "resgistrarEscribaniaToolStripMenuItem";
            this.resgistrarEscribaniaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.resgistrarEscribaniaToolStripMenuItem.Tag = "SubMenu";
            this.resgistrarEscribaniaToolStripMenuItem.Text = "Registrar Escribania";
            this.resgistrarEscribaniaToolStripMenuItem.Click += new System.EventHandler(this.resgistrarEscribaniaToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.españolToolStripMenuItem,
            this.inglesToolStripMenuItem,
            this.italianoToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.idiomaToolStripMenuItem.Tag = "Menu";
            this.idiomaToolStripMenuItem.Text = "Idioma";
            this.idiomaToolStripMenuItem.Visible = false;
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.españolToolStripMenuItem.Tag = "SubMenu";
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // inglesToolStripMenuItem
            // 
            this.inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            this.inglesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.inglesToolStripMenuItem.Tag = "SubMenu";
            this.inglesToolStripMenuItem.Text = "Ingles";
            this.inglesToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 720);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1382, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Usuario";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 20);
            this.toolStripStatusLabel1.Text = "Usuario";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(139, 20);
            this.toolStripStatusLabel2.Text = "[Sesión no iniciada]";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(42, 20);
            this.toolStripStatusLabel3.Text = "Hora";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1086, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(284, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // italianoToolStripMenuItem
            // 
            this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
            this.italianoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.italianoToolStripMenuItem.Text = "Italiano";
            this.italianoToolStripMenuItem.Click += new System.EventHandler(this.italianoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "D:\\FACULTAD\\3-Tercero\\TRABAJO DE DIPLOMA\\Codigos\\ProyectoProductivo2024\\MYIMBO_V2" +
    "\\WinFormApp\\bin\\Debug\\ManualdeUsuario.chm";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1382, 746);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrincipal_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem cambiarSesiónToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem copiaDeSeguridadYRestaurarDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagoAlquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonarCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPropiedadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resgistrarEscribaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propietarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

