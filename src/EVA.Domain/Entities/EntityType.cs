using System;
using EVA.Domain.Abstractions;
using EVA.Domain.Abstractions.Entity;

namespace EVA.Domain.Entities
{
    public class EntityType : DomainEntity<Guid>, IAggregate
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        protected EntityType()
        {
        }

        public EntityType(string name, string description)
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTimeOffset.UtcNow;
            Name = name;
            Description = description;
        }

        public override bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        public Entity CreateEntity()
        {
            return new Entity(Id);
        }
    }
}