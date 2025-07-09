using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Helpers;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Services
{
    public class HomeMasterService : IHomeMasterService
    {
        private readonly IHomeMasterRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;

        public HomeMasterService(IHomeMasterRepository repo, IWebHostEnvironment env, IHttpContextAccessor http)
        {
            _repo = repo;
            _env = env;
            _http = http;
        }

        private string GetBaseUrl() =>
            $"{_http.HttpContext?.Request.Scheme}://{_http.HttpContext?.Request.Host}";

        private async Task<string?> SaveFileAsync(IFormFile? file, string folderName)
        {
            if (file == null) return null;

            string folder = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            string path = Path.Combine(folder, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"{GetBaseUrl()}/{folderName}/{fileName}";
        }

        public async Task<HomeMaster> UploadAsync(HomeMasterUploadDTO dto)
        {
            var bannerUrl = await SaveFileAsync(dto.BannerImage, "banners");
            var teamImageUrl = await SaveFileAsync(dto.TeamGroupImage, "teams");

            var home = new HomeMaster
            {
                MainTitle = dto.MainTitle,
                SubTitle = dto.SubTitle,
                AboutCompany = dto.AboutCompany,
                WhyChooseUs = dto.WhyChooseUs,
                YearsOfExperience = dto.YearsOfExperience,
                ServiceHighlightOne = dto.ServiceHighlightOne,
                ServiceHighlightTwo = dto.ServiceHighlightTwo,
                ServiceHighlightThree = dto.ServiceHighlightThree,
                CustomerReviewSectionTitle = dto.CustomerReviewSectionTitle,
                FeaturedProductSectionTitle = dto.FeaturedProductSectionTitle,
                TeamDescription = dto.TeamDescription,
                BannerImageUrl = bannerUrl,
                TeamGroupImageUrl = teamImageUrl,
                WorkingGalleries = await Task.WhenAll(dto.GalleryImages.Select(async img =>
                {
                    var imageUrl = await SaveFileAsync(img, "working-gallery");
                    return new WorkingGallery { MediaUrl = imageUrl };
                })).ContinueWith(t => t.Result.ToList()),
                CreatedAt = DateTime.UtcNow
            };

            return await _repo.AddAsync(home);
        }

        public async Task<HomeMaster?> UpdateAsync(int id, HomeMasterUploadDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.MainTitle = dto.MainTitle;
            existing.SubTitle = dto.SubTitle;
            existing.AboutCompany = dto.AboutCompany;
            existing.WhyChooseUs = dto.WhyChooseUs;
            existing.YearsOfExperience = dto.YearsOfExperience;
            existing.ServiceHighlightOne = dto.ServiceHighlightOne;
            existing.ServiceHighlightTwo = dto.ServiceHighlightTwo;
            existing.ServiceHighlightThree = dto.ServiceHighlightThree;
            existing.CustomerReviewSectionTitle = dto.CustomerReviewSectionTitle;
            existing.FeaturedProductSectionTitle = dto.FeaturedProductSectionTitle;
            existing.TeamDescription = dto.TeamDescription;

            if (dto.BannerImage != null)
                existing.BannerImageUrl = await SaveFileAsync(dto.BannerImage, "banners");

            if (dto.TeamGroupImage != null)
                existing.TeamGroupImageUrl = await SaveFileAsync(dto.TeamGroupImage, "teams");

            if (dto.GalleryImages != null && dto.GalleryImages.Any())
            {
                // Optional: delete old image files from disk
                foreach (var oldGallery in existing.WorkingGalleries)
                {
                    var path = oldGallery.MediaUrl.Replace(GetBaseUrl(), _env.WebRootPath).Replace("/", "\\");
                    if (File.Exists(path)) File.Delete(path);
                }

                // Clear existing galleries
                existing.WorkingGalleries.Clear();

                // Upload new gallery images
                var newGalleries = await Task.WhenAll(dto.GalleryImages.Select(async img =>
                {
                    var url = await SaveFileAsync(img, "working-gallery");
                    return new WorkingGallery { MediaUrl = url };
                }));

                existing.WorkingGalleries = newGalleries.ToList();
            }


            return await _repo.UpdateAsync(existing);
        }

        public async Task<IEnumerable<HomeMaster>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<HomeMaster?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            return await _repo.DeleteAsync(id);
        }

        //public async Task<HomeMaster?> GetByIdWithGalleryAsyncs(int id)
        //{
        //    return await _repo.GetByIdWithGalleryAsync(id);
        //}
    }
}

