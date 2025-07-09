using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Infrastructure.Repository
{
    public class IndianClientRepository : GenericRepository<IndianClient>, IIndianClientRepository
    {
        public IndianClientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
