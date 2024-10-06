using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Strategy.Alquiler;
using Services.BLL;
using Services.DomainModel;
using WinFormApp.Forms;
using WinFormApp.Forms.Business;
using WinFormApp.Forms.System_Management;
using WinFormsApp.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace WinFormApp
{
    public partial class FrmPrincipal : Form
    {
        private FrmLogin frmParaCerrar = null;
        private List<string> _userPermissions;

        // Establece un idioma predeterminado
        private static string idiomaActual = "es-AR";

        //Variable para recuperar en usuario logueado al sistema
        string nombreUsuario = GlobalSystemValues.NombreUsuario;
        

        public FrmPrincipal(FrmLogin frmLogin, List<string> userPermissions, Guid usuarioId)
        {
            InitializeComponent();

            frmParaCerrar = frmLogin;
            _userPermissions = userPermissions;

            // Suscribe el método CambiarIdiomaPrincipal al evento LanguageChanged
            LanguageBLL.LanguageChanged += CambiarIdiomaPrincipal;

            // Manejar el evento FormClosing para cerrar la aplicación correctamente
            this.FormClosing += FrmPrincipal_FormClosing;

            // Llama al método ConfigurarMenusPorUsuario de UsuarioManager para configurar los menús
            UsuarioManager.Instance.ConfigurarMenusPorUsuario(usuarioId, menuStrip1);
        }


        public void CambiarIdiomaPrincipal(object sender, EventArgs e)
        {
            // Actualiza el idioma de los controles en este formulario
            CambiarIdiomaEnTodosLosFormularios(LanguageBLL.CurrentLanguage);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Establece la ruta completa del archivo CHM usando Path.Combine para garantizar la compatibilidad con diferentes sistemas operativos
            string rutaManualUsuario = Path.Combine(Application.StartupPath, "ManualdeUsuario.chm");

            // Verifica si el archivo CHM existe antes de establecerlo como la ayuda del proveedor de ayuda
            if (File.Exists(rutaManualUsuario))
            {
                helpProvider1.HelpNamespace = rutaManualUsuario;
            }
            else
            {
                MessageBox.Show("El archivo de ayuda no se encontró en la ubicación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MostrarMenusParaUsuario();
            // Muestra el nombre de usuario en un control, como una etiqueta en la barra de menú
            toolStripStatusLabel2.Text = nombreUsuario;

            // Muestro la fecha y hora actual en mi etiqueta label1. Ejemplo ("dd-MM-yyyy HH:mm:ss"
            timer1.Enabled = true;
        }



        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Llama al método para cambiar los nombres de los menús
            //CambiarIdiomaEnMenu("es-AR");
            CambiarIdioma("es-AR");
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Llama al método para cambiar los nombres de los menús
            //CambiarIdiomaEnMenu("en-GB");
            CambiarIdioma("en-GB");
        }


        private void italianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarIdioma("it-IT");
        }

        public void CambiarIdioma(string lang)
        {
            // Llama al método para cambiar los nombres de los menús en el formulario principal
            CambiarIdiomaEnMenu(lang);

            // Llama al método para cambiar los nombres de los controles en este formulario
            CambiarIdiomaEnTodosLosFormularios(lang);

            //TraducirMesnsajes(lang);
        }



        public void CambiarIdiomaEnTodosLosFormularios(string lang)
        {

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

            foreach (Form formulario in Application.OpenForms)
            {
                // Verifica si el formulario es diferente de FrmLogin y es un formulario que quieres traducir
                if (formulario != this && formulario.GetType() != typeof(FrmLogin))
                {
                    CambiarIdiomaFormulario(formulario, lang);
                }
            }

        }

        private void CambiarIdiomaFormulario(Form formulario, string lang)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmPrincipal || form is FrmLogin)
                {
                    // No cambies el idioma de estos formularios si no es necesario.
                    // Esto evita la recursión infinita.
                    continue;
                }

                // Cambia el idioma de los demás formularios
                MethodInfo changeLanguageMethod = form.GetType().GetMethod("CambiarIdiomaEnFormulario", BindingFlags.Instance | BindingFlags.NonPublic);
                if (changeLanguageMethod != null)
                {
                    changeLanguageMethod.Invoke(form, new object[] { lang });
                }
            }

        }
     


        private void CambiarIdiomaEnMenu(string lang)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                //Cambia el idioma de los menús

                //MenuPadre
                sesiónToolStripMenuItem.Text = LanguageBLL.Traducir("Sesión", lang);
                //SubMenuHijos
                cambiarSesiónToolStripMenuItem.Text = LanguageBLL.Traducir("Cambiar Sesión", lang);
                cerrarSesiónToolStripMenuItem.Text = LanguageBLL.Traducir("Cerrar Sesión", lang);

                //MenuPadre
                administraciónDelSistemaToolStripMenuItem.Text = LanguageBLL.Traducir("Administración del Sistema", lang);
                //SubMenuHijos
                gestiónDeUsuariosToolStripMenuItem.Text = LanguageBLL.Traducir("Gestión de Usuarios", lang);
                gestiónDePermisosToolStripMenuItem.Text = LanguageBLL.Traducir("Gestión de Permisos", lang);
                copiaDeSeguridadYRestaurarDBToolStripMenuItem.Text = LanguageBLL.Traducir("Copia de seguridad y restaurar DB", lang);

                //MenuPadre
                operacionesToolStripMenuItem.Text = LanguageBLL.Traducir("Operaciones", lang);
                //SubMenuHijos
                alquilerToolStripMenuItem.Text = LanguageBLL.Traducir("Alquiler", lang);
                pagoAlquilerToolStripMenuItem.Text = LanguageBLL.Traducir("Pago Alquiler", lang);
                compraToolStripMenuItem.Text = LanguageBLL.Traducir("Compra", lang);
                abonarCompraToolStripMenuItem.Text = LanguageBLL.Traducir("Abonar Compra", lang);
                ventaToolStripMenuItem.Text = LanguageBLL.Traducir("Venta", lang);
                registrarPropiedadToolStripMenuItem.Text = LanguageBLL.Traducir("Registrar Propiedad", lang);
                propietarioToolStripMenuItem1.Text = LanguageBLL.Traducir("Propietario", lang);
                resgistrarEscribaniaToolStripMenuItem.Text = LanguageBLL.Traducir("Registrar Escribania", lang);

                //MenuPadre
                idiomaToolStripMenuItem.Text = LanguageBLL.Traducir("Idioma", lang);
                españolToolStripMenuItem.Text = LanguageBLL.Traducir("Español", lang);
                inglesToolStripMenuItem.Text = LanguageBLL.Traducir("Ingles", lang);
                ayudaToolStripMenuItem.Text = LanguageBLL.Traducir("Ayuda", lang);

                
                toolStripStatusLabel1.Text = LanguageBLL.Traducir("Usuario", lang);
                toolStripStatusLabel3.Text = LanguageBLL.Traducir("Hora", lang);
                                
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir del sistema y cerrar la aplicación?",
                                         "Confirmación",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar sesión y salir del sistema
                // Cerrar la aplicación
                Application.Exit();
            }
            else
            {
                // El usuario ha hecho clic en "No", cancelar la acción
            }

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
 
            // Mostrar el mensaje de confirmación solo si el motivo del cierre es Close
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir del sistema y cerrar la aplicación?",
                //                                      "Confirmación",
                //                                      MessageBoxButtons.YesNo,
                //                                      MessageBoxIcon.Question);

                string mensajeConfirmacion = LanguageBLL.Traducir("¿Estás seguro de que deseas salir del sistema y cerrar la aplicación?", idiomaActual);

                DialogResult result = MessageBox.Show(mensajeConfirmacion,
                                                      LanguageBLL.Traducir("Confirmación", idiomaActual),
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    // Cancelar el cierre si el usuario hace clic en No
                    e.Cancel = true;
                }
                else
                {
                    // Cerrar la aplicación si el usuario hace clic en Sí
                    Application.Exit();
                }
            }
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestorUsuarios frm = new FrmGestorUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cambiarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            // Muestra un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro de cerrar la sesión actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                // Cierra el formulario actual (FrmPrincipal)
                this.Close();

                // Abre el formulario de inicio de sesión (FrmLogin)
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Muestro la hora del sistema en mi sistema HH:mm:ss
            //lblHora.Text = "Hora: " + DateTime.Now.ToLongTimeString();
            toolStripStatusLabel3.Text = "Hora: " + DateTime.Now.ToLongTimeString();

        }

        private void copiaDeSeguridadYRestaurarDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeguridadRestaurar frmSeguridadRestaurar = new FrmSeguridadRestaurar();
            frmSeguridadRestaurar.MdiParent = this;
            frmSeguridadRestaurar.Show();
        }

        private void gestiónDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestorPermisos frm = new FrmGestorPermisos();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pagoAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagoAlquiler fm = new FrmPagoAlquiler();
            fm.MdiParent = this;
            fm.Show();
        }

        private void abonarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagoCompra fm = new FrmPagoCompra();
            fm.MdiParent = this;
            fm.Show();
        }

        private void tasarPropiedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarPropiedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropiedades frm = new FrmPropiedades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void resgistrarEscribaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEscribania frm = new FrmEscribania();
            frm.MdiParent = this;
            frm.Show();
        }

        private void alquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ICalculadorAlquiler calculadorCasa = new CalculadorCasa();

            FrmAlquiler frm = new FrmAlquiler(calculadorCasa);
            frm.MdiParent = this;
            frm.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra frm = new FrmCompra();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenta frm = new FrmVenta();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void compradorToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmComprador frm = new FrmComprador();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void propietarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropietario frm = new FrmPropietario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void propietarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPropietario frm = new FrmPropietario();
            frm.MdiParent = this;
            frm.Show();
        }

       

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre el archivo CHM usando el proveedor de ayuda
            Help.ShowHelp(this, helpProvider1.HelpNamespace);

        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó la tecla F1
            if (e.KeyCode == Keys.F1)
            {
                // Abre el archivo CHM usando el proveedor de ayuda
                Help.ShowHelp(this, helpProvider1.HelpNamespace);
            }
        }

        private void propiedadesPublicadasToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
    }
}
