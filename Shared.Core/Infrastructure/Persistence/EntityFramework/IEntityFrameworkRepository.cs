using Domain.Aggregate;

namespace Infrastructure.Persistence.EntityFramework
{
    public interface IEntityFrameworkRepository<T> where T : IAggregateRoot
    {
    }
}