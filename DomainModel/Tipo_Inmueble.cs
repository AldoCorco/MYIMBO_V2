using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa un tipo de inmueble.
    /// </summary>
    public class TipoInmueble
    {
        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de inmueble.
        /// </summary>
        public string TipoInmuebleNombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del tipo de inmueble.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la localidad asociada al tipo de inmueble.
        /// </summary>
        public Guid? IdLocalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del partido asociado al tipo de inmueble.
        /// </summary>
        public Guid? IdPartido { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la provincia asociada al tipo de inmueble.
        /// </summary>
        public Guid? IdProvincia { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del tipo de inmueble.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la provincia asociada al tipo de inmueble.
        /// </summary>
        public string NombreProvincia { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del partido asociado al tipo de inmueble.
        /// </summary>
        public string NombrePartido { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la localidad asociada al tipo de inmueble.
        /// </summary>
        public string NombreLocalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el precio de venta del tipo de inmueble.
        /// </summary>
        public int PrecioVenta { get; set; }

        /// <summary>
        /// Obtiene o establece el precio de alquiler del tipo de inmueble.
        /// </summary>
        public int PrecioAlquiler { get; set; }

        public int TieneReserva { get; set; }
        public int ImporteReserva { get; set; }
    }

}
