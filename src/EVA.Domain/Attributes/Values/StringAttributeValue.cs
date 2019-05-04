using System;

namespace EVA.Domain.Attributes.Values
{
    public class StringAttributeValue : AttributeValue<string>
    {
        public StringAttributeValue(Guid entityId, Guid attributeId, string value) : base(entityId, attributeId, value)
        {
        }
    }
}