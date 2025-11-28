using System;
using System.Collections.Generic;

namespace petTrackerApi.Model;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreadoAt { get; set; }

    public DateTime? EditadoAt { get; set; }

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
