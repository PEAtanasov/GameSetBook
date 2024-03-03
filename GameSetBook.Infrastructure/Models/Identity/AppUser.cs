using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using static GameSetBook.Common.ValidationConstatns.AppUserConstants;

//namespace GameSetBook.Infrastructure.Models.Identity
//{
//    /// <summary>
//    /// Extension of the identoty user
//    /// </summary>
//    [Comment("Extension of the identoty user")]
//    public class AppUser : IdentityUser
//    {
//        /// <summary>
//        /// User first name
//        /// </summary>
//        [Required]
//        [Comment("User first name")]
//        [MaxLength(FirstNameMaxLength)]
//        public string FirstName { get; set; } = string.Empty;

//        /// <summary>
//        /// User first name
//        /// </summary>
//        [Required]
//        [Comment("User last name")]
//        [MaxLength(LastNameMaxLength)]
//        public string LastName { get; set; } = string.Empty;

//        /// <summary>
//        /// Does the user have a registered GameSetMatchUpProfile
//        /// </summary>
//        [Required]
//        public bool HasGameSetMatchUpProfileProfile { get; set; }
        
//        /// <summary>
//        /// User's city
//        /// </summary>
//        [Required]
//        [Comment("User's city")]
//        [ForeignKey(nameof(City))]
//        public int CityId { get; set; }

//        public City City { get; set; } = null!;

//        /// <summary>
//        /// User's country
//        /// </summary>
//        [Required]
//        [Comment("User's country")]
//        [ForeignKey(nameof(Country))]
//        public int CountryId { get; set; }

//        public Country Country { get; set; } = null!;

//        public ICollection<Booking> Bookings {  get; set; } = new List<Booking>(); 
//    }
//}
