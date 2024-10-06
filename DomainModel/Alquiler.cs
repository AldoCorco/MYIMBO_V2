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
    public class Alquiler
    {
        /// <summary>
        /// Obtiene o establece el identificador único del contrato de alquiler.
        /// </summary>
        public Guid IdAlquiler { get; set; }

        /// <summary>
        /// Obtiene o establece el importe de la reserva para el contrato de alquiler.
        /// </summary>
        public int ImporteReserva { get; set; }

        /// <summary>
        /// Obtiene o establece la garantía asociada al contrato de alquiler.
        /// </summary>
        public string Garantia { get; set; }

        /// <summary>
        /// Obtiene o establece el importe mensual del alquiler.
        /// </summary>
        public decimal ImporteAlquiler { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado al contrato de alquiler.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el estado activo o inactivo de la operación.
        /// </summary>
        public string Activo { get; set; }
    }

}
