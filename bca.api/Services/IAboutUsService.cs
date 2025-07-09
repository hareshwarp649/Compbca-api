using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IAboutUsService
    {
        Task<AboutUs> UploadAsync(AboutUsUploadDTO dto);
        Task<AboutUs?> UpdateAsync(AboutUsUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AboutUs>> GetAllAsync();
        Task<AboutUs?> GetByIdAsync(int id);
    }
}
