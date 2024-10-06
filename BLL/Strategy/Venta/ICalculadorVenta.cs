using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategy.Venta
{
    /// <summary>
    /// Interfaz que define métodos para el cálculo de distintos aspectos relacionados con la venta de propiedades.
    /// </summary>
    public interface ICalculadorVenta
    {
        /// <summary>
        /// Calcula el total del boleto de venta basado en el valor de la propiedad.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del boleto de venta.</returns>
        decimal CalcularTotalBoleto(decimal valorPropiedad);

        /// <summary>
        /// Calcula el total del impuesto asociado a la venta basado en el valor de la propiedad.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del impuesto asociado a la venta.</returns>
        decimal CalcularTotalImpuesto(decimal valorPropiedad);

        /// <summary>
        /// Calcula el valor total de dinero asociado a la propiedad, incluyendo comisiones e impuestos.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El valor total de dinero asociado a la propiedad.</returns>
        decimal CalcularTotalDineroPropiedad(decimal valorPropiedad);
    }

}
