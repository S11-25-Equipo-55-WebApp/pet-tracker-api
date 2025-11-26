using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Vacuna
{
    public int VacunaId { get; set; }

    public string Codigo { get; set; } = null!;

    public DateOnly FechaAplicacion { get; set; }

    public DateOnly? FechaProxima { get; set; }

    public string? Notas { get; set; }

    public int MascotaId { get; set; }

    public int TipoVacunaId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual TipoVacuna TipoVacuna { get; set; } = null!;
}
