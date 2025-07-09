using bca.api.Data;
using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bca.api.Infrastructure.Repository
{
    public class ContactUsRepository:GenericRepository<ContactUs>, IContactUsRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactUsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactUs>> GetAllWithServiceAsync()
        {
            return await _context.ContactsUs.Include(c => c.SelectService).ToListAsync();

        }
        public async Task<ContactUs?> GetByIdWithServiceAsync(int id)
        {
            return await _context.ContactsUs.Include(c => c.SelectService).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
    
}
