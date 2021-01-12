#region Imports

using Microsoft.EntityFrameworkCore;
using SPAR.Wiki.Animes.Domain;
using SPLAR.Wiki.Shared.Domain.Animes;
using SPLAR.Wiki.Shared.Domain.Studios;
using Wiki.Core.Animes.Infrastructure.Persistence.Entity_Framework;

#endregion

namespace SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework
{
    public class WikiContext : DbContext
    {
        #region Variables

        private string _sConnection;

        #endregion
        
        #region Constructs

        public WikiContext()
        {
        }
        
        public WikiContext(string sConnection)
        {
            _sConnection = sConnection;
        }

        #endregion

        #region Entities

        public DbSet<Anime> Animes { get; set; }

        #endregion

        #region Mapping

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sConnection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}