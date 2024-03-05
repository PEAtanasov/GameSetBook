using GameSetBook.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameSetBook.Common.ValidationConstatns.GameSetMatchUpProfileGConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// GameSetMatchUp player profile entity
    /// </summary>
    [Comment("GameSetMatchUp player profile entity")]
    public class GameSetMatchUpPlayerProfile
    {
        public GameSetMatchUpPlayerProfile()
        {
            TournamentsGSMUPlayerProfile = new List<TournamentGSMUPlayerProfile>();
        }
        /// <summary>
        /// Profile identifier
        /// </summary>
        [Key]
        [Comment("Profile identifier")]
        public int Id { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [Comment("User first name")]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [Comment("User last name")]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Player description
        /// </summary>
        [Comment("Player description")]
        [MaxLength(DescriptionMaxLength)]
        public string? PlayerDescription { get; set; }

        /// <summary>
        /// Player's level
        /// </summary>
        [Required]
        [Comment("Player's level")]
        public PlayerLevel PlayerLevel { get; set; }

        /// <summary>
        /// Player's level
        /// </summary>
        [Required]
        [Comment("Player's level")]
        public PlayStyle PlayStyle { get; set; }

        /// <summary>
        /// Url reference to the profile image
        /// </summary>
        [Required]
        [Comment("Url reference to the profile image")]
        [MaxLength(ProfileImageUrlMaxLength)]
        public string ProfileImageUrl { get; set; } = Common.ImageSource.DefaultProfileImageUrl;

        /// <summary>
        /// User identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        public virtual IdentityUser User { get; set; } = null!;

        /// <summary>
        /// User's city
        /// </summary>
        [Required]
        [Comment("User's city")]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;

        /// <summary>
        /// User's country
        /// </summary>
        [Required]
        [Comment("User's country")]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<TournamentGSMUPlayerProfile> TournamentsGSMUPlayerProfile { get; set; }
    }
}
