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
    public class ClienteManager
    {
        private static ClienteManager _instance;
        private readonly IGenericRepository<Cliente> _clienteRepository;

        private ClienteManager(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public static ClienteManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var clienteRepository = ClienteRepository.Instance;

                    _instance = new ClienteManager(clienteRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente ObtenerCliente(Guid id)
        {
            return _clienteRepository.SelectOne(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool AgregarCliente(Cliente cliente)
        {
            return _clienteRepository.Add(cliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool ModificarCliente(Cliente cliente)
        {
            return _clienteRepository.Update(cliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BorrarCliente(Guid id)
        {
            return _clienteRepository.Delete(id);
        }
    }
}
