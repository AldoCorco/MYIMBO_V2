using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CryptographyService
    {
        public static string EncriptarContrasenia(string contrasenia)
        {
           

            using (SHA256 sha256 = SHA256.Create())
            {
                // Convierte la cadena de entrada en un arreglo de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(contrasenia);

                // Calcula el hash SHA-256 y lo convierte en una cadena hexadecimal
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
