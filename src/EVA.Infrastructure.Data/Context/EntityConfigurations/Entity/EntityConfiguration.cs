using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Entity
{
    public class EntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Entity>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Entity> builder)
        {
            builder.ToTable("entities");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.CreatedDateTime).HasColumnName("created_date_time").IsRequired();
            builder.Property(b => b.ModifiedDateTime).HasColumnName("modified_date_time").IsRequired(false);
            builder.Property<Guid>("TypeId").HasColumnName("type_id").IsRequired();

            builder.HasOne(b => b.Type)
                .WithMany()
                .HasForeignKey("TypeId");

            builder.HasMany(b => b.BooleanAttributeValues)
                .WithOne()
                .HasForeignKey("EntityId");

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Entity.BooleanAttributeValues))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(b => b.DateTimeAttributeValues)
                .WithOne()
                .HasForeignKey("EntityId");

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Entity.DateTimeAttributeValues))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(b => b.DecimalAttributeValues)
                .WithOne()
                .HasForeignKey("EntityId");

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Entity.DecimalAttributeValues))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(b => b.IntegerAttributeValues)
                .WithOne()
                .HasForeignKey("EntityId");

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Entity.IntegerAttributeValues))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(b => b.StringAttributeValues)
                .WithOne()
                .HasForeignKey("EntityId");

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Entity.StringAttributeValues))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}