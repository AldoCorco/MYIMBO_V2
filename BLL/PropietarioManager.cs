using DAL.Contracts;
using DAL.Implementations;
using DAL.Implementations.File;
using DomainModel;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con los propietarios de propiedades.
    /// </summary>
    public class PropietarioManager
    {
        private readonly ILogger logger;
        private readonly IGenericRepository<Propietario> propietarioRepository;

        private static PropietarioManager instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase PropietarioManager.
        /// </summary>
        /// <param name="propietarioRepository">Repositorio genérico de Propietario.</param>
        /// <param name="logger">Registrador de eventos.</param>
        /// <exception cref="ArgumentNullException">Se produce cuando propietarioRepository o logger son nulos.</exception>
        private PropietarioManager(IGenericRepository<Propietario> propietarioRepository, ILogger logger)
        {
            this.propietarioRepository = propietarioRepository ?? throw new ArgumentNullException(nameof(propietarioRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Proporciona una instancia única de la clase PropietarioManager utilizando el patrón Singleton.
        /// </summary>
        public static PropietarioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var propietarioRepository = PropietarioRepository.Instance;
                    var logger = new SqlLogger(); 

                    instance = new PropietarioManager(propietarioRepository, logger);
                }
                return instance;
            }
        }


        /// <summary>
        /// Agrega un propietario a una propiedad.
        /// </summary>
        /// <param name="propietario">El propietario a agregar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        //public bool AgregarPropietario(Propietario propietario)
        //{
        //    return _propietarioRepository.Add(propietario);
        //}
        public bool AgregarPropietario(Propietario propietario)
        {
            try
            {
                bool exito = propietarioRepository.Add(propietario);

                if (exito)
                {
                    // Crear un log exitoso
                    string logMessage = $"Se agregó correctamente el propietario: {propietario.Nombre}";
                    Log logSuccess = new Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logMessage,
                        Severity = Severity.Info,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log exitoso utilizando el logger
                    logger.Store(logSuccess);
                }

                return exito;
            }
            catch (Exception ex)
            {
                // En caso de error, crear log de error
                string logErrorMessage = $"Error al agregar el propietario: {ex.Message}";
                Log logError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logErrorMessage,
                    Severity = Severity.Error,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error utilizando el logger
                logger.Store(logError);

                throw new Exception(logErrorMessage, ex);
            }
        }


        /// <summary>
        /// Modifica a un propietario.
        /// </summary>
        /// <param name="propietario">El propietario modificado.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool ModificarPropietario(Propietario propietario)
        {
            try
            {
                bool actualizacionExitosa = propietarioRepository.Update(propietario);

                if (actualizacionExitosa)
                {
                    // Crear un mensaje de log exitoso
                    string logMessage = $"Se actualizó correctamente el propietario: {propietario.Nombre}";
                    Log logSuccess = new Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logMessage,
                        Severity = Severity.Info,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log exitoso utilizando el logger
                    logger.Store(logSuccess);

                }
                else
                {
                    // Crear un mensaje de log de error
                    string logErrorMessage = "Error al actualizar el propietario. Por favor, inténtelo de nuevo.";
                    Log logError = new Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);
                }

                return actualizacionExitosa;
            }
            catch (Exception ex)
            {
                // Crear un mensaje de log de error crítico
                string logCriticalErrorMessage = $"Error crítico al modificar el propietario: {ex.Message}";
                Log logCriticalError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logCriticalErrorMessage,
                    Severity = Severity.CriticalError,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error crítico utilizando el logger
                logger.Store(logCriticalError);

                throw; // Re-throw la excepción para que sea manejada en un nivel superior si es necesario
            }
        }


        /// <summary>
        /// Borra a un propietario.
        /// </summary>
        /// <param name="id">El ID del propietario a borrar.</param>
        /// <returns>True si la operación fue exitosa, False en caso contrario.</returns>
        public bool BorrarPropietario(Guid id)
        {
            try
            {
                // Obtener el propietario antes de borrarlo para el log y para comprobar si existe
                Propietario propietarioAntesDeBorrar = propietarioRepository.SelectOne(id);

                //if (propietarioAntesDeBorrar == null)
                //{
                //    // Crear un mensaje de log de advertencia
                //    string logWarningMessage = $"No se encontró el propietario con ID: {id}. No se realizó la operación de borrado.";
                //    Log logWarning = new Log
                //    {
                //        IdLog = Guid.NewGuid(),
                //        Message = logWarningMessage,
                //        Severity = Severity.Warning,
                //        Fecha_txr = DateTime.Now
                //    };

                //    // Guardar el log de advertencia utilizando el logger
                //    logger.Store(logWarning);

                //    // Mostrar mensaje al usuario
                //    MessageBox.Show($"No se encontró el propietario con ID: {id}. No se realizó la operación de borrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    return false;
                //}

                // Llamar al método en PropietarioRepository para borrar el propietario
                bool borradoExitoso = propietarioRepository.Delete(id);

                if (borradoExitoso)
                {
                    // Crear un mensaje de log exitoso
                    string logMessage = $"Se borró correctamente el propietario con ID: {id}";
                    Log logSuccess = new Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logMessage,
                        Severity = Severity.Info,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log exitoso utilizando el logger
                    logger.Store(logSuccess);

                    return true;
                }
                else
                {
                    // Crear un mensaje de log de error
                    string logErrorMessage = "Error al intentar borrar el propietario.";
                    Log logError = new Log
                    {
                        IdLog = Guid.NewGuid(),
                        Message = logErrorMessage,
                        Severity = Severity.Error,
                        Fecha_txr = DateTime.Now
                    };

                    // Guardar el log de error utilizando el logger
                    logger.Store(logError);

                    return false;
                }
            }
            catch (Exception ex)
            {
                // Crear un mensaje de log de error crítico
                string logCriticalErrorMessage = $"Error crítico al intentar borrar el propietario: {ex.Message}";
                Log logCriticalError = new Log
                {
                    IdLog = Guid.NewGuid(),
                    Message = logCriticalErrorMessage,
                    Severity = Severity.CriticalError,
                    Fecha_txr = DateTime.Now
                };

                // Guardar el log de error crítico utilizando el logger
                logger.Store(logCriticalError);

                // Propagar la excepción para que pueda ser manejada en la capa superior si es necesario
                throw;
            }
        }




        /// <summary>
        /// Obtiene todos los propietarios.
        /// </summary>
        /// <returns>Una colección de propietarios.</returns>
        public IEnumerable<Propietario> ObtenerTodosLosPropietarios()
        {
            return propietarioRepository.SelectAll();
        }

        /// <summary>
        /// Busca un propietario por el ID de la propiedad.
        /// </summary>
        /// <param name="id">El ID de la propiedad.</param>
        /// <returns>El propietario asociado a la propiedad.</returns>
        public Propietario BuscarPropietarioPorPropiedad(Guid id)
        {
            return propietarioRepository.SelectOne(id);
        }
    }
}
