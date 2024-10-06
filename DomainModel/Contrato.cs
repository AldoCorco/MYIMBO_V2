using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa un contrato de alquiler.
    /// </summary>
    public class Contrato
    {
        /// <summary>
        /// Obtiene o establece el identificador único del contrato.
        /// </summary>
        public Guid IdContrato { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio del contrato.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de finalización del contrato.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la escribanía asociada al contrato.
        /// </summary>
        public Guid IdEscribania { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado al contrato.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del alquiler asociado al contrato.
        /// </summary>
        public Guid IdAlquiler { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public Guid IdCliente { get; set; }
    }

}
