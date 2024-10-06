using DAL.Contracts;
using DAL.Implementations;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Gestor para operaciones relacionadas con contratos.
    /// </summary>
    public class ContratoManager
    {
        private static ContratoManager _instance;
        private readonly IGenericRepository<Contrato> _contratoRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ContratoManager.
        /// </summary>
        /// <param name="contratoRepository">Repositorio genérico de contratos.</param>
        private ContratoManager(IGenericRepository<Contrato> contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        /// <summary>
        /// Obtiene una única instancia de ContratoManager.
        /// </summary>
        public static ContratoManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var contratoRepository = ContratoRepository.Instance;

                    _instance = new ContratoManager(contratoRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
        public bool AgregarContrato(Contrato contrato)
        {
            return _contratoRepository.Add(contrato);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
        public bool ModificarContrato(Contrato contrato)
        {
            return _contratoRepository.Update(contrato);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BorrarContrato(Guid id)
        {
            return _contratoRepository.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contrato> ObtenerTodosLosContratos()
        {
            return _contratoRepository.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contrato BuscarContrato(Guid id)
        {
            return _contratoRepository.SelectOne(id);
        }
    }
}
