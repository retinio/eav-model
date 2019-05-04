using System;

namespace EVA.Domain.Abstractions.Entity
{    
    public interface IDomainEntity
    {
        /// <summary>
        /// DateTime of create entity
        /// </summary>
        DateTimeOffset CreatedDateTime { get; }

        /// <summary>
        /// DateTime of modified entity
        /// </summary>
        DateTimeOffset? ModifiedDateTime { get;  }     
    }

    public interface IDomainEntity<T> : IDomainEntity
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        T Id { get; }
    }
}