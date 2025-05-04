using Domain.Primitives;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Customers;
using MediatR;
using Microsoft.VisualBasic;
namespace Infrastructure.Persistencia;
public class ApplicationDbContext : DbContext, IAplicationDbContext, IUniOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base (options)
    {
        _publisher = publisher ?? throw new ArgumentException(nameof(publisher));
    }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    } 
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToke = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AgregateRoot>()
        .Select(e => e.Entity)
        .Where(e => e.GetDomainEvents().Any())
        .SelectMany(e => e.GetDomainEvents());
    var result = await base.SaveChangesAsync(cancellationToke);
    foreach (var domainEvent in domainEvents)
    {
        await _publisher.Publish(domainEvent, cancellationToke);

    }
    return result;
    }
}