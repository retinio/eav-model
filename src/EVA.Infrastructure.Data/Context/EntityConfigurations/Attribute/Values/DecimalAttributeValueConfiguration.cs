using System;
using EVA.Domain.Attributes.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Attribute.Values
{
    public class DecimalAttributeValueConfiguration : AttributeValueConfiguration<DecimalAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<DecimalAttributeValue> builder)
        {
            builder.ToTable("decimal_entity_attribute_values");
            builder.Property(b => b.Value).HasColumnName("value").IsRequired();
            base.Configure(builder);            
        }
    }
}