using bca.api.Data.Entities;
using bca.api.Infrastructure.IRepository;

namespace bca.api.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync()
        {
            return await _bankRepository.GetAllAsync();
        }

        public async Task<Bank?> GetBankByIdAsync(int id)
        {
            return await _bankRepository.GetByIdAsync(id);
        }

        public async Task<Bank> CreateBankAsync(Bank bank)
        {
            return await _bankRepository.AddAsync(bank);
        }

        public async Task<Bank?> UpdateBankAsync(Bank bank)
        {
            return await _bankRepository.UpdateAsync(bank);
        }

        public async Task<bool> DeleteBankAsync(int id)
        {
            return await _bankRepository.DeleteAsync(id);
        }
    }
}
