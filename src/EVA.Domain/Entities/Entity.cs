using System;
using System.Collections.Generic;
using EVA.Domain.Abstractions;
using EVA.Domain.Abstractions.Entity;
using EVA.Domain.Attributes.Values;
using EVA.Domain.Entities.AttributeCollections;
using EVA.Domain.Entities.AttributeCollections.Boolean;
using EVA.Domain.Entities.AttributeCollections.DateTime;
using EVA.Domain.Entities.AttributeCollections.Decimal;
using EVA.Domain.Entities.AttributeCollections.Integer;
using EVA.Domain.Entities.AttributeCollections.String;

namespace EVA.Domain.Entities
{
    public class Entity : DomainEntity<Guid>, 
        IAggregate, 
        IBooleanAttributeCollection,
        IIntegerAttributeCollection,
        IDateTimeAttributeCollection,
        IDecimalAttributeCollection,
        IStringAttributeCollection
    {
        private AttributeCollectionDecoratorFactory _collectionDecoratorFactory;

        public List<BooleanAttributeValue> BooleanAttributeValues => _booleanAttributeValues;
        private List<BooleanAttributeValue> _booleanAttributeValues;

        public List<IntegerAttributeValue> IntegerAttributeValues => _integerAttributeValues;
        private List<IntegerAttributeValue> _integerAttributeValues;

        public List<DecimalAttributeValue> DecimalAttributeValues => _decimalAttributeValues;
        private List<DecimalAttributeValue> _decimalAttributeValues;

        public List<StringAttributeValue> StringAttributeValues => _stringAttributeValues;
        private List<StringAttributeValue> _stringAttributeValues;

        public List<DateTimeAttributeValue> DateTimeAttributeValues => _dateTimeAttributeValues;
        private List<DateTimeAttributeValue> _dateTimeAttributeValues;
                
        public EntityType Type { get; private set; }
        private Guid _typeId;

        protected Entity()
        {
            _booleanAttributeValues = new List<BooleanAttributeValue>();
            _integerAttributeValues = new List<IntegerAttributeValue>();
            _decimalAttributeValues = new List<DecimalAttributeValue>();
            _stringAttributeValues = new List<StringAttributeValue>();
            _dateTimeAttributeValues = new List<DateTimeAttributeValue>();

            _collectionDecoratorFactory = new AttributeCollectionDecoratorFactory(this);
        }

        public Entity(Guid typeId): this()
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTimeOffset.UtcNow;
            _typeId = typeId;
        }

        public override bool IsTransient()
        {
            return Id == Guid.Empty;            
        }

        public void AddAttributeValue(Attributes.Attribute attribute, object value)
        {
            var attributeCollectionDecorator = _collectionDecoratorFactory.Create(attribute.Type);
            if (attributeCollectionDecorator == null)
                throw new DomainException($"Can't create AttributeCollectionDecorator by attribute type {attribute.Type.Name}");

            attributeCollectionDecorator.AddAttributeValue(Id, attribute, value);
        }

        public void UpdateAttributeValue(Attributes.Attribute attribute, object value)
        {
            var attributeCollectionDecorator = _collectionDecoratorFactory.Create(attribute.Type);
            if (attributeCollectionDecorator == null)
                throw new DomainException($"Can't create AttributeCollectionDecorator by attribute type {attribute.Type.Name}");

            attributeCollectionDecorator.UpdateAttributeValue(Id, attribute, value);
        }
    }
}