namespace GameSetBook.Core.Models.Admin.Court
{
    public class CourtAdminViewModel
    {
    
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surface { get; set; } = string.Empty;

        public bool IsLighted { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsIndoor { get; set; }

        public bool IsActive { get; set; }

        public int ClubId { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
