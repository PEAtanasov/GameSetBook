namespace GameSetBook.Common
{
    public static class ValidationConstatns
    {
        public static class ClubConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 300;

            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 64;

            public const int PhoneMinLength = 6;
            public const int PhoneMaxLength = 15;

            public const double RatingMinValue = 0.00;
            public const double RatingMaxValue = 10.00;

            public const int ClubLogoUrlMaxLength = 1024;
        }

        public static class CityConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class CountryConstants
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 56;
        }

        public static class CourtConstants
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 20;
        }

        public static class GameSetMatchUpProfileGConstants
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 30;

            public const int DescriptionMaxLength = 30;

            public const int ProfileImageUrlMaxLength = 1024;
        }

        public static class BookingConstants
        {
            public const int ClientNameMaxLength = 50;
        }

        public static class ReviewConstants
        {
            public const int ReviewtTitleMinLength = 1;
            public const int ReviewtTitleMaxLength = 20;

            public const int ReviewtDescriptionMinLength = 1;
            public const int ReviewtDescriptionMaxLength = 100;

            public const int ReviewMinRate = 1;
            public const int ReviewtMaxRate = 10;
        }

    }
}
