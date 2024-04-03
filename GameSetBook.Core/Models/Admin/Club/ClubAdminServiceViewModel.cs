namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubAdminServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CityName { get; set; } = string.Empty;

        public string CountryName { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public string ClubOwner {  get; set; } = string.Empty; 

        public decimal Price { get; set; }

        public int WorkingTimeStart { get; set; }

        public int WorkingTimeEnd { get; set; }

        public int NumberofCourts { get; set; }

        public double Rating { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }
    }
}
