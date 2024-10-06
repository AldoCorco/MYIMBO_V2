using DAL.Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Implementations
{
    /// <summary>
    /// Repositorio para operaciones relacionadas con la entidad  Localidad.
    /// </summary>
    public class LocalidadRepository : IGenericRepository<Localidad>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static LocalidadRepository _instance;
        private readonly ILogger logger;

        private LocalidadRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static LocalidadRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LocalidadRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Método para agregar una localidad
        /// </summary>
        /// <param name="localidad"></param>
        /// <returns></returns>
        public bool Add(Localidad localidad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", Guid.NewGuid())); // Genera un nuevo Id
                        cmd.Parameters.Add(new SqlParameter("@nom_localidad", localidad.NombreLocalidad));
                        cmd.Parameters.Add(new SqlParameter("@idpartido", localidad.IdPartido)); // Suponiendo que IdPartido está disponible en el objeto localidad

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                string logErrorMessage = $"Error al agregar una nueva localidad: {ex.Message}";
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
        /// Método para borrar una localidad
        /// </summary>
        /// <param name="id">Uso como parámetro el id</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Localidad eliminada con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna localidad con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar la localidad con ID {id}: {ex.Message}";
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
        /// Método para listar las localidades
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Localidad> SelectAll()
        {
            List<Localidad> localidades = new List<Localidad>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Localidad localidad = new Localidad
                                {
                                    IdLocalidad = (Guid)reader["idlocalidad"],
                                    NombreLocalidad = reader["nom_localidad"].ToString(),
                                    CodigoPostal = reader["codigo_postal"].ToString(),
                                    IdPartido = (Guid)reader["idpartido"] // Suponiendo que IdPartido está disponible en el resultado de la consulta
                                };

                                localidades.Add(localidad);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todas las localidades: {ex.Message}";
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

            return localidades;
        }


        /// <summary>
        /// Método para seleccionar una localidad
        /// </summary>
        /// <param name="id">Uso como parámetros la id</param>
        /// <returns></returns>
        public Localidad SelectOne(Guid id)
        {
            Localidad localidad = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                localidad = new Localidad
                                {
                                    IdLocalidad = (Guid)reader["idlocalidad"],
                                    NombreLocalidad = reader["nom_localidad"].ToString(),
                                    CodigoPostal = reader["codigo_postal"].ToString(),
                                    IdPartido = (Guid)reader["idpartido"] // Suponiendo que IdPartido está disponible en el resultado de la consulta
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la localidad con ID {id}: {ex.Message}";
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

            return localidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localidadId"></param>
        /// <returns></returns>
        public IEnumerable<Localidad> ObtenerLocalidadPorId(Guid localidadId)
        {
            List<Localidad> localidades = new List<Localidad>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", localidadId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Localidad localidad = new Localidad
                                {
                                    IdLocalidad = (Guid)reader["idlocalidad"],
                                    NombreLocalidad = reader["nom_localidad"].ToString(),
                                    CodigoPostal = reader["codigo_postal"].ToString(),
                                    IdPartido = (Guid)reader["idpartido"]
                                };

                                localidades.Add(localidad);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la localidad con ID {localidadId}: {ex.Message}";
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

            return localidades;
        }
        

        /// <summary>
        /// Método para modificar una localidad
        /// </summary>
        /// <param name="localidad">Uso como parámetros la localidad</param>
        /// <returns></returns>
        public bool Update(Localidad localidad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("LocalidadUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idlocalidad", localidad.IdLocalidad));
                        cmd.Parameters.Add(new SqlParameter("@nom_localidad", localidad.NombreLocalidad));
                        cmd.Parameters.Add(new SqlParameter("@codigo_postal", localidad.CodigoPostal));
                        cmd.Parameters.Add(new SqlParameter("@idpartido", localidad.IdPartido)); // Suponiendo que IdPartido está disponible en el objeto localidad

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar la localidad con ID {localidad.IdLocalidad}: {ex.Message}";
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Alquiler SelectReserva(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
