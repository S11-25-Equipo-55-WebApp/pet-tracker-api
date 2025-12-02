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
        public static string GenerarCodigoDobleFecha(int? idBase, DateTime fecha, DateOnly? fechaProxima)
        {
            string fechaFormateada = fecha.ToString("ddMMyy");

            string fechaFormateada2 = fechaProxima.Value.ToString("ddMMyy");

            return $"{idBase}_{fechaFormateada}{fechaProxima}";
        }
        public static string GenerarCodigoDobleFechaDateTime(int? idBase, DateTime fecha, DateTime? fechaProxima)
        {
            string fechaFormateada = fecha.ToString("ddMMyy");

            string fechaFormateada2 = fechaProxima.Value.ToString("ddMMyy");

            return $"{idBase}_{fechaFormateada}{fechaFormateada2}";
        }

        public static string GenerarCodigoRandom(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "XXXX" + Guid.NewGuid().ToString("N").Substring(0, 2).ToUpper();

            nombre = nombre.Trim().ToUpper();
            nombre = nombre
                .Replace("Á", "A")
                .Replace("É", "E")
                .Replace("Í", "I")
                .Replace("Ó", "O")
                .Replace("Ú", "U")
                .Replace("Ñ", "N");

            nombre = new string(nombre.Where(char.IsLetter).ToArray());
            string baseCodigo = nombre.Length >= 4 ? nombre.Substring(0, 4) : nombre.PadRight(4, 'X');

            string suffix = Guid.NewGuid().ToString("N").Substring(0, 2).ToUpper();

            return baseCodigo + suffix;
        }

    }
}
