using System;
using System.Collections.Generic;

namespace CoreWCFService.Core.Entities;

public class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TipoSexo { get; set; }
}
