using GameSetBook.Core.Models.City;

namespace GameSetBook.Core.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityServiceModel>> GetAllCitiesAsync();
    }
}
