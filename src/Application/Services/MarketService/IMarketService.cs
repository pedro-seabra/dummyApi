using dummyApi.src.Application.DTOs;
using dummyApi.src.Domain.Entities;

namespace dummyApi.src.Application.Services.MarketService
{
    public interface IMarketService
    {
        public Task<Market?>GetByIdAsync(int id);
        public Task<IEnumerable<Market?>> GetAllAsync();
        public Task<Market> AddAsync(Market market);
        public Task Delete(int id);
        public Task<Market> PutUpdateAsync(int id, Market market);
        public Task<Market> PatchUpdateAsync(int id, MarketDto market);
    }
}
