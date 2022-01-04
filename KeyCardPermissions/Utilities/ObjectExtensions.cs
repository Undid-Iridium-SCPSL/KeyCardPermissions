using System.Collections;

namespace KeyCardPermissions.Utilities
{

    public static class ObjectExtensions
    {
        public static bool IsNullOrEmpty(this IList List)
        {
            return (List == null || List.Count < 1);
        }

        public static bool IsNullOrEmpty(this IDictionary Dictionary)
        {
            return (Dictionary == null || Dictionary.Count < 1);
        }

        public static bool IsNullOrEmpty(this string String)
        {
            return ((String ?? "").Trim() != "");
        }
    }
}
