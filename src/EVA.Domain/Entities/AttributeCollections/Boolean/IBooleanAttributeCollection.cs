using System;
using System.Collections.Generic;
using EVA.Domain.Attributes.Values;

namespace EVA.Domain.Entities.AttributeCollections.Boolean
{
    internal interface IBooleanAttributeCollection 
    {        
        List<BooleanAttributeValue> BooleanAttributeValues { get; }
    }
}