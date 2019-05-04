using System;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Domain.Entities.AttributeCollections.Integer
{
    internal class IntegerAttributeCollectionDecorator : IAttributeCollectionDecorator
    {
        private readonly IIntegerAttributeCollection _attributeCollection;

        public IntegerAttributeCollectionDecorator(IIntegerAttributeCollection attributeCollection)
        {
            _attributeCollection = attributeCollection;
        }

        public void AddAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.IntegerAttributeValues.Add(new IntegerAttributeValue(entityId, attribute.Id, (int)value));
        }

        public void UpdateAttributeValue(Guid entityId, Attribute attribute, object value)
        {

            _attributeCollection.IntegerAttributeValues.ReplaceValueObject(new IntegerAttributeValue(entityId, attribute.Id, (int)value));
        }
    }
}