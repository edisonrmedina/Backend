using MediatR;

namespace Domain
{
    public interface IAccountRepository 
    {
        Task<List<Account>> GetAll();
        Task<Account?> GetByIdAsync(AccountID id);
        Task<bool> ExistsAsync(AccountID id);
        void Add(Account ClienteAccount);
        void Update(Account ClienteAccount);
        void Delete(Account ClienteAccount);
        Task<Account> GetByIdWithMovementsAsync(AccountID accountId);
        Task<List<AccountID>> getAllByClientId(Guid ClienteId);
    }
}
