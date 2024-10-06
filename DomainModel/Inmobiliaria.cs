using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa una operación inmobiliaria.
    /// </summary>
    public class Inmobiliaria
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la operación inmobiliaria.
        /// </summary>
        public Guid IdInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado a la operación.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del propietario asociado a la operación.
        /// </summary>
        public Guid? IdPropietario { get; set; }


        /// <summary>
        /// Obtiene o establece el identificador único del comprador asociado a la operación de venta.
        /// </summary>
        public Guid? IdComprador { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del contrato asociado a la operación de alquiler.
        /// </summary>
        public Guid? IdAlquiler { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la venta asociada a la operación.
        /// </summary>
        public Guid? IdVenta { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del contrato asociado a la operación.
        /// </summary>
        public Guid? IdContrato { get; set; }

        /// <summary>
        /// Obtiene o establece los detalles adicionales de la operación inmobiliaria.
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se realizó la operación inmobiliaria.
        /// </summary>
        public DateTime FechaOperacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado activo o inactivo de la operación.
        /// </summary>
        public string Activo { get; set; }
    }

}
