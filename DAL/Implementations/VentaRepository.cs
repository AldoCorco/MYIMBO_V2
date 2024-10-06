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
    /// Repositorio para operaciones relacionadas con la entidad  Venta.
    /// </summary>
    public class VentaRepository: IGenericRepository<Venta>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static VentaRepository _instance;
        private readonly ILogger logger;

        private VentaRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static VentaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VentaRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Agrega una venta a la base de datos.
        /// </summary>
        /// <param name="obj">La venta a agregar.</param>
        /// <returns>True si la venta se agrega correctamente, False si ocurre un error.</returns>
        public bool Add(Venta obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("VentaInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idventa", Guid.NewGuid())); // Utiliza el Id proporcionado
                        cmd.Parameters.Add(new SqlParameter("@importe", obj.Importe));
                        cmd.Parameters.Add(new SqlParameter("@comision", obj.Comision));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));
                        cmd.Parameters.Add(new SqlParameter("@idpropietario", obj.IdPropietario));
                        cmd.Parameters.Add(new SqlParameter("@tipo_inmueble", obj.TipoInmuebleNombre));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", obj.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar una venta: {ex.Message}";
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
        /// Actualiza una venta en la base de datos.
        /// </summary>
        /// <param name="obj">La venta actualizada.</param>
        /// <returns>True si la venta se actualiza correctamente, False si ocurre un error.</returns>
        public bool Update(Venta obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("VentaUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idventa", obj.IdVenta));
                        cmd.Parameters.Add(new SqlParameter("@importe", obj.Importe));
                        cmd.Parameters.Add(new SqlParameter("@comision", obj.Comision));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));
                        cmd.Parameters.Add(new SqlParameter("@Activo", obj.Activo));
                        cmd.Parameters.Add(new SqlParameter("@idpropietario", obj.IdPropietario));
                        cmd.Parameters.Add(new SqlParameter("@tipo_inmueble", obj.TipoInmuebleNombre));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", obj.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@direccion", obj.Direccion));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected >= -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar una venta: {ex.Message}";
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
        /// Obtiene una venta de la base de datos según su ID.
        /// </summary>
        /// <param name="id">El ID de la venta.</param>
        /// <returns>La venta encontrada, o null si no se encuentra ninguna venta con el ID especificado.</returns>
        public Venta SelectOne(Guid id)
        {
            Venta venta = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("VentaSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                venta = new Venta
                                {
                                    IdVenta = (Guid)reader["idventa"],
                                    Importe = (int)reader["importe"],
                                    Comision = (decimal)reader["comision"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    Activo = (string)reader["activo"],
                                    TipoInmuebleNombre = (string)reader["tipo_inmueble"],
                                    Descripcion = (string)reader["descripcion"],
                                    Direccion = (string)reader["direccion"],

                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la venta con ID {id}: {ex.Message}";
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

            return venta;
        }


        /// <summary>
        /// Obtiene todas las ventas de la base de datos.
        /// </summary>
        /// <returns>Una colección de todas las ventas.</returns>
        public IEnumerable<Venta> SelectAll()
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("VentaSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    IdVenta = (Guid)reader["idventa"],
                                    Importe = (int)reader["importe"],
                                    Comision = (decimal)reader["comision"],
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    Activo = (string)reader["activo"],
                                    TipoInmuebleNombre = (string)reader["tipo_inmueble"],
                                    Descripcion = (string)reader["descripcion"],
                                    Direccion = (string)reader["direccion"],

                                };

                                ventas.Add(venta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todas las ventas: {ex.Message}";
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

            return ventas;
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
