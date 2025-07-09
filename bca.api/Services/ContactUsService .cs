using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class ContactUsService:IContactUsService
    {
        private readonly IContactUsRepository _repo;
        private readonly IMapper _mapper;

        public ContactUsService(IContactUsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ContactUsDTO> CreateAsync(ContactUsCreateDTO dto)
        {
            //var entity = _mapper.Map<ContactUs>(dto);
            //var result = await _repo.AddAsync(entity);
            //return _mapper.Map<ContactUsDTO>(result);

            var entity = _mapper.Map<ContactUs>(dto);

            // Save to database
            var result = await _repo.AddAsync(entity);

            // ✅ Re-fetch with SelectService loaded
            var savedWithService = await _repo.GetByIdWithServiceAsync(result.Id);

            return _mapper.Map<ContactUsDTO>(savedWithService!);
        }

        public async Task<IEnumerable<ContactUsDTO>> GetAllAsync()
        {
            var data = await _repo.GetAllWithServiceAsync();
            return _mapper.Map<IEnumerable<ContactUsDTO>>(data);
        }

        public async Task<ContactUsDTO?> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdWithServiceAsync(id);
            return data != null ? _mapper.Map<ContactUsDTO>(data) : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
