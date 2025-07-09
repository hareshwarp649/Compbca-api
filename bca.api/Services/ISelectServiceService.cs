using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Services
{
    public interface ISelectServiceService
    {
        Task<IEnumerable<SelectService>> GetAllAsync();
        Task<SelectService> CreateAsync(SelectServiceDTO dto);
        Task<SelectService?> UpdateAsync(int id, SelectServiceDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
