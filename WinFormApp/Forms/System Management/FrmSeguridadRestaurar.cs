using Services.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp.Forms.System_Management
{
    public partial class FrmSeguridadRestaurar : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        private string rutaBackup = "";
        private string rutaRestauracion = "";

        public FrmSeguridadRestaurar()
        {
            InitializeComponent();

            // Suscribe el formulario al evento LanguageChanged de LanguageBLL
            LanguageBLL.LanguageChanged += (sender, e) => CambiarIdiomaEnFormulario(LanguageBLL.CurrentLanguage);
        }

        private void FrmSeguridadRestaurar_Load(object sender, EventArgs e)
        {

        }

        private void CambiarIdiomaEnFormulario(string lang)
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

                lblBasedeDatos.Text = LanguageBLL.Traducir("Respaldo Base de datos", lang);
                lblUbicacion.Text = LanguageBLL.Traducir("Ubicación", lang);
                lblBasedeDatos2.Text = LanguageBLL.Traducir("Restaurar Base de datos", lang);
                lblUbicacion2.Text = LanguageBLL.Traducir("Ubicación", lang);

                btnRespaldo.Text = LanguageBLL.Traducir("Respaldo", lang);
                btnRestaurar.Text = LanguageBLL.Traducir("Restaurar", lang);

                // Repite este proceso para otros controles que desees traducir en el formulario.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el idioma del formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Browser
        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarDirectorioParaBackup();
        }

        private void btnRespaldo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaBackup))
            {
                RealizarBackup(rutaBackup);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una ruta de backup antes de realizar el respaldo.");
            }
        }

        //Browser
        private void button4_Click(object sender, EventArgs e)
        {
            SeleccionarArchivoDeRestauracion();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            SeleccionarArchivoDeRestauracion();
        }

        private void SeleccionarDirectorioParaBackup()
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaBackup = folderBrowserDialog.SelectedPath;
                    textBox1.Text = rutaBackup;
                }
            }
        }

        private void SeleccionarArchivoDeRestauracion()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Respaldo (*.bak)|*.bak";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaRestauracion = openFileDialog.FileName;
                    textBox2.Text = rutaRestauracion;

                    // Realizar la restauración cuando se selecciona el archivo de restauración
                    RealizarRestauracion(rutaRestauracion);
                }
            }
        }

        private void RealizarBackup(string directorioBackup)
        {
            try
            {
                string fechaBackup = DateTime.Now.ToString("yyyyMMddHHmmss");
                string nombreArchivo = $"backup_{fechaBackup}.bak";
                string rutaCompleta = Path.Combine(directorioBackup, nombreArchivo);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"BACKUP DATABASE MYIMBO TO DISK='{rutaCompleta}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Backup realizado correctamente en: {rutaCompleta}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el backup: {ex.Message}");
            }
        }

        private void RealizarRestauracion(string rutaRestauracion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"USE master; RESTORE DATABASE MYIMBO FROM DISK='{rutaRestauracion}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Restauración completada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la restauración: {ex.Message}");
            }
        }

    }
}
