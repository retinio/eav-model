using System;

namespace EVA.Domain.Attributes.Values
{
    public class DecimalAttributeValue : AttributeValue<decimal>
    {
        public DecimalAttributeValue(Guid entityId, Guid attributeId, decimal value) : base(entityId, attributeId, value)
        {
        }
    }
}