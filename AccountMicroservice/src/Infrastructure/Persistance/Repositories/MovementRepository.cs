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
    public class MovementRespository : IMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementRespository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Movement ClienteAccount) => _context.Movement.Add(ClienteAccount);

        public void Delete(Movement ClienteAccount) => _context.Movement.Remove(ClienteAccount);

        public async Task<bool> ExistsAsync(MovementId id) => await _context.Movement.AnyAsync(c => c.MovementId == id);

        public async Task<List<Movement>> GetAll() => await _context.Movement.ToListAsync();

        public async Task<Movement?> GetByIdAsync(MovementId id) => await _context.Movement.SingleOrDefaultAsync(c => c.MovementId == id);

        public async Task<List<Movement>> GetMovimientosByDateRangeAndAccountsAsync(DateTime fechaInicio, DateTime fechaFin, List<AccountID> cuentaIds)
        {
            return await _context.Movement
                .Where(m => m.Fecha >= fechaInicio && m.Fecha <= fechaFin && cuentaIds.Contains(m.AccountFk))
                .GroupBy(m => m.AccountFk)
                .Select(group => group.FirstOrDefault()) 
                .ToListAsync();
        }


        public void Update(Movement ClienteAccount) => _context.Movement.Update(ClienteAccount);

    }
}
