using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.CountryConstants;
using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Core.Models.Admin.Country
{
    public class CountryAddAdminFormModel
    {
        /// <summary>
        /// Country name
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
