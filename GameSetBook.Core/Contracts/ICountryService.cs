using GameSetBook.Core.Models.Admin.Country;
using GameSetBook.Core.Models.Country;

namespace GameSetBook.Core.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryServiceModel>> GetAllCountriesAsync();
    }
}
