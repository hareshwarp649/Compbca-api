using bca.api.Data.Entities;

namespace bca.api.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllBanksAsync();
        Task<Bank?> GetBankByIdAsync(int id);
        Task<Bank> CreateBankAsync(Bank bank);
        Task<Bank?> UpdateBankAsync(Bank bank);
        Task<bool> DeleteBankAsync(int id);
    }
}
