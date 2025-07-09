using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IWorkingGalleryService
    {

        Task<WorkingGallery> UploadAsync(WorkingGalleryUploadDTO dto);
        Task<WorkingGallery?> UpdateAsync(int id, WorkingGalleryUploadDTO dto);
        Task<IEnumerable<WorkingGallery>> GetByHomeMasterIdAsync(int homeMasterId);
        Task<WorkingGallery?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
