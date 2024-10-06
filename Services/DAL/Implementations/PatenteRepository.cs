using DomainModel;
using Services.DAL.Contracts;
using Services.DAL.Implementations.File;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.DAL.Implementations
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad Patente.
    /// </summary>
    public class PatenteRepository : IGenericRepository<Patente>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        private static PatenteRepository _instance;
        private readonly ILogger logger;

        /// <summary>
        /// Representa un repositorio para operaciones relacionadas con patentes.
        /// </summary>
        private PatenteRepository()
        {
            // Inicializa el logger en el constructor
            this.logger = new SqlLogger(); // Puedes ajustar esto según cómo esté implementada tu clase SqlLogger
        }

        /// <summary>
        /// Obtiene una instancia única de la clase PatenteRepository utilizando el patrón Singleton.
        /// </summary>
        public static PatenteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PatenteRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Agrega una nueva patente a la base de datos.
        /// </summary>
        /// <param name="obj">La patente a agregar.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, false.</returns>
        public bool Add(Patente obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PatenteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DateTime currentTime = DateTime.Now;

                        cmd.Parameters.Add(new SqlParameter("@IdPatente", Guid.NewGuid().ToString()));
                        //cmd.Parameters.Add(new SqlParameter("@IdPatente", obj.IdPatente));
                        cmd.Parameters.Add(new SqlParameter("@NombrePermiso", obj.NombrePermiso));
                        cmd.Parameters.Add(new SqlParameter("@Vista", obj.Vista));
                        cmd.Parameters.Add(new SqlParameter("@Fecha_Patente", currentTime));

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }

                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al insertar la patente en la base de datos: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
                    logger.Store(logError);

                    //Console.WriteLine("Error al insertar la patente: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina una patente de la base de datos.
        /// </summary>
        /// <param name="id">El ID de la patente a eliminar.</param>
        /// <returns>True si la operación se realiza con éxito, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza una patente en la base de datos.
        /// </summary>
        /// <param name="obj">La patente a actualizar.</param>
        /// <returns>True si la operación se realiza con éxito, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool Update(Patente obj)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Obtiene todas las familias de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Familia que representan todas las familias almacenadas en la base de datos.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public List<Familia> ObtenerFamilias()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todas las relaciones entre patentes y familias de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos PatenteFamilia que representan todas las relaciones entre patentes y familias almacenadas en la base de datos.</returns>
        public List<PatenteFamilia> ListarPatenteFamilia()
        {
            List<PatenteFamilia> patenteFamilias = new List<PatenteFamilia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("FamiliaPatenteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PatenteFamilia patenteFamilia = new PatenteFamilia
                                {
                                    IdFamilia = (Guid)reader["IdFamilia"],
                                    IdPatente = (Guid)reader["IdPatente"],
                                    FechaCreacionFP = (DateTime)reader["Fecha_Patente"]
                                };

                                patenteFamilias.Add(patenteFamilia);
                            }
                        }
                    }

                    return patenteFamilias;
                }
                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al obtener las patentes: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
                    logger.Store(logError);
                    throw; // Relanzar la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }

        /// <summary>
        /// Obtiene todas las patentes de la base de datos.
        /// </summary>
        /// <returns>Una lista de todas las patentes.</returns>
        public List<Patente> ObtenerPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PatenteSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patente patente = new Patente
                                {
                                    IdPatente = (Guid)reader["IdPatente"],
                                    NombrePermiso = (string)reader["NombrePermiso"],
                                    Vista = (string)reader["Vista"],
                                    Fecha_Patente = (DateTime)reader["Fecha_Patente"]
                                };

                                patentes.Add(patente);
                            }
                        }
                    }

                    return patentes;
                }
                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al obtener las patentes: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
                    logger.Store(logError);
                    throw; // Relanzar la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }

        /// <summary>
        /// Obtiene todas las patentes de la base de datos.
        /// </summary>
        /// <returns>Una enumeración de todas las patentes.</returns>
        public IEnumerable<Patente> SelectAll()
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PatenteSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patente patente = new Patente
                                {
                                    IdPatente = (Guid)reader["IdPatente"],
                                    NombrePermiso = (string)reader["NombrePermiso"],
                                    Vista = (string)reader["Vista"],
                                    Fecha_Patente = (DateTime)reader["Fecha_Patente"]
                                };

                                patentes.Add(patente);
                            }
                        }
                    }

                    return patentes;
                }
                catch (Exception ex)
                {
                    string logErrorMessage = $"Error al obtener todas las patentes: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
                    logger.Store(logError);
                    throw; // Relanzar la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }

        /// <summary>
        /// Obtiene una patente por su identificador único.
        /// </summary>
        /// <param name="idPatente">El identificador único de la patente.</param>
        /// <returns>La patente correspondiente al identificador especificado.</returns>
        public Patente SelectOne(Guid idPatente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("PatenteSelect", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agrega el parámetro del identificador de patente al procedimiento almacenado
                        command.Parameters.AddWithValue("@IdPatente", idPatente);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Crea un objeto Patente con los datos del resultado
                                Patente patente = new Patente
                                {
                                    IdPatente = (Guid)reader["IdPatente"],
                                    NombrePermiso = reader["NombrePermiso"].ToString(),
                                    Vista = reader["Vista"].ToString(),
                                    Fecha_Patente = (DateTime)reader["Fecha_Patente"]
                                };

                                return patente;
                            }
                        }
                    }

                    // Si no se encuentra una patente con el ID especificado, devuelve null o lanza una excepción según tus necesidades.
                    return null;
                }
                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al obtener la patente con ID {idPatente}: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
                    logger.Store(logError);
                    throw;
                }
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="nombrePermiso"></param>
        ///// <returns></returns>
        //public bool ExistePermiso(string nombrePermiso)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("BuscarPermisoPorNombre", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                return reader.HasRows;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Verifica si un permiso existe en la base de datos.
        /// </summary>
        /// <param name="nombrePermiso">El nombre del permiso a verificar.</param>
        /// <returns>True si el permiso existe, False en caso contrario.</returns>
        public bool ExistePermiso(string nombrePermiso)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("BuscarPermisoPorNombre", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registra el error en el registro de errores
                string logErrorMessage = $"Error al verificar la existencia del permiso {nombrePermiso}: {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guarda el log de error utilizando el logger
                logger.Store(logError);

                // Manejar la excepción o relanzarla según sea necesario
                throw;
            }
        }


        /// <summary>
        /// Une un usuario a una patente en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la unión se realizó con éxito, False en caso contrario.</returns>
        public bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DateTime currentTime = DateTime.Now;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                        cmd.Parameters.Add(new SqlParameter("@IdPatente", idPatente));
                        cmd.Parameters.Add(new SqlParameter("@FechaCreacion", currentTime));

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al unir el usuario {idUsuario} y la patente {idPatente}: {ex.Message}";
                    DomainModel.Log logError = new DomainModel.Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guarda el log de error utilizando el logger
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
        /// Une un usuario a una familia en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario que se va a unir a la familia.</param>
        /// <param name="idFamilia">El ID de la familia a la que se va a unir el usuario.</param>
        /// <returns>True si la unión se realiza con éxito; de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona una patente por su nombre de la base de datos.
        /// </summary>
        /// <param name="name">El nombre de la patente que se va a seleccionar.</param>
        /// <returns>La patente seleccionada con el nombre especificado.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public Patente SelectOneByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona una patente de sesión por su nombre de la base de datos.
        /// </summary>
        /// <param name="name">El nombre de la patente de sesión que se va a seleccionar.</param>
        /// <returns>La patente de sesión seleccionada con el nombre especificado.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public Patente SelectOneSesion(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une dos familias en la base de datos.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia principal.</param>
        /// <param name="idFamiliaHijo">El ID de la familia secundaria que se va a unir a la principal.</param>
        /// <param name="fechaCreacion">La fecha de creación de la unión entre las familias.</param>
        /// <returns>True si la unión de las familias se realiza con éxito; de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool UnirFamilias(Guid idFamilia, Guid idFamiliaHijo, DateTime fechaCreacion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Agrega una patente a una familia en la base de datos.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia a la que se va a agregar la patente.</param>
        /// <param name="idPatente">El ID de la patente que se va a agregar a la familia.</param>
        /// <param name="fechaCreacionFP">La fecha de creación de la relación entre la patente y la familia.</param>
        /// <returns>True si la patente se agrega a la familia con éxito; de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool AgregarFamiliaPatente(Guid idFamilia, Guid idPatente, DateTime fechaCreacionFP)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona una patente por su ID de la base de datos.
        /// </summary>
        /// <param name="patenteId">El objeto de la patente que se va a seleccionar.</param>
        /// <returns>La patente seleccionada con el ID especificado.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public Patente SelectOne(Patente patenteId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un usuario por su ID de la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario que se va a obtener.</param>
        /// <returns>El usuario con el ID especificado.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public Usuario ObtenerPorId(Guid idUsuario)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Verifica si existe un rol en la base de datos.
        /// </summary>
        /// <param name="nombreRol">El nombre del rol que se va a verificar.</param>
        /// <returns>True si el rol existe en la base de datos; de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool ExisteRol(string nombreRol)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si un usuario tiene un rol específico en la base de datos.
        /// </summary>
        /// <param name="usuNom">El nombre de usuario que se va a verificar.</param>
        /// <param name="nombreRol">El nombre del rol que se va a verificar.</param>
        /// <returns>True si el usuario tiene el rol especificado; de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool ExisteUsuarioRol(string usuNom, string nombreRol)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario por su ID de la base de datos.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario del cual se obtendrán las familias.</param>
        /// <returns>Una lista de familias asociadas al usuario.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// Obtiene las patentes asociadas a un usuario desde la base de datos.
        ///// </summary>
        ///// <param name="usuarioId">El ID del usuario.</param>
        ///// <returns>Una lista de patentes asociadas al usuario.</returns>
        ////public List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId)
        ////{
        ////    List<Patente> patentes = new List<Patente>();

        ////    using (SqlConnection connection = new SqlConnection(connectionString))
        ////    {
        ////        connection.Open();

        ////        using (SqlCommand cmd = new SqlCommand("UsuarioPatenteSelectByIdUsuario", connection))
        ////        {
        ////            cmd.CommandType = CommandType.StoredProcedure;
        ////            cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);

        ////            using (SqlDataReader reader = cmd.ExecuteReader())
        ////            {
        ////                while (reader.Read())
        ////                {
        ////                    Patente patente = new Patente
        ////                    {
        ////                        IdUsuario = (Guid)reader["IdUsuario"],
        ////                        IdPatente = (Guid)reader["IdPatente"],
        ////                        FechaCreacion = (DateTime)reader["FechaCreacion"],
        ////                    };
        ////                    patentes.Add(patente);
        ////                }
        ////            }
        ////        }
        ////    }

        ////    return patentes;
        ////}

        /// <summary>
        /// Obtiene las patentes asociadas a un usuario desde la base de datos.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de patentes asociadas al usuario.</returns>
        public List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId)
        {
            List<Patente> patentes = new List<Patente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteSelectByIdUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patente patente = new Patente
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    IdPatente = (Guid)reader["IdPatente"],
                                    FechaCreacion = (DateTime)reader["FechaCreacion"],
                                };
                                patentes.Add(patente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registra el error en el registro de errores
                string logErrorMessage = $"Error al obtener las patentes del usuario con ID {usuarioId}: {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guarda el log de error utilizando el logger
                logger.Store(logError);

            }

            return patentes;
        }


        /// <summary>
        /// Obtiene una lista de los permisos de usuario disponibles en el sistema.
        /// </summary>
        /// <returns>Una lista de permisos de usuario.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public List<Contracts.UsuarioPatente> ListarUsuarioPermisos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Borra la asociación entre un usuario y una patente en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la operación se realiza con éxito, de lo contrario, false.</returns>
        public bool BorrarUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteDeleteByIdUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                        cmd.Parameters.Add(new SqlParameter("@IdPatente", idPatente));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= -1)
                        {
                            MessageBox.Show("Rol de usuario eliminada con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna patente con el ID de usuario y patente especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción mostrando un mensaje de error y registrándola en el log
                string logErrorMessage = $"Error al intentar eliminar la patente para el usuario con ID {idUsuario}: {ex.Message}";
                DomainModel.Log logError = new DomainModel.Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guarda el log de error utilizando el logger
                logger.Store(logError);
                return false;
            }
        }


        /// <summary>
        /// Une una patente a una familia especificada.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public void UnirFamiliaPatente(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une una patente a una familia especificada.
        /// </summary>
        /// <param name="patenteFamilia">La relación entre la familia y la patente.</param>
        /// <returns>True si la operación se realizó con éxito, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool UnirFamiliaPatente(PatenteFamilia patenteFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une una patente a una familia especificada.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <param name="patenteFamilia">La relación entre la familia y la patente.</param>
        /// <returns>True si la operación se realizó con éxito, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool FamiliaPatenteUnir(Guid idFamilia, PatenteFamilia patenteFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une una patente a una familia especificada.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la operación se realizó con éxito, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public bool FamiliaPatenteUnir(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de las relaciones entre roles y permisos.
        /// </summary>
        /// <returns>Una lista de relaciones entre roles y permisos.</returns>
        /// <exception cref="NotImplementedException">Excepción que se produce cuando el método no está implementado.</exception>
        public List<PatenteFamilia> ListarRolesPermisos()
        {
            throw new NotImplementedException();
        }

        //List<Familia> IGenericRepository<Patente>.ListarPatenteFamilia()
        //{
        //    throw new NotImplementedException();
        //}
    }


}
