using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class EstadoRecordatorio
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateTime CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
