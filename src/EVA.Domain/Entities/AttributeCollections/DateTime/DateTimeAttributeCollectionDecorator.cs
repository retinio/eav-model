using System;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Domain.Entities.AttributeCollections.DateTime
{
    internal class DateTimeAttributeCollectionDecorator : IAttributeCollectionDecorator
    {
        private readonly IDateTimeAttributeCollection _attributeCollection;

        public DateTimeAttributeCollectionDecorator(IDateTimeAttributeCollection attributeCollection)
        {
            _attributeCollection = attributeCollection;
        }

        public void AddAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.DateTimeAttributeValues.Add(new DateTimeAttributeValue(entityId, attribute.Id, System.DateTime.Parse(value.ToString())));        
        }

        public void UpdateAttributeValue(Guid entityId, Attribute attribute, object value)
        {
            _attributeCollection.DateTimeAttributeValues.ReplaceValueObject(new DateTimeAttributeValue(entityId, attribute.Id, System.DateTime.Parse(value.ToString())));
        }
    }
}