using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class FotoMascota
{
    public int FotoMascotaId { get; set; }

    public string? Codigo { get; set; }

    public string? FotoUrl { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? SubidaAt { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
