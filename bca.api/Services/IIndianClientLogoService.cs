using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IIndianClientLogoService
    {
        Task<IndianClientLogo> UploadAsync(IndianClientLogoUploadDTO dto);
        Task<IndianClientLogo?> UpdateAsync(IndianClientLogoUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<IndianClientLogo>> GetAllAsync();
        Task<IndianClientLogo?> GetByIdAsync(int id);
    }
}
