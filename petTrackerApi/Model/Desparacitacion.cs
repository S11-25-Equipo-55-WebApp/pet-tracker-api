using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Desparacitacion
{
    public int DesparacitacionId { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime? FechaAplicacion { get; set; }

    public DateTime? FechaProxima { get; set; }

    public string? Notas { get; set; }

    public int MascotaId { get; set; }

    public int TipoDesparacitacionId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual TipoDesparacitacion TipoDesparacitacion { get; set; } = null!;
}
