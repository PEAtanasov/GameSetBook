using System.ComponentModel.DataAnnotations;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.CityConstants;

namespace GameSetBook.Core.Models.Admin.City
{
    public class CityAddAdminFormModel
    {
        /// <summary>
        /// City name
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthMessage)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Country identifier
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
    }
}
