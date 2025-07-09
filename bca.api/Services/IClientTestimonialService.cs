using bca.api.DTOs;

namespace bca.api.Services
{
    public interface IClientTestimonialService
    {
        Task<ClientTestimonialDTO> CreateAsync(ClientTestimonialUploadDTO dto);
        Task<IEnumerable<ClientTestimonialDTO>> GetAllAsync();
        Task<ClientTestimonialDTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
         Task<IEnumerable<ClientTestimonialDTO>> GetTopRatedAsync();
    }
}
