using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class HomeMasterRepository : GenericRepository<HomeMaster>, IHomeMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public HomeMasterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<HomeMaster?> GetByIdWithGalleryAsync(int id)
        {
            return await _context.HomeMasters
            .Include(h => h.WorkingGalleries)
            .FirstOrDefaultAsync(h => h.Id == id);

            

        }
    }
}
