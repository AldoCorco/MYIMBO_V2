using DAL.Implementations;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;

namespace BLL
{
    /// <summary>
    /// Gestor para operaciones relacionadas con escribanías.
    /// </summary>
    public class EscribaniaManager
    {
        private static EscribaniaManager _instance;
        private readonly IGenericRepository<Escribania> _escribaniaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase EscribaniaManager.
        /// </summary>
        /// <param name="escribaniaRepository">Repositorio genérico de escribanías.</param>
        private EscribaniaManager(IGenericRepository<Escribania> escribaniaRepository)
        {
            _escribaniaRepository = escribaniaRepository;
        }


        /// <summary>
        /// Obtiene una única instancia de EscribaniaManager.
        /// </summary>
        public static EscribaniaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var escribaniaRepository = EscribaniaRepository.Instance;

                    _instance = new EscribaniaManager(escribaniaRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Método para agregar una Escribania
        /// </summary>
        /// <param name="escribania"></param>
        /// <returns></returns>
        public bool AgregarEscribania(Escribania escribania)
        {
            return _escribaniaRepository.Add(escribania);
        }


        /// <summary>
        /// Método actualizar una Escribania
        /// </summary>
        /// <param name="escribania"></param>
        /// <returns></returns>
        public bool ActualizarEscribania(Escribania escribania)
        {
            return _escribaniaRepository.Update(escribania);
        }

        /// <summary>
        /// Método para borrar una Escribania
        /// </summary>
        /// <param name="id">Uso el id como parametro</param>
        /// <returns></returns>
        public bool EliminarEscribania(Guid id)
        {
            return _escribaniaRepository.Delete(id);
        }

        /// <summary>
        /// Método para listar todas las Escribania
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Escribania> ObtenerTodasLasEscribanias()
        {
            return _escribaniaRepository.SelectAll();
        }

        /// <summary>
        /// Obtiene una escribanía por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la escribanía.</param>
        /// <returns>La escribanía encontrada o null si no se encuentra.</returns>
        public Escribania ObtenerEscribaniaPorId(Guid id)
        {
            return _escribaniaRepository.SelectOne(id);
        }

    }


}