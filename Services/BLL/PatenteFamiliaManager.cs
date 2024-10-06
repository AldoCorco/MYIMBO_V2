using DomainModel;
using Services.DAL.Contracts;
using Services.DAL.Implementations;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con la asignación de patentes a familias.
    /// </summary>
    public class PatenteFamiliaManager
    {
        private static PatenteFamiliaManager _instance;
        private readonly IGenericRepository<PatenteFamilia> _patenteFamiliaRepository;
        private PatenteFamiliaRepository patenteFamiliaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PatenteFamiliaManager"/>.
        /// </summary>
        /// <param name="patenteFamiliaRepository">El repositorio de asignación de patentes a familias.</param>
        public PatenteFamiliaManager(PatenteFamiliaRepository patenteFamiliaRepository)
        {
            this.patenteFamiliaRepository = patenteFamiliaRepository;
        }


        private PatenteFamiliaManager(IGenericRepository<PatenteFamilia> patenteFamiliaRepository)
        {
            _patenteFamiliaRepository = patenteFamiliaRepository;
        }

        /// <summary>
        /// Proporciona acceso a una única instancia de <see cref="PatenteFamiliaManager"/>.
        /// </summary>
        public static PatenteFamiliaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var patenteFamiliaRepository = PatenteFamiliaRepository.Instance;

                    _instance = new PatenteFamiliaManager(patenteFamiliaRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Representa la identificación de una patente.
        /// </summary>
        public Patente IdPatente { get; private set; }

        /// <summary>
        /// Obtiene una colección de roles y permisos.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="PatenteFamilia"/>.</returns>
        public IEnumerable<PatenteFamilia> ListarRolesPermisos()
        {
            //Muestro todos los usuario al iniciar el formulario
            return _patenteFamiliaRepository.SelectAll();
        }

        /// <summary>
        /// Obtiene la asociación de un rol y permiso específico mediante su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la asociación.</param>
        /// <returns>La asociación de rol y permiso correspondiente al identificador proporcionado.</returns>
        public PatenteFamilia ObtenerFamilia(Guid id)
        {
            return _patenteFamiliaRepository.SelectOne(id);

        }

        
    }
}
