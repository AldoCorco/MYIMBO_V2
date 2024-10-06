using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.BLL;
using Services.DomainModel;
using WinFormsApp.Forms;

namespace WinFormApp.Forms
{
    public partial class FrmLogin : Form
    {
        private Guid usuarioId;
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contrasenia = txtContraseña.Text;

            GlobalSystemValues.NombreUsuario = nombreUsuario;

            try
            {
                // Realiza la autenticación utilizando UsuarioManager
                bool inicioSesionExitoso = UsuarioManager.Instance.IniciarSesion(nombreUsuario, contrasenia);

                if (inicioSesionExitoso)
                {
                    // Muestra el mensaje de bienvenida
                    MostrarMensajeBienvenida();

                    // Obtiene el ID del usuario después del inicio de sesión exitoso
                    Guid? usuarioId = UsuarioManager.Instance.ObtenerUsuarioId(nombreUsuario);

                    if (usuarioId.HasValue)
                    {
                        // Obtener los permisos del usuario que ha iniciado sesión
                        List<string> userPermissions = ObtenerPermisosDelUsuario(usuarioId.Value);

                        // Inicio de sesión exitoso, abre el formulario principal del proyecto
                        FrmPrincipal frmPrincipal = new FrmPrincipal(this, userPermissions, usuarioId.Value);
                        this.Hide();
                        frmPrincipal.Show();
                    }
                    else
                    {
                        MessageBox.Show("El ID de usuario no pudo ser obtenido. Contacte a su administrador.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas. Inténtelo de nuevo ó contacte a su administrador.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error durante el inicio de sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<string> ObtenerPermisosDelUsuario(Guid usuarioId)
        {
            try
            {
                // Obtener los IDs de las patentes asignadas al usuario
                List<Guid> idsPatentesAsignadas = UsuarioManager.Instance.ObtenerIdsPatentesPorUsuario(usuarioId);

                // Convertir los IDs de patentes a strings
                List<string> permisosUsuario = idsPatentesAsignadas.Select(id => id.ToString()).ToList();

                return permisosUsuario;
            }
            catch (Exception ex)
            {
                // Maneja las excepciones según tus necesidades
                Console.WriteLine("Error al obtener los permisos del usuario: " + ex.Message);
                throw;
            }
        }


        private void MostrarMensajeBienvenida()
        {
            // Muestra el mensaje de bienvenida
            MessageBox.Show("Bienvenido al sistema MYIMBO", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnIngresar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al evento btnIngresar_Click cuando se presiona Enter
                btnIngresar_Click(sender, e);
            }
        }
    }
}
