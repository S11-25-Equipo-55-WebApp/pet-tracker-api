namespace petTrackerApi.Services.IServices
{
    public interface ICloudinaryService
    {
        Task<(bool Success, string? Url, string? PublicId, string? Error)> UploadImageAsync(IFormFile file);
    }
}
