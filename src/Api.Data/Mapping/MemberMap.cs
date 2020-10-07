using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class MemberMap : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder.ToTable("Member");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name)
                  .IsUnique();

            builder.Property(e => e.Name)
                   .IsRequired();
        }

    }
}
