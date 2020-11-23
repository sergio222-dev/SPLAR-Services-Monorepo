#region Imports

using SPLAR.Wiki.Shared.Domain.Animes;
using SPLAR.Wiki.Shared.Domain.Studios;

#endregion

namespace SPAR.Wiki.Animes.Domain
{
    public class Anime
    {
        #region Constructors

        public Anime(AnimeId oId, AnimeName oAnimeName, StudioId oStudioId)
        {
            Id = oId;
            Name = oAnimeName;
            StudioId = oStudioId;
        }

        #endregion

        #region Public Methods

        public static Anime Create(AnimeId oId, AnimeName oName, StudioId oStudioId)
        {
            var oAnime = new Anime(oId, oName, oStudioId);

            //TODO: implement event sourcing here

            return oAnime;
        }

        #endregion

        #region Variables

        #endregion

        #region Property

        public AnimeId Id { get; }

        public AnimeName Name { get; }

        public StudioId StudioId { get; }

        #endregion
    }
}