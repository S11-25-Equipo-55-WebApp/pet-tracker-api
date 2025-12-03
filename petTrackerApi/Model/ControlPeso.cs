using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class ControlPeso
{
    public int ControlPesoId { get; set; }

    public string Codigo { get; set; } = null!;

    public int Peso { get; set; }

    public int UnidadMedidaId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public string? Notas { get; set; }

    public int MascotaId { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual UnidadMedida UnidadMedida { get; set; } = null!;
}
