using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class SelectServiceService:ISelectServiceService
    {
        private readonly ISelectServiceRepository _repo;
        private readonly IMapper _mapper;

        public SelectServiceService(ISelectServiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SelectService>> GetAllAsync()
        {
            var services = await _repo.GetAllOrderedAsync();
            return _mapper.Map<IEnumerable<SelectService>>(services);
        }

        public async Task<SelectService> CreateAsync(SelectServiceDTO dto)
        {
            var entity = new SelectService
            {
                ServiceName = dto.ServiceName,
                CreatedDateTime = DateTime.Now
            };
            var result = await _repo.AddAsync(entity);
            return _mapper.Map<SelectService>(result);
        }

        public async Task<SelectService?> UpdateAsync(int id, SelectServiceDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.ServiceName = dto.ServiceName;
            await _repo.UpdateAsync(existing);
            return _mapper.Map<SelectService>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
