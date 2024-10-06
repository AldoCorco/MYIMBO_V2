using System;
using System.Windows.Forms;
using Services.DomainModel;
using Services.Services;
using Services.BLL;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Collections.Generic;

namespace WinFormsApp.Forms
{
    public partial class FrmGestorUsuarios : Form
    {
        
        private object _usuarioService;
        private Usuario idusuario;
        public object SelectedItem { get; set; }
        public FrmGestorUsuarios()
        {
            InitializeComponent();

            ////// Registra este formulario para escuchar el cambio de idioma;
            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);
        }


        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblUsuario.Text = LanguageBLL.Traducir("Usuario", lang);
                lblContraseña.Text = LanguageBLL.Traducir("Contraseña", lang);
                lblNombreCompleto.Text = LanguageBLL.Traducir("Nombre Completo", lang);
                lblTipoDocumento.Text = LanguageBLL.Traducir("Tipo Documento", lang);
                lblNroDocumento.Text = LanguageBLL.Traducir("Nro. Documento", lang);
                lblEmail.Text = LanguageBLL.Traducir("Email", lang);
                lblActivo.Text = LanguageBLL.Traducir("Activo", lang);
                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmGestorUsuarios_Load(object sender, EventArgs e)
        {
            //Inicio mostrando todos los usuarios. Sino hay tabla
            ListarTodosLosUsuario();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existe;
                existe = UsuarioManager.Instance.IniciarSesion(txtUsuario.Text, txtContraseña.Text);
                if (existe == true )
                {
                    MessageBox.Show("Ya existe el usuario");
                }
                else 
                {
                    //Aca creo el usuario
                    Usuario usuario = new Usuario();

                    usuario.UsuNom = txtUsuario.Text;
                    usuario.Contrasenia = CryptographyService.EncriptarContrasenia(txtContraseña.Text);
                    usuario.Nombre_Completo = txtNombreCompleto.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.TipoDocumento = txtTipoDocumento.Text;
                    usuario.NroDocumento = txtNroDocumento.Text;
                    usuario.Activo = checkBox1.Checked ? "S" : "N"; // Activo se guarda como "S" o "N"
                    usuario.EsAdmin = checkBox2.Checked ? "S" : "N"; // Activo se guarda como "S" o "N"

                    //Llamo a mi método CrearUsuario
                    UsuarioManager.Instance.CrearUsuario(usuario);

                    // Recargar la lista después de insertar
                    ListarTodosLosUsuario();
                    
                    // Limpio todos los campos
                    LimpiarCampos();
                }
            }
            catch (Exception)
            {

                throw;
            } 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Obtener el IdUsuario de la fila seleccionada
                    Guid idUsuario = (Guid)dataGridView2.SelectedRows[0].Cells["IdUsuario"].Value;

                    // Obtener los valores actualizados de los TextBox y CheckBox
                    string nuevoUsuNom = txtUsuario.Text;
                    string nuevoContrasenia = CryptographyService.EncriptarContrasenia(txtContraseña.Text);
                    string nuevoNombreCompleto = txtNombreCompleto.Text;
                    string nuevoEmail = txtEmail.Text;
                    string nuevoTipoDocumento = txtTipoDocumento.Text;
                    string nuevoNroDocumento = txtNroDocumento.Text;
                    bool nuevoActivo = checkBox1.Checked;
                    bool nuevoEsAdmin = checkBox2.Checked;

                    // Crear un objeto Usuario con los valores actualizados
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = idUsuario,
                        UsuNom = nuevoUsuNom,
                        Contrasenia = nuevoContrasenia,
                        Nombre_Completo = nuevoNombreCompleto,
                        Email = nuevoEmail,
                        TipoDocumento = nuevoTipoDocumento,
                        NroDocumento = nuevoNroDocumento,
                        Activo = nuevoActivo ? "S" : "N",
                        EsAdmin = nuevoEsAdmin ? "S" : "N",
                    };

                    // Llamar al método en UsuarioManager para actualizar el usuario
                    bool actualizacionExitosa = UsuarioManager.Instance.ModificarUsuario(usuario);

                    if (actualizacionExitosa)
                    {
                        // Obtener la lista actualizada de usuarios
                        var usuariosActualizados = UsuarioManager.Instance.ListarTodos();

                        // Asignar la lista como fuente de datos del DataGridView
                        dataGridView2.DataSource = usuariosActualizados;

                        // Volver a enlazar la fuente de datos del DataGridView
                        ListarTodosLosUsuario();

                        MessageBox.Show("Usuario actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al modificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ListarTodosLosUsuario()
        {

            try
            {
                // Obtener la lista de todos los usuarios utilizando el método GetAllUsuarios
                var usuarios = UsuarioManager.Instance.ListarTodos();

                // Asignar la lista de usuarios al DataGridView
                dataGridView2.DataSource = null; // Primero establece el origen de datos a null
                dataGridView2.DataSource = usuarios;

                // Dejo oculto el campo
                dataGridView2.Columns["IdUsuario"].Visible = false;

                dataGridView2.Columns["UsuNom"].HeaderText = "Nombre de Usuario";
                //dataGridView2.Columns["Contrasenia"].HeaderText = "Contraseña";
                dataGridView2.Columns["Contrasenia"].Visible = false;
                dataGridView2.Columns["Nombre_Completo"].HeaderText = "Nombre Completo";
                dataGridView2.Columns["Email"].HeaderText = "Correo Electrónico";
                dataGridView2.Columns["TipoDocumento"].HeaderText = "Tipo de Documento";
                dataGridView2.Columns["NroDocumento"].HeaderText = "Número de Documento";
                dataGridView2.Columns["Activo"].HeaderText = "Activo";
                dataGridView2.Columns["FechaCreacion_Usu"].HeaderText = "Fecha de Creación";
                dataGridView2.Columns["EsAdmin"].HeaderText = "Activo";

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada

                Guid idUsuario = (Guid)selectedRow.Cells["IdUsuario"].Value;
                string nombreUsuario = selectedRow.Cells["UsuNom"].Value.ToString();
                string contraseña = selectedRow.Cells["Contrasenia"].Value.ToString();
                string nombreCompleto = selectedRow.Cells["Nombre_Completo"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string tipoDocumento = selectedRow.Cells["TipoDocumento"].Value.ToString();
                string nroDocumento = selectedRow.Cells["NroDocumento"].Value.ToString();

                string activoValue = selectedRow.Cells["Activo"].Value.ToString();
                string EsAdminValue = selectedRow.Cells["EsAdmin"].Value.ToString();

                // Marca el CheckBox si el valor es "S", de lo contrario, lo desmarca
                checkBox1.Checked = (activoValue == "S");
                checkBox2.Checked = (EsAdminValue == "S");

                txtUsuario.Text = nombreUsuario;
                txtContraseña.Text = contraseña;
                txtNombreCompleto.Text = nombreCompleto;
                txtEmail.Text = email;
                txtTipoDocumento.Text = tipoDocumento;
                txtNroDocumento.Text = nroDocumento;

            }

        }


        private void LimpiarCampos()
        {
            // Limpiar los valores de los TextBox y el CheckBox
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtNombreCompleto.Clear();
            txtEmail.Clear();
            txtTipoDocumento.Clear();
            txtNroDocumento.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Obtener el IdUsuario de la fila seleccionada
                    Guid idUsuario = (Guid)dataGridView2.SelectedRows[0].Cells["IdUsuario"].Value;

                    // Obtener los valores actualizados de los TextBox y CheckBox
                    string nuevoUsuNom = txtUsuario.Text;
                    string nuevoContrasenia = txtContraseña.Text;
                    string nuevoNombreCompleto = txtNombreCompleto.Text;
                    string nuevoEmail = txtEmail.Text;
                    string nuevoTipoDocumento = txtTipoDocumento.Text;
                    string nuevoNroDocumento = txtNroDocumento.Text;
                    bool nuevoActivo = checkBox1.Checked;
                    bool nuevoEsAdmin = checkBox2.Checked;

                    UsuarioManager.Instance.BorrarUsuario(idUsuario);
                    
                }

                // Después de actualiza, recarga la lista si es necesario
                ListarTodosLosUsuario();

            }
            catch (Exception)
            {

                throw;
            }
        }

       
        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }

}
