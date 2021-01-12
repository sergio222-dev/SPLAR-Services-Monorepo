#region Imports

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPAR.Wiki.Animes.Domain;
using SPLAR.Wiki.Shared.Domain.Animes;

#endregion

namespace Wiki.Core.Animes.Infrastructure.Persistence.Entity_Framework
{
    public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            // https://stackoverflow.com/questions/49607375/ef-core-dbcontext-map-custom-type-as-primary-key
            // http://thedatafarm.com/data-access/entity-framework-private-constructors-and-private-setters/
            builder.ToTable("Animes");
            builder.HasKey(anime => new { anime.Id });
            builder
                .Property<AnimeId>("Id")
                .HasConversion(
                    id => id.Value, 
                    guid => new AnimeId(guid),
                    new ValueComparer<AnimeId>(
                        (l, r) => l.Value == r.Value,
                        v => v.Value.GetHashCode(),
                        v => new AnimeId(v.Value)
                        )
                    );

            // https://github.com/dotnet/efcore/issues/23788
            // https://www.edgesidesolutions.com/ddd-value-objects-with-entity-framework-core/
            builder.OwnsOne(p => p.Name, a =>
            {
                a.Property<string>("Value").HasColumnName("Name");
                a.WithOwner();
            });

            builder.Navigation(a => a.Name);

            builder.OwnsOne(m => m.StudioId, a =>
            {
                a.Property<Guid>("Value").HasColumnName("StudioId");
                a.WithOwner();
            });

            
        }
    }
}