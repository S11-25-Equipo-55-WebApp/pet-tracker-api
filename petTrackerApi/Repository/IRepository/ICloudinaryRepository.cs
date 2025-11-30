using CloudinaryDotNet.Actions;

namespace petTrackerApi.Repository.IRepository
{
    public interface ICloudinaryRepository
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file);
    }
}
