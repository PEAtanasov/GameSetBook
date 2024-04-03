using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Club;
using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class AllClubsAdminSortingModel
    {
        public AllClubsAdminSortingModel()
        {
            Cities = new List<string>();
            Countries = new List<string>();
            Clubs = new List<ClubAdminServiceViewModel>();
        }
        public int ClubsPerPage { get; set; } = 5;

        public string City { get; init; } = null!;

        public string Country { get; init; } = null!;

        [Display(Name = "Search by name")]
        public string SearchTerm { get; init; } = null!;

        public ClubSorting ClubSorting { get; init; }

        public ClubStatusSorting ClubStatusSorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalClubCount { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<ClubAdminServiceViewModel> Clubs { get; set; }
    }
}
