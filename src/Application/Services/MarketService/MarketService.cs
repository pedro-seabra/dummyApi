using dummyApi.src.Application.DTOs;
using dummyApi.src.Domain.Entities;
using dummyApi.src.Infrastructure.Repositories.MarketRepository;

namespace dummyApi.src.Application.Services.MarketService
{

    public class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;

        public MarketService(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        public async Task<IEnumerable<Market?>> GetAllAsync()
        {
            return await _marketRepository.GetAllAsync();
        }

        public async Task<Market?> GetByIdAsync(int id)
        {
            return await _marketRepository.GetByIdAsync(id);
        }

        public async Task<Market> AddAsync(Market market)
        {
            return await _marketRepository.AddAsync(market);
        }

        public async Task Delete(int id)
        {
            Market? market = await GetByIdAsync(id);
            if (market is null) throw new InvalidOperationException("Market not found");

            _marketRepository.Delete(market);
        }

        public async Task<Market> PutUpdateAsync(int id, Market updateMarket)
        {
            var market = await _marketRepository.GetByIdAsync(id);
            if (market is null)
                throw new InvalidOperationException("Cannot update a market that doesn't exist");

            market.setName(updateMarket.Name);
            market.Location.setAddress(updateMarket.Location.Address);
            market.Location.setCity(updateMarket.Location.City);
            market.Location.setState(updateMarket.Location.State);
            market.Location.setCountry(updateMarket.Location.Country);
            market.Location.setZipCode(updateMarket.Location.ZipCode);

            return await _marketRepository.UpdateAsync(market);
        }

        public async Task<Market> PatchUpdateAsync(int id, MarketDto market)
        {
            var existingMarket = await _marketRepository.GetByIdAsync(id);

            if (existingMarket is null)
                throw new InvalidOperationException("Cannot update a market that doesn't exist");

            if (market.Name is not null)
                existingMarket.setName(market.Name);

            if (market.Location is not null)
            {
                if (market.Location.Address is not null)
                    existingMarket.Location.setAddress(market.Location.Address);
                if (market.Location.City is not null)
                    existingMarket.Location.setCity(market.Location.City);
                if (market.Location.State is not null)
                    existingMarket.Location.setState(market.Location.State);
                if (market.Location.Country is not null)
                    existingMarket.Location.setCountry(market.Location.Country);
                if (market.Location.ZipCode is not null)
                    existingMarket.Location.setZipCode(market.Location.ZipCode);
            }

            return await _marketRepository.UpdateAsync(existingMarket);
        }
    }
}
