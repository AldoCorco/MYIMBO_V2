using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.CompositeSeguridad
{
    public class PatenteFamilia
    {

        public Guid IdPatente { get; set; }
        public Guid IdFamilia { get; set; }

        public DateTime FechaCreacionFP { get; set; }
        public string NombreRol { get; internal set; }
    }
}
