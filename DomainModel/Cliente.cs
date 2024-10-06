using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa un cliente o inquilino.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo asociado al inquilino.
        /// </summary>
        public int LegajoInquilino { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del cliente.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del cliente.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del cliente.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del cliente.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble asociado al contrato.
        /// </summary>
        public Guid IdTipoInmueble { get; set; }
    }

}
