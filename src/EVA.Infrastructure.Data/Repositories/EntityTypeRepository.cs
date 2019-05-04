using System;
using System.Threading.Tasks;
using EVA.Domain.Entities;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EVA.Infrastructure.Data.Repositories
{
    public class EntityTypeRepository : Repository<EntityType>, IEntityTypeRepository
    {
        public EntityTypeRepository(EvaContext context) : base(context)
        {
        }

        public async Task<EntityType> GetByIdAsync(Guid id)
        {
            return await Context.Set<EntityType>()
                .SingleOrDefaultAsync(a => a.Id == id);            
        }

        public async Task<EntityType> GetByNameAsync(string name)
        {
            return await Context.Set<EntityType>()
                .SingleOrDefaultAsync(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}