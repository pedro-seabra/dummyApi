using dummyApi.src.Domain.Entities;

namespace dummyApi.src.Infrastructure.Repositories.MarketRepository
{
    public interface IMarketRepository
    {
        Task<Market?> GetByIdAsync(int id);
        Task<IEnumerable<Market?>> GetAllAsync();
        Task<Market> AddAsync(Market market);
        Task<Market> UpdateAsync(Market market);
        void Delete(Market market);
    }
}
