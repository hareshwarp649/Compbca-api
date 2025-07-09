using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class IndianClientLogoRepository: GenericRepository<IndianClientLogo>, IIndianClientLogoRepository
    {
        private readonly ApplicationDbContext _context;

        public IndianClientLogoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IndianClientLogo?> GetIndianClientLogoPageAsync(int id)
        {
            //return await _context.AboutsUs
            //.Include(h => h.Title)
            //.FirstOrDefaultAsync(h => h.Id == id);

            return await _context.IndianClientLogos.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
        }
    }
}
