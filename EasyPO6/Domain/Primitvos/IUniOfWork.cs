namespace Domain.Primitives;

public interface IUniOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
}