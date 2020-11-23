#region Imports

using SPAR.Wiki.Animes.Domain;
using SPLAR.Wiki.Shared.Domain.Animes;
using SPLAR.Wiki.Shared.Domain.Studios;

#endregion

namespace SPLAR.Wiki.Animes.Application.Create
{
    public sealed class AnimeCreator
    {
        #region Variables

        private readonly IAnimeRepository _oAnimeRepository;

        #endregion

        #region Constructors

        public AnimeCreator(IAnimeRepository oAnimeRepository)
        {
            _oAnimeRepository = oAnimeRepository;
        }

        #endregion

        #region Create

        public void Create(AnimeId oId, AnimeName oName, StudioId oStudioId)
        {
            var oAnime = Anime.Create(oId, oName, oStudioId);

            _oAnimeRepository.Save(oAnime);
            //TODO: publish events here
        }

        #endregion
    }
}