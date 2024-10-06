using Services.DAL.Contracts;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UsuarioPatente = Services.DAL.Contracts.UsuarioPatente;
using DomainModel;
using Services.DAL.Implementations.File;

namespace Services.DAL.Implementations
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad UsuarioPatente.
    /// </summary>
    public class UsuarioPatenteRepository : IGenericRepository<UsuarioPatente>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        private static UsuarioPatenteRepository _instance;
        private readonly ILogger logger;

        private UsuarioPatenteRepository()
        {
            // Inicializa el logger en el constructor
            this.logger = new SqlLogger(); // Puedes ajustar esto según cómo esté implementada tu clase SqlLogger
        }

        /// <summary>
        /// 
        /// </summary>
        public static UsuarioPatenteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioPatenteRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de objetos Familia asociados al usuario.</returns>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            List<Familia> familias = new List<Familia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UsuarioFamiliaDeleteByIdUsuario", connection))
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
                                    IdPatente = (Guid)reader["IdPatente"],
                                    FechaCreacion = (DateTime)reader["FechaCreacion"]
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
                    string logErrorMessage = $"Error al obtener familias por usuario con ID {usuarioId}: {ex.Message}";
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
        /// Une un usuario a una patente en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la operación se realiza con éxito, False si ocurre algún error.</returns>
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
                    // Maneja la excepción según tus necesidades
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al unir usuario {idUsuario} y patente {idPatente}: {ex.Message}";
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
        /// Obtiene todas las asignaciones de usuarios a patentes de la base de datos y registra errores en el registro de errores.
        /// </summary>
        /// <returns>Una colección de todas las asignaciones de usuarios a patentes.</returns>
        public IEnumerable<UsuarioPatente> SelectAll()
        {
            List<Contracts.UsuarioPatente> usuarioPatentes = new List<UsuarioPatente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteSelectALL", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UsuarioPatente usuarioPatente = new UsuarioPatente
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    IdPatente = (Guid)reader["IdPatente"],
                                    FechaCreacion = (DateTime)reader["FechaCreacion"],
                                    NombrePermiso = reader["NombrePermiso"].ToString(),
                                    Vista = reader["Vista"].ToString(),
                                    Usu_nom = reader["Usu_nom"].ToString(),
                                    Nombre_Completo = reader["Nombre_Completo"].ToString()
                                    // Ajusta las propiedades según la estructura de tu tabla y clase
                                };

                                usuarioPatentes.Add(usuarioPatente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registra el error en el registro de errores
                string logErrorMessage = $"Error al obtener todas las asignaciones de usuarios a patentes: {ex.Message}";
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

            return usuarioPatentes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public Patente SelectOne(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public Patente SelectOne(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioPatenteSelectByIdUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Construye un objeto Patente con los datos obtenidos de la base de datos
                                Patente patente = new Patente
                                {
                                    IdPatente = reader.GetGuid(reader.GetOrdinal("IdPatente")),
                                    FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion"))
                                    // Asegúrate de mapear todos los campos necesarios de acuerdo a tu clase Patente
                                };
                                return patente;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Aquí puedes manejar la excepción de alguna manera apropiada para tu aplicación
            }

            return null; // Si no se encuentra la patente con el ID especificado
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(Patente obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(Patente obj)
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
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
        /// <param name="usuNom"></param>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ExisteUsuarioRol(string usuNom, string nombreRol)
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
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Patente> ObtenerPatentes()
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
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Patente SelectOneByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Patente SelectOneSesion(string name)
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
        /// <param name="idUsuario"></param>
        /// <param name="idFamilia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todas las patentes asignadas a un usuario específico de la base de datos.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario del que se desean obtener las patentes.</param>
        /// <returns>Una lista de patentes asignadas al usuario.</returns>
        public List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId)
        {
            

            List<Patente> patentesAsignadas = new List<Patente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ObtenerPermisosDelUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);

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
                                patentesAsignadas.Add(patente);
                            }
                        }
                    }
                }

                return patentesAsignadas;
            }
            catch (Exception ex)
            {
                // Registra el error en el registro de errores
                string logErrorMessage = $"Error al obtener patentes del usuario con ID {usuarioId}: {ex.Message}";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(UsuarioPatente obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(UsuarioPatente obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        UsuarioPatente IGenericRepository<UsuarioPatente>.SelectOne(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        UsuarioPatente IGenericRepository<UsuarioPatente>.SelectOneByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        UsuarioPatente IGenericRepository<UsuarioPatente>.SelectOneSesion(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<UsuarioPatente> ListarUsuarioPermisos()
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
