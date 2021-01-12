using System.Data.Entity;

namespace Wiki.Shared.Infrastructure.Persistence.EntityFramework
{
    public class WikiContext : DbContext
    {
        public WikiContext(){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Anime>()
        }
    }
}