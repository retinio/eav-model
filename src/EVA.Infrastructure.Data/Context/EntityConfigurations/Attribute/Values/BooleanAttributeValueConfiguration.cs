using EVA.Domain.Attributes.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Attribute.Values
{
    public class BooleanAttributeValueConfiguration : AttributeValueConfiguration<BooleanAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<BooleanAttributeValue> builder)
        {
            builder.ToTable("boolean_entity_attribute_values");
            builder.Property(b => b.Value).HasColumnName("value").IsRequired();
            base.Configure(builder);
        }
    }
}