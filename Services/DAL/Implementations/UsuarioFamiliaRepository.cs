using Services.DAL.Contracts;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Services.DAL.Implementations.File;

namespace Services.DAL.Implementations
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad UsuarioFamilia.
    /// </summary>
    public class UsuarioFamiliaRepository : IGenericRepository<UsuarioFamiliaRepository>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        private static UsuarioFamiliaRepository _instance;
        private readonly ILogger logger;

        public Guid IdUsuario { get; private set; }
        public Guid IdFamilia { get; private set; }
        public DateTime FechaCreacionUF { get; private set; }
        public string Usu_nom { get; private set; }
        public string NombreRol { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private UsuarioFamiliaRepository() 
        {
            // Inicializa el logger en el constructor
            this.logger = new SqlLogger(); // Puedes ajustar esto según cómo esté implementada tu clase SqlLogger
        }

        /// <summary>
        /// 
        /// </summary>
        public static UsuarioFamiliaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioFamiliaRepository();
                }
                return _instance;
            }
        }



        /// <summary>
        /// Obtiene todos los registros de la tabla UsuarioFamilia utilizando el procedimiento almacenado UsuarioFamiliaSelect.
        /// </summary>
        /// <returns>Una colección de objetos UsuarioFamiliaRepository.</returns>
        public IEnumerable<UsuarioFamiliaRepository> SelectAll()
        {
            List<UsuarioFamiliaRepository> usuariosFamilias = new List<UsuarioFamiliaRepository>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UsuarioFamiliaSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UsuarioFamiliaRepository usuarioFamilia = new UsuarioFamiliaRepository
                                {
                                    IdUsuario = (Guid)reader["IdUsuario"],
                                    IdFamilia = (Guid)reader["IdFamilia"],
                                    FechaCreacionUF = (DateTime)reader["FechaCreacionUF"],
                                    Usu_nom = reader["Usu_nom"].ToString(),
                                    NombreRol = reader["NombreRol"].ToString()
                                };

                                usuariosFamilias.Add(usuarioFamilia);
                            }
                        }
                    }

                    return usuariosFamilias;
                }
                catch (Exception ex)
                {
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al obtener los usuarios/familias: {ex.Message}";
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
        /// Agrega un nuevo registro de asociación entre un usuario y una familia en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <param name="usuNom">El nombre de usuario.</param>
        /// <param name="nombreRol">El nombre del rol.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, false.</returns>
        public bool Add(Guid idUsuario, Guid idFamilia, string usuNom, string nombreRol)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("UsuarioFamiliaInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                        cmd.Parameters.Add(new SqlParameter("@IdFamilia", idFamilia));
                        cmd.Parameters.Add(new SqlParameter("@FechaCreacionUF", DateTime.Now)); // Si deseas usar la fecha actual
                        cmd.Parameters.Add(new SqlParameter("@Usu_nom", usuNom));
                        cmd.Parameters.Add(new SqlParameter("@NombreRol", nombreRol));

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        // Registra el en el log
                        string logMessage = $"El rol al usuario {idUsuario} y la familia {idFamilia}";
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
                    // Registra el error en el registro de errores
                    string logErrorMessage = $"Error al insertar en la base de datos la asociación entre el usuario {idUsuario} y la familia {idFamilia}: {ex.Message}";
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
        }

        /// <summary>
        /// Elimina un registro de la tabla UsuarioFamilia mediante el ID del usuario utilizando el procedimiento almacenado UsuarioFamiliaDeleteByIdUsuario.
        /// </summary>
        /// <param name="id">El ID del usuario cuyo rol se eliminará.</param>
        /// <returns>True si se elimina correctamente, de lo contrario, false.</returns>
        public bool Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("UsuarioFamiliaDeleteByIdUsuario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agrega el parámetro del ID del usuario al comando
                        cmd.Parameters.AddWithValue("@IdUsuario", id);

                        // Ejecuta el comando para borrar el rol del usuario
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Si se afectó al menos una fila, devuelve true, de lo contrario, false
                        return rowsAffected >= -1;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    string logErrorMessage = $"Error al eliminar el rol del usuario: {ex.Message}";
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
        }


        //public UsuarioFamiliaRepository SelectOne(Guid id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlCommand cmd = new SqlCommand("UsuarioFamiliaSelectByIdUsuario", connection))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add(new SqlParameter("@IdUsuario", id));

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        UsuarioFamiliaRepository usuarioFamilia = new UsuarioFamiliaRepository
        //                        {
        //                            IdUsuario = (Guid)reader["IdUsuario"],
        //                            IdFamilia = (Guid)reader["IdFamilia"],
        //                            FechaCreacionUF = (DateTime)reader["FechaCreacionUF"],
        //                            UsuNom = reader["Usu_nom"].ToString(),
        //                            NombreRol = reader["NombreRol"].ToString()
        //                        };

        //                        return usuarioFamilia;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error al obtener el usuario y familia: " + ex.Message);
        //            // Manejar la excepción según tus necesidades.
        //            throw;
        //        }
        //    }

        //    // Si no se encuentra ninguna coincidencia, devuelve null
        //    return null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(UsuarioFamiliaRepository obj)
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
        /// <param name="idUsuario"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool BorrarUsuarioPatente(Guid idUsuario, Guid idPatente)
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
        /// <param name="nombreUsuario"></param>
        /// <param name="nombreFamilia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ExisteUsuarioRol(string nombreUsuario, string nombreFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="patenteFamilia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool FamiliaPatenteUnir(Guid idFamilia, PatenteFamilia patenteFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool FamiliaPatenteUnir(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Familia> ListarPatenteFamilia()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<PatenteFamilia> ListarRolesPermisos()
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
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Familia> ObtenerFamilias()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UsuarioFamiliaRepository SelectOne(Guid id)
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
        public UsuarioFamiliaRepository SelectOneByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UsuarioFamiliaRepository SelectOneSesion(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="idPatente"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UnirFamiliaPatente(Guid idFamilia, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patenteFamilia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UnirFamiliaPatente(PatenteFamilia patenteFamilia)
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
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idPatente"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(UsuarioFamiliaRepository obj)
        {
            throw new NotImplementedException();
        }
    }
}
