using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class TipoMedicamento
{
    public int TipoMedId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateTime CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Medicacion> Medicacions { get; set; } = new List<Medicacion>();
}
