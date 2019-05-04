using System;
using System.Collections.Generic;
using EVA.Domain.Abstractions;
using EVA.Domain.Abstractions.Entity;

namespace EVA.Domain.Entities.Relationships
{
    public class Relations : DomainEntity<Guid>, IAggregate
    {
        public EntityType ReferencedEntityType { get; private set; }
        private Guid _referencedEntityTypeId;

        public EntityType ReferencingEntityType { get; private set; }
        private Guid _referencingEntityTypeId;

        public IEnumerable<EntityRelations> Entities => _entities.AsReadOnly();
        private List<EntityRelations> _entities;

        public string Name { get; private set; }

        protected Relations()
        {
            _entities = new List<EntityRelations>();
        }

        public override bool IsTransient()
        {
            return Id == Guid.Empty;
        }
    }
}