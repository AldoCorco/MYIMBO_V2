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
    /// Repositorio para operaciones relacionadas con la entidad  Propietario.
    /// </summary>
    public class PropietarioRepository : IGenericRepository<Propietario>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static PropietarioRepository _instance;
        private readonly ILogger logger;
        private PropietarioRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PropietarioRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PropietarioRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Lista todos los Propietarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Propietario> SelectAll()
        {
            List<Propietario> propietarios = new List<Propietario>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PropietarioSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Propietario propietario = new Propietario
                                {
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    LegajoPropietario = (int)reader["legajo_propietario"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
                                    IdTipoInmueble = (Guid)reader["idtipo_inmueble"]
                                };

                                propietarios.Add(propietario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todos los propietarios: {ex.Message}";
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

            return propietarios;
        }

        /// <summary>
        /// Agrega Propietarios
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Propietario obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PropietarioInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idpropietario", Guid.NewGuid()));
                        cmd.Parameters.Add(new SqlParameter("@legajo_propietario", obj.LegajoPropietario));
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
                string logErrorMessage = $"Error al agregar un nuevo propietario: {ex.Message}";
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
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Propietario obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PropietarioUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idpropietario", obj.IdPropietario));
                        cmd.Parameters.Add(new SqlParameter("@legajo_propietario", obj.LegajoPropietario));
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
                string logErrorMessage = $"Error al actualizar un propietario con ID {obj.IdPropietario}: {ex.Message}";
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
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PropietarioDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idpropietario", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected < 0)
                        {
                            MessageBox.Show("Propietario eliminado con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún propietario con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar un propietario con ID {id}: {ex.Message}";
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
        public Propietario SelectOne(Guid id)
        {
            Propietario propietario = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("PropietarioSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtipo_inmueble", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                propietario = new Propietario
                                {
                                    IdPropietario = (Guid)reader["idpropietario"],
                                    LegajoPropietario = (int)reader["legajo_propietario"],
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = (int)reader["dni"],
                                    FechaNacimiento = (DateTime)reader["fecha_nac"],
                                    Telefono = reader["telefono"].ToString(),
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
                string logErrorMessage = $"Error al obtener el propietario con ID {id}: {ex.Message}";
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

            return propietario;
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
