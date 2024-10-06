using Services.BLL;
using Services.DAL.Implementations;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormApp.Forms.System_Management
{
    public partial class FrmGestorPermisos : Form
    {
        private Guid idFamilia = Guid.Empty;
        private Guid idPatente = Guid.Empty;

        public FrmGestorPermisos()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);

        }

        private void FrmGestorPermisos_Load(object sender, EventArgs e)
        {
            //Inicio mostrando todos los usuarios. Sino hay tabla
            ListarTodosLosUsuario();
            ListarTodosLosRoles();
            ListarTodosLosPermisos();
            MostrarPermisosEnGrilla();
            ListarTodosLosRolesUsuarios();
            //ListarRolesPorUsuario();
        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblUsuario.Text = LanguageBLL.Traducir("Usuario", lang);
                lblNombreRol.Text = LanguageBLL.Traducir("Nombre de Rol", lang);
                lblNombredeRol.Text = LanguageBLL.Traducir("Nombre de Rol", lang);
                lblNombrePermiso.Text = LanguageBLL.Traducir("Nombre de Permiso", lang);
                lblVistaPermiso.Text = LanguageBLL.Traducir("Vista del Permiso", lang);
                lblNombreCompleto.Text = LanguageBLL.Traducir("Nombre Completo", lang);
                groupBox1.Text = LanguageBLL.Traducir("Permisos", lang);
                groupBox2.Text = LanguageBLL.Traducir("Rol", lang);
                groupBox3.Text = LanguageBLL.Traducir("Rol de Usuario", lang);
                lblListaUsuarios.Text = LanguageBLL.Traducir("Listado Usuarios", lang);
                btnGuardar.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificar.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrar.Text = LanguageBLL.Traducir("Borrar", lang);
                btnLimpiarCampos.Text = LanguageBLL.Traducir("Limpiar Campos", lang);
                btnAgregarRol.Text = LanguageBLL.Traducir("Guardar", lang);
                btnModificarRol.Text = LanguageBLL.Traducir("Modificar", lang);
                btnBorrarRol.Text = LanguageBLL.Traducir("Borrar", lang);
                button4.Text = LanguageBLL.Traducir("Limpiar Campos", lang);
                btnAgregar.Text = LanguageBLL.Traducir("Agregar", lang);
                label1.Text = LanguageBLL.Traducir("Usuario", lang);
                label2.Text = LanguageBLL.Traducir("Nombre Completo", lang);
                label3.Text = LanguageBLL.Traducir("Nombre de Permiso", lang);

                btnAgregarPermiso.Text = LanguageBLL.Traducir("Guardar", lang);
                btnBorrarPermiso.Text = LanguageBLL.Traducir("Borrar", lang);
                groupBox4.Text = LanguageBLL.Traducir("Permiso por Usuario", lang);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListarTodosLosUsuario()
        {

            try
            {
                // Obtener la lista de todos los usuarios utilizando el método GetAllUsuarios
                var usuarios = UsuarioManager.Instance.ListarTodos();

                // Asignar la lista de usuarios al DataGridView
                dataGridView3.DataSource = null; // Primero establece el origen de datos a null
                dataGridView3.DataSource = usuarios;

                // Dejo oculto el campo
                dataGridView3.Columns["IdUsuario"].Visible = false;

                dataGridView3.Columns["UsuNom"].HeaderText = "Nombre de Usuario";
                dataGridView3.Columns["Contrasenia"].Visible = false;
                dataGridView3.Columns["Nombre_Completo"].HeaderText = "Nombre Completo";
                dataGridView3.Columns["Email"].Visible = false;
                dataGridView3.Columns["TipoDocumento"].Visible = false;
                dataGridView3.Columns["NroDocumento"].Visible = false;
                dataGridView3.Columns["Activo"].Visible = false;
                dataGridView3.Columns["FechaCreacion_Usu"].Visible = false;

                //LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView3.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView3.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idUsuario = (Guid)selectedRow.Cells["IdUsuario"].Value;
                string nombreUsuario = selectedRow.Cells["UsuNom"].Value.ToString();
                string nombreCompleto = selectedRow.Cells["Nombre_Completo"].Value.ToString();

                // Marca el CheckBox si el valor es "S", de lo contrario, lo desmarca
                //checkBox1.Checked = (activoValue == "S");
                txtUsuario.Text = nombreUsuario;
                txtNombreCompleto.Text = nombreCompleto;

                textBox1.Text = nombreUsuario;
                txtPermiso2.Text = nombreCompleto;

            }
        }

        
        public void ListarTodosLosRoles()
        {
            try
            {
                // Obtengo la lista de todas las familias utilizando el método ListarFamilias de FamiliaManager
                var familias = FamiliaManager.Instance.ListarFamilias();

                // Asignar la lista de familias al DataGridView
                dataGridView_Roles.DataSource = null; // Primero establece el origen de datos a null
                dataGridView_Roles.DataSource = familias;

                // Dejo oculto el campo

                dataGridView_Roles.Columns["IdFamilia"].Visible = false;
                dataGridView_Roles.Columns["NombreRol"].HeaderText = "Nombre de Rol"; // Ajusta el nombre de la columna según tu modelo de datos
                dataGridView_Roles.Columns["Patentes"].Visible = false;
                dataGridView_Roles.Columns["Usu_nom"].Visible = false;
                dataGridView_Roles.Columns["IdUsuario"].Visible = false;
                dataGridView_Roles.Columns["IdPatente"].Visible = false;
                dataGridView_Roles.Columns["Fecha_Familia"].Visible = false;
                dataGridView_Roles.Columns["FechaCreacion"].Visible = false;
                dataGridView_Roles.Columns["FechaCreacionUF"].Visible = false;
                dataGridView_Roles.Columns["FechaCreacionFP"].Visible = false;
                dataGridView_Roles.Columns["Nombre"].Visible = false;
                dataGridView_Roles.Columns["EsAdmin"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListarRolesPorUsuario()
        {
            try
            {
                //Obtener la lista de roles por usuario usando el método correspondiente de tu lógica de negocio
                var roles = UsuarioManager.Instance.ListarRolesPorUsuario();

                //Asignar la lista de roles al DataGridView
                dataGridView_RolUsuario.DataSource = null; // Primero establece el origen de datos a null
                dataGridView_RolUsuario.DataSource = roles;

                //Configurar las columnas según sea necesario
                dataGridView_RolUsuario.Columns["IdRol"].Visible = false; // Ocultar la columna IdRol si es necesario
                dataGridView_RolUsuario.Columns["NombreRol"].HeaderText = "Nombre del Rol";


                dataGridView_RolUsuario.Columns["IdFamilia"].Visible = false;
                dataGridView_RolUsuario.Columns["NombreRol"].HeaderText = "Nombre de Rol"; // Ajusta el nombre de la columna según tu modelo de datos
                dataGridView_RolUsuario.Columns["Fecha_Familia"].Visible = false;
            }
            catch (Exception ex)
            {
                //Manejar la excepción si ocurre alguna
                Console.WriteLine("Error al listar roles por usuario: " + ex.Message);
                throw; // Lanza la excepción para que sea manejada por el código que llama a este método
            }


        }

        public void ListarTodosLosRolesUsuarios()
        {
            try
            {
                //dataGridView_RolUsuario
                var usuariofamilia = UsuarioFamiliaRepository.Instance.SelectAll();

                // Asignar la lista de usuarios al DataGridView
                dataGridView_RolUsuario.DataSource = null; // Primero establece el origen de datos a null
                dataGridView_RolUsuario.DataSource = usuariofamilia;

                dataGridView_RolUsuario.Columns["IdUsuario"].Visible = false;
                dataGridView_RolUsuario.Columns["IdFamilia"].Visible = false;
                dataGridView_RolUsuario.Columns["FechaCreacionUF"].Visible = false;

                dataGridView_RolUsuario.Columns["NombreRol"].HeaderText = "Nombre de Rol";
                dataGridView_RolUsuario.Columns["Usu_nom"].HeaderText = "Nombre de Usuario";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ListarTodosLosPermisos()
        {
            try
            {
                //Obtengo la lista de todas las patentes
                var patente = PatenteManager.Instance.ListarPatentes();

                // Asignar la lista de usuarios al DataGridView
                dataGridView_Permisos.DataSource = null; // Primero establece el origen de datos a null
                dataGridView_Permisos.DataSource = patente;

                dataGridView_Permisos.Columns["IdPatente"].Visible = false;
                dataGridView_Permisos.Columns["NombrePermiso"].HeaderText = "Nombre de Permiso";
                dataGridView_Permisos.Columns["Vista"].HeaderText = "Nombre de Vista";
                dataGridView_Permisos.Columns["Fecha_Patente"].Visible = false;
                dataGridView_Permisos.Columns["IdUsuario"].Visible = false;
                dataGridView_Permisos.Columns["FechaCreacion"].Visible = false;
                dataGridView_Permisos.Columns["PermisoPadreId"].Visible = false;
                dataGridView_Permisos.Columns["PermisoPadreNombre"].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void dataGridView_Roles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_Roles.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView_Roles.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idFamilia = (Guid)selectedRow.Cells["IdFamilia"].Value;
                string nombreFamilia = selectedRow.Cells["NombreRol"].Value.ToString();

                txtRol.Text = nombreFamilia;
                txtRol2.Text = nombreFamilia;

                textBox2.Text = nombreFamilia;

                //idFamilia = idFamilia;

            }
        }

        private void dataGridView_RolUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_RolUsuario.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView_RolUsuario.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idFamilia = (Guid)selectedRow.Cells["IdFamilia"].Value;
                Guid idUsuario = (Guid)selectedRow.Cells["IdUsuario"].Value;


                string nombreFamilia = selectedRow.Cells["NombreRol"].Value.ToString();
                //string nombreUsuario = selectedRow.Cells["UsuNom"].Value.ToString();
                //string nombreCompleto = selectedRow.Cells["Nombre_Completo"].Value.ToString();


                //txtUsuario.Text = nombreUsuario;
                //txtNombreCompleto.Text = nombreCompleto;
                txtRol2.Text = nombreFamilia;

            }
        }

        private void dataGridView_Permisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho doble clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_Permisos.Rows.Count)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView_Permisos.Rows[e.RowIndex];

                // Accede a los valores de las celdas de la fila seleccionada
                Guid idPatente = (Guid)selectedRow.Cells["IdPatente"].Value;
                string nombrePatente = selectedRow.Cells["NombrePermiso"].Value.ToString();
                string nombreVistaPatente = selectedRow.Cells["Vista"].Value.ToString();

                // Marca el CheckBox si el valor es "S", de lo contrario, lo desmarca
                //checkBox1.Checked = (activoValue == "S");
                txtPermiso.Text = nombrePatente;
                txtVistaPermiso.Text = nombreVistaPatente;

                //txtPermiso2.Text = nombrePatente;
                txtVistaPermiso2.Text = nombrePatente;

                textBox3.Text = nombrePatente;

                //idPatente = idPatenteSeleccionada;


            }
        }


        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreRol = txtRol.Text;

                // Verificar si el rol ya existe
                bool existe = FamiliaManager.Instance.ExisteRol(nombreRol);

                if (existe)
                {
                    MessageBox.Show("Ya existe el rol");
                }
                else
                {
                    // Generar un nuevo idFamilia automáticamente o según tu lógica de aplicación
                    Guid idFamilia = Guid.NewGuid();

                    Familia familia = new Familia();
                    familia.IdFamilia = idFamilia;
                    familia.NombreRol = nombreRol;

                    // Llamo a mi método CrearElRol
                    FamiliaManager.Instance.CrearRol(familia);

                    // Recargar la lista después de insertar
                    ListarTodosLosRoles();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre alguna
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en la DataGridView
                if (dataGridView_Roles.SelectedRows.Count > 0)
                {
                    // Obtener el IdFamilia de la fila seleccionada
                    Guid idFamilia = (Guid)dataGridView_Roles.SelectedRows[0].Cells["IdFamilia"].Value;

                    // Obtener el valor actualizado del TextBox
                    string nuevoNombreRol = txtRol.Text;

                    // Crear un objeto Familia con el nombre actualizado
                    Familia familia = new Familia
                    {
                        IdFamilia = idFamilia,
                        NombreRol = nuevoNombreRol
                    };

                    // Llamar al método en FamiliaManager para actualizar el rol
                    bool actualizacionExitosa = FamiliaManager.Instance.ModificarFamilia(familia);

                    if (actualizacionExitosa)
                    {
                        // Obtener la lista actualizada de familias
                        var familiasActualizadas = FamiliaManager.Instance.ListarFamilias();

                        // Asignar la lista como fuente de datos del DataGridView
                        dataGridView_Roles.DataSource = familiasActualizadas;

                        // Volver a enlazar la fuente de datos del DataGridView
                        ListarTodosLosRoles();
                        LimpiarCampos();
                        //MessageBox.Show("Rol actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el rol.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al modificar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Guardar Permisos
        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Crear un objeto Patente con los valores ingresados
        //        // Generar un nuevo idPatente automáticamente o según tu lógica de aplicación
        //        Guid idPatente = Guid.NewGuid();
        //        Patente nuevaPatente = new Patente
        //        {
        //            IdPatente = idPatente,
        //            NombrePermiso = nombrePermiso,
        //            Vista = nombreVista
        //        };



        //        // Llamar al método en el PatenteManager para crear la patente
        //        bool patenteCreada = PatenteManager.Instance.CrearPatentePermiso(nuevaPatente);

        //        if (patenteCreada)
        //        {
        //            MessageBox.Show("Patente creada correctamente.");
        //            // Limpiar los TextBox después de crear la patente
        //            txtPermiso.Clear();
        //            txtVistaPermiso.Clear();

        //            // Recargar los datos en el dataGridView_Permisos
        //            ListarTodosLosPermisos();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al crear la patente. Por favor, inténtalo de nuevo más tarde.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción si ocurre alguna
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}


        //Modificar Permiso

        /// <summary>
        /// Guarda permiso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los TextBox
                string nombrePermiso = txtPermiso.Text;
                string nombreVista = txtVistaPermiso.Text;

                // Verificar si la patente ya existe
                bool existe = PatenteManager.Instance.ExistePermisoPatente(nombrePermiso);

                if (existe)
                {
                    MessageBox.Show($"Ya existe el permiso '{nombrePermiso}'.");
                }
                else
                {
                    // Crear un objeto Patente con los valores ingresados
                    Guid idPatente = Guid.NewGuid();
                    Patente nuevaPatente = new Patente
                    {
                        IdPatente = idPatente,
                        NombrePermiso = nombrePermiso,
                        Vista = nombreVista
                    };

                    // Llamar al método en el PatenteManager para crear la patente
                    bool patenteCreada = PatenteManager.Instance.CrearPatentePermiso(nuevaPatente);

                    if (patenteCreada)
                    {
                        MessageBox.Show("Patente creada correctamente.");
                        // Limpiar los TextBox después de crear la patente
                        LimpiarCampos();
                        // Recargar los datos en el dataGridView_Permisos
                        ListarTodosLosPermisos();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear la patente. Por favor, inténtalo de nuevo más tarde.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre alguna
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        //Borrar Permiso
        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        //Limpiar Permiso
        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {

        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
 
        /// <summary>
        /// Agregar Rol a Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los TextBox
                string nombrePermiso = txtPermiso.Text;
                string nombreVista = txtVistaPermiso.Text;

                // Verificar si se han seleccionado un usuario y un rol
                if (dataGridView3.SelectedRows.Count > 0 && dataGridView_Roles.SelectedRows.Count > 0)
                {
                    // Obtener los identificadores del usuario y del rol seleccionados
                    Guid idUsuario = Guid.Parse(dataGridView3.SelectedRows[0].Cells["IdUsuario"].Value.ToString());
                    Guid idFamilia = Guid.Parse(dataGridView_Roles.SelectedRows[0].Cells["IdFamilia"].Value.ToString());

                    // Obtener el nombre del usuario y el nombre del rol desde las filas seleccionadas
                    string nombreUsuario = dataGridView3.SelectedRows[0].Cells["UsuNom"].Value.ToString();
                    string nombreFamilia = dataGridView_Roles.SelectedRows[0].Cells["NombreRol"].Value.ToString();

                    // Verificar si el rol ya está asignado al usuario
                    bool existeRol = UsuarioManager.Instance.ExisteRolAlUsuario(nombreUsuario, nombreFamilia);

                    if (existeRol)
                    {
                        // Mostrar un mensaje si el rol ya está asignado al usuario
                        MessageBox.Show($"El usuario '{nombreUsuario}' ya tiene asignado el rol '{nombreFamilia}'.");

                    }
                    else
                    {
                        // Intentar agregar el rol al usuario
                        bool rolAgregado = UsuarioManager.Instance.CrearRolParaUsuario(idUsuario, idFamilia, nombreUsuario, nombreFamilia);

                        if (rolAgregado)
                        {
                            // Mostrar un mensaje si el rol se asignó correctamente
                            MessageBox.Show($"Se asignó el rol '{nombreFamilia}' al usuario '{nombreUsuario}' correctamente.");

                            // Recargar la grilla de roles de usuarios
                            ListarTodosLosRolesUsuarios();

                        }
                        else
                        {
                            // Mostrar un mensaje si no se pudo agregar el rol al usuario
                            MessageBox.Show($"No se pudo agregar el rol '{nombreFamilia}' al usuario '{nombreUsuario}'. Por favor, inténtalo de nuevo más tarde.");
                        }
                    }
                }
                else
                {
                    // Mostrar un mensaje si no se han seleccionado usuario y rol
                    MessageBox.Show("Por favor, selecciona un usuario y un rol antes de intentar asignar el rol.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje en caso de error
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Borrar Rol a Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView_RolUsuario.SelectedRows.Count > 0)
            {
                // Obtiene el ID del usuario seleccionado en la fila
                Guid idUsuario = (Guid)dataGridView_RolUsuario.SelectedRows[0].Cells["IdUsuario"].Value;

                // Intenta borrar el rol del usuario utilizando el ID del usuario
                bool borradoExitoso = UsuarioManager.Instance.BorrarRolParaUsuario(idUsuario);

                if (borradoExitoso)
                {
                    // Muestra un mensaje de éxito
                    MessageBox.Show("Rol borrado exitosamente.");

                    // Vuelve a cargar la lista de roles de usuarios en el DataGridView
                    ListarTodosLosRolesUsuarios();
                }
                else
                {
                    // Muestra un mensaje de error si no se pudo borrar el rol del usuario
                    MessageBox.Show("Error al borrar el rol del usuario.");
                }
            }
            else
            {
                // Si no hay una fila seleccionada, muestra un mensaje de advertencia
                MessageBox.Show("Por favor, seleccione un usuario de la lista.");
            }
        }


        private void LimpiarCampos()
        {
            // Limpiar los valores de los TextBox y el CheckBox
            txtUsuario.Clear();
            txtNombreCompleto.Clear();
            txtPermiso.Clear();
            txtVistaPermiso.Clear();

            txtRol.Clear();
            txtRol2.Clear();


        }
        private void dataGridView_Roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        //private void btnAgregarPermiso_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //txtPermiso2.Text = nombrePatente;
        //        //txtVistaPermiso2.Text = nombrePatente;

        //        // Verifica si hay una fila seleccionada en dataGridView3
        //        if (dataGridViewPermisosUsuarios.SelectedRows.Count > 0)
        //        {
        //            // Obtiene el idUsuario de la fila seleccionada en dataGridView3
        //            Guid idUsuario = (Guid)dataGridView3.SelectedRows[0].Cells["IdUsuario"].Value;

        //            // Verifica si hay una fila seleccionada en dataGridView_Permisos
        //            if (dataGridView_Permisos.SelectedRows.Count > 0)
        //            {
        //                // Obtiene el idPatente de la fila seleccionada en dataGridView_Permisos
        //                Guid idPatente = (Guid)dataGridView_Permisos.SelectedRows[0].Cells["IdPatente"].Value;

        //                // Llama al método AgregarPatenteAUsuario para agregar el permiso al usuario
        //                if (UsuarioManager.Instance.AgregarPatenteAUsuario(idUsuario, idPatente))
        //                {
        //                    MessageBox.Show("Permiso agregado al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    // Vuelve a cargar los usuarios para reflejar los cambios
        //                    ListarTodosLosUsuario();
        //                    ListarTodosLosPermisos();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Error al agregar el permiso al usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Seleccione un permiso en la lista de permisos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Seleccione un usuario en la lista de usuarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se produjo un error al agregar el permiso al usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los TextBox
                string nombrePermiso = txtPermiso.Text;
                string nombreVista = txtVistaPermiso.Text;

                // Verificar si se han seleccionado un usuario y un permiso
                if (dataGridView3.SelectedRows.Count > 0 && dataGridView_Permisos.SelectedRows.Count > 0)
                {
                    // Obtener los identificadores del usuario y del permiso seleccionados
                    Guid idUsuario = Guid.Parse(dataGridView3.SelectedRows[0].Cells["IdUsuario"].Value.ToString());
                    Guid idPermiso = Guid.Parse(dataGridView_Permisos.SelectedRows[0].Cells["IdPatente"].Value.ToString());

                    // Obtener el nombre del usuario y el nombre del permiso desde las filas seleccionadas
                    string nombreUsuario = dataGridView3.SelectedRows[0].Cells["UsuNom"].Value.ToString();
                    string nombrePermisoSeleccionado = dataGridView_Permisos.SelectedRows[0].Cells["NombrePermiso"].Value.ToString();

                    // Intentar agregar el permiso al usuario
                    bool usuarioPermisoAgregado = UsuarioManager.Instance.AgregarPatenteAUsuario(idUsuario, idPermiso);

                    if (usuarioPermisoAgregado)
                    {
                        // Mostrar un mensaje si se asignó correctamente el permiso al usuario
                        MessageBox.Show("Permiso agregado al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPermisosEnGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el permiso al usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje si no se han seleccionado usuario y permiso
                    MessageBox.Show("Seleccione un usuario y un permiso antes de intentar agregar el permiso al usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje en caso de error
                MessageBox.Show("Se produjo un error al agregar el permiso al usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnBorrarPermiso_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Verifica si hay una fila seleccionada en dataGridViewPermisosUsuarios
        //        if (dataGridViewPermisosUsuarios.SelectedRows.Count > 0)
        //        {
        //            // Obtiene el IdUsuario y el IdPatente de la fila seleccionada
        //            Guid idUsuario = (Guid)dataGridViewPermisosUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
        //            Guid idPatente = (Guid)dataGridViewPermisosUsuarios.SelectedRows[0].Cells["IdPatente"].Value;

        //            // Llama al método EliminarPatenteDeUsuario para eliminar el permiso del usuario
        //            bool eliminado = UsuarioManager.Instance.EliminarPatenteDeUsuario(idUsuario, idPatente);
        //            if (eliminado)
        //            {
        //                MessageBox.Show("Permiso eliminado del usuario con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                // Vuelve a cargar los usuarios para reflejar los cambios
        //                ListarTodosLosUsuario();
        //                ListarTodosLosPermisos();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error al eliminar el permiso del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Seleccione una fila en la lista de permisos de usuarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se produjo un error al eliminar el permiso del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnBorrarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay una fila seleccionada en dataGridViewPermisosUsuarios
                if (dataGridViewPermisosUsuarios.SelectedRows.Count > 0)
                {
                    // Obtiene el IdUsuario y el IdPatente de la fila seleccionada
                    Guid idUsuario = (Guid)dataGridViewPermisosUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
                    Guid idPatente = (Guid)dataGridViewPermisosUsuarios.SelectedRows[0].Cells["IdPatente"].Value;

                    // Llama al método EliminarPatenteDeUsuario para eliminar el permiso del usuario
                    bool eliminado = UsuarioManager.Instance.EliminarPatenteDeUsuario(idUsuario, idPatente);
                    if (eliminado)
                    {
                        MessageBox.Show("Permiso eliminado del usuario con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Vuelve a cargar los usuarios para reflejar los cambios
                        ListarTodosLosUsuario();
                        ListarTodosLosPermisos();
                        MostrarPermisosEnGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el permiso del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila en la lista de permisos de usuarios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al eliminar el permiso del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnActualizarPermiso_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridViewPermisosUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void MostrarPermisosEnGrilla()
        {
            try
            {
                // Obtengo la lista de todos los permisos utilizando el método ListarUsuarioPermisos
                var permisos = UsuarioPatenteManager.Instance.ListarUsuarioPermisos();

                // Asignar la lista de permisos al DataGridView
                dataGridViewPermisosUsuarios.DataSource = null; // Primero establece el origen de datos a null
                dataGridViewPermisosUsuarios.DataSource = permisos;

                // Ajustar las columnas según tu estructura de UsuarioPatente
                dataGridViewPermisosUsuarios.Columns["IdUsuario"].Visible = false;
                dataGridViewPermisosUsuarios.Columns["IdPatente"].Visible = false;
                dataGridViewPermisosUsuarios.Columns["FechaCreacion"].Visible = false;

                dataGridViewPermisosUsuarios.Columns["NombrePermiso"].HeaderText = "Nombre de Permiso";
                dataGridViewPermisosUsuarios.Columns["Vista"].HeaderText = "Nombre de Vista";
                dataGridViewPermisosUsuarios.Columns["Usu_nom"].HeaderText = "Nombre de Usuario";
                dataGridViewPermisosUsuarios.Columns["Nombre_Completo"].HeaderText = "Nombre Completo";

                // Puedes ajustar los nombres de las columnas y cualquier otra lógica según tus necesidades

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al listar los permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Permisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya hecho clic en la columna deseada
            if (e.ColumnIndex == dataGridView_Permisos.Columns["NombrePermiso"].Index && e.RowIndex >= 0)
            {
                // Llama al método MostrarPermisosEnGrilla
                MostrarPermisosEnGrilla();
            }
        }

        /// <summary>
        /// Guarda El Rol y el permiso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha seleccionado un rol y un permiso
                if (dataGridView_Roles.SelectedRows.Count > 0 && dataGridView_Permisos.SelectedRows.Count > 0)
                {
                    // Obtiene el IdFamilia y el IdPatente de las filas seleccionadas en las grillas
                    Guid idFamilia = Guid.Parse(dataGridView_Roles.SelectedRows[0].Cells["IdFamilia"].Value.ToString());
                    Guid idPermiso = Guid.Parse(dataGridView_Permisos.SelectedRows[0].Cells["IdPatente"].Value.ToString());

                    // Crea un objeto PatenteFamilia con los IdFamilia y IdPatente obtenidos
                    PatenteFamilia patenteFamilia = new PatenteFamilia
                    {
                        IdFamilia = idFamilia,
                        IdPatente = idPermiso,
                        FechaCreacionFP = DateTime.Now,
                    };

                    // Llama al método para crear el permiso del rol
                   //PatenteFamiliaManager.Instance.AgregarFamiliaPatente(patenteFamilia);
                    //PatenteFamiliaManager.Instance.AgregarFamiliaPatente(patenteFamilia);

                    //if (creado)
                    //{
                    //    MessageBox.Show("Permiso del rol creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error al crear el permiso del rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un rol y un permiso antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
