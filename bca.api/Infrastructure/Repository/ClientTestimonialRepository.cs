using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class ClientTestimonialRepository: GenericRepository<ClientTestimonial>, IClientTestimonialRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientTestimonialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientTestimonial>> GetTopRatedTestimonialsAsync(int topCount = 5)
        {
            return await _context.ClientTestimonials
                .Where(t => t.Rating >= 4)
                .OrderByDescending(t => t.CreatedAt)
                .Take(topCount)
                .ToListAsync();
        }
    }
}
