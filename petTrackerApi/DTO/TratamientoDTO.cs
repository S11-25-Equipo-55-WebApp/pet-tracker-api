namespace petTrackerApi.DTO
{
    public class TratamientoDTO
    {
        public int TratamientoId { get; set; }

        public string? Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public int Frecuencia { get; set; }

        public int Dosis { get; set; }

        public string? Notas { get; set; }

        public int ConsultaId { get; set; }

        public DateTime CreadoAt { get; set; }

        public DateTime? EditadoAt { get; set; }
    }
}
