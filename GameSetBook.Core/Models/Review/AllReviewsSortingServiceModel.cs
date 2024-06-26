﻿using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Models.Review
{
    public class AllReviewsSortingServiceModel
    {
        public int ClubId { get; set; }

        public int ReviewsPerPage { get; set; } = 5;

        public int CurrentPage { get; init; } = 1;

        public int TotalReviewCount { get; set; }

        public ReviewSorting ReviewSorting { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();

        public ClubInfoViewModel ClubInfo { get; set; } = null!;
    }
}
