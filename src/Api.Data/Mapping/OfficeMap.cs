using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class OfficeMap : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.ToTable("Office");

            builder.HasKey(o => o.Id);

            builder.HasIndex(o => o.Name)
                  .IsUnique();

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(60);


            builder.HasMany(o => o.Electeds);
            //    .HasForeignKey<ElectedEntity>(m => m.MemberId);

            builder.HasMany(o => o.Associates);
            //    .WithOne(m => m.Office);
            //    .HasForeignKey<AssociateEntity>(m => m.a);

        }


    }
}
