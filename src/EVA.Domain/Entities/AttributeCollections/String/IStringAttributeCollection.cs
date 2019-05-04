using System.Collections.Generic;
using EVA.Domain.Attributes.Values;

namespace EVA.Domain.Entities.AttributeCollections.String
{
    internal interface IStringAttributeCollection
    {
        List<StringAttributeValue> StringAttributeValues { get; }
    }
}