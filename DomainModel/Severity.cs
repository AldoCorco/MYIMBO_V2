using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Enumeración que define los distintos niveles de gravedad para reportar información en el registro (log).
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Información general.
        /// </summary>
        Info,

        /// <summary>
        /// Advertencia que indica una situación potencialmente problemática.
        /// </summary>
        Warning,

        /// <summary>
        /// Error que afecta la ejecución normal del programa.
        /// </summary>
        Error,

        /// <summary>
        /// Error crítico que puede comprometer la estabilidad del sistema.
        /// </summary>
        CriticalError,

        /// <summary>
        /// Error fatal que indica una situación grave e irreparable.
        /// </summary>
        FatalError
    }

}
