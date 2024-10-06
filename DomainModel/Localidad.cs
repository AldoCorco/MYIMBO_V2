using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa una localidad dentro de un partido.
    /// </summary>
    public class Localidad
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la localidad.
        /// </summary>
        public Guid IdLocalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la localidad.
        /// </summary>
        public string NombreLocalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el código postal de la localidad.
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del partido al que pertenece la localidad.
        /// </summary>
        public Guid IdPartido { get; set; }
    }

}
