using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class TipoEvento
{
    public int TipoEventoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
}
