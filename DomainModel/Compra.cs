using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Clase que representa un comprador de un inmueble.
    /// </summary>
    public class Compra
    {
        /// <summary>
        /// Obtiene o establece el identificador único del comprador.
        /// </summary>
        public Guid IdComprador { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo asociado al comprador.
        /// </summary>
        public int LegajoComprador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del comprador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del comprador.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del comprador.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del comprador.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del comprador.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tipo de inmueble de interés para el comprador.
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
        /// Obtiene o establece el impuesto asociada a la venta en formato de cadena.
        /// </summary>
        public decimal Impuesto { get; set; }

        /// <summary>
        /// Obtiene o establece valor total de la propiedad asociada a la venta en formato de cadena.
        /// </summary>
        public decimal TotalPropiedad { get; set; }

        /// <summary>
        /// Obtiene o establece el estado activo o inactivo de la operación.
        /// </summary>
        public string Activo { get; set; }
    }

}
