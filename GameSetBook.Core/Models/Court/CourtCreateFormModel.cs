﻿using GameSetBook.Common.Enums;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.CourtConstants;

namespace GameSetBook.Core.Models.Court
{
    public class CourtCreateFormModel
    {
        /// <summary>
        /// Court name
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Court Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Court surface
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        public Surface Surface { get; set; }

        /// <summary>
        /// Is the court lighted
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Is The Court Lighted")]
        public bool IsLighted { get; set; }

        /// <summary>
        /// Price for renting court per one hour
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(MinPricePerHour, MaxPricePerHour ,ErrorMessage = RangeMessage)]
        [Display(Name ="Price Per Hour (BGN)")]
        public decimal PricePerHour { get; set; }

        /// <summary>
        /// Is the court indoor
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Is The Court Indoor")]
        public bool IsIndoor { get; set; }

        /// <summary>
        /// Club identifier
        /// </summary>
        [Required]
        public int ClubId { get; set; }
    }
}
