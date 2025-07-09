using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IIndianClientService
    {
        Task<IndianClientDTO> CreateAsync(IndianClientCreateDTO dto);
        Task<IEnumerable<IndianClientDTO>> GetAllAsync();
        Task<IndianClientDTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<IndianClientDTO?> UpdateAsync(int id, IndianClientCreateDTO dto);
       
    }
}
