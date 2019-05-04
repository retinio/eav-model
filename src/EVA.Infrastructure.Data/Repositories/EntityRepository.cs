using EVA.Domain.Entities;
using EVA.Infrastructure.Data.Context;

namespace EVA.Infrastructure.Data.Repositories
{
    public class EntityRepository : Repository<Entity>, IEntityRepository
    {
        public EntityRepository(EvaContext context) : base(context)
        {
        }
    }
}