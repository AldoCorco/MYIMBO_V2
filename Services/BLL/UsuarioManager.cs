using Services.DAL.Contracts;
using Services.DAL.Implementations;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Services.BLL
{
    /// <summary>
    /// Gestor para la administración de usuarios, patentes y familias.
    /// </summary>
    public class UsuarioManager
    {
        private static UsuarioManager _instance;
        //private object _patenteFamiliaRepository;

        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Patente> _patenteRepository;
        private readonly IGenericRepository<Familia> _familiaRepository;
        private readonly IGenericRepository<PatenteFamilia> _patenteFamiliaRepository;


        /// <summary>
        /// Manager para la gestión de usuarios, patentes y familias.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio de usuarios.</param>
        /// <param name="patenteRepository">Repositorio de patentes.</param>
        /// <param name="familiaRepository">Repositorio de familias.</param>
        /// <param name="patenteFamiliaRepository">Repositorio de relaciones entre patentes y familias.</param>
        private UsuarioManager(IGenericRepository<Usuario> usuarioRepository, IGenericRepository<Patente> patenteRepository, IGenericRepository<Familia> familiaRepository, IGenericRepository<PatenteFamilia> patenteFamiliaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _patenteRepository = patenteRepository;
            _familiaRepository = familiaRepository;
            _patenteFamiliaRepository = patenteFamiliaRepository;

        }

        /// <summary>
        /// Instancia única de la clase UsuarioManager utilizando el patrón Singleton.
        /// </summary>
        public static UsuarioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var usuarioRepository = UsuarioRepository.Instance;
                    var patenteRepository = PatenteRepository.Instance;
                    var familiaRepository = FamiliaRepository.Instance;
                    var patenteFamiliaRepository = PatenteFamiliaRepository.Instance;

                    _instance = new UsuarioManager(usuarioRepository, patenteRepository, familiaRepository, patenteFamiliaRepository);
                }
                return _instance;
            }
        }

        //public string nombreUsuario { get; private set; }

        /// <summary>
        /// Inicia sesión para un usuario con el nombre de usuario y contraseña proporcionados.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contrasenia">Contraseña del usuario.</param>
        /// <returns>
        /// True si la sesión se inicia con éxito y el usuario tiene los permisos necesarios;
        /// de lo contrario, false.
        /// </returns>
        public bool IniciarSesion(string nombreUsuario, string contrasenia)
        {
            try
            {
                Usuario usuario = _usuarioRepository.SelectOneSesion(nombreUsuario);

                if (usuario != null && usuario.Activo == "S")
                {
                    // Encriptar la contraseña proporcionada por el usuario y comparar con la almacenada en la base de datos
                    string contraseniaEncriptada = CryptographyService.EncriptarContrasenia(contrasenia);

                    // Verificar si las contraseñas coinciden
                    if (contraseniaEncriptada == usuario.Contrasenia)
                    {
                        if (usuario.EsAdmin == "S")
                        {
                            // Usuario administrador, tiene acceso a todos los menús
                            usuario.Patentes = ObtenerTodasLasPatentes();
                            usuario.Familias = ObtenerTodasLasFamilias();
                            
                            return true;
                        }
                        else
                        {
                            // No es administrador
                            //Obtengo la lista de permisos por usuario
                            usuario.Patentes = ListaPatentesPorUsuario(usuario.IdUsuario);
                            //Obtengo la lista de roles por usuario
                            usuario.Familias = ObtenerFamiliasPorUsuario(usuario.IdUsuario);

                            // Verificar si el usuario tiene acceso a algún menú
                            if (usuario.Patentes.Any() || usuario.Familias.Any())
                            {
                                return true; // Usuario válido con permisos para ver menús
                            }
                        }
                    }
                }

                return false; // Usuario inválido, inactivo o sin permisos para ver menús
            }
            catch (Exception ex)
            {
                return false; // Tratar la operación como fallida debido a la excepción
            }
        }

        private List<PatenteFamilia> ListarRolesPermisos()
        {
            return (List<PatenteFamilia>)_patenteFamiliaRepository.SelectAll();

        }


        /// <summary>
        /// Obtiene todas las patentes disponibles.
        /// </summary>
        /// <returns>Lista de objetos Patente que representa todas las patentes disponibles.</returns>
        private List<Patente> ObtenerTodasLasPatentes()
        {
            return _patenteRepository.ObtenerPatentes();
        }



        /// <summary>
        /// Agrega una patente a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario al que se agregará la patente.</param>
        /// <param name="idPatente">ID de la patente que se agregará al usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public bool AgregarPatenteAUsuario(Guid idUsuario, Guid idPatente)
        {
            try
            {
                // Obtener el usuario y la patente desde los repositorios
                Usuario usuario = _usuarioRepository.SelectOne(idUsuario);
                Patente patente = _patenteRepository.SelectOne(idPatente);

                if (usuario != null && patente != null)
                {
                    // Verificar si el usuario ya tiene la patente
                    if (usuario.Patentes.Any(p => p.IdPatente == idPatente))
                    {
                        Console.WriteLine("El usuario ya tiene esta patente.");
                    }
                    else
                    {
                        // Llamar al método UnirUsuarioPatente para establecer la relación
                        if (_patenteRepository.UnirUsuarioPatente(idUsuario, idPatente))
                        {
                            Console.WriteLine("Patente agregada al usuario exitosamente.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Error al unir la patente al usuario.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Usuario o patente no encontrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la patente al usuario: " + ex.Message);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        public bool  EliminarPatenteDeUsuario(Guid idUsuario, Guid idPatente) 
        {
            try
            {
                // Obtener el usuario y la patente desde los repositorios
                Usuario usuario = _usuarioRepository.SelectOne(idUsuario);
                Patente patente = _patenteRepository.SelectOne(idPatente);

                return _patenteRepository.BorrarUsuarioPatente(idUsuario, idPatente);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene los IDs de las patentes asignadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de IDs de las patentes asignadas al usuario.</returns>
        public List<Guid> ObtenerIdsPatentesPorUsuario(Guid usuarioId)
        {

            List<Patente> patentesAsignadas = _patenteRepository.ObtenerPatentesPorUsuario(usuarioId);
            List<Guid> idsPatentesAsignadas = patentesAsignadas.Select(patente => patente.IdPatente).ToList();
            return idsPatentesAsignadas;

        }

        /// <summary>
        /// Obtiene la lista de patentes asignadas a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Lista de objetos Patente que representa las patentes asignadas al usuario.</returns>
        public List<Patente> ListaPatentesPorUsuario(Guid idUsuario)
        {
            Usuario usuario = _usuarioRepository.SelectOne(idUsuario);

            // Verificar si el usuario NO es administrador
            if (usuario != null && usuario.EsAdmin != "S")
            {
                List<Guid> idPatenteAsignadas = ObtenerIdsPatentesPorUsuario(idUsuario);
                List<Patente> patentesAsignadas = new List<Patente>();

                foreach (Guid idPatente in idPatenteAsignadas)
                {
                    Patente patente = _patenteRepository.SelectOne(idPatente);
                    if (patente != null)
                    {
                        patentesAsignadas.Add(patente);
                    }
                }

                return patentesAsignadas;
            }
            else
            {
                // Si el usuario es administrador, no necesita consultar permisos
                return ObtenerTodasLasPatentes(); // Implementa este método para obtener todas las patentes
            }
        }

        /// <summary>
        /// Obtiene las familias asignadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de objetos Familia que representa las familias asignadas al usuario.</returns>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            
            List<Familia> familias = _familiaRepository.ObtenerFamiliasPorUsuario(usuarioId);

            return familias;

        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">Objeto Usuario que contiene la información del nuevo usuario.</param>
        /// <returns>True si la operación de creación fue exitosa; de lo contrario, false.</returns>
        public bool CrearUsuario(Usuario usuario)
        {
            // Llamar al método en la capa DAL para crear el usuario.
              return _usuarioRepository.Add(usuario);

        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios.
        /// </summary>
        /// <returns>Enumerable de objetos Usuario que representa la lista de todos los usuarios.</returns>
        public IEnumerable<Usuario> ListarTodos()
        {
            //Muestro todos los usuario al iniciar el formulario
            return _usuarioRepository.SelectAll();
        }


        /// <summary>
        /// Modifica la información de un usuario existente.
        /// </summary>
        /// <param name="usuario">Objeto Usuario que contiene la información actualizada del usuario.</param>
        /// <returns>True si la operación de modificación fue exitosa; de lo contrario, false.</returns>
        public bool ModificarUsuario(Usuario usuario)
        {
            return _usuarioRepository.Update(usuario);

        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        /// <returns>True si la operación de eliminación fue exitosa; de lo contrario, false.</returns>
        public bool BorrarUsuario(Guid idUsuario)
        {
            // Llamar al método en la capa DAL para eliminar el usuario
            return _usuarioRepository.Delete(idUsuario);

        }

        /// <summary>
        /// Verifica si un usuario tiene un rol específico.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario a verificar.</param>
        /// <param name="nombreRol">Nombre del rol a verificar.</param>
        /// <returns>True si el usuario tiene el rol específico; de lo contrario, false.</returns>
        public bool ExisteRolAlUsuario(string nombreUsuario, string nombreRol)
        {
            try
            {
                // Llama al método del repositorio para verificar si el usuario tiene el rol específico
                return _usuarioRepository.ExisteUsuarioRol(nombreUsuario, nombreRol);
            }
            catch (Exception ex)
            {
                // Maneja la excepción si es necesario o lanza una nueva excepción específica
                Console.WriteLine("Error al verificar si el usuario tiene el rol específico: " + ex.Message);
                throw; // Lanza la excepción para que sea manejada por el código que llama a este método
            }
        }

        /// <summary>
        /// Crea un nuevo rol para un usuario.
        /// </summary>
        /// <param name="idUsuario">Identificador único del usuario al que se le asignará el rol.</param>
        /// <param name="idFamilia">Identificador único del rol (familia) a asignar.</param>
        /// <param name="UsuNom">Nombre de usuario asociado al rol.</param>
        /// <param name="NombreRol">Nombre del rol a asignar.</param>
        /// <returns>True si la creación del rol para el usuario fue exitosa; de lo contrario, false.</returns>
        public bool CrearRolParaUsuario(Guid idUsuario, Guid idFamilia, string UsuNom, string NombreRol)
        {
            try
            {
                // Llama al método Add de UsuarioFamiliaRepository y retorna el resultado
                return UsuarioFamiliaRepository.Instance.Add(idUsuario, idFamilia, UsuNom, NombreRol);


            }
            catch (Exception ex)
            {
                // Maneja la excepción o lanza una nueva excepción específica si es necesario
                Console.WriteLine("Error al crear rol para usuario: " + ex.Message);
                return false;
            }
        }

        public bool BorrarRolParaUsuario(Guid idUsuario)
        {
            return UsuarioFamiliaRepository.Instance.Delete(idUsuario);
        }

        /// <summary>
        /// Obtiene la lista de todos los roles de usuario.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="Usuario"/> que representan los roles de usuario.</returns>
        public IEnumerable<Usuario> ListarRolesPorUsuario()
        {
            
            ////Muestro todos los usuario al iniciar el formulario
            return _usuarioRepository.SelectAll();
        }

        /// <summary>
        /// Obtiene el identificador único de un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario para el cual se busca el identificador único.</param>
        /// <returns>El identificador único del usuario.</returns>
        /// <exception cref="Exception">Se lanza si el usuario no se encuentra.</exception>
        public Guid ObtenerUsuarioId(string nombreUsuario)
        {

            try
            {
                Usuario usuario = _usuarioRepository.SelectOneByName(nombreUsuario);

                if (usuario != null)
                {
                    return usuario.IdUsuario;
                }

                throw new Exception("Usuario no encontrado"); // O manejar esta excepción según tus necesidades
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al obtener el ID del usuario: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un menú principal por su nombre en un <see cref="MenuStrip"/>.
        /// </summary>
        /// <param name="nombreMenu">El nombre del menú principal que se busca.</param>
        /// <param name="menuStrip">El <see cref="MenuStrip"/> donde se busca el menú principal.</param>
        /// <returns>El <see cref="ToolStripMenuItem"/> que representa el menú principal encontrado, o null si no se encuentra.</returns>
        private ToolStripMenuItem ObtenerMenuPrincipal(string nombreMenu, MenuStrip menuStrip)
        {
            // Método auxiliar para obtener un menú principal por su nombre
            ToolStripMenuItem menuPrincipal = null;

            // Busca el menú principal en los menús ya existentes
            foreach (ToolStripMenuItem menu in menuStrip.Items)
            {
                if (menu.Text == nombreMenu)
                {
                    menuPrincipal = menu;
                    break;
                }
            }

            return menuPrincipal;
        }

        /// <summary>
        /// Configura los menús y submenús de un <see cref="MenuStrip"/> según las patentes asignadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario para el cual se configuran los menús.</param>
        /// <param name="menuStrip">El <see cref="MenuStrip"/> que se configura.</param>
        //public void ConfigurarMenusPorUsuario(Guid usuarioId, MenuStrip menuStrip)
        //{
        //    // Lista para realizar un seguimiento de los menús principales ya agregados
        //    List<ToolStripMenuItem> menusPrincipalesAgregados = new List<ToolStripMenuItem>();

        //    // Obtengo todas las patentes disponibles
        //    List<Patente> todasLasPatentes = PatenteManager.Instance.ListarPatentes().ToList();

        //    // Obtengo las patentes(permisos) específicas del usuario
        //    List<Patente> patentesUsuario = _patenteRepository.ObtenerPatentesPorUsuario(usuarioId).ToList();

        //    //Obtengo las familias(roles) específicas del usuario
        //    List<Familia> familiaUsuario = _familiaRepository.ObtenerFamiliasPorUsuario(usuarioId).ToList();

        //    //Familia = _familiaRepository.SelectOne(familiaUsuario);

        //    //List<PatenteFamilia> patentefamilia = PatenteFamiliaRepository.Instance.SelectOne(idfamilia);

        //    // Itera sobre todas las patentes disponibles y configura la visibilidad de los menús y submenús según los permisos
        //    foreach (Patente patente in todasLasPatentes)
        //    {
        //        ToolStripItem menuItem;

        //        // Verifica si el permiso es un menú principal
        //        if (string.IsNullOrEmpty(patente.PermisoPadreNombre))
        //        {
        //            // Busca el menú principal correspondiente
        //            ToolStripMenuItem menuPrincipal = ObtenerMenuPrincipal(patente.NombrePermiso, menuStrip);

        //            // Si se encontró el menú principal, configura el menú principal
        //            if (menuPrincipal != null)
        //            {
        //                menuItem = menuPrincipal;

        //                // Agrega el menú principal a la lista de menús principales ya agregados
        //                menusPrincipalesAgregados.Add(menuPrincipal);
        //            }
        //            else
        //            {
        //                menuItem = new ToolStripMenuItem();
        //                menuItem.Text = patente.NombrePermiso;
        //                menuItem.Tag = "Menu"; // Etiqueta que indica que es un menú principal

        //                // Añade condiciones adicionales para agregar submenús específicos
        //                if (EsSubMenuEspecifico(patente.NombrePermiso))
        //                {
        //                    // Agrega el menú principal a la barra de menú
        //                    menuStrip.Items.Add(menuItem);

        //                    // Agrega el menú principal a la lista de menús principales ya agregados
        //                    menusPrincipalesAgregados.Add((ToolStripMenuItem)menuItem);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Es un submenú, busca el menú principal correspondiente
        //            ToolStripMenuItem menuPadre = ObtenerMenuPrincipal(patente.PermisoPadreNombre, menuStrip);

        //            // Si se encontró el menú principal y no se ha agregado, configura el submenú
        //            if (menuPadre != null && !menusPrincipalesAgregados.Contains(menuPadre))
        //            {
        //                menuItem = new ToolStripMenuItem();
        //                menuItem.Text = patente.NombrePermiso;
        //                menuItem.Tag = "SubMenu"; // Etiqueta que indica que es un submenú

        //                // Añade condiciones adicionales para agregar submenús específicos
        //                if (EsSubMenuEspecifico(patente.NombrePermiso))
        //                {
        //                    // Agrega el submenú al menú principal
        //                    menuPadre.DropDownItems.Add(menuItem);
        //                }
        //            }
        //            else
        //            {
        //                // Si no se encontró el menú principal o ya se agregó, no se puede agregar el submenú
        //                continue;
        //            }
        //        }

        //        // Configura otras propiedades comunes
        //        menuItem.Name = patente.Vista;
        //        menuItem.Tag = patente.IdPatente;

        //        // Lee el campo Tag y ajusta la visibilidad en consecuencia
        //        if (menuItem.Tag != null && menuItem.Tag.ToString() == "SubMenu")
        //        {
        //            // Es un submenú, forzar la visibilidad a true
        //            menuItem.Visible = true;
        //        }
        //        else
        //        {
        //            // Es un menú principal, ajustar la visibilidad según sea necesario
        //            menuItem.Visible = patentesUsuario.Any(p => p.IdPatente == patente.IdPatente); // Solo visible si está en las patentes del usuario
        //        }
        //    }

        //    // Desactiva los menús que no se encontraron en las patentes del usuario
        //    DesactivarMenusNoEncontrados(menuStrip, menusPrincipalesAgregados);
        //}

        /// <summary>
        /// Determina si un permiso es un submenú específico basado en su nombre.
        /// </summary>
        /// <param name="nombrePermiso">El nombre del permiso que se evalúa.</param>
        /// <returns>
        /// true si el permiso es un submenú específico; de lo contrario, false.
        /// </returns>
        private bool EsSubMenuEspecifico(string nombrePermiso)
        {
            // Implementa la lógica necesaria para determinar si un permiso es un submenú específico
            // Por ejemplo, puedes usar una lógica condicional basada en el nombre del permiso
            return nombrePermiso.StartsWith("SubMenuEspecifico");
        }



        /// <summary>
        /// Configura los menús y submenús de un <see cref="MenuStrip"/> según las patentes asignadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario para el cual se configuran los menús.</param>
        /// <param name="menuStrip">El <see cref="MenuStrip"/> que se configura.</param>
        public void ConfigurarMenusPorUsuario(Guid usuarioId, MenuStrip menuStrip)
        {
            // Lista para realizar un seguimiento de los menús principales ya agregados
            List<ToolStripMenuItem> menusPrincipalesAgregados = new List<ToolStripMenuItem>();

            // Obtener las familias específicas del usuario
            List<Familia> familiasUsuario = _familiaRepository.ObtenerFamiliasPorUsuario(usuarioId).ToList();

            // Iterar sobre cada familia y configurar los menús
            foreach (Familia familia in familiasUsuario)
            {
                //// Obtener las patentes asociadas a la familia actual
                //List<Patente> patentesFamilia = ObtenerPatentesPorFamilia(familia.IdFamilia);

                // Obtener las patentes asociadas a la familia actual
                List<Patente> patentesFamilia = ObtenerPatentesPorFamilia(familia.IdFamilia);

                // Configurar los menús basados en las patentes de esta familia
                ConfigurarMenusPorPatentes(patentesFamilia, menuStrip, menusPrincipalesAgregados);
            }

            // Desactivar los menús que no se encontraron en las patentes del usuario
            DesactivarMenusNoEncontrados(menuStrip, menusPrincipalesAgregados);
        }


        //private List<Patente> ObtenerPatentesPorFamilia(Guid idFamilia)
        //{
        //    List<Patente> patentes = new List<Patente>();

        //    try
        //    {
        //        // Obtener las patentes asociadas a la familia actual
        //        PatenteFamilia patenteFamilia = PatenteFamiliaRepository.Instance.SelectOne(idFamilia);

        //        if (patenteFamilia != null)
        //        {
        //            // Obtener la patente correspondiente
        //            Patente patente = PatenteRepository.Instance.SelectOne(patenteFamilia.IdPatente);

        //            if (patente != null)
        //            {
        //                patentes.Add(patente);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones
        //        // Aquí puedes manejar la excepción de alguna manera apropiada para tu aplicación
        //    }

        //    return patentes;
        //}

        /// <summary>
        /// Obtiene las patentes asociadas a una familia.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <returns>Una lista de patentes asociadas a la familia.</returns>
        private List<Patente> ObtenerPatentesPorFamilia(Guid idFamilia)
        {
            List<Patente> patentes = new List<Patente>();

            try
            {
                // Obtener todas las patentes asociadas a la familia actual
                List<PatenteFamilia> patentesFamilia = PatenteFamiliaRepository.Instance.SelectOne(idFamilia);


                foreach (PatenteFamilia patenteFamilia in patentesFamilia)
                {
                    // Obtener la patente correspondiente
                    Patente patente = PatenteRepository.Instance.SelectOne(patenteFamilia.IdPatente);

                    if (patente != null)
                    {
                        patentes.Add(patente);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Aquí puedes manejar la excepción de alguna manera apropiada para tu aplicación
            }

            return patentes;
        }



        //private List<Patente> ObtenerPatentesPorFamilia(Guid idFamilia)
        //{
        //    // Obtener las patentes asociadas a la familia actual
        //    //PatenteFamilia patentesFamilia = PatenteFamiliaManager.Instance.ObtenerFamilia(idFamilia);
        //    PatenteFamilia patenteFamilia = PatenteFamiliaRepository.Instance.SelectOne(idFamilia);

        //    // Obtener las patentes correspondientes
        //    List<Patente> patentes = new List<Patente>();

        //    // Verificar si se encontró alguna patente asociada a la familia
        //    if (patenteFamilia != null)
        //    {
        //        // Obtener la patente correspondiente
        //        Patente patente = PatenteRepository.Instance.SelectOne(patenteFamilia.IdPatente);


        //        //// Obtener la lista de patentes correspondiente
        //        //List<Patente> patente = PatenteRepository.Instance.SelectOne(patenteFamilia.IdPatente);

        //        // Agregar la patente a la lista si se encontró
        //        if (patente != null)
        //        {
        //            patentes.Add(patente);
        //        }
        //    }

        //    return patentes;

        //}

        /// <summary>
        /// Configura los menús en función de las patentes del usuario.
        /// </summary>
        /// <param name="patentesUsuario">Lista de patentes del usuario.</param>
        /// <param name="menuStrip">MenuStrip en el que se configurarán los menús.</param>
        /// <param name="menusPrincipalesAgregados">Lista de menús principales ya agregados.</param>
        private void ConfigurarMenusPorPatentes(List<Patente> patentesUsuario, MenuStrip menuStrip, List<ToolStripMenuItem> menusPrincipalesAgregados)
        {
            // Iterar sobre las patentes del usuario y configurar los menús
            foreach (Patente patente in patentesUsuario)
            {
                ToolStripItem menuItem;

                // Verificar si el permiso es un menú principal
                if (string.IsNullOrEmpty(patente.PermisoPadreNombre))
                {
                    // Buscar el menú principal correspondiente
                    ToolStripMenuItem menuPrincipal = ObtenerMenuPrincipal(patente.NombrePermiso, menuStrip);

                    // Si se encontró el menú principal, configurarlo
                    if (menuPrincipal != null)
                    {
                        menuItem = menuPrincipal;
                        // Agregar el menú principal a la lista de menús principales ya agregados
                        menusPrincipalesAgregados.Add(menuPrincipal);
                    }
                    else
                    {
                        menuItem = new ToolStripMenuItem();
                        menuItem.Text = patente.NombrePermiso;
                        menuItem.Tag = "Menu"; // Etiqueta que indica que es un menú principal

                        // Añadir condiciones adicionales para agregar submenús específicos
                        if (EsSubMenuEspecifico(patente.NombrePermiso))
                        {
                            // Agregar el menú principal a la barra de menú
                            menuStrip.Items.Add(menuItem);
                            // Agregar el menú principal a la lista de menús principales ya agregados
                            menusPrincipalesAgregados.Add((ToolStripMenuItem)menuItem);
                        }
                    }
                }
                else
                {
                    // Es un submenú, buscar el menú principal correspondiente
                    ToolStripMenuItem menuPadre = ObtenerMenuPrincipal(patente.PermisoPadreNombre, menuStrip);

                    // Si se encontró el menú principal y no se ha agregado, configurar el submenú
                    if (menuPadre != null && !menusPrincipalesAgregados.Contains(menuPadre))
                    {
                        menuItem = new ToolStripMenuItem();
                        menuItem.Text = patente.NombrePermiso;
                        menuItem.Tag = "SubMenu"; // Etiqueta que indica que es un submenú

                        // Añadir condiciones adicionales para agregar submenús específicos
                        if (EsSubMenuEspecifico(patente.NombrePermiso))
                        {
                            // Agregar el submenú al menú principal
                            menuPadre.DropDownItems.Add(menuItem);
                        }
                    }
                    else
                    {
                        // Si no se encontró el menú principal o ya se agregó, no se puede agregar el submenú
                        continue;
                    }
                }

                // Configurar otras propiedades comunes
                menuItem.Name = patente.Vista;
                menuItem.Tag = patente.IdPatente;

                // Leer el campo Tag y ajustar la visibilidad en consecuencia
                if (menuItem.Tag != null && menuItem.Tag.ToString() == "SubMenu")
                {
                    // Es un submenú, forzar la visibilidad a true
                    menuItem.Visible = true;
                }
                else
                {
                    // Es un menú principal, ajustar la visibilidad según sea necesario
                    menuItem.Visible = patentesUsuario.Any(p => p.IdPatente == patente.IdPatente); // Solo visible si está en las patentes del usuario
                }
            }
        }


        //Método para obtener los permisos asociados a las familias del usuario

        //private List<Patente> ObtenerPermisosDeFamilias(List<Familia> familiasUsuario)
        //{
        //    List<Patente> patentesFamiliaUsuario = new List<Patente>();

        //    foreach (Familia familia in familiasUsuario)
        //    {
        //        //// Obtener las patentes asociadas a la familia actual
        //        //List<PatenteFamilia> patentesFamilia = PatenteFamiliaManager.Instance.ObtenerFamilia(familia.IdFamilia);

        //        //// Iterar sobre las patentes asociadas a la familia actual y agregarlas a la lista de patentes de la familia del usuario
        //        //foreach (PatenteFamilia patenteFamilia in patentesFamilia)
        //        //{
        //        //    // Obtener la información de la patente actual
        //        //    Patente patente = _patenteRepository.ObtenerPorId(patenteFamilia.IdPatente);

        //        //    // Agregar la patente a la lista de patentes de la familia del usuario si aún no está presente
        //        //    if (!patentesFamiliaUsuario.Contains(patente))
        //        //    {
        //        //        patentesFamiliaUsuario.Add(patente);
        //        //    }
        //        //}
        //    }

        //    return patentesFamiliaUsuario;
        //}




        /// <summary>
        /// Desactiva los menús y submenús que no se encontraron en las patentes del usuario.
        /// </summary>
        /// <param name="menuStrip">El <see cref="MenuStrip"/> que se está verificando.</param>
        /// <param name="menusPrincipalesAgregados">La lista de menús principales que fueron agregados.</param>
        private void DesactivarMenusNoEncontrados(MenuStrip menuStrip, List<ToolStripMenuItem> menusPrincipalesAgregados)
        {
            // Itera sobre los menús en la barra de menú y desactiva los que no se encontraron en las patentes
            foreach (ToolStripItem menuItem in menuStrip.Items)
            {
                if (menuItem is ToolStripMenuItem && !menusPrincipalesAgregados.Contains((ToolStripMenuItem)menuItem))
                {
                    // Verifica si el menú principal no está en la lista de menús principales agregados
                    if (!menusPrincipalesAgregados.Any(m => m.Name == menuItem.Name))
                    {
                        // El menú no se encontró, desactiva el menú y sus submenús recursivamente
                        DesactivarMenuYSubmenus((ToolStripMenuItem)menuItem);
                    }
                }
            }
        }

        /// <summary>
        /// Desactiva un menú y sus submenús recursivamente.
        /// </summary>
        /// <param name="menu">El menú que se va a desactivar.</param>
        private void DesactivarMenuYSubmenus(ToolStripMenuItem menu)
        {
            // Desactiva el menú y sus submenús recursivamente
            menu.Visible = false;

            foreach (ToolStripItem subMenuItem in menu.DropDownItems)
            {
                if (subMenuItem is ToolStripMenuItem)
                {
                    DesactivarMenuYSubmenus((ToolStripMenuItem)subMenuItem);
                }
            }
        }

        /// <summary>
        /// Obtiene las patentes asociadas al usuario actual.
        /// </summary>
        /// <returns>Una lista de objetos Patente que representan las patentes del usuario.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        private List<Patente> ObtenerPatentesPorUsuario()
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Obtiene todas las familias disponibles.
        /// </summary>
        /// <returns>Una lista de objetos Familia que representan todas las familias disponibles.</returns>
        private List<Familia> ObtenerTodasLasFamilias()
        {

            return _familiaRepository.ObtenerFamilias();
        }

        /// <summary>
        /// Desasigna una patente específica de un usuario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario del que se va a desasignar la patente.</param>
        /// <param name="idPatente">El ID de la patente que se va a desasignar.</param>
        /// <returns>True si la operación de desasignación fue exitosa; de lo contrario, False.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool DesasignarPatente(Guid idUsuario, Guid idPatente)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Asigna una patente específica a un usuario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario al que se va a asignar la patente.</param>
        /// <param name="idPatente">El ID de la patente que se va a asignar.</param>
        /// <returns>True si la operación de asignación fue exitosa; de lo contrario, False.</returns>
        public bool AsignarPatente(Guid idUsuario, Guid idPatente)
        {
            // Obtener el usuario y la patente correspondientes desde la base de datos
            Usuario usuario = _usuarioRepository.SelectOne(idUsuario);
            Patente patente = _patenteRepository.SelectOne(idPatente);

            if (usuario != null && patente != null)
            {
                // Verificar si el usuario ya tiene la patente asignada
                if (usuario.Patentes.Any(p => p.IdPatente == idPatente))
                {
                    return false; // El usuario ya tiene esta patente asignada
                }

                // Asignar la patente al usuario
                usuario.Patentes.Add(patente);
                _usuarioRepository.Update(usuario); // Supongamos que tienes un método para actualizar el usuario en la base de datos

                return true; // Asignación exitosa
            }

            return false; // No se pudo asignar la patente
        }

        /// <summary>
        /// Asigna una familia específica a un usuario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario al que se va a asignar la familia.</param>
        /// <param name="idFamilia">El ID de la familia que se va a asignar.</param>
        /// <returns>True si la operación de asignación fue exitosa; de lo contrario, False.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool AsignarFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">El nombre del usuario a seleccionar.</param>
        /// <returns>El objeto Usuario correspondiente al nombre especificado, o null si no se encuentra.</returns>
        public Usuario SeleccionarPorNombre(string nombre)
        {
            return _usuarioRepository.SelectOneByName(nombre);
        }

        /// <summary>
        /// Obtiene las patentes asociadas a un usuario mediante su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario del que se desean obtener las patentes.</param>
        /// <returns>Una lista de patentes asociadas al usuario.</returns>
        private List<Patente> ObtenerPatentesPorIdUsuario(Guid idUsuario)
        {
            return _usuarioRepository.ObtenerPatentesPorUsuario(idUsuario);
        }

        /// <summary>
        /// Agrega una familia a un usuario específico en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario al que se va a agregar la familia.</param>
        /// <param name="idFamilia">El ID de la familia que se va a agregar.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, False.</returns>
        public bool AgregarFamiliaAUsuario(Guid idUsuario, Guid idFamilia)
        {
            // Lógica para verificar permisos, etc., antes de unir usuario y familia
            // Unir usuario y familia en la base de datos
            return _familiaRepository.UnirUsuarioFamilia(idUsuario, idFamilia);
        }

        /// <summary>
        /// Une dos familias en la base de datos.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia principal.</param>
        /// <param name="idFamiliaHijo">El ID de la familia secundaria que se unirá a la principal.</param>
        /// <param name="fechaCreacion">La fecha de unión de las familias.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, False.</returns>
        public bool UnirFamilias(Guid idFamilia, Guid idFamiliaHijo, DateTime fechaCreacion)
        {
            try
            {
                // Lógica para verificar permisos, etc., antes de unir las familias
                // Unir las familias en la base de datos usando el repositorio genérico
                return _familiaRepository.UnirFamilias(idFamilia, idFamiliaHijo, fechaCreacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al unir familias: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Agrega una patente a una familia en la base de datos.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia a la que se va a agregar la patente.</param>
        /// <param name="idPatente">El ID de la patente que se va a agregar.</param>
        /// <param name="fechaCreacionFP">La fecha de creación de la relación entre la patente y la familia.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, False.</returns>
        public bool AgregarPatenteAFamilia(Guid idFamilia, Guid idPatente, DateTime fechaCreacionFP)
        {
            try
            {
                // Lógica para verificar permisos y otras condiciones antes de agregar la patente a la familia
                // Agregar la patente a la familia usando el repositorio de familias
                return _familiaRepository.AgregarFamiliaPatente(idFamilia, idPatente, fechaCreacionFP);

            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al agregar patente a la familia: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Une un usuario a una patente en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario al que se va a unir la patente.</param>
        /// <param name="idPatente">El ID de la patente que se va a unir al usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, False.</returns>
        /// <exception cref="NotImplementedException">Se lanza cuando el método no está implementado.</exception>
        public bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            // Lógica para unir un usuario a una patente
            // Implementa la lógica para unir la relación Usuario-Patente en la base de datos
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une un usuario a una familia en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario al que se va a unir la familia.</param>
        /// <param name="idFamilia">El ID de la familia que se va a unir al usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, False.</returns>
        /// <exception cref="NotImplementedException">Se lanza cuando el método no está implementado.</exception>
        public bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();
        }
    }
}
