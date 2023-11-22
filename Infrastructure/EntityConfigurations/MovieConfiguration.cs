using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true);

            builder.Property(x => x.Description);

            builder.Property(x => x.Year).IsRequired(true);

            builder.HasOne(x => x.PosterImage)
                 .WithOne(i=>i.Movie)
                 .HasForeignKey<Image>(i => i.MovieId)
                 .IsRequired(true);
        }
    }
}
