using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVA.Domain.Attributes;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Attribute = EVA.Domain.Attributes.Attribute;

namespace EVA.Infrastructure.Data.Repositories
{
    public class AttributeRepository : Repository<Attribute>, IAttributeRepository
    {
        public AttributeRepository(EvaContext context) : base(context)
        {
        }

        public async Task<Attribute> GetByIdAsync(Guid id)
        {
            return await Context.Set<Attribute>()
                .Include(a => a.Type)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Attribute>> GetByNamesAsync(string[] names)
        {
            return await Context.Set<Attribute>()
                .Include(a => a.Type)
                .Where(a => names.Any(n => string.Equals(a.Name, n, StringComparison.OrdinalIgnoreCase))).ToArrayAsync();
        }
    }
}