using GameSetBook.Core.Models.Admin.Country;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICountryServiceAdmin
    {
        Task<IEnumerable<CountryViewModel>> GetAllCountriesAsync();
    }
}
