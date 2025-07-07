using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface IEmployeeDocumentRepository : IGenericRepository<EmployeeDocument>
    {
        Task<IEnumerable<EmployeeDocument>> GetEmployeeDocumentsAsync(int userId);
    }
}
