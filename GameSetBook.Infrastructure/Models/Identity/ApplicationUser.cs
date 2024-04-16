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

        /// <summary>
        /// All bookings of the user
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// User's club
        /// </summary>
        public Club? Club { get; set; }

        /// <summary>
        /// All user's reviews
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
