using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Services.DAL.Contracts;
using Services.DomainModel;
using System.Windows.Forms;
using Services.DomainModel.CompositeSeguridad;
using DomainModel;
//using Log = Services.DomainModel.Log;
using Services.DAL.Implementations.File;

namespace Services.DAL.Implementations
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad Usuario.
    /// </summary>
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        private static UsuarioRepository _instance;
        private readonly ILogger logger;

        private UsuarioRepository() 
        {
            // Inicializa el logger en el constructor
            this.logger = new SqlLogger(); // Puedes ajustar esto según cómo esté implementada tu clase SqlLogger

        }

        /// <summary>
        /// 
        /// </summary>
        public static UsuarioRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioRepository();
                }
                return _instance;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public Usuario SelectOneByName(string name)
        //{

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("UsuarioSelectByName", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            // Agrega el parámetro del nombre de usuario al procedimiento almacenado
        //            command.Parameters.AddWithValue("@NombreUsuario", name);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    return new Usuario
        //                    {
        //                        IdUsuario = (Guid)reader["IdUsuario"],
        //                        UsuNom = reader["Usu_nom"].ToString(),
        //                        Contrasenia = reader["Contrasenia"].ToString(),
        //                        Nombre_Completo = reader["Nombre_Completo"].ToString(),
        //                        Email = reader["Email"].ToString(),
        //                        TipoDocumento = reader["TipoDocumento"].ToString(),
        //                        NroDocumento = reader["NroDocumento"].ToString(),
        //                        FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
        //                        Activo = reader["Activo"].ToString(),
        //                        EsAdmin = reader["EsAdmin"].ToString(),
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return null; // Usuario no encontrado
        //    //return usuario;
        //}

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="name">Nombre de usuario a buscar.</param>
        /// <returns>El usuario encontrado o null si no se encuentra.</returns>
        public Usuario SelectOneByName(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UsuarioSelectByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agrega el parámetro del nombre de usuario al procedimiento almacenado
                        command.Parameters.AddWithValue("@NombreUsuario", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                // Construye el objeto Usuario
                                Usuario usuario = new Usuario
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    UsuNom = reader["Usu_nom"].ToString(),
                                    Contrasenia = reader["Contrasenia"].ToString(),
                                    Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    TipoDocumento = reader["TipoDocumento"].ToString(),
                                    NroDocumento = reader["NroDocumento"].ToString(),
                                    FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
                                    Activo = reader["Activo"].ToString(),
                                    EsAdmin = reader["EsAdmin"].ToString(),
                                };

                                // Escribe en el registro que se ha encontrado el usuario
                                string logMessage = $"Usuario ingresó al sistema con el nombre '{name}' (ID: {usuario.IdUsuario}).";

                                DomainModel.Log logInfo = new DomainModel.Log
                                {
                                    IdLog = Guid.NewGuid(),
                                    Message = logMessage,
                                    Severity = Severity.Info,
                                    Fecha_txr = DateTime.Now
                                };
                                // Guardar el log de información utilizando el logger
                                logger.Store(logInfo);

                                // Devuelve el usuario encontrado
                                return usuario;

                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                string logErrorMessage = $"Error al obtener el usuario por nombre '{name}': {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error utilizando el logger
                logger.Store(logError);

                // Relanzar la excepción para que sea manejada por el código que llama a este método
                throw;
            }

            return null; // Usuario no encontrado
        }


        /// <summary>
        /// Agrega un nuevo usuario.
        /// </summary>
        /// <param name="obj">El usuario a agregar.</param>
        /// <returns>True si el usuario se agregó correctamente; de lo contrario, False.</returns>
        public bool Add(Usuario obj)
        {
            //throw new NotImplementedException();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    try
                    {
                        connection.Open();

                        // Crea un nuevo comando para ejecutar el procedimiento almacenado
                        using (SqlCommand cmd = new SqlCommand("UsuarioInsert", connection))
                        {
                        cmd.CommandType = CommandType.StoredProcedure;
                            DateTime currentTime = DateTime.Now;


                            // Configura los parámetros del procedimiento almacenado
                            cmd.Parameters.Add(new SqlParameter("@IdUsuario", Guid.NewGuid().ToString())); // Genera un nuevo IdUsuario
                            cmd.Parameters.Add(new SqlParameter("@Usu_nom", obj.UsuNom));
                            cmd.Parameters.Add(new SqlParameter("@Contrasenia", obj.Contrasenia));
                            cmd.Parameters.Add(new SqlParameter("@Nombre_Completo", obj.Nombre_Completo));
                            cmd.Parameters.Add(new SqlParameter("@Email", obj.Email));
                            cmd.Parameters.Add(new SqlParameter("@TipoDocumento", obj.TipoDocumento));
                            cmd.Parameters.Add(new SqlParameter("@NroDocumento", obj.NroDocumento));
                            cmd.Parameters.Add(new SqlParameter("@FechaCreacion_Usu", currentTime));
                            cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));
                            cmd.Parameters.Add(new SqlParameter("@EsAdmin", obj.Activo));    

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Usuario se guardó con éxito.");
                        // Escribe en el registro que se ha creado un nuevo usuario
                        string logMessage = $"Se creó un nuevo usuario con nombre '{obj.UsuNom}' y ID '{cmd.Parameters["@IdUsuario"].Value}'.";
                            DomainModel.Log logInfo = new DomainModel.Log
                            {
                                IdLog = Guid.NewGuid(),
                                Message = logMessage,
                                Severity = Severity.Info,
                                Fecha_txr = DateTime.Now
                            };
                        // Guarda el log de información utilizando el logger
                        logger.Store(logInfo);

                        return true;

                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error al guardar el usuario: " + ex.Message);
                        string logErrorMessage = $"Error al agregar el usuario: {ex.Message}";
                        DomainModel.Log logError = new DomainModel.Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logErrorMessage,
                            Severity = Severity.Error,
                            Fecha_txr = DateTime.Now
                        };

                        // Guardar el log de error utilizando el logger
                        logger.Store(logError);

                        // Relanzar la excepción para que sea manejada por el código que llama a este método
                        throw;

                        //return false;
                    }
                    finally
                    {
                        connection.Close();
                    }

            }

        }

        /// <summary>
        /// Elimina un usuario según su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario a eliminar.</param>
        /// <returns>True si el usuario se eliminó correctamente; de lo contrario, False.</returns>
        public bool Delete(Guid idUsuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UsuarioDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura el parámetro del procedimiento almacenado con el valor correcto
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));

                        // Ejecuta el procedimiento almacenado
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= -1)
                        {
                            MessageBox.Show("Usuario borrado con éxito.");
                            //MessageBox.Show("No se encontró ningún usuario con el Id especificado.");
                            return true;
                        }
                        else
                        {
                            //Revisar porque viene por acá cuando borra
                            MessageBox.Show("No se encontró ningún usuario con el Id especificado.");
                            //MessageBox.Show("Usuario borrado con éxito.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string logErrorMessage = $"Error al intentar eliminar el usuario: {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error utilizando el logger
                logger.Store(logError);

                // Relanzar la excepción para que sea manejada por el código que llama a este método
                throw;
            }
        }


        /// <summary>
        /// Actualiza la información de un usuario.
        /// </summary>
        /// <param name="obj">El objeto Usuario con la información actualizada.</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario, False.</returns>
        public bool Update(Usuario obj)
        {
            //throw new NotImplementedException();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("UsuarioUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DateTime currentTime = DateTime.Now;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario",obj.IdUsuario)); //Le paso la id que seleccione  
                        cmd.Parameters.Add(new SqlParameter("@Usu_nom", obj.UsuNom));
                        cmd.Parameters.Add(new SqlParameter("@Contrasenia", obj.Contrasenia));
                        cmd.Parameters.Add(new SqlParameter("@Nombre_Completo", obj.Nombre_Completo));
                        cmd.Parameters.Add(new SqlParameter("@Email", obj.Email));
                        cmd.Parameters.Add(new SqlParameter("@TipoDocumento", obj.TipoDocumento));
                        cmd.Parameters.Add(new SqlParameter("@NroDocumento", obj.NroDocumento));
                        cmd.Parameters.Add(new SqlParameter("@FechaCreacion_Usu", currentTime));
                        cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));
                        cmd.Parameters.Add(new SqlParameter("@EsAdmin", obj.EsAdmin));

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        // Escribe en el registro que se ha modificado el usuario
                        string logMessage = $"Usuario modificado con éxito (ID: {obj.IdUsuario}).";
                        DomainModel.Log logInfo = new DomainModel.Log
                        {
                            IdLog = Guid.NewGuid(),
                            Message = logMessage,
                            Severity = Severity.Info,
                            Fecha_txr = DateTime.Now
                        };
                        // Guardar el log de información utilizando el logger
                        logger.Store(logInfo);

                        // Se cerrará la conexión automáticamente en el bloque using

                        MessageBox.Show("Usuario modificado con éxito.");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    string logErrorMessage = $"Error al modificar el usuario: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    // Relanzar la excepción para que sea manejada por el código que llama a este método
                    throw;
                }
                finally
                {
                    
                }

            }
        }

        /// <summary>
        /// Obtiene todos los usuarios almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que representan a todos los usuarios almacenados.</returns>
        public IEnumerable<Usuario> SelectAll()
        {
            //throw new NotImplementedException();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Me creo un lista
                List<Usuario> usuarios = new List<Usuario>();
                try
                {
                    connection.Open();

                    // Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("UsuarioSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                              while (reader.Read())
                              {
                                   Usuario usuario = new Usuario
                                   {
                                       IdUsuario = (Guid)reader["IdUsuario"],
                                       UsuNom = reader["Usu_nom"].ToString(),
                                       Contrasenia = reader["Contrasenia"].ToString(),
                                       Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                       Email = reader["Email"].ToString(),
                                       TipoDocumento = reader["TipoDocumento"].ToString(),
                                       NroDocumento = reader["NroDocumento"].ToString(),
                                       FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
                                       Activo = reader["Activo"].ToString(),
                                       EsAdmin = reader["EsAdmin"].ToString()

                                   };
                                   usuarios.Add(usuario);
                              }

                        }

                    }
                    
                }
                catch (Exception ex) 
                {
                    string logErrorMessage = $"Error al obtener la lista de usuarios: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    // Relanzar la excepción para que sea manejada por el código que llama a este método
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                return usuarios;

            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar.</param>
        /// <returns>El usuario encontrado o null si no se encuentra.</returns>
        public Usuario SelectOne(Guid idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    UsuNom = reader["Usu_nom"].ToString(),
                                    Contrasenia = reader["Contrasenia"].ToString(),
                                    Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    TipoDocumento = reader["TipoDocumento"].ToString(),
                                    NroDocumento = reader["NroDocumento"].ToString(),
                                    FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
                                    Activo = reader["Activo"].ToString(),
                                    EsAdmin = reader["EsAdmin"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, registrarla o lanzarla nuevamente si es necesario.
                    string logErrorMessage = $"Error al obtener el usuario con ID {idUsuario}: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);
                }

                return null; // Usuario no encontrado
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Usuario> Usuario() 
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UsuarioSelectAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    UsuNom = reader["Usu_nom"].ToString(),
                                    Contrasenia = reader["Contrasenia"].ToString(),
                                    Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    TipoDocumento = reader["TipoDocumento"].ToString(),
                                    NroDocumento = reader["NroDocumento"].ToString(),
                                    FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
                                    Activo = reader["Activo"].ToString(),
                                    EsAdmin = reader["EsAdmin"].ToString()
                                };
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, si es necesario.
                MessageBox.Show("Error al obtener la lista de usuarios: " + ex.Message);
                
            }

            return usuarios;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario para iniciar sesión.
        /// </summary>
        /// <param name="name">Nombre de usuario.</param>
        /// <returns>El usuario encontrado o null si no se encuentra.</returns>
        public Usuario SelectOneSesion(string name)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UsuarioSesion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agrega el parámetro del nombre de usuario al procedimiento almacenado
                        command.Parameters.AddWithValue("@NombreUsuario", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    UsuNom = reader["Usu_nom"].ToString(),
                                    Contrasenia = reader["Contrasenia"].ToString(),
                                    Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    TipoDocumento = reader["TipoDocumento"].ToString(),
                                    NroDocumento = reader["NroDocumento"].ToString(),
                                    FechaCreacion_Usu = (DateTime)reader["FechaCreacion_Usu"],
                                    Activo = reader["Activo"].ToString(),
                                    EsAdmin = reader["EsAdmin"].ToString()
                                };
                            }
                        }
                    }

                    // Si no se encontró un usuario, puedes devolver null o lanzar una excepción,
                    // según tus necesidades.
                    return null;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, registrarla o lanzarla nuevamente si es necesario.
                    //throw ex;
                    string logErrorMessage = $"Error al obtener el usuario para iniciar sesión con nombre {name}: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    // Relanzar la excepción para que sea manejada por el código que llama a este método
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario por su ID.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de familias asociadas al usuario.</returns>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            List<Familia> familias = new List<Familia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UsuarioFamiliaSelectByIdUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdUsuario", usuarioId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Familia familia = new Familia
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    IdFamilia = (Guid)reader["IdFamilia"],
                                    FechaCreacionUF = (DateTime)reader["FechaCreacionUF"],
                                    Usu_nom = reader["Usu_nom"].ToString(),
                                    NombreRol = reader["NombreRol"].ToString()
                                };

                                familias.Add(familia);
                            }
                        }
                    }

                    return familias;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, registrarla o lanzarla nuevamente si es necesario.
                    string logErrorMessage = $"Error al obtener las familias por usuario con ID {usuarioId}: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    // Relanzar la excepción para que sea manejada por el código que llama a este método
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        public bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                        cmd.Parameters.Add(new SqlParameter("@IdPatente", idPatente));
                        cmd.Parameters.Add(new SqlParameter("@FechaCreacion", DateTime.Now));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string logErrorMessage = $"Error al unir usuario {idUsuario} y patente {idPatente}: {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error utilizando el logger
                logger.Store(logError);

                return false;
            }

        }


        /// <summary>
        /// Verifica si existe un usuario con un rol específico.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <param name="nombreRol">Nombre del rol.</param>
        /// <returns>True si el usuario con el rol existe, False si no.</returns>
        public bool ExisteUsuarioRol(string nombreUsuario, string nombreRol)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ExisteUsuarioRol", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@Usu_Nom", nombreUsuario));
                        cmd.Parameters.Add(new SqlParameter("@NombreRol", nombreRol));

                        // Ejecuta el procedimiento almacenado para verificar si existe el usuario con el rol
                        object result = cmd.ExecuteScalar();

                        // Si el resultado es 1, significa que existe el usuario con el rol, de lo contrario, no existe
                        //return result != null && Convert.ToInt32(result) == 1;

                        //// Si el resultado es 0 o NULL, significa que existe el usuario con el rol, de lo contrario, no existe
                        return result == null || Convert.ToInt32(result) == 0;

                    }
                }
                catch (Exception ex)
                {
                    // Registrar el error en el archivo de registro
                    string logErrorMessage = $"Error al verificar la existencia del usuario con el rol: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePermiso"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ExistePermiso(string nombrePermiso)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Contracts.UsuarioPatente> ListarUsuarioPermisos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="idPatente"></param>
        /// <param name="fechaCreacionFP"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AgregarFamiliaPatente(Guid idFamilia, Guid idPatente, DateTime fechaCreacionFP)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patenteId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Patente SelectOne(Patente patenteId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Usuario ObtenerPorId(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ExisteRol(string nombreRol)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idFamilia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="idFamiliaHijo"></param>
        /// <param name="fechaCreacion"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UnirFamilias(Guid idFamilia, Guid idFamiliaHijo, DateTime fechaCreacion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Patente> ObtenerPatentes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Familia> ObtenerFamilias()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool BorrarUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        public List<PatenteFamilia> ListarRolesPermisos()
        {
            throw new NotImplementedException();
        }

        public void UnirFamiliaPatente(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        public bool UnirFamiliaPatente(PatenteFamilia patenteFamilia)
        {
            throw new NotImplementedException();
        }

        public bool FamiliaPatenteUnir(Guid idFamilia, PatenteFamilia patenteFamilia)
        {
            throw new NotImplementedException();
        }

        public bool FamiliaPatenteUnir(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        public List<Familia> ListarPatenteFamilia()
        {
            throw new NotImplementedException();
        }
    }

}
