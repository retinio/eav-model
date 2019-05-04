using System;
using EVA.Domain.Abstractions;
using EVA.Domain.Abstractions.Entity;

namespace EVA.Domain.Attributes
{
    public class Attribute : DomainEntity<Guid>, IAggregate
    {
        public AttributeType Type { get; private set; }
        private int _typeId;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; private set; }

        protected Attribute()
        {
        }

        public Attribute(int typeId, string name)
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTimeOffset.UtcNow;
            Name = name;            
            _typeId = typeId;
        }

        public Attribute(int typeId, string name, string description): this(typeId, name)
        {            
            Description = description;         
        }

        public override bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeType(AttributeType type)
        {
            _typeId = type.Id;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

    }
}