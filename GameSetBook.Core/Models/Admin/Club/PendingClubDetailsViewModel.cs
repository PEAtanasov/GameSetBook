using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GameSetBook.Core.Models.Admin.Court;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class PendingClubDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int WorkingTimeStart { get; set; }

        public int WorkingTimeEnd { get; set; }

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int? NumberOfCoaches { get; set; }

        public int NumberOfCourts { get; set; }

        public bool HasParking { get; set; }

        public bool HasShower { get; set; }

        public bool HasShop { get; set; }

        public string LogoUrl { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsAproovedByAdmin { get; set; }

        public string ClubOwnerId { get; set; } = string.Empty;

        public bool IsClubOwnerActive { get; set; }

        public string ClubOwner { get; set; } = string.Empty;

        IEnumerable<PendingCourtViewModel> Courts = new List<PendingCourtViewModel>();
    }
}

