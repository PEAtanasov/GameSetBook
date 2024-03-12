using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Web
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = GetEnumDisplayName(e)
                       })
                       .ToList();
        }

        private static string GetEnumDisplayName<TEnum>(TEnum value) where TEnum : Enum
        {
            var memberInfo = typeof(TEnum).GetMember(value.ToString());
            if (memberInfo.Length == 0)
            {
                return value.ToString();
            }

            var displayNameAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                                    .OfType<DisplayAttribute>()
            .FirstOrDefault();

            return displayNameAttribute != null ? displayNameAttribute.Name : value.ToString();
        }
    }
}
