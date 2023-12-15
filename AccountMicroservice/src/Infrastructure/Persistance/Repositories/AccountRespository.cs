using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class AccountRespository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRespository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Account ClienteAccount) => _context.Account.Add(ClienteAccount);

        public void Delete(Account ClienteAccount) => _context.Account.Remove(ClienteAccount);

        public async Task<bool> ExistsAsync(AccountID id) => await _context.Account.AnyAsync(c => c.AccountID == id);

        public async Task<List<Account>> GetAll() => await _context.Account.ToListAsync();

        public async Task<List<AccountID>> getAllByClientId(Guid ClienteId)
        {
            return await _context.Account
            .Where(account => account.ClienteId == ClienteId)
            .Select(account => account.AccountID)
            .ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(AccountID id) => await _context.Account.SingleOrDefaultAsync(c => c.AccountID == id);

        public async Task<Account> GetByIdWithMovementsAsync(AccountID accountId)
        {
            return await _context.Account
            .Include(account => account.Movimentos) // Incluir la propiedad de navegación Movements
             .FirstOrDefaultAsync(account => account.AccountID == accountId);
        }

        public void Update(Account ClienteAccount) => _context.Account.Update(ClienteAccount);

       


    }
}
