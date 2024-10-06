using System;

namespace Services.DAL.Contracts
{
    public class UsuarioPatente
    {
        public Guid IdUsuario { get; internal set; }
        public Guid IdPatente { get; internal set; }
        public DateTime FechaCreacion { get; internal set; }
        public string NombrePermiso { get; internal set; }
        public string Vista { get; internal set; }
        public string Usu_nom { get; internal set; }
        public string Nombre_Completo { get; internal set; }
    }
}