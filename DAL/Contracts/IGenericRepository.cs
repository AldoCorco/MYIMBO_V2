using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    /// <summary>
    /// Interfaz genérica para operaciones básicas en un repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto del repositorio.</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Método genérico para agregar un objeto.
        /// </summary>
        /// <param name="obj">Objeto a agregar.</param>
        /// <returns>Devuelve true si la operación fue exitosa, de lo contrario, false.</returns>
        bool Add(T obj);

        /// <summary>
        /// Método genérico para actualizar un objeto.
        /// </summary>
        /// <param name="obj">Objeto a actualizar.</param>
        /// <returns>Devuelve true si la operación fue exitosa, de lo contrario, false.</returns>
        bool Update(T obj);

        /// <summary>
        /// Método genérico para borrar un objeto por su ID.
        /// </summary>
        /// <param name="id">ID del objeto a borrar.</param>
        /// <returns>Devuelve true si la operación fue exitosa, de lo contrario, false.</returns>
        bool Delete(Guid id);

        /// <summary>
        /// Método genérico para seleccionar un objeto por su ID.
        /// </summary>
        /// <param name="id">ID del objeto a seleccionar.</param>
        /// <returns>El objeto seleccionado o null si no se encuentra.</returns>
        T SelectOne(Guid id);

        /// <summary>
        /// Método genérico para seleccionar todos los objetos en el repositorio.
        /// </summary>
        /// <returns>Una colección de todos los objetos en el repositorio.</returns>
        IEnumerable<T> SelectAll();


        /// <summary>
        /// Método para obtener las provincias de un partido específico.
        /// </summary>
        /// <param name="partidoId">ID del partido.</param>
        /// <returns>Una colección de provincias asociadas al partido.</returns>
        IEnumerable<Provincia> ObtenerProvincias(Guid partidoId);

        /// <summary>
        /// Método para obtener los partidos de una provincia específica.
        /// </summary>
        /// <param name="provinciaId">ID de la provincia.</param>
        /// <returns>Una colección de partidos asociados a la provincia.</returns>
        IEnumerable<Partido> ObtenerPartidosPorId(Guid provinciaId);

        /// <summary>
        /// Método para obtener las localidades de un partido específico.
        /// </summary>
        /// <param name="partidoId">ID del partido.</param>
        /// <returns>Una colección de localidades asociadas al partido.</returns>
        IEnumerable<Localidad> ObtenerLocalidadPorId(Guid partidoId);

        /// <summary>
        /// Método para seleccionar una reserva por su ID.
        /// </summary>
        /// <param name="id">ID de la reserva.</param>
        /// <returns>La reserva seleccionada o null si no se encuentra.</returns>
        Alquiler SelectReserva(Guid id);
    }
}
