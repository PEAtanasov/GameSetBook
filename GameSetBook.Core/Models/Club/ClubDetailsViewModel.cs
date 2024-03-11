namespace GameSetBook.Core.Models.Club
{
    public class ClubDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int WorkingTimeStart { get; set; }
        public int WorkingTimeEnd { get; set; }
        public int? NumberOfCoaches { get; set; }
        public int NumberOfCourts { get; set; }
        public bool HasParking { get; set; }
        public bool HasShower { get; set; }
        public bool HasShop { get; set; }
        public bool IsActive { get; set; }
        public ClubInfoViewModel ClubInfo { get; set; } = null!;


        //public double Rating { get; set; }
    }
}
