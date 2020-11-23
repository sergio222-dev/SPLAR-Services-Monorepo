#region Imports

using SPLAR.Shared.Domain.ValueObjects;
using SPLAR.Wiki.Shared.Domain.Animes;

#endregion

namespace SPAR.Wiki.Studios.Domain
{
    public class StudioAnimes : CollectionValueObject<AnimeId>
    {
        #region Constructors

        public StudioAnimes(AnimeId[] lstAnimeIds) : base(lstAnimeIds)
        {
        }

        #endregion
    }
}