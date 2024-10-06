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
    /// Repositorio para operaciones relacionadas con la entidad Compra.
    /// </summary>
    public class CompraRepository : IGenericRepository<Compra>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static CompraRepository _instance;
        private readonly ILogger logger;

        private CompraRepository()
        {
        }

        /// <summary>
        /// Proporciona una única instancia de la clase CompraRepository utilizando el patrón Singleton.
        /// </summary>
        public static CompraRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo objeto Compra a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Compra a agregar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool Add(Compra obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("CompradorInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idcomprador", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@legajo_comprador", obj.LegajoComprador));
                        cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellido", obj.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@dni", obj.DNI));
                        cmd.Parameters.Add(new SqlParameter("@fecha_nac", obj.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@importe", obj.Importe));
                        cmd.Parameters.Add(new SqlParameter("@comision", obj.Comision));
                        cmd.Parameters.Add(new SqlParameter("@impuesto", obj.Impuesto));
                        cmd.Parameters.Add(new SqlParameter("@total_propiedad", obj.TotalPropiedad));
                        cmd.Parameters.Add(new SqlParameter("@activo", obj.Activo));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar el comprador: {ex.Message}";
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
        /// Elimina un objeto Compra de la base de datos mediante su identificador.
        /// </summary>
        /// <param name="id">El identificador del objeto Compra a eliminar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        //public bool Delete(Guid id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("CompradorDelete", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            // Agregar parámetro para el idcomprador
        //            command.Parameters.Add("@idcomprador", SqlDbType.UniqueIdentifier).Value = id;

        //            // Ejecutar el comando
        //            int rowsAffected = command.ExecuteNonQuery();

        //            // Si se afectó al menos una fila, se considera que la eliminación fue exitosa
        //            return rowsAffected >= -1;
        //        }
        //    }
        //}
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CompradorDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro para el idcomprador
                        command.Parameters.Add("@idcomprador", SqlDbType.UniqueIdentifier).Value = id;

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si se afectó al menos una fila, se considera que la eliminación fue exitosa
                        return rowsAffected >= -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar el comprador con ID {id}: {ex.Message}";
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
        /// Actualiza un objeto Compra en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Compra con los nuevos valores a actualizar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool Update(Compra obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("CompradorUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idcomprador", obj.IdComprador));
                        cmd.Parameters.Add(new SqlParameter("@legajo_comprador", obj.LegajoComprador));
                        cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellido", obj.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@dni", obj.DNI));
                        cmd.Parameters.Add(new SqlParameter("@fecha_nac", obj.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@importe", obj.Importe));
                        cmd.Parameters.Add(new SqlParameter("@comision", obj.Comision));
                        cmd.Parameters.Add(new SqlParameter("@impuesto", obj.Impuesto));
                        cmd.Parameters.Add(new SqlParameter("@total_propiedad", obj.TotalPropiedad));
                        cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar la Compra con ID {obj.IdComprador}: {ex.Message}";
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
        /// Obtiene un objeto Compra de la base de datos mediante su idTipoInmueble.
        /// </summary>
        /// <param name="idTipoInmueble">El identificador del tipo de inmueble asociado al comprador.</param>
        /// <returns>Un objeto Compra si se encuentra en la base de datos, o null si no se encuentra.</returns>
        public Compra SelectOne(Guid idTipoInmueble)
        {
            Compra comprador = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("CompradorSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", idTipoInmueble));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                comprador = new Compra
                                {
                                    IdComprador = (Guid)reader["idcomprador"],
                                    LegajoComprador = (int)reader["legajo_comprador"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    Importe = (int)reader["importe"],
                                    Comision = (decimal)reader["comision"],
                                    Impuesto = (decimal)reader["impuesto"],
                                    TotalPropiedad = (decimal)reader["total_propiedad"]
                                    //Activo = reader["activo"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el Comprador con ID {idTipoInmueble}: {ex.Message}";
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

            return comprador;
        }

        /// <summary>
        /// Obtiene todos los objetos Compra de la base de datos.
        /// </summary>
        /// <returns>Una colección de objetos Compra.</returns>
        public IEnumerable<Compra> SelectAll()
        {
            List<Compra> compradores = new List<Compra>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("CompradorSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Compra compra = new Compra
                                {
                                    IdComprador = (Guid)reader["idcomprador"],
                                    LegajoComprador = (int)reader["legajo_comprador"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    Importe = (int)reader["importe"],
                                    Comision = (decimal)reader["comision"],
                                    Impuesto = (decimal)reader["impuesto"],
                                    TotalPropiedad = (decimal)reader["total_propiedad"]

                                };

                                compradores.Add(compra);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener los Compradores: {ex.Message}";
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

            return compradores;
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
