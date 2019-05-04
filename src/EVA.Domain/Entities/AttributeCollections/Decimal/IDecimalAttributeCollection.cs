using System.Collections.Generic;
using EVA.Domain.Attributes.Values;

namespace EVA.Domain.Entities.AttributeCollections.Decimal
{
    public interface IDecimalAttributeCollection
    {
        List<DecimalAttributeValue> DecimalAttributeValues { get; }
    }
}