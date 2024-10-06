using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Services.DAL.Contracts;
using DomainModel;

namespace Services.DAL.Implementations.File
{
    /// <summary>
    /// Implementación de la interfaz <see cref="ILogger"/> que almacena y recupera registros de log en una base de datos SeguridadDB.
    /// </summary>
    public class SqlLogger : ILogger
    {
        private readonly string connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SqlLogger"/>.
        /// </summary>
        public SqlLogger()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        }

        /// <summary>
        /// Obtiene una lista con todos los registros de log almacenados en la base de datos SeguridadDB.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Log"/>.</returns>
        public List<DomainModel.Log> GetAll()
        {

            List<DomainModel.Log> logs = new List<DomainModel.Log>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("LogSelectAll", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DomainModel.Log log = new DomainModel.Log
                            {
                                Message = reader["message"].ToString(),
                                Severity = (Severity)Enum.Parse(typeof(Severity), reader["severity"].ToString()),
                                Fecha_txr = (DateTime)reader["fecha_txr"]
                            };

                            logs.Add(log);
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Almacena un registro de log en la base de datos SeguridadDB.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que se desea almacenar.</param>
        public void Store(DomainModel.Log log)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("LogInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idlog", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@message", log.Message);
                    cmd.Parameters.AddWithValue("@severity", log.Severity.ToString());
                    cmd.Parameters.AddWithValue("@fecha_txr", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
