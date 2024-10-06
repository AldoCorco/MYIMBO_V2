using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa una tasación de un inmueble.
    /// </summary>
    public class Tasacion
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la tasación.
        /// </summary>
        public Guid IdTasacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado a la tasación.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el importe de venta estimado en la tasación.
        /// </summary>
        public int ImporteVenta { get; set; }

        /// <summary>
        /// Obtiene o establece el importe de alquiler estimado en la tasación.
        /// </summary>
        public int ImporteAlquiler { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se realizó la tasación.
        /// </summary>
        public DateTime Fecha { get; set; }
    }

}
