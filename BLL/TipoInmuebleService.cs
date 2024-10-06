using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DAL.Implementations;
using DAL.Contracts;

namespace BLL
{
    public class TipoInmuebleManager
    {
        private static TipoInmuebleManager _instance;
        private readonly IGenericRepository<TipoInmueble> _tipoInmuebleRepository;

        /// <summary>
        /// Maneja las operaciones relacionadas con los tipos de inmuebles.
        /// </summary>
        /// <param name="tipoInmuebleRepository">Repositorio de tipo de inmuebles.</param>
        private TipoInmuebleManager(IGenericRepository<TipoInmueble> tipoInmuebleRepository)
        {
            _tipoInmuebleRepository = tipoInmuebleRepository;
        }

        /// <summary>
        /// Obtiene una instancia única de TipoInmuebleManager utilizando el patrón Singleton.
        /// </summary>
        public static TipoInmuebleManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var tipoInmuebleRepository = TipoInmuebleRepository.Instance;

                    _instance = new TipoInmuebleManager(tipoInmuebleRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo tipo de inmueble.
        /// </summary>
        /// <param name="tipoInmueble">El tipo de inmueble a agregar.</param>
        /// <returns>True si se agregó correctamente, de lo contrario False.</returns>
        public bool AgregarTipoInmueble(TipoInmueble tipoInmueble)
        {
            return _tipoInmuebleRepository.Add(tipoInmueble);
        }

        /// <summary>
        /// Actualiza un tipo de inmueble existente.
        /// </summary>
        /// <param name="tipoInmueble">El tipo de inmueble actualizado.</param>
        /// <returns>True si se actualizó correctamente, de lo contrario False.</returns>
        public bool ActualizarTipoInmueble(TipoInmueble tipoInmueble)
        {
            return _tipoInmuebleRepository.Update(tipoInmueble);
        }

        /// <summary>
        /// Elimina un tipo de inmueble según su identificador.
        /// </summary>
        /// <param name="id">El identificador del tipo de inmueble a eliminar.</param>
        /// <returns>True si se eliminó correctamente, de lo contrario False.</returns>
        public bool EliminarTipoInmueble(Guid id)
        {
            return _tipoInmuebleRepository.Delete(id);
        }

        /// <summary>
        /// Obtiene todos los tipos de inmuebles disponibles.
        /// </summary>
        public IEnumerable<TipoInmueble> ObtenerTodosLosTiposDeInmuebles()
        {
            return _tipoInmuebleRepository.SelectAll();
        }

        /// <summary>
        /// Obtiene un tipo de inmueble específico por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del tipo de inmueble.</param>
        /// <returns>El tipo de inmueble correspondiente al identificador proporcionado.</returns>
        public TipoInmueble ObtenerTipoInmueblePorId(Guid id)
        {
            return _tipoInmuebleRepository.SelectOne(id);
        }

    }

}
