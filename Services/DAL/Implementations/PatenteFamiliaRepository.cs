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
    ///  Repositorio para operaciones relacionadas con la entidad PatenteFamilia.
    /// </summary>
    public class PatenteFamiliaRepository : IGenericRepository<PatenteFamilia>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        private static PatenteFamiliaRepository _instance;
        private readonly ILogger logger;

        public PatenteFamiliaRepository()
        {
            // Inicializa el logger en el constructor
            this.logger = new SqlLogger(); // Puedes ajustar esto según cómo esté implementada tu clase SqlLogger
        }

        /// <summary>
        /// 
        /// </summary>
        public static PatenteFamiliaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PatenteFamiliaRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene todas las relaciones de Patente-Familia de la base de datos.
        /// </summary>
        /// <returns>Una colección de todas las relaciones de Patente-Familia.</returns>
        public IEnumerable<PatenteFamilia> SelectAll()
        {

            List<PatenteFamilia> patentesFamilia = new List<PatenteFamilia>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("FamiliaSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Construye un objeto PatenteFamilia con los datos obtenidos de la base de datos
                                PatenteFamilia patenteFamilia = new PatenteFamilia
                                {
                                    IdFamilia = reader.GetGuid(reader.GetOrdinal("IdFamilia")),
                                    NombreRol = reader.GetString(reader.GetOrdinal("NombreRol")),
                                    FechaCreacionFP = reader.GetDateTime(reader.GetOrdinal("Fecha_Familia"))
                                };
                                patentesFamilia.Add(patenteFamilia);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                string logErrorMessage = $"Error al seleccionar todas las relaciones de Patente-Familia: {ex.Message}";
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

            return (IEnumerable<PatenteFamilia>)patentesFamilia;

        }


        /// <summary>
        /// Obtiene una lista de relaciones de Patente-Familia asociadas a una familia específica según su ID.
        /// </summary>
        /// <param name="id">El ID de la familia.</param>
        /// <returns>Una lista de relaciones de Patente-Familia asociadas a la familia especificada.</returns>
        public List<PatenteFamilia> SelectOne(Guid id)
        {
            List<PatenteFamilia> patentesFamilia = new List<PatenteFamilia>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("FamiliaPatenteSelectByIdFamilia", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdFamilia", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Construye un objeto PatenteFamilia con los datos obtenidos de la base de datos
                                PatenteFamilia patenteFamilia = new PatenteFamilia
                                {
                                    IdFamilia = reader.GetGuid(reader.GetOrdinal("IdFamilia")),
                                    IdPatente = reader.GetGuid(reader.GetOrdinal("IdPatente")),
                                    FechaCreacionFP = reader.GetDateTime(reader.GetOrdinal("FechaCreacionFP"))
                                };

                                // Agrega el objeto PatenteFamilia a la lista
                                patentesFamilia.Add(patenteFamilia);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                string logErrorMessage = $"Error al seleccionar las relaciones de Patente-Familia por ID de familia: {ex.Message}";
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

            return patentesFamilia; // Devuelve la lista de PatenteFamilia
        }

        /// <summary>
        /// Agrega una nueva relación de Patente-Familia a la base de datos.
        /// </summary>
        /// <param name="obj">La relación de Patente-Familia a agregar.</param>
        /// <returns>True si la operación se realizó con éxito; de lo contrario, false.</returns>
        public bool Add(PatenteFamilia obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crea un nuevo comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("FamiliaPatenteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DateTime currentTime = DateTime.Now;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@IdFamilia", obj.IdFamilia));
                        cmd.Parameters.Add(new SqlParameter("@IdPatente", obj.IdPatente));
                        cmd.Parameters.Add(new SqlParameter("@FechaCreacionFP", currentTime));

                        // Ejecuta el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        // Escribe en el registro que se ha creado una nueva relación de Patente-Familia
                        string logMessage = $"Se creó una nueva relación de Patente-Familia con ID de familia '{obj.IdFamilia}' y ID de patente '{obj.IdPatente}'.";
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
                    // Escribe en el registro que ocurrió un error al agregar la relación de Patente-Familia
                    string logErrorMessage = $"Error al agregar la relación de Patente-Familia: {ex.Message}";
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
        /// Actualiza una relación de Patente-Familia.
        /// </summary>
        /// <param name="obj">La relación de Patente-Familia a actualizar.</param>
        /// <returns>True si la actualización fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool Update(PatenteFamilia obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina una relación de Patente-Familia según su ID.
        /// </summary>
        /// <param name="id">El ID de la relación de Patente-Familia a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Agrega una nueva relación de Patente-Familia.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <param name="fechaCreacionFP">La fecha de creación de la relación.</param>
        /// <returns>True si la adición fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool AgregarFamiliaPatente(Guid idFamilia, Guid idPatente, DateTime fechaCreacionFP)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina una relación de Usuario-Patente.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la eliminación fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool BorrarUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si un permiso ya existe en la base de datos.
        /// </summary>
        /// <param name="nombrePermiso">El nombre del permiso.</param>
        /// <returns>True si el permiso existe, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool ExistePermiso(string nombrePermiso)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si un rol ya existe en la base de datos.
        /// </summary>
        /// <param name="nombreRol">El nombre del rol.</param>
        /// <returns>True si el rol existe, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool ExisteRol(string nombreRol)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si existe una relación de Usuario-Rol.
        /// </summary>
        /// <param name="usuNom">El nombre de usuario.</param>
        /// <param name="nombreRol">El nombre del rol.</param>
        /// <returns>True si la relación Usuario-Rol existe, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool ExisteUsuarioRol(string usuNom, string nombreRol)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de relaciones de Usuario-Patente.
        /// </summary>
        /// <returns>Una lista de relaciones de Usuario-Patente.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public List<Contracts.UsuarioPatente> ListarUsuarioPermisos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de familias.
        /// </summary>
        /// <returns>Una lista de familias.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public List<Familia> ObtenerFamilias()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de familias asociadas al usuario.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todas las patentes.
        /// </summary>
        /// <returns>Una lista de todas las patentes.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public List<Patente> ObtenerPatentes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene las patentes asociadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de patentes asociadas al usuario.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <returns>El usuario correspondiente al ID especificado.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public Usuario ObtenerPorId(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una patente por su ID.
        /// </summary>
        /// <param name="patenteId">El ID de la patente.</param>
        /// <returns>La patente correspondiente al ID especificado.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public Patente SelectOne(Patente patenteId)
        {
            throw new NotImplementedException();
        }

        //// <summary>
        /// Obtiene una relación de Patente-Familia por su nombre.
        /// </summary>
        /// <param name="name">El nombre de la relación Patente-Familia.</param>
        /// <returns>La relación de Patente-Familia correspondiente al nombre especificado.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public PatenteFamilia SelectOneByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una relación de Patente-Familia por su nombre de sesión.
        /// </summary>
        /// <param name="name">El nombre de la relación Patente-Familia.</param>
        /// <returns>La relación de Patente-Familia correspondiente al nombre de sesión especificado.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public PatenteFamilia SelectOneSesion(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une dos familias.
        /// </summary>
        /// <param name="idFamilia">El ID de la familia principal.</param>
        /// <param name="idFamiliaHijo">El ID de la familia secundaria.</param>
        /// <param name="fechaCreacion">La fecha de unión de las familias.</param>
        /// <returns>True si la unión fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool UnirFamilias(Guid idFamilia, Guid idFamiliaHijo, DateTime fechaCreacion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une un usuario a una familia.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <returns>True si la unión fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une un usuario a una patente.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la unión fue exitosa, de lo contrario, false.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        public bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una relación de Patente-Familia por su ID.
        /// </summary>
        /// <param name="id">El ID de la relación de Patente-Familia.</param>
        /// <returns>La relación de Patente-Familia correspondiente al ID especificado.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no está implementado.</exception>
        PatenteFamilia IGenericRepository<PatenteFamilia>.SelectOne(Guid id)
        {
            throw new NotImplementedException();
        }

        //public PatenteFamilia SelectOne(Guid id)
        //{
        //    //throw new NotImplementedException();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (SqlCommand cmd = new SqlCommand("FamiliaPatenteSelectByIdFamilia", connection))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@IdFamilia", id);

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        // Construye un objeto PatenteFamilia con los datos obtenidos de la base de datos
        //                        PatenteFamilia patenteFamilia = new PatenteFamilia
        //                        {
        //                            IdFamilia = reader.GetGuid(reader.GetOrdinal("IdFamilia")),
        //                            IdPatente = reader.GetGuid(reader.GetOrdinal("IdPatente")),
        //                            FechaCreacionFP = reader.GetDateTime(reader.GetOrdinal("FechaCreacionFP"))
        //                        };
        //                        return patenteFamilia;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones
        //    }

        //    return null; // Si no se encuentra la PatenteFamilia con el ID especificado

        //}
    }
}
