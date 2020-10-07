using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ElectionMap : IEntityTypeConfiguration<ElectionEntity>
    {
        public void Configure(EntityTypeBuilder<ElectionEntity> builder)
        {
            builder.ToTable("Election");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name)
                  .IsUnique();

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(60);



            builder.HasMany(e => e.Offices)
                   .WithOne(m => m.Election);

        }

    }
}
