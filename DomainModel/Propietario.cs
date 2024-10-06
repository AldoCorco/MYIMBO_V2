using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa a un propietario de un inmueble.
    /// </summary>
    public class Propietario
    {
        /// <summary>
        /// Obtiene o establece el identificador único del propietario.
        /// </summary>
        public Guid IdPropietario { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo asociado al propietario.
        /// </summary>
        public int LegajoPropietario { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del propietario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del propietario.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del propietario.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del propietario.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del propietario.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado al propietario.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }
    }

}
