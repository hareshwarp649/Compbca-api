using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Helpers;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Services
{
    public class WorkingGalleryService : IWorkingGalleryService
    {
        private readonly IWorkingGalleryRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;

        public WorkingGalleryService(IWorkingGalleryRepository repo, IWebHostEnvironment env, IHttpContextAccessor http)
        {
            _repo = repo;
            _env = env;
            _http = http;
        }

        private string GetBaseUrl() =>
            $"{_http.HttpContext?.Request.Scheme}://{_http.HttpContext?.Request.Host}";

        private async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            var folderPath = Path.Combine(_env.WebRootPath, folder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullPath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"{GetBaseUrl()}/{folder}/{fileName}";
        }

        public async Task<WorkingGallery> UploadAsync(WorkingGalleryUploadDTO dto)
        {
            var mediaUrl = await SaveFileAsync(dto.MediaFile, "working-gallery");

            var gallery = new WorkingGallery
            {
                HomeMasterId = dto.HomeMasterId,
                MediaUrl = mediaUrl,
                Title = dto.Title,
                
            };

            return await _repo.AddAsync(gallery);
        }

        public async Task<WorkingGallery?> UpdateAsync(int id, WorkingGalleryUploadDTO dto)
        {
            var gallery = await _repo.GetByIdAsync(id);
            if (gallery == null) return null;

            gallery.Title = dto.Title;
            

            if (dto.MediaFile != null)
            {
                // delete old file (optional)
                var oldPath = gallery.MediaUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
                if (File.Exists(oldPath)) File.Delete(oldPath);

                gallery.MediaUrl = await SaveFileAsync(dto.MediaFile, "working-gallery");
            }

            return await _repo.UpdateAsync(gallery);
        }

        public async Task<IEnumerable<WorkingGallery>> GetByHomeMasterIdAsync(int homeMasterId)
        {
            return await _repo.GetByHomeMasterIdAsync(homeMasterId);
        }

        public async Task<WorkingGallery?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<bool> DeleteAsync(int id)
        {
            var gallery = await _repo.GetByIdAsync(id);
            if (gallery == null) return false;

            // delete file from disk
            var path = gallery.MediaUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
            if (File.Exists(path)) File.Delete(path);

            return await _repo.DeleteAsync(id);
        }
    }
}

