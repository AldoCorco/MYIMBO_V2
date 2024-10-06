using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategy.Alquiler
{
    /// <summary>
    /// Clase concreta que implementa la interfaz <see cref="ICalculadorAlquiler"/> para el cálculo específico de propiedades tipo local comercial.
    /// </summary>
    public class CalculadorLocal : ICalculadorAlquiler
    {
        /// <summary>
        /// Calcula el total del boleto de alquiler para una propiedad tipo local comercial.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del boleto de alquiler.</returns>
        public decimal CalcularTotalBoleto(decimal valorPropiedad)
        {
            // Comisión del 7%
            decimal comision7 = 0.07m;

            return valorPropiedad * comision7;
        }

        /// <summary>
        /// Calcula el valor total de dinero asociado a la propiedad tipo local comercial, incluyendo comisiones e impuestos.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El valor total de dinero asociado a la propiedad tipo local comercial.</returns>
        public decimal CalcularTotalDineroPropiedad(decimal valorPropiedad)
        {
            decimal totalBoleto = CalcularTotalBoleto(valorPropiedad);
            decimal totalImpuesto = CalcularTotalImpuesto(valorPropiedad);

            return valorPropiedad + totalBoleto + totalImpuesto;
        }

        /// <summary>
        /// Calcula el total del impuesto asociado al alquiler de una propiedad tipo local comercial.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del impuesto asociado al alquiler.</returns>
        public decimal CalcularTotalImpuesto(decimal valorPropiedad)
        {
            // Impuesto del 5%
            decimal impuesto5 = 0.05m;

            return valorPropiedad * impuesto5;
        }
    }

}
