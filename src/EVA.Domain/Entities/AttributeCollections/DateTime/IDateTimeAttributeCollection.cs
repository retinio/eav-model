using System.Collections.Generic;
using EVA.Domain.Attributes.Values;

namespace EVA.Domain.Entities.AttributeCollections.DateTime
{
    internal interface IDateTimeAttributeCollection
    {
        List<DateTimeAttributeValue> DateTimeAttributeValues { get; }
    }
}