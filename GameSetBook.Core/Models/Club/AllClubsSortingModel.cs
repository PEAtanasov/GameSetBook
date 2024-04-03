using GameSetBook.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Core.Models.Club
{
    public class AllClubsSortingModel
    {
        public AllClubsSortingModel()
        {
            Clubs = new List<ClubServiceViewModel>();
            Cities = new List<string>();
            Countries = new List<string>();

        }

        public int ClubsPerPage { get; set; } = 5;

        public string City { get; init; } = null!;

        public string Country { get; init; } = null!;

        [Display(Name = "Search by name")]
        public string SearchTerm { get; init; } = null!;

        public ClubSorting ClubSorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalClubCount { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<ClubServiceViewModel> Clubs { get; set; }
    }
}
