#region Imports

using System;
using Microsoft.EntityFrameworkCore;
using SPLAR.Shared.Infrastructure.Persistence.EntityFramework;

#endregion

namespace SPLAR.Shared.Infrastructure.EntityFramework
{
    public class EntityFrameworkEntityManager : IDisposable
    {
        public DbContext Context { get; protected set; }

        protected EntityFrameworkEntityManager(DbContext oContext)
        {
            Context = oContext;
        }

        public static EntityFrameworkEntityManager Create(DbContext oContext)
        {
            return new(oContext);
        }

        public EntityFrameworkRepository GetRepository<TRepository>() where TRepository : EntityFrameworkRepository
        {
            return Activator.CreateInstance(typeof(TRepository), this) as TRepository;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}