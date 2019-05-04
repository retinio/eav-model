using System;
using System.Threading.Tasks;
using EVA.Domain.Abstractions;
using EVA.Domain.Abstractions.Entity;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EVA.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : DomainEntity, IAggregate
    {
        protected EvaContext Context { get; private set; }

        protected Repository(EvaContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<T> AddAsync(T aggregate)
        {         
            var dbEntityEntry = await Context.Set<T>()
                .AddAsync(aggregate);
            return dbEntityEntry.Entity;
        }

        public virtual async Task<T> UpdateAsync(T aggregate)
        {
            aggregate.ModifiedDateTime = DateTimeOffset.UtcNow;
            var dbEntityEntry = Context.Entry(aggregate);
            dbEntityEntry.State = EntityState.Modified;
            return dbEntityEntry.Entity;
        }

        public virtual async Task<bool> DeleteAsync(T aggregate)
        {
            Context.Set<T>().Remove(aggregate);
            return true;
        }
    }
}