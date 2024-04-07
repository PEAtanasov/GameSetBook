using GameSetBook.Core.Models.Admin.Court;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubScheduleAdminServiceModel
    {
        public ClubScheduleAdminServiceModel()
        {
            Courts = new List<CourtScheduleAdminViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int WorkingHourStart { get; set; }

        public int WorkingHourEnd { get; set; }

        public DateTime? Date { get; set; }

        public IEnumerable<CourtScheduleAdminViewModel> Courts { get; set; }
    }
}
