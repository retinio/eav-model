using System;
using EVA.Domain.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Relationships
{
    public class RelationsConfiguration : IEntityTypeConfiguration<Relations>
    {
        public void Configure(EntityTypeBuilder<Relations> builder)
        {
            builder.ToTable("relations");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.CreatedDateTime).HasColumnName("created_date_time").IsRequired();
            builder.Property(b => b.ModifiedDateTime).HasColumnName("modified_date_time").IsRequired(false);
            builder.Property(b => b.Name).HasColumnName("name").IsRequired();
            builder.Property<Guid>("ReferencedEntityTypeId").HasColumnName("referenced_entity_type_id").IsRequired();
            builder.Property<Guid>("ReferencingEntityTypeId").HasColumnName("referencing_entity_type_id").IsRequired();

            builder.HasOne(b => b.ReferencedEntityType)
                .WithMany()
                .HasForeignKey("ReferencedEntityTypeId");

            builder.HasOne(b => b.ReferencingEntityType)
                .WithMany()
                .HasForeignKey("ReferencingEntityTypeId");

            builder.HasMany(b => b.Entities)
                .WithOne()
                .HasForeignKey("RelationId");

            builder.Metadata.FindNavigation(nameof(Relations.Entities))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}