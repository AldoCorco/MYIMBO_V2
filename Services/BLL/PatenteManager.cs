using DomainModel;
using Services.DAL.Contracts;
using Services.DAL.Implementations;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.BLL
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con las patentes.
    /// </summary>
    public class PatenteManager
    {
        private static PatenteManager _instance;
        private readonly IGenericRepository<Patente> _patenteRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PatenteManager"/>.
        /// </summary>
        /// <param name="patenteRepository">Repositorio de patentes.</param>
        private PatenteManager(IGenericRepository<Patente> patenteRepository)
        {
            _patenteRepository = patenteRepository;
        }

        /// <summary>
        /// Obtiene una instancia única de la clase <see cref="PatenteManager"/>.
        /// </summary>
        public static PatenteManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var patenteRepository = PatenteRepository.Instance;

                    _instance = new PatenteManager(patenteRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene todas las patentes disponibles.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="Patente"/>.</returns>
        public IEnumerable<Patente> ListarPatentes()
        {
            //Muestro todos los usuario al iniciar el formulario
            return _patenteRepository.SelectAll();
        }

        /// <summary>
        /// Crea un nuevo permiso de patente en el sistema.
        /// </summary>
        /// <param name="patente">La patente a crear.</param>
        /// <returns>True si se creó exitosamente; de lo contrario, false.</returns>
        public bool CrearPatentePermiso(Patente patente)
        {
            return _patenteRepository.Add(patente);
            
        }

        /// <summary>
        /// Verifica si un permiso de patente ya existe en el sistema.
        /// </summary>
        /// <param name="nombrePermiso">El nombre del permiso a verificar.</param>
        /// <returns>True si el permiso existe; de lo contrario, false.</returns>
        public bool ExistePermisoPatente(string nombrePermiso)
        {
            //throw new NotImplementedException();
            return _patenteRepository.ExistePermiso(nombrePermiso);
        }

        /// <summary>
        /// Convierte implícitamente un objeto <see cref="PatenteFamiliaManager"/> a un <see cref="PatenteManager"/>.
        /// </summary>
        /// <param name="v">El objeto <see cref="PatenteFamiliaManager"/> a convertir.</param>
        public static implicit operator PatenteManager(PatenteFamiliaManager v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una patente por su ID.
        /// </summary>
        /// <param name="patente">La patente cuyo ID se utilizará para la búsqueda.</param>
        /// <returns>La patente encontrada.</returns>
        public Patente ObtenerPorId(Patente patente)
        {
            return _patenteRepository.SelectOne(patente);

        }
    }

    
}
