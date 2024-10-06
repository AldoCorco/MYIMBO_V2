using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.CompositeSeguridad
{
    /// <summary>
    /// clase Familia
    /// </summary>
    public class Familia
    {
        /// <summary>
        /// IdFamilia
        /// </summary>
        public Guid IdFamilia { get; set; }

        /// <summary>
        /// NombreRol
        /// </summary>
        public string NombreRol { get; set; }

        /// <summary>
        /// Fecha_Familia
        /// </summary>
        public DateTime Fecha_Familia { get; set; }

        /// <summary>
        /// Patentes
        /// </summary>
        public object Patentes { get; internal set; }

        /// <summary>
        /// IdUsuario
        /// </summary>
        public Guid IdUsuario { get; internal set; }

        /// <summary>
        /// IdPatente
        /// </summary>
        public Guid IdPatente { get; internal set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        public DateTime FechaCreacion { get; internal set; }

        /// <summary>
        /// FechaCreacionFP
        /// </summary>
        public DateTime FechaCreacionFP { get; internal set; }

        /// <summary>
        /// Usu_nom
        /// </summary>
        public string Usu_nom { get; internal set; }

        /// <summary>
        /// FechaCreacionUF
        /// </summary>
        public DateTime FechaCreacionUF { get; internal set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; internal set; }

        /// <summary>
        /// Tipo de usuario ADMIN
        /// </summary>
        public string EsAdmin { get; internal set; }
        //public List<Patente> Patentes { get; set; } = new List<Patente>();
    }

}
