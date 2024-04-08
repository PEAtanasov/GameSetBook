using GameSetBook.Core.Models.Admin.City;
using GameSetBook.Core.Models.City;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICityServiceAdmin
    {
        Task<IEnumerable<CityAdminServiceModel>> GetAllCitiesAsync();

        Task<bool> ExystByNameAsync(string name, int countryId);

        Task AddAsync(CityAddAdminFormModel model);
    }
}
