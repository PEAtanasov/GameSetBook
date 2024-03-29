namespace GameSetBook.Core.Models.Club
{
    public class ClubDetailsAndInfoViewModel
    {
        public int ClubId { get; set; }

        public ClubInfoViewModel Info { get; set; } = null!;

        public ClubDetailsViewModel Details { get; set; } = null!;

    }
}
