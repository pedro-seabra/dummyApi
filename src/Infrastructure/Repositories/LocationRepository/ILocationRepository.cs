using dummyApi.src.Domain.Entities;

namespace dummyApi.src.Infrastructure.Repositories.LocationRepository
{
    public interface ILocationRepository
    {
        // Define methods for Location repository
        Location GetByIdAsync(int id);
    }
}
