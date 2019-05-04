using System.Data;
using System.Threading;
using System.Threading.Tasks;
using EVA.Domain.Attributes;
using EVA.Domain.Entities;
using EVA.Infrastructure.Data.Abstractions;
using EVA.Infrastructure.Data.Context;
using EVA.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EVA.Infrastructure.Data
{
    public class EvaUnitOfWork : UnitOfWork<EvaContext>, IEvaUnitOfWork
    {
        private IAttributeRepository _attributeRepository;
        private IEntityTypeRepository _entityTypeRepository;
        private IEntityRepository _entityRepository;

        public EvaUnitOfWork(EvaContext context) : base(context)
        {
        }

        public override async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        }
        
        public IAttributeRepository AttributeRepository
        {
            get
            {
                if (_attributeRepository != null) return _attributeRepository;
                return _attributeRepository = new AttributeRepository(Context);
            }
        }

        public IEntityTypeRepository EntityTypeRepository
        {
            get
            {
                if (_entityTypeRepository != null) return _entityTypeRepository;
                return _entityTypeRepository = new EntityTypeRepository(Context);
            }
        }

        public IEntityRepository EntityRepository
        {
            get
            {
                if (_entityRepository != null) return _entityRepository;
                return _entityRepository = new EntityRepository(Context);
            }
        }
    }
}