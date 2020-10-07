using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AssociateMap : IEntityTypeConfiguration<AssociateEntity>
    {
        public void Configure(EntityTypeBuilder<AssociateEntity> builder)
        {
            builder.ToTable("Associate");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.MemberId, e.OfficeId }).IsUnique();

            builder.HasOne(e => e.Office);

            builder.HasOne(e => e.Member);
        }

    }
}
