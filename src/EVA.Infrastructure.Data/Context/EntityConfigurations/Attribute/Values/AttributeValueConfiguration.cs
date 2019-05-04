using System;
using EVA.Domain.Attributes.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Attribute.Values
{
    public abstract class AttributeValueConfiguration<T> : IEntityTypeConfiguration<T> where T : AttributeValue
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => new { b.EntityId, b.AttributeId });
            builder.Property(b => b.EntityId).HasColumnName("entity_id").IsRequired();            
            builder.Property(b=> b.AttributeId).HasColumnName("attribute_id").IsRequired();

            builder.HasOne(b => b.Attribute)
                .WithMany()
                .HasForeignKey("AttributeId");
        }
    }
}