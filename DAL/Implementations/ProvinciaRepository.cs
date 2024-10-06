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
    /// Repositorio para operaciones relacionadas con la entidad  Provincia.
    /// </summary>
    public class ProvinciaRepository : IGenericRepository<Provincia>
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private static ProvinciaRepository _instance;
        private readonly ILogger logger;

        private ProvinciaRepository()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ProvinciaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProvinciaRepository();
                }
                return _instance;
            }
        }


        //public Provincia ObtenerProvinciaConPartidosYLocalidades(Guid idProvincia)
        //{
        //    Provincia provincia = null;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand("ObtenerDatosPorProvincia", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@idprovincia", idProvincia));

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    provincia = new Provincia
        //                    {
        //                        IdProvincia = (Guid)reader["IdProvincia"],
        //                        NombreProvincia = reader["NombreProvincia"].ToString()
        //                        // Otros campos según tu estructura de datos
        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return provincia;
        //}

        //public IEnumerable<Provincia> ObtenerProvinciaConPartidosYLocalidades(Guid idProvincia)
        //{
        //    List<Provincia> provincias = new List<Provincia>();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (SqlCommand cmd = new SqlCommand("ObtenerProvinciaConPartidosYLocalidades", connection))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add(new SqlParameter("@idProvincia", idProvincia));

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Provincia provincia = new Provincia
        //                        {
        //                            // Mapea los datos del resultado al objeto Provincia
        //                            IdProvincia = (Guid)reader["idProvincia"],
        //                            NombreProvincia = reader["nombreProvincia"].ToString(),
        //                            //IdPartido = (Guid)reader["idpartido"],

        //                            // ... mapea otros campos según tu modelo Provincia
        //                        };

        //                        provincias.Add(provincia);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al obtener provincia con partidos y localidades: " + ex.Message);
        //        // Maneja la excepción según tus necesidades
        //    }

        //    return provincias;
        //}


        /// <summary>
        /// Método para agregar una Provincia
        /// </summary>
        /// <param name="provincia">Uso como parámetro provincia</param>
        /// <returns></returns>
        public bool Add(Provincia provincia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ProvinciaInsert", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Configura los parámetros del procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", Guid.NewGuid())); // Genera un nuevo Id
                        cmd.Parameters.Add(new SqlParameter("@nom_provincia", provincia.NombreProvincia));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al agregar una nueva provincia: {ex.Message}";
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
        /// Método para borrar Provincias
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

                    using (SqlCommand cmd = new SqlCommand("ProvinciaDelete", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", id));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Provincia eliminada con éxito.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna provincia con el ID especificado.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al eliminar la provincia con ID {id}: {ex.Message}";
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
        /// Método para listar todas las Provincias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Provincia> SelectAll()
        {
            List<Provincia> provincias = new List<Provincia>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ProvinciaSelectAll", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Provincia provincia = new Provincia
                                {
                                    IdProvincia = (Guid)reader["idprovincia"],
                                    NombreProvincia = reader["nom_provincia"].ToString()
                                };

                                provincias.Add(provincia);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener todas las provincias: {ex.Message}";
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

            return provincias;
        }


        /// <summary>
        /// Método para obtener una Provincia
        /// </summary>
        /// <param name="id">Uso el id como parámetro</param>
        /// <returns></returns>
        public Provincia SelectOne(Guid id)
        {
            Provincia provincia = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ProvinciaSelect", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idprovincia", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                provincia = new Provincia
                                {
                                    IdProvincia = (Guid)reader["idprovincia"],
                                    NombreProvincia = reader["nom_provincia"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al obtener la provincia con ID {id}: {ex.Message}";
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

            return provincia;
        }

        /// <summary>
        /// Método para actualizar las Provincias
        /// </summary>
        /// <param name="provincia">Uso provincia como parámetro</param>
        /// <returns></returns>
        public bool Update(Provincia provincia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("ProvinciaUpdate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idprovincia", provincia.IdProvincia));
                        cmd.Parameters.Add(new SqlParameter("@nom_provincia", provincia.NombreProvincia));

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en el archivo de registro
                string logErrorMessage = $"Error al actualizar la provincia con ID {provincia.IdProvincia}: {ex.Message}";
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
        public IEnumerable<Localidad> ObtenerLocalidadPorId(Guid partidoId)
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
