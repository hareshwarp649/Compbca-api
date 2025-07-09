using AutoMapper;
using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class InternationalClientLogoService: IInternationalClientLogoService
    {
        private readonly IInternationalClientLogoRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;

        public InternationalClientLogoService(IInternationalClientLogoRepository repo, IWebHostEnvironment env, IHttpContextAccessor httpContext)
        {
            _repo = repo;
            _env = env;
            _httpContext = httpContext;
        }

        private string GetBaseUrl() =>
            $"{_httpContext.HttpContext?.Request.Scheme}://{_httpContext.HttpContext?.Request.Host}";

        private async Task<(string filePath, string imageUrl)> SaveLogoAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "international-logos");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            string uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            string imageUrl = $"{GetBaseUrl()}/international-logos/{uniqueName}";
            return (filePath, imageUrl);
        }

        public async Task<InternationalClientLogo> UploadAsync(InternationalClientLogoUploadDTO dto)
        {
            var (filePath, imageUrl) = await SaveLogoAsync(dto.Logo);

            var logo = new InternationalClientLogo
            {
                ClientName = dto.ClientName,
                WebsiteUrl = dto.WebsiteUrl,
                LogoImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            return await _repo.AddAsync(logo);
        }

        public async Task<InternationalClientLogo?> UpdateAsync(InternationalClientLogoUpdateDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) return null;

            existing.ClientName = dto.ClientName;
            existing.WebsiteUrl = dto.WebsiteUrl;

            if (dto.Logo != null)
            {
                var oldPath = existing.LogoImageUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
                if (File.Exists(oldPath)) File.Delete(oldPath);

                var (newPath, imageUrl) = await SaveLogoAsync(dto.Logo);
                existing.LogoImageUrl = imageUrl;
            }

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            var oldPath = existing.LogoImageUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
            if (File.Exists(oldPath)) File.Delete(oldPath);

            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InternationalClientLogo>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<InternationalClientLogo?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    }
}
