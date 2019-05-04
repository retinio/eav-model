using System.Collections;
using System.Collections.Generic;
using EVA.Domain.Entities.AttributeCollections.Boolean;
using EVA.Domain.Entities.AttributeCollections.DateTime;
using EVA.Domain.Entities.AttributeCollections.Decimal;
using EVA.Domain.Entities.AttributeCollections.Integer;
using EVA.Domain.Entities.AttributeCollections.String;

namespace EVA.Domain.Entities.AttributeCollections
{
    internal class AttributeCollectionDecoratorFactory
    {        
        private readonly IDictionary<int, IAttributeCollectionDecorator> _attributeCollectionDecorators;

        public AttributeCollectionDecoratorFactory(Entity entity)
        {
            _attributeCollectionDecorators = new Dictionary<int, IAttributeCollectionDecorator>
            {
                {Attributes.AttributeType.Boolean.Id, new BooleanAttributeCollectionDecorator(entity)},
                {Attributes.AttributeType.DateTime.Id, new DateTimeAttributeCollectionDecorator(entity)},
                {Attributes.AttributeType.Decimal.Id, new DecimalAttributeCollectionDecorator(entity)},
                {Attributes.AttributeType.Integer.Id, new IntegerAttributeCollectionDecorator(entity)},
                {Attributes.AttributeType.String.Id, new StringAttributeCollectionDecorator(entity)}
            };
        }

        public IAttributeCollectionDecorator Create(Attributes.AttributeType attributeType)
        {
            return _attributeCollectionDecorators.ContainsKey(attributeType.Id) ? _attributeCollectionDecorators[attributeType.Id] : null;
        }
    }
}