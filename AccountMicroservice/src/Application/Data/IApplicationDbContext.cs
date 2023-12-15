using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Movement> Movement { get; set; }
    DbSet<Account> Account { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}
