using System;
using EVA.Domain.Attributes.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Attribute.Values
{
    public class IntegerAttributeValueConfiguration : AttributeValueConfiguration<IntegerAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<IntegerAttributeValue> builder)
        {
            builder.ToTable("integer_entity_attribute_values");
            builder.Property(b => b.Value).HasColumnName("value").IsRequired();
            base.Configure(builder);
        }
    }
}