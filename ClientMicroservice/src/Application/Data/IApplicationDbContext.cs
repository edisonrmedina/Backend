using Application.Comunication;
using Application.Comunication.Model;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Persona> Persona { get; set; }
    DbSet<ClienteAccount> Cliente { get; set; }

    DbSet<ClientCreateRequest> clientCreateRequests {  get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}