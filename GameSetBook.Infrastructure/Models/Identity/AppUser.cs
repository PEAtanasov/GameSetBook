using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameSetBook.Common.ValidationConstatns;

namespace GameSetBook.Infrastructure.Models.Identity
{
    ///// <summary>
    ///// Extension of the identoty user
    ///// </summary>
    //[Comment("Extension of the identoty user")]
    //public class AppUser : IdentityUser
    //{
    //    /// <summary>
    //    /// User first name
    //    /// </summary>
    //    [Required]
    //    [Comment("User first name")]
    //    [MaxLength(FirstNameMaxLength)]
    //    public string FirstName { get; set; } = string.Empty;

    //    /// <summary>
    //    /// User first name
    //    /// </summary>
    //    [Required]
    //    [Comment("User last name")]
    //    [MaxLength(LastNameMaxLength)]
    //    public string LastName { get; set; } = string.Empty;

    //    /// <summary>
    //    /// Does the user have a registered GameSetMatchUpProfile
    //    /// </summary>
    //    [Required]
    //    public bool HasGameSetMatchUpPlayerProfile { get; set; }

    //    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    //}
}
