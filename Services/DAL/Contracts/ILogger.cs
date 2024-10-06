using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Interfaz que define métodos para la gestión de logs.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Almacena un registro de log.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que se desea almacenar.</param>
        void Store(Log log);

        /// <summary>
        /// Obtiene una lista con todos los registros de log almacenados.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Log"/>.</returns>
        List<Log> GetAll();


    }
}
