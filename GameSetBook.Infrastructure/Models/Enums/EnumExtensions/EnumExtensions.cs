using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameSetBook.Infrastructure.Models.Enums.EnumExtensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name?? null!;
        }
    }
}
