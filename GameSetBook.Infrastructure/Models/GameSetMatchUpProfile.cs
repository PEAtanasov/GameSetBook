﻿using Microsoft.AspNetCore.Identity;
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
    public class GameSetMatchUpProfile
    {
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
        /// Url reference to the profile image
        /// </summary>
        [Required]
        [Comment("Url reference to the profile image")]
        [MaxLength(ProfileImageUrlMaxLength)]
        public string ProfileImageUrl { get; set; } = string.Empty.ToString();

        /// <summary>
        /// User identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;

        /// <summary>
        /// User's city
        /// </summary>
        [Required]
        [Comment("User's city")]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

        /// <summary>
        /// User's country
        /// </summary>
        [Required]
        [Comment("User's country")]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public Country Country { get; set; } = null!;
    }
}
