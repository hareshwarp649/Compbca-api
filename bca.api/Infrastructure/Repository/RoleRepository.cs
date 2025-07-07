using bca.api.Data.Entities;
using bca.api.Data;
using Microsoft.EntityFrameworkCore;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Infrastructure.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllWithPermissionsAsync()
        {
            return await _context.Roles.Include(r => r.RolePermissions)
                               .ThenInclude(rp => rp.Permission)
                               .ToListAsync();
        }
    }
}
