#region Imports

using SPAR.Shared.Domain.ValueObject;
using SPLAR.Wiki.Shared.Domain.Animes;

#endregion

namespace SPAR.Wiki.Studios.Domain
{
    public class StudioAnimes : CollectionValueObject<AnimeId>
    {
        #region Constructors

        private StudioAnimes() {}
        
        public StudioAnimes(AnimeId[] lstAnimeIds) : base(lstAnimeIds)
        {
        }

        #endregion
    }
}