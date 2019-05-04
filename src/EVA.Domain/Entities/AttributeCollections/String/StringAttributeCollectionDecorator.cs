using System;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Domain.Entities.AttributeCollections.String
{
    internal class StringAttributeCollectionDecorator : IAttributeCollectionDecorator
    {
        private readonly IStringAttributeCollection _attributeCollection;

        public StringAttributeCollectionDecorator(IStringAttributeCollection attributeCollection)
        {
            _attributeCollection = attributeCollection;
        }

        public void AddAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.StringAttributeValues.Add(new StringAttributeValue(entityId, attribute.Id, (string)value));            
        }

        public void UpdateAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.StringAttributeValues.ReplaceValueObject(new StringAttributeValue(entityId, attribute.Id, (string)value));
        }
    }
}