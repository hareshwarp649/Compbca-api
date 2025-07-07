using bca.api.Data.Entities;
using bca.api.Data;
using Microsoft.EntityFrameworkCore;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Infrastructure.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetRolesByUserIdAsync(string userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<UserRole> userRoles) // ✅ Add this method
        {
            await _context.UserRoles.AddRangeAsync(userRoles); // Bulk Insert
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRolesAsync(string userId, List<int> roleIds)
        {
            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == userId && roleIds.Contains(ur.RoleId))
            .ToListAsync();

            _context.UserRoles.RemoveRange(roles);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRole>> GetUsersByRoleNameAsync(string roleName)
        {
            return await _context.UserRoles
                .Where(ur => ur.Role.Name == roleName)
                .Include(ur => ur.User)
                .ThenInclude(u => u.Bank)
                .ToListAsync();
        }

        public async Task<bool> DeleteRolesAsync(string userId)
        {
            // First remove user roles
            var roles = await _context.UserRoles.Where(ur => ur.UserId == userId).ToListAsync();
            _context.UserRoles.RemoveRange(roles);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
