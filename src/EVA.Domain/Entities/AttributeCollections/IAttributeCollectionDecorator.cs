using System;

namespace EVA.Domain.Entities.AttributeCollections
{
    internal interface IAttributeCollectionDecorator
    {
        void AddAttributeValue(Guid entityId, Attributes.Attribute attribute, object value);

        void UpdateAttributeValue(Guid entityId, Attributes.Attribute attribute, object value);
    }
}