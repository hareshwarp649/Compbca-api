using AutoMapper;
using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;

        public AboutUsService(IAboutUsRepository repo, IWebHostEnvironment env, IHttpContextAccessor httpContext)
        {
            _repo = repo;
            _env = env;
            _httpContext = httpContext;
        }

        private string GetBaseUrl()
        {
            return $"{_httpContext.HttpContext?.Request.Scheme}://{_httpContext.HttpContext?.Request.Host}";
        }

        private async Task<(string filePath, string imageUrl)> SaveFileAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            string imageUrl = $"{GetBaseUrl()}/uploads/{uniqueName}";
            return (filePath, imageUrl);
        }

        public async Task<AboutUs> UploadAsync(AboutUsUploadDTO dto)
        {
            var (filePath, imageUrl) = await SaveFileAsync(dto.Image);

            var aboutUs = new AboutUs
            {
                Title = dto.Title,
                Description = dto.Description,
                FilePath = filePath,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            return await _repo.AddAsync(aboutUs);
        }

        public async Task<AboutUs?> UpdateAsync(AboutUsUpdateDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null)
                return null;

            existing.Title = dto.Title;
            existing.Description = dto.Description;

            if (dto.Image != null)
            {
                // Delete old file
                if (!string.IsNullOrEmpty(existing.FilePath) && File.Exists(existing.FilePath))
                    File.Delete(existing.FilePath);

                var (newPath, newUrl) = await SaveFileAsync(dto.Image);
                existing.FilePath = newPath;
                existing.ImageUrl = newUrl;
            }

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return false;

            // Delete file
            if (!string.IsNullOrEmpty(existing.FilePath) && File.Exists(existing.FilePath))
                File.Delete(existing.FilePath);

            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<AboutUs>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<AboutUs?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    }
}
