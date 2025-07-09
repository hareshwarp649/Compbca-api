using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IHomeMasterService
    {

        Task<HomeMaster> UploadAsync(HomeMasterUploadDTO dto);
        Task<HomeMaster?> UpdateAsync(int id, HomeMasterUploadDTO dto);
        Task<IEnumerable<HomeMaster>> GetAllAsync();
        Task<HomeMaster?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        //Task GetByIdWithGalleryAsyncs(int id);
    }
}
