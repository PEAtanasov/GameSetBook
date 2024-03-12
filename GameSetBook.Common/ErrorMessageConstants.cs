namespace GameSetBook.Common
{
    public static class ErrorMessageConstants
    {  
        public const int maxImageSize = 5;
        public const string RequiredMessage = "The filed {0} is required";
        public const string StringLengthMessage = "The field {0} must be between {2} and {1} symbols";
        public const string RangeMessage = "The field {0} must be between {1} and {2}";
        public static string ImageSizeToBig = $"The file size must not exceed {ValidationConstatns.ImageSizeConstants.ClubLogoMaxLength/1024/1024} MB.";
        public const string WrongImageFormat = "Please upload an valid image format (JPG, JPEG, GIF, or PNG).";
        public const string UnknownError = "Unknown error" ;
    }
}
