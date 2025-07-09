using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface IContactUsRepository: IGenericRepository<ContactUs>
    {
        Task<IEnumerable<ContactUs>> GetAllWithServiceAsync();
        Task<ContactUs?> GetByIdWithServiceAsync(int id);
    }
}
