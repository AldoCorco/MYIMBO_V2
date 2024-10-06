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
    /// Clase que gestiona la lógica de negocio relacionada con las operaciones de Provincia.
    /// </summary>
    public class ProvinciaManager
    {
        private static ProvinciaManager _instance;
        private readonly IGenericRepository<Provincia> _provinciaRepository;

        /// <summary>
        /// Constructor privado para implementar el patrón Singleton.
        /// </summary>
        /// <param name="provinciaRepository">Instancia del repositorio genérico de Provincia.</param>
        private ProvinciaManager(IGenericRepository<Provincia> provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }


        /// <summary>
        /// Constructor sin parámetros. Debería usarse solo en casos específicos donde no sea necesario inicializar con un repositorio.
        /// </summary>
        public ProvinciaManager()
        {
        }

        /// <summary>
        /// Propiedad estática que devuelve la única instancia de ProvinciaManager mediante el patrón Singleton.
        /// </summary>
        public static ProvinciaManager Instance
        {
            get
            {
                if (_instance == null)
                {

                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var provinciaRepository = ProvinciaRepository.Instance; // Asegúrate de tener ProvinciaRepository implementado

                    _instance = new ProvinciaManager(provinciaRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene una Provincia por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la Provincia.</param>
        /// <returns>Objeto Provincia correspondiente al identificador proporcionado.</returns>
        public Provincia ObtenerProvinciaPorId(Guid id)
        {
            return _provinciaRepository.SelectOne(id);
        }

        /// <summary>
        /// Obtiene una Provincia por su identificador único, si el identificador es nulo devuelve null.
        /// </summary>
        /// <param name="idProvincia">Identificador único de la Provincia.</param>
        /// <returns>Objeto Provincia correspondiente al identificador proporcionado o null si el identificador es nulo.</returns>
        public Provincia ObtenerProvinciaPorId(Guid? idProvincia)
        {
            return _provinciaRepository.SelectOne((Guid)idProvincia);
        }


    }



}
