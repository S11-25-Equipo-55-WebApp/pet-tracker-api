using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class TipoVacuna
{
    public int TipoVacunaId { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public DateTime? CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual ICollection<Vacuna> Vacunas { get; set; } = new List<Vacuna>();
}
