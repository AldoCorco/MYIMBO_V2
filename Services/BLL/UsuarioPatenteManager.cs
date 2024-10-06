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
    /// Gestiona las operaciones relacionadas con las relaciones entre usuarios y patentes.
    /// </summary>
    public class UsuarioPatenteManager
    {
        private static UsuarioPatenteManager _instance;
        private readonly IGenericRepository<DAL.Contracts.UsuarioPatente> _usuariopatenteRepository;

        /// <summary>
        /// Constructor privado para evitar instanciación directa.
        /// </summary>
        /// <param name="usuariopatenteRepository">El repositorio de relaciones usuario-patente.</param>
        private UsuarioPatenteManager(IGenericRepository<DAL.Contracts.UsuarioPatente> usuariopatenteRepository)
        {
            _usuariopatenteRepository = usuariopatenteRepository;
        }

        /// <summary>
        /// Obtiene la instancia única del gestor de relaciones usuario-patente.
        /// </summary>
        public static UsuarioPatenteManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var usuariopatenteRepository = UsuarioPatenteRepository.Instance;

                    _instance = new UsuarioPatenteManager(usuariopatenteRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene todas las relaciones usuario-patente.
        /// </summary>
        /// <returns>Una colección de relaciones usuario-patente.</returns>
        public IEnumerable<DAL.Contracts.UsuarioPatente> ListarUsuarioPermisos()
        {
            return _usuariopatenteRepository.SelectAll();

        }

    }

}
