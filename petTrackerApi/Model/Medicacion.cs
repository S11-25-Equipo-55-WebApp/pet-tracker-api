using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Medicacion
{
    public int MedicacionId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int Frecuencia { get; set; }

    public string? Descripcion { get; set; }

    public int ConsultaId { get; set; }

    public int TipoMedicacionId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual ConsultaClinica Consulta { get; set; } = null!;

    public virtual TipoMedicamento TipoMedicacion { get; set; } = null!;
}
