using dummyApi.src.Domain.Entities;

namespace dummyApi.src.Infrastructure.Repositories.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        // Dummy return for now
        public Location GetByIdAsync(int id)
        {
            return new Location(1, "515 Rue Francois app 212", "Verdun", "Quebec", "Canada", "H3E 1G5");
        }
    }
}
