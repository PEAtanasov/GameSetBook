namespace GameSetBook.Common
{
    public static class ValidationConstatns
    {
        public static class ClubConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 2000;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 300;

            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 64;

            public const int PhoneMinLength = 6;
            public const int PhoneMaxLength = 15;

            public const double RatingMinValue = 0.00;
            public const double RatingMaxValue = 10.00;

            public const int ClubLogoUrlMaxLength = 1024;

            public const int ClubWorkingHourStartLowerRange = 0;
            public const int ClubWorkingHourStartUpperRange = 12;

            public const int ClubWorkingHourEndLowerrange = 13;
            public const int ClubWorkingHourEndUpperrange = 24;

            public const int MinCoaches = 0;
            public const int MaxCoaches = 100;

            public const int MinCourts = 1;
            public const int MaxCourts = 100;
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

            public const int MinPricePerHour = 0;
            public const int MaxPricePerHour = 500;
        }

        public static class BookingConstants
        {
            public const int ClientNameMinLength = 2;
            public const int ClientNameMaxLength = 100;

            public const int ClientPhoneMinLength = 5;
            public const int ClientPhoneMaxLength = 15;
        }

        public static class ReviewConstants
        {
            public const int ReviewtTitleMinLength = 1;
            public const int ReviewtTitleMaxLength = 20;

            public const int ReviewDescriptionMinLength = 1;
            public const int ReviewDescriptionMaxLength = 100;

            public const int ReviewMinRate = 1;
            public const int ReviewtMaxRate = 10;
        }

        public static class DateTimeFormats
        {
            public const string DateTimeFormat = "yyyy-MM-dd HH:mm";
            public const string DateOnlyFormat = "yyyy-MM-dd";
        }

        public static class ImageSizeConstants
        {
            public const int ClubLogoMaxLength = 5242880;
        }

        public static class ApplicationUserConstans
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 100;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 100;
        }
    }
}
