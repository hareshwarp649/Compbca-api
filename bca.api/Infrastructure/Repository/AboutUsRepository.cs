using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class AboutUsRepository : GenericRepository<AboutUs>, IAboutUsRepository
    {
        private readonly ApplicationDbContext _context;

        public AboutUsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AboutUs?> GetAboutUsPageAsync(int id)
        {
            //return await _context.AboutsUs
            //.Include(h => h.Title)
            //.FirstOrDefaultAsync(h => h.Id == id);

            return await _context.AboutsUs.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
        }
    }
}
