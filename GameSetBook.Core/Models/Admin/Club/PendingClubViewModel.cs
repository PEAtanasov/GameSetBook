namespace GameSetBook.Core.Models.Admin.Club
{
    public class PendingClubViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClubOwner { get; set; }= string.Empty;

        public bool ClubOwnerStatus { get; set; }

        public DateTime RegisteredOn { get; set; }

        public string City { get; set; } = string.Empty;

        public int NumberOfCourts { get; set; }
    }
}
