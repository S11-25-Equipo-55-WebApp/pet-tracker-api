using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class TipoDesparacitacion
{
    public int TipoDesparacitacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateTime CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Desparacitacion> Desparacitacions { get; set; } = new List<Desparacitacion>();
}
