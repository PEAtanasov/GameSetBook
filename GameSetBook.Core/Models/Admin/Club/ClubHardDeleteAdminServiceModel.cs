using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubHardDeleteAdminServiceModel
    {
        [Required]
        public int Id { get; set; }

        
        public string Name { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public int TotalCourtsCount { get; set; }

        public int TotalBookingsCount { get; set; }

        public int TotalReviewsCount { get; set; }

        public string ClubOwnerEmail { get; set; } = string.Empty;

        [Required]
        public string ClubOwnerId { get; set; } = string.Empty;
    }
}
