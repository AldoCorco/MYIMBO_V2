using Services.DAL.Contracts;
using Services.DAL.Implementations;
using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    /// <summary>
    /// Gestor de operaciones relacionadas con las familias.
    /// </summary>
    public class FamiliaManager
    {
        private static FamiliaManager _instance;
        private readonly IGenericRepository<Familia> _familiaRepository;

        /// <summary>
        /// Constructor privado para evitar la instancia directa. Utiliza el patrón Singleton.
        /// </summary>
        /// <param name="familiaRepository">Repositorio de familias.</param>
        private FamiliaManager(IGenericRepository<Familia> familiaRepository)
        {
            _familiaRepository = familiaRepository;
        }

        /// <summary>
        /// Obtiene la instancia única del gestor de familias.
        /// </summary>
        public static FamiliaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var familiaRepository = FamiliaRepository.Instance;

                    _instance = new FamiliaManager(familiaRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las familias.
        /// </summary>
        /// <returns>Una colección de objetos Familia que representan todas las familias.</returns>
        public IEnumerable<Familia> ListarFamilias()
        {
            //Muestro todos los usuario al iniciar el formulario
            return _familiaRepository.SelectAll();
        }

        /// <summary>
        /// Verifica si existe un rol con el nombre especificado.
        /// </summary>
        /// <param name="nombreRol">El nombre del rol a verificar.</param>
        /// <returns>True si existe un rol con el nombre especificado, de lo contrario False.</returns>
        public bool ExisteRol(string nombreRol)
        {
            //throw new NotImplementedException();
            return _familiaRepository.ExisteRol(nombreRol);
        }

        /// <summary>
        /// Crea un nuevo rol en el sistema.
        /// </summary>
        /// <param name="familia">La familia que se va a crear como rol.</param>
        /// <returns>True si se crea con éxito, de lo contrario False.</returns>
        public bool CrearRol(Familia familia)
        {
            // Llamar al método en la capa DAL para crear el rol.
            return _familiaRepository.Add(familia);

        }

        /// <summary>
        /// Modifica una familia existente en el sistema.
        /// </summary>
        /// <param name="familia">La familia que se va a modificar.</param>
        /// <returns>True si se modifica con éxito, de lo contrario False.</returns>
        public bool ModificarFamilia(Familia familia)
        {
            //throw new NotImplementedException();
            return _familiaRepository.Update(familia);
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario del cual se desean obtener las familias.</param>
        /// <returns>Una lista de familias asociadas al usuario.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no ha sido implementado.</exception>
        private List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            // Implementa la lógica para obtener las familias asociadas al usuario.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Crea un rol para un usuario.
        /// </summary>
        /// <returns>True si se crea el rol correctamente, de lo contrario False.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el método no ha sido implementado.</exception>
        public bool CrearRolParaUsuario()
        {
            // Implementa la lógica para obtener las familias asociadas al usuario.
            throw new NotImplementedException();
            
        }
    }
}
