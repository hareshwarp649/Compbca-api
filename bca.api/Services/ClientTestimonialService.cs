using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class ClientTestimonialService:IClientTestimonialService
    {
        private readonly IClientTestimonialRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ClientTestimonialService(IClientTestimonialRepository repo, IWebHostEnvironment env, IMapper mapper)
        {
            _repo = repo;
            _env = env;
            _mapper = mapper;
        }

        public async Task<ClientTestimonialDTO> CreateAsync(ClientTestimonialUploadDTO dto)
        {
            string? imageUrl = null;

            if (dto.ClientImage != null)
            {
                var folder = Path.Combine(_env.WebRootPath, "testimonial-images");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                var fileName = $"{Guid.NewGuid()}_{dto.ClientImage.FileName}";
                var path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.ClientImage.CopyToAsync(stream);
                }

                imageUrl = $"/testimonial-images/{fileName}";
            }

            var entity = new ClientTestimonial
            {
                ClientName = dto.ClientName,
                ClientImageUrl = imageUrl,
                Feedback = dto.Feedback,
                Rating = dto.Rating,
                ClientLocation = dto.ClientLocation,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repo.AddAsync(entity);
            return _mapper.Map<ClientTestimonialDTO>(created);
        }

        public async Task<IEnumerable<ClientTestimonialDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientTestimonialDTO>>(list);
        }

        public async Task<ClientTestimonialDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ClientTestimonialDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClientTestimonialDTO>> GetTopRatedAsync()
        {
            var topTestimonials = await _repo.GetTopRatedTestimonialsAsync();
            return _mapper.Map<IEnumerable<ClientTestimonialDTO>>(topTestimonials);
        }
    }
}
