#region Imports

using System.Linq;
using SPAR.Wiki.Animes.Domain;
using SPLAR.Shared.Infrastructure.EntityFramework;
using SPLAR.Shared.Infrastructure.Persistence.EntityFramework;
using SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework;

#endregion

namespace SPAR.Wiki.Animes.Infrastructure.Persistence
{
    public class EntityFrameworkAnimeRepository : EntityFrameworkRepository, IAnimeRepository
    {
        #region Constructs

        public EntityFrameworkAnimeRepository(EntityFrameworkEntityManager oEntityManager) : base(oEntityManager)
        {
        }

        #endregion

        #region Methods

        public void Save(Anime oAnime)
        {
            Context.Add(oAnime);
            Context.SaveChanges();
        }

        public Anime[] Search()
        {
            var context = Context as WikiContext;

            var animes = from anime in context.Animes select anime;
            
            return animes.ToArray();
        }

        #endregion
    }
}