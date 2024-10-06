using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.CompositeSeguridad
{
    public class UsuarioPatente
    {
        public Guid IdUsuario { get; set; }
        public string UsuNom { get; set; }
        public string Nombre_Completo { get; set; }
    }
}
