using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IContactUsService
    {
        Task<ContactUsDTO> CreateAsync(ContactUsCreateDTO dto);
        Task<IEnumerable<ContactUsDTO>> GetAllAsync();
        Task<ContactUsDTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
