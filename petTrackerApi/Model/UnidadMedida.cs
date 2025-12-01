namespace petTrackerApi.Model
{
    public class UnidadMedida
    {
        public int UnidadMedidaId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Abreviatura { get; set; } = null!;

        public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();
    }
}
