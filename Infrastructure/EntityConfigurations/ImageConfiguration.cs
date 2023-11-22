using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UrlImage)
            .IsRequired(true);

        builder.HasOne(m => m.Movie)
             .WithOne(m=>m.PosterImage)
             .HasForeignKey<Image>(i => i.MovieId)
             .IsRequired();
    }
}