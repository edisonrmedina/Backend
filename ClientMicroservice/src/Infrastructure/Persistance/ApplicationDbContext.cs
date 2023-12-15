using Application.Comunication.Model;
using Application.Data;
using Domain;
using Domain.Primitive;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{

    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        Persona = Set<Persona>();
        Cliente = Set<ClienteAccount>();
        clientCreateRequests = Set<ClientCreateRequest>();
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }


    public DbSet<Persona> Persona { get; set; }
    public DbSet<ClienteAccount> Cliente { get; set; }
    public DbSet<ClientCreateRequest> clientCreateRequests { get; set ; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e => e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}