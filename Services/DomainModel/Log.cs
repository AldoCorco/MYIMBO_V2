using crypto;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    /// <summary>
    /// Clase que representa un registro en el registro (log) de la sesiones.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Obtiene o establece el identificador único del registro en el log.
        /// </summary>
        public Guid IdLog { get; set; }

        /// <summary>
        /// Obtiene o establece el mensaje asociado al registro en el log.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Obtiene o establece la gravedad (severity) del mensaje en el registro.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la transacción en el log.
        /// </summary>
        public DateTime Fecha_txr { get; set; }

    }
}
