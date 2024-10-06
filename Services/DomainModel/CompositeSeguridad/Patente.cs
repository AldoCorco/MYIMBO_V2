using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.CompositeSeguridad
{
    /// <summary>
    /// Representa una patente de permiso en el sistema.
    /// </summary>
    public class Patente
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la patente.
        /// </summary>
        public Guid IdPatente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del permiso.
        /// </summary>
        public string NombrePermiso { get; set; }

        /// <summary>
        /// Obtiene o establece la vista asociada al permiso.
        /// </summary>
        public string Vista { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación de la patente.
        /// </summary>
        public DateTime Fecha_Patente { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del usuario asociado a la patente.
        /// </summary>
        public Guid IdUsuario { get; internal set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación de la patente.
        /// </summary>
        public DateTime FechaCreacion { get; internal set; }

        /// <summary>
        /// Obtiene o establece el identificador del permiso padre.
        /// </summary>
        public object PermisoPadreId { get; internal set; }

        /// <summary>
        /// Obtiene o establece el nombre del permiso padre.
        /// </summary>
        public string PermisoPadreNombre { get; internal set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string Usu_nom { get; internal set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del usuario.
        /// </summary>
        public string Nombre_Completo { get; internal set; }
    }

}
