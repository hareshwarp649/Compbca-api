using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class InternationalClientLogoRepository: GenericRepository<InternationalClientLogo>, IInternationalClientLogoRepository
    {
        private readonly ApplicationDbContext _context;

        public InternationalClientLogoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<InternationalClientLogo?> GetInternationalClientLogoPageAsync(int id)
        {
            

            return await _context.InternationalClientLogos.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
        }
    }
}
