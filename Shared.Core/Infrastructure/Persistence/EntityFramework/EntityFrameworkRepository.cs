#region Imports

using Microsoft.EntityFrameworkCore;
using SPLAR.Shared.Infrastructure.EntityFramework;

#endregion

namespace SPLAR.Shared.Infrastructure.Persistence.EntityFramework
{
    public class EntityFrameworkRepository
    {
        #region Variables

        internal DbContext _oContext;

        #endregion

        #region Properties

        protected DbContext Context => _oContext;
        
        #endregion

        #region Constructs

        public EntityFrameworkRepository(EntityFrameworkEntityManager oEntityManager)
        {
            _oContext = oEntityManager.Context;
            // _dbSet = _oContext.Set<TEntity>();
        }

        #endregion

        #region Methods
        
        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            return Context.Find<TEntity>(keyValues);
        }

        #endregion
    }
}