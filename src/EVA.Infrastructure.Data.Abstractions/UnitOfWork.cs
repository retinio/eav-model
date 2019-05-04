using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EVA.Infrastructure.Data.Abstractions
{
    public abstract class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        protected T Context { get; }

        protected UnitOfWork(T context)
        {
            Context = context;           
        }

        public abstract Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,CancellationToken cancellationToken = default(CancellationToken));
        
        public virtual async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}