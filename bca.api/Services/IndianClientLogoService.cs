using AutoMapper;
using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class IndianClientLogoService: IIndianClientLogoService
    {
        private readonly IIndianClientLogoRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;

        public IndianClientLogoService(IIndianClientLogoRepository repo, IWebHostEnvironment env, IHttpContextAccessor httpContext)
        {
            _repo = repo;
            _env = env;
            _httpContext = httpContext;
        }

        private string GetBaseUrl() =>
            $"{_httpContext.HttpContext?.Request.Scheme}://{_httpContext.HttpContext?.Request.Host}";

        private async Task<(string filePath, string imageUrl)> SaveLogoAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "client-logos");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            string uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            string imageUrl = $"{GetBaseUrl()}/client-logos/{uniqueName}";
            return (filePath, imageUrl);
        }

        public async Task<IndianClientLogo> UploadAsync(IndianClientLogoUploadDTO dto)
        {
            var (filePath, imageUrl) = await SaveLogoAsync(dto.Logo);

            var logo = new IndianClientLogo
            {
                ClientName = dto.ClientName,
                WebsiteUrl = dto.WebsiteUrl,
                LogoImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            return await _repo.AddAsync(logo);
        }

        public async Task<IndianClientLogo?> UpdateAsync(IndianClientLogoUpdateDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) return null;

            existing.ClientName = dto.ClientName;
            existing.WebsiteUrl = dto.WebsiteUrl;

            if (dto.Logo != null)
            {
                var filePath = existing.LogoImageUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
                if (File.Exists(filePath)) File.Delete(filePath);

                var (newPath, imageUrl) = await SaveLogoAsync(dto.Logo);
                existing.LogoImageUrl = imageUrl;
            }

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            var filePath = existing.LogoImageUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
            if (File.Exists(filePath)) File.Delete(filePath);

            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<IndianClientLogo>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<IndianClientLogo?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    }
}
