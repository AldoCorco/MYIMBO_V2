using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel
{
    public class Usuario
    {
        //[Key]
        public Guid IdUsuario { get; set; }
        public string UsuNom { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaCreacion_Usu { get; set; }
        public string Activo { get; set; }

        public string EsAdmin { get; set; }

        public List<Patente> Patentes { get; set; } = new List<Patente>();
        public List<Familia> Familias { get; set; } = new List<Familia>();


        //public List<Patente> Patentes { get; set; } // Lista de patentes del usuario
        //public List<Familia> Familias { get; set; } // Lista de familias del usuario

        //internal bool TienePermiso(string nombrePermiso)
        //{
        //    //throw new NotImplementedException();
        //    return Patentes.Any(p => p.NombrePermiso == nombrePermiso) ||
        //       Familias.Any(f => f.Patentes.Any(p => p.NombrePermiso == nombrePermiso));

        //}

    }


}
