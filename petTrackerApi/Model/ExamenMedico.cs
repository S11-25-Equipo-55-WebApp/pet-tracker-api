using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class ExamenMedico
{
    public int ExamenId { get; set; }

    public string Codigo { get; set; } = null!;

    public DateOnly FechaExamen { get; set; }

    public string? Resultado { get; set; }

    public int ConsultaId { get; set; }

    public int TipoExamenId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual ConsultaClinica Consulta { get; set; } = null!;

    public virtual TipoExamen TipoExamen { get; set; } = null!;
}
