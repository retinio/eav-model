using EVA.Domain.Attributes;
using EVA.Domain.Entities;
using EVA.Infrastructure.Data.Abstractions;

namespace EVA.Infrastructure.Data
{
    public interface IEvaUnitOfWork : IUnitOfWork
    {
        IAttributeRepository AttributeRepository { get; }

        IEntityTypeRepository EntityTypeRepository { get; }

        IEntityRepository EntityRepository { get; }
    }
}