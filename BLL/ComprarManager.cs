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
    public class ComprarManager
    {
        private static ComprarManager _instance;
        private readonly IGenericRepository<Compra> compraRepository;
        private readonly ILogger logger;

        /// <summary>
        /// Crea una nueva instancia de ComprarManager.
        /// </summary>
        /// <param name="compraRepository">Repositorio utilizado para acceder a los datos de compra.</param>
        /// <param name="logger">Logger utilizado para registrar eventos y excepciones.</param>
        /// <exception cref="ArgumentNullException">Se lanza cuando el repositorio de compra o el logger son nulos.</exception>
        private ComprarManager(IGenericRepository<Compra> compraRepository, ILogger logger)
        {
            this.compraRepository = compraRepository ?? throw new ArgumentNullException(nameof(compraRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Proporciona una instancia única de ComprarManager utilizando el patrón Singleton.
        /// </summary>
        public static ComprarManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var compraRepository = CompraRepository.Instance;
                    var logger = new SqlLogger();

                    _instance = new ComprarManager(compraRepository, logger);
                }
                return _instance;
            }
        }


        /// <summary>
        /// Valido si estan tildadas las validaciones de las garantias
        /// </summary>
        /// <param name="checkBox1">DNI</param>
        /// <param name="checkBox2">Certificado de domicilio</param>
        /// <returns></returns>
        public string VerificarCondicionesCompra(bool checkBox1, bool checkBox2)
        {
            if (!checkBox1 && checkBox2)
            {
                return "Falta Presentar DNI";
            }
            else if (checkBox1 && !checkBox2)
            {
                return "Falta Presentar Certificado de domicilio";
            }
            else if (!checkBox1 && !checkBox2)
            {
                MostrarAlerta("Debe Presentar DNI y Certificado de domicilio");
                return "Falta Presentar DNI y Certificado de domicilio";
            }
            else
            {
                return "Requisitos de documentación completados";
                //return;
            }
        }

        /// <summary>
        /// Muestra una alerta con el mensaje especificado.
        /// </summary>
        /// <param name="mensaje">El mensaje que se mostrará en la alerta.</param>
        public void MostrarAlerta(string mensaje)
        {
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Busca un comprador por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del comprador.</param>
        /// <returns>El objeto Compra correspondiente al identificador proporcionado, o null si no se encuentra.</returns>
        public Compra BuscarComprador(Guid id)
        {
            return compraRepository.SelectOne(id);
        }

        /// <summary>
        /// Guarda una compra en la base de datos.
        /// </summary>
        /// <param name="compra">La compra a guardar.</param>
        /// <returns>True si la operación se realizó con éxito, de lo contrario False.</returns>
        /// <exception cref="Exception">Se produce una excepción si la operación falla.</exception>
        public bool GuardarCompra(Compra compra)
        {
            try
            {
                bool exito = compraRepository.Add(compra);

                if (exito)
                {
                    // Crear un log exitoso
                    string logMessage = $"Se agregó correctamente la compra con id Inmueble: {compra.IdTipoInmueble}";
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
                string logErrorMessage = $"Error al agregar la compra: {ex.Message}";
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
        /// Modifica una compra en la base de datos.
        /// </summary>
        /// <param name="compra">La compra con los datos actualizados.</param>
        /// <returns>True si la operación se realizó con éxito, de lo contrario False.</returns>
        /// <exception cref="Exception">Se produce una excepción si la operación falla.</exception>
        public bool ModificarCompra(Compra compra)
        {
            try
            {
                bool exito = compraRepository.Update(compra);

                if (exito)
                {
                    // Crear un log exitoso
                    string logMessage = $"Se modificó correctamente la compra con id: {compra.IdComprador}";
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
                string logErrorMessage = $"Error al modificar la compra: {ex.Message}";
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
        /// Obtiene todos los compradores de la base de datos.
        /// </summary>
        /// <returns>Una colección de objetos Compra que representan a los compradores.</returns>
        public IEnumerable<Compra> ObtenerCompradores()
        {
            return compraRepository.SelectAll();
        }

        //public bool EliminarCompra(Guid id)
        //{
        //    //return compraRepository.Delete(id);

        //    try
        //    {
        //        bool exito = compraRepository.Delete(id);

        //        if (exito)
        //        {
        //            // Crear un log exitoso
        //            string logMessage = $"Se borró correctamente la compra con id: {id}";
        //            Log logSuccess = new Log
        //            {
        //                IdLog = Guid.NewGuid(),
        //                Message = logMessage,
        //                Severity = Severity.Info,
        //                Fecha_txr = DateTime.Now
        //            };

        //            // Guardar el log exitoso utilizando el logger
        //            logger.Store(logSuccess);
        //        }

        //        return exito;
        //    }
        //    catch (Exception ex)
        //    {
        //        // En caso de error, crear log de error
        //        string logErrorMessage = $"Error al borrar la compra: {ex.Message}";
        //        Log logError = new Log
        //        {
        //            IdLog = Guid.NewGuid(),
        //            Message = logErrorMessage,
        //            Severity = Severity.Error,
        //            Fecha_txr = DateTime.Now
        //        };

        //        // Guardar el log de error utilizando el logger
        //        logger.Store(logError);

        //        throw new Exception(logErrorMessage, ex);
        //    }
        //}

    }
}
