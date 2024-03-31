using GameSetBook.Core.Models.City;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICityServiceAdmin
    {
        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();
    }
}
