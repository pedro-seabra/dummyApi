using dummyApi.src.Domain.Entities;
using dummyApi.src.Infrastructure.Contexts;using Microsoft.EntityFrameworkCore;

namespace dummyApi.src.Infrastructure.Repositories.MarketRepository
{
    public class MarketRepository : IMarketRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Market> AddAsync(Market market)
        {
            var newMarket = await _context.Markets.AddAsync(market);
            _context.SaveChanges();

            return newMarket.Entity;
        }

        public void Delete(Market market)
        {
            _context.Markets.Remove(market);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Market?>> GetAllAsync()
        {
            return await _context.Markets
                .Include(l => l.Location)
                .ToListAsync();
        }

        public async Task<Market?> GetByIdAsync(int id)
        {
            return await _context.Markets
                .Include(l => l.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Market> UpdateAsync(Market updatedMarket)
        {
            updatedMarket.setUpdatedAt(DateTime.UtcNow);
            var marketEntry = _context.Markets.Update(updatedMarket);
            await _context.SaveChangesAsync();
            return marketEntry.Entity;
        }
    }
}
