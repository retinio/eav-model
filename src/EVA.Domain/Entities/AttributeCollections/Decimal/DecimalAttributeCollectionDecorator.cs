using System;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Domain.Entities.AttributeCollections.Decimal
{
    public class DecimalAttributeCollectionDecorator : IAttributeCollectionDecorator
    {
        private readonly IDecimalAttributeCollection _attributeCollection;

        public DecimalAttributeCollectionDecorator(IDecimalAttributeCollection attributeCollection)
        {
            _attributeCollection = attributeCollection;
        }

        public void AddAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.DecimalAttributeValues.Add(new DecimalAttributeValue(entityId, attribute.Id, (decimal)value));
        }

        public void UpdateAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.DecimalAttributeValues.ReplaceValueObject(new DecimalAttributeValue(entityId, attribute.Id, (decimal)value));
        }
    }
}