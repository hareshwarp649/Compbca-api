using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<Role>> GetAllWithPermissionsAsync();
    }
}
