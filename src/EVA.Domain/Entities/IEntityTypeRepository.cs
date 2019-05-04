using System;
using System.Threading.Tasks;
using EVA.Domain.Abstractions;

namespace EVA.Domain.Entities
{
    public interface IEntityTypeRepository : IRepository<EntityType>
    {
        Task<EntityType> GetByIdAsync(Guid id);

        Task<EntityType> GetByNameAsync(string name);
    }
}