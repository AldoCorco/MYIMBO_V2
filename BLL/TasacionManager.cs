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
    /// Gestiona las operaciones relacionadas con las tasaciones de propiedades.
    /// </summary>
    public class TasacionManager
    {
        private static TasacionManager _instance;
        private readonly IGenericRepository<Tasacion> _tasacionRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase TasacionManager.
        /// </summary>
        /// <param name="tasacionRepository">Repositorio genérico para acceder a los datos de las tasaciones.</param>
        private TasacionManager(IGenericRepository<Tasacion> tasacionRepository)
        {
            _tasacionRepository = tasacionRepository;
        }

        /// <summary>
        /// Obtiene una instancia única de TasacionManager utilizando el patrón Singleton.
        /// </summary>
        public static TasacionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var tasacionRepository = TasacionRepository.Instance;

                    _instance = new TasacionManager(tasacionRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Método para agregar la tasación
        /// </summary>
        /// <param name="tasacion"></param>
        /// <returns></returns>
        public bool AgregarTasacion(Tasacion tasacion)
        {
            return _tasacionRepository.Add(tasacion);
        }

        /// <summary>
        /// Método para actualizar la tasación
        /// </summary>
        /// <param name="tasacion"></param>
        /// <returns></returns>
        public bool ActualizarTasacion(Tasacion tasacion)
        {
            return _tasacionRepository.Update(tasacion);
        }

        /// <summary>
        /// Método para borrar la tasación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EliminarTasacion(Guid id)
        {
            return _tasacionRepository.Delete(id);
        }

        /// <summary>
        /// Método para obtener una tasación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tasacion ObtenerTasacionPorId(Guid id)
        {
            return _tasacionRepository.SelectOne(id);
        }


    }
}
