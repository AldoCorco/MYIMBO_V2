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
    /// Repositorio para operaciones relacionadas con la entidad  Partido.
    /// </summary>
    public class PartidoRepository : IGenericRepository<Partido>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static PartidoRepository _instance;
        private readonly ILogger logger;

        private PartidoRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PartidoRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PartidoRepository();
                }
                return _instance;
            }
        }


        /// <summary>
        /// Método para agregar un Partido
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        public bool Add(Partido partido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idpartido", Guid.NewGuid())); // Genera un nuevo Id
                        cmd.Parameters.Add(new SqlParameter("@nom_partido", partido.NombrePartido));
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", partido.IdProvincia)); // Suponiendo que IdProvincia está disponible en el objeto partido

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar un nuevo partido: {ex.Message}";
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
        /// Método para borrar un Partido
        /// </summary>
        /// <param name="id">Uso el id como parámetro</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idpartido", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Partido eliminado con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún partido con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar un partido con ID {id}: {ex.Message}";
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
        /// Método para listar los Partidos
        /// </summary>
        /// <returns>Obtengo una lista de los Partidos</returns>
        public IEnumerable<Partido> SelectAll()
        {
            List<Partido> partidos = new List<Partido>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Partido partido = new Partido
                                {
                                    IdPartido = (Guid)reader["idpartido"],
                                    IdProvincia = (Guid)reader["idprovincia"], // Suponiendo que IdProvincia está disponible en el resultado de la consulta
                                    NombrePartido = reader["nom_partido"].ToString(),
                                    
                                };

                                partidos.Add(partido);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todos los partidos: {ex.Message}";
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

            return partidos;
        }


        /// <summary>
        /// Método para seleccionar un solo Partido
        /// </summary>
        /// <param name="id">Uso como parámetro el id</param>
        /// <returns></returns>
        public Partido SelectOne(Guid id)
        {
            Partido partido = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idpartido", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                partido = new Partido
                                {
                                    IdPartido = (Guid)reader["idpartido"],
                                    IdProvincia = (Guid)reader["idprovincia"], // Suponiendo que IdProvincia está disponible en el resultado de la consulta
                                    NombrePartido = reader["nom_partido"].ToString(),

                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el partido con ID {id}: {ex.Message}";
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

            return partido;
        }

        /// <summary>
        /// Método para obtener los Partido por id
        /// </summary>
        /// <param name="id">Uso como parámetro el id</param>
        /// <returns></returns>
        public IEnumerable<Partido> ObtenerPartidosPorId(Guid id)
        {
            List<Partido> partidos = new List<Partido>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idpartido", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Partido partido = new Partido
                                {
                                    IdPartido = (Guid)reader["idpartido"],
                                    IdProvincia = (Guid)reader["idprovincia"],
                                    NombrePartido = reader["nom_partido"].ToString()
                                };

                                partidos.Add(partido);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener los partidos con ID {id}: {ex.Message}";
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

            return partidos;
        }


        /// <summary>
        /// Método para actualizar los Partidos
        /// </summary>
        /// <param name="partido">Le paso partido como parámetro</param>
        /// <returns></returns>
        public bool Update(Partido partido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PartidoUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idpartido", partido.IdPartido));
                        cmd.Parameters.Add(new SqlParameter("@nom_partido", partido.NombrePartido));
                        //cmd.Parameters.Add(new SqlParameter("@idprovincia", partido.IdProvincia)); // Suponiendo que IdProvincia está disponible en el objeto partido

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar el partido con ID {partido.IdPartido}: {ex.Message}";
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Alquiler SelectReserva(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
