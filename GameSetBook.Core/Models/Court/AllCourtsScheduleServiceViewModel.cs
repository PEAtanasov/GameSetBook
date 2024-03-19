using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Models.Court
{
    public class AllCourtsScheduleServiceViewModel
    {
        public AllCourtsScheduleServiceViewModel()
        {
            Courts = new List<CourtScheduleViewModel>();
        }
        public ClubInfoViewModel ClubInfo { get; set; } = null!;

        public IEnumerable<CourtScheduleViewModel> Courts { get; set; }
    }
}
