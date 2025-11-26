using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Recordatorio
{
    public int RecordatorioInt { get; set; }

    public string Codigo { get; set; } = null!;

    public byte[] Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaRecordatorio { get; set; }

    public int Intervalo { get; set; }

    public int EstadoRecordatorioId { get; set; }

    public int UsuarioId { get; set; }

    public int MascotaId { get; set; }

    public int TipoVvmdid { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual EstadoRecordatorio EstadoRecordatorio { get; set; } = null!;

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual TipoVvmd TipoVvmd { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
