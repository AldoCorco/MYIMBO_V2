using DAL.Contracts;
using DAL.Implementations;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase que gestiona la lógica de negocio relacionada con las operaciones de Localidad.
    /// </summary>
    public class LocalidadManager
    {
        private static LocalidadManager _instance;
        private readonly IGenericRepository<Localidad> _localidadRepository;

        /// <summary>
        /// Constructor privado para implementar el patrón Singleton.
        /// </summary>
        /// <param name="localidadRepository">Instancia del repositorio genérico de Localidad.</param>
        private LocalidadManager(IGenericRepository<Localidad> localidadRepository)
        {
            _localidadRepository = localidadRepository;
        }

        /// <summary>
        /// Propiedad estática que devuelve la única instancia de LocalidadManager mediante el patrón Singleton.
        /// </summary>
        public static LocalidadManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var localidadRepository = LocalidadRepository.Instance; 
                    _instance = new LocalidadManager(localidadRepository);
                }
                return _instance;
            }
        }


        //public IEnumerable<Localidad> ObtenerLocalidadPorId(Guid idLocalidad)
        //{
        //    try
        //    {
        //        // Implementa la lógica para obtener las localidades por el ID del partido
        //        return _localidadRepository.ObtenerLocalidadPorId(idLocalidad);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al obtener las localidades por partido: " + ex.Message);
        //        throw; // Puedes lanzar una excepción personalizada o manejar el error de otra manera según tus necesidades
        //    }
        //}

        /// <summary>
        /// Obtiene una Localidad por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la Localidad.</param>
        /// <returns>Objeto Localidad correspondiente al identificador proporcionado.</returns>
        public Localidad ObtenerLocalidadPorId(Guid id)
        {
            return _localidadRepository.SelectOne(id);
        }


        /// <summary>
        /// Obtiene el nombre de una Localidad por su identificador único.
        /// </summary>
        /// <param name="idLocalidad">Identificador único de la Localidad.</param>
        /// <returns>Objeto Localidad con el nombre correspondiente al identificador proporcionado.</returns>
        public Localidad ObtenerNombrelocalidadPorId(Guid? idLocalidad)
        {
            //throw new NotImplementedException();
            return _localidadRepository.SelectOne((Guid)idLocalidad);
        }


    }


}
