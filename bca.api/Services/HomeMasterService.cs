using bca.api.Data.Entities;
using bca.api.Helpers;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Services
{
    public class HomeMasterService : IHomeMasterService
    {
        private readonly IHomeMasterRepository _repo;
        private readonly IWebHostEnvironment _env;
        public HomeMasterService(IHomeMasterRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public async Task<IEnumerable<HomeMaster>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<HomeMaster?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id, h => h.WorkingGalleries);
        }


        public async Task<HomeMaster> CreateAsync(HomeMaster home)
        {
            await _repo.AddAsync(home);
            await _repo.SaveChangesAsync();
            return home;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
             return await _repo.DeleteAsync(id);


            //var entity = await _repo.GetByIdAsync(id);
            //if (entity == null) return false;

            //// Delete images
            //DeleteImage(entity.BannerImageUrl);
            //DeleteImage(entity.TeamGroupImageUrl);

            //return await _repo.DeleteAsync(id);

        }
        public async Task<HomeMaster?> UpdateAsync(HomeMaster home)
        {
            var existing = await _repo.GetByIdAsync(home.Id);
            if (existing == null) return null;

            await _repo.UpdateAsync(home);
            await _repo.SaveChangesAsync();
            return home;
        }

        //public async Task<bool> UploadBannerImageAsync(int homeId, IFormFile image)
        //{
        //    var entity = await _repo.GetByIdAsync(homeId);
        //    if (entity == null || image == null) return false;

        //    var fileName = await SaveImage(image, "banner");
        //    entity.BannerImageUrl = $"/images/banner/{fileName}";

        //    await _repo.UpdateAsync(entity);
        //    await _repo.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> UploadTeamImageAsync(int homeId, IFormFile image)
        //{
        //    var entity = await _repo.GetByIdAsync(homeId);
        //    if (entity == null || image == null) return false;

        //    var fileName = await SaveImage(image, "team");
        //    entity.TeamGroupImageUrl = $"/images/team/{fileName}";

        //    await _repo.UpdateAsync(entity);
        //    await _repo.SaveChangesAsync();
        //    return true;


        //}

        //private async Task<string> SaveImage(IFormFile file, string folder)
        //{
        //    var path = Path.Combine("wwwroot", "images", folder);
        //    Directory.CreateDirectory(path);

        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var fullPath = Path.Combine(path, fileName);

        //    using var stream = new FileStream(fullPath, FileMode.Create);
        //    await file.CopyToAsync(stream);

        //    return fileName;
        //}
        //private void DeleteImage(string? imagePath)
        //{
        //    if (string.IsNullOrWhiteSpace(imagePath)) return;

        //    var fullPath = Path.Combine("wwwroot", imagePath.TrimStart('/'));
        //    if (File.Exists(fullPath))
        //    {
        //        File.Delete(fullPath);
        //    }
        //}

        //--------------------------------------------------------


        //public void RemoveBanerImage(HomeMaster home)
        //{
        //    if (home.BannerImageUrl is { })
        //        ImageHelper.RemoveImage("homes", home.BannerImageUrl);
        //}

        //public async Task<string> UpdateBanerImageAsync(IFormFile img, HomeMaster home, HttpRequest request)
        //{
        //    string folder = "homes";
        //    string fileName = await ImageHelper
        //        .UploadImageAsync(img, folder, $"airline-{home.Id}-logo");
        //    var serverUrl = $"{request.Scheme}://{request.Host.Value}";
        //    var imageUrl = $"{serverUrl}/imgs/{folder}/{fileName}";

        //    return imageUrl;


        public async Task<HomeMaster> UploadImageAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var folderPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new HomeMaster { BannerImageUrl = fileName }; //FilePath = $"/uploads/{fileName}"
            return await _repo.AddAsync(image);
        }

        public async Task<HomeMaster?> UpdateImageAsync(int id, IFormFile file)
        {
            var image = await _repo.GetByIdAsync(id);
            if (image == null) return null;

            var oldPath = Path.Combine(_env.WebRootPath, "uploads", image.BannerImageUrl);
            if (File.Exists(oldPath)) File.Delete(oldPath);

            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var newFilePath = Path.Combine(_env.WebRootPath, "uploads", newFileName);

            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            image.BannerImageUrl = newFileName;
            image.BannerImageUrl = $"/uploads/{newFileName}";
            return await _repo.UpdateAsync(image);
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _repo.GetByIdAsync(id);
            if (image == null) return false;

            var path = Path.Combine(_env.WebRootPath, "uploads", image.BannerImageUrl);
            if (File.Exists(path)) File.Delete(path);

            return await _repo.DeleteAsync(id);
        }
    }
}

