using System.Collections.Generic;
using EVA.Domain.Attributes.Values;

namespace EVA.Domain.Entities.AttributeCollections.Integer
{
    internal interface IIntegerAttributeCollection
    {
        List<IntegerAttributeValue> IntegerAttributeValues { get; }
    }
}