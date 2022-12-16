using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFService.Core.DTOs
{
    public class DTOUsuario
    {
        public string? Nombre { get; set; }

        public DateTime? Fecha { get; set; }

        public int? TipoSexo { get; set; }
    }
}
