using SPAR.Wiki.Animes.Domain;
using SPLAR.Wiki.Shared.Domain.Animes;

namespace SPLAR.Wiki.Animes.Application.Delete
{
    public class AnimeDeleter
    {
        #region Variables

        private readonly IAnimeRepository _oAnimeRepository;

        #endregion

        #region Constructs

        public AnimeDeleter(IAnimeRepository oAnimeRepository)
        {
            _oAnimeRepository = oAnimeRepository;
        }

        #endregion

        #region Methods

        public void Delete(AnimeId id)
        {
        }

        #endregion
    }
}