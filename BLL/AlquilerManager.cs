using DAL.Implementations;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using System.Windows.Forms;

namespace BLL
{
    /// <summary>
    /// Gestor para administrar operaciones relacionadas con alquileres.
    /// </summary>
    public class AlquilerManager
    {
        private static AlquilerManager _instance;
        private readonly IGenericRepository<Alquiler> _alquilerRepository;

        /// <summary>
        /// Constructor privado para crear una nueva instancia de AlquilerManager.
        /// </summary>
        /// <param name="alquilerRepository">Repositorio de alquileres.</param>
        private AlquilerManager(IGenericRepository<Alquiler> alquilerRepository)
        {
            _alquilerRepository = alquilerRepository;
        }

        /// <summary>
        /// Obtiene una instancia única de AlquilerManager utilizando el patrón Singleton.
        /// </summary>
        public static AlquilerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var alquilerRepository = AlquilerRepository.Instance;

                    _instance = new AlquilerManager(alquilerRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Veficico si es mayor de 21 años, para habilitar las siguiente condición
        /// </summary>
        /// <param name="edad"></param>
        /// <param name="checkBox1"></param>
        /// <param name="checkBox2"></param>
        /// <returns></returns>

        public string VerificarEdad(int edad, bool checkBox1, bool checkBox2)
        {
            if (edad >= 21)
            {
                // La edad es mayor o igual a 21, verifica las otras condiciones usando el método existente
                return VerificarCondiciones(checkBox1, checkBox2);
            }
            else
            {
                // La edad no es suficiente para alquilar
                return "Edad no permitida para alquilar";
            }
        }

        /// <summary>
        /// Valido si estan tildadas las validaciones de las garantias
        /// </summary>
        /// <param name="checkBox1">Garantia</param>
        /// <param name="checkBox2">Recibo de Sueldo</param>
        /// <returns></returns>
        private string VerificarCondiciones(bool checkBox1, bool checkBox2)
        {
            if (!checkBox1 && checkBox2)
            {
                return "Falta Presentar Garantia";
            }
            else if (checkBox1 && !checkBox2)
            {
                return "Falta Presentar Recibo de Sueldo";
            }
            else if (!checkBox1 && !checkBox2)
            {
                MostrarAlerta("Debe Presentar Garantia y Recibo de Sueldo");
                return "Falta Presentar Garantia y Recibo de Sueldo";
            }
            else
            {
                return "Requisitos de documentación completados";
                //return;
            }
        }

        private void MostrarAlerta(string mensaje)
        {
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// <summary>
        /// Método para validar que el importe de la reserva sea mayor o igual a 1500.
        /// </summary>
        /// <param name="importeReserva">Importe de la reserva a validar.</param>
        /// <returns>True si el importe es válido, false si es menor a 1500.</returns>
        public bool ValidarImporteReserva(int importeReserva)
        {
            return importeReserva >= 1500;
        }

        /// <summary>
        /// Método para agregar la reserva de alquiler
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public bool ReservaPropiedad(Alquiler alquiler)
        {
            return _alquilerRepository.Add(alquiler);
        }

        /// <summary>
        /// Método para actualizar la reserva de alquiler
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public bool ActualizarReserva(Alquiler alquiler)
        {
            return _alquilerRepository.Update(alquiler);
        }


        /// <summary>
        /// Método para eliminar la reserva de alquiler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CancelarReserva(Guid id)
        {
            return _alquilerRepository.Delete(id);
        }

        

        /// <summary>
        /// Verifica si ya existe una reserva para la propiedad asociada al alquiler.
        /// </summary>
        /// <param name="id">ID de la pripiedad que voy a alquilar.</param>
        /// <returns>True si ya tiene reserva, False si no tiene reserva.</returns>
        public Alquiler VerificarSiTieneReserva(Guid id)
        {
            return _alquilerRepository.SelectReserva(id);

        }

        /// <summary>
        /// Obtiene un alquiler por su ID.
        /// </summary>
        /// <param name="id">ID del alquiler.</param>
        /// <returns>El alquiler correspondiente al ID proporcionado.</returns>
        public Alquiler AptoContrato(Guid id)
        {
            return _alquilerRepository.SelectOne(id);

        }

        /// <summary>
        /// Busca una reserva por su ID.
        /// </summary>
        /// <param name="id">ID de la reserva a buscar.</param>
        /// <returns>La reserva correspondiente al ID proporcionado.</returns>
        public Alquiler BuscarReserva(Guid id)
        {
            return _alquilerRepository.SelectOne(id);

        }

        /// <summary>
        /// Obtiene una lista de todas las propiedades con reservas.
        /// </summary>
        /// <returns>Una lista de alquileres que representan propiedades con reservas.</returns>
        public List<Alquiler> ObtenerPropiedadesConReserva()
        {
            return (List<Alquiler>)_alquilerRepository.SelectAll();
        }

    }
}
