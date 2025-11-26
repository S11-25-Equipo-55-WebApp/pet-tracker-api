using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Mascota
{
    public int MascotaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public int EspecieId { get; set; }

    public int RazaId { get; set; }

    public string FotoMascota { get; set; }

    public int UsuarioId { get; set; }

    public DateTime CreadoAt { get; set; }

    public DateTime EditadoAt { get; set; }

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();

    public virtual ICollection<ConsultaClinica> ConsultaClinicas { get; set; } = new List<ConsultaClinica>();

    public virtual ICollection<ControlPeso> ControlPesos { get; set; } = new List<ControlPeso>();

    public virtual ICollection<Desparacitacion> Desparacitacions { get; set; } = new List<Desparacitacion>();

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();

    public virtual Especie Especie { get; set; } = null!;

    public virtual Raza Raza { get; set; } = null!;

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Vacuna> Vacunas { get; set; } = new List<Vacuna>();
}
