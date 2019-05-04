using System.Threading.Tasks;

namespace EVA.Domain.Abstractions
{
    public interface IRepository<T> where T : IAggregate
    {
        Task<T> AddAsync(T aggregate);

        Task<T> UpdateAsync(T aggregate);

        Task<bool> DeleteAsync(T aggregate);
    }
}
