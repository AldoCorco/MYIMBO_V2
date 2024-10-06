using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DomainModel;
using Microsoft.Win32;

namespace DAL.Implementations
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad Alquiler.
    /// </summary>
    public class AlquilerRepository: IGenericRepository<Alquiler>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static AlquilerRepository _instance;
        private readonly ILogger logger;

        /// <summary>
        /// 
        /// </summary>
        private AlquilerRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static AlquilerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AlquilerRepository();
                }
                return _instance;
            }
        }


        /// <summary>
        /// Método para registrar los datos del alquiler
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Alquiler obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("AlquilerInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idalquiler", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@importe_reserva", obj.ImporteReserva));
                        cmd.Parameters.Add(new SqlParameter("@garantia", obj.Garantia));
                        cmd.Parameters.Add(new SqlParameter("@importe_alquiler", obj.ImporteAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@activo", obj.Activo));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'AlquilerInsert': {ex.Message}";
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
        /// Método para borrar los datos del alquiler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un objeto Alquiler en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Alquiler con los nuevos valores a actualizar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool Update(Alquiler obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("AlquilerUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idalquiler", obj.IdAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@importe_reserva", obj.ImporteReserva));
                        cmd.Parameters.Add(new SqlParameter("@garantia", obj.Garantia));
                        cmd.Parameters.Add(new SqlParameter("@importe_alquiler", obj.ImporteAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'AlquilerUpdate': {ex.Message}";
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


        ///// <summary>
        ///// Método para listar los datos del alquiler
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Alquiler> SelectAll()
        //{
        //    List<Alquiler> alquileres = new List<Alquiler>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("AlquilerSelectAll", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Alquiler alquiler = new Alquiler
        //                    {
        //                        IdAlquiler = (Guid)reader["idalquiler"],
        //                        ImporteReserva = (int)reader["importe_reserva"],
        //                        Garantia = reader["garantia"].ToString(),
        //                        ImporteAlquiler = (decimal)reader["importe_alquiler"],
        //                        IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
        //                        Activo = (string)reader["activo"],
        //                    };

        //                    alquileres.Add(alquiler);
        //                }
        //            }
        //        }
        //    }

        //    return alquileres;
        //}

        /// <summary>
        /// Método para listar los datos del alquiler
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Alquiler> SelectAll()
        {
            List<Alquiler> alquileres = new List<Alquiler>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("AlquilerSelectAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alquiler alquiler = new Alquiler
                                {
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    ImporteReserva = (int)reader["importe_reserva"],
                                    Garantia = reader["garantia"].ToString(),
                                    ImporteAlquiler = (decimal)reader["importe_alquiler"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    Activo = (string)reader["activo"],
                                };

                                alquileres.Add(alquiler);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'AlquilerSelectAll': {ex.Message}";
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

            return alquileres;
        }


        /// <summary>
        /// Método para encontrar uno registro de alquiler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Alquiler SelectOne(Guid id)
        {
            Alquiler alquiler = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("AlquilerSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                alquiler = new Alquiler
                                {
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    ImporteReserva = (int)reader["importe_reserva"],
                                    Garantia = reader["garantia"].ToString(),
                                    ImporteAlquiler = (decimal)reader["importe_alquiler"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    Activo = (string)reader["activo"],
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el Alquiler con ID {id}: {ex.Message}";
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

            return alquiler;
        }

        /// <summary>
        /// Método para buscar una reserva del alquiler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Alquiler SelectReserva(Guid id)
        {
            Alquiler alquiler = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("AlquilerSelectReserva", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                alquiler = new Alquiler
                                {
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    ImporteReserva = (int)reader["importe_reserva"],
                                    Garantia = reader["garantia"].ToString(),
                                    ImporteAlquiler = (decimal)reader["importe_alquiler"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    Activo = (string)reader["activo"],
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la reserva del Alquiler con ID {id}: {ex.Message}";
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

            return alquiler;
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

    }
}
