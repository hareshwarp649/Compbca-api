using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class WorkingGalleryRepository : GenericRepository<WorkingGallery>, IWorkingGalleryRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkingGalleryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkingGallery>> GetByHomeMasterIdAsync(int homeMasterId)
        {
            return await _context.WorkingGalleries
                .Where(w => w.HomeMasterId == homeMasterId)
                .ToListAsync();
        }
    }
}
