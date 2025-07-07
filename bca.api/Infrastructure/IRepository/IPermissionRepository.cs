using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllWithRolesAsync();
        Task<IEnumerable<Permission>> SearchAndSortPermissionsAsync(
            string? name, string? category, string? description,
            string? sortBy, string? sortOrder, int pageNumber, int pageSize);

       Task<bool> HasPermissionAsync(string userName, string permissionName);
    }
}
