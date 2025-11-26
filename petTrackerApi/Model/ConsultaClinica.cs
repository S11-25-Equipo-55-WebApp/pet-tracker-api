using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class ConsultaClinica
{
    public int ConsultaClinicaId { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime FechaConsulta { get; set; }

    public string? Motivo { get; set; }

    public string? Diagnostico { get; set; }

    public string? Veterinario { get; set; }

    public string? Notas { get; set; }

    public int MascotaId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual ICollection<ExamenMedico> ExamenMedicos { get; set; } = new List<ExamenMedico>();

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual ICollection<Medicacion> Medicacions { get; set; } = new List<Medicacion>();

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
