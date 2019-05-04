using EVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Entity
{
    public class EntityTypeConfiguration : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> builder)
        {
            builder.ToTable("entity_types");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.CreatedDateTime).HasColumnName("created_date_time").IsRequired();
            builder.Property(b => b.ModifiedDateTime).HasColumnName("modified_date_time").IsRequired(false);
            builder.Property(b => b.Name).HasColumnName("name").HasMaxLength(128).IsRequired();
            builder.Property(b => b.Description).HasColumnName("description").IsRequired(false);
        }
    }
}