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
        }
        public string City { get; set; } = null!;

        [Display(Name = "Search by name")]
        public string SearchTerm { get; set; } = null!;

        public ClubSorting ClubSorting { get; set; } = ClubSorting.Newest;

        public int CurrentPage { get; set; } = 1;

        public int ClubsPerPage { get; } = 6;

        public int TotalClubCount { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<ClubServiceViewModel> Clubs { get; set; }
    }
}
