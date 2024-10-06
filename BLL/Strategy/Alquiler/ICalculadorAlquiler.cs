using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategy.Alquiler
{
    /// <summary>
    /// Interfaz que define métodos para el cálculo de distintos aspectos relacionados con el alquiler de propiedades.
    /// </summary>
    public interface ICalculadorAlquiler
    {
        /// <summary>
        /// Realiza el cálculo del total del boleto de alquiler basado en el valor de la propiedad.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del boleto de alquiler.</returns>
        decimal CalcularTotalBoleto(decimal valorPropiedad);

        /// <summary>
        /// Realiza el cálculo del total del impuesto asociado al alquiler basado en el valor de la propiedad.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del impuesto asociado al alquiler.</returns>
        decimal CalcularTotalImpuesto(decimal valorPropiedad);

        /// <summary>
        /// Realiza el cálculo del valor total de dinero asociado a la propiedad, incluyendo comisiones e impuestos.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El valor total de dinero asociado a la propiedad.</returns>
        decimal CalcularTotalDineroPropiedad(decimal valorPropiedad);
    }

}
