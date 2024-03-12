using GameSetBook.Core.Models;

namespace GameSetBook.Core.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();
    }
}
