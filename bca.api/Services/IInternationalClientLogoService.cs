using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IInternationalClientLogoService
    {
        Task<InternationalClientLogo> UploadAsync(InternationalClientLogoUploadDTO dto);
        Task<InternationalClientLogo?> UpdateAsync(InternationalClientLogoUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<InternationalClientLogo>> GetAllAsync();
        Task<InternationalClientLogo?> GetByIdAsync(int id);
    }
}
