using GameSetBook.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameSetBook.Common.ValidationConstatns.ApplicationUserConstans;

namespace GameSetBook.Infrastructure.Models.Identity
{
    /// <summary>
    /// Extension of the identoty user
    /// </summary>
    [Comment("Extension of the identoty user")]
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// User first name
        /// </summary>
        [Comment("User first name")]
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Comment("User last name")]
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public Club? Club { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
