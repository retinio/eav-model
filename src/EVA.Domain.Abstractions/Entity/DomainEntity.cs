using System;

namespace EVA.Domain.Abstractions.Entity
{
    public abstract class DomainEntity : IDomainEntity
    {        
        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public long ModifiedTimeStamp
        {
            get
            {
                var span = (ModifiedDateTime ?? CreatedDateTime) -
                           new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return (long)span.TotalSeconds;
            }
        }

        public abstract bool IsTransient();

        public static bool operator ==(DomainEntity left, DomainEntity right)
        {
            return left?.Equals(right) ?? (Equals(right, null));
            
        }

        public static bool operator !=(DomainEntity left, DomainEntity right)
        {
            return !(left == right);
        }
    }

    public abstract class DomainEntity<T> : DomainEntity, IDomainEntity<T>
    {        
        public virtual T Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is DomainEntity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (DomainEntity<T>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (IsTransient()) return base.GetHashCode();
            return Id.GetHashCode() ^ 31;
        }
    }
}
