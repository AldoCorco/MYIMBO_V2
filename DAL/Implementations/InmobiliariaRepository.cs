using DAL.Contracts;
using DAL.Implementations;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Repository.Hierarchy;

namespace DAL
{
    /// <summary>
    ///  Repositorio para operaciones relacionadas con la entidad Inmobiliaria.
    /// </summary>
    public class InmobiliariaRepository : IGenericRepository<Inmobiliaria>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static InmobiliariaRepository _instance;
        private readonly ILogger logger;
        private InmobiliariaRepository()
        {
        }

        /// <summary>
        /// Proporciona una instancia única de InmobiliariaRepository utilizando el patrón Singleton.
        /// </summary>
        public static InmobiliariaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InmobiliariaRepository();
                }
                return _instance;
            }
        }



        /// <summary>
        /// Método para agregar un transacción a la Inmobiliaria
        /// </summary>
        /// <param name="obj">El obj es el id de la transacción</param>
        /// <returns></returns>
        public bool Add(Inmobiliaria obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InmobiliariaInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idinmueble", Guid.NewGuid());
                        command.Parameters.AddWithValue("@idtipo_inmueble", obj.IdTipoInmueble);
                        //command.Parameters.AddWithValue("@idpropietario", obj.IdPropietario);

                        if (obj.IdPropietario.HasValue)
                        {
                            command.Parameters.AddWithValue("@idpropietario", obj.IdPropietario.Value);
                        }
                        else
                        {
                            // Si IdComprador es null, puedes asignar DBNull.Value o dejarlo fuera, dependiendo de tu lógica
                            command.Parameters.AddWithValue("@idpropietario", DBNull.Value);
                        }

                        //command.Parameters.AddWithValue("@idcomprador", obj.IdComprador);

                        // Asegurarse de manejar el caso en que IdComprador es null
                        if (obj.IdComprador.HasValue)
                        {
                            command.Parameters.AddWithValue("@idcomprador", obj.IdComprador.Value);
                        }
                        else
                        {
                            // Si IdComprador es null, puedes asignar DBNull.Value o dejarlo fuera, dependiendo de tu lógica
                            command.Parameters.AddWithValue("@idcomprador", DBNull.Value);
                        }

                        //command.Parameters.AddWithValue("@idalquiler", obj.IdAlquiler);

                        if (obj.IdAlquiler.HasValue)
                        {
                            command.Parameters.AddWithValue("@idalquiler", obj.IdAlquiler.Value);
                        }
                        else
                        {
                            // Si IdComprador es null, puedes asignar DBNull.Value o dejarlo fuera, dependiendo de tu lógica
                            command.Parameters.AddWithValue("@idalquiler", DBNull.Value);
                        }

                        //command.Parameters.AddWithValue("@idventa", obj.IdVenta);

                        if (obj.IdVenta.HasValue)
                        {
                            command.Parameters.AddWithValue("@idventa", obj.IdVenta.Value);
                        }
                        else
                        {
                            // Si IdComprador es null, puedes asignar DBNull.Value o dejarlo fuera, dependiendo de tu lógica
                            command.Parameters.AddWithValue("@idventa", DBNull.Value);
                        }

                        //command.Parameters.AddWithValue("@idcontrato", obj.IdContrato);

                        if (obj.IdContrato.HasValue)
                        {
                            command.Parameters.AddWithValue("@idcontrato", obj.IdContrato.Value);
                        }
                        else
                        {
                            // Si IdComprador es null, puedes asignar DBNull.Value o dejarlo fuera, dependiendo de tu lógica
                            command.Parameters.AddWithValue("@idcontrato", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@detalle", obj.Detalle);
                        command.Parameters.AddWithValue("@fecha_operacion", obj.FechaOperacion);
                        command.Parameters.AddWithValue("@Activo", obj.Activo); // Agrega el parámetro Activo


                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected >= -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'InmobiliariaInsert': {ex.Message}";
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
        /// Método para borrar una transacción de la Inmobiliaria
        /// </summary>
        /// <param name="id">Utilizo el id como parámetro</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InmobiliariaDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro
                        command.Parameters.AddWithValue("@idinmueble", id);

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'InmobiliariaDelete': {ex.Message}";
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
        /// Método para actualizar alguna operación de la Inmobiliaria
        /// </summary>
        /// <param name="obj"> El obj es el id de la transacción</param>
        /// <returns></returns>
        public bool Update(Inmobiliaria obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InmobiliariaUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idinmueble", obj.IdInmueble);
                        command.Parameters.AddWithValue("@idtipo_inmueble", obj.IdTipoInmueble);
                        command.Parameters.AddWithValue("@idpropietario", obj.IdPropietario);
                        command.Parameters.AddWithValue("@idcomprador", obj.IdComprador);
                        command.Parameters.AddWithValue("@idalquiler", obj.IdAlquiler);
                        command.Parameters.AddWithValue("@idventa", obj.IdVenta);
                        command.Parameters.AddWithValue("@idcontrato", obj.IdContrato);
                        command.Parameters.AddWithValue("@detalle", obj.Detalle);
                        command.Parameters.AddWithValue("@fecha_operacion", obj.FechaOperacion);

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'InmobiliariaUpdate': {ex.Message}";
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
        /// Método para listar todas las operaciones registradas en la Inmobiliaria
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Inmobiliaria> SelectAll()
        {
            List<Inmobiliaria> inmobiliarias = new List<Inmobiliaria>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("InmobiliariaSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Inmobiliaria inmobiliaria = new Inmobiliaria
                                {
                                    IdInmueble = (Guid)reader["idinmueble"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    IdComprador = (Guid)reader["idcomprador"],
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    IdVenta = (Guid)reader["idventa"],
                                    IdContrato = (Guid)reader["idcontrato"],
                                    Detalle = reader["detalle"].ToString(),
                                    FechaOperacion = (DateTime)reader["fecha_operacion"]
                                };

                                inmobiliarias.Add(inmobiliaria);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'InmobiliariaSelectAll': {ex.Message}";
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

            return inmobiliarias;
        }

        /// <summary>
        /// Método para buscar una operación de la Inmobiliaria
        /// </summary>
        /// <param name="id">Lo busco por su ID</param>
        /// <returns></returns>
        public Inmobiliaria SelectOne(Guid id)
        {
            Inmobiliaria inmobiliaria = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("InmobiliariaSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idinmueble", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                inmobiliaria = new Inmobiliaria
                                {
                                    IdInmueble = (Guid)reader["idinmueble"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    IdComprador = (Guid)reader["idcomprador"],
                                    IdAlquiler = (Guid)reader["idalquiler"],
                                    IdVenta = (Guid)reader["idventa"],
                                    IdContrato = (Guid)reader["idcontrato"],
                                    Detalle = reader["detalle"].ToString(),
                                    FechaOperacion = (DateTime)reader["fecha_operacion"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al ejecutar procedimiento almacenado 'InmobiliariaSelect' para buscar una operación por ID: {ex.Message}";
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

            return inmobiliaria;
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
