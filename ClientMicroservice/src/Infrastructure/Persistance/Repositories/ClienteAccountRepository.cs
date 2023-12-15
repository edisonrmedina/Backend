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
    public class ClienteAccountRespository : IClienteAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteAccountRespository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(ClienteAccount ClienteAccount) => _context.Cliente.Add(ClienteAccount);

        public void Delete(ClienteAccount ClienteAccount) => _context.Cliente.Remove(ClienteAccount);

        public async Task<bool> ExistsAsync(PersonaId id) => await  _context.Cliente.AnyAsync(c => c.PersonaId == id);
  
        public async Task<List<ClienteAccount>> GetAll() => await _context.Cliente.ToListAsync();

        public async Task<ClienteAccount?> GetByIdAsync(PersonaId id) => await _context.Cliente.SingleOrDefaultAsync(c => c.PersonaId == id);

        public void Update(ClienteAccount ClienteAccount) => _context.Cliente.Update(ClienteAccount);

    }
}
