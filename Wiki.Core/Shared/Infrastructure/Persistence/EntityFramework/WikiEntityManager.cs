#region Imports

using System;
using SPLAR.Shared.Infrastructure.EntityFramework;

#endregion

namespace SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework
{
    public class WikiEntityManager : EntityFrameworkEntityManager
    {
        // private WikiContext _oWikiContext;

        // public WikiContext Context => _oWikiContext;
        
        private WikiEntityManager(WikiContext oContext) : base(oContext)
        {
            // _oWikiContext = oContext;
        }

        // public static WikiEntityManager Create(WikiContext oContext)
        // {
        //     return new(oContext);
        // }

        // public TRepository GetRepository<TRepository>() where TRepository : EntityFrameworkRepository<>
        // {
        //     return (TRepository) Activator.CreateInstance(typeof(TRepository), Context);
        // }

        public void Dispose()
        {
            // TODO debug
            Console.WriteLine("Dispose Context DB");
            Context.Dispose();
        }
    }
}