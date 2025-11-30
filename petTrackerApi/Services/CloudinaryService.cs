
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace SubirArchivoClodinary.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly ICloudinaryRepository _repository;

        public CloudinaryService(ICloudinaryRepository repository)
        {
            _repository = repository;
        }
        public async Task<(bool Success, string? Url, string? PublicId, string? Error)> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return (false, null, null, "No se ha enviado ninguna imagen.");

            try
            {
                var result = await _repository.UploadImageAsync(file);

                if (result == null)
                    return (false, null, null, "Respuesta vacía desde Cloudinary.");

                if (result.Error != null)
                    return (false, null, null, $"Error en Cloudinary: {result.Error.Message}");

                if (result.StatusCode != System.Net.HttpStatusCode.OK &&
                    result.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    return (false, null, null, $"Error al subir la imagen. Status: {result.StatusCode}");
                }

                return (true, result.SecureUrl?.ToString(), result.PublicId, null);
            }
            catch (Exception ex)
            {
                return (false, null, null, $"Error inesperado: {ex.Message}");
            }
        }
    }
}

