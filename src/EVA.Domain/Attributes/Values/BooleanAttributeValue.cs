using System;

namespace EVA.Domain.Attributes.Values
{
    public class BooleanAttributeValue : AttributeValue<bool>
    {
        public BooleanAttributeValue(Guid entityId, Guid attributeId, bool value) : base(entityId, attributeId, value)
        {

        }
    }
}