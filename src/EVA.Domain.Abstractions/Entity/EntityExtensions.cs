using System.Collections.Generic;

namespace EVA.Domain.Abstractions.Entity
{
    public static class EntityExtensions
    {
        public static void ReplaceEntity<T>(this List<T> collection, T entity) where T : DomainEntity
        {
            var index = collection.IndexOf(entity);
            if (index != -1)
                collection[index] = entity;
        }

        public static void ReplaceValueObject<T>(this List<T> collection, T entity) where T : ValueObject
        {
            var index = collection.IndexOf(entity);
            if (index != -1)
                collection[index] = entity;
        }
    }
}