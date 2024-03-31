using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.ClubConstants;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ImageSource;

namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubEditFormModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Club name
        /// </summary>
        [Required(ErrorMessage =RequiredMessage)]
        [Comment("Club name")]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength,ErrorMessage = StringLengthMessage)]
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
        [Range(ClubWorkingHourStartLowerRange,ClubWorkingHourStartUpperRange)]
        [Display(Name="Working Time Starts At")]
        public int WorkingTimeStart { get; set; }

        /// <summary>
        /// Club working time start
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(ClubWorkingHourEndLowerrange, ClubWorkingHourEndUpperrange)]
        [Display(Name = "Working Time Ends At")]
        public int WorkingTimeEnd { get; set; }

        /// <summary>
        /// Address of the club
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Club Description")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Club's city identifier
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name ="City")]
        public int CityId { get; set; }

        /// <summary>
        /// Number of coaches in the club
        /// </summary> 
        [Range(MinCoaches,MaxCoaches)]
        [Display(Name= "Number Of Coaches (optional)")]
        public int? NumberOfCoaches { get; set; }

        /// <summary>
        /// Numbber of courts in the club
        /// </summary>
       
        public int NumberOfCourts { get; set; }   // just for displaying

        /// <summary>
        /// Is car parking for clients available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name="Parking")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Is shower for clients available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Showers")]
        public bool HasShower { get; set; }

        /// <summary>
        /// Is tennis shop available
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Tennis Shop")]
        public bool HasShop { get; set; }

        public string LogoUrl { get; set; } = DefaultClubLogoUrl;

        /// <summary>
        /// Club's email
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Club's Email")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Club's phone number
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Club's Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsAproovedByAdmin { get; set; }

        public double Rating { get; set; }

        public string ClubOwnerName { get; set; } = string.Empty;

        public int NumberOfActiveCourts { get; set; }

    }
}
    

