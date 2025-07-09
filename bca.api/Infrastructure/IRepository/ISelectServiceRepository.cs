using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface ISelectServiceRepository : IGenericRepository<SelectService>
    {
        Task<IEnumerable<SelectService>> GetAllOrderedAsync();
    }
}
