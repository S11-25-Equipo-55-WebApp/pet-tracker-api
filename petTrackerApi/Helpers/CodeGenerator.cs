namespace petTrackerApi.Helpers
{
    public static class CodeGenerator
    {
        public static string GenerarCodigo(string? textoBase, DateTime fecha, int idBase)
        {
            if (string.IsNullOrWhiteSpace(textoBase))
                throw new ArgumentException("El texto base no puede estar vacío.");

            string textoLimpio = textoBase.Trim().Replace(" ", "").ToUpper();
            string fechaFormateada = fecha.ToString("ddMMyy");

            return $"{textoLimpio}_{fechaFormateada}{idBase}";
        }
        public static string GenerarCodigo(int? idBase, DateTime fecha)
        {
            string fechaFormateada = fecha.ToString("ddMMyy");

            return $"{idBase}_{fechaFormateada}";
        }
    }
}
