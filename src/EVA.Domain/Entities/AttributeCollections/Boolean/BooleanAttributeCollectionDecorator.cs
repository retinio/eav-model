using System;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Domain.Entities.AttributeCollections.Boolean
{
    internal class BooleanAttributeCollectionDecorator : IAttributeCollectionDecorator
    {
        private readonly IBooleanAttributeCollection _attributeCollection;

        public BooleanAttributeCollectionDecorator(IBooleanAttributeCollection attributeCollection)
        {
            _attributeCollection = attributeCollection;
        }
 
        public void AddAttributeValue(Guid entityId, Attributes.Attribute attribute, object value)
        {            
            _attributeCollection.BooleanAttributeValues.Add(new BooleanAttributeValue(entityId, attribute.Id, (bool)value));
        }

        public void UpdateAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.BooleanAttributeValues.ReplaceValueObject(new BooleanAttributeValue(entityId, attribute.Id, (bool)value));            
        }
    }
}