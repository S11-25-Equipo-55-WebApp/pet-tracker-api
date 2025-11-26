using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class TipoVvmd
{
    public int TipoVvmdid { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
