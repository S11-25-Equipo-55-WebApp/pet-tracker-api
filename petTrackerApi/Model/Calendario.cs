using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Calendario
{
    public int CalendarioId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public DateTime FechaEvento { get; set; }

    public string? Notas { get; set; }

    public int UsuarioId { get; set; }

    public int MascotaId { get; set; }

    public int? TipoEventoId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual TipoEvento? TipoEvento { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
