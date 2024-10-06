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

namespace DAL.Implementations
{
    /// <summary>
    /// Repositorio para operaciones relacionadas con la entidad Contrato.
    /// </summary>
    public class ContratoRepository : IGenericRepository<Contrato>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static ContratoRepository _instance;
        private readonly ILogger logger;

        private ContratoRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ContratoRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContratoRepository();
                }
                return _instance;
            }
        }



        /// <summary>
        /// Devuelte todos los contratos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contrato> SelectAll()
        {
            List<Contrato> contratos = new List<Contrato>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ContratoSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contrato contrato = new Contrato
                                {
                                    IdContrato = (Guid)reader["idcontrato"],
                                    FechaInicio = (DateTime)reader["fecha_inicio"],
                                    FechaFin = (DateTime)reader["fecha_fin"],
                                    IdEscribania = (Guid)reader["idescribania"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdAlquiler = (Guid)reader["idalquiler"]
                                };

                                contratos.Add(contrato);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todos los contratos: {ex.Message}";
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

            return contratos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idtipo_inmueble"></param>
        /// <returns></returns>
        public Contrato SelectOne(Guid idtipo_inmueble)
        {
            Contrato contrato = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ContratoSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", idtipo_inmueble));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                contrato = new Contrato
                                {
                                    IdContrato = (Guid)reader["idcontrato"],
                                    FechaInicio = (DateTime)reader["fecha_inicio"],
                                    FechaFin = (DateTime)reader["fecha_fin"],
                                    IdEscribania = (Guid)reader["idescribania"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    IdCliente = (Guid)reader["idcliente"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el contrato con ID de tipo de inmueble {idtipo_inmueble}: {ex.Message}";
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

            return contrato;
        }

        /// <summary>
        /// Agrega un nuevo contrato a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Contrato a agregar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool Add(Contrato obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ContratoInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idcontrato", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@fecha_inicio", obj.FechaInicio));
                        cmd.Parameters.Add(new SqlParameter("@fecha_fin", obj.FechaFin));
                        cmd.Parameters.Add(new SqlParameter("@idescribania", obj.IdEscribania));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@idalquiler", obj.IdAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@idcliente", obj.IdCliente));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar un nuevo contrato: {ex.Message}";
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
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Contrato obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ContratoUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idcontrato", obj.IdContrato));
                        cmd.Parameters.Add(new SqlParameter("@fecha_inicio", obj.FechaInicio));
                        cmd.Parameters.Add(new SqlParameter("@fecha_fin", obj.FechaFin));
                        cmd.Parameters.Add(new SqlParameter("@idescribania", obj.IdEscribania));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@idalquiler", obj.IdAlquiler));
                        cmd.Parameters.Add(new SqlParameter("@idcliente", obj.IdCliente));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar un contrato: {ex.Message}";
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Alquiler SelectReserva(Guid id)
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
        /// <param name="provinciaId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Partido> ObtenerPartidosPorId(Guid provinciaId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provincia> ObtenerProvincias(Guid partidoId)
        {
            throw new NotImplementedException();
        }

    }
}
