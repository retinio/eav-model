using System;
using System.Collections.Generic;
using EVA.Domain.Abstractions;

namespace EVA.Domain.Entities.Relationships
{
    public class EntityRelations : ValueObject
    {
        public Guid RelationId { get; private set; }

        public Guid ReferencedEntityId { get; private set; }

        public Guid ReferencingEntityId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return RelationId;
            yield return ReferencedEntityId;
            yield return ReferencingEntityId;
        }
    }
}