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
    /// Repositorio para operaciones relacionadas con la entidad  Escribania.
    /// </summary>
    public class EscribaniaRepository : IGenericRepository<Escribania>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static EscribaniaRepository _instance;
        private readonly ILogger logger;
        private EscribaniaRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static EscribaniaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EscribaniaRepository();
                }
                return _instance;
            }
        }


        /// <summary>
        /// Método para agregar una Escribania
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Escribania obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("EscribaniaInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idescribania", Guid.NewGuid())); // Genera un nuevo Id
                        cmd.Parameters.Add(new SqlParameter("@razon_social", obj.RazonSocial));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar una nueva escribanía: {ex.Message}";
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
        /// Método para borrar una Escribania
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

                    using (SqlCommand cmd = new SqlCommand("EscribaniaDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idescribania", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Escribanía eliminada con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna escribanía con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar la escribanía con ID {id}: {ex.Message}";
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
        /// Método para listar todas las Escribania
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Escribania> SelectAll()
        {
            List<Escribania> escribanias = new List<Escribania>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("EscribaniaSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Escribania escribania = new Escribania
                                {
                                    IdEscribania = (Guid)reader["idescribania"],
                                    RazonSocial = reader["razon_social"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Telefono = reader["telefono"].ToString()
                                };

                                escribanias.Add(escribania);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todas las escribanías: {ex.Message}";
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

            return escribanias;
        }

        /// <summary>
        /// Método para seleccionar una Escribania
        /// </summary>
        /// <param name="id">Uso como parámetro el id</param>
        /// <returns></returns>
        public Escribania SelectOne(Guid id)
        {
            Escribania escribania = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("EscribaniaSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idescribania", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                escribania = new Escribania
                                {
                                    IdEscribania = (Guid)reader["idescribania"],
                                    RazonSocial = reader["razon_social"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Telefono = reader["telefono"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la escribanía con ID {id}: {ex.Message}";
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

            return escribania;
        }

        /// <summary>
        /// Método para actualizar una Escribania
        /// </summary>
        /// <param name="obj">Uso como parámatro el obj</param>
        /// <returns></returns>
        public bool Update(Escribania obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("EscribaniaUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idescribania", obj.IdEscribania));
                        cmd.Parameters.Add(new SqlParameter("@razon_social", obj.RazonSocial));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar la escribanía con ID {obj.IdEscribania}: {ex.Message}";
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
        public IEnumerable<Localidad> ObtenerLocalidadPorId(Guid partidoId)
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
        public IEnumerable<Provincia> ObtenerProvincias(Guid partidoId)
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
