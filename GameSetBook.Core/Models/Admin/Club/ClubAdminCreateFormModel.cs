using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.ClubConstants;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ImageSource;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubAdminCreateFormModel
    {
        /// <summary>
        /// Club identifier
        /// </summary>
        [Comment("Club identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Club name
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Club Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Club description
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Club Description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Club working time start
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(ClubWorkingHourStartLowerRange, ClubWorkingHourStartUpperRange, ErrorMessage = RangeMessage)]
        [Display(Name = "Working Time Start")]
        public int WorkingTimeStart { get; set; }

        /// <summary>
        /// Club working time start
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(ClubWorkingHourEndLowerrange, ClubWorkingHourEndUpperrange, ErrorMessage = RangeMessage)]
        [Display(Name = "Working Time End")]
        public int WorkingTimeEnd { get; set; }

        /// <summary>
        /// Address of the club
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Club's city identifier
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "City")]
        public int CityId { get; set; }

        /// <summary>
        /// Number of coaches in the club
        /// </summary> 
        [Range(MinCoaches, MaxCoaches, ErrorMessage = RangeMessage)]
        [Display(Name = "Number Of Coaches (optional)")]
        public int? NumberOfCoaches { get; set; }

        /// <summary>
        /// Numbber of courts in the club
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(MinCourts, MaxCourts, ErrorMessage = RangeMessage)]
        [Display(Name = "Number Of Courts The Club Have")]
        public int NumberOfCourts { get; set; }

        /// <summary>
        /// Is car parking for clients available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Parking")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Is shower for clients available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Shower")]
        public bool HasShower { get; set; }

        /// <summary>
        /// Is tennis shop available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Tennis Shop")]
        public bool HasShop { get; set; }

        /// <summary>
        /// Club's logo Url
        /// </summary>
        public string LogoUrl { get; set; } = DefaultClubLogoUrl;

        /// <summary>
        /// Club's email
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthMessage)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Club's phone number
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Club owner email
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name= "Club Owner Email")]
        public string ClubOwnerEmail { get; set; } = string.Empty;

        /// <summary>
        /// Club owner identifier
        /// </summary>
        public string ClubOwnerId { get; set; } = string.Empty;
    }
}
