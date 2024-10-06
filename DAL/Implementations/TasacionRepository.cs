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
    /// Repositorio para operaciones relacionadas con la entidad  Tasacion.
    /// </summary>
    public class TasacionRepository : IGenericRepository<Tasacion>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static TasacionRepository _instance;
        private readonly ILogger logger;

        private TasacionRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static TasacionRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TasacionRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Método para agregar la tasación
        /// </summary>
        /// <param name="tasacion">Le paso como parámetro tasacion</param>
        /// <returns></returns>
        public bool Add(Tasacion tasacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("TasacionInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;;
                        DateTime currentTime = DateTime.Now;

                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idtasacion", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@importe_venta", tasacion.ImporteVenta));
                        cmd.Parameters.Add(new SqlParameter("@fecha", currentTime));
                        cmd.Parameters.Add(new SqlParameter("@importe_alquiler", tasacion.ImporteAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", tasacion.IdTipoInmueble));


                        // Ejecutar el procedimiento almacenado
                        cmd.ExecuteNonQuery();

                        return true; // Indica que la operación fue exitosa
                    }
                }
                catch (Exception ex)
                {
                    // Registrar el error en el archivo de registro
                    string logErrorMessage = $"Error al agregar una nueva tasación: {ex.Message}";
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
        }

        /// <summary>
        /// Método para eliminar la tasación
        /// </summary>
        /// <param name="id">Uso como parámetro el id de inmueble</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("TasacionDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tasación eliminada con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna tasación con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                string logErrorMessage = $"Error al intentar eliminar la tasación con ID {id}: {ex.Message}";
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
        /// Método para actualizar una tasación
        /// </summary>
        /// <param name="obj">Uso como parámetro obj</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(Tasacion obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para buscar una tasación
        /// </summary>
        /// <param name="id">Uso como parámetro el id</param>
        /// <returns></returns>
        public Tasacion SelectOne(Guid id)
        {
            Tasacion tasacion = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("TasacionSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tasacion = new Tasacion
                                {
                                    IdTasacion = (Guid)reader["idtasacion"],
                                    ImporteVenta = (int)reader["importe_venta"],
                                    Fecha = (DateTime)reader["fecha"],
                                    ImporteAlquiler = (int)reader["importe_alquiler"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la tasación con ID {id}: {ex.Message}";
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
            return tasacion;
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
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Tasacion> SelectAll()
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
