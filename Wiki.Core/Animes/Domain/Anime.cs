#region Imports

using Domain.Aggregate;
using SPLAR.Wiki.Shared.Domain.Animes;
using SPLAR.Wiki.Shared.Domain.Studios;

#endregion

namespace SPAR.Wiki.Animes.Domain
{
    public class Anime : IAggregateRoot
    {
        #region Constructors

        private Anime()
        {
        }
        
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

        public AnimeId Id { get; set; }

        public AnimeName Name { get; set; }

        public StudioId StudioId { get; set; }

        #endregion
    }
}