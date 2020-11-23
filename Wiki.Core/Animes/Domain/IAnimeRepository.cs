namespace SPAR.Wiki.Animes.Domain
{
    public interface IAnimeRepository
    {
        public void Save(Anime oAnime);
        public Anime[] Search();
    }
}