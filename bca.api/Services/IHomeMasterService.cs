using bca.api.Data.Entities;

namespace bca.api.Services
{
    public interface IHomeMasterService
    {
        Task<HomeMaster?> GetByIdAsync(int id);
        Task<IEnumerable<HomeMaster>> GetAllAsync();
        Task<HomeMaster> CreateAsync(HomeMaster home);
        Task<HomeMaster?> UpdateAsync(HomeMaster home);
        Task<bool> DeleteAsync(int id);

        //Task<bool> UploadBannerImageAsync(int homeId, IFormFile image);
        //Task<bool> UploadTeamImageAsync(int homeId, IFormFile image);

        //Task<IEnumerable<HomeMaster>> GetAllImagesAsync();
        //Task<HomeMaster?> GetImageByIdAsync(int id);
        Task<HomeMaster> UploadImageAsync(IFormFile file);
        Task<HomeMaster?> UpdateImageAsync(int id, IFormFile file);
        Task<bool> DeleteImageAsync(int id);

        //Task<string> UpdateBanerImageAsync(IFormFile img, HomeMaster home, HttpRequest request);
        //void RemoveBanerImage(HomeMaster home);
    }
}
