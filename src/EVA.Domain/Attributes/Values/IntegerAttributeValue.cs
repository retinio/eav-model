using System;

namespace EVA.Domain.Attributes.Values
{
    public class IntegerAttributeValue : AttributeValue<int>
    {
        public IntegerAttributeValue(Guid entityId, Guid attributeId, int value) : base(entityId, attributeId, value)
        {
        }
    }
}