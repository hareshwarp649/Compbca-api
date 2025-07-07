using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Infrastructure.Repository
{
    public class BankRepository : GenericRepository<Bank>, IBankRepository
    {
        public BankRepository(ApplicationDbContext context) : base(context) { }
    }
}
