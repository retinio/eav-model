using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVA.Domain.Abstractions;

namespace EVA.Domain.Attributes
{
    public interface IAttributeRepository : IRepository<Attribute>
    {
        Task<Attribute> GetByIdAsync(Guid id);

        Task<IEnumerable<Attribute>> GetByNamesAsync(string[] names);
    }
}