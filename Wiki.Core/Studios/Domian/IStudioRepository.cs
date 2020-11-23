namespace SPAR.Wiki.Studios.Domain
{
    public interface IStudioRepository
    {
        public void Save(Studio oAnime);
        public Studio[] Search();
    }
}