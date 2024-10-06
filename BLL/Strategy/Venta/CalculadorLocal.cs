using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategy.Venta
{
    /// <summary>
    /// Clase concreta que implementa la interfaz <see cref="ICalculadorVenta"/> para el cálculo específico de propiedades tipo local comercial.
    /// </summary>
    public class CalculadorLocal : ICalculadorVenta
    {
        /// <summary>
        /// Calcula el total del boleto de venta para una propiedad tipo local comercial.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del boleto de venta.</returns>
        public decimal CalcularTotalBoleto(decimal valorPropiedad)
        {
            // Comisión del 20%
            decimal comision20 = 0.2m;

            return valorPropiedad * comision20;
        }

        /// <summary>
        /// Calcula el valor total de dinero asociado a la venta de una propiedad tipo local comercial, incluyendo comisiones e impuestos.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El valor total de dinero asociado a la venta de la propiedad tipo local comercial.</returns>
        public decimal CalcularTotalDineroPropiedad(decimal valorPropiedad)
        {
            decimal totalBoleto = CalcularTotalBoleto(valorPropiedad);
            decimal totalImpuesto = CalcularTotalImpuesto(valorPropiedad);

            return valorPropiedad + totalBoleto + totalImpuesto;
        }

        /// <summary>
        /// Calcula el total del impuesto asociado a la venta de una propiedad tipo local comercial.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del impuesto asociado a la venta.</returns>
        public decimal CalcularTotalImpuesto(decimal valorPropiedad)
        {
            // Impuesto del 15%
            decimal impuesto15 = 0.15m;

            return valorPropiedad * impuesto15;
        }
    }

}
