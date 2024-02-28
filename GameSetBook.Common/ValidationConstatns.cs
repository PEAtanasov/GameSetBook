using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public static class CityConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
    }
}
