using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class SelectServiceRepository : GenericRepository<SelectService>, ISelectServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public SelectServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectService>> GetAllOrderedAsync()
        {
            return await _context.SelectServices
                .OrderBy(s => s.ServiceName)
                .ToListAsync();
        }
    }
}
