using DAL.Contracts;
using DAL.Implementations;
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
    public class VentaManager
    {
        private static VentaManager _instance;
        private readonly IGenericRepository<Venta> _ventaRepository;
        private readonly ILogger logger;

        /// <summary>
        /// Constructor privado para evitar instanciación directa.
        /// </summary>
        /// <param name="ventaRepository">Repositorio de ventas.</param>
        private VentaManager(IGenericRepository<Venta> ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        /// <summary>
        /// Instancia única de la clase VentaManager.
        /// </summary>
        public static VentaManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Obtén instancias de los repositorios utilizando el patrón Singleton
                    var ventaRepository = VentaRepository.Instance;

                    _instance = new VentaManager(ventaRepository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Verifica las condiciones necesarias para una venta basadas en el estado de los checkboxes.
        /// </summary>
        /// <param name="checkBox1">Estado del checkbox 1 (Título de Propiedad Original).</param>
        /// <param name="checkBox2">Estado del checkbox 2 (DNI).</param>
        /// <param name="checkBox3">Estado del checkbox 3 (Comprobantes de Impuestos).</param>
        /// <param name="checkBox4">Estado del checkbox 4 (Certificado Catastral).</param>
        /// <returns>Un mensaje indicando el estado de las condiciones.</returns>
        public string VerificarCondicionesVenta(bool checkBox1, bool checkBox2, bool checkBox3, bool checkBox4)
        {
            if (!checkBox1)
            {
                MostrarAlerta("Falta Presentar Título de Propiedad Original");
                return "Falta Presentar Título de Propiedad Original";
            }
            else if (!checkBox2)
            {
                MostrarAlerta("Falta Presentar DNI");
                return "Falta Presentar DNI";
            }
            else if (!checkBox3)
            {
                MostrarAlerta("Falta Presentar Comprobantes de Impuestos");
                return "Falta Presentar Comprobantes de Impuestos";
            }
            else if (!checkBox4)
            {
                MostrarAlerta("Falta Presentar Certificado Castral");
                return "Falta Presentar Certificado Castral";
            }
            else
            {
                return "Requisitos de documentación completados";
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


        public bool GuardarVenta(Venta venta)
        {
            return _ventaRepository.Add(venta);

            try
            {
                bool exito = _ventaRepository.Add(venta);

                if (exito)
                {
                    // Crear un log exitoso
                    string logMessage = $"Se agregó correctamente la venta con id: {venta.IdVenta}";
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
                string logErrorMessage = $"Error al agregar la venta: {ex.Message}";
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
        /// Modifica una venta en la base de datos.
        /// </summary>
        /// <param name="venta">La venta a modificar.</param>
        /// <returns>True si la modificación fue exitosa; de lo contrario, False.</returns>
        /// <exception cref="Exception">Se produce una excepción si ocurre un error durante la modificación.</exception>
        public bool ModificarVenta(Venta venta)
        {
            return _ventaRepository.Update(venta);

        }

        /// <summary>
        /// Obtiene una venta por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la venta.</param>
        /// <returns>La venta correspondiente al identificador proporcionado.</returns>
        public Venta ObtenerIdVenta(Guid id)
        {
            return _ventaRepository.SelectOne(id);
        }

        /// <summary>
        /// Verifica si existe una venta creada con el identificador único especificado.
        /// </summary>
        /// <param name="id">El identificador único de la venta.</param>
        /// <returns>La venta correspondiente al identificador proporcionado, si existe; de lo contrario, devuelve null.</returns>
        public Venta ExixteVentaCreada(Guid id)
        {
            return _ventaRepository.SelectOne(id);
        }

        public IEnumerable<Venta> ObtenerTodasLasVentas()
        {
            return _ventaRepository.SelectAll();
        }

        //public bool BorrarVenta(Guid id)
        //{
        //    return _ventaRepository.Add(id);
        //}

        //public IEnumerable<Compra> ObtenerCompradores()
        //{
        //    return compraRepository.SelectAll();
        //}

    }
}
