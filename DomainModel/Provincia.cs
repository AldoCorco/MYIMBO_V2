using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa una provincia.
    /// </summary>
    public class Provincia
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la provincia.
        /// </summary>
        public Guid IdProvincia { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la provincia.
        /// </summary>
        public string NombreProvincia { get; set; }
    }

}
