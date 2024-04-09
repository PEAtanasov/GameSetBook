using GameSetBook.Core.Models.Admin.City;
using GameSetBook.Core.Models.Admin.Club;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace GameSetBook.Core.Models.Admin.Country
{
    public class CountryDetailsAdminViewModel
    {
        public CountryDetailsAdminViewModel()
        {
            Cities = new List<CityAdminServiceModel>();
            Clubs= new List<ClubSimpleAdminViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<CityAdminServiceModel> Cities { get; set; }

        public IEnumerable<ClubSimpleAdminViewModel> Clubs { get; set; }
    }
}
