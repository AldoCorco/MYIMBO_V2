using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Venta
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la venta.
        /// </summary>
        public Guid IdVenta { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado a la venta.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el importe de la venta en formato de cadena.
        /// </summary>
        public int Importe { get; set; }


        /// <summary>
        /// Obtiene o establece la comisión asociada a la venta en formato de cadena.
        /// </summary>
        public decimal Comision { get; set; }


        /// <summary>
        /// Obtiene o establece el identificador único del propietario.
        /// </summary>
        public Guid IdPropietario { get; set; }

        /// <summary>
        /// Obtiene o establece el estado activo o inactivo de la operación.
        /// </summary>
        public string Activo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de inmueble.
        /// </summary>
        public string TipoInmuebleNombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del tipo de inmueble.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del tipo de inmueble.
        /// </summary>
        public string Direccion { get; set; }

    }
}
