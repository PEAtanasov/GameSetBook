using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Models.Admin.Country;

namespace GameSetBook.Core.Models.Admin.City
{
    public class CityDetailsAdminViewModel
    {
        public CityDetailsAdminViewModel()
        {
            Clubs = new List<ClubSimpleAdminViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public CountryAdminServiceModel Country { get; set; } = null!;

        public IEnumerable<ClubSimpleAdminViewModel> Clubs { get; set; }
    }
}
