using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class IndianClientService : IIndianClientService
    {
        private readonly IIndianClientRepository _repo;
        private readonly IMapper _mapper;

        public IndianClientService(IIndianClientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IndianClientDTO> CreateAsync(IndianClientCreateDTO dto)
        {
            var entity = _mapper.Map<IndianClient>(dto);
            var result = await _repo.AddAsync(entity);
            return _mapper.Map<IndianClientDTO>(result);
        }

        public async Task<IEnumerable<IndianClientDTO>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<IndianClientDTO>>(data);
        }

        public async Task<IndianClientDTO?> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<IndianClientDTO>(data);
        }

        public async Task<IndianClientDTO?> UpdateAsync(int id, IndianClientCreateDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing); // update properties from dto to existing entity
            await _repo.UpdateAsync(existing);

            return _mapper.Map<IndianClientDTO>(existing);
        }

       

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
