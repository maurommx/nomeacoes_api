using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ElectedMap : IEntityTypeConfiguration<ElectedEntity>
    {
        public void Configure(EntityTypeBuilder<ElectedEntity> builder)
        {
            builder.ToTable("Elected");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.MemberId, e.OfficeId }).IsUnique();

            // builder.HasOne(e => e.Office)
            //        .WithOne(m => m.) ;

            builder.HasOne(e => e.Office);
            builder.HasOne(e => e.Member);
        }

    }
}
