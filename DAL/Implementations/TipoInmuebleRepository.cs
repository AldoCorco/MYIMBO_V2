using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Contracts;

namespace DAL.Implementations
{
    /// <summary>
    /// Repositorio para operaciones relacionadas con la entidad  TipoInmueble.
    /// </summary>
    public class TipoInmuebleRepository : IGenericRepository<TipoInmueble>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static TipoInmuebleRepository _instance;
        private readonly ILogger logger;

        private TipoInmuebleRepository()
        {
        }

        /// <summary>
        /// Obtiene una instancia única de la clase TipoInmuebleRepository utilizando el patrón Singleton.
        /// </summary>
        public static TipoInmuebleRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TipoInmuebleRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Recupera todos los inmuebles almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de todos los inmuebles recuperados.</returns>
        public IEnumerable<TipoInmueble> SelectAll()
        {
            List<TipoInmueble> tipoInmuebles = new List<TipoInmueble>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Tipo_InmuebleSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoInmueble tipoInmueble = new TipoInmueble
                                {
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    TipoInmuebleNombre = reader["tipo_inmueble"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                    IdLocalidad = (Guid)reader["idlocalidad"],
                                    IdPartido = (Guid)reader["idpartido"],
                                    IdProvincia = (Guid)reader["idprovincia"],
                                    Direccion = reader["direccion"].ToString()
                                };

                                tipoInmuebles.Add(tipoInmueble);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todos los tipos de inmuebles: {ex.Message}";
                Log logError = new Log
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

            return tipoInmuebles;
        }

        /// <summary>
        /// Agrega un nuevo inmueble a la base de datos.
        /// </summary>
        /// <param name="obj">El inmueble a agregar.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, False.</returns>
        public bool Add(TipoInmueble obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Tipo_InmuebleInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", Guid.NewGuid())); // Genera un nuevo Id
                        cmd.Parameters.Add(new SqlParameter("@tipo_inmueble", obj.TipoInmuebleNombre));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", obj.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", obj.IdLocalidad));
                        cmd.Parameters.Add(new SqlParameter("@idpartido", obj.IdPartido));
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", obj.IdProvincia));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar un nuevo tipo de inmueble: {ex.Message}";
                Log logError = new Log
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
        /// Actualiza un inmueble a la base de datos.
        /// </summary>
        /// <param name="obj">El inmueble a agregar.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, False.</returns>
        public bool Update(TipoInmueble obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Tipo_InmuebleUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@tipo_inmueble", obj.TipoInmuebleNombre));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", obj.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", obj.IdLocalidad));
                        cmd.Parameters.Add(new SqlParameter("@idpartido", obj.IdPartido));
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", obj.IdProvincia));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar un tipo de inmueble: {ex.Message}";
                Log logError = new Log
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
        /// Elimina un inmueble de la base de datos.
        /// </summary>
        /// <param name="id">El ID del inmueble a eliminar.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, False.</returns>
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Tipo_InmuebleDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // La eliminación fue exitosa
                            return true;
                        }
                        else
                        {
                            // No se encontró ninguna fila con el ID especificado
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al intentar eliminar el tipo de inmueble con ID {id}: {ex.Message}";
                Log logError = new Log
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
        /// Obtiene un inmueble de la base de datos según su ID.
        /// </summary>
        /// <param name="id">El ID del inmueble.</param>
        /// <returns>El inmueble correspondiente al ID especificado; null si no se encuentra.</returns>
        public TipoInmueble SelectOne(Guid id)
        {
            TipoInmueble tipoInmueble = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Tipo_InmuebleSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tipoInmueble = new TipoInmueble
                                {
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    TipoInmuebleNombre = reader["tipo_inmueble"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                    IdLocalidad = (Guid)reader["idlocalidad"],
                                    IdPartido = (Guid)reader["idpartido"],
                                    IdProvincia = (Guid)reader["idprovincia"],
                                    Direccion = reader["direccion"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el tipo de inmueble con ID {id}: {ex.Message}";
                Log logError = new Log
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

            return tipoInmueble;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="partidoId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Provincia> ObtenerProvincias(Guid partidoId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provinciaId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Partido> ObtenerPartidosPorId(Guid provinciaId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partidoId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Localidad> ObtenerLocalidadPorId(Guid partidoId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProvincia"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Provincia SelectOne(Guid? idProvincia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partidoId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Localidad> LocalidadesPorPartido(Guid partidoId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provinciaId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Partido> ObtenerPartidosPorProvincia(Guid provinciaId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Alquiler SelectReserva(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}