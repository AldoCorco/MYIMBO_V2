using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Services.DomainModel.Exceptions;

namespace Services.DAL.Implementations
{
    internal sealed class LanguageRepository
    {
        #region Singleton
        private readonly static LanguageRepository _instance = new LanguageRepository();

        public static LanguageRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        private string foldersLanguage = ConfigurationManager.AppSettings["FolderLanguage"];
        private string filePathLanguage = ConfigurationManager.AppSettings["FilePathLanguage"];

               
        public string Traducir(string key, string lang)
        {
            try
            {
                string filePath = $"{foldersLanguage}/{filePathLanguage}{lang}";

                // Verifica si el idioma es español y la clave está en el archivo de idioma
                if ((lang == "es-AR" || lang == "es-GB") && ExisteClaveEnIdioma(filePath, key))
                {
                    // Si el idioma es español y la clave está en el archivo, devolver la clave original
                    return key;
                }
                else
                {
                    // Si no, buscar la traducción en el archivo de idioma
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] dataFile = sr.ReadLine().Split('=');

                            if (dataFile.Length == 2 && dataFile[0] == key)
                            {
                                // Retornar la traducción encontrada en el archivo de idioma
                                return dataFile[1];
                            }
                        }
                    }

                    // Si la clave no se encuentra, devolver la misma clave
                    return key;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción aquí
                Console.WriteLine($"Error al traducir '{key}' al idioma '{lang}': {ex.Message}");
                throw;
            }
        }

        // Función para verificar si la clave existe en el archivo de idioma
        private bool ExisteClaveEnIdioma(string filePath, string key)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] dataFile = sr.ReadLine().Split('=');

                    if (dataFile.Length == 2 && dataFile[0] == key)
                    {
                        // La clave existe en el archivo de idioma
                        return true;
                    }
                }
            }
            // La clave no se encuentra en el archivo de idioma
            return false;
        }


        public void WriteNewWord(string word, string value)
        {


        }

        public Dictionary<string, string> FindAll()
        {
            return null;
        }

        /// <summary>
        /// Generar una implementación que lea las extensiones de todos mis archivos dentro de I18n
        /// </summary>
        /// <returns></returns>
        public List<string> GetCurrentCultures()
        {
            return new List<string>();
        }
    }
}
