using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa un partido dentro de una provincia.
    /// </summary>
    public class Partido
    {
        /// <summary>
        /// Obtiene o establece el identificador único del partido.
        /// </summary>
        public Guid IdPartido { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la provincia a la que pertenece el partido.
        /// </summary>
        public Guid IdProvincia { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del partido.
        /// </summary>
        public string NombrePartido { get; set; }
    }

}
