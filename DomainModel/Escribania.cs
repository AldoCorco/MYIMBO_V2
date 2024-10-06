using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa una escribanía.
    /// </summary>
    public class Escribania
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la escribanía.
        /// </summary>
        public Guid IdEscribania { get; set; }

        /// <summary>
        /// Obtiene o establece la razón social (nombre) de la escribanía.
        /// </summary>
        public string RazonSocial { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección de la escribanía.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono de la escribanía.
        /// </summary>
        public string Telefono { get; set; }
    }

}
