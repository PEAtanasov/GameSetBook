using GameSetBook.Core.Models.Admin.Country;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICountryServiceAdmin
    {
        Task<IEnumerable<CountryAdminServiceModel>> GetAllCountriesAsync();

        Task<bool> ExistByNameAsync(string name);

        Task AddAsync(CountryAddAdminFormModel model);

        Task<bool> ExistById(int id);

        Task DeleteAsync(int id);

        Task<CountryDetailsAdminViewModel> GetCountryDetailAsync(int id);
    }
}
