using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Define las operaciones genéricas para gestionar relaciones en el sistema.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad de relación.</typeparam>
    public interface IGenericRelacion<T>
    {
        /// <summary>
        /// Agrega una nueva relación.
        /// </summary>
        /// <param name="entidadRelacion">La entidad de relación a agregar.</param>
        /// <returns>True si la operación se realizó correctamente, de lo contrario, False.</returns>

        bool AgregarRelacion(T entidadRelacion);

        /// <summary>
        /// Elimina una relación existente por su ID.
        /// </summary>
        /// <param name="idRelacion">El ID de la relación a eliminar.</param>
        /// <returns>True si la operación se realizó correctamente, de lo contrario, False.</returns>
        bool EliminarRelacion(Guid idRelacion);

        /// <summary>
        /// Obtiene todas las relaciones.
        /// </summary>
        /// <returns>Una colección de relaciones.</returns>
        IEnumerable<T> ObtenerRelaciones();

        /// <summary>
        /// Asocia un usuario con una patente.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idPatente">El ID de la patente.</param>
        /// <returns>True si la operación se realizó correctamente, de lo contrario, False.</returns>
        bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente);

        /// <summary>
        /// Asocia un usuario con una familia.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="idFamilia">El ID de la familia.</param>
        /// <returns>True si la operación se realizó correctamente, de lo contrario, False.</returns>
        bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia);
    }
}
