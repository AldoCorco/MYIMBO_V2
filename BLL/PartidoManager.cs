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
    /// Clase que gestiona la lógica de negocio relacionada con las operaciones de Partido.
    /// </summary>
    public class PartidoManager
    {
        private static PartidoManager _instance;
        private readonly IGenericRepository<Partido> _partidoRepository;

        /// <summary>
        /// Constructor privado para implementar el patrón Singleton.
        /// </summary>
        /// <param name="partidoRepository">Instancia del repositorio genérico de Partido.</param>
        private PartidoManager(IGenericRepository<Partido> partidoRepository)
        {
            _partidoRepository = partidoRepository;
        }

        /// <summary>
        /// Propiedad estática que devuelve la única instancia de PartidoManager mediante el patrón Singleton.
        /// </summary>
        public static PartidoManager Instance
        {
            get
            {
                if (_instance == null)
                {

                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var partidoRepository = PartidoRepository.Instance; 

                    _instance = new PartidoManager(partidoRepository);


                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene el nombre de un Partido por su identificador único.
        /// </summary>
        /// <param name="idPartido">Identificador único del Partido.</param>
        /// <returns>Objeto Partido con el nombre correspondiente al identificador proporcionado.</returns>
        public Partido ObtenerNombrePartidoPorId(Guid? idPartido)
        {
            return _partidoRepository.SelectOne((Guid)idPartido);
        }


        //public IEnumerable<Partido> ObtenerPartidosPorId(Guid provinciaId)
        //{
        //    // Implementa la lógica para obtener los partidos según el ID de la provincia
        //    return _partidoRepository.ObtenerPartidosPorId(provinciaId);
        //}

        /// <summary>
        /// Obtiene un Partido por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del Partido.</param>
        /// <returns>Objeto Partido correspondiente al identificador proporcionado.</returns>
        public Partido ObtenerPartidosPorId(Guid id)
        {
            return _partidoRepository.SelectOne(id);

        }

    }

}
