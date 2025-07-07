using bca.api.Data.Entities;

namespace bca.api.Infrastructure.IRepository
{
    public interface IUserDocumentRepository : IGenericRepository<UserDocument>
    {
        Task<IEnumerable<UserDocument>> GetUserDocumentsAsync(int userId);
    }
}
