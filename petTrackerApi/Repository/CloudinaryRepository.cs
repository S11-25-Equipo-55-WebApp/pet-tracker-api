using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class CloudinaryRepository : ICloudinaryRepository
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryRepository(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "uploads_demo"
            };

            return await _cloudinary.UploadAsync(uploadParams);
        }
    }
}
