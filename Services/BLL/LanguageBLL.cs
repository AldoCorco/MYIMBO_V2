using Services.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL
{
    public static class LanguageBLL
    {
        // Evento para notificar el cambio de idioma
        public static event EventHandler LanguageChanged;

        // Idioma predeterminado español
        private static string currentLanguage = "es-AR";


        public static string CurrentLanguage
        {
            get { return currentLanguage; }
        }

        public static void SetLanguage(string lang)
        {
            try
            {
                if (currentLanguage != lang)
                {
                    currentLanguage = lang;

                    // Notifica a los formularios registrados sobre el cambio de idioma
                    OnLanguageChanged();
                }

            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que falle el cambio de idioma
                Console.WriteLine($"Error al cambiar el idioma: {ex.Message}");
            }
        }

        private static void OnLanguageChanged()
        {
            try
            {
                LanguageChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que falle la notificación del cambio de idioma
                Console.WriteLine($"Error al notificar el cambio de idioma: {ex.Message}");
            }
        }

        public static string Traducir(string key, string lang)
        {
            try
            {
                return LanguageRepository.Current.Traducir(key, lang);
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que falle la traducción
                Console.WriteLine($"Error al traducir '{key}' al idioma '{lang}': {ex.Message}");
                throw; // También propagamos la excepción para que otros puedan manejarla
            }
        }

        internal static string Traducir(string nombrePermiso, object lang)
        {
            throw new NotImplementedException();
        }

        //public static string TraducirMessageBox(string key, string lang)
        //{
        //    string mensaje = LanguageRepository.Current.Traducir(key, lang);
        //    return mensaje;
        //}

    }

}
