using System;

namespace EVA.Domain.Attributes.Values
{
    public class DateTimeAttributeValue : AttributeValue<DateTime>
    {
        public DateTimeAttributeValue(Guid entityId, Guid attributeId, DateTime value) : base(entityId, attributeId, value)
        {
        }
    }
}