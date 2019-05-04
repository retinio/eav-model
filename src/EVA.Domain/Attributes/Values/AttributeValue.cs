using System;
using System.Collections.Generic;
using EVA.Domain.Abstractions;

namespace EVA.Domain.Attributes.Values
{
    public abstract class AttributeValue : ValueObject
    {
        protected AttributeValue(Guid entityId, Guid attributeId)
        {
            AttributeId = attributeId;
            EntityId = entityId;
        }

        public Attribute Attribute { get; private set; }
        public Guid AttributeId { get; private set; }

        public Guid EntityId { get; private set; }
    }

    public abstract class AttributeValue<T> : AttributeValue
    {
        protected AttributeValue(Guid entityId, Guid attributeId, T value) : base(entityId, attributeId)
        {
            Value = value;
        }

        public T Value { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Attribute?.Id;
            yield return EntityId;
            yield return Value;
        }
    }    
}