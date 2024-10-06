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
    ///  Repositorio para operaciones relacionadas con la entidad Cliente.
    /// </summary>
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static ClienteRepository _instance;
        private readonly ILogger logger;

        private ClienteRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ClienteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Listo los clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> SelectAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ClienteSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cliente cliente = new Cliente
                                {
                                    IdCliente = (Guid)reader["idcliente"],
                                    LegajoInquilino = (int)reader["legajo_inquilino"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"]
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todos los clientes: {ex.Message}";
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

            return clientes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente SelectOne(Guid id)
        {
            Cliente cliente = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ClienteSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Cliente
                                {
                                    IdCliente = (Guid)reader["idcliente"],
                                    LegajoInquilino = (int)reader["legajo_inquilino"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"],
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener el Cliente con ID {id}: {ex.Message}";
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

            return cliente;
        }



        /// <summary>
        /// Agrega un nuevo cliente a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Cliente a agregar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool Add(Cliente obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ClienteInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idcliente", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@legajo_inquilino", obj.LegajoInquilino));
                        cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellido", obj.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@dni", obj.DNI));
                        cmd.Parameters.Add(new SqlParameter("@fecha_nac", obj.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar el cliente: {ex.Message}";
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
        public bool Update(Cliente obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ClienteUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idcliente", obj.IdCliente));
                        cmd.Parameters.Add(new SqlParameter("@legajo_inquilino", obj.LegajoInquilino));
                        cmd.Parameters.Add(new SqlParameter("@nombre", obj.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellido", obj.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@dni", obj.DNI));
                        cmd.Parameters.Add(new SqlParameter("@fecha_nac", obj.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@telefono", obj.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", obj.IdTipoInmueble));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar el cliente: {ex.Message}";
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
