using DAL;
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
    /// Gestiona las operaciones relacionadas con las propiedades inmobiliarias.
    /// </summary>
    public class InmobiliariaManager
    {
        private static InmobiliariaManager _instance;
        private readonly IGenericRepository<Inmobiliaria> _inmobiliariaRepository;

        /// <summary>
        /// Gestiona las operaciones relacionadas con las propiedades inmobiliarias.
        /// </summary>
        /// <param name="inmobiliariaRepository">Repositorio para acceder a los datos de las propiedades inmobiliarias.</param>
        private InmobiliariaManager(IGenericRepository<Inmobiliaria> inmobiliariaRepository)
        {
            _inmobiliariaRepository = inmobiliariaRepository;
        }

        /// <summary>
        /// Proporciona una instancia única de InmobiliariaManager utilizando el patrón Singleton.
        /// </summary>
        public static InmobiliariaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var inmobiliariaRepository = InmobiliariaRepository.Instance;

                    _instance = new InmobiliariaManager(inmobiliariaRepository);
                }
                return _instance;
            }
        }


        /// <summary>
        /// Registra una operación de venta en el sistema.
        /// </summary>
        /// <param name="inmobiliaria">Objeto Inmobiliaria que representa la operación de venta.</param>
        /// <returns>True si la operación se registró correctamente, de lo contrario False.</returns>
        public bool RegistrarOperacionVenta(Inmobiliaria inmobiliaria)
        {
            return _inmobiliariaRepository.Add(inmobiliaria);
        }


        /// <summary>
        /// Registra una operación de compra en el sistema.
        /// </summary>
        /// <param name="inmobiliaria">Objeto Inmobiliaria que representa la operación de compra.</param>
        /// <returns>True si la operación se registró correctamente, de lo contrario False.</returns>
        public bool RegistrarOperacionCompra(Inmobiliaria inmobiliaria)
        {
            return _inmobiliariaRepository.Add(inmobiliaria);
        }

        /// <summary>
        /// Registra una operación de compra en el sistema.
        /// </summary>
        /// <param name="inmobiliaria">Objeto Inmobiliaria que representa la operación de reserva del alquiler.</param>
        /// <returns>True si la operación se registró correctamente, de lo contrario False.</returns>
        public bool RegistrarOperacionResevaAlquiler(Inmobiliaria inmobiliaria)
        {
            return _inmobiliariaRepository.Add(inmobiliaria);
        }

        

        //public bool EliminarOperacion(Guid id)
        //{
        //    return _inmobiliariaRepository.Delete(id);
        //}


    }
}
