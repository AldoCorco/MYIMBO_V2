using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Strategy.Alquiler
{
    /// <summary>
    /// Clase concreta que implementa la interfaz <see cref="ICalculadorAlquiler"/> para el cálculo específico de propiedades tipo casa.
    /// </summary>
    public class CalculadorCasa : ICalculadorAlquiler
    {
        /// <summary>
        /// Calcula el total del boleto de alquiler para una propiedad tipo casa.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El total del boleto de alquiler.</returns>
        public decimal CalcularTotalBoleto(decimal valorPropiedad)
        {
            // Comisión del 12%
            decimal comision12 = 0.12m;

            return valorPropiedad * comision12;
        }

        /// <summary>
        /// Calcula el valor total de dinero asociado a la propiedad tipo casa, incluyendo comisiones e impuestos.
        /// </summary>
        /// <param name="valorPropiedad">El valor de la propiedad sobre la cual se realiza el cálculo.</param>
        /// <returns>El valor total de dinero asociado a la propiedad tipo casa.</returns>
        public decimal CalcularTotalDineroPropiedad(decimal valorPropiedad)
        {
            decimal totalBoleto = CalcularTotalBoleto(valorPropiedad);
            decimal totalImpuesto = CalcularTotalImpuesto(valorPropiedad);

            return valorPropiedad + totalBoleto + totalImpuesto;
        }

        /// <summary>
        /// Calcula el total del impuesto asociado al alquiler de una propiedad tipo casa.
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
